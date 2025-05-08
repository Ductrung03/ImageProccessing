using OpenCvSharp;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System;

public static class BprProcessor
{
    /// <summary>
    /// Thay thế điểm ảnh lỗi sử dụng OpenCV Mat
    /// </summary>
    /// <param name="input">Ảnh đầu vào</param>
    /// <param name="badPixelMask">Mặt nạ điểm ảnh lỗi (1: lỗi, 0: tốt)</param>
    /// <returns>Ảnh đã được xử lý</returns>
    public static Mat ApplyBPR(Mat input, Mat badPixelMask)
    {
        // Kiểm tra kích thước
        if (input.Size() != badPixelMask.Size())
            throw new ArgumentException("Kích thước ảnh đầu vào và mặt nạ điểm ảnh lỗi phải giống nhau");

        // Tạo bản sao để lưu kết quả
        Mat result = input.Clone();

        // Convert ảnh sang grayscale nếu cần
        Mat gray = new Mat();
        if (input.Channels() == 3)
            Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
        else
            gray = input;

        // Lấy kích thước ảnh
        int height = input.Rows;
        int width = input.Cols;

        unsafe
        {
            // Thực hiện thuật toán thay thế
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Kiểm tra nếu là điểm ảnh lỗi
                    if (badPixelMask.At<byte>(y, x) == 1)
                    {
                        // Trường hợp 1: Kiểm tra 8 pixel xung quanh
                        int validNeighbors = 0;
                        int sum = 0;

                        for (int dy = -1; dy <= 1; dy++)
                        {
                            for (int dx = -1; dx <= 1; dx++)
                            {
                                if (dx == 0 && dy == 0) continue; // Bỏ qua điểm hiện tại

                                int nx = x + dx;
                                int ny = y + dy;

                                // Kiểm tra giới hạn ảnh
                                if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                                {
                                    // Kiểm tra xem pixel này có tốt không
                                    if (badPixelMask.At<byte>(ny, nx) == 0)
                                    {
                                        sum += gray.At<byte>(ny, nx);
                                        validNeighbors++;
                                    }
                                }
                            }
                        }

                        byte replacementValue;

                        // Nếu có đủ điểm lân cận tốt
                        if (validNeighbors >= 3)
                        {
                            replacementValue = (byte)(sum / validNeighbors);
                        }
                        else
                        {
                            // Trường hợp 2: Mở rộng ra vòng 16 pixel
                            int extendedSum = 0;
                            int extendedNeighbors = 0;

                            for (int dy = -2; dy <= 2; dy++)
                            {
                                for (int dx = -2; dx <= 2; dx++)
                                {
                                    // Bỏ qua vòng trong (đã kiểm tra ở trên)
                                    if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1) continue;

                                    int nx = x + dx;
                                    int ny = y + dy;

                                    if (nx >= 0 && nx < width && ny >= 0 && ny < height)
                                    {
                                        if (badPixelMask.At<byte>(ny, nx) == 0)
                                        {
                                            extendedSum += gray.At<byte>(ny, nx);
                                            extendedNeighbors++;
                                        }
                                    }
                                }
                            }

                            if (extendedNeighbors > 0)
                            {
                                replacementValue = (byte)(extendedSum / extendedNeighbors);
                            }
                            else
                            {
                                // Trường hợp 3: Nếu không có điểm tốt, giữ nguyên giá trị gốc
                                replacementValue = gray.At<byte>(y, x);
                            }
                        }

                        // Gán giá trị vào ảnh kết quả
                        if (input.Channels() == 3)
                        {
                            Vec3b color = new Vec3b(replacementValue, replacementValue, replacementValue);
                            result.Set(y, x, color);
                        }
                        else
                        {
                            result.Set(y, x, replacementValue);
                        }
                    }
                }
            }
        }

        // Giải phóng tài nguyên
        if (input != gray)
            gray.Dispose();

        return result;
    }

    /// <summary>
    /// Load nhiều mặt nạ điểm ảnh lỗi và kết hợp chúng
    /// </summary>
    /// <param name="maskPaths">Danh sách đường dẫn tới các tệp CSV</param>
    /// <param name="width">Chiều rộng mặt nạ</param>
    /// <param name="height">Chiều cao mặt nạ</param>
    /// <returns>Mặt nạ kết hợp</returns>
    public static Mat CombineBadPixelMasks(string[] maskPaths, int width, int height)
    {
        Mat combinedMask = Mat.Zeros(height, width, MatType.CV_8UC1);

        foreach (string maskPath in maskPaths)
        {
            if (!File.Exists(maskPath))
                throw new FileNotFoundException($"Không tìm thấy file mặt nạ: {maskPath}");

            Mat mask = LoadBadPixelMask(maskPath, width, height);

            // Kết hợp mặt nạ bằng phép OR
            Cv2.BitwiseOr(combinedMask, mask, combinedMask);

            mask.Dispose();
        }

        return combinedMask;
    }

    /// <summary>
    /// Đọc mặt nạ điểm ảnh lỗi từ file CSV
    /// </summary>
    private static Mat LoadBadPixelMask(string path, int targetWidth, int targetHeight)
    {
        string[] lines = File.ReadAllLines(path);
        int originalHeight = lines.Length;
        int originalWidth = lines[0].Split(';').Length;

        Mat originalMask = new Mat(originalHeight, originalWidth, MatType.CV_8UC1);

        for (int y = 0; y < originalHeight; y++)
        {
            string[] values = lines[y].Split(';');
            for (int x = 0; x < originalWidth; x++)
            {
                if (int.TryParse(values[x], out int value))
                {
                    originalMask.Set(y, x, (byte)(value > 0 ? 1 : 0));
                }
            }
        }

        // Resize mặt nạ nếu cần
        if (originalWidth != targetWidth || originalHeight != targetHeight)
        {
            Mat resizedMask = new Mat();
            Cv2.Resize(originalMask, resizedMask, new OpenCvSharp.Size(targetWidth, targetHeight),
                       interpolation: InterpolationFlags.Nearest);
            originalMask.Dispose();
            return resizedMask;
        }

        return originalMask;
    }
}
