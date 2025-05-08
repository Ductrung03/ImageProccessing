using OpenCvSharp;
using System.Collections.Generic;

namespace ImageProcessing.Processing
{
    public class PostProcessor
    {
        private readonly int _frameCount;
        private Queue<Mat> _buffer;
        private Mat _sum;

        public PostProcessor(int frameCount)
        {
            _frameCount = frameCount;
            _buffer = new Queue<Mat>();
        }

        public Mat Process(Mat newFrame)
        {
            Mat normalized = newFrame / _frameCount;

            if (_sum == null)
            {
                _sum = normalized.Clone();
                _buffer.Enqueue(normalized);
                return _sum.Clone();
            }

            if (_buffer.Count < _frameCount)
            {
                _sum += normalized;
                _buffer.Enqueue(normalized);
            }
            else
            {
                _sum += normalized;
                Mat old = _buffer.Dequeue();
                _sum -= old;
                old.Dispose();
                _buffer.Enqueue(normalized);
            }

            return _sum.Clone();
        }

        public void Reset()
        {
            foreach (var f in _buffer) f.Dispose();
            _buffer.Clear();
            _sum?.Dispose();
            _sum = null;
        }
    }
}
