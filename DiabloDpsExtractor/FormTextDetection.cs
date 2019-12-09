using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DiabloDpsExtractor
{
    public partial class FormTextDetection : Form
    {
        VideoCapture capture;
        private int minThresholdDefault = 50;
        private int maxThresholdDefault = 255;
        public FormTextDetection()
        {
            InitializeComponent();
            minThresholdValue.Text = minThresholdDefault.ToString();
            maxThresholdValue.Text = maxThresholdDefault.ToString();
            minThresholdTrackbar.Value = minThresholdDefault;
            maxThresholdTrackbar.Value = maxThresholdDefault;
        }

        private void startStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle screenArea = Rectangle.FromLTRB(2561, 0, 5120, 1440); // 2nd monitor
            ScreenCaptureStream stream = new ScreenCaptureStream(screenArea, 100);
            stream.NewFrame += new NewFrameEventHandler(video_NewFrame);
            openVideoToolStripMenuItem.Enabled = false;

            // start the video source
            stream.Start();
        }

        private void OpenVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                startRecordingToolStripMenuItem.Enabled = false;
                capture = new VideoCapture(ofd.FileName);
                Mat m = new Mat();
                capture.Read(m);
                DetectVideoText();
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // get new frame
            // figure out how to not make this run out of memory
            var bitmap = eventArgs.Frame.Clone() as Bitmap;

            // process the frame
            var img = new Image<Bgr, byte>(bitmap);

            DetectText(img);
            bitmap.Dispose();
        }

        private async void DetectVideoText()
        {
            if (capture == null)
            {
                return;
            }

            try
            {

                while (true)
                {
                    Mat m = new Mat();
                    capture.Read(m);

                    if (!m.IsEmpty)
                    {
                        outputBox.Image = m.Bitmap;
                        DetectText(m.ToImage<Bgr, byte>());
                        double fps = capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                        await Task.Delay(1000 / Convert.ToInt32(fps));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DetectText(Image<Bgr, byte> img)
        {
            /*
             1. Edge detection (sobel)
             2. Dilation (10,1)
             3. FindContours
             4. Geometrical Constraints
             */

            //sobel

            // add sliders here to figure out how to detect D3 damages
            var sobel = img
                .Convert<Gray, byte>()
                .Sobel(1, 0, 3)
                .AbsDiff(new Gray(0.0))
                .Convert<Gray, byte>()
                .ThresholdBinary(new Gray(minThresholdDefault), new Gray(maxThresholdDefault));

            var se = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(10, 2), new Point(-1, -1));
            sobel = sobel.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Dilate, se, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Reflect, new MCvScalar(255));
            var contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            var m = new Mat();
            
            CvInvoke.FindContours(sobel, contours, m, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            var list = new List<Rectangle>();

            for (int i = 0; i < contours.Size; i++)
            {
                var brect = CvInvoke.BoundingRectangle(contours[i]);

                double ar = brect.Width / brect.Height;
                if (ar > 2 && brect.Width > 25 && brect.Height > 8 && brect.Height < 100)
                {
                    list.Add(brect);
                }
            }


            var imgOut = img.CopyBlank();
            foreach (var r in list)
            {
                CvInvoke.Rectangle(img, r, new MCvScalar(0, 0, 255), 2);
                CvInvoke.Rectangle(imgOut, r, new MCvScalar(0, 255, 255), -1);
            }

            imgOut._And(imgOut);
            contrastBox.Image = imgOut.Bitmap;
            outputBox.Image = img.Bitmap;
        }

        private void thresholdBinaryTrackbar_Scroll(object sender, EventArgs e)
        {
            minThresholdDefault = minThresholdTrackbar.Value;
            minThresholdValue.Text = minThresholdDefault.ToString();
        }

        private void maxThresholdTrackbar_Scroll(object sender, EventArgs e)
        {
            maxThresholdDefault = maxThresholdTrackbar.Value;
            maxThresholdValue.Text = maxThresholdDefault.ToString();
        }
    }
}
