using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Processing
{
    public static class EdgeProcessor
    {
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Bitmap ApplyEdgeEnhancement(Bitmap input, float alpha = 1.0f)
        {
            Bitmap gray = ToGrayScale(input); 
            Bitmap result = new Bitmap(gray.Width, gray.Height);

            for (int y = 1; y < gray.Height - 1; y++)
            {
                for (int x = 1; x < gray.Width - 1; x++)
                {
                    int edge = 8 * gray.GetPixel(x, y).R
                             - gray.GetPixel(x - 1, y).R
                             - gray.GetPixel(x + 1, y).R
                             - gray.GetPixel(x, y - 1).R
                             - gray.GetPixel(x, y + 1).R
                             - gray.GetPixel(x - 1, y - 1).R
                             - gray.GetPixel(x - 1, y + 1).R
                             - gray.GetPixel(x + 1, y - 1).R
                             - gray.GetPixel(x + 1, y + 1).R;

                    Color orig = gray.GetPixel(x, y);
                    int r = Clamp((int)(orig.R + alpha * edge), 0, 255);
                    result.SetPixel(x, y, Color.FromArgb(r, r, r));
                }
            }

            return result;
        }


        public static Bitmap ToGrayScale(Bitmap input)
        {
            Bitmap gray = new Bitmap(input.Width, input.Height);
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);
                    int grayValue = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                    gray.SetPixel(x, y, Color.FromArgb(grayValue, grayValue, grayValue));
                }
            }
            return gray;
        }

    }
}
