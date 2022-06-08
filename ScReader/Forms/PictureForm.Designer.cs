namespace ScReader.Forms
{
    partial class PictureForm
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
            this.ScreenImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenImage
            // 
            this.ScreenImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenImage.Location = new System.Drawing.Point(0, 0);
            this.ScreenImage.Name = "ScreenImage";
            this.ScreenImage.Size = new System.Drawing.Size(500, 500);
            this.ScreenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ScreenImage.TabIndex = 0;
            this.ScreenImage.TabStop = false;
            this.ScreenImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenImage_MouseDown);
            this.ScreenImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenImage_MouseMove);
            this.ScreenImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenImage_MouseUp);
            // 
            // PictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.ScreenImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PictureForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PictureForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PictureForm_FormClosing);
            this.Load += new System.EventHandler(this.PictureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScreenImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal PictureBox ScreenImage;
    }
}