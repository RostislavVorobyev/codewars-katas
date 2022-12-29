using NUnit.Framework;
using System.Collections.Generic;

namespace Codewars.Tests
{
    [TestFixture]
    public class UniqueNumberTests
    {
        [TestCase(new[] { 1, 2, 2, 2 }, ExpectedResult = 1)]
        [TestCase(new[] { -2, 2, 2, 2 }, ExpectedResult = -2)]
        [TestCase(new[] { 11, 11, 14, 11, 11 }, ExpectedResult = 14)]
        public int BaseTest(IEnumerable<int> numbers)
        {
            return UniqueNumber.GetUnique(numbers);
        }
    }
}
