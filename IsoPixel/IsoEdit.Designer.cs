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
            this.tsmiNewSprite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImportSprite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDeleteSprite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.spriteEditor = new IsoPixel.DepthSpriteEditor();
            this.listContainedIn = new IsoPixel.BitmapList();
            this.listContains = new IsoPixel.BitmapList();
            this.listSprites = new IsoPixel.BitmapList();
            this.cmsSpriteList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sprites";
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
            // tsmiNewSprite
            // 
            this.tsmiNewSprite.Name = "tsmiNewSprite";
            this.tsmiNewSprite.Size = new System.Drawing.Size(151, 22);
            this.tsmiNewSprite.Text = "New sprite...";
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
            // tsmiDeleteSprite
            // 
            this.tsmiDeleteSprite.Name = "tsmiDeleteSprite";
            this.tsmiDeleteSprite.Size = new System.Drawing.Size(151, 22);
            this.tsmiDeleteSprite.Text = "Delete sprite...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contained in:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(553, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contains:";
            // 
            // spriteEditor
            // 
            this.spriteEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spriteEditor.Location = new System.Drawing.Point(98, 25);
            this.spriteEditor.Name = "spriteEditor";
            this.spriteEditor.Size = new System.Drawing.Size(452, 466);
            this.spriteEditor.TabIndex = 8;
            this.spriteEditor.Text = "depthSpriteEditor1";
            // 
            // listContainedIn
            // 
            this.listContainedIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listContainedIn.ItemsCount = 0;
            this.listContainedIn.Location = new System.Drawing.Point(642, 25);
            this.listContainedIn.Name = "listContainedIn";
            this.listContainedIn.SelectionIndex = 3;
            this.listContainedIn.Size = new System.Drawing.Size(80, 466);
            this.listContainedIn.TabIndex = 6;
            this.listContainedIn.Text = "bitmapList2";
            // 
            // listContains
            // 
            this.listContains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listContains.ItemsCount = 0;
            this.listContains.Location = new System.Drawing.Point(556, 25);
            this.listContains.Name = "listContains";
            this.listContains.SelectionIndex = 3;
            this.listContains.Size = new System.Drawing.Size(80, 466);
            this.listContains.TabIndex = 4;
            this.listContains.Text = "bitmapList1";
            // 
            // listSprites
            // 
            this.listSprites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listSprites.ContextMenuStrip = this.cmsSpriteList;
            this.listSprites.ItemsCount = 0;
            this.listSprites.Location = new System.Drawing.Point(12, 25);
            this.listSprites.Name = "listSprites";
            this.listSprites.SelectionIndex = -1;
            this.listSprites.Size = new System.Drawing.Size(80, 466);
            this.listSprites.TabIndex = 3;
            this.listSprites.OnSelectItem += new IsoPixel.BitmapList.OnSelectItemEvent(this.listSprites_OnSelectItem);
            this.listSprites.OnGetItemTitle += new IsoPixel.BitmapList.OnGetItemTitleEvent(this.listSprites_OnGetItemTitle);
            this.listSprites.OnGetItemBitmap += new IsoPixel.BitmapList.OnGetItemBitmapEvent(this.listSprites_OnGetItemBitmap);
            // 
            // IsoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(734, 503);
            this.Controls.Add(this.spriteEditor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listContainedIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listContains);
            this.Controls.Add(this.listSprites);
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
        private BitmapList listSprites;
        private BitmapList listContains;
        private System.Windows.Forms.Label label2;
        private BitmapList listContainedIn;
        private System.Windows.Forms.Label label3;
        private DepthSpriteEditor spriteEditor;


    }
}

