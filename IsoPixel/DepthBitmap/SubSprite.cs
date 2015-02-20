using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class SubSprite
    {
        public string id;
        public int x, y, z;

        public SubSprite() { }

        public SubSprite(string id, int x, int y, int z)
        {
            this.id = id;
            MoveTo(x, y, z);
        }

        public void MoveTo(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
