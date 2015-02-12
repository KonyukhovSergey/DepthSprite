using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class Cube
    {
        private int size;
        private byte[] tiles;
        private CoordinateCalculator cc;

        public Cube(int size, CoordinateCalculator cc)
        {
            this.size = size;
            this.cc = cc;
            tiles = new byte[(size * 2 + 1) * (size * 2 + 1) * (size * 2 + 1)];
        }

        public byte Get(int x, int y, int z)
        {
            if (x > -size && x <= size && y > -size && y <= size && z > -size && z <= size)
            {
                return tiles[GetIndex(x, y, z)];
            }
            return 0;
        }

        public void Set(int x, int y, int z, byte tile)
        {
            if (x > -size && x <= size && y > -size && y <= size && z > -size && z <= size)
            {
                tiles[GetIndex(x, y, z)] = tile;
            }
        }

        private int GetIndex(int x, int y, int z)
        {
            int s = size * 2 + 1;
            return (z + size) * s * s + (y + size) * s + x + size;
        }

        public void DrawTo(Sprite sprite, FastBitmap[] bitmaps)
        {
            sprite.Clear(Color.White, int.MaxValue);

            int tileIndex = 0;

            for (int z = -size; z <= size; z++)
            {
                for (int y = -size; y <= size; y++)
                {
                    for (int x = -size; x <= size; x++)
                    {
                        int sx = cc.sx(x, y);
                        int sy = cc.sy(x, y, z);
                        int sz = cc.sz(x, y);

                        int tile = tiles[tileIndex];
                        tileIndex++;

                        if (tile > 0)
                        {
                            FastBitmap fb = bitmaps[tile - 1];
                            sprite.Draw(fb, sx - fb.Width / 2, sy - fb.Height, sz);
                        }
                    }
                }
            }
        }
    }
}
