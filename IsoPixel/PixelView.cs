using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;

namespace IsoPixel
{
    public class PixelView : BufferedGraphicsControl
    {
        private Sprite sprite = new Sprite(128, 128);
        private Bitmap bitmap = new Bitmap(128, 128);
        private Cube cube = new Cube(16, new CoordinateCalculator(128, 128, 8, 4, 7));
        private CursorPosition cursor = new CursorPosition();

        private FastBitmap[] tiles;

        protected override void OnBufferSetup(Graphics gr)
        {
            gr.Clear(Color.WhiteSmoke);
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        }

        protected override void OnBufferPaint(Graphics gr)
        {
            if (tiles == null)
            {
                tiles = new FastBitmap[1];
                tiles[0] = new FastBitmap(Image.FromFile("d:\\brick.png"));
            }

            gr.Clear(Color.WhiteSmoke);

            cube.DrawTo(sprite, tiles);
            sprite.ToBitmap(bitmap);
            gr.DrawImage(bitmap, 4, 24, bitmap.Width * 3, bitmap.Height * 3);
            gr.DrawString(cursor.Info(), Font, Brushes.Black, 4, 4);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (cursor.ControlKey(keyData))
            {
                Invalidate();
                return true;
            }
            else if (keyData == Keys.Space)
            {
                int tile = cube.Get(cursor.x, cursor.y, cursor.z);
                cube.Set(cursor.x, cursor.y, cursor.z, (byte)(tile > 0 ? 0 : 1));
                Invalidate();
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
