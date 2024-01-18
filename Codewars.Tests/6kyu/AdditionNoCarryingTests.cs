using NUnit.Framework;

namespace Codewars.Tests._6kyu
{
    [TestFixture]
    public class AdditionNoCarryingTests
    {

        [Test]
        public void BasicTests()
        {
            var kata = new AdditionNoCarrying();

            Assert.AreEqual(1180, kata.AdditionWithoutCarrying(456, 1734), "");

            Assert.AreEqual(99999, kata.AdditionWithoutCarrying(99999, 0), "");

            Assert.AreEqual(888, kata.AdditionWithoutCarrying(999, 999), "");

            Assert.AreEqual(0, kata.AdditionWithoutCarrying(0, 0), "");
        }
    }
}
