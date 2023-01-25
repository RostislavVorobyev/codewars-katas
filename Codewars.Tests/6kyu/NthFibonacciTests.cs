using NUnit.Framework;
using System.Collections.Generic;

namespace Codewars.Tests
{
    [TestFixture]
    public class NthFibonacciTests
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData(1).Returns(0);
                yield return new TestCaseData(2).Returns(1);
                yield return new TestCaseData(3).Returns(1);
                yield return new TestCaseData(4).Returns(2);
                yield return new TestCaseData(5).Returns(3);
                yield return new TestCaseData(6).Returns(5);
                yield return new TestCaseData(7).Returns(8);
                yield return new TestCaseData(8).Returns(13);
                yield return new TestCaseData(9).Returns(21);
                yield return new TestCaseData(10).Returns(24);
                yield return new TestCaseData(11).Returns(55);
                yield return new TestCaseData(12).Returns(89);
                yield return new TestCaseData(13).Returns(144);
                yield return new TestCaseData(14).Returns(233);
                yield return new TestCaseData(15).Returns(377);
                yield return new TestCaseData(16).Returns(610);
                yield return new TestCaseData(17).Returns(987);
                yield return new TestCaseData(18).Returns(1597);
                yield return new TestCaseData(19).Returns(2584);
                yield return new TestCaseData(20).Returns(4181);
                yield return new TestCaseData(21).Returns(6765);
                yield return new TestCaseData(22).Returns(10946);
                yield return new TestCaseData(23).Returns(17711);
                yield return new TestCaseData(24).Returns(28657);
                yield return new TestCaseData(25).Returns(46368);
            }
        }

        [Test, TestCaseSource("testCases")]
        public int Test(int n)
        {
            return NthFibonacci.NthFib(n);
        }
    }
}
