using System.Runtime.InteropServices;

namespace ScReader.Forms
{
    public partial class StatusForm : Form
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

        public StatusForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
        }
    }
}
