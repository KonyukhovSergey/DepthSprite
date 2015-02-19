using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;
using System.Drawing;


namespace UnitTests
{
    [TestClass]
    public class FastGraphicsTests
    {
        [TestMethod]
        public void TestSetGet()
        {
            FastGraphics fg = new FastGraphics(3, 3);

            fg.Graphics.Clear(Color.Red);
            Assert.AreEqual(Color.Red.ToArgb(), fg.GetPixel(0, 0));
            Assert.AreEqual(Color.Red.ToArgb(), fg.GetPixel(2, 2));

            fg.Bitmap.SetPixel(1, 1, Color.Green);
            Assert.AreEqual(Color.Green.ToArgb(), fg.GetPixel(1, 1));

            fg.SetPixel(2, 0, Color.Blue.ToArgb());
            Assert.AreEqual(Color.Blue.ToArgb(), fg.Bitmap.GetPixel(2, 0).ToArgb());

            Assert.AreEqual(9, fg.Data.Length);
        }

        [TestMethod]
        public void FastGraphicsInit()
        {
            FastGraphics fg = new FastGraphics(1, 1);
            fg.SetPixel(0, 0, Color.Red);
            Assert.AreEqual(Color.Red.ToArgb(), fg.Bitmap.GetPixel(0, 0).ToArgb());

            FastGraphics fg2 = new FastGraphics(fg.Bitmap);
            Assert.AreEqual(Color.Red.ToArgb(), fg.Bitmap.GetPixel(0, 0).ToArgb());
        }

        [TestMethod]
        public void TestSerialization()
        {
            FastGraphics fg = new FastGraphics(32, 32);
            fg.Graphics.Clear(Color.Red);
            fg.Bitmap.SetPixel(1, 1, Color.Green);
            fg.SetPixel(2, 0, Color.Blue.ToArgb());

            FastGraphics fg2 = new FastGraphics();
            fg2.base64_image_data = fg.base64_image_data;

            Assert.AreEqual(fg.Data.Length, fg2.Data.Length);
            Assert.AreEqual(fg.base64_image_data, fg2.base64_image_data);
        }
    }
}
