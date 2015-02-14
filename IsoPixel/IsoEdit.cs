using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel
{
    public partial class IsoEdit : Form
    {
        private DepthContainer depthContainer = new DepthContainer();

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
            OpenFileDialog ofd = new OpenFileDialog() { DefaultExt = "*.png|.png files", Multiselect = false };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FastBitmap fb = new FastBitmap(Image.FromFile(ofd.FileName));
                depthContainer.sprites.Add(Guid.NewGuid().ToString(), new DepthSprite(fb));
                container.ItemsCount = depthContainer.sprites.Count;
            }
        }

        

        private Bitmap container_OnGetItemBitmap(int index)
        {
            var item = depthContainer.sprites.Values.ToArray()[index];
            FastGraphics fg = new FastGraphics(item.Width,item.Height);
            item.DrawTo(fg,depthContainer.sprites);

            return fg.Bitmap;
        }
    }
}
