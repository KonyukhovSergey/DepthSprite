using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class BitmapList : BufferedGraphicsControl
    {
        private int count = 0;

        private int top = 0;
        private int size = 64;
        private int tile = 16;
        private int padding = 8;
        private int selectedIndex = 3;
        private int hoveredIndex = -1;

        private bool isControlHovered = false;

        private int TotalHeight
        {
            get
            {
                return count * (size + tile + padding);
            }
        }

        private int GetFirstVisibleIndex()
        {
            if (top >= 0)
            {
                return 0;
            }

            return (-top) / (size + tile + padding);
        }

        private int GetLastVisibleIndex()
        {
            int index = 1 + (-top + Height) / (size + tile + padding);
            return index < count ? index : (count - 1);
        }

        private int GetPositionForItem(int index)
        {
            return top + index * (size + tile + padding);
        }

        private int GetIndexForPosition(int position)
        {
            return (position - top) / (size + tile + padding);
        }

        protected override void OnBufferSetup(System.Drawing.Graphics gr)
        {

        }

        protected override void OnBufferPaint(System.Drawing.Graphics gr)
        {
            gr.Clear(Color.White);

            for (int i = GetFirstVisibleIndex(); i <= GetLastVisibleIndex(); i++)
            {
                if (i == selectedIndex)
                {
                    gr.FillRectangle(Brushes.LightSteelBlue, 0, GetPositionForItem(i), size + padding * 2, size + tile + padding);
                }

                if (i == hoveredIndex)
                {
                    gr.FillRectangle(Brushes.LightBlue, 0, GetPositionForItem(i), size + padding * 2, size + tile + padding);
                }

                gr.FillRectangle(Brushes.White, padding, GetPositionForItem(i) + padding, size, size);

                if (OnGetItemBitmap != null)
                {
                    gr.DrawImage(OnGetItemBitmap(i), padding, GetPositionForItem(i));
                }

                if (OnGetItemTitle != null)
                {
                    gr.DrawString(OnGetItemTitle(i), Font, Brushes.Black, padding, GetPositionForItem(i) + size + padding);
                }
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            int index = GetIndexForPosition(e.Y);

            if (hoveredIndex != index)
            {
                hoveredIndex = index;
                Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            int index = GetIndexForPosition(e.Y);

            if (index != selectedIndex)
            {
                selectedIndex = index;
                Invalidate();

                if (OnSelectItem != null && selectedIndex >= 0 && selectedIndex < count)
                {
                    OnSelectItem(selectedIndex);
                }
            }
            base.OnMouseClick(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Width = size + 2 * padding;
            base.OnResize(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isControlHovered = true;
            Focus();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isControlHovered = false;
            hoveredIndex = -1;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            if (isControlHovered)
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

        [Category("BitmapListView")]
        public event OnSelectItemEvent OnSelectItem;

        [Category("BitmapListView")]
        public event OnGetItemTitleEvent OnGetItemTitle;

        [Category("BitmapListView")]
        public event OnGetItemBitmapEvent OnGetItemBitmap;

        [Category("BitmapListView")]
        public int SelectionIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    Invalidate();
                }
            }
        }

        [Category("BitmapListView")]
        public int ItemsCount
        {
            get
            {
                return count;
            }
            set
            {
                if (value != count)
                {
                    count = value;
                    Invalidate();
                }
            }
        }

        public delegate void OnSelectItemEvent(int index);
        public delegate string OnGetItemTitleEvent(int index);
        public delegate Bitmap OnGetItemBitmapEvent(int index);
    }


}
