﻿using IsoPixel.Utils;
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

        private int left = 0, top = 0, zoom = 8;
        private int state = 0;
        private DragHelper dragHelper = new DragHelper();

        public DepthSprite Sprite
        {
            get { return sprite; }
            set { sprite = value; Invalidate(); }
        }

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

                foreach (var subSprite in sprite.subSprites)
                {
                    DepthSprite ds = sprite.container[subSprite.id];
                    gr.DrawRectangle(Pens.LightGreen, subSprite.x * zoom + left, subSprite.y * zoom + top, ds.Width * 8, ds.Height * 8);
                }
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            dragHelper.OnMouseDown(e, left, top);
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (dragHelper.OnMouseMove(e))
            {
                left = dragHelper.CurrentObjectLocationX;
                top = dragHelper.CurrentObjectLocationY;
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (dragHelper.OnMouseUp(e))
            {
                left = dragHelper.CurrentObjectLocationX;
                top = dragHelper.CurrentObjectLocationY;
                Invalidate();
            }
            base.OnMouseUp(e);
        }
    }
}