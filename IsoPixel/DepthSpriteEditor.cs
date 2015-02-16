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
        private DepthContainer sprites;

        private FastGraphics fg;

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
                sprite.DrawTo(fg, sprites);
                gr.FillRectangle(Brushes.SlateGray, 0, 0, fg.Width * 8, fg.Height * 8);
                gr.DrawImage(fg.Bitmap, 0, 0, fg.Width * 8, fg.Height * 8);
            }
        }

        public void SetSprite(DepthSprite sprite, DepthContainer sprites)
        {
            this.sprite = sprite;
            this.sprites = sprites;

            fg = new FastGraphics(sprite.Width, sprite.Height);

            Invalidate();
        }

        public DepthSprite GetSprite()
        {
            return sprite;
        }
    }
}
