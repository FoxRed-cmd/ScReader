namespace ScReader.Forms
{
    partial class AimForm
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
            this.AimPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AimPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // AimPicture
            // 
            this.AimPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AimPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AimPicture.Location = new System.Drawing.Point(1, 1);
            this.AimPicture.Name = "AimPicture";
            this.AimPicture.Size = new System.Drawing.Size(248, 248);
            this.AimPicture.TabIndex = 0;
            this.AimPicture.TabStop = false;
            // 
            // AimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.Controls.Add(this.AimPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AimForm";
            this.Text = "AimForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AimForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AimPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox AimPicture;
    }
}