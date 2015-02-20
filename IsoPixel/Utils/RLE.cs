using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public static class RLE
    {
        public static byte[] Encode(byte[] data)
        {
            MemoryStream dest = new MemoryStream();
            byte runLength;

            for (int i = 0; i < data.Length; i++)
            {
                runLength = 1;
                while (runLength < byte.MaxValue
                    && i + 1 < data.Length
                    && data[i] == data[i + 1])
                {
                    runLength++;
                    i++;
                }
                dest.WriteByte(runLength);
                dest.WriteByte(data[i]);
            }

            return dest.ToArray();
        }

        public static byte[] Decode(byte[] data)
        {
            MemoryStream dest = new MemoryStream();
            byte runLength;

            for (int i = 1; i < data.Length; i += 2)
            {
                runLength = data[i - 1];

                while (runLength > 0)
                {
                    dest.WriteByte(data[i]);
                    runLength--;
                }
            }
            return dest.ToArray();
        }
    }
}
