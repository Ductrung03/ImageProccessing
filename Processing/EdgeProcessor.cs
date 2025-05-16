using OpenCvSharp;
using System;

namespace ImageProcessing.Processing
{
    public class EdgeProcessor
    {
        
        public static Mat ApplyEdgeEnhancement(Mat input, float strength = 1.0f)
        {
         
            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

         
            Mat laplacian = new Mat();
            Cv2.Laplacian(gray, laplacian, MatType.CV_16S, 3);

         
            Mat absLaplacian = new Mat();
            Cv2.ConvertScaleAbs(laplacian, absLaplacian);

          
            Mat enhanced = new Mat();
            Cv2.AddWeighted(gray, 1.0, absLaplacian, strength, 0, enhanced);

           
            if (input.Channels() == 3)
            {
                Mat colorResult = new Mat();
                Cv2.CvtColor(enhanced, colorResult, ColorConversionCodes.GRAY2BGR);
                gray.Dispose();
                laplacian.Dispose();
                absLaplacian.Dispose();
                enhanced.Dispose();
                return colorResult;
            }

            gray.Dispose();
            laplacian.Dispose();
            absLaplacian.Dispose();
            return enhanced;
        }
    }
}