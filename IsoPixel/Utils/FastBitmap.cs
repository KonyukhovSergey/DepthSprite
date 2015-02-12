using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class FastBitmap : BitmapSize
    {
        private byte[] data;
        private int stride;

        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public FastBitmap(Image image)
        {
            Bitmap bmp = new Bitmap(image);
            width = bmp.Width;
            height = bmp.Height;

            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            stride = bd.Stride;
            int bytes = stride * bmp.Height;

            data = new byte[bytes];

            Marshal.Copy(bd.Scan0, data, 0, bd.Stride * bd.Height);

            bmp.UnlockBits(bd);
            bmp.Dispose();
        }

        public FastBitmap(int width, int height)
        {
            this.width = width;
            this.height = height;
            stride = width * 4;
            data = new byte[stride * height];
        }

        public Color GetPixel(int i, int j)
        {
            if (IsInBox(i, j))
            {
                int p = i * 4 + j * stride;
                return Color.FromArgb(data[p + 3], data[p + 2], data[p + 1], data[p + 0]);
            }
            else
            {
                return Color.Transparent;
            }
        }

        public int GetA(int i, int j)
        {
            if (IsInBox(i, j))
            {
                return data[i * 4 + j * stride + 3];
            }
            return 255;
        }

        public void SetPixel(int i, int j, Color c)
        {
            if (IsInBox(i, j))
            {
                int p = i * 4 + j * stride;
                data[p + 3] = c.A;
                data[p + 2] = c.R;
                data[p + 1] = c.G;
                data[p + 0] = c.B;
            }
        }

        public void SetPixel(int i, int j, Color c, int alpha)
        {
            if (IsInBox(i, j))
            {
                int p = i * 4 + j * stride;
                data[p + 3] = c.A;
                data[p + 2] = (byte)(((int)data[p + 2] * (255 - alpha) + c.R * alpha) / 255);
                data[p + 1] = (byte)(((int)data[p + 1] * (255 - alpha) + c.G * alpha) / 255);
                data[p + 0] = (byte)(((int)data[p + 0] * (255 - alpha) + c.B * alpha) / 255);
            }
        }

        public Bitmap ToBitmap()
        {
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            ToBitmap(bmp);
            return bmp;
        }

        public void ToBitmap(Bitmap bmp)
        {
            if (bmp.Width == width && bmp.Height == height)
            {
                BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                Marshal.Copy(data, 0, bd.Scan0, stride * height);
                bmp.UnlockBits(bd);
            }
            else
            {
                throw new InvalidOperationException("wrong bitmap size");
            }
        }
    }
}
