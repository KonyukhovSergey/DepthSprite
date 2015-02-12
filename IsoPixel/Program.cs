using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsoPixel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DepthContainer dc = new DepthContainer();

            dc.sprites["id01"] = new DepthSprite();
            dc.sprites["id02"] = new DepthSprite(16, 16);
            dc.sprites["id03"] = new DepthSprite(32, 32);

            dc.sprites["id03"].sprites.Add(new SpritePosition() { id = "id01", x = 10, y = 10, z = 10 });
            dc.sprites["id03"].sprites.Add(new SpritePosition() { id = "id02", x = 20, y = 10, z = 10 });

            string bl = dc.ToJsonSring();

            DepthContainer dc2 = DepthContainer.Parse(bl);
            Application.Run(new IsoEdit());
        }
    }
}
