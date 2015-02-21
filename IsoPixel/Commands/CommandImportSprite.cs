using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoPixel
{
    public class CommandImportSprite : CommandBase
    {
        private DepthContainer container;
        private Image image;
        private string id;
        private DepthSprite importedSprite;
        private BitmapList list;

        public CommandImportSprite(Image image, string id, DepthContainer container, BitmapList list)
        {
            this.container = container;
            this.image = image;
            this.id = id;
            this.list = list;
        }

        public CommandImportSprite(string fileName, DepthContainer container, BitmapList list) :
            this(Image.FromFile(fileName), Path.GetFileNameWithoutExtension(fileName), container, list)
        {
        }

        public override bool Execute()
        {
            if (!container.ContainsKey(id))
            {
                importedSprite = new DepthSprite(image, id, container);
                list.AddId(id);
                return true;
            }
            return false;
        }

        public override void Cancel()
        {
            container.Remove(id);
            list.RemoveId(id);
        }
    }
}
