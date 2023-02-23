using NUnit.Framework;

namespace Codewars.Tests
{
    public class ArrayDiffTests
    {
        [TestFixture]
        public class SolutionTest
        {
            [Test]
            public void SampleTest()
            {
                Assert.AreEqual(new int[] { 2 }, ArrayDiff.Find(new int[] { 1, 2 }, new int[] { 1 }));
                Assert.AreEqual(new int[] { 2, 2 }, ArrayDiff.Find(new int[] { 1, 2, 2 }, new int[] { 1 }));
                Assert.AreEqual(new int[] { 1 }, ArrayDiff.Find(new int[] { 1, 2, 2 }, new int[] { 2 }));
                Assert.AreEqual(new int[] { 1, 2, 2 }, ArrayDiff.Find(new int[] { 1, 2, 2 }, new int[] { }));
                Assert.AreEqual(new int[] { }, ArrayDiff.Find(new int[] { }, new int[] { 1, 2 }));
                Assert.AreEqual(new int[] { 3 }, ArrayDiff.Find(new int[] { 1, 2, 3 }, new int[] { 1, 2 }));
            }
        }
    }
}
