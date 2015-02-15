using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace IsoPixel
{
    public class FastGraphics
    {
        private Graphics gr;
        private Bitmap bmp;

        private BitmapData bd;

        private int[] data;
        private int stride;

        public FastGraphics(int width, int height)
        {
            bmp = new Bitmap(width, height);
            gr = Graphics.FromImage(bmp);
        }

        public FastGraphics(Image source)
            : this(source.Width, source.Height)
        {
            Graphics.DrawImage(source, 0, 0);
        }

        public Graphics Graphics { get { Unlock(); return gr; } }

        public Bitmap Bitmap { get { Unlock(); return bmp; } }

        public int[] Data { get { Lock(); return data; } }

        public int Width { get { return bmp.Width; } }

        public int Height { get { return bmp.Height; } }

        public void SetPixel(int x, int y, int color)
        {
            Lock();
            data[x + y * stride] = color;
        }

        public int GetPixel(int x, int y)
        {
            Lock();
            return data[x + y * stride];
        }

        public Color GetColor(int x, int y)
        {
            return Color.FromArgb(GetPixel(x, y));
        }

        public void SetPixel(int x, int y, Color color)
        {
            SetPixel(x, y, color.ToArgb());
        }

        private void Lock()
        {
            if (bd == null)
            {
                bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                if (data == null)
                {
                    stride = bd.Stride / 4;
                    data = new int[bd.Height * stride];
                }

                Marshal.Copy(bd.Scan0, data, 0, data.Length);
            }
        }

        private void Unlock()
        {
            if (bd != null)
            {
                Marshal.Copy(data, 0, bd.Scan0, data.Length);
                bmp.UnlockBits(bd);
                bd = null;
            }
        }
    }
}
