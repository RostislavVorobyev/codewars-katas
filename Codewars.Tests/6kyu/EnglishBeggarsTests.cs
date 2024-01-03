using NUnit.Framework;

namespace Codewars.Tests
{
    public class EnglishBeggarsTests
    {
        [Test]
        public void FixedTest()
        {
            // Basic tests
            int[] test = { 1, 2, 3, 4, 5 };
            int[] a1 = { 15 }, a2 = { 9, 6 }, a3 = { 5, 7, 3 }, a4 = { 1, 2, 3, 4, 5, 0 }, a5 = { };
            Assert.AreEqual(a1, EnglishBeggars.Beggars(test, 1));
            Assert.AreEqual(a2, EnglishBeggars.Beggars(test, 2));
            Assert.AreEqual(a3, EnglishBeggars.Beggars(test, 3));
            Assert.AreEqual(a4, EnglishBeggars.Beggars(test, 6));
            Assert.AreEqual(a5, EnglishBeggars.Beggars(test, 0));
        }
    }
}
