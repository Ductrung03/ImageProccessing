using OpenCvSharp;
using System;
using System.IO;

namespace ImageProcessing.Processing
{
    public static class NucProcessor
    {
        //Công thức Alpha * V + Beta
        public static Mat ApplyNUC(Mat input, float[,] gain, float[,] offset)
        {
            int height = input.Rows;
            int width = input.Cols;

            if (gain.GetLength(0) != height || gain.GetLength(1) != width ||
                offset.GetLength(0) != height || offset.GetLength(1) != width)
                throw new ArgumentException($"Kích thước ảnh ({width}x{height}) không khớp với gain/offset ({gain.GetLength(1)}x{gain.GetLength(0)}).");

            if (input.Type() != MatType.CV_8UC1)
                Cv2.CvtColor(input, input, ColorConversionCodes.BGR2GRAY);

            Mat result = new Mat(height, width, MatType.CV_8UC1);
            var inputIndexer = input.GetGenericIndexer<byte>();
            var resultIndexer = result.GetGenericIndexer<byte>();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float pixel = inputIndexer[y, x];
                    float calibratedValue = pixel * gain[y, x] + offset[y, x];

                    resultIndexer[y, x] = Clamp(calibratedValue);
                }
            }

            return result;
        }

        // Hàm Clamp giá trị pixel
        private static byte Clamp(float value) =>
            (byte)Math.Max(0, Math.Min(255, value));

        // Đọc bảng NUC từ CSV
        public static float[,] LoadCSVToFloatArray(string path, int width, int height)
        {
            float[,] result = new float[height, width];
            var lines = File.ReadAllLines(path);

            if (lines.Length < height)
                throw new Exception("CSV không đủ dòng dữ liệu.");

            for (int i = 0; i < height; i++)
            {
                var values = lines[i].Split(';');

                if (values.Length < width)
                    throw new Exception($"Dòng {i} trong CSV không đủ giá trị cột.");

                for (int j = 0; j < width; j++)
                {
                    result[i, j] = float.Parse(values[j], System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            return result;
        }
    }
}
