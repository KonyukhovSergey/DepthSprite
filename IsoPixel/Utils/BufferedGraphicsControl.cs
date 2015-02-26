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
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            OnBufferPaint(e.Graphics);
        }

        protected abstract void OnBufferPaint(Graphics gr);
    }
}
