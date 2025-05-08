using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Processing
{
    public static class DynamicBprProcessor
    {
        /// <summary>
        /// Áp dụng thuật toán BPR Dynamic dựa trên phép lọc trung vị có điều kiện
        /// </summary>
        /// <param name="input">Ảnh đầu vào</param>
        /// <param name="threshold">Ngưỡng phát hiện pixel bất thường</param>
        /// <returns>Ảnh đã xử lý</returns>
        public static Mat ApplyDynamicBPR(Mat input, int threshold)
        {
            // Tạo bản sao để lưu kết quả
            Mat result = input.Clone();

            // Tạo bản sao grayscale nếu cần
            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input;

            // Tính toán giá trị trung vị của từng pixel với cửa sổ 3x3
            Mat median = new Mat();
            Cv2.MedianBlur(gray, median, 3);

            // Tính toán hiệu giữa ảnh gốc và ảnh trung vị
            Mat diff = new Mat();
            Cv2.Absdiff(gray, median, diff);

            // Tạo mặt nạ cho các điểm cần thay thế (giá trị khác biệt lớn hơn ngưỡng)
            Mat mask = new Mat();
            Cv2.Compare(diff, new Scalar(threshold), mask, CmpType.GT);

            // Áp dụng mặt nạ: thay thế những pixel có khác biệt lớn với giá trị trung vị
            if (input.Channels() == 1)
            {
                median.CopyTo(result, mask);
            }
            else
            {
                // Với ảnh màu, cần xử lý riêng từng kênh màu
                Mat[] channels = new Mat[3];
                Mat[] medianChannels = new Mat[3];
                Cv2.Split(input, out channels);

                for (int i = 0; i < 3; i++)
                {
                    // Tính trung vị cho từng kênh màu
                    medianChannels[i] = new Mat();
                    Cv2.MedianBlur(channels[i], medianChannels[i], 3);

                    // Áp dụng mặt nạ
                    medianChannels[i].CopyTo(channels[i], mask);
                }

                // Gộp các kênh màu lại
                Cv2.Merge(channels, result);

                // Giải phóng bộ nhớ
                foreach (var channel in channels)
                    channel.Dispose();
                foreach (var channel in medianChannels)
                    channel.Dispose();
            }

            // Giải phóng bộ nhớ
            gray.Dispose();
            median.Dispose();
            diff.Dispose();
            mask.Dispose();

            return result;
        }

        /// <summary>
        /// Áp dụng thuật toán BPR Dynamic với khả năng tinh chỉnh cao hơn
        /// </summary>
        /// <param name="input">Ảnh đầu vào</param>
        /// <param name="threshold">Ngưỡng phát hiện</param>
        /// <param name="kernelSize">Kích thước cửa sổ trung vị (3, 5, hoặc 7)</param>
        /// <returns>Ảnh đã xử lý</returns>
        public static Mat ApplyAdvancedDynamicBPR(Mat input, int threshold, int kernelSize = 3)
        {
            if (kernelSize != 3 && kernelSize != 5 && kernelSize != 7)
                throw new ArgumentException("Kích thước cửa sổ phải là 3, 5 hoặc 7");

            // Chuyển đổi sang grayscale nếu cần
            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input;

            // Tạo bản sao để lưu kết quả
            Mat result = input.Clone();

            // Tính toán ảnh trung vị
            Mat median = new Mat();
            Cv2.MedianBlur(gray, median, kernelSize);

            // Tính độ khác biệt tuyệt đối
            Mat absDiff = new Mat();
            Cv2.Absdiff(gray, median, absDiff);

            // Tạo mặt nạ theo điều kiện
            Mat mask = new Mat();
            Cv2.Compare(absDiff, new Scalar(threshold), mask, CmpType.GT);

            // Đếm số điểm ảnh sẽ bị thay thế
            int pixelCount = Cv2.CountNonZero(mask);

            // Áp dụng phép thay thế
            if (input.Channels() == 1)
            {
                median.CopyTo(result, mask);
            }
            else
            {
                // Tạo một phiên bản trung vị của ảnh màu
                Mat colorMedian = new Mat();
                Cv2.MedianBlur(input, colorMedian, kernelSize);

                // Áp dụng mặt nạ
                colorMedian.CopyTo(result, mask);

                colorMedian.Dispose();
            }

            // Giải phóng bộ nhớ
            if (input != gray)
                gray.Dispose();
            median.Dispose();
            absDiff.Dispose();
            mask.Dispose();

            return result;
        }
    }
}

