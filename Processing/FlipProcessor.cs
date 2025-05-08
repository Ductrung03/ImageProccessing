using OpenCvSharp;
using System;

namespace ImageProcessing.Processing
{
    public class FlipProcessor
    {
        public enum FlipDirection
        {
            Vertical = 0,      // Lật theo chiều dọc (OpenCV: flipCode = 0)
            Horizontal = 1,    // Lật theo chiều ngang (OpenCV: flipCode = 1)
            Both = -1          // Lật theo cả hai chiều (OpenCV: flipCode = -1)
        }

        /// <summary>
        /// Flips an image horizontally, vertically, or both
        /// </summary>
        /// <param name="input">Input image</param>
        /// <param name="mode">Flip mode</param>
        /// <returns>Flipped image</returns>
        public static Mat ApplyFlip(Mat input, FlipDirection direction)
        {
            Mat result = new Mat();
            FlipMode flipMode;

            switch (direction)
            {
                case FlipDirection.Vertical:
                    flipMode = FlipMode.X;
                    break;
                case FlipDirection.Horizontal:
                    flipMode = FlipMode.Y;
                    break;
                case FlipDirection.Both:
                    flipMode = (FlipMode)(-1); // Ép kiểu -1 sang FlipMode
                    break;
                default:
                    throw new ArgumentException("Invalid flip direction");
            }

            Cv2.Flip(input, result, flipMode);
            return result;
        }
    }
}