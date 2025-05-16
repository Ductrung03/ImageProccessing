using OpenCvSharp;
using System;

namespace ImageProcessing.Processing
{
    public class FlipProcessor
    {
        public enum FlipDirection
        {
            Vertical = 0,     
            Horizontal = 1,    
            Both = -1         
        }

      
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
                    flipMode = (FlipMode)(-1); 
                    break;
                default:
                    throw new ArgumentException("Invalid flip direction");
            }

            Cv2.Flip(input, result, flipMode);
            return result;
        }
    }
}