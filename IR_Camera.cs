using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

using OpenCvSharp;
using OpenCvSharp.Extensions;
using ImageProcessing.Processing;

namespace ImageProcessing
{
    public partial class IR_Camera : Form
    {
        #region Fields

        // Nguồn đầu vào
        private VideoCapture videoCapture;
        private Mat currentFrame;
        private CancellationTokenSource videoTokenSource;
        private Task videoProcessingTask;
        private string currentFilePath;
        private bool isLiveVideoRunning = false;

        // Trạng thái các mô-đun xử lý
        private bool isPostActive = false;
        private bool isNucActive = false;
        private bool isBprActive = false;
        private bool isBprDynamicActive = false;
        private bool isEdgeActive = false;
        private bool isBinningActive = false;
        private bool isAgcActive = false;
        private bool isFlipActive = false;
        private bool isGammaActive = false;
        private bool isFocusActive = false;

        // Các mô-đun xử lý
        private PostProcessor postProcessor;
        private Mat nucGainMatrix;
        private Mat nucOffsetMatrix;
        private Mat bprMaskMat;
        private System.Windows.Forms.Timer processingTimer;

        // Hiển thị hình ảnh
        private Mat originalMat;
        private Mat processedMat;
        private Mat resultMat;

        // Kích thước mặc định cho ảnh đã xử lý
        private const int DEFAULT_WIDTH = 640;
        private const int DEFAULT_HEIGHT = 480;

        #endregion

        public IR_Camera()
        {
            InitializeComponent();
            SetupTimer();
        }

        #region Form Events

        private void IR_Camera_Load(object sender, EventArgs e)
        {
            // Thiết lập các tùy chọn nhiệt độ cho NUC
            SetupTemperatureComboBox();

            // Thiết lập giá trị phạm vi cho thanh trượt
            hScrollBar1.Minimum = 1;
            hScrollBar1.Maximum = 100;
            hScrollBar1.Value = 50;

            hScrollBar2.Minimum = 1;
            hScrollBar2.Maximum = 100;
            hScrollBar2.Value = 20;

            // Hiển thị các PictureBox
            pvDisplayControl.Visible = true;
            pvDisplayControl2.Visible = true;
            pvDisplayControl3.Visible = true;

            // Bật chế độ co giãn ảnh
            pvDisplayControl.SizeMode = PictureBoxSizeMode.StretchImage;
            pvDisplayControl2.SizeMode = PictureBoxSizeMode.StretchImage;
            pvDisplayControl3.SizeMode = PictureBoxSizeMode.StretchImage;

            // Mặc định chọn CameraLink
            rdCAMLink.Checked = true;
        }

        private void SetupTemperatureComboBox()
        {
            List<float> temperatureOptions = new List<float> { 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70 };
            comboBoxTempNuc.Items.Clear();

            foreach (var temp in temperatureOptions)
            {
                comboBoxTempNuc.Items.Add($"{temp} °C");
            }

            comboBoxTempNuc.SelectedIndex = 0;
        }

        private void SetupTimer()
        {
            processingTimer = new System.Windows.Forms.Timer();
            processingTimer.Interval = 33; // ~30 khung hình mỗi giây
            processingTimer.Tick += ProcessingTimer_Tick;
        }

        private void IR_Camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Giải phóng tài nguyên
            StopVideoProcessing();
            DisposeResources();
        }

        private void DisposeResources()
        {
            // Dừng bộ hẹn giờ
            processingTimer?.Stop();
            processingTimer?.Dispose();

            // Giải phóng tài nguyên video
            videoTokenSource?.Cancel();
            videoCapture?.Dispose();

            // Giải phóng tài nguyên ảnh
            originalMat?.Dispose();
            processedMat?.Dispose();
            resultMat?.Dispose();
            currentFrame?.Dispose();

            // Giải phóng tài nguyên xử lý
            nucGainMatrix?.Dispose();
            nucOffsetMatrix?.Dispose();
            bprMaskMat?.Dispose();
        }


        #endregion

        #region Input Source Selection Handlers

