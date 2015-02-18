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

            //dc.Add(new DepthSprite(4, 4) { id = "id01" });
            //dc.Add(new DepthSprite(16, 16) { id = "id02" });
            //dc.Add(new DepthSprite(8, 8) { id = "id03" });
            dc["id01"] = new DepthSprite(4, 4, dc);
            dc["id02"] = new DepthSprite(16, 16, dc);
            dc["id03"] = new DepthSprite(8, 8, dc);
            dc["id03"].subSprites.Add(new SubSprite("id01", 10, 10, 10));
            dc["id03"].subSprites.Add(new SubSprite("id02", 20, 10, 10));
        }

        [TestMethod]
        public void TestSerialization()
        {
            string text = dc.ToJsonSring();
            DepthContainer dc2 = DepthContainer.Parse(text);
            Assert.AreEqual(text, dc2.ToJsonSring());
        }

        [TestMethod]
        public void TestCanAddSubSprite()
        {
            Assert.IsTrue(dc["id01"].CanAddToSprite("id02"));
            Assert.IsFalse(dc["id01"].CanAddToSprite("id01"));

            Assert.IsFalse(dc["id01"].CanAddToSprite("id03"));
            Assert.IsFalse(dc["id31"].CanAddToSprite("id01"));
        }
    }
}
