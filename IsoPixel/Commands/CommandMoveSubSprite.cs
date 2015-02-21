using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CommandMoveSubSprite : CommandBase
    {
        private int x, y, z, px, py, pz;
        private DepthSprite sprite;
        private SubSprite subSprite;

        public CommandMoveSubSprite(DepthSprite sprite, SubSprite subSprite, int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            this.sprite = sprite;
            this.subSprite = subSprite;
        }

        public override bool Execute()
        {
            px = subSprite.x;
            py = subSprite.y;
            pz = subSprite.z;

            subSprite.MoveTo(x, y, z);
            sprite.ClearCache();

            return true;
        }

        public override void Cancel()
        {
            subSprite.MoveTo(px, py, pz);
            sprite.ClearCache();
        }

        public override string ToString()
        {
            return "MoveSubSprite";
        }
    }
}
