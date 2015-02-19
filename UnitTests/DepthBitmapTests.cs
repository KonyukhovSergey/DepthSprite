using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;
using System.Drawing;

namespace UnitTests
{
    [TestClass]
    public class DepthBitmapTests
    {
        DepthContainer dc;

        [TestInitialize]
        public void SetUp()
        {
            dc = new DepthContainer();

            FastGraphics fg1 = new FastGraphics(1, 1);
            fg1.SetPixel(0, 0, Color.Red);

            FastGraphics fg2 = new FastGraphics(2, 1);
            fg2.SetPixel(0, 0, Color.Green);
            fg2.SetPixel(1, 0, Color.Blue);

            dc.Add(new DepthSprite(fg1.Bitmap, "ds1", dc));
            dc.Add(new DepthSprite(fg2.Bitmap, "ds2", dc));

            dc.Add(new DepthSprite(fg2.Bitmap, "ds3", dc));
            dc["ds3"].subSprites.Add(new SubSprite("ds1", 0, 0, 0));
        }

        [TestMethod]
        public void TestCacheDraw()
        {
            Assert.AreEqual(Color.Red.ToArgb(), dc["ds1"].Bitmap.GetPixel(0, 0).ToArgb());

            Assert.AreEqual(Color.Green.ToArgb(), dc["ds2"].Bitmap.GetPixel(0, 0).ToArgb());
            Assert.AreEqual(Color.Blue.ToArgb(), dc["ds2"].Bitmap.GetPixel(1, 0).ToArgb());

            Assert.AreEqual(Color.Red.ToArgb(), dc["ds3"].Bitmap.GetPixel(0, 0).ToArgb());
            Assert.AreEqual(Color.Blue.ToArgb(), dc["ds3"].Bitmap.GetPixel(1, 0).ToArgb());
        }

        [TestMethod]
        public void MoveSubSprite()
        {
            Assert.AreEqual(Color.Red.ToArgb(), dc["ds3"].Bitmap.GetPixel(0, 0).ToArgb());

            dc["ds3"].subSprites[0].z = 1;
            dc["ds3"].ClearCache();

            Assert.AreEqual(Color.Green.ToArgb(), dc["ds3"].Bitmap.GetPixel(0, 0).ToArgb());
            Assert.AreEqual(Color.Blue.ToArgb(), dc["ds3"].Bitmap.GetPixel(1, 0).ToArgb());
        }

        [TestMethod]
        public void BackgroundTransparency()
        {
            FastGraphics fg = new FastGraphics(2, 1);
            fg.SetPixel(0, 0, Color.Yellow);
            fg.SetPixel(1, 0, Color.FromArgb(0, 0, 0, 0));
            dc.Add(new DepthSprite(fg.Bitmap, "ds4", dc));
            dc["ds4"].subSprites.Add(new SubSprite("ds2", 0, 0, 1));

            Assert.AreEqual(Color.Yellow.ToArgb(), dc["ds4"].Bitmap.GetPixel(0, 0).ToArgb());
            Assert.AreEqual(Color.Blue.ToArgb(), dc["ds4"].Bitmap.GetPixel(1, 0).ToArgb());            
        }

        [TestMethod]
        public void DepthSpriteInit()
        {
            FastGraphics fg = new FastGraphics(1, 1);
            fg.SetPixel(0, 0, Color.Red);

            DepthBitmap depthBitmap = new DepthBitmap(fg.Bitmap);
            Assert.AreEqual(Color.Red.ToArgb(), depthBitmap.GetColor(0, 0).ToArgb());
        }
    }
}
