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
        private IList<string> ids = new List<string>();
        private int count { get { return ids.Count; } }

        private int top = 0;
        private int size = 64;
        private int tile = 16;
        private int padding = 8;

        private int selectedIndex = -1;
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

                if (OnGetItemImage != null)
                {
                    gr.DrawImage(OnGetItemImage(ids[i]), padding, GetPositionForItem(i) + padding);
                }

                gr.DrawString(ids[i], Font, Brushes.Black, padding, GetPositionForItem(i) + size + padding);
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

            selectedIndex = index;

            if (OnSelectItem != null && selectedIndex >= 0 && selectedIndex < count)
            {
                OnSelectItem(ids[selectedIndex]);
            }

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
        public event OnGetItemImageEvent OnGetItemImage;

        [Category("BitmapListView")]
        public string SelectedId
        {
            get
            {
                if (selectedIndex >= 0 && selectedIndex < ids.Count)
                {
                    return ids[selectedIndex];
                }
                else { return default(string); }
            }
            set
            {
                selectedIndex = ids.IndexOf(value);
                Invalidate();
            }
        }


        public void AddId(string id)
        {
            ids.Add(id);
            Invalidate();
        }

        public void RemoveId(string id)
        {
            ids.Remove(id);
            Invalidate();
        }

        public void RemoveAll()
        {
            ids.Clear();
            Invalidate();
        }

        public delegate void OnSelectItemEvent(string id);
        public delegate Image OnGetItemImageEvent(string id);
    }
}
