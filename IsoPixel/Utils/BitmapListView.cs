using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel.Utils
{
    public class BitmapListView : BufferedGraphicsControl
    {
        private int count = 40;
        private int top = 0;
        private int size = 64;

        private int padding = 8;

        private int selectedIndex = 3;
        private bool isHovered = false;

        private int TotalHeight
        {
            get
            {
                return count * (size + padding) + padding;
            }
        }

        private int GetFirstVisibleIndex()
        {
            if (top >= 0)
            {
                return 0;
            }

            return (-top) / (size + padding);
        }

        private int GetLastVisibleIndex()
        {
            int index = 1 + (-top + Height) / (size + padding);
            return index < count ? index : (count - 1);
        }

        private int GetPositionForItem(int index)
        {
            return top + index * (size + padding);
        }

        private int GetIndexForPosition(int position)
        {
            return (position - top) / (size + padding);
        }

        protected override void OnBufferSetup(System.Drawing.Graphics gr)
        {

        }

        protected override void OnBufferPaint(System.Drawing.Graphics gr)
        {
            gr.Clear(Color.WhiteSmoke);

            for (int i = GetFirstVisibleIndex(); i <= GetLastVisibleIndex(); i++)
            {
                if (i == selectedIndex)
                {
                    gr.FillRectangle(Brushes.LightBlue, padding/2, GetPositionForItem(i) + padding/2, size + padding , size + padding );
                }
                gr.FillRectangle(Brushes.White, padding, GetPositionForItem(i) + padding, size, size);
                gr.DrawString(i.ToString(), Font, Brushes.Black, padding * 2, padding * 2 + GetPositionForItem(i));
            }
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            selectedIndex = GetIndexForPosition(e.Y);
            Invalidate();
            base.OnMouseClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Width = size + 2 * padding;
            base.OnResize(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            Focus();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            if (isHovered)
            {
                top += e.Delta;

                if (top > 0)
                {
                    top = 0;
                }

                if (TotalHeight > Height)
                {
                    if (-top + Height > TotalHeight)
                    {
                        top = -TotalHeight + Height;
                    }
                }
                else
                {
                    top = 0;
                }

                Invalidate();
            }
            base.OnMouseWheel(e);
        }
    }
}
