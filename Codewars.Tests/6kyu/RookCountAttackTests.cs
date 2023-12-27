using NUnit.Framework;

namespace Codewars.Tests
{
    internal class RookCountAttackTests
    {
        [Test]
        public void NoRooks()
        {
            int[][] rooks = new int[][] { };
            int expected = 0;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestFromImage()
        {
            int[][] rooks = new int[][] { new int[] { 2, 5 }, new int[] { 5, 3 }, new int[] { 5, 5 } };
            int expected = 2;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestFromImage2()
        {
            int[][] rooks = new int[][] { new int[] { 1, 3 }, new int[] { 1, 5 }, new int[] { 3, 5 }, new int[] { 5, 3 }, new int[] { 5, 3 } };
            int expected = 5;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRooksOnDiagonal()
        {
            int[][] rooks = new int[][] {new int[] {0, 0}, new int[] {1, 1}, new int[] {2, 2}, new int[] {3, 3},
                                     new int[] {4, 4}, new int[] {5, 5}, new int[] {6, 6}, new int[] {7, 7}};
            int expected = 0;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAttackingRooksEachOther()
        {
            int[][] rooks = new int[][] { new int[] { 1, 1 }, new int[] { 1, 6 } };
            int expected = 1;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RooksOnSameRow()
        {
            int[][] rooks = new int[][] { new int[] { 1, 1 }, new int[] { 1, 3 }, new int[] { 1, 5 }, new int[] { 1, 7 } };
            int expected = 3;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void OneAttackingRook()
        {
            int[][] rooks = new int[][] {new int[] {0, 0}, new int[] {2, 1}, new int[] {4, 2}, new int[] {6, 3},
                                     new int[] {1, 5}, new int[] {3, 6}, new int[] {5, 7}, new int[] {7, 2}};
            int expected = 1;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MultipleAttackingRooks()
        {
            int[][] rooks = new int[][] { new int[] { 0, 0 }, new int[] { 0, 4 }, new int[] { 4, 4 }, new int[] { 4, 2 }, new int[] { 4, 0 } };
            int expected = 5;
            int actual = RookCountAttack.CountAttackingRooks(rooks);
            Assert.AreEqual(expected, actual);
        }
    }
}
