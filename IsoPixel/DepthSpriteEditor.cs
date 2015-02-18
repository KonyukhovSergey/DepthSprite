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
                gr.FillRectangle(Brushes.SlateGray, 0, 0, sprite.Width * 8, sprite.Height * 8);
                gr.DrawImage(sprite.Bitmap, 0, 0, sprite.Width * 8, sprite.Height * 8);
            }
        }
    }
}
