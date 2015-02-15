using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel
{
    public class CursorPosition : PixelPosition
    {
        public bool ControlKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up: y++; return true;
                case Keys.Down: y--; return true;
                case Keys.Left: x--; return true;
                case Keys.Right: x++; return true;
                case Keys.PageUp: z++; return true;
                case Keys.PageDown: z--; return true;
            }
            return false;
        }

    }
}
