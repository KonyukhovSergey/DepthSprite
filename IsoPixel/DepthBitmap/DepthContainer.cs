using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IsoPixel
{
    public class DepthContainer : List<DepthSprite>
    {
        public static DepthContainer Parse(string json)
        {
            var ser = new JavaScriptSerializer();
            ser.MaxJsonLength = Int32.MaxValue;
            var dictionary = ser.Deserialize<List<DepthSprite>>(json);
            return new DepthContainer(dictionary);

        }

        public DepthContainer() : base() { }

        public DepthContainer(List<DepthSprite> dictionary) : base(dictionary) { }

        public string ToJsonSring()
        {
            return JsonStringFormatter.FormatOutput(new JavaScriptSerializer().Serialize(this));
        }

        public DepthSprite this[string id]
        {
            get
            {
                return this.FirstOrDefault(e => e.id == id); ;
            }
        }

        public void ClearCacheFor(string id)
        {
            this[id].ClearCache();

            foreach (var sprite in this)
            {
                foreach (var spritePosition in sprite.sprites)
                {
                    if (spritePosition.id.Equals(id))
                    {
                        ClearCacheFor(sprite.id);
                    }
                }
            }
        }
    }
}
