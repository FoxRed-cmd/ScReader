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
            this.components = new System.ComponentModel.Container();
            this.SavePathTextBox = new System.Windows.Forms.TextBox();
            this.SavePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Screenshot = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonMinimize = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.CheckBoxAutoRun = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ReadText = new System.Windows.Forms.Button();
            this.OpenInExplorer = new System.Windows.Forms.Button();
            this.Title.SuspendLayout();
            this.SuspendLayout();
            // 
            // SavePathTextBox
            // 
            this.SavePathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SavePathTextBox.Location = new System.Drawing.Point(87, 38);
            this.SavePathTextBox.Name = "SavePathTextBox";
            this.SavePathTextBox.Size = new System.Drawing.Size(208, 23);
            this.SavePathTextBox.TabIndex = 1;
            // 
            // SavePath
            // 
            this.SavePath.BackColor = System.Drawing.SystemColors.Control;
            this.SavePath.BackgroundImage = global::ScReader.Properties.Resources.diskette;
            this.SavePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SavePath.FlatAppearance.BorderSize = 0;
            this.SavePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SavePath.Location = new System.Drawing.Point(301, 38);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(24, 24);
            this.SavePath.TabIndex = 2;
            this.toolTip1.SetToolTip(this.SavePath, "Обзор");
            this.SavePath.UseVisualStyleBackColor = false;
            this.SavePath.Click += new System.EventHandler(this.SavePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сохранить:";
            // 
            // Screenshot
            // 
            this.Screenshot.BackColor = System.Drawing.SystemColors.Control;
            this.Screenshot.BackgroundImage = global::ScReader.Properties.Resources.screenshot;
            this.Screenshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Screenshot.FlatAppearance.BorderSize = 0;
            this.Screenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Screenshot.Location = new System.Drawing.Point(331, 38);
            this.Screenshot.Name = "Screenshot";
            this.Screenshot.Size = new System.Drawing.Size(24, 24);
            this.Screenshot.TabIndex = 0;
            this.toolTip1.SetToolTip(this.Screenshot, "Захват экрана   |PrintScreen");
            this.Screenshot.UseVisualStyleBackColor = false;
            this.Screenshot.Click += new System.EventHandler(this.Screenshot_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.BackColor = System.Drawing.Color.RoyalBlue;
            this.ButtonExit.BackgroundImage = global::ScReader.Properties.Resources.button;
            this.ButtonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonExit.FlatAppearance.BorderSize = 0;
            this.ButtonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonExit.Location = new System.Drawing.Point(331, 3);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(24, 24);
            this.ButtonExit.TabIndex = 3;
            this.ButtonExit.UseVisualStyleBackColor = false;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonMinimize
            // 
            this.ButtonMinimize.BackColor = System.Drawing.Color.RoyalBlue;
            this.ButtonMinimize.BackgroundImage = global::ScReader.Properties.Resources.minimize;
            this.ButtonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonMinimize.FlatAppearance.BorderSize = 0;
            this.ButtonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMinimize.Location = new System.Drawing.Point(301, 3);
            this.ButtonMinimize.Name = "ButtonMinimize";
            this.ButtonMinimize.Size = new System.Drawing.Size(24, 24);
            this.ButtonMinimize.TabIndex = 4;
            this.ButtonMinimize.UseVisualStyleBackColor = false;
            this.ButtonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.RoyalBlue;
            this.Title.Controls.Add(this.TitleText);
            this.Title.Controls.Add(this.ButtonExit);
            this.Title.Controls.Add(this.ButtonMinimize);
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(364, 30);
            this.Title.TabIndex = 5;
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            this.Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Title_MouseMove);
            this.Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Title_MouseUp);
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.ForeColor = System.Drawing.SystemColors.Control;
            this.TitleText.Location = new System.Drawing.Point(12, 9);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(55, 15);
            this.TitleText.TabIndex = 5;
            this.TitleText.Text = "ScReader";
            // 
            // CheckBoxAutoRun
            // 
            this.CheckBoxAutoRun.AutoSize = true;
            this.CheckBoxAutoRun.Location = new System.Drawing.Point(12, 67);
            this.CheckBoxAutoRun.Name = "CheckBoxAutoRun";
            this.CheckBoxAutoRun.Size = new System.Drawing.Size(195, 19);
            this.CheckBoxAutoRun.TabIndex = 6;
            this.CheckBoxAutoRun.Text = "Запускать при старте Windows";
            this.CheckBoxAutoRun.UseVisualStyleBackColor = true;
            // 
            // ReadText
            // 
            this.ReadText.BackgroundImage = global::ScReader.Properties.Resources.free_transform;
            this.ReadText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReadText.FlatAppearance.BorderSize = 0;
            this.ReadText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadText.Location = new System.Drawing.Point(331, 63);
            this.ReadText.Name = "ReadText";
            this.ReadText.Size = new System.Drawing.Size(24, 24);
            this.ReadText.TabIndex = 7;
            this.toolTip1.SetToolTip(this.ReadText, "Извлечь текст   |F9");
            this.ReadText.UseVisualStyleBackColor = true;
            this.ReadText.Click += new System.EventHandler(this.ReadText_Click);
            // 
            // OpenInExplorer
            // 
            this.OpenInExplorer.BackgroundImage = global::ScReader.Properties.Resources.folder;
            this.OpenInExplorer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.OpenInExplorer.FlatAppearance.BorderSize = 0;
            this.OpenInExplorer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenInExplorer.Location = new System.Drawing.Point(301, 64);
            this.OpenInExplorer.Name = "OpenInExplorer";
            this.OpenInExplorer.Size = new System.Drawing.Size(24, 23);
            this.OpenInExplorer.TabIndex = 8;
            this.toolTip1.SetToolTip(this.OpenInExplorer, "Отркыть в проводнике");
            this.OpenInExplorer.UseVisualStyleBackColor = true;
            this.OpenInExplorer.Click += new System.EventHandler(this.OpenInExplorer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 92);
            this.Controls.Add(this.OpenInExplorer);
            this.Controls.Add(this.ReadText);
            this.Controls.Add(this.CheckBoxAutoRun);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Screenshot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.SavePathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Opacity = 0.93D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ScReader";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Title.ResumeLayout(false);
            this.Title.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox SavePathTextBox;
        private Button SavePath;
        private Label label1;
        private Button Screenshot;
        private Button ButtonExit;
        private Button ButtonMinimize;
        private Panel Title;
        private Label TitleText;
        private CheckBox CheckBoxAutoRun;
        private ToolTip toolTip1;
        private Button ReadText;
        private Button OpenInExplorer;
    }
}