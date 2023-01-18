namespace Codewars.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ConwayLookAndSayTests
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData(0ul).Returns(10ul).SetDescription("Input: 0ul\n      Expected: 10ul");
                yield return new TestCaseData(2014ul).Returns(12101114ul).SetDescription("Input: 2014ul\n      Expected: 12101114ul");
                yield return new TestCaseData(1122ul).Returns(2122ul).SetDescription("Input: 1122ul\n      Expected: 2122ul");
                yield return new TestCaseData(22322ul).Returns(221322ul).SetDescription("Input: 22322ul\n      Expected: 221322ul");
            }
        }

        [Test, TestCaseSource("testCases")]
        public ulong Test(ulong number) =>
          ConwayLookAndSay.LookSay(number);
    }
}
