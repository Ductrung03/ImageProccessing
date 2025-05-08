using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing.Proccesing
{
    public class VideoProcessor
    {
        private CancellationTokenSource videoTokenSource;
        private Task videoTask;
        private PictureBox pvDisplayControl;

        public VideoProcessor(PictureBox displayControl)
        {
            pvDisplayControl = displayControl;
        }

        public void PlayVideo(string videoPath)
        {
            if (videoTokenSource != null)
            {
                videoTokenSource.Cancel();
                videoTask?.Wait();
                videoTokenSource.Dispose();
            }

            videoTokenSource = new CancellationTokenSource();
            CancellationToken token = videoTokenSource.Token;

            videoTask = Task.Run(() =>
            {
                using (var cap = new VideoCapture(videoPath))
                {
                    if (!cap.IsOpened()) return;

                    using (var frame = new Mat())
                    {
                        while (!token.IsCancellationRequested)
                        {
                            if (!cap.Read(frame) || frame.Empty())
                                break;

                            using (var bitmap = BitmapConverter.ToBitmap(frame))
                            {
                                pvDisplayControl.Invoke((MethodInvoker)(() =>
                                {
                                    if (pvDisplayControl.Image != null) pvDisplayControl.Image.Dispose();
                                    pvDisplayControl.Image = (Bitmap)bitmap.Clone();
                                    pvDisplayControl.SizeMode = PictureBoxSizeMode.StretchImage;
                                }));
                            }
                            Cv2.WaitKey(30);
                        }
                    }
                }
            }, token);
        }
    }
}
