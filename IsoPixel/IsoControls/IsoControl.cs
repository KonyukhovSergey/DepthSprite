using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel.IsoControls
{
    public class IsoControl
    {
        private int left, top, width, height;
        private AnchorStyles anchor = AnchorStyles.Left | AnchorStyles.Top;
        private IList<IsoControl> controls = new List<IsoControl>();

        public IsoControl(int left, int top, int width, int height)
        {
            UpdateBounds(left, top, width, height);
        }

        public IsoControl(int left, int top, int width, int height, AnchorStyles anchor)
            : this(left, top, width, height)
        {
            this.anchor = anchor;
        }

        public void UpdateBounds(int left, int top, int width, int height)
        {
            foreach (var control in controls)
            {
                control.UpdateBounds(
                    control.left + (control.anchor.HasFlag(AnchorStyles.Left) ? 0 : (control.anchor.HasFlag(AnchorStyles.Right) ? width - this.width : 0)),
                    control.top + (control.anchor.HasFlag(AnchorStyles.Top) ? 0 : (control.anchor.HasFlag(AnchorStyles.Bottom) ? height - this.height : 0)),
                    control.width + (control.anchor.HasFlag(AnchorStyles.Left | AnchorStyles.Right) ? width - this.width : 0),
                    control.height + (control.anchor.HasFlag(AnchorStyles.Top | AnchorStyles.Bottom) ? height - this.height : 0)
                    );
            }

            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;

            OnSize(width, height);
        }

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public virtual void OnMouseMove(int x, int y)
        {
            foreach (var control in controls)
            {
                control.OnMouseMove(x - control.left, y - control.top);
            }
        }

        public virtual void OnSize(int width, int height)
        {

        }

        public void DrawTo(Graphics gr)
        {
            gr.TranslateTransform(left, top);

            gr.SetClip(new Rectangle(0, 0, width, height));

            OnPaint(gr);

            foreach (var control in controls)
            {
                control.DrawTo(gr);
            }

            gr.TranslateTransform(-left, -top);
        }

        public virtual void OnPaint(Graphics gr)
        {
        }

        public void Add(IsoControl control)
        {
            controls.Add(control);
        }

        public void Remove(IsoControl control)
        {
            controls.Remove(control);
        }
    }
}
