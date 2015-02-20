using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class CommandSetZTests
    {
        [TestMethod]
        public void TestCommandSetZ()
        {
            DepthSprite ds = new DepthSprite(2, 2, "sprite", new DepthContainer());
            ds.SetZ(0, 0, 1);

            CommandBase command = new CommandSetZ(0, 0, 2, ds);

            command.Execute();
            Assert.AreEqual(2, ds.GetZ(0, 0));

            command.Undo();
            Assert.AreEqual(1, ds.GetZ(0, 0));

            CommandBase commandFail = new CommandSetZ(10, 0, 0, ds);
            Assert.IsFalse(commandFail.Execute());

            Assert.AreEqual("SetZ for 'sprite' at (0, 0) with '2'", command.ToString());
        }
    }
}
