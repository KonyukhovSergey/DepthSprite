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

            dc.Add(new DepthSprite(4, 4, "id01", dc));
            dc.Add(new DepthSprite(16, 16, "id02", dc));
            dc.Add(new DepthSprite(8, 8, "id03", dc));
            dc["id03"].subSprites.Add(new SubSprite("id01", 10, 10, 10));
            dc["id03"].subSprites.Add(new SubSprite("id02", 20, 10, 10));
            dc.Add(new DepthSprite(1, 1, "id04", dc));
            dc.Add(new DepthSprite(1, 1, "id05", dc));
            dc["id05"].subSprites.Add(new SubSprite("id04", 0, 0, 0));
            dc["id04"].subSprites.Add(new SubSprite("id01", 0, 0, 0));
            dc["id04"].subSprites.Add(new SubSprite("id03", 1, 1, 1));
        }

        [TestMethod]
        public void TestSerialization()
        {
            string text = dc.ToJsonSring();
            DepthContainer dc2 = DepthContainer.Parse(text);
            Assert.AreEqual(text, dc2.ToJsonSring());
        }

        [TestMethod]
        public void TestCanAddSpriteToSprite()
        {
            Assert.IsTrue(dc.CanAddSpriteToSprite("id01", "id02"));
            Assert.IsFalse(dc.CanAddSpriteToSprite("id01", "id01"));
            Assert.IsTrue(dc.CanAddSpriteToSprite("id01", "id03"));
            Assert.IsFalse(dc.CanAddSpriteToSprite("id03", "id01"));
            Assert.IsFalse(dc.CanAddSpriteToSprite("id04", "id01"));
            Assert.IsFalse(dc.CanAddSpriteToSprite("id04", "id02"));
            Assert.IsFalse(dc.CanAddSpriteToSprite("id04", "id03"));
            Assert.IsTrue(dc.CanAddSpriteToSprite("id02", "id05"));
            Assert.IsFalse(dc.CanAddSpriteToSprite("id05", "id02"));
        }

        [TestMethod]
        public void TestCanAddToSprite()
        {
            Assert.IsTrue(dc["id01"].CanAddToSprite("id02"));
            Assert.IsFalse(dc["id01"].CanAddToSprite("id01"));
            Assert.IsTrue(dc["id01"].CanAddToSprite("id03"));
            Assert.IsFalse(dc["id03"].CanAddToSprite("id01"));
            Assert.IsFalse(dc["id04"].CanAddToSprite("id01"));
            Assert.IsFalse(dc["id04"].CanAddToSprite("id02"));
            Assert.IsFalse(dc["id04"].CanAddToSprite("id03"));
            Assert.IsTrue(dc["id02"].CanAddToSprite("id05"));
            Assert.IsFalse(dc["id05"].CanAddToSprite("id02"));
        }
    }
}
