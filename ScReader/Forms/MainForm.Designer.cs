namespace ScReader.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            SavePathTextBox = new TextBox();
            SavePath = new Button();
            Screenshot = new Button();
            ButtonExit = new Button();
            ButtonMinimize = new Button();
            Title = new Panel();
            TitleText = new Label();
            ReadText = new Button();
            OpenInExplorer = new Button();
            toolTip1 = new ToolTip(components);
            Title.SuspendLayout();
            SuspendLayout();
            // 
            // SavePathTextBox
            // 
            SavePathTextBox.BorderStyle = BorderStyle.FixedSingle;
            SavePathTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            SavePathTextBox.Location = new Point(12, 38);
            SavePathTextBox.Name = "SavePathTextBox";
            SavePathTextBox.Size = new Size(317, 23);
            SavePathTextBox.TabIndex = 6;
            SavePathTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // SavePath
            // 
            SavePath.BackColor = Color.RoyalBlue;
            SavePath.BackgroundImage = Properties.Resources.diskette;
            SavePath.BackgroundImageLayout = ImageLayout.Center;
            SavePath.FlatAppearance.BorderSize = 0;
            SavePath.FlatStyle = FlatStyle.Flat;
            SavePath.Location = new Point(112, 3);
            SavePath.Name = "SavePath";
            SavePath.Size = new Size(24, 24);
            SavePath.TabIndex = 0;
            toolTip1.SetToolTip(SavePath, "Browse");
            SavePath.UseVisualStyleBackColor = false;
            SavePath.Click += SavePath_Click;
            // 
            // Screenshot
            // 
            Screenshot.BackColor = Color.RoyalBlue;
            Screenshot.BackgroundImage = Properties.Resources.screenshot;
            Screenshot.BackgroundImageLayout = ImageLayout.Center;
            Screenshot.FlatAppearance.BorderSize = 0;
            Screenshot.FlatStyle = FlatStyle.Flat;
            Screenshot.Location = new Point(172, 3);
            Screenshot.Name = "Screenshot";
            Screenshot.Size = new Size(24, 24);
            Screenshot.TabIndex = 2;
            toolTip1.SetToolTip(Screenshot, "Screenshot");
            Screenshot.UseVisualStyleBackColor = false;
            Screenshot.Click += Screenshot_Click;
            // 
            // ButtonExit
            // 
            ButtonExit.BackColor = Color.RoyalBlue;
            ButtonExit.BackgroundImage = Properties.Resources.button;
            ButtonExit.BackgroundImageLayout = ImageLayout.Center;
            ButtonExit.FlatAppearance.BorderSize = 0;
            ButtonExit.FlatStyle = FlatStyle.Flat;
            ButtonExit.Location = new Point(305, 4);
            ButtonExit.Name = "ButtonExit";
            ButtonExit.Size = new Size(24, 24);
            ButtonExit.TabIndex = 5;
            ButtonExit.UseVisualStyleBackColor = false;
            ButtonExit.Click += ButtonExit_Click;
            // 
            // ButtonMinimize
            // 
            ButtonMinimize.BackColor = Color.RoyalBlue;
            ButtonMinimize.BackgroundImage = Properties.Resources.minimize;
            ButtonMinimize.BackgroundImageLayout = ImageLayout.Center;
            ButtonMinimize.FlatAppearance.BorderSize = 0;
            ButtonMinimize.FlatStyle = FlatStyle.Flat;
            ButtonMinimize.Location = new Point(275, 4);
            ButtonMinimize.Name = "ButtonMinimize";
            ButtonMinimize.Size = new Size(24, 24);
            ButtonMinimize.TabIndex = 4;
            ButtonMinimize.UseVisualStyleBackColor = false;
            ButtonMinimize.Click += ButtonMinimize_Click;
            // 
            // Title
            // 
            Title.BackColor = Color.RoyalBlue;
            Title.Controls.Add(TitleText);
            Title.Controls.Add(ReadText);
            Title.Controls.Add(OpenInExplorer);
            Title.Controls.Add(ButtonExit);
            Title.Controls.Add(ButtonMinimize);
            Title.Controls.Add(Screenshot);
            Title.Controls.Add(SavePath);
            Title.Location = new Point(0, 0);
            Title.Name = "Title";
            Title.Size = new Size(339, 30);
            Title.TabIndex = 5;
            Title.MouseDown += Title_MouseDown;
            Title.MouseMove += Title_MouseMove;
            Title.MouseUp += Title_MouseUp;
            // 
            // TitleText
            // 
            TitleText.AutoSize = true;
            TitleText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TitleText.ForeColor = SystemColors.Control;
            TitleText.Location = new Point(8, 8);
            TitleText.Name = "TitleText";
            TitleText.Size = new Size(60, 15);
            TitleText.TabIndex = 5;
            TitleText.Text = "ScReader";
            // 
            // ReadText
            // 
            ReadText.BackgroundImage = Properties.Resources.free_transform;
            ReadText.BackgroundImageLayout = ImageLayout.Center;
            ReadText.FlatAppearance.BorderSize = 0;
            ReadText.FlatStyle = FlatStyle.Flat;
            ReadText.Location = new Point(202, 3);
            ReadText.Name = "ReadText";
            ReadText.Size = new Size(24, 24);
            ReadText.TabIndex = 3;
            toolTip1.SetToolTip(ReadText, "Read text");
            ReadText.UseVisualStyleBackColor = true;
            ReadText.Click += ReadText_Click;
            // 
            // OpenInExplorer
            // 
            OpenInExplorer.BackgroundImage = Properties.Resources.folder;
            OpenInExplorer.BackgroundImageLayout = ImageLayout.Center;
            OpenInExplorer.FlatAppearance.BorderSize = 0;
            OpenInExplorer.FlatStyle = FlatStyle.Flat;
            OpenInExplorer.Location = new Point(142, 4);
            OpenInExplorer.Name = "OpenInExplorer";
            OpenInExplorer.Size = new Size(24, 23);
            OpenInExplorer.TabIndex = 1;
            toolTip1.SetToolTip(OpenInExplorer, "Open save folder");
            OpenInExplorer.UseVisualStyleBackColor = true;
            OpenInExplorer.Click += OpenInExplorer_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 71);
            Controls.Add(Title);
            Controls.Add(SavePathTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Opacity = 0.93D;
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "ScReader";
            TopMost = true;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            Title.ResumeLayout(false);
            Title.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SavePathTextBox;
        private Button SavePath;
        private Button Screenshot;
        private Button ButtonExit;
        private Button ButtonMinimize;
        private Panel Title;
        private Label TitleText;
        private ToolTip toolTip1;
        private Button ReadText;
        private Button OpenInExplorer;
    }
}