        private void rdCAMLink_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCAMLink.Checked)
            {
                StopVideoProcessing();
                textBox7.Enabled = false;
            }
        }

        private void rdVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdVideo.Checked)
            {
                StopVideoProcessing();
                textBox7.Enabled = true;
            }
        }

        private void rdPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPicture.Checked)
            {
                StopVideoProcessing();
                textBox7.Enabled = true;
            }
        }

        private void btnOpenCAM_VIDEO_PIC_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdCAMLink.Checked)
                {
                    // Open Camera Link connection
                    new MainForm().Show();
                    return;
                }
                else if (rdVideo.Checked)
                {
                    OpenVideoFile();
                }
                else if (rdPicture.Checked)
                {
                    OpenImageFile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenVideoFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Video files (*.mp4;*.avi)|*.mp4;*.avi|All files (*.*)|*.*";
                dialog.Title = "Select Video File";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    StopVideoProcessing();
                    currentFilePath = dialog.FileName;
                    textBox7.Text = currentFilePath;
                    StartVideoProcessing(currentFilePath);
                }
            }
        }

        private void OpenImageFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                dialog.Title = "Select Image File";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = dialog.FileName;
                    textBox7.Text = currentFilePath;
                    LoadImageFile(currentFilePath);
                }
            }
        }

        private void LoadImageFile(string filePath)
        {
            // Kiểm tra xem file có tồn tại không
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Tệp không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Giải phóng các ảnh trước đó
                originalMat?.Dispose();
                processedMat?.Dispose();
                resultMat?.Dispose();

                // Tải ảnh bằng OpenCV
                originalMat = Cv2.ImRead(filePath, ImreadModes.Color);
                if (originalMat.Empty())
                {
                    MessageBox.Show("Không thể đọc tệp ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thay đổi kích thước nếu cần thiết
                if (originalMat.Width != DEFAULT_WIDTH || originalMat.Height != DEFAULT_HEIGHT)
                {
                    Mat resized = new Mat();
                    Cv2.Resize(originalMat, resized, new OpenCvSharp.Size(DEFAULT_WIDTH, DEFAULT_HEIGHT));
                    originalMat.Dispose();
                    originalMat = resized;
                }

                // Tạo bản sao để xử lý
                processedMat = originalMat.Clone();

                // Hiển thị ảnh gốc
                DisplayMatInPictureBox(originalMat, pvDisplayControl);

                // Xử lý và hiển thị nếu có bất kỳ bộ xử lý nào đang hoạt động
                ApplyActiveProcessors();

                // Thử tìm và hiển thị vùng nét nhất để hỗ trợ lấy nét
                Task.Run(() => FindAndDisplaySharpestRegion(originalMat));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Video Processing

        private void StartVideoProcessing(string videoPath)
        {
            try
            {
                StopVideoProcessing();

                videoCapture = new VideoCapture(videoPath);
                if (!videoCapture.IsOpened())
                {
                    MessageBox.Show("Could not open video file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                videoTokenSource = new CancellationTokenSource();
                var token = videoTokenSource.Token;
                isLiveVideoRunning = true;

                
                videoProcessingTask = Task.Run(() => ProcessVideoFrames(token), token);

               
                processingTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting video processing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopVideoProcessing();
            }
        }

        private void ProcessVideoFrames(CancellationToken token)
        {
            try
            {
                using (var frame = new Mat())
                {
                    while (!token.IsCancellationRequested && videoCapture != null && videoCapture.IsOpened())
                    {
                        if (!videoCapture.Read(frame) || frame.Empty())
                        {
                            
                            break;
                        }

                       
                        Mat resizedFrame = new Mat();
                        if (frame.Width != DEFAULT_WIDTH || frame.Height != DEFAULT_HEIGHT)
                        {
                            Cv2.Resize(frame, resizedFrame, new OpenCvSharp.Size(DEFAULT_WIDTH, DEFAULT_HEIGHT));
                        }
                        else
                        {
                            resizedFrame = frame.Clone();
                        }

                      
                        lock (this)
                        {
                            currentFrame?.Dispose();
                            currentFrame = resizedFrame.Clone();
                        }

                     
                        Thread.Sleep(33); 

                        resizedFrame.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show($"Error processing video: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StopVideoProcessing();
                }));
            }
            finally
            {
              
                isLiveVideoRunning = false;
            }
        }

        private void StopVideoProcessing()
        {
            
            videoTokenSource?.Cancel();

           
            try
            {
                videoProcessingTask?.Wait(1000);
            }
            catch (Exception) {}

            // Dispose resources
            videoTokenSource?.Dispose();
            videoTokenSource = null;

            videoCapture?.Dispose();
            videoCapture = null;

          
            processingTimer.Stop();

            isLiveVideoRunning = false;
        }

        private void ProcessingTimer_Tick(object sender, EventArgs e)
        {
            
            if (isLiveVideoRunning && currentFrame != null)
            {
                lock (this)
                {
                    if (currentFrame.Empty()) return;

                    // Display original frame
                    originalMat?.Dispose();
                    originalMat = currentFrame.Clone();
                    DisplayMatInPictureBox(originalMat, pvDisplayControl);

                    // Apply any active processors
                    ApplyActiveProcessors();

                    // Find and display sharpest region periodically
                    if (isFocusActive)
                    {
                        Task.Run(() => FindAndDisplaySharpestRegion(originalMat));
                    }
                }
            }
        }

        #endregion

        #region Image Processing and Display

        private void ApplyActiveProcessors()
        {
            if (originalMat == null || originalMat.Empty()) return;

            // Start with a fresh copy of the original
            processedMat?.Dispose();
            processedMat = originalMat.Clone();

            // Apply processors in sequence
            try
            {
                if (isPostActive)
                {
                    ApplyPostProcessor();
                }

                if (isNucActive)
                {
                    ApplyNucProcessor();
                }

                if (isBprActive)
                {
                    ApplyBprProcessor();
                }

                if (isBprDynamicActive)
                {
                    ApplyDynamicBprProcessor();
                }

                if (isEdgeActive)
                {
                    ApplyEdgeProcessor();
                }

                if (isBinningActive)
                {
                    ApplyBinningProcessor();
                }

                if (isAgcActive)
                {
                    ApplyAgcProcessor();
                }

                if (isFlipActive)
                {
                    ApplyFlipProcessor();
                }

                if (isGammaActive)
                {
                    ApplyGammaProcessor();
                }

                // Display processed image
                DisplayMatInPictureBox(processedMat, pvDisplayControl2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayMatInPictureBox(Mat mat, PictureBox pictureBox)
        {
            if (mat == null || mat.Empty() || pictureBox == null) return;

            try
            {
                // Convert Mat to Bitmap for display
                using (Bitmap bmp = BitmapConverter.ToBitmap(mat))
                {
                    // Dispose previous image
                    pictureBox.Image?.Dispose();

                    // Set new image
                    pictureBox.Image = new Bitmap(bmp);
                    pictureBox.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying image: {ex.Message}");
            }
        }

        private void FindAndDisplaySharpestRegion(Mat sourceMat)
        {
            try
            {
                if (sourceMat == null || sourceMat.Empty()) return;

                // Find sharpest region
                Mat sharpestRegion = AutoFocusProcessor.GetSharpestRegionMat(sourceMat, 5, 5);

                if (sharpestRegion != null && !sharpestRegion.Empty())
                {
                    // Display on UI thread
                    BeginInvoke(new Action(() =>
                    {
                        DisplayMatInPictureBox(sharpestRegion, pvDisplayControl3);
                        sharpestRegion.Dispose();
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding sharpest region: {ex.Message}");
            }
        }

        #endregion

        #region Post Processor

        private void btnPost_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!isPostActive)
                {
                    if (!int.TryParse(txtPost_Frames.Text, out int frameCount) || frameCount <= 0)
                    {
                        MessageBox.Show("Invalid frame count. Please enter a positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Create post processor
                    postProcessor = new PostProcessor(frameCount);

                    isPostActive = true;
                    btnPost.BackColor = Color.LightBlue;

                    // Apply processor if we have an image loaded
                    if (!rdVideo.Checked)
                    {
                        ApplyActiveProcessors();
                    }
                }
                else
                {
                    // Deactivate post processor
                    isPostActive = false;
                    btnPost.BackColor = SystemColors.Control;

                    // Reset post processor
                    postProcessor = null;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Post Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyPostProcessor()
        {
            if (postProcessor == null || processedMat == null || processedMat.Empty()) return;

            // Apply post processor
            Mat result = postProcessor.Process(processedMat);

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region NUC Processor

        private void btnNUC_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!isNucActive)
                {
                    // Load NUC matrices if not already loaded
                    if (nucGainMatrix == null || nucOffsetMatrix == null)
                    {
                        if (!LoadNucMatrices())
                        {
                            return;
                        }
                    }

                    isNucActive = true;
                    btnNUC.BackColor = Color.LightBlue;

                    // Apply NUC if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate NUC
                    isNucActive = false;
                    btnNUC.BackColor = SystemColors.Control;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in NUC Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LoadNucMatrices()
        {
            try
            {
                // You should customize these paths or allow user selection
                string gainPath = @"D:/DucTrung/LK/Project/C#/Trung_HTTT_K57/Data/240328_SoLieuThuNghiem_DaiGui/Alpha_matrix.csv";
                string offsetPath = @"D:/DucTrung/LK/Project/C#/Trung_HTTT_K57/Data/240328_SoLieuThuNghiem_DaiGui/Beta_matrix.csv";

                if (!File.Exists(gainPath) || !File.Exists(offsetPath))
                {
                    MessageBox.Show("NUC matrices files not found. Please verify the paths.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Load matrices
                nucGainMatrix = NucProcessor.LoadMatrixFromCsv(gainPath, DEFAULT_WIDTH, DEFAULT_HEIGHT);
                nucOffsetMatrix = NucProcessor.LoadMatrixFromCsv(offsetPath, DEFAULT_WIDTH, DEFAULT_HEIGHT);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading NUC matrices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ApplyNucProcessor()
        {
            if (nucGainMatrix == null || nucOffsetMatrix == null || processedMat == null || processedMat.Empty()) return;

            // Apply NUC
            Mat result = NucProcessor.ApplyNuc(processedMat, nucGainMatrix, nucOffsetMatrix);

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region BPR Processor

        private void btnBpr_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!isBprActive)
                {
                    // Load BPR mask if not already loaded
                    if (bprMaskMat == null)
                    {
                        if (!LoadBprMask())
                        {
                            return;
                        }
                    }

                    isBprActive = true;
                    btnBpr.BackColor = Color.LightBlue;

                    // Apply BPR if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate BPR
                    isBprActive = false;
                    btnBpr.BackColor = SystemColors.Control;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in BPR Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool LoadBprMask()
        {
            try
            {
                // Paths to BPR mask files - customize these paths
                string[] maskFiles = new string[]
                {
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\GlobalBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\NETDBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\ResponsivityBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\SignalLevelBadPixelsRawOutput_matrix.csv",
                    @"D:\DucTrung\LK\Project\C#\Trung_HTTT_K57\Data\240328_SoLieuThuNghiem_DaiGui\TemporalNoiseBadPixelsRawOutput_matrix.csv"
                };

                // Check if files exist
                foreach (string file in maskFiles)
                {
                    if (!File.Exists(file))
                    {
                        MessageBox.Show($"BPR mask file not found: {file}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                // Initialize combined mask
                bprMaskMat = Mat.Zeros(DEFAULT_HEIGHT, DEFAULT_WIDTH, MatType.CV_8UC1);

                // Combine all masks
                foreach (string file in maskFiles)
                {
                    // Load individual mask
                    Mat mask = new Mat(DEFAULT_HEIGHT, DEFAULT_WIDTH, MatType.CV_8UC1);

                    // Read CSV and convert to Mat
                    string[] lines = File.ReadAllLines(file);
                    int originalHeight = lines.Length;
                    int originalWidth = lines[0].Split(';').Length;

                    Mat originalMask = Mat.Zeros(originalHeight, originalWidth, MatType.CV_8UC1);

                    for (int y = 0; y < originalHeight; y++)
                    {
                        string[] values = lines[y].Split(';');
                        for (int x = 0; x < Math.Min(originalWidth, values.Length); x++)
                        {
                            if (int.TryParse(values[x], out int value) && value > 0)
                            {
                                originalMask.Set(y, x, (byte)255);
                            }
                        }
                    }

                    // Resize if needed
                    if (originalHeight != DEFAULT_HEIGHT || originalWidth != DEFAULT_WIDTH)
                    {
                        Cv2.Resize(originalMask, mask, new OpenCvSharp.Size(DEFAULT_WIDTH, DEFAULT_HEIGHT),
                                  0, 0, InterpolationFlags.Nearest);
                    }
                    else
                    {
                        originalMask.CopyTo(mask);
                    }

                    // Combine with main mask using bitwise OR
                    Cv2.BitwiseOr(bprMaskMat, mask, bprMaskMat);

                    // Clean up
                    originalMask.Dispose();
                    mask.Dispose();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading BPR mask: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ApplyBprProcessor()
        {
            if (bprMaskMat == null || processedMat == null || processedMat.Empty()) return;

            // Apply BPR
            Mat result = BprProcessor.ApplyBPR(processedMat, bprMaskMat);

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region BPR Dynamic Processor

        private void BtnBprDynamic_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!isBprDynamicActive)
                {
                    isBprDynamicActive = true;
                    BtnBprDynamic.BackColor = Color.LightBlue;

                    // Apply Dynamic BPR if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate Dynamic BPR
                    isBprDynamicActive = false;
                    BtnBprDynamic.BackColor = SystemColors.Control;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Dynamic BPR Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyDynamicBprProcessor()
        {
            if (processedMat == null || processedMat.Empty()) return;

            // Apply Dynamic BPR with threshold 8192 (this can be made configurable)
            Mat result = DynamicBprProcessor.ApplyAdvancedDynamicBPR(processedMat, 8192, 3);

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region Edge Processor

        private void btnEdge_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isEdgeActive)
                {
                    isEdgeActive = true;
                    btnEdge.BackColor = Color.LightBlue;

                    // Apply Edge Enhancement if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate Edge Enhancement
                    isEdgeActive = false;
                    btnEdge.BackColor = SystemColors.Control;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Edge Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyEdgeProcessor()
        {
            if (processedMat == null || processedMat.Empty()) return;

            // Get alpha value from slider
            float alpha = hScrollBar2.Value / 20.0f;

            // Convert to grayscale if needed
            Mat grayMat = new Mat();
            if (processedMat.Channels() == 3)
            {
                Cv2.CvtColor(processedMat, grayMat, ColorConversionCodes.BGR2GRAY);
            }
            else
            {
                grayMat = processedMat.Clone();
            }

            // Create Laplacian kernel with custom alpha
            Mat kernel = new Mat(3, 3, MatType.CV_32F);
            kernel.Set(0, 0, 0f); kernel.Set(0, 1, -alpha); kernel.Set(0, 2, 0f);
            kernel.Set(1, 0, -alpha); kernel.Set(1, 1, 1 + (4 * alpha)); kernel.Set(1, 2, -alpha);
            kernel.Set(2, 0, 0f); kernel.Set(2, 1, -alpha); kernel.Set(2, 2, 0f);

            // Apply filter
            Mat filtered = new Mat();
            Cv2.Filter2D(grayMat, filtered, -1, kernel);

            // Convert back to BGR if needed
            Mat result = new Mat();
            if (processedMat.Channels() == 3)
            {
                Cv2.CvtColor(filtered, result, ColorConversionCodes.GRAY2BGR);
            }
            else
            {
                result = filtered.Clone();
            }

            // Clean up
            kernel.Dispose();
            grayMat.Dispose();
            filtered.Dispose();

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region Binning Processor

        private void btnBinning_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isBinningActive)
                {
                    isBinningActive = true;
                    btnBinning.BackColor = Color.LightBlue;

                    // Apply Binning if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate Binning
                    isBinningActive = false;
                    btnBinning.BackColor = SystemColors.Control;

                   
                        // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Binning Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyBinningProcessor()
        {
            if (processedMat == null || processedMat.Empty()) return;

            // Downscale by factor of 2 (binning 2x2)
            Mat downscaled = new Mat();
            Cv2.Resize(processedMat, downscaled, new OpenCvSharp.Size(processedMat.Width / 2, processedMat.Height / 2),
                       interpolation: InterpolationFlags.Area);

            // Upscale back to original size
            Mat result = new Mat();
            Cv2.Resize(downscaled, result, new OpenCvSharp.Size(processedMat.Width, processedMat.Height),
                       interpolation: InterpolationFlags.Nearest);

            // Clean up
            downscaled.Dispose();

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region AGC Processor

        private void btnAgc_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isAgcActive)
                {
                    isAgcActive = true;
                    btnAgc.BackColor = Color.LightBlue;

                    // Apply AGC if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate AGC
                    isAgcActive = false;
                    btnAgc.BackColor = SystemColors.Control;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in AGC Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyAgcProcessor()
        {
            if (processedMat == null || processedMat.Empty()) return;

            // Convert to grayscale if needed
            Mat grayMat = new Mat();
            if (processedMat.Channels() == 3)
            {
                Cv2.CvtColor(processedMat, grayMat, ColorConversionCodes.BGR2GRAY);
            }
            else
            {
                grayMat = processedMat.Clone();
            }

            // Get min-max values
            Cv2.MinMaxLoc(grayMat, out double minVal, out double maxVal);

            // Apply AGC based on radio button selection
            Mat result = new Mat();

            if (radioButton3.Checked) // Auto mode
            {
                // Auto contrast stretch
                Cv2.Normalize(grayMat, result, 0, 255, NormTypes.MinMax);
            }
            else if (radioButton4.Checked) // Semi mode
            {
                // Get thresholds from textboxes
                if (double.TryParse(textBox3.Text, out double thInf) &&
                    double.TryParse(textBox4.Text, out double thSup))
                {
                    // Clip values outside the threshold range
                    Mat mask1 = new Mat(), mask2 = new Mat();
                    Cv2.Threshold(grayMat, mask1, thInf, 255, ThresholdTypes.Binary);
                    Cv2.Threshold(grayMat, mask2, thSup, 255, ThresholdTypes.BinaryInv);

                    Mat clipped = new Mat();
                    Cv2.Max(grayMat, thInf, clipped);
                    Cv2.Min(clipped, thSup, clipped);

                    // Normalize to full range
                    Cv2.Normalize(clipped, result, 0, 255, NormTypes.MinMax);

                    // Clean up
                    mask1.Dispose();
                    mask2.Dispose();
                    clipped.Dispose();
                }
                else
                {
                    // Fallback to auto if thresholds invalid
                    Cv2.Normalize(grayMat, result, 0, 255, NormTypes.MinMax);
                }
            }
            else // Manual mode
            {
                // Get limits from textboxes
                if (double.TryParse(textBox5.Text, out double limitInf) &&
                    double.TryParse(textBox6.Text, out double limitSup))
                {
                    // Calculate gain and offset
                    double gain = 255.0 / (limitSup - limitInf);
                    double offset = -gain * limitInf;

                    // Apply gain and offset
                    grayMat.ConvertTo(result, MatType.CV_8UC1, gain, offset);
                }
                else
                {
                    // Fallback to auto if limits invalid
                    Cv2.Normalize(grayMat, result, 0, 255, NormTypes.MinMax);
                }
            }

            // Convert back to BGR if needed
            Mat finalResult = new Mat();
            if (processedMat.Channels() == 3)
            {
                Cv2.CvtColor(result, finalResult, ColorConversionCodes.GRAY2BGR);
                result.Dispose();
            }
            else
            {
                finalResult = result;
            }

            // Clean up
            grayMat.Dispose();

            // Update processed mat
            processedMat.Dispose();
            processedMat = finalResult;
        }

        #endregion

        #region Flip Processor

        private void btnFlip_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!isFlipActive)
                {
                    isFlipActive = true;
                    btnFlip.BackColor = Color.LightBlue;

                    // Apply Flip if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate Flip
                    isFlipActive = false;
                    btnFlip.BackColor = SystemColors.Control;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Flip Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFlipProcessor()
        {
            if (processedMat == null || processedMat.Empty()) return;

            // Determine flip mode based on radio buttons
            FlipMode flipMode = FlipMode.X; // Default to X-axis

            if (rdb_x.Checked)
            {
                flipMode = FlipMode.X;
            }
            else if (rdb_y.Checked)
            {
                flipMode = FlipMode.Y;
            }
            else if (radioButton1.Checked) // Both X and Y
            {
                flipMode = FlipMode.XY;
            }

            // Apply flip
            Mat result = new Mat();
            Cv2.Flip(processedMat, result, flipMode);

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region Gamma Processor

        private void btnGamma_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isGammaActive)
                {
                    isGammaActive = true;
                    btnGamma.BackColor = Color.LightBlue;

                    // Apply Gamma if image is already loaded
                    ApplyActiveProcessors();
                }
                else
                {
                    // Deactivate Gamma
                    isGammaActive = false;
                    btnGamma.BackColor = SystemColors.Control;

                    // Re-apply other processors
                    ApplyActiveProcessors();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Gamma Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyGammaProcessor()
        {
            if (processedMat == null || processedMat.Empty()) return;

            // Get gamma value from slider (0.1 to 3.0)
            float gamma = (hScrollBar1.Value - 50) / 25.0f + 1.0f; // 0 = 0.1, 50 = 1.0, 100 = 3.0
            textBox9.Text = gamma.ToString("F2");

            // Create lookup table for gamma correction
            Mat lookupTable = new Mat(1, 256, MatType.CV_8U);
            for (int i = 0; i < 256; i++)
            {
                lookupTable.At<byte>(0, i) = (byte)(Math.Pow(i / 255.0, 1.0 / gamma) * 255.0);
            }

            // Apply gamma correction
            Mat result = new Mat();

            if (processedMat.Channels() == 1)
            {
                Cv2.LUT(processedMat, lookupTable, result);
            }
            else
            {
                // Split channels
                Mat[] channels = new Mat[3];
                Cv2.Split(processedMat, out channels);

                // Apply gamma to each channel
                for (int i = 0; i < 3; i++)
                {
                    Cv2.LUT(channels[i], lookupTable, channels[i]);
                }

                // Merge channels back
                Cv2.Merge(channels, result);

                // Clean up
                foreach (var channel in channels)
                {
                    channel.Dispose();
                }
            }

            // Clean up
            lookupTable.Dispose();

            // Update processed mat
            processedMat.Dispose();
            processedMat = result;
        }

        #endregion

        #region Focus Processor

        private void btnFocus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isFocusActive)
                {
                    isFocusActive = true;
                    btnFocus.BackColor = Color.LightBlue;

                    // Find and display sharpest region if image is already loaded
                    if (originalMat != null && !originalMat.Empty())
                    {
                        Task.Run(() => FindAndDisplaySharpestRegion(originalMat));
                    }
                }
                else
                {
                    // Deactivate Focus
                    isFocusActive = false;
                    btnFocus.BackColor = SystemColors.Control;

                    // Clear focus display
                    if (pvDisplayControl3.Image != null)
                    {
                        pvDisplayControl3.Image.Dispose();
                        pvDisplayControl3.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in Focus Processor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Action Buttons

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // If we have a video path, start playing
                if (!string.IsNullOrEmpty(currentFilePath) && rdVideo.Checked)
                {
                    StartVideoProcessing(currentFilePath);
                }
                else if (!string.IsNullOrEmpty(currentFilePath) && rdPicture.Checked)
                {
                    // Reload current image
                    LoadImageFile(currentFilePath);
                }
                else
                {
                    MessageBox.Show("Please select a valid file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting processing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                // Stop video processing
                StopVideoProcessing();

                // Clear displays
                if (pvDisplayControl.Image != null)
                {
                    pvDisplayControl.Image.Dispose();
                    pvDisplayControl.Image = null;
                }

                if (pvDisplayControl2.Image != null)
                {
                    pvDisplayControl2.Image.Dispose();
                    pvDisplayControl2.Image = null;
                }

                if (pvDisplayControl3.Image != null)
                {
                    pvDisplayControl3.Image.Dispose();
                    pvDisplayControl3.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping processing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                // Clean up and close
                DisposeResources();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exiting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            // Show configuration dialog (if implemented)
            MessageBox.Show("Settings functionality not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Upload configuration (if implemented)
            MessageBox.Show("Upload functionality not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Helper Methods and UI Controls

        // Add any additional helper methods here

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Update gamma value display and reapply if active
            if (isGammaActive)
            {
                ApplyActiveProcessors();
            }
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            // Update edge enhancement value and reapply if active
            if (isEdgeActive)
            {
                ApplyActiveProcessors();
            }
        }



        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}