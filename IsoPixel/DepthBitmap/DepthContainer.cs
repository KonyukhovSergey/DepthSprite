using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IsoPixel
{
    public class DepthContainer
    {
        public IDictionary<string, DepthSprite> sprites = new Dictionary<string, DepthSprite>();

        public static DepthContainer Parse(string json)
        {
            var ser = new JavaScriptSerializer();
            ser.MaxJsonLength = Int32.MaxValue;
            return ser.Deserialize<DepthContainer>(json);
        }

        public string ToJsonSring()
        {
            return JsonStringFormatter.FormatOutput(new JavaScriptSerializer().Serialize(this));
        }

        public void ClearCacheFor(string id)
        {
            sprites[id].ClearCache();

            foreach (var spriteId in sprites.Keys)
            {
                foreach (var spritePosition in sprites[spriteId].sprites)
                {
                    if (spritePosition.id.Equals(id))
                    {
                        ClearCacheFor(spriteId);
                    }
                }
            }
        }
    }
}
