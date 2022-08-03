using NUnit.Framework;
using System.Collections.Generic;

namespace Codewars.Tests
{
    [TestFixture]
    public class CamelCaseBreakerTests
    {
        private CamelCaseBreaker _camelCaseBreaker;

        [SetUp]
        public void SetUp()
        {
            _camelCaseBreaker = new CamelCaseBreaker();
        }

        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("camelCasing").Returns("camel Casing");
                yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
            }
        }

        [Test, TestCaseSource("testCases")]
        public string Test(string str) => _camelCaseBreaker.BreakCamelCase(str);
    }
}