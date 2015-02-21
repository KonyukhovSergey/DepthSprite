using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class CommandAddSubSpriteTests
    {
        [TestMethod]
        public void TestCommandAddSubSprite()
        {
            DepthContainer dc = new DepthContainer();

            new DepthSprite(4, 4, "id01", dc);
            new DepthSprite(8, 4, "id02", dc);

            CommandBase command = new CommandAddSubSprite(new SubSprite("id01", 0, 0, 0), dc["id02"]);

            Assert.IsTrue(command.Execute());
            Assert.AreEqual("id01", dc["id02"].subSprites[0].id);

            command.Cancel();
            Assert.AreEqual(0, dc["id02"].subSprites.Count);

            CommandBase commandFail = new CommandAddSubSprite(new SubSprite("id01", 0, 0, 0), dc["id01"]);
            Assert.IsFalse(commandFail.Execute());

            Assert.AreEqual("AddSubSprite 'id01' to sprite 'id02'", command.ToString());
        }
    }
}
