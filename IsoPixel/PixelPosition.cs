using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class PixelPosition
    {
        public int x, y, z;

        public string Info()
        {
            return string.Format("x={0}, y={1}, z={2}", x, y, z);
        }
    }
}
