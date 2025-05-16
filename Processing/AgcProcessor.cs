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

        public static Mat ApplyAgc(Mat input, AgcMode mode, double limitMin = 0, double limitMax = 255,
                                  double thresholdMin = 0, double thresholdMax = 255)
        {
            Mat result = new Mat();

            switch (mode)
            {
                case AgcMode.Auto:
                    double minVal, maxVal;
                    Point minLoc, maxLoc;
                    Cv2.MinMaxLoc(input, out minVal, out maxVal, out minLoc, out maxLoc);
                    Cv2.Normalize(input, result, 0, 255, NormTypes.MinMax);
                    break;

                case AgcMode.SemiAuto:
                    Mat mask = new Mat();
                    Cv2.InRange(input, new Scalar(thresholdMin), new Scalar(thresholdMax), mask);
                    Cv2.Normalize(input, result, limitMin, limitMax, NormTypes.MinMax, -1, mask);
                    mask.Dispose();
                    break;

                case AgcMode.Manual:
                    result = input.Clone();
                    Cv2.Normalize(result, result, limitMin, limitMax, NormTypes.MinMax);
                    break;
            }

            return result;
        }

        public static Mat ApplyHistogramEqualization(Mat input)
        {
            Mat result = new Mat();

            if (input.Channels() == 1)
            {
                Cv2.EqualizeHist(input, result);
            }
            else
            {
                Mat ycrcb = new Mat();
                Cv2.CvtColor(input, ycrcb, ColorConversionCodes.BGR2YCrCb);

                Mat[] channels = new Mat[3];
                Cv2.Split(ycrcb, out channels);

                Cv2.EqualizeHist(channels[0], channels[0]);

                Cv2.Merge(channels, ycrcb);
                Cv2.CvtColor(ycrcb, result, ColorConversionCodes.YCrCb2BGR);

                ycrcb.Dispose();
                foreach (var channel in channels)
                    channel.Dispose();
            }

            return result;
        }
    }
}
