using OpenCvSharp;
using System;

namespace ImageProcessing.Processing
{
    public class EdgeProcessor
    {
        /// <summary>
        /// Enhance edges in an image using a Laplacian filter
        /// </summary>
        /// <param name="input">Input image</param>
        /// <param name="strength">Edge enhancement strength (0.0-2.0)</param>
        /// <returns>Edge-enhanced image</returns>
        public static Mat ApplyEdgeEnhancement(Mat input, float strength = 1.0f)
        {
            // Convert to grayscale if needed
            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            // Apply Laplacian filter for edge detection
            Mat laplacian = new Mat();
            Cv2.Laplacian(gray, laplacian, MatType.CV_16S, 3);

            // Convert back to CV_8U
            Mat absLaplacian = new Mat();
            Cv2.ConvertScaleAbs(laplacian, absLaplacian);

            // Enhance the original image by adding weighted edges
            Mat enhanced = new Mat();
            Cv2.AddWeighted(gray, 1.0, absLaplacian, strength, 0, enhanced);

            // Clean up
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