using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace ImageProcessing.Processing
{
    public class BinningProcessor
    {
        /// <summary>
        /// Applies 2x2 binning to reduce noise on the image
        /// </summary>
        /// <param name="input">Input Mat image</param>
        /// <returns>Processed Mat with original dimensions</returns>
        public static Mat ApplyBinning(Mat input)
        {
            // Create a copy to avoid modifying original
            Mat result = new Mat();

            // First reduce the image by averaging 2x2 blocks
            Mat reduced = new Mat();
            Cv2.Resize(input, reduced, new Size(input.Width / 2, input.Height / 2),
                0, 0, InterpolationFlags.Area);

            // Then resize back to original dimensions, maintaining the reduced noise benefit
            Cv2.Resize(reduced, result, new Size(input.Width, input.Height),
                0, 0, InterpolationFlags.Nearest);

            reduced.Dispose();
            return result;
        }
    }
}