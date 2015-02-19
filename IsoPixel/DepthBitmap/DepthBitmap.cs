using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class DepthBitmap : FastGraphics
    {
        private static int zoffset = 100;
        private byte[] zvalues = new byte[0];

        public DepthBitmap() { }

        public DepthBitmap(int width, int height)
            : base(width, height)
        {
            zvalues = new byte[width * height];
            ClearZ(0);
        }

        public DepthBitmap(Image image)
            : base(image)
        {
            zvalues = new byte[Width * Height];
            ClearZ(0);
        }

        public string base64_z_values
        {
            get { return Convert.ToBase64String(RLE.Encode(zvalues)); }
            set { zvalues = RLE.Decode(Convert.FromBase64String(value)); }
        }

        public int GetZ(int x, int y)
        {
            return (int)zvalues[x + y * Width] - zoffset;
        }

        public void SetZ(int x, int y, int z)
        {
            zvalues[x + y * Width] = (byte)(z + zoffset);
        }

        public void Clear(int r, int g, int b, int a, int z)
        {
            Graphics.Clear(Color.FromArgb(a, r, g, b));
            ClearZ(z);
        }

        public void ClearZ(int z)
        {
            for (int i = 0; i < zvalues.Length; i++)
            {
                zvalues[i] = (byte)(z + zoffset);
            }
        }

        public void Draw(DepthBitmap source, int px, int py, int pz)
        {
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    if (!IsInRect(px + x, py + y)) continue;

                    if (source.GetColor(x, y).A > 0 && ((pz + source.GetZ(x, y)) <= GetZ(x + px, y + py) || GetColor(x + px, y + py).A == 0))
                    {
                        SetPixel(x + px, y + py, source.GetPixel(x, y));
                        SetZ(x + px, y + py, pz + source.GetZ(x, y));
                    }
                }
            }
        }

        public bool IsInRect(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Width && y < Height;
        }
    }
}
