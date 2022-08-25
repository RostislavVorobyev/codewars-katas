using NUnit.Framework;

namespace Codewars.Tests
{
    [TestFixture]
    public class ScrambliesTests
    {
        [Test]
        public static void ScrabliesReturnCorrectRestultWhenNonNullStringsPassed()
        {
            Assert.AreEqual(true, Scramblies.Scramble("rkqodlw", "world"));
            Assert.AreEqual(true, Scramblies.Scramble("cedewaraaossoqqyt", "codewars"));
            Assert.AreEqual(true, Scramblies.Scramble("katas", "steak"));
            Assert.AreEqual(true, Scramblies.Scramble("scriptjavx", "javascript"));
            Assert.AreEqual(true, Scramblies.Scramble("scriptingjava", "javascript"));
            Assert.AreEqual(true, Scramblies.Scramble("scriptsjava", "javascripts"));
            Assert.AreEqual(true, Scramblies.Scramble("javscripts", "javascript"));
            Assert.AreEqual(true, Scramblies.Scramble("aabbcamaomsccdd", "commas"));
        }
    }
}
