using OpenCvSharp;
using System;
using System.IO;

namespace ImageProcessing.Processing
{
    public class NucProcessor
    {
        /// <summary>
        /// Apply Non-Uniformity Correction to an image
        /// </summary>
        /// <param name="input">Input image</param>
        /// <param name="gainMatrix">Gain correction matrix</param>
        /// <param name="offsetMatrix">Offset correction matrix</param>
        /// <returns>NUC-corrected image</returns>
        public static Mat ApplyNuc(Mat input, Mat gainMatrix, Mat offsetMatrix)
        {
            // Ensure dimensions match
            if (input.Size() != gainMatrix.Size() || input.Size() != offsetMatrix.Size())
                throw new ArgumentException("Input, gain, and offset matrices must have the same dimensions");

            // Convert to 32-bit float for precision
            Mat result = new Mat();
            Mat floatInput = new Mat();
            input.ConvertTo(floatInput, MatType.CV_32F);

            // Apply gain and offset: result = input * gain + offset
            Mat gainMultiplied = new Mat();
            Cv2.Multiply(floatInput, gainMatrix, gainMultiplied);
            Cv2.Add(gainMultiplied, offsetMatrix, result);

            // Convert back to 8-bit
            Mat output = new Mat();
            result.ConvertTo(output, MatType.CV_8U);

            // Clean up
            floatInput.Dispose();
            gainMultiplied.Dispose();
            result.Dispose();

            return output;
        }

        /// <summary>
        /// Convert array-based gain/offset to Mat
        /// </summary>
        public static Mat ConvertArrayToMat(float[,] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);

            Mat result = new Mat(height, width, MatType.CV_32F);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result.At<float>(y, x) = array[y, x];
                }
            }

            return result;
        }

        /// <summary>
        /// Load gain/offset matrix from CSV file
        /// </summary>
        public static Mat LoadMatrixFromCsv(string filePath, int width, int height)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Matrix file not found: {filePath}");

            string[] lines = File.ReadAllLines(filePath);
            int fileHeight = lines.Length;
            int fileWidth = lines[0].Split(';').Length;

            Mat matrix = new Mat(fileHeight, fileWidth, MatType.CV_32F);

            for (int y = 0; y < fileHeight; y++)
            {
                string[] values = lines[y].Split(';');
                for (int x = 0; x < Math.Min(fileWidth, values.Length); x++)
                {
                    if (float.TryParse(values[x],
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out float value))
                    {
                        matrix.At<float>(y, x) = value;
                    }
                }
            }

            // Resize if needed
            if (fileWidth != width || fileHeight != height)
            {
                Mat resized = new Mat();
                Cv2.Resize(matrix, resized, new Size(width, height), 0, 0, InterpolationFlags.Linear);
                matrix.Dispose();
                return resized;
            }

            return matrix;
        }

        /// <summary>
        /// Create NUC calibration matrices from thermal images
        /// </summary>
        /// <param name="lowTempImage">Low temperature reference image</param>
        /// <param name="highTempImage">High temperature reference image</param>
        /// <param name="gainMatrix">Output gain matrix</param>
        /// <param name="offsetMatrix">Output offset matrix</param>
        public static void CalculateNucMatrices(
            Mat lowTempImage, Mat highTempImage,
            out Mat gainMatrix, out Mat offsetMatrix)
        {
            // Ensure grayscale
            Mat lowGray = new Mat();
            Mat highGray = new Mat();

            if (lowTempImage.Channels() == 3)
                Cv2.CvtColor(lowTempImage, lowGray, ColorConversionCodes.BGR2GRAY);
            else
                lowGray = lowTempImage.Clone();

            if (highTempImage.Channels() == 3)
                Cv2.CvtColor(highTempImage, highGray, ColorConversionCodes.BGR2GRAY);
            else
                highGray = highTempImage.Clone();

            // Convert to float for calculations
            Mat lowFloat = new Mat();
            Mat highFloat = new Mat();
            lowGray.ConvertTo(lowFloat, MatType.CV_32F);
            highGray.ConvertTo(highFloat, MatType.CV_32F);

            // Calculate average values
            Scalar lowMean = Cv2.Mean(lowFloat);
            Scalar highMean = Cv2.Mean(highFloat);
            float v1 = (float)lowMean.Val0;
            float v2 = (float)highMean.Val0;

            // Calculate gain and offset matrices
            // Gain = (V2 - V1) / (P2 - P1)
            // Offset = (V2*P1 - V1*P2) / (P1 - P2)

            Mat diff = new Mat();
            Cv2.Subtract(highFloat, lowFloat, diff);

            gainMatrix = new Mat(lowFloat.Size(), MatType.CV_32F);
            offsetMatrix = new Mat(lowFloat.Size(), MatType.CV_32F);

            // To avoid division by zero
            Mat mask = new Mat();
            Cv2.Compare(diff, new Scalar(0.001f), mask, CmpType.GT);

            // Calculate gain
            gainMatrix.SetTo(new Scalar(1.0f));
            Mat gainTemp = new Mat();
            Cv2.Divide(new Scalar(v2 - v1), diff, gainTemp, 1.0, MatType.CV_32F);
            gainTemp.CopyTo(gainMatrix, mask);

            // Calculate offset
            Mat offsetTemp1 = new Mat();
            Mat offsetTemp2 = new Mat();
            Cv2.Multiply(new Scalar(v2), lowFloat, offsetTemp1);
            Cv2.Multiply(new Scalar(v1), highFloat, offsetTemp2);

            Mat offsetNumerator = new Mat();
            Cv2.Subtract(offsetTemp1, offsetTemp2, offsetNumerator);

            Mat offsetDenominator = new Mat();
            Cv2.Subtract(lowFloat, highFloat, offsetDenominator);

            Cv2.Divide(offsetNumerator, offsetDenominator, offsetMatrix, 1.0, MatType.CV_32F);

            // Clean up
            lowGray.Dispose();
            highGray.Dispose();
            lowFloat.Dispose();
            highFloat.Dispose();
            diff.Dispose();
            mask.Dispose();
            gainTemp.Dispose();
            offsetTemp1.Dispose();
            offsetTemp2.Dispose();
            offsetNumerator.Dispose();
            offsetDenominator.Dispose();
        }
    }
}