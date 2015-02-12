using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel
{
    public abstract class BufferedGraphicsControl : Control
    {
        private Bitmap bitmap = null;
        private Graphics graphics = null;

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (bitmap == null)
            {
                bitmap = new Bitmap(Width, Height);
                graphics = Graphics.FromImage(bitmap);
                OnBufferSetup(graphics);
            }

            OnBufferPaint(graphics);
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
        }

        protected override void OnResize(EventArgs e)
        {
            if (bitmap != null)
            {
                graphics.Dispose();
                bitmap.Dispose();
                bitmap = null;
            }
        }

        protected abstract void OnBufferSetup(Graphics gr);
        protected abstract void OnBufferPaint(Graphics gr);
    }
}
