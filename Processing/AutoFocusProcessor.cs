using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;

namespace ImageProcessing.Processing
{
    public static class AutoFocusProcessor
    {
        /// <summary>
        /// Lấy vùng sắc nét nhất từ ảnh đầu vào dưới dạng Mat
        /// </summary>
        /// <param name="image">Ảnh đầu vào</param>
        /// <param name="gridRows">Số hàng để chia ảnh</param>
        /// <param name="gridCols">Số cột để chia ảnh</param>
        /// <returns>Mat chứa vùng sắc nét nhất</returns>
        public static Mat GetSharpestRegionMat(Mat image, int gridRows = 5, int gridCols = 5)
        {
            if (image == null || image.Empty()) return null;

            int width = image.Width;
            int height = image.Height;
            int regionWidth = width / gridCols;
            int regionHeight = height / gridRows;

            double maxSharpness = 0;
            Rect sharpestRegion = new Rect();

            for (int row = 0; row < gridRows; row++)
            {
                for (int col = 0; col < gridCols; col++)
                {
                    int x = col * regionWidth;
                    int y = row * regionHeight;
                    int w = Math.Min(regionWidth, width - x);
                    int h = Math.Min(regionHeight, height - y);

                    if (w <= 0 || h <= 0) continue;

                    Rect region = new Rect(x, y, w, h);
                    using (Mat regionMat = new Mat(image, region))
                    {
                        double sharpness = CalculateSharpness(regionMat);
                        if (sharpness > maxSharpness)
                        {
                            maxSharpness = sharpness;
                            sharpestRegion = region;
                        }
                    }
                }
            }

            if (maxSharpness > 0)
            {
                return new Mat(image, sharpestRegion).Clone();
            }

            return null;
        }

        /// <summary>
        /// Tính toán độ sắc nét của ảnh
        /// </summary>
        /// <param name="frame">Ảnh đầu vào</param>
        /// <returns>Giá trị độ sắc nét - giá trị cao hơn biểu thị ảnh sắc nét hơn</returns>
        public static double CalculateSharpness(Mat frame)
        {
            using (var gray = new Mat())
            using (var denoised = new Mat())
            using (var lap = new Mat())
            {
                if (frame.Channels() > 1)
                    Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
                else
                    frame.CopyTo(gray);

                Cv2.GaussianBlur(gray, denoised, new Size(3, 3), 0);
                Cv2.Laplacian(denoised, lap, MatType.CV_16S);

                Cv2.MeanStdDev(lap, out _, out Scalar stddev);
                return stddev.Val0 * stddev.Val0; // Phương sai như là chỉ số độ sắc nét
            }
        }

        /// <summary>
        /// Tìm frame sắc nét nhất trong video
        /// </summary>
        /// <param name="videoPath">Đường dẫn tới file video</param>
        /// <returns>Frame sắc nét nhất dưới dạng Mat</returns>
        public static Mat FindSharpestFrame(string videoPath)
        {
            using (var cap = new VideoCapture(videoPath))
            {
                if (!cap.IsOpened()) return null;

                Mat sharpestFrame = new Mat();
                double maxSharpness = 0;

                using (var frame = new Mat())
                {
                    while (cap.Read(frame))
                    {
                        if (frame.Empty()) break;

                        double sharpness = CalculateSharpness(frame);
                        if (sharpness > maxSharpness)
                        {
                            maxSharpness = sharpness;
                            if (!sharpestFrame.Empty()) sharpestFrame.Dispose();
                            sharpestFrame = frame.Clone();
                        }
                    }
                }

                return sharpestFrame.Empty() ? null : sharpestFrame;
            }
        }

