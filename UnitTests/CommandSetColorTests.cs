using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class CommandSetColorTests
    {
        [TestMethod]
        public void TestCommandSetColor()
        {
            DepthSprite ds = new DepthSprite(1, 1, "sprite", new DepthContainer());
            ds.SetPixel(0, 0, 32);

            CommandBase command = new CommandSetColor(0, 0, 16, ds);

            Assert.IsTrue(command.Execute());
            Assert.AreEqual(16, ds.GetPixel(0, 0));

            command.Undo();
            Assert.AreEqual(32, ds.GetPixel(0, 0));

            CommandBase commandFail = new CommandSetColor(10, 0, 0, ds);
            Assert.IsFalse(commandFail.Execute());

            Assert.AreEqual("SetPixel for 'sprite' at (0, 0) with 'Color [A=0, R=0, G=0, B=16]'", command.ToString());
        }
    }
}
