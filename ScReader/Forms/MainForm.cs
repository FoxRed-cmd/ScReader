using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ScReader.Forms
{
    public partial class MainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private bool _isDragging = false;
        private Point _dragCursorPoint;
        private Point _dragFormPoint;
        private Point _dif;

        internal bool _isShow = true;
        internal bool _getText = false;
        internal string _prevPath;
        internal Image _currentImage;

        internal string _savePath;
        private FolderBrowserDialog _folderBrowserDialog;
        private NotifyIcon _icon;
        private ContextMenuStrip _menu;

        private PictureForm _pictureForm;

        private Rectangle _resolution;
        private Bitmap _image;
        private Graphics _graphics;

        internal Settings _settings;
        public MainForm()
        {
            InitializeComponent();

            Title.BackColor = Color.FromArgb(44, 62, 98);
            ButtonMinimize.BackColor = Color.FromArgb(44, 62, 98);
            SavePath.BackColor = Color.FromArgb(44, 62, 98);
            Screenshot.BackColor = Color.FromArgb(44, 62, 98);
            ButtonExit.BackColor = Color.FromArgb(44, 62, 98);
            BackColor = Color.FromArgb(33, 44, 57);
            SavePathTextBox.BackColor = Color.FromArgb(44, 62, 98);
            SavePathTextBox.ForeColor = Color.WhiteSmoke;

            TitleText.ForeColor = Color.WhiteSmoke;


            _settings = new Settings();



            _menu = new ContextMenuStrip()
            {
                ShowCheckMargin = true,
                ShowImageMargin = false,
            };

            _menu.Items.Add("Screenshot", null, (s, e) =>
            {
                _getText = false;
                _isShow = false;
                ShowScreen(SavePath, null);
            });
            _menu.Items.Add("Read Text", null, (s, e) =>
            {
                _getText = true;
                _isShow = false;
                ShowScreen(SavePath, null);
            });

            _menu.Items.Add(new ToolStripSeparator());

            _menu.Items.Add("Save image", null, (s, e) =>
            {
                var menuCheck = (s as ToolStripMenuItem);

                _settings.SaveImage = menuCheck.Checked = !menuCheck.Checked;
                _settings.WriteConfig(_settings);
            });
            _menu.Items.Add("Startup with windows", null, (s, e) =>
            {
                var menuCheck = (s as ToolStripMenuItem);

                _settings.AutoStart = menuCheck.Checked = !menuCheck.Checked;
                _settings.WriteConfig(_settings);
            });

            _menu.Items.Add(new ToolStripSeparator());

            _menu.Items.Add("Exit", null, (s, e) => Application.Exit());

            _icon = new NotifyIcon()
            {
                Icon = Properties.Resources.screenshot1,
                Visible = true,
                ContextMenuStrip = _menu,
                Text = TitleText.Text
            };

            _icon.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Visible)
                    {
                        GC.Collect(2, GCCollectionMode.Forced);
                        GC.WaitForPendingFinalizers();
                        Hide();
                    }
                    else
                        Show();
                }
            };

            _savePath = $@"{Application.StartupPath}ScReaderImages";
            SavePathTextBox.Text = _savePath;

            if (!Directory.Exists(_savePath))
                Directory.CreateDirectory(_savePath);

            _folderBrowserDialog = new FolderBrowserDialog()
            {
                InitialDirectory = SavePathTextBox.Text,
            };
            SavePathTextBox.TextChanged += (s, e) =>
            {
                _savePath = SavePathTextBox.Text;
                _settings.SavePath = _savePath;
                _settings.WriteConfig(_settings);
            };
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
            TitleText.ContextMenuStrip = _menu;
            KeyPreview = true;
        }

        private void ButtonExit_Click(object sender, EventArgs e) => Application.Exit();

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            this.Hide();
        }

        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = true;
            _dragCursorPoint = Cursor.Position;
            _dragFormPoint = this.Location;
        }

        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                _dif = Point.Subtract(Cursor.Position, new Size(_dragCursorPoint));
                this.Location = Point.Add(_dragFormPoint, new Size(_dif));
            }
        }

        private void Title_MouseUp(object sender, MouseEventArgs e)
        {
            _settings.Top = Top;
            _settings.Left = Left;
            _settings.WriteConfig(_settings);
            _isDragging = false;
        }

        private void SavePath_Click(object sender, EventArgs e)
        {
            using (_folderBrowserDialog)
            {
                if (DialogResult.OK == _folderBrowserDialog.ShowDialog())
                {
                    SavePathTextBox.Text = _folderBrowserDialog.SelectedPath;
                    _savePath = SavePathTextBox.Text;
                }
            }
        }

        private void Screenshot_Click(object sender, EventArgs e)
        {
            _getText = false;
            _isShow = true;
            ShowScreen(sender, e);
        }

        private void ShowScreen(object sender, EventArgs e)
        {
            if (SavePathTextBox.Text != null && SavePathTextBox.Text != string.Empty)
            {
                this.Hide();
                _currentImage = MakeScreenshot();
                _pictureForm.ScreenImage.Image = _currentImage;
                _pictureForm.ShowDialog();

                _image.Dispose();
            }
            else
            {
                SavePath_Click(sender, e);
            }
        }

        internal Bitmap MakeScreenshot(bool saveImage = false)
        {
            _resolution = Screen.PrimaryScreen.Bounds;

            _image = new Bitmap(_resolution.Width, _resolution.Height);

            using (_graphics = Graphics.FromImage(_image))
            {
                _graphics.CompositingQuality = CompositingQuality.HighQuality;
                _graphics.CopyFromScreen(Point.Empty, Point.Empty, _resolution.Size);
            }

            if (saveImage)
            {
                if (!Directory.Exists(_savePath))
                    Directory.CreateDirectory(_savePath);
                _prevPath = $@"{_savePath}\{DateTime.Now:dd-MM-yyyy_hh-mm-ss}.png";
                _image.Save(_prevPath, ImageFormat.Png);
            }
            return _image;
        }

        internal Bitmap MakeScreenshot(Point start, Point end, bool saveImage = false)
        {
            FindResolutionImage(ref start, ref end, ref _resolution);

            _image = new Bitmap(_resolution.Width, _resolution.Height);

            using (_graphics = Graphics.FromImage(_image))
            {
                _graphics.CompositingQuality = CompositingQuality.HighQuality;
                _graphics.CopyFromScreen(start, Point.Empty, _resolution.Size);
            }

            if (saveImage)
            {
                if (!Directory.Exists(_savePath))
                    Directory.CreateDirectory(_savePath);
                _prevPath = $@"{_savePath}\{DateTime.Now:dd-MM-yyyy_hh-mm-ss}.png";
                _image.Save(_prevPath, ImageFormat.Png);
            }

            ImageToClipboard(_image);

            return _image;
        }

        private void ImageToClipboard(Image image)
        {
            if (_getText == false)
            {
                Clipboard.SetImage(image);
            }
        }

        internal void FindResolutionImage(ref Point start, ref Point end, ref Rectangle resolution)
        {
            if (start.Y < end.Y && start.X < end.X)
            {
                resolution = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);
            }
            else if (start.Y < end.Y && start.X > end.X)
            {
                resolution = new Rectangle(end.X, start.Y, start.X - end.X, end.Y - start.Y);
                start = new Point(end.X, start.Y);
            }
            else if (start.Y > end.Y && start.X > end.X)
            {
                resolution = new Rectangle(end.X, end.Y, start.X - end.X, start.Y - end.Y);
                start = new Point(end.X, end.Y);
            }
            else if (start.Y > end.Y && start.X < end.X)
            {
                resolution = new Rectangle(start.X, end.Y, start.X - end.X, end.Y - start.Y);
                start = new Point(start.X, end.Y);
            }

            if (resolution.Width < 0)
                resolution.Width *= -1;

            if (resolution.Height < 0)
                resolution.Height *= -1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _settings = _settings.ReadConfig(_settings);

            (_menu.Items[3] as ToolStripMenuItem).Checked = _settings.SaveImage;
            (_menu.Items[4] as ToolStripMenuItem).Checked = _settings.AutoStart;

            _savePath = _settings.SavePath;
            SavePathTextBox.Text = _savePath;

            this.Top = _settings.Top;
            this.Left = _settings.Left;

            _pictureForm = new PictureForm() { Owner = this };
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.Top = this.Top;
            _settings.Left = this.Left;
            _settings.SavePath = _savePath;

            _settings.WriteConfig(_settings);

            _icon.Visible = false;
        }

        private void ReadText_Click(object sender, EventArgs e)
        {
            _getText = true;
            _isShow = true;
            ShowScreen(sender, e);
        }

        private void OpenInExplorer_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", _savePath);
            this.Hide();
            _icon.Visible = true;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (_settings.AutoStart)
            {
                this.Hide();
                _icon.Visible = true;
            }
        }
    }
}