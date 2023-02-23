using NUnit.Framework;
using System;
using static Codewars.CodewarsRankingSystem;

namespace Codewars.Tests
{
    [TestFixture]
    public class CodewarsRankingSystemTests
    {
        // Assert correct rank progression
        public void AssertRankProgression(int rank, User user, int expRank, int expProgress)
        {
            Assert.True(user.Rank == expRank,
              "Applied Rank: " + rank +
              "; Expected rank: " + expRank +
              "; Actual: " + user.Rank);

            Assert.True(user.Progress == expProgress,
              "Applied Rank; " + rank +
              "; Expected progress: " + expProgress +
              ", Actual: " + user.Progress);
        }

        [TestCase(-7, -8, 10)]
        [TestCase(-6, -8, 40)]
        [TestCase(-5, -8, 90)]
        [TestCase(-4, -7, 60)]
        [TestCase(-8, -8, 3)]
        // Check single increments
        public void TestValidSingleRankProgression(int rank, int expectedRank, int expectedProgress)
        {
            User user = new User();

            user.incProgress(rank);

            AssertRankProgression(rank, user, expectedRank, expectedProgress);
        }

        [TestCase(1, -2, 40)]
        public void TestValidMultipleRankProgression(int rank, int expectedRank, int expectedProgress)
        {
            User user = new User();

            user.incProgress(rank);

            AssertRankProgression(rank, user, expectedRank, expectedProgress);
        }

        [TestCase(9)]
        [TestCase(-9)]
        [TestCase(0)]
        // Check invalid rank progressions
        public void TestInvalidRange(int rank)
        {
            User user = new User();
            Assert.Throws<ArgumentException>(() => user.incProgress(rank));
        }
    }
}
