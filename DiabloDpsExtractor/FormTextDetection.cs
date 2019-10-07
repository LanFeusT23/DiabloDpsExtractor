using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using Emgu.CV;
using Emgu.CV.Structure;

namespace DiabloDpsExtractor
{
    public partial class FormTextDetection : Form
    {
        public FormTextDetection()
        {
            InitializeComponent();
        }

        private void startStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle screenArea = Rectangle.FromLTRB(0, 0, 2560, 1440);
            ScreenCaptureStream stream = new ScreenCaptureStream(screenArea, 100);
            stream.NewFrame += new NewFrameEventHandler(video_NewFrame);

            // start the video source
            stream.Start();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // get new frame
            var bitmap = eventArgs.Frame.Clone() as Bitmap;

            // process the frame
            var img = new Image<Bgr, byte>(bitmap);

            var imgOut = DetectText(img);
            pictureBox1.Image = img.Bitmap;
            pictureBox2.Image = imgOut.Bitmap;
        }

        private Image<Bgr, byte> DetectText(Image<Bgr, byte> img)
        {
            /*
             1. Edge detection (sobel)
             2. Dilation (10,1)
             3. FindContours
             4. Geometrical Constraints
             */

            //sobel
            var sobel = img
                .Convert<Gray, byte>()
                .Sobel(1, 0, 3)
                .AbsDiff(new Gray(0.0))
                .Convert<Gray, byte>()
                .ThresholdBinary(new Gray(50), new Gray(255));

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

            return imgOut;

        }
    }
}
