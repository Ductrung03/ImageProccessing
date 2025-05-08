using OpenCvSharp;
using System;
using System.IO;

namespace ImageProcessing.Processing
{
    public class BprProcessor
    {
        /// <summary>
        /// Apply Bad Pixel Replacement to an image
        /// </summary>
        /// <param name="input">Input image</param>
        /// <param name="badPixelMask">Bad pixel mask (1 = bad pixel, 0 = good pixel)</param>
        /// <returns>Image with bad pixels replaced</returns>
        public static Mat ApplyBpr(Mat input, Mat badPixelMask)
        {
            // Ensure mask and input are same size
            if (input.Size() != badPixelMask.Size())
                throw new ArgumentException("Input image and bad pixel mask must have the same dimensions");

            // Clone input to avoid modifying original
            Mat result = input.Clone();

            // Convert to grayscale if color image
            Mat gray = new Mat();
            if (input.Channels() == 3)
                Cv2.CvtColor(input, gray, ColorConversionCodes.BGR2GRAY);
            else
                gray = input.Clone();

            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    // Skip if not a bad pixel
                    if (badPixelMask.At<byte>(y, x) == 0)
                        continue;

                    // Method 1: Replace with average of 8 surrounding pixels
                    int validNeighbors = 0;
                    int sum = 0;

                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            if (dx == 0 && dy == 0) continue;

                            int nx = x + dx;
                            int ny = y + dy;

                            if (nx >= 0 && nx < input.Width && ny >= 0 && ny < input.Height)
                            {
                                // Only use good pixels for replacement
                                if (badPixelMask.At<byte>(ny, nx) == 0)
                                {
                                    sum += gray.At<byte>(ny, nx);
                                    validNeighbors++;
                                }
                            }
                        }
                    }

                    // If enough valid neighbors, use their average
                    if (validNeighbors >= 3)
                    {
                        byte replacementValue = (byte)(sum / validNeighbors);

                        if (input.Channels() == 3)
                        {
                            result.At<Vec3b>(y, x) = new Vec3b(replacementValue, replacementValue, replacementValue);
                        }
                        else
                        {
                            result.At<byte>(y, x) = replacementValue;
                        }
                    }
                    else
                    {
                        // Method 2: Try 5x5 neighborhood (16 outer pixels)
                        int extendedSum = 0;
                        int extendedValidNeighbors = 0;

                        for (int dy = -2; dy <= 2; dy++)
                        {
                            for (int dx = -2; dx <= 2; dx++)
                            {
                                if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1) continue;

                                int nx = x + dx;
                                int ny = y + dy;

                                if (nx >= 0 && nx < input.Width && ny >= 0 && ny < input.Height)
                                {
                                    if (badPixelMask.At<byte>(ny, nx) == 0)
                                    {
                                        extendedSum += gray.At<byte>(ny, nx);
                                        extendedValidNeighbors++;
                                    }
                                }
                            }
                        }

                        if (extendedValidNeighbors > 0)
                        {
                            byte replacementValue = (byte)(extendedSum / extendedValidNeighbors);

                            if (input.Channels() == 3)
                            {
                                result.At<Vec3b>(y, x) = new Vec3b(replacementValue, replacementValue, replacementValue);
                            }
                            else
                            {
                                result.At<byte>(y, x) = replacementValue;
                            }
                        }
                    }
                }
            }

            gray.Dispose();
            return result;
        }

        /// <summary>
        /// Load bad pixel mask from CSV file
        /// </summary>
        /// <param name="filePath">Path to CSV file</param>
        /// <param name="width">Output width</param>
        /// <param name="height">Output height</param>
        /// <returns>Bad pixel mask as Mat</returns>
        public static Mat LoadBadPixelMask(string filePath, int width, int height)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Bad pixel mask file not found: {filePath}");

            string[] lines = File.ReadAllLines(filePath);
            int fileHeight = lines.Length;
            int fileWidth = lines[0].Split(';').Length;

            Mat mask = new Mat(fileHeight, fileWidth, MatType.CV_8UC1);

            for (int y = 0; y < fileHeight; y++)
            {
                string[] values = lines[y].Split(';');
                for (int x = 0; x < Math.Min(fileWidth, values.Length); x++)
                {
                    if (int.TryParse(values[x], out int value))
                    {
                        mask.At<byte>(y, x) = (byte)(value > 0 ? 1 : 0);
                    }
                }
            }

            // Resize if needed
            if (fileWidth != width || fileHeight != height)
            {
                Mat resized = new Mat();
                Cv2.Resize(mask, resized, new Size(width, height), 0, 0, InterpolationFlags.Nearest);
                mask.Dispose();
                return resized;
            }

            return mask;
        }

        /// <summary>
        /// Creates a mask from multiple CSV files (combining with OR operation)
        /// </summary>
        public static Mat CombineBadPixelMasks(string[] filePaths, int width, int height)
        {
            Mat combinedMask = Mat.Zeros(height, width, MatType.CV_8UC1);

            foreach (string filePath in filePaths)
            {
                using (Mat mask = LoadBadPixelMask(filePath, width, height))
                {
                    Cv2.BitwiseOr(combinedMask, mask, combinedMask);
                }
            }

            return combinedMask;
        }
    }
}