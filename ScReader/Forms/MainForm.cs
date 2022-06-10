using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

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

        private GlobalKeyboardHook _globalKeyboard;
        

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

        private Settings _settings;
        public MainForm()
        {
            InitializeComponent();

            Title.BackColor = Color.FromArgb(44, 62, 98);
            ButtonMinimize.BackColor = Color.FromArgb(44, 62, 98);
            ButtonExit.BackColor = Color.FromArgb(44, 62, 98);
            SavePath.BackColor = Color.FromArgb(33, 44, 57);
            Screenshot.BackColor = Color.FromArgb(33, 44, 57);
            BackColor = Color.FromArgb(33, 44, 57);
            SavePathTextBox.BackColor = Color.FromArgb(44, 62, 98);
            SavePathTextBox.ForeColor = Color.WhiteSmoke;

            TitleText.ForeColor = Color.WhiteSmoke;
            label1.ForeColor = Color.WhiteSmoke;
            CheckBoxAutoRun.ForeColor = Color.WhiteSmoke;


            _settings = new Settings();
            

            _menu = new ContextMenuStrip();
            _menu.Items.Add("Захват экрана   |PrintScreen", Properties.Resources.screenshot, (s, e) => 
            {
                _getText = false;
                _isShow = false;
                ShowScreen(SavePath, null);
            });
            _menu.Items.Add("Извлечь текст   |F9", Properties.Resources.free_transform, (s, e) =>
            {
                _getText = true;
                _isShow = false;
                ShowScreen(SavePath, null);
            });
            _menu.Items.Add("Выйти", Properties.Resources.button, (s, e) => Application.Exit());

            foreach (ToolStripItem item in _menu.Items)
            {
                item.BackColor = Color.FromArgb(33, 44, 57);
                item.ForeColor = Color.WhiteSmoke;
                item.MouseEnter += (s, e) => item.ForeColor = Color.Black;
                item.MouseLeave += (s, e) => item.ForeColor = Color.WhiteSmoke;
            }

            _icon = new NotifyIcon()
            {
                Icon = Properties.Resources.screenshot1,
                Visible = false,
                ContextMenuStrip = _menu,
                Text = TitleText.Text
            };

            _icon.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Show();
                    _icon.Visible = false;
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
            };

            CheckBoxAutoRun.CheckedChanged += (s, e) =>
            {
                _settings.AutoStart = CheckBoxAutoRun.Checked;
                _settings.WriteConfig(_settings);
            };

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));

            KeyPreview = true;
        }

        private void ButtonExit_Click(object sender, EventArgs e) => Application.Exit();

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
            _icon.Visible = true;
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

        private void Title_MouseUp(object sender, MouseEventArgs e) => _isDragging = false;

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
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();

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
            _globalKeyboard = new GlobalKeyboardHook();

            _globalKeyboard.HookedKeys.Add(Keys.PrintScreen);
            _globalKeyboard.HookedKeys.Add(Keys.F9);

            _globalKeyboard.KeyUp += (s, e) => 
            {
                if (e.KeyCode == Keys.PrintScreen)
                {
                    _getText = false;

                    if (_icon.Visible == true)
                        _isShow = false;
                    
                    else
                        _isShow = true;
                    
                    ShowScreen(SavePath, null);
                }
                else if (e.KeyCode == Keys.F9)
                {
                    _getText = true;

                    if (_icon.Visible == true)
                        _isShow = false;

                    else
                        _isShow = true;

                    ShowScreen(SavePath, null);
                }
            }; 

            _settings = _settings.ReadConfig(_settings);

            CheckBoxAutoRun.Checked = _settings.AutoStart;

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