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

        public CommandImportSprite(Image image, string id, DepthContainer container)
        {
            this.container = container;
            this.image = image;
            this.id = id;
        }

        public CommandImportSprite(string fileName, DepthContainer container) :
            this(Image.FromFile(fileName), Path.GetFileNameWithoutExtension(fileName), container)
        {
        }

        public override bool Execute()
        {
            if (!container.ContainsKey(id))
            {
                importedSprite = new DepthSprite(image, id, container);
                return true;
            }
            return false;
        }

        public override void Cancel()
        {
            container.Remove(id);
        }
    }
}
