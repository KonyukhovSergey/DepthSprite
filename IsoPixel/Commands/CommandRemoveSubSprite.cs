using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CommandRemoveSubSprite : CommandBase
    {
        private DepthSprite sprite;
        private SubSprite subSprite;

        public CommandRemoveSubSprite(SubSprite subSprite, DepthSprite sprite)
        {
            this.sprite = sprite;
            this.subSprite = subSprite;
        }

        public override bool Execute()
        {
            if (sprite.subSprites.Contains(subSprite))
            {
                sprite.subSprites.Remove(subSprite);
                sprite.ClearCache();
                return true;
            }
            return false;
        }

        public override void Undo()
        {
            sprite.subSprites.Add(subSprite);
            sprite.ClearCache();
        }

        public override string ToString()
        {
            return string.Format("RemoveSubSprite '{0}' from sprite '{1}'", subSprite.id, sprite.id);
        }
    }
}
