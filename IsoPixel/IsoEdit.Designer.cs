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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsSpriteList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiImportSprite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteSprite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewSprite = new System.Windows.Forms.ToolStripMenuItem();
            this.container = new IsoPixel.BitmapList();
            this.cmsSpriteList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Container";
            // 
            // cmsSpriteList
            // 
            this.cmsSpriteList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewSprite,
            this.tsmiImportSprite,
            this.toolStripSeparator1,
            this.tsmiDeleteSprite,
            this.toolStripSeparator2,
            this.tsmiLoad,
            this.tsmiSave});
            this.cmsSpriteList.Name = "cmsSpriteList";
            this.cmsSpriteList.Size = new System.Drawing.Size(152, 126);
            // 
            // tsmiImportSprite
            // 
            this.tsmiImportSprite.Name = "tsmiImportSprite";
            this.tsmiImportSprite.Size = new System.Drawing.Size(151, 22);
            this.tsmiImportSprite.Text = "Import sprite...";
            this.tsmiImportSprite.Click += new System.EventHandler(this.tsmiImportSprite_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // tsmiLoad
            // 
            this.tsmiLoad.Name = "tsmiLoad";
            this.tsmiLoad.Size = new System.Drawing.Size(151, 22);
            this.tsmiLoad.Text = "Load...";
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(151, 22);
            this.tsmiSave.Text = "Save...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // tsmiDeleteSprite
            // 
            this.tsmiDeleteSprite.Name = "tsmiDeleteSprite";
            this.tsmiDeleteSprite.Size = new System.Drawing.Size(151, 22);
            this.tsmiDeleteSprite.Text = "Delete sprite...";
            // 
            // tsmiNewSprite
            // 
            this.tsmiNewSprite.Name = "tsmiNewSprite";
            this.tsmiNewSprite.Size = new System.Drawing.Size(151, 22);
            this.tsmiNewSprite.Text = "New sprite...";
            // 
            // container
            // 
            this.container.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.container.ContextMenuStrip = this.cmsSpriteList;
            this.container.ItemsCount = 0;
            this.container.Location = new System.Drawing.Point(12, 25);
            this.container.Name = "container";
            this.container.SelectionIndex = -1;
            this.container.Size = new System.Drawing.Size(80, 483);
            this.container.TabIndex = 3;
            this.container.Text = "bitmapList1";
            this.container.OnGetItemBitmap += new IsoPixel.BitmapList.OnGetItemBitmapEvent(this.container_OnGetItemBitmap);
            // 
            // IsoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(779, 520);
            this.Controls.Add(this.container);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "IsoEdit";
            this.Text = "IsoEdit";
            this.cmsSpriteList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsSpriteList;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewSprite;
        private System.Windows.Forms.ToolStripMenuItem tsmiImportSprite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteSprite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private BitmapList container;


    }
}

