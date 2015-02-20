using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CommandSetColor : CommandBase
    {
        private DepthSprite sprite;
        private int x, y;
        private int color, prevColor;

        public CommandSetColor(int x, int y, int color, DepthSprite sprite)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.sprite = sprite;
        }

        public override bool Execute()
        {
            if (sprite.IsInRect(x, y))
            {
                prevColor = sprite.GetPixel(x, y);
                sprite.SetPixel(x, y, color);
                sprite.ClearCache();
                return true;
            }
            return false;
        }

        public override void Undo()
        {
            sprite.SetPixel(x, y, prevColor);
            sprite.ClearCache();
        }

        public override string ToString()
        {
            return string.Format("SetPixel for '{0}' at ({1}, {2}) with '{3}'", sprite.id, x, y, Color.FromArgb(color).ToString());
        }
    }
}
