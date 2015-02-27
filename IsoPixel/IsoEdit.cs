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
            root = new IsoControl(0, 0, 400, 300);

            root.Add(new IsoControl(4, 4, 80, 200));
            root.Add(new IsoControl(200, 200, 80, 20, AnchorStyles.Right | AnchorStyles.Bottom));
            root.Add(new IsoControl(100, 4, 80, 100, AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right));
            root.Add(new IsoControl(150, 150, 100, 100, AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right|AnchorStyles.Bottom));

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
    }
}
