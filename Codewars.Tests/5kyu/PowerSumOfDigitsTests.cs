using Codewars;
using NUnit.Framework;

namespace CodewarsTests1
{
    [TestFixture]
    public class PowerSumOfDigitsTests
    {
        private PowerSumOfDigits underTest = new PowerSumOfDigits();

        [Test]
        public void PowerSumDigTermShouldReturnCorrectAnswerForValidParameters()
        {
            //Assert.AreEqual(81, underTest.PowerSumDigTerm(1));
            //Assert.AreEqual(512, underTest.PowerSumDigTerm(2));
            Assert.AreEqual(2401, underTest.PowerSumDigTerm(3));
            //Assert.AreEqual(4913, underTest.PowerSumDigTerm(4));
        }
    }
}
