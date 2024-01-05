using System.Linq;
using NUnit.Framework;

namespace Codewars.Tests
{
    [TestFixture]

    public class TwoSumTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(new[] { 0, 2 }, TwoSum.FindTwoSum(new[] { 1, 2, 3 }, 4).OrderBy(a => a).ToArray());
            Assert.AreEqual(new[] { 1, 2 }, TwoSum.FindTwoSum(new[] { 1234, 5678, 9012 }, 14690).OrderBy(a => a).ToArray());
            Assert.AreEqual(new[] { 0, 1 }, TwoSum.FindTwoSum(new[] { 2, 2, 3 }, 4).OrderBy(a => a).ToArray());
        }
    }
}
