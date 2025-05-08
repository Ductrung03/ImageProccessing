using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;

namespace ImageProcessing.Processing
{
    public static class AutoFocusProcessor
    {
        //Chọn vùng sắc nét nhất
        public static Bitmap GetSharpestRegion(Mat image, int gridRows = 5, int gridCols = 5)
        {
            if (image.Empty()) return null;

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
                using (Mat sharpestRegionMat = new Mat(image, sharpestRegion))
                {
                    return BitmapConverter.ToBitmap(sharpestRegionMat);
                }
            }

            return null; 
        }

        //Tính toán độ sắc nét
        public static double CalculateSharpness(Mat frame)
        {
            using (var gray = new Mat())
            using (var denoised = new Mat())
            using (var lap = new Mat())
            {
                Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
                Cv2.GaussianBlur(gray, denoised, new OpenCvSharp.Size(3, 3), 0); 
                Cv2.Laplacian(denoised, lap, MatType.CV_16S); 
                Scalar stddev;
                Cv2.MeanStdDev(lap, out _, out stddev);
                return stddev.Val0 * stddev.Val0;
            }
        }

        //Tìm frame sắc nét nhất
        public static Bitmap AutoFocusFromFrames(string videoPath)
        {
            using (var cap = new VideoCapture(videoPath))
            {
                if (!cap.IsOpened()) return null;

                using (var sharpestFrame = new Mat())
                using (var frame = new Mat())
                {
                    double maxSharpness = 0;

                    while (cap.Read(frame))
                    {
                        if (frame.Empty()) break;

                        double sharpness = CalculateSharpness(frame);
                        if (sharpness > maxSharpness)
                        {
                            maxSharpness = sharpness;
                            frame.CopyTo(sharpestFrame);
                        }
                    }

                    return sharpestFrame.Empty() ? null : BitmapConverter.ToBitmap(sharpestFrame);
                }
            }
        }
        // Tăng độ sắc nét
        public static Bitmap AutoFocusFromImage(Mat image)
        {
            using (var gray = new Mat())
            using (var sharpened = new Mat())
            {
                Cv2.CvtColor(image, gray, ColorConversionCodes.BGR2GRAY);
                Cv2.GaussianBlur(gray, sharpened, new OpenCvSharp.Size(0, 0), 3);
                Cv2.AddWeighted(gray, 1.5, sharpened, -0.5, 0, sharpened);
                using (var result = new Mat())
                {
                    Cv2.CvtColor(sharpened, result, ColorConversionCodes.GRAY2BGR);
                    return BitmapConverter.ToBitmap(result);
                }
            }
        }
    }
}