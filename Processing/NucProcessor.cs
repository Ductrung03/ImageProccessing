using OpenCvSharp;
using System;
using System.IO;

namespace ImageProcessing.Processing
{
    public class NucProcessor
    {
       
        public static Mat ApplyNuc(Mat input, Mat gainMatrix, Mat offsetMatrix)
        {
            
            if (input.Size() != gainMatrix.Size() || input.Size() != offsetMatrix.Size())
                throw new ArgumentException("Input, gain, and offset matrices must have the same dimensions");

          
            Mat result = new Mat();
            Mat floatInput = new Mat();
            input.ConvertTo(floatInput, MatType.CV_32F);

            
            Mat gainMultiplied = new Mat();
            Cv2.Multiply(floatInput, gainMatrix, gainMultiplied);
            Cv2.Add(gainMultiplied, offsetMatrix, result);

           
            Mat output = new Mat();
            result.ConvertTo(output, MatType.CV_8U);

          
            floatInput.Dispose();
            gainMultiplied.Dispose();
            result.Dispose();

            return output;
        }

       
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

           
            if (fileWidth != width || fileHeight != height)
            {
                Mat resized = new Mat();
                Cv2.Resize(matrix, resized, new Size(width, height), 0, 0, InterpolationFlags.Linear);
                matrix.Dispose();
                return resized;
            }

            return matrix;
        }

        
        public static void CalculateNucMatrices(
            Mat lowTempImage, Mat highTempImage,
            out Mat gainMatrix, out Mat offsetMatrix)
        {
            
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

            
            Mat lowFloat = new Mat();
            Mat highFloat = new Mat();
            lowGray.ConvertTo(lowFloat, MatType.CV_32F);
            highGray.ConvertTo(highFloat, MatType.CV_32F);

          
            Scalar lowMean = Cv2.Mean(lowFloat);
            Scalar highMean = Cv2.Mean(highFloat);
            float v1 = (float)lowMean.Val0;
            float v2 = (float)highMean.Val0;

            

            Mat diff = new Mat();
            Cv2.Subtract(highFloat, lowFloat, diff);

            gainMatrix = new Mat(lowFloat.Size(), MatType.CV_32F);
            offsetMatrix = new Mat(lowFloat.Size(), MatType.CV_32F);

            
            Mat mask = new Mat();
            Cv2.Compare(diff, new Scalar(0.001f), mask, CmpType.GT);

            
            gainMatrix.SetTo(new Scalar(1.0f));
            Mat gainTemp = new Mat();
            Cv2.Divide(new Scalar(v2 - v1), diff, gainTemp, 1.0, MatType.CV_32F);
            gainTemp.CopyTo(gainMatrix, mask);

           
            Mat offsetTemp1 = new Mat();
            Mat offsetTemp2 = new Mat();
            Cv2.Multiply(new Scalar(v2), lowFloat, offsetTemp1);
            Cv2.Multiply(new Scalar(v1), highFloat, offsetTemp2);

            Mat offsetNumerator = new Mat();
            Cv2.Subtract(offsetTemp1, offsetTemp2, offsetNumerator);

            Mat offsetDenominator = new Mat();
            Cv2.Subtract(lowFloat, highFloat, offsetDenominator);

            Cv2.Divide(offsetNumerator, offsetDenominator, offsetMatrix, 1.0, MatType.CV_32F);

           
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