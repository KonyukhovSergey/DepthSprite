using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CommandAddSubSprite : CommandBase
    {
        private DepthSprite sprite;
        private SubSprite subSprite;

        public CommandAddSubSprite(SubSprite subSprite, DepthSprite sprite)
        {
            this.sprite = sprite;
            this.subSprite = subSprite;
        }

        public override bool Execute()
        {
            if (sprite.CanAddSubSprite(subSprite.id))
            {
                sprite.subSprites.Add(subSprite);
                sprite.ClearCache();
                return true;
            }
            return false;
        }

        public override void Undo()
        {
            sprite.subSprites.Remove(subSprite);
            sprite.ClearCache();
        }

        public override string ToString()
        {
            return string.Format("AddSubSprite '{0}' to sprite '{1}'", subSprite.id, sprite.id);
        }
    }
}
