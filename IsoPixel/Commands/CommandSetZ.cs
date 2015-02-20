using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CommandSetZ : CommandBase
    {
        private DepthSprite sprite;
        private int x, y;
        private int zValue, prevZValue;

        public CommandSetZ(int x, int y, int value, DepthSprite sprite)
        {
            this.x = x;
            this.y = y;
            this.zValue = value;
            this.sprite = sprite;
        }

        public override bool Execute()
        {
            if (sprite.IsInRect(x, y))
            {
                prevZValue = sprite.GetZ(x, y);
                sprite.SetZ(x, y, zValue);
                sprite.ClearCache();
                return true;
            }
            return false;
        }

        public override void Undo()
        {
            sprite.SetZ(x, y, prevZValue);
            sprite.ClearCache();
        }

        public override string ToString()
        {
            return string.Format("SetZ for '{0}' at ({1}, {2}) with '{3}'", sprite.id, x, y, zValue);
        }
    }
}
