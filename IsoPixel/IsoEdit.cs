using IsoPixel.IsoControls;
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
        private IsoControl root;

        public IsoEdit()
        {
            root = new IsoMouseTest(0, 0, 400, 300);

            root.Add(new IsoMouseTest(4, 30, 80, 200));
            root.Add(new IsoMouseTest(250, 200, 80, 40, AnchorStyles.Right | AnchorStyles.Bottom));
            root.Add(new IsoMouseTest(100, 34, 80, 100, AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right));
            IsoControl c = new IsoMouseTest(150, 150, 100, 100, AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
            root.Add(c);
            c.Add(new IsoMouseTest(4, 34, 30, 20));
            c.Add(new IsoMouseTest(64, 74, 30, 30, AnchorStyles.Right | AnchorStyles.Bottom));

            InitializeComponent();
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            root.DrawTo(e.Graphics);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            root.UpdateBounds(0, 0, ClientSize.Width, ClientSize.Height);
            base.OnSizeChanged(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            root.OnMouseMove(e.X, e.Y);
            Invalidate();
        }
    }
}
