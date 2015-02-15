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

            dc.Add(new DepthSprite() { id = "id01" });
            dc.Add(new DepthSprite(16, 16) { id = "id02" });
            dc.Add(new DepthSprite(8, 8) { id = "id03" });
            dc["id03"].sprites.Add(new SpritePosition() { id = "id01", x = 10, y = 10, z = 10 });
            dc["id03"].sprites.Add(new SpritePosition() { id = "id02", x = 20, y = 10, z = 10 });
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
