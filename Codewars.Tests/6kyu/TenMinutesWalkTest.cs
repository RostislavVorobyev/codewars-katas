using NUnit.Framework;

namespace Codewars
{ 
    [TestFixture]
    public class SolutionTest
    {

    private TenMinutesWalk underTest = new TenMinutesWalk();

        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(true, underTest.IsValidWalk(new string[] { "n", "s", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return true");
            Assert.AreEqual(false, underTest.IsValidWalk(new string[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }), "should return false");
            Assert.AreEqual(false, underTest.IsValidWalk(new string[] { "w" }), "should return false");
            Assert.AreEqual(false, underTest.IsValidWalk(new string[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return false");
        }
    }
}
