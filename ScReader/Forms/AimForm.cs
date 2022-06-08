using System.Drawing.Drawing2D;

namespace ScReader.Forms
{
    public partial class AimForm : Form
    {
        private Bitmap _image;
        private Bitmap _imageZoom;
        private Graphics _graphics;
        private Rectangle _resolution;
        private Point _windowPosition;
        private Pen _pen;

        public AimForm()
        {
            InitializeComponent();
            TopMost = true;
            ShowIcon = false;
            ShowInTaskbar = false;
            _pen = new Pen(Brushes.Red, 2);
        }

        private Image ZoomPicture(Image img, Size size)
        {
            _imageZoom = new Bitmap(_image.Width * size.Width, _image.Height * size.Height);
            using (_graphics = Graphics.FromImage(_imageZoom))
            {
                _graphics.SmoothingMode = SmoothingMode.AntiAlias;
                _graphics.CompositingQuality = CompositingQuality.HighQuality;
                _graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                _graphics.DrawImage(_image, new Rectangle(0, 0, _imageZoom.Width, _imageZoom.Height));

                _graphics.DrawLine(_pen, new Point(AimPicture.Width - 124, AimPicture.Height - 132), new Point(AimPicture.Width - 124, AimPicture.Height - 116));
                _graphics.DrawLine(_pen, new Point(AimPicture.Width - 132, AimPicture.Height - 124), new Point(AimPicture.Width - 116, AimPicture.Height - 124));
            }
            return _imageZoom;
        }

        private void ChangeWindowPosition(ref Point cursorPosition)
        {

            if (GetDistance(ref _windowPosition, ref cursorPosition) < 450 && Top == 0 && Left == 0)
            {
                _resolution = Screen.PrimaryScreen.Bounds;
                Top = _resolution.Height - Height;
                Left = _resolution.Width - Width;

                _windowPosition.X = Top;
                _windowPosition.Y = Left;
            }
            else if (GetDistance(ref _windowPosition, ref cursorPosition) < 1400 && Top != 0 && Left != 0)
            {
                Top = 0;
                Left = 0;

                _windowPosition.X = Top;
                _windowPosition.Y = Left;
            }
        }

        private double GetDistance(ref Point pointA, ref Point pointИ) => Math.Sqrt(Math.Pow(pointИ.X - pointA.X, 2) + Math.Pow(pointИ.Y - pointA.Y, 2));

        public void UpdatePosition(Point cursorPosition)
        {
            ChangeWindowPosition(ref cursorPosition);

            _image = new Bitmap(AimPicture.Width, AimPicture.Height);
            using (_graphics = Graphics.FromImage(_image))
            {
                _resolution = new Rectangle(cursorPosition.X - 62, cursorPosition.Y - 62, AimPicture.Width, AimPicture.Height);
                _graphics.CopyFromScreen(new Point(cursorPosition.X - 62, cursorPosition.Y - 62), Point.Empty, _resolution.Size);

                AimPicture.Image = ZoomPicture(_image, new Size(2, 2));

                AimPicture.Refresh();

                GC.Collect(2, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            }
        }

        private void AimForm_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            _windowPosition = new Point(Top, Left);
        }
    }
}
