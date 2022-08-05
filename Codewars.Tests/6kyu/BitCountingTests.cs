using NUnit.Framework;

namespace Codewars.Tests
{
    [TestFixture]
    public class BitCountingTests
    {

        private BitCounting _bitCounting;

        [SetUp]
        public void SetUp()
        {
            _bitCounting = new BitCounting();
        }

        [Test]
        public void CountBits()
        {
            Assert.AreEqual(0, _bitCounting.CountBits(0));
            Assert.AreEqual(1, _bitCounting.CountBits(4));
            Assert.AreEqual(3, _bitCounting.CountBits(7));
            Assert.AreEqual(2, _bitCounting.CountBits(9));
            Assert.AreEqual(2, _bitCounting.CountBits(10));
        }

    }
}