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
            BackColor = Color.FromArgb(44, 62, 98);

            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
        }

        private void StatusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect(0, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(1, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.Collect(2, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }
    }
}
