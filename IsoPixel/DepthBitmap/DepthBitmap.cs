using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class DepthBitmap : BitmapSize
    {
        private static DepthPixel VoidPixel = new DepthPixel() { a = 0, z = 0 };

        protected DepthPixel[] pixels;

        public DepthBitmap()
        {
            width = 0;
            height = 0;
            pixels = new DepthPixel[0];
        }

        public DepthBitmap(int width, int height)
        {
            this.width = width;
            this.height = height;
            pixels = new DepthPixel[width * height];
        }

        public string bitmap
        {
            get
            {
                byte[] data = new byte[1 + 1 + pixels.Length * 5];

                data[0] = (byte)width;
                data[1] = (byte)height;

                int position = 2;

                for (int i = 0; i < pixels.Length; i++)
                {
                    position = pixels[i].WriteTo(data, position);
                }

                if (position != data.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return data != null ? Convert.ToBase64String(data) : null;
            }
            set
            {
                byte[] data = Convert.FromBase64String(value);

                width = data[0];
                height = data[1];

                int position = 2;

                pixels = new DepthPixel[width * height];

                for (int i = 0; i < pixels.Length; i++)
                {
                    position = pixels[i].ReadFrom(data, position);
                }

                if (position != data.Length)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Draw(DepthBitmap source, int px, int py, int pz)
        {
            for (int y = 0; y < source.height; y++)
            {
                for (int x = 0; x < source.width; x++)
                {
                    if (!IsInBox(px + x, py + y)) continue;

                    DepthPixel sourcePixel = source.pixels[Index(x, y)];
                    DepthPixel destinationPixel = pixels[Index(x + px, y + py)];

                    if (sourcePixel.a >= 0 && (pz + sourcePixel.z) <= destinationPixel.z)
                    {
                        destinationPixel.Set(sourcePixel);
                        destinationPixel.z = (byte)(pz + sourcePixel.z);
                    }
                }
            }
        }

        public DepthPixel PixelAt(int x, int y)
        {
            return IsInBox(x, y) ? pixels[Index(x, y)] : VoidPixel;
        }
    }
}
