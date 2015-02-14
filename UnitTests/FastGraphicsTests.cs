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
    }
}
