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
        private BitmapList list;
        private SubSprite subSprite;

        public CommandAddSubSprite(SubSprite subSprite, DepthSprite sprite, BitmapList list)
        {
            this.sprite = sprite;
            this.subSprite = subSprite;
            this.list = list;
        }

        public override bool Execute()
        {
            if (sprite == null || subSprite == null)
            {
                return false;
            }

            if (sprite.CanAddSubSprite(subSprite.id))
            {
                sprite.subSprites.Add(subSprite);
                sprite.ClearCache();
                list.AddId(subSprite.id);
                return true;
            }
            return false;
        }

        public override void Cancel()
        {
            sprite.subSprites.Remove(subSprite);
            sprite.ClearCache();
            list.RemoveId(subSprite.id);
        }

        public override string ToString()
        {
            return string.Format("AddSubSprite '{0}' to sprite '{1}'", subSprite.id, sprite.id);
        }
    }
}
