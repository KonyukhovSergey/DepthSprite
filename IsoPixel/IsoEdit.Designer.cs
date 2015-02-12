namespace IsoPixel
{
    partial class IsoEdit
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
            this.pixelView = new IsoPixel.PixelView();
            this.SuspendLayout();
            // 
            // pixelView
            // 
            this.pixelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pixelView.Location = new System.Drawing.Point(0, 0);
            this.pixelView.Name = "pixelView";
            this.pixelView.Size = new System.Drawing.Size(666, 480);
            this.pixelView.TabIndex = 0;
            this.pixelView.Text = "pixelView1";
            // 
            // IsoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 480);
            this.Controls.Add(this.pixelView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "IsoEdit";
            this.Text = "IsoEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private PixelView pixelView;
    }
}

