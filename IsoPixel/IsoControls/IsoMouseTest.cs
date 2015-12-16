using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel.IsoControls
{
    public class IsoMouseTest : IsoControl
    {
        private Font font = new Font(FontFamily.GenericSansSerif, 8);
        private int x, y;

        public IsoMouseTest(int left, int top, int width, int height) : base(left, top, width, height) { }
        public IsoMouseTest(int left, int top, int width, int height,AnchorStyles anchor) : base(left, top, width, height,anchor) { }

        public override void OnMouseMove(int x, int y)
        {
            this.x = x;
            this.y = y;
            base.OnMouseMove(x, y);
        }
        public override void OnPaint(System.Drawing.Graphics gr)
        {
            gr.Clear(Color.WhiteSmoke);
            gr.DrawRectangle(Pens.DarkGreen, 0, 0, Width - 1, Height - 1);
            gr.DrawString(x.ToString() + " " + y.ToString(), font, Brushes.Black, 2, 2);
        }
    }
}
