using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class ImageProcessor
    {
        private PictureBox pvDisplayControl;

        public ImageProcessor(PictureBox displayControl)
        {
            pvDisplayControl = displayControl;
        }

        public void LoadAndDisplayImage(string filePath)
        {
            using (var img = Cv2.ImRead(filePath, ImreadModes.Color))
            {
                if (img.Empty())
                {
                    MessageBox.Show("Không thể đọc ảnh từ đường dẫn.");
                    return;
                }

                using (var originalBitmap = BitmapConverter.ToBitmap(img))
                {
                    if (pvDisplayControl.Image != null) pvDisplayControl.Image.Dispose();
                    pvDisplayControl.Image = (Bitmap)originalBitmap.Clone();
                    pvDisplayControl.SizeMode = PictureBoxSizeMode.StretchImage;
                    pvDisplayControl.Visible = true;
                }
            }
        }
    }
}
