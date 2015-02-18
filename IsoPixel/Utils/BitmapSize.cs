using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class BitmapSize
    {
        protected int width, height;


        protected int Index(int x, int y)
        {
            return x + y * width;
        }

        protected int GetX(int index)
        {
            return index % width;
        }

        protected int GetY(int index)
        {
            return index / width;
        }

        public int Width { get { return width; } }
        public int Height { get { return height; } }
    
    }
}
