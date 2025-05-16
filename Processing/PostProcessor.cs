using OpenCvSharp;
using System.Collections.Generic;

namespace ImageProcessing.Processing
{
    public class PostProcessor
    {
        private readonly int _frameCount;
        private readonly int _step;
        private Queue<Mat> _frameBuffer;
        private Mat _accumulatedSum;

        
        public PostProcessor(int frameCount, int step = 1)
        {
            _frameCount = frameCount;
            _step = step;
            _frameBuffer = new Queue<Mat>();
        }

       
        public Mat Process(Mat newFrame)
        {
           
            Mat normalizedFrame = new Mat();
            newFrame.ConvertTo(normalizedFrame, MatType.CV_32F);

            
            if (_accumulatedSum == null)
            {
                _accumulatedSum = normalizedFrame.Clone();
                _frameBuffer.Enqueue(normalizedFrame);

                
                Mat initialOutput = new Mat(); 
                _accumulatedSum.ConvertTo(initialOutput, MatType.CV_8U);
                return initialOutput;
            }

            
            if (_frameBuffer.Count >= _frameCount)
            {
                Mat oldestFrame = _frameBuffer.Dequeue();
                Cv2.Subtract(_accumulatedSum, oldestFrame, _accumulatedSum);
                oldestFrame.Dispose();
            }

            
            Cv2.Add(_accumulatedSum, normalizedFrame, _accumulatedSum);
            _frameBuffer.Enqueue(normalizedFrame);

           
            Mat finalOutput = new Mat();  
            Cv2.Divide(_accumulatedSum, new Scalar(_frameBuffer.Count), finalOutput);
            finalOutput.ConvertTo(finalOutput, MatType.CV_8U);

            return finalOutput;
        }

        
        public void Reset()
        {
            _accumulatedSum?.Dispose();
            _accumulatedSum = null;

            foreach (var frame in _frameBuffer)
                frame.Dispose();

            _frameBuffer.Clear();
        }
    }
}