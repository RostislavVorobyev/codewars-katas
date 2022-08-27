using NUnit.Framework;

namespace Codewars.Tests
{
    [TestFixture]
    public class IPValidationTests
    {
        [Test]
        public void TestCases()
        {
            Assert.AreEqual(true, IPValidation.IsValid("0.0.0.0"));
            Assert.AreEqual(true, IPValidation.IsValid("12.255.56.1"));
            Assert.AreEqual(true, IPValidation.IsValid("137.255.156.100"));
        }

        [Test]
        public void IsValidShouldReturnFalseOnIncorrectImput()
        {
            Assert.AreEqual(false, IPValidation.IsValid("12.34.256.78"));
            Assert.AreEqual(false, IPValidation.IsValid("1234.34.56"));
            Assert.AreEqual(false, IPValidation.IsValid("pr12.34.56.78"));
            Assert.AreEqual(false, IPValidation.IsValid("12.34.56.78sf"));
            Assert.AreEqual(false, IPValidation.IsValid("12.34.56 .1"));
            Assert.AreEqual(false, IPValidation.IsValid("12.34.56.-1"));
            Assert.AreEqual(false, IPValidation.IsValid("123.045.067.089"));
            Assert.AreEqual(false, IPValidation.IsValid(""));
            Assert.AreEqual(false, IPValidation.IsValid("abc.def.ghi.jkl"));
            Assert.AreEqual(false, IPValidation.IsValid("123.456.789.0"));
            Assert.AreEqual(false, IPValidation.IsValid("12.34.56"));
            Assert.AreEqual(false, IPValidation.IsValid("12.34.56.00"));
            Assert.AreEqual(false, IPValidation.IsValid("12.34.56.7.8"));
        }
    }
}
