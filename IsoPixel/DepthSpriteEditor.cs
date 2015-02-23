using IsoPixel.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class DepthSpriteEditor : BufferedGraphicsControl
    {
        private DepthSprite sprite;

        public int left = 0, top = 0, zoom = 8;

        public DepthSprite Sprite
        {
            get { return sprite; }
            set { sprite = value; Invalidate(); }
        }

        public DepthSpriteEditor()
        {
            mode = new EditorModeBase(this);
        }

        private EditorModeBase mode;

        public EditorModeBase Mode { get { return mode; } set { mode = value; } }

        protected override void OnBufferSetup(Graphics gr)
        {
            gr.InterpolationMode = InterpolationMode.NearestNeighbor;
            gr.PixelOffsetMode = PixelOffsetMode.Half;
        }

        protected override void OnBufferPaint(Graphics gr)
        {
            gr.Clear(Color.LightGray);

            if (sprite != null)
            {
                gr.FillRectangle(Brushes.SlateGray, left, top, sprite.Width * zoom, sprite.Height * zoom);
                gr.DrawImage(sprite.Bitmap, left, top, sprite.Width * zoom, sprite.Height * zoom);

                //foreach (var subSprite in sprite.subSprites)
                //{
                //    DepthSprite ds = sprite.container[subSprite.id];
                //    gr.DrawRectangle(Pens.LightGreen, subSprite.x * zoom + left, subSprite.y * zoom + top, ds.Width * 8, ds.Height * 8);
                //}
            }

            mode.OnDraw(gr);
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (mode.OnMouseDown(e))
            {
                return;
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (mode.OnMouseMove(e))
            {
                return;
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (mode.OnMouseUp(e))
            {
                return;
            }

            base.OnMouseUp(e);
        }
    }
}
