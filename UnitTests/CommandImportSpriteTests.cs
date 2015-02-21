using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class CommandImportSpriteTests
    {
        [TestMethod]
        public void TestCommandImportSprite()
        {
            DepthContainer dc = new DepthContainer();
            FastGraphics fg = new FastGraphics(1, 1);
            fg.SetPixel(0, 0, 32);

            CommandBase command = new CommandImportSprite(fg.Bitmap, "dot", dc);

            Assert.IsTrue(command.Execute());
            Assert.IsNotNull(dc["dot"]);

            command.Cancel();
            Assert.IsFalse(dc.ContainsKey("dot"));

            Assert.IsTrue(command.Execute());
            Assert.IsFalse(command.Execute());
        }
    }
}