        /// <summary>
        /// Tăng cường độ sắc nét của ảnh
        /// </summary>
        /// <param name="image">Ảnh đầu vào</param>
        /// <param name="amount">Mức độ làm sắc nét (0.0-2.0)</param>
        /// <returns>Ảnh đã được làm sắc nét</returns>
        public static Mat EnhanceSharpness(Mat image, double amount = 1.0)
        {
            if (image == null || image.Empty()) return null;

            // Chuyển sang ảnh xám nếu cần
            Mat gray = new Mat();
            if (image.Channels() > 1)
                Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
            else
                image.CopyTo(gray);

            // Áp dụng làm mờ Gaussian
            Mat blurred = new Mat();
            Cv2.GaussianBlur(gray, blurred, new Size(0, 0), 3);

            // Kỹ thuật unsharp mask
            Mat sharpened = new Mat();
            Cv2.AddWeighted(gray, 1.0 + amount, blurred, -amount, 0, sharpened);

            // Chuyển lại sang BGR nếu cần
            Mat result;
            if (image.Channels() > 1)
            {
                result = new Mat();
                Cv2.CvtColor(sharpened, result, ColorConversionCodes.GRAY2BGR);
            }
            else
            {
                result = sharpened.Clone();
            }

            // Dọn dẹp
            gray.Dispose();
            blurred.Dispose();
            sharpened.Dispose();

            return result;
        }

        /// <summary>
        /// Tính toán chỉ số focus tại nhiều điểm trong ảnh
        /// </summary>
        /// <param name="image">Ảnh đầu vào</param>
        /// <param name="gridSize">Kích thước lưới</param>
        /// <returns>Ma trận chứa các chỉ số focus</returns>
        public static Mat CalculateFocusMap(Mat image, int gridSize = 16)
        {
            if (image == null || image.Empty()) return null;

            int width = image.Width;
            int height = image.Height;
            int blockWidth = width / gridSize;
            int blockHeight = height / gridSize;

            Mat focusMap = Mat.Zeros(MatType.CV_32F, new int[] { gridSize, gridSize });

            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    int startX = x * blockWidth;
                    int startY = y * blockHeight;
                    int w = Math.Min(blockWidth, width - startX);
                    int h = Math.Min(blockHeight, height - startY);

                    if (w <= 0 || h <= 0) continue;

                    Rect region = new Rect(startX, startY, w, h);
                    using (Mat block = new Mat(image, region))
                    {
                        double sharpness = CalculateSharpness(block);
                        focusMap.Set(y, x, (float)sharpness);
                    }
                }
            }

            return focusMap;
        }

        /// <summary>
        /// Hiển thị trực quan các chỉ số focus trên ảnh
        /// </summary>
        /// <param name="image">Ảnh đầu vào</param>
        /// <param name="gridSize">Kích thước lưới</param>
        /// <returns>Ảnh trực quan hóa các chỉ số focus</returns>
        public static Mat VisualizeFocusMap(Mat image, int gridSize = 16)
        {
            Mat focusMap = CalculateFocusMap(image, gridSize);
            if (focusMap == null) return null;

            // Chuẩn hóa focus map để hiển thị
            Mat normalizedMap = new Mat();
            Cv2.Normalize(focusMap, normalizedMap, 0, 255, NormTypes.MinMax);
            normalizedMap.ConvertTo(normalizedMap, MatType.CV_8U);

            // Thay đổi kích thước về kích thước ảnh gốc
            Mat resizedMap = new Mat();
            Cv2.Resize(normalizedMap, resizedMap, image.Size(), 0, 0, InterpolationFlags.Nearest);

            // Áp dụng bảng màu
            Mat colorMap = new Mat();
            Cv2.ApplyColorMap(resizedMap, colorMap, ColormapTypes.Jet);

            // Trộn với ảnh gốc
            Mat result = new Mat();
            if (image.Channels() == 1)
            {
                Mat colorImage = new Mat();
                Cv2.CvtColor(image, colorImage, ColorConversionCodes.GRAY2BGR);
                Cv2.AddWeighted(colorImage, 0.7, colorMap, 0.3, 0, result);
                colorImage.Dispose();
            }
            else
            {
                Cv2.AddWeighted(image, 0.7, colorMap, 0.3, 0, result);
            }

            // Dọn dẹp
            focusMap.Dispose();
            normalizedMap.Dispose();
            resizedMap.Dispose();
            colorMap.Dispose();

            return result;
        }

        // Phương thức cũ để tương thích ngược - trả về Bitmap
        public static System.Drawing.Bitmap GetSharpestRegion(Mat image, int gridRows = 5, int gridCols = 5)
        {
            Mat sharpestRegionMat = GetSharpestRegionMat(image, gridRows, gridCols);
            if (sharpestRegionMat == null || sharpestRegionMat.Empty())
                return null;

            System.Drawing.Bitmap result = BitmapConverter.ToBitmap(sharpestRegionMat);
            sharpestRegionMat.Dispose();
            return result;
        }
    }
}