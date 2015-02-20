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

        [ScriptIgnore]
        public string id { get; private set; }

        private DepthBitmap cache;

        [ScriptIgnore]
        public DepthContainer container { get; private set; }

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

        public DepthSprite() { }

        public DepthSprite(int width, int height, string id, DepthContainer container)
            : base(width, height)
        {
            this.container = container;
            this.id = id;
            container[id] = this;
            Clear(0, 0, 0, 0, 0);
        }


        public bool CanAddToSprite(string id)
        {
            if (id.Equals(this.id))
            {
                return false;
            }

            foreach (var subSprite in subSprites)
            {
                if (!container[subSprite.id].CanAddToSprite(id))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CanAddSubSprite(string subSpriteId)
        {
            return container.CanAddSpriteToSprite(subSpriteId, id);
        }

        public DepthSprite(Image image, string id, DepthContainer container)
            : base(image)
        {
            container[id] = this;
            this.container = container;
            this.id = id;
        }

        private void Update()
        {
            if (cache == null)
            {
                cache = new DepthBitmap(Width, Height);
                cache.Draw(this, 0, 0, 0);

                foreach (var subSprite in subSprites)
                {
                    container[subSprite.id].Update();
                    cache.Draw(container[subSprite.id].cache, subSprite.x, subSprite.y, subSprite.z);
                }
            }
        }

        [ScriptIgnore]
        public override Bitmap Bitmap
        {
            get
            {
                Update();
                return cache.Bitmap;
            }
        }

        public void SetContainerAndId(DepthContainer container, string id)
        {
            this.container = container;
            this.id = id;
        }

    }
}
