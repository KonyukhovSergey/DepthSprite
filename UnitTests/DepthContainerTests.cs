using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsoPixel;

namespace UnitTests
{
    [TestClass]
    public class DepthContainerTests
    {
        private DepthContainer dc;

        [TestInitialize]
        public void SetUp()
        {
            dc = new DepthContainer();

            dc.sprites["id01"] = new DepthSprite();
            dc.sprites["id02"] = new DepthSprite(16, 16);
            dc.sprites["id03"] = new DepthSprite(32, 32);
            dc.sprites["id03"].sprites.Add(new SpritePosition() { id = "id01", x = 10, y = 10, z = 10 });
            dc.sprites["id03"].sprites.Add(new SpritePosition() { id = "id02", x = 20, y = 10, z = 10 });
        }

        [TestMethod]
        public void TestSerialization()
        {
            string text = dc.ToJsonSring();
            DepthContainer dc2 = DepthContainer.Parse(text);
            Assert.AreEqual(text, dc2.ToJsonSring());
        }
    }
}
