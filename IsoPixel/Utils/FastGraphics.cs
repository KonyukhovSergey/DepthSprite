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

        public Graphics Graphics
        {
            get
            {
                Unlock();
                return gr;
            }
        }

        public Bitmap Bitmap
        {
            get
            {
                Unlock();
                return bmp;
            }
        }

        public void Set(int color, int x, int y)
        {
            Lock();
            data[x + y * stride] = color;
        }

        public int Get(int x, int y)
        {
            Lock();
            return data[x + y * stride];
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
