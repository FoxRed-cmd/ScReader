using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System.Reflection;

namespace ScReader.Forms
{
    public partial class PictureForm : Form
    {
        private StatusForm _statusForm;
        private AimForm _aimForm;
        private Task _task;

        private bool _isSizeChange = false;
        private Point _startPoint;
        private Point _endPoint;
        private MainForm _mainForm;

        private Graphics _graphics;
        private Rectangle _rectangle;
        private Pen _pen;

        private Tesseract tesseract;
        private string lang = "rus+eng";
        private string recText;

        public Image CurrentImage { get; set; }
        public PictureForm()
        {
            InitializeComponent();
            
            _statusForm = new StatusForm();            
        }

        private void ScreenImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isSizeChange = true;
                _startPoint = Cursor.Position;
            }
            else if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Middle)
            {
                _aimForm.Close();

                _isSizeChange = false;
                _mainForm = Owner as MainForm;

                GC.Collect(2, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();

                if (_mainForm._isShow == true)
                    _mainForm.Show();
                this.Close();
            }
        }

        private void ScreenImage_MouseMove(object sender, MouseEventArgs e)
        {
            _aimForm.UpdatePosition(Cursor.Position);

            ScreenImage.Image = (Image?)_mainForm._currentImage.Clone();

            if (_isSizeChange)
            {
                using (_pen = new Pen(Brushes.Red, 1))
                {
                    using (_graphics = Graphics.FromImage(ScreenImage.Image))
                    {
                        FindResolutionImage(_startPoint, Cursor.Position, ref _rectangle);
                        _graphics.DrawRectangle(_pen, _rectangle);
                    }
                }

                ScreenImage.Refresh();

                GC.Collect(2, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }

            ScreenImage.Refresh();
        }

        private async void ScreenImage_MouseUp(object sender, MouseEventArgs e)
        {
            _aimForm.Close();

            _isSizeChange = false;
            _endPoint = Cursor.Position;

            _mainForm = Owner as MainForm;

            if (_startPoint == _endPoint)
            {
                if (_mainForm._isShow == true)
                    _mainForm.Show();
                this.Close();
                return;
            }

            ScreenImage.Image = (Image?)_mainForm._currentImage.Clone();
            ScreenImage.Refresh();

            if (_mainForm._getText == false)
            {
                _mainForm.MakeScreenshot(_startPoint, _endPoint, true);
            }
            else
            {
                _mainForm.MakeScreenshot(_startPoint, _endPoint, true);
                
                _statusForm.Show();

                try
                {
                    GetTextFromImage(_mainForm._prevPath);
                }
                catch (Exception)
                {
                    _statusForm.StatusLabel.Text = "Произошла ошибка";

                    await Task.Delay(1000);

                    _statusForm.Close();

                    if (_mainForm._isShow)
                        _mainForm.Show();

                    this.Close();
                }

                this.Close();

                while (!_task.IsCompleted) 
                { 
                    _statusForm.StatusLabel.Text = "Выполняется извлечение";
                    foreach (char dot in "...")
                    {
                        _statusForm.StatusLabel.Text += dot;
                        await Task.Delay(300);
                    }
                }
                
                File.Delete(_mainForm._prevPath);
                Clipboard.SetText(recText);

                _statusForm.StatusLabel.Text = "Текст скопирован в буфер обмена";

                await Task.Delay(1000);

                _statusForm.Close();
            }

            if (_mainForm._isShow)
                _mainForm.Show();

            this.Close();

            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }

        private string Recognition(string path)
        {
            string currentDir = Assembly.GetExecutingAssembly().Location;
            currentDir = currentDir.Remove(currentDir.LastIndexOf('\\'));
            using (tesseract = new Tesseract($@"{currentDir}\Resources\", lang, OcrEngineMode.LstmOnly))
            {
                tesseract.SetImage(new Image<Bgr, byte>(path));
                tesseract.Recognize();
                return $"{tesseract.GetUTF8Text()}\n";
            }
        }

        private void GetTextFromImage(string path)
        {
            recText = string.Empty;
            _task = new(() => 
            {
                if (path.EndsWith(".png") || path.EndsWith(".jpg"))
                {
                    recText += Recognition(path);
                }
            });
            _task.Start();
        }

        private void FindResolutionImage(Point start, Point end, ref Rectangle rectangle)
        {
            if (start.Y < end.Y && start.X < end.X)
            {
                start = new Point(start.X - 1, start.Y - 1);
                rectangle = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            }
            else if (start.Y < end.Y && start.X > end.X)
            {
                end = new Point(end.X - 1, end.Y + 1);
                start = new Point(start.X + 1, start.Y - 1);
                rectangle = new Rectangle(end.X, start.Y, start.X - end.X, end.Y - start.Y);
            }
            else if (start.Y > end.Y && start.X > end.X)
            {
                end = new Point(end.X - 1, end.Y - 1);
                start = new Point(start.X + 1, start.Y + 1);
                rectangle = new Rectangle(end.X, end.Y, start.X - end.X, start.Y - end.Y);
            }
            else if (start.Y > end.Y && start.X < end.X)
            {
                end = new Point(end.X + 1, end.Y - 1);
                start = new Point(start.X - 1, start.Y + 1);
                rectangle = new Rectangle(start.X, end.Y, start.X - end.X, end.Y - start.Y);
            }

            if (rectangle.Width < 0)
                rectangle.Width *= -1;

            if (rectangle.Height < 0)
                rectangle.Height *= -1;
        }

        private void PictureForm_Load(object sender, EventArgs e)
        {
            _mainForm = Owner as MainForm;
            _aimForm = new AimForm();
            _aimForm.Show();
            _aimForm.UpdatePosition(Cursor.Position);
        }
    }
}
