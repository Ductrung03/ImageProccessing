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

        /// <summary>
        /// Creates a new Post Accumulation processor
        /// </summary>
        /// <param name="frameCount">Number of frames to accumulate</param>
        /// <param name="step">Step size between frames (default: 1)</param>
        public PostProcessor(int frameCount, int step = 1)
        {
            _frameCount = frameCount;
            _step = step;
            _frameBuffer = new Queue<Mat>();
        }

        /// <summary>
        /// Process a new frame with post accumulation
        /// </summary>
        /// <param name="newFrame">New frame to process</param>
        /// <returns>Accumulated frame result</returns>
        public Mat Process(Mat newFrame)
        {
            // Convert to floating point for better precision in accumulation
            Mat normalizedFrame = new Mat();
            newFrame.ConvertTo(normalizedFrame, MatType.CV_32F);

            // Initialize accumulator if first frame
            if (_accumulatedSum == null)
            {
                _accumulatedSum = normalizedFrame.Clone();
                _frameBuffer.Enqueue(normalizedFrame);

                // Return the first frame as is
                Mat initialOutput = new Mat();  // Đổi tên thành initialOutput
                _accumulatedSum.ConvertTo(initialOutput, MatType.CV_8U);
                return initialOutput;
            }

            // Maintain the buffer size
            if (_frameBuffer.Count >= _frameCount)
            {
                Mat oldestFrame = _frameBuffer.Dequeue();
                Cv2.Subtract(_accumulatedSum, oldestFrame, _accumulatedSum);
                oldestFrame.Dispose();
            }

            // Add new frame to accumulator
            Cv2.Add(_accumulatedSum, normalizedFrame, _accumulatedSum);
            _frameBuffer.Enqueue(normalizedFrame);

            // Calculate result by dividing by number of frames
            Mat finalOutput = new Mat();  // Đổi tên thành finalOutput
            Cv2.Divide(_accumulatedSum, new Scalar(_frameBuffer.Count), finalOutput);
            finalOutput.ConvertTo(finalOutput, MatType.CV_8U);

            return finalOutput;
        }

        /// <summary>
        /// Resets the accumulator
        /// </summary>
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