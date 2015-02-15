using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CoordinateCalculator
    {
        private int a, b, c;
        private int cx,cy;

        public CoordinateCalculator(int width, int height, int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            cx = width / 2;
            cy = height;
        }

        public int sx(int x, int y)
        {
            return a * (x - y) + cx;
        }

        public int sy(int x, int y, int z)
        {
            return cy - (b * (x + y) + c * z);
        }

        public int sz(int x, int y)
        {
            return x + y;
        }
    }
}
