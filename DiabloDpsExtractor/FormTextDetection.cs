using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Tesseract;
using PageSegMode = Tesseract.PageSegMode;

namespace DiabloDpsExtractor
{
    public partial class FormTextDetection : Form
    {

        VideoCapture capture;
        Bitmap detectedTxtImg;
        private int minThresholdDefault = 2;
        private int maxThresholdDefault = 10;
        private TesseractEngine ocr;

        public FormTextDetection()
        {
            InitializeComponent();
            minThresholdValue.Text = minThresholdDefault.ToString();
            maxThresholdValue.Text = maxThresholdDefault.ToString();
            minThresholdTrackbar.Value = minThresholdDefault;
            maxThresholdTrackbar.Value = maxThresholdDefault;
            ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            ocr.SetVariable("tessedit_char_whitelist", "BM0123456789.");
        }

        private void startStripMenuItem_Click(object sender, EventArgs e)
        {
            //Rectangle screenArea = Rectangle.FromLTRB(0, 0, 2560, 1440); // 1st monitor
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
                        var image = m.ToImage<Bgr, byte>();
                        image.ROI = new Rectangle(200, 100, 800, 500);
                        DetectText(image);
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

            //sobelj
            var sobel = img
                //.InRange(new Bgr(0, 80, 100), new Bgr(35, 220, 240)) // yellow ish detection
                //.Convert<Gray, byte>()
                //.ThresholdBinary(new Hsv(25, 50, 50), new Hsv(32, 255, 255))
                .Convert<Hsv, byte>()
                .InRange(new Hsv(25, 100, 100), new Hsv(30, 255, 255)) // yellow ish detection
                .Convert<Gray, byte>()
                .Sobel(1, 0, 3)
                .AbsDiff(new Gray(0.0))
                .Convert<Gray, byte>()
                .ThresholdBinary(new Gray(55), new Gray(255));

            var se = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(15, 2), new Point(-1, -1));
            sobel = sobel.MorphologyEx(MorphOp.Dilate, se, new Point(-1, -1), 1, BorderType.Reflect, new MCvScalar(255));
            var contours = new VectorOfVectorOfPoint();
            var m = new Mat();
            
            CvInvoke.FindContours(sobel, contours, m, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            //ReadText(img, contours);
            DisplayBoxes(img, contours);
        }

        private void ReadText(Image<Bgr, byte> imgInput, VectorOfVectorOfPoint contours)
        {
            Regex rx = new Regex(@"^(\d+.?\d+?)([MB])[[:>:]]");
            
            if (contours.Size > 0)
            {
                for (int i = 0; i < contours.Size; i++)
                {
                    var brect = CvInvoke.BoundingRectangle(contours[i]);

                    // GET TEXT
                    var imageText = imgInput.Copy();
                    imageText.ROI = brect;
                    contrastBox.Image = imgInput.Bitmap;
                    outputBox.Image = imageText.Bitmap;
                    var results = "";
                    try
                    {
                        // OCR
                        var page = ocr.Process(imageText.Bitmap, PageSegMode.SingleWord);
                        results = page.GetText();

                        if (!string.IsNullOrWhiteSpace(results))
                        {
                            var matches = rx.Matches(results);
                            if (matches.Count > 0)
                            {
                                Console.WriteLine("detected text: " + results.Trim());
                                var groups = matches[0].Groups;
                                int dmg;
                                if (!int.TryParse(groups[1].Value, out dmg))
                                {
                                    page.Dispose();
                                    return;
                                }
                                var multiplierMatch = groups[2].Value;
                                var multiplier = 1;
                                if (multiplierMatch == "M")
                                {
                                    multiplier = 1000000;
                                }
                                else if (multiplierMatch == "B")
                                {
                                    multiplier = 1000000000;
                                }

                                var totalDmg = (long)dmg * (long)multiplier;
                                Console.WriteLine("text value: " + totalDmg);
                            }
                        }

                        page.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    
                    imageText.Dispose();
                    //imgInput.ROI = Rectangle.Empty;
                }
                
                imgInput.Dispose();
            }
        }

        private void DisplayBoxes(Image<Bgr, byte> imgInput, VectorOfVectorOfPoint contours)
        {
            var list = new List<Rectangle>();

            if (contours.Size > 0)
            {
                for (int i = 0; i < contours.Size; i++)
                {
                    var brect = CvInvoke.BoundingRectangle(contours[i]);

                    double ar = brect.Width / brect.Height;
                    if (ar > 2 && brect.Width > 25 && brect.Height > 8 && brect.Height < 100)
                    {
                        list.Add(brect);
                    }
                }


                var imgOut = imgInput.CopyBlank();
                foreach (var r in list)
                {
                    CvInvoke.Rectangle(imgInput, r, new MCvScalar(0, 0, 255), 2);
                    CvInvoke.Rectangle(imgOut, r, new MCvScalar(0, 255, 255), -1);
                }

                imgOut._And(imgOut);
                contrastBox.Image = imgOut.Bitmap;
                outputBox.Image = imgInput.Bitmap;
            }
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
