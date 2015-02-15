using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel
{
    public partial class IsoEdit : Form
    {
        private DepthContainer sprites = new DepthContainer();

        public IsoEdit()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }

        private void tsmiImportSprite_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = "*.png|.png files",
                Multiselect = true,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    sprites.Add(new DepthSprite(Image.FromFile(fileName)) { name = Path.GetFileNameWithoutExtension(fileName) });
                }
                listSprites.ItemsCount = sprites.Count;
            }
        }

        private Bitmap listSprites_OnGetItemBitmap(int index)
        {
            var item = sprites[index];
            FastGraphics fastGraphics = new FastGraphics(item.Width, item.Height);

            item.DrawTo(fastGraphics, sprites);
            return fastGraphics.Bitmap;
        }

        private string listSprites_OnGetItemTitle(int index)
        {
            return sprites[index].name;
        }

        private void listSprites_OnSelectItem(int index)
        {
            spriteEditor.SetSprite(sprites[index], sprites);
        }
    }
}
