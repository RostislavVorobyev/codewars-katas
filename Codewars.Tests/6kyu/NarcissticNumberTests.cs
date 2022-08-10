using System.Collections.Generic;
using NUnit.Framework;

namespace Codewars.Tests
{
    [TestFixture]
    public class NarcissticNumberTests
    {
        private NarcissticNumber underTest = new NarcissticNumber();

        [SetUp]
        public void SetUp()
        {
            underTest = new NarcissticNumber();
        }

        private static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(1)
                                .Returns(true)
                                .SetDescription("1 is narcissitic");
                yield return new TestCaseData(371)
                                .Returns(true)
                                .SetDescription("371 is narcissitic");
            }
        }

        [Test, TestCaseSource("TestCases")]
        public bool Test(int n) => underTest.Narcissistic(n);

    }
}
