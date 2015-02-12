using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public struct DepthPixel
    {
        public byte r, g, b, a;
        public int z;

        public int ReadFrom(byte[] data, int position)
        {
            r = data[position++];
            g = data[position++];
            b = data[position++];
            a = data[position++];
            z = data[position++] - 100;
            return position;
        }

        public int WriteTo(byte[] data, int position)
        {
            data[position++] = r;
            data[position++] = g;
            data[position++] = b;
            data[position++] = a;
            data[position++] = (byte)(z + 100);
            return position;
        }

        public void Set(int r, int g, int b, int a, int z)
        {
            this.r = (byte)r;
            this.g = (byte)g;
            this.b = (byte)b;
            this.a = (byte)a;
            this.z = z;
        }

        public void Set(DepthPixel dp)
        {
            r = dp.r;
            g = dp.g;
            b = dp.b;
            a = dp.a;
            z = dp.z;
        }

        public Color GetColor()
        {
            return Color.FromArgb(a, r, g, b);
        }
    }
}
