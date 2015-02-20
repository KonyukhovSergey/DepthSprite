using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;
using System.Drawing;
using IsoPixel.Commands;

namespace UnitTests
{
    [TestClass]
    public class CommandMoveSubSpriteTests
    {
        [TestMethod]
        public void TestCommandMoveSubSprite()
        {
            DepthContainer dc = new DepthContainer();
            DepthSprite ds1 = new DepthSprite(1, 1, "ds1", dc);
            ds1.SetPixel(0, 0, Color.Red);

            DepthSprite ds2 = new DepthSprite(2, 1, "ds2", dc);
            ds2.SetPixel(0, 0, Color.Green);
            ds2.SetPixel(1, 0, Color.Blue);

            SubSprite ss = new SubSprite("ds1", 0, 0, 0);
            ds2.subSprites.Add(ss);

            CommandBase command = new CommandMoveSubSprite(ds2, ss, 1, 0, 0);

            Assert.IsTrue(command.Execute());
            Assert.AreEqual(Color.Green.ToArgb(), ds2.Bitmap.GetPixel(0, 0).ToArgb());
            Assert.AreEqual(Color.Red.ToArgb(), ds2.Bitmap.GetPixel(1, 0).ToArgb());

            command.Undo();
            Assert.AreEqual(Color.Red.ToArgb(), ds2.Bitmap.GetPixel(0, 0).ToArgb());
            Assert.AreEqual(Color.Blue.ToArgb(), ds2.Bitmap.GetPixel(1, 0).ToArgb());
        }
    }
}
