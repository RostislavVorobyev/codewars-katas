using NUnit.Framework;

namespace Codewars.Tests
{
    [TestFixture]
    public class AddBinaryTest
    {
        [Test]
        public void TestExample()
        {
            Assert.AreEqual("11", BinaryAddition.AddBinary(1, 2));
        }
    }
}
