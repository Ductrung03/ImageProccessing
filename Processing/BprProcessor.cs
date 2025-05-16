using OpenCvSharp;
using System;
using System.IO;

namespace ImageProcessing.Processing
{
    public static class BprProcessor
    {
        public static Mat ApplyBPR(Mat input, Mat badPixelMask)
        {

            if (input.Size() != badPixelMask.Size())
                throw new ArgumentException("Kích thước ảnh đầu vào và mặt nạ điểm ảnh lỗi phải giống nhau");

 
            Mat result = input.Clone();

   
            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input;


            int height = input.Rows;
            int width = input.Cols;

            unsafe
            {

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        if (badPixelMask.At<byte>(y, x) == 1)
                        {

                            int validNeighbors = 0;
                            int sum = 0;

                            for (int dy = -1; dy <= 1; dy++)
                            {
                                for (int dx = -1; dx <= 1; dx++)
                                {
                                    if (dx == 0 && dy == 0) continue;

                                    int nx = x + dx;
                                    int ny = y + dy;

          
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


                            if (validNeighbors >= 3)
                            {
                                replacementValue = (byte)(sum / validNeighbors);
                            }
                            else
                            {

                                int extendedSum = 0;
                                int extendedNeighbors = 0;

                                for (int dy = -2; dy <= 2; dy++)
                                {
                                    for (int dx = -2; dx <= 2; dx++)
                                    {

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

                                    replacementValue = gray.At<byte>(y, x);
                                }
                            }


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

            if (input != gray)
                gray.Dispose();

            return result;
        }

        
        public static int[,] LoadBPRMask(string path, int width, int height)
        {
            string[] lines = File.ReadAllLines(path);
            int originalHeight = lines.Length;
            int originalWidth = lines[0].Split(';').Length;

            int[,] mask = new int[height, width];


            if (originalHeight != height || originalWidth != width)
            {

                int[,] originalMask = new int[originalHeight, originalWidth];

                for (int y = 0; y < originalHeight; y++)
                {
                    string[] values = lines[y].Split(';');
                    for (int x = 0; x < originalWidth && x < values.Length; x++)
                    {
                        if (int.TryParse(values[x], out int value))
                        {
                            originalMask[y, x] = (value > 0) ? 1 : 0;
                        }
                    }
                }


                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int origX = (int)(x * (float)originalWidth / width);
                        int origY = (int)(y * (float)originalHeight / height);

                        if (origX < originalWidth && origY < originalHeight)
                        {
                            mask[y, x] = originalMask[origY, origX];
                        }
                    }
                }
            }
            else
            {

                for (int y = 0; y < height && y < lines.Length; y++)
                {
                    string[] values = lines[y].Split(';');
                    for (int x = 0; x < width && x < values.Length; x++)
                    {
                        if (int.TryParse(values[x], out int value))
                        {
                            mask[y, x] = (value > 0) ? 1 : 0;
                        }
                    }
                }
            }

            return mask;
        }

        public static Mat CreateMaskMat(int[,] mask)
        {
            int height = mask.GetLength(0);
            int width = mask.GetLength(1);

            Mat maskMat = new Mat(height, width, MatType.CV_8UC1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    maskMat.Set(y, x, (byte)(mask[y, x]));
                }
            }

            return maskMat;
        }

       
        public static System.Drawing.Bitmap ApplyBPR(System.Drawing.Bitmap input, int[,] badPixelMask)
        {

            Mat inputMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(input);


            Mat maskMat = CreateMaskMat(badPixelMask);

  
            Mat resultMat = ApplyBPR(inputMat, maskMat);


            System.Drawing.Bitmap result = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(resultMat);

            inputMat.Dispose();
            maskMat.Dispose();
            resultMat.Dispose();

            return result;
        }
    }
}