using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Processing
{
    public static class DynamicBprProcessor
    {
       
        public static Mat ApplyDynamicBPR(Mat input, int threshold)
        {

            Mat result = input.Clone();

            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input;

            Mat median = new Mat();
            Cv2.MedianBlur(gray, median, 3);

            Mat diff = new Mat();
            Cv2.Absdiff(gray, median, diff);

            Mat mask = new Mat();
            Cv2.Compare(diff, new Scalar(threshold), mask, CmpType.GT);

            if (input.Channels() == 1)
            {
                median.CopyTo(result, mask);
            }
            else
            {

                Mat[] channels = new Mat[3];
                Mat[] medianChannels = new Mat[3];
                Cv2.Split(input, out channels);

                for (int i = 0; i < 3; i++)
                {
  
                    medianChannels[i] = new Mat();
                    Cv2.MedianBlur(channels[i], medianChannels[i], 3);

                    medianChannels[i].CopyTo(channels[i], mask);
                }


                Cv2.Merge(channels, result);


                foreach (var channel in channels)
                    channel.Dispose();
                foreach (var channel in medianChannels)
                    channel.Dispose();
            }

            gray.Dispose();
            median.Dispose();
            diff.Dispose();
            mask.Dispose();

            return result;
        }

        public static Mat ApplyAdvancedDynamicBPR(Mat input, int threshold, int kernelSize = 3)
        {
            if (kernelSize != 3 && kernelSize != 5 && kernelSize != 7)
                throw new ArgumentException("Kích thước cửa sổ phải là 3, 5 hoặc 7");

            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input;

            Mat result = input.Clone();

            Mat median = new Mat();
            Cv2.MedianBlur(gray, median, kernelSize);

            Mat absDiff = new Mat();
            Cv2.Absdiff(gray, median, absDiff);

            Mat mask = new Mat();
            Cv2.Compare(absDiff, new Scalar(threshold), mask, CmpType.GT);

            int pixelCount = Cv2.CountNonZero(mask);

            if (input.Channels() == 1)
            {
                median.CopyTo(result, mask);
            }
            else
            {

                Mat colorMedian = new Mat();
                Cv2.MedianBlur(input, colorMedian, kernelSize);

              
                colorMedian.CopyTo(result, mask);

                colorMedian.Dispose();
            }


            if (input != gray)
                gray.Dispose();
            median.Dispose();
            absDiff.Dispose();
            mask.Dispose();

            return result;
        }
    }
}

