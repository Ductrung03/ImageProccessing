using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace ImageProcessing.Processing
{
    public class BinningProcessor
    {
        /// <summary>
        /// Áp dụng binning 2x2 để giảm nhiễu trên ảnh
        /// </summary>
        /// <param name="input">Ảnh đầu vào dạng Mat</param>
        /// <returns>Ảnh Mat đã xử lý với kích thước gốc</returns>
        public static Mat ApplyBinning(Mat input)
        {
            // Tạo bản sao để tránh thay đổi ảnh gốc
            Mat result = new Mat();

            // Đầu tiên giảm kích thước ảnh bằng cách tính trung bình các khối 2x2
            Mat reduced = new Mat();
            Cv2.Resize(input, reduced, new Size(input.Width / 2, input.Height / 2),
                0, 0, InterpolationFlags.Area);

            // Sau đó đổi kích thước trở lại kích thước ban đầu, giữ lại lợi ích giảm nhiễu
            Cv2.Resize(reduced, result, new Size(input.Width, input.Height),
                0, 0, InterpolationFlags.Nearest);

            reduced.Dispose();
            return result;
        }
    }
}