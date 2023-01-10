using NUnit.Framework;

namespace Codewars.Tests
{
    [TestFixture]
    public class DigitalRootTests
    {
        [Test]
        public void Tests()
        {
            Assert.AreEqual(7, DigitalRoot.Calculate(16));
            Assert.AreEqual(6, DigitalRoot.Calculate(456));
        }
    }
}
