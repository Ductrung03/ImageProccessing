using OpenCvSharp;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System;

public static class BprProcessor
{
    public static Bitmap ApplyBPR(Bitmap input, int[,] mask)
    {
        int width = input.Width;
        int height = input.Height;
        Bitmap output = new Bitmap(input);

        // Sử dụng LockBits để tăng hiệu suất
        BitmapData inputData = input.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        BitmapData outputData = output.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        int stride = inputData.Stride;
        unsafe
        {
            byte* inputPtr = (byte*)inputData.Scan0;
            byte* outputPtr = (byte*)outputData.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (mask[y, x] == 1) // Pixel lỗi
                    {
                        int rSum = 0, gSum = 0, bSum = 0, count = 0;
                        List<(int, int)> validNeighbors = new List<(int, int)>();

                        // Kiểm tra 8 pixel xung quanh
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            for (int dx = -1; dx <= 1; dx++)
                            {
                                if (dx == 0 && dy == 0) continue;
                                int nx = x + dx;
                                int ny = y + dy;
                                if (nx >= 0 && nx < width && ny >= 0 && ny < height && mask[ny, nx] == 0)
                                {
                                    validNeighbors.Add((nx, ny));
                                    int index = ny * stride + nx * 3;
                                    bSum += inputPtr[index];
                                    gSum += inputPtr[index + 1];
                                    rSum += inputPtr[index + 2];
                                    count++;
                                }
                            }
                        }

                        // Trường hợp 1: Có pixel tốt xung quanh
                        if (count > 0)
                        {
                            int index = y * stride + x * 3;
                            outputPtr[index] = (byte)(bSum / count);
                            outputPtr[index + 1] = (byte)(gSum / count);
                            outputPtr[index + 2] = (byte)(rSum / count);
                        }
                        // Trường hợp 2: Không đủ pixel tốt, lấy pixel tốt gần nhất
                        else if (validNeighbors.Count > 0)
                        {
                            var (nx, ny) = validNeighbors[0]; // Lấy pixel tốt gần nhất
                            int srcIndex = ny * stride + nx * 3;
                            int dstIndex = y * stride + x * 3;
                            outputPtr[dstIndex] = inputPtr[srcIndex];
                            outputPtr[dstIndex + 1] = inputPtr[srcIndex + 1];
                            outputPtr[dstIndex + 2] = inputPtr[srcIndex + 2];
                        }
                        // Trường hợp 3: Không có pixel tốt, mở rộng ra vòng 16 pixel
                        else
                        {
                            for (int dy = -2; dy <= 2; dy++)
                            {
                                for (int dx = -2; dx <= 2; dx++)
                                {
                                    if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1) continue; // Bỏ qua vòng 8 pixel
                                    int nx = x + dx;
                                    int ny = y + dy;
                                    if (nx >= 0 && nx < width && ny >= 0 && ny < height && mask[ny, nx] == 0)
                                    {
                                        int srcIndex = ny * stride + nx * 3;
                                        int dstIndex = y * stride + x * 3;
                                        outputPtr[dstIndex] = inputPtr[srcIndex];
                                        outputPtr[dstIndex + 1] = inputPtr[srcIndex + 1];
                                        outputPtr[dstIndex + 2] = inputPtr[srcIndex + 2];
                                        goto Found; // Thoát khi tìm thấy pixel tốt
                                    }
                                }
                            }
                            // Nếu không tìm thấy pixel tốt, giữ nguyên pixel
                        }
                    Found:;
                    }
                }
            }
        }
        input.UnlockBits(inputData);
        output.UnlockBits(outputData);
        return output;
    }

    public static int[,] LoadBPRMask(string path, int targetWidth, int targetHeight)
    {
        try
        {
            var lines = File.ReadAllLines(path);
            int originalHeight = lines.Length;
            int originalWidth = lines[0].Split(';').Length;

            // Đọc mặt nạ gốc
            int[,] originalMask = new int[originalHeight, originalWidth];
            for (int y = 0; y < originalHeight; y++)
            {
                var parts = lines[y].Split(';');
                if (parts.Length != originalWidth)
                    throw new Exception($"Số cột trong dòng {y} ({parts.Length}) không khớp với chiều rộng mặt nạ ({originalWidth}).");

                for (int x = 0; x < originalWidth; x++)
                {
                    if (!int.TryParse(parts[x], out int value) || (value != 0 && value != 1))
                        throw new Exception($"Giá trị tại ({y}, {x}) không hợp lệ: {parts[x]}");
                    originalMask[y, x] = value;
                }
            }

            // Nếu kích thước mặt nạ khớp với kích thước mục tiêu, trả về ngay
            if (originalWidth == targetWidth && originalHeight == targetHeight)
                return originalMask;

            // Resize mặt nạ bằng cách sử dụng OpenCvSharp
            using (Mat maskMat = new Mat(originalHeight, originalWidth, MatType.CV_8UC1))
            {
                for (int y = 0; y < originalHeight; y++)
                {
                    for (int x = 0; x < originalWidth; x++)
                    {
                        maskMat.At<byte>(y, x) = (byte)originalMask[y, x];
                    }
                }

                using (Mat resizedMaskMat = new Mat())
                {
                    Cv2.Resize(maskMat, resizedMaskMat, new OpenCvSharp.Size(targetWidth, targetHeight), 0, 0, InterpolationFlags.Nearest);
                    int[,] resizedMask = new int[targetHeight, targetWidth];
                    for (int y = 0; y < targetHeight; y++)
                    {
                        for (int x = 0; x < targetWidth; x++)
                        {
                            resizedMask[y, x] = resizedMaskMat.At<byte>(y, x);
                        }
                    }
                    return resizedMask;
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi đọc file mặt nạ {Path.GetFileName(path)}: {ex.Message}");
        }
    }
}