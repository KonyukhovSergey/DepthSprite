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
            this.pixelView1 = new IsoPixel.PixelView();
            this.bitmapListView2 = new IsoPixel.Utils.BitmapListView();
            this.bitmapListView1 = new IsoPixel.Utils.BitmapListView();
            this.SuspendLayout();
            // 
            // pixelView1
            // 
            this.pixelView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pixelView1.Location = new System.Drawing.Point(259, 12);
            this.pixelView1.Name = "pixelView1";
            this.pixelView1.Size = new System.Drawing.Size(273, 424);
            this.pixelView1.TabIndex = 2;
            this.pixelView1.Text = "pixelView1";
            // 
            // bitmapListView2
            // 
            this.bitmapListView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bitmapListView2.Location = new System.Drawing.Point(80, 0);
            this.bitmapListView2.Margin = new System.Windows.Forms.Padding(0);
            this.bitmapListView2.Name = "bitmapListView2";
            this.bitmapListView2.Size = new System.Drawing.Size(80, 448);
            this.bitmapListView2.TabIndex = 1;
            this.bitmapListView2.Text = "bitmapListView2";
            // 
            // bitmapListView1
            // 
            this.bitmapListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.bitmapListView1.Location = new System.Drawing.Point(0, 0);
            this.bitmapListView1.Margin = new System.Windows.Forms.Padding(0);
            this.bitmapListView1.Name = "bitmapListView1";
            this.bitmapListView1.Size = new System.Drawing.Size(80, 448);
            this.bitmapListView1.TabIndex = 0;
            this.bitmapListView1.Text = "bitmapListView1";
            // 
            // IsoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 448);
            this.Controls.Add(this.pixelView1);
            this.Controls.Add(this.bitmapListView2);
            this.Controls.Add(this.bitmapListView1);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "IsoEdit";
            this.Text = "IsoEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.BitmapListView bitmapListView1;
        private Utils.BitmapListView bitmapListView2;
        private PixelView pixelView1;

    }
}

