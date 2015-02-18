using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace IsoPixel
{
    public class DepthSprite : DepthBitmap
    {
        public IList<SubSprite> subSprites = new List<SubSprite>();

        private DepthBitmap cache;
        private DepthContainer container;

        public void ClearCache()
        {
            cache = null;

            foreach (var kvp in container)
            {
                foreach (var subSprite in kvp.Value.subSprites)
                {
                    if (subSprite.id.Equals(kvp.Key))
                    {
                        container[subSprite.id].ClearCache();
                    }
                }
            }
        }

        public bool CanAddToSprite(string id)
        {
            if (container[id] == this)
            {
                return false;
            }

            foreach (var subSprite in container[id].subSprites)
            {
                if (!container[subSprite.id].CanAddSubSprite(id))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CanAddSubSprite(string id)
        {
            if (container[id] == this)
            {
                return false;
            }

            foreach (var subSprite in container[id].subSprites)
            {
                if (!container[subSprite.id].CanAddSubSprite(id))
                {
                    return false;
                }
            }

            return true;
        }

        public DepthSprite() { }

        public DepthSprite(int width, int height, DepthContainer container)
            : base(width, height)
        {
            this.container = container;
            Clear(0, 0, 0, 0, 0);
        }

        public DepthSprite(Image image, DepthContainer container)
            : base(image)
        {
            this.container = container;
        }

        private void Update()
        {
            if (cache == null)
            {
                cache = new DepthBitmap(Width, Height);
                cache.Draw(this, 0, 0, 0);

                foreach (var item in subSprites)
                {
                    container[item.id].Update();
                    cache.Draw(container[item.id].cache, item.x, item.y, item.z);
                }
            }
        }

        [ScriptIgnore]
        public override Bitmap Bitmap
        {
            get
            {
                Update();
                return base.Bitmap;
            }
        }

        public void SetContainer(DepthContainer container)
        {
            this.container = container;
        }

    }
}
