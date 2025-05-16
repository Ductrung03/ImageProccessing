using OpenCvSharp;
using System;
using System.Runtime.InteropServices;

namespace ImageProcessing.Processing
{
    public class GammaProcessor
    {
       
        public static Mat ApplyGammaCorrection(Mat input, double gamma)
        {
            
            Mat lookUpTable = new Mat(1, 256, MatType.CV_8U);
            byte[] lookUpTableData = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                lookUpTableData[i] = (byte)(Math.Pow(i / 255.0, gamma) * 255.0);
            }

            Marshal.Copy(lookUpTableData, 0, lookUpTable.Data, 256);

            
            Mat result = new Mat();
            Cv2.LUT(input, lookUpTable, result);

            lookUpTable.Dispose();
            return result;
        }
    }
}