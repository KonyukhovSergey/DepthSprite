using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace IsoPixel
{
    public class Sprite : FastBitmap
    {
        private int[] zvalues;

        public Sprite(int width, int height)
            : base(width, height)
        {
            zvalues = new int[width * height];
        }

        public void Clear(Color color)
        {
            Clear(color, int.MaxValue);
        }

        public void Clear(Color color, int z)
        {
            for (int i = 0; i < zvalues.Length; i++)
            {
                SetPixel(i % Width, i / Width, color);
                zvalues[i] = z;
            }
        }

        public void Draw(FastBitmap fb, int px, int py, int z)
        {
            for (int y = 0; y < fb.Height; y++)
            {
                int sy = py + y;
                if (sy < 0 || sy >= Height) continue;
                for (int x = 0; x < fb.Height; x++)
                {
                    int sx = px + x;
                    if (sx < 0 || sx >= Width) continue;

                    int i = sy * Width + sx;

                    if (z <= zvalues[i])
                    {
                        Color c = fb.GetPixel(x, y);
                        if (c.A != 0)
                        {
                            SetPixel(sx, sy, c);
                            zvalues[i] = z;
                        }
                    }
                }
            }
        }
    }
}
