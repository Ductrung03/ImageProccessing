using OpenCvSharp;
using System;

namespace ImageProcessing.Processing
{
    public class AgcProcessor
    {
        public enum AgcMode
        {
            Auto,
            SemiAuto,
            Manual
        }

        /// <summary>
        /// Apply Auto Gain Control to enhance image contrast
        /// </summary>
        /// <param name="input">Input image</param>
        /// <param name="mode">AGC mode</param>
        /// <param name="limitMin">Lower limit (for manual and semi-auto modes)</param>
        /// <param name="limitMax">Upper limit (for manual and semi-auto modes)</param>
        /// <param name="thresholdMin">Minimum threshold (for semi-auto mode)</param>
        /// <param name="thresholdMax">Maximum threshold (for semi-auto mode)</param>
        /// <returns>Enhanced image</returns>
        public static Mat ApplyAgc(Mat input, AgcMode mode, double limitMin = 0, double limitMax = 255,
                                  double thresholdMin = 0, double thresholdMax = 255)
        {
            Mat result = new Mat();

            switch (mode)
            {
                case AgcMode.Auto:
                    // Auto mode: normalize using min/max of entire image
                    double minVal, maxVal;
                    Point minLoc, maxLoc;
                    Cv2.MinMaxLoc(input, out minVal, out maxVal, out minLoc, out maxLoc);
                    Cv2.Normalize(input, result, 0, 255, NormTypes.MinMax);
                    break;

                case AgcMode.SemiAuto:
                    // Semi-auto: normalize using the specified threshold percentages
                    Mat mask = new Mat();
                    Cv2.InRange(input, new Scalar(thresholdMin), new Scalar(thresholdMax), mask);
                    Cv2.Normalize(input, result, limitMin, limitMax, NormTypes.MinMax, -1, mask);
                    mask.Dispose();
                    break;

                case AgcMode.Manual:
                    // Manual: apply specific limits provided by user
                    result = input.Clone();
                    Cv2.Normalize(result, result, limitMin, limitMax, NormTypes.MinMax);
                    break;
            }

            return result;
        }

        /// <summary>
        /// Apply histogram equalization for contrast enhancement
        /// </summary>
        public static Mat ApplyHistogramEqualization(Mat input)
        {
            Mat result = new Mat();

            if (input.Channels() == 1)
            {
                // For grayscale images
                Cv2.EqualizeHist(input, result);
            }
            else
            {
                // For color images, convert to YCrCb, equalize Y channel, convert back
                Mat ycrcb = new Mat();
                Cv2.CvtColor(input, ycrcb, ColorConversionCodes.BGR2YCrCb);

                // Split channels
                Mat[] channels = new Mat[3];
                Cv2.Split(ycrcb, out channels);

                // Equalize the Y channel
                Cv2.EqualizeHist(channels[0], channels[0]);

                // Merge back
                Cv2.Merge(channels, ycrcb);

                // Convert back to BGR
                Cv2.CvtColor(ycrcb, result, ColorConversionCodes.YCrCb2BGR);

                // Cleanup
                ycrcb.Dispose();
                foreach (var channel in channels)
                    channel.Dispose();
            }

            return result;
        }
    }
}