using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class CommandRemoveSubSpriteTests
    {
        [TestMethod]
        public void TestCommandRemoveSubSprite()
        {
            DepthContainer dc = new DepthContainer();

            new DepthSprite(4, 4, "id01", dc);
            new DepthSprite(8, 4, "id02", dc);
            dc["id02"].subSprites.Add(new SubSprite("id01", 0, 0, 0));

            CommandBase command = new CommandRemoveSubSprite(dc["id02"].subSprites[0], dc["id02"]);

            Assert.IsTrue(command.Execute());
            Assert.AreEqual(0, dc["id02"].subSprites.Count);

            command.Undo();
            Assert.AreEqual("id01", dc["id02"].subSprites[0].id);

            CommandBase commandFail = new CommandRemoveSubSprite(new SubSprite("id01", 10, 0, 0), dc["id02"]);
            Assert.IsFalse(commandFail.Execute());

            Assert.AreEqual("RemoveSubSprite 'id01' from sprite 'id02'", command.ToString());
        }
    }
}
