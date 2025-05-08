using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ImageProcessing.Processing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Threading;
using PvGUIDotNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ImageProcessing
{

    public partial class IR_Camera : Form
    {
        private CancellationTokenSource videoTokenSource;
        private Task videoTask;
        
      
        private Bitmap imageBeforeEdge = null;
        private bool isEdgeActive = false;


        private bool isNUCActive = false;
      
        private bool isPostActive = false;

        //MainForm FormConnectCAMLINK = new MainForm();

        int rdCAMLink_Checked = 1;
        public IR_Camera()
        {
            InitializeComponent();
        }
      
        private void IR_Camera_Load(object sender, EventArgs e)
        {
            List<float> temperatureOptions = new List<float> { 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70 };
            comboBoxTempNuc.Items.Clear();
            foreach (var t in temperatureOptions)
            {
                comboBoxTempNuc.Items.Add($"{t} °C");
            }

            comboBoxTempNuc.SelectedIndex = 0;
        }

        private void btn_connect_CAMLink_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

        }


        private void btnOpenCAM_VIDEO_PIC_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string filePath = string.Empty;

            switch (rdCAMLink_Checked)
            {
                case 1: // CameraLink
                    new MainForm().Show();
                    return;

                case 2: // Video
                    dialog.Filter = "Video files (*.mp4;*.avi)|*.mp4;*.avi|All files (*.*)|*.*";
                    dialog.Title = "Chọn video";
                    if (dialog.ShowDialog() != DialogResult.OK) return;

                    filePath = dialog.FileName;
                    PlayVideo(filePath);
                    return;

                case 3: // Picture
                    filePath = textBox7.Text.Trim();

                    if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                    {
                        MessageBox.Show("Đường dẫn ảnh không hợp lệ. Vui lòng kiểm tra lại.");
                        return;
                    }

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

                        // Lấy vùng sắc nét nhất và hiển thị vào pvDisplayControl3
                        using (var sharpestRegionBitmap = AutoFocusProcessor.GetSharpestRegion(img))
                        {
                            if (sharpestRegionBitmap != null)
                            {
                               
                                if (pvDisplayControl3.Image != null) pvDisplayControl3.Image.Dispose();
                                pvDisplayControl3.Image = (Bitmap)sharpestRegionBitmap.Clone();
                                pvDisplayControl3.SizeMode = PictureBoxSizeMode.StretchImage;
                                pvDisplayControl3.Visible = true;  // Đảm bảo pvDisplayControl3 hiển thị
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy vùng sắc nét nhất trong ảnh.");
                            }
                        }
                    }
                    return;

                default:
                    return;
            }
        }

        private void PlayVideo(string videoPath)
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
                                Invoke((MethodInvoker)(() =>
                                {
                                    if (this.IsDisposed || !this.IsHandleCreated) return;
                                    if (pvDisplayControl.Image != null) pvDisplayControl.Image.Dispose();
                                    pvDisplayControl.Image = (Bitmap)bitmap.Clone();
                                    pvDisplayControl.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pvDisplayControl.Visible = true;
                                }));
                            }

                            Bitmap sharpestRegionBitmap = AutoFocusProcessor.GetSharpestRegion(frame);
                            if (sharpestRegionBitmap != null)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    if (this.IsDisposed || !this.IsHandleCreated) return;
                                    if (pvDisplayControl3.Image != null) pvDisplayControl3.Image.Dispose();
                                    pvDisplayControl3.Image = (Bitmap)sharpestRegionBitmap.Clone();
                                    pvDisplayControl3.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pvDisplayControl3.Visible = true;
                                }));
                                sharpestRegionBitmap.Dispose(); 
                            }

                            Cv2.WaitKey(30); 
                        }
                    }
                }
            }, token);
        }


        private void rdCAMLink_CheckedChanged(object sender, EventArgs e)
        {
            rdCAMLink_Checked = 1;
        }

        private void rdVideo_CheckedChanged(object sender, EventArgs e)
        {
            rdCAMLink_Checked = 2;
        }

        private void rdPicture_CheckedChanged(object sender, EventArgs e)
        {
            rdCAMLink_Checked = 3;
        }

        private void pvDisplayControl2_Load(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {

        }

        #region LoadPicture
        private void button1_Click(object sender, EventArgs e)
        {
            string imagePath = textBox7.Text;

            if (File.Exists(imagePath))
            {
                try
                {
                    Image img = Image.FromFile(imagePath);
                    pvDisplayControl.Image = img; 
                    pvDisplayControl.SizeMode = PictureBoxSizeMode.StretchImage;

                    pvDisplayControl.Visible = true;
                    //pvDisplayControl1.Visible = false; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở ảnh: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Đường dẫn ảnh không tồn tại.");
            }
        }

        #endregion
        private void BtnLoadVideo_Click(object sender, EventArgs e)
        {

        }

        #region Post

        private PostProcessor postProcessor;
        private System.Windows.Forms.Timer postTimer;
        private bool isPostRunning = false;

        private async void btnPost_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPost_Frames.Text, out int N) || N <= 0)
            {
                MessageBox.Show("Số lượng frame không hợp lệ.");
                return;
            }

            postProcessor = new PostProcessor(N);

            if (rdPicture.Checked)
            {
                if (pvDisplayControl.Image == null)
                {
                    MessageBox.Show("Vui lòng tải ảnh vào trước.");
                    return;
                }

                Bitmap bitmap = new Bitmap(pvDisplayControl.Image);
                Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
                Mat result = postProcessor.Process(mat);

                pvDisplayControl2.Image?.Dispose();
                pvDisplayControl2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
                pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;
                pvDisplayControl2.Visible = true;

                mat.Dispose();
                result.Dispose();
                bitmap.Dispose();
            }

            else if (rdVideo.Checked)
            {
                if (pvDisplayControl.Image == null)
                {
                    MessageBox.Show("Video chưa được play ở pvDisplayControl.");
                    return;
                }

                if (postTimer != null)
                {
                    postTimer.Stop();
                    postTimer.Dispose();
                }

                postTimer = new System.Windows.Forms.Timer();
                postTimer.Interval = 30; 
                postTimer.Tick += (s, ev) =>
                {
                    if (!isPostRunning || pvDisplayControl.Image == null) return;

                    Bitmap frameBmp = new Bitmap(pvDisplayControl.Image);
                    Mat mat = OpenCvSharp.Extensions.BitmapConverter.ToMat(frameBmp);
                    Mat result = postProcessor.Process(mat);

                    pvDisplayControl2.Image?.Dispose();
                    pvDisplayControl2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(result);
                    pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pvDisplayControl2.Visible = true;

                    frameBmp.Dispose();
                    mat.Dispose();
                    result.Dispose();
                };

                isPostRunning = true;
                postTimer.Start();
            }


            isPostActive = true;
            btnPost.BackColor = Color.LightBlue;
        }

        #endregion

        #region NUC

        private System.Windows.Forms.Timer nucTimer;
        private float[,] gainMatrix, offsetMatrix;
        private readonly int expectedW = 640;
        private readonly int expectedH = 480;
        private bool isVideoMode = false; 
        private VideoCapture videoCapture;

        private bool LoadNUCMatrices(string gainPath, string offsetPath)
        {
            try
            {
                gainMatrix = NucProcessor.LoadCSVToFloatArray(gainPath, expectedW, expectedH);
                offsetMatrix = NucProcessor.LoadCSVToFloatArray(offsetPath, expectedW, expectedH);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải gain/offset: {ex.Message}");
                return false;
            }
        }

        private void NucTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Mat frame;

                if (isVideoMode && videoCapture != null && videoCapture.IsOpened())
                {
                    frame = new Mat();
                    if (!videoCapture.Read(frame) || frame.Empty())
                    {
                        nucTimer.Stop();
                        MessageBox.Show("Đã hết video hoặc không thể đọc.");
                        return;
                    }
                }
                else if (pvDisplayControl.Image != null)
                {
                    using (var frameBmp = new Bitmap(pvDisplayControl.Image))
                    {
                        frame = OpenCvSharp.Extensions.BitmapConverter.ToMat(frameBmp);
                    }
                }
                else
                {
                    nucTimer.Stop();
                    MessageBox.Show("Chưa chọn nguồn ảnh hoặc video.");
                    return;
                }

                if (frame.Width != expectedW || frame.Height != expectedH)
                    Cv2.Resize(frame, frame, new OpenCvSharp.Size(expectedW, expectedH));

                using (Mat nucResult = NucProcessor.ApplyNUC(frame, gainMatrix, offsetMatrix))
                {
                    Mat displayMat = new Mat();
                    Cv2.CvtColor(nucResult, displayMat, ColorConversionCodes.GRAY2BGR);

                    pvDisplayControl2.Image?.Dispose();
                    pvDisplayControl2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(displayMat);
                    pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;

                    displayMat.Dispose();
                }

                frame.Dispose();
            }
            catch (Exception ex)
            {
                nucTimer.Stop();
                MessageBox.Show("Lỗi khi xử lý NUC: " + ex.Message);
            }
        }



        private void btnNUC_Click_1(object sender, EventArgs e)
        {
            if (!isNUCActive)
            {
                if (!LoadNUCMatrices(
                        @"D:/DucTrung/LK/Project/C#/Trung_HTTT_K57/Data/240328_SoLieuThuNghiem_DaiGui/Alpha_matrix.csv",
                        @"D:/DucTrung/LK/Project/C#/Trung_HTTT_K57/Data/240328_SoLieuThuNghiem_DaiGui/Beta_matrix.csv"))
                    return;

                nucTimer = new System.Windows.Forms.Timer { Interval = 30 };
                nucTimer.Tick += NucTimer_Tick;
                nucTimer.Start();

                isNUCActive = true;
                btnNUC.BackColor = Color.LightBlue;
            }
            else
            {
                nucTimer?.Stop();
                nucTimer?.Dispose();
                nucTimer = null;

                videoCapture?.Dispose();
                videoCapture = null;

                pvDisplayControl2.Image?.Dispose();
                pvDisplayControl2.Image = null;

                isNUCActive = false;
                btnNUC.BackColor = SystemColors.Control;
            }
        }

        #endregion

        #region BPR

      
        private bool isBPRActive = false;
        private int[,] cachedCombinedMask = null;

        private System.Windows.Forms.Timer bprTimer;
        private bool isBPRRunning = false;

        private void btnBpr_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!isBPRActive)
                {
                    PictureBox sourceBox = pvDisplayControl2.Image != null ? pvDisplayControl2 : pvDisplayControl;
                    if (sourceBox.Image == null)
                    {
                        MessageBox.Show("Chưa có ảnh để xử lý BPR.");
                        return;
                    }

                    // Tải và lưu mặt nạ vào cache nếu chưa có
                    if (cachedCombinedMask == null)
                    {
                        string[] maskFiles = new string[]
                        {
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\GlobalBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\NETDBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\ResponsivityBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\SignalLevelBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\TemporalNoiseBadPixelsRawOutput_matrix.csv"
                        };

                        // Lấy kích thước khung hình
                        int width = sourceBox.Image.Width;
                        int height = sourceBox.Image.Height;

                        cachedCombinedMask = new int[height, width];
                        foreach (string file in maskFiles)
                        {
                            if (!File.Exists(file))
                            {
                                MessageBox.Show($"File mặt nạ không tồn tại: {file}");
                                return;
                            }
                            int[,] mask = BprProcessor.LoadBPRMask(file, width, height);
                            for (int y = 0; y < height; y++)
                            {
                                for (int x = 0; x < width; x++)
                                {
                                    if (mask[y, x] == 1)
                                        cachedCombinedMask[y, x] = 1;
                                }
                            }
                        }
                    }

                    if (rdVideo.Checked)
                    {
                        if (bprTimer != null)
                        {
                            bprTimer.Stop();
                            bprTimer.Dispose();
                        }

                        bprTimer = new System.Windows.Forms.Timer();
                        bprTimer.Interval = 30; // Tương ứng với 30ms/frame
                        bprTimer.Tick += (s, ev) =>
                        {
                            if (!isBPRRunning || pvDisplayControl.Image == null) return;

                            Bitmap frameBmp = new Bitmap(pvDisplayControl.Image);
                            Bitmap result = BprProcessor.ApplyBPR(frameBmp, cachedCombinedMask);

                            pvDisplayControl2.Image?.Dispose();
                            pvDisplayControl2.Image = result;
                            pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;
                            pvDisplayControl2.Visible = true;

                            frameBmp.Dispose();
                        };

                        isBPRRunning = true;
                        bprTimer.Start();
                    }
                    else if (rdPicture.Checked)
                    {
                        Bitmap input = new Bitmap(sourceBox.Image);
                        Bitmap output = BprProcessor.ApplyBPR(input, cachedCombinedMask);
                        pvDisplayControl2.Image?.Dispose();
                        pvDisplayControl2.Image = output;
                        pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pvDisplayControl2.Visible = true;
                    }

                    isBPRActive = true;
                    btnBpr.BackColor = Color.LightBlue;
                }
                else
                {
                    if (bprTimer != null)
                    {
                        bprTimer.Stop();
                        bprTimer.Dispose();
                        bprTimer = null;
                    }
                    isBPRRunning = false;

                    pvDisplayControl2.Image?.Dispose();
                    pvDisplayControl2.Image = null;

                    isBPRActive = false;
                    btnBpr.BackColor = SystemColors.Control;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý BPR: {ex.Message}");
            }
        }


        #endregion

        #region EDGE

        private void btnEdge_Click(object sender, EventArgs e)
        {

            float alpha = hScrollBar2.Value / 20.0f; 
            if (!isEdgeActive)
            {
                PictureBox source = pvDisplayControl2.Image != null ? pvDisplayControl2 : pvDisplayControl;

                if (source.Image == null)
                {
                    MessageBox.Show("Vui lòng tải ảnh trước khi xử lý Edge.");
                    isEdgeActive = false;
                    return;
                }

                imageBeforeEdge?.Dispose();
                imageBeforeEdge = new Bitmap(source.Image);

                Bitmap input = new Bitmap(source.Image);
                Bitmap output = EdgeProcessor.ApplyEdgeEnhancement(input, alpha);

                pvDisplayControl2.Image = output;
                pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;
                pvDisplayControl2.Visible = true;
            }
            else
            {
                if (imageBeforeEdge != null)
                {
                    pvDisplayControl2.Image = new Bitmap(imageBeforeEdge);
                    pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;
                    pvDisplayControl2.Visible = true;
                }
            }

            isEdgeActive = !isEdgeActive;
            btnEdge.BackColor = isEdgeActive ? Color.LightBlue : SystemColors.Control;
        }

        #endregion

    }
}
