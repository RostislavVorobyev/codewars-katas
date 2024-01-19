using NUnit.Framework;

namespace Codewars.Tests
{
    public class IsKingInCheckTests
    {
        [TestFixture]
        public class SolutionTest
        {
            [Test]
            public void CheckByPawn()
            {
                char[,] test1 =
                       {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                       {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                       {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                       {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                       {' ', ' ', ' ', 'P', ' ', ' ', ' ', ' '},
                       {' ', ' ', 'K', ' ', ' ', ' ', ' ', ' '},
                       {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                       {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(true, IsKingInCheck.IsTheKingInCheck(test1));
            }

            [Test]
            public void CheckByBishop()
            {
                char[,] test2 =
                               {
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'B'},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {'K', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(true, IsKingInCheck.IsTheKingInCheck(test2));
            }

            [Test]
            public void CheckByRook()
            {
                char[,] test3 = {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', 'K', ' ', ' ', 'R', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(true, IsKingInCheck.IsTheKingInCheck(test3));
            }

            [Test]
            public void CheckByKnight()
            {
                char[,] test4 =
                               {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', 'K', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {'N', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(true, IsKingInCheck.IsTheKingInCheck(test4));
            }

            [Test]
            public void CheckByQueen()
            {
                char[,] test5 =
                               {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', 'K', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', 'Q', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(true, IsKingInCheck.IsTheKingInCheck(test5));
            }

            [Test]
            public void KingAlone()
            {
                char[,] test6 =
                               {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', 'K', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(false, IsKingInCheck.IsTheKingInCheck(test6));
            }

            [Test]
            public void KingWithPiecesNoCheck()
            {
                char[,] test7 =
                               {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {'Q', ' ', ' ', 'N', ' ', ' ', ' ', 'Q'},
                               {' ', ' ', ' ', 'K', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(false, IsKingInCheck.IsTheKingInCheck(test7));
            }

            [Test]
            public void NoCheckBecauseBlockingPiece()
            {
                char[,] test8 =
                               {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {'R', ' ', 'B', 'K', ' ', ' ', ' ', ' '},
                               {' ', ' ', 'P', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(false, IsKingInCheck.IsTheKingInCheck(test8));
            }

            [Test]
            public void NoCheckBecauseTwoBlockingPieces()
            {
                char[,] test9 =
                               {{' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', 'B', ' ', ' '},
                               {' ', ' ', ' ', ' ', 'R', ' ', ' ', ' '},
                               {'R', ' ', 'P', 'K', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(false, IsKingInCheck.IsTheKingInCheck(test9));
            }

            [Test]
            public void NoCheckBecauseFiveBlockingPieces()
            {
                char[,] test10 =
                                {{' ', ' ', ' ', ' ', ' ', ' ', 'B', 'B'},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                {' ', ' ', ' ', ' ', ' ', 'R', ' ', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', 'N', ' '},
                                {'R', ' ', 'P', 'K', ' ', 'P', 'Q', ' '},
                                {' ', ' ', ' ', ' ', 'P', ' ', ' ', ' '},
                                {' ', ' ', ' ', 'N', ' ', ' ', ' ', ' '},
                                {' ', ' ', ' ', 'Q', ' ', ' ', 'Q', ' '}};
                Assert.AreEqual(false, IsKingInCheck.IsTheKingInCheck(test10));
            }

            [Test]
            public void CheckByQueenWithBishop()
            {
                char[,] test5 =
                               {
                               {' ', 'B', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', 'K', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', 'Q', ' ', ' ', ' ', ' ', ' ', ' '},
                               {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}};
                Assert.AreEqual(true, IsKingInCheck.IsTheKingInCheck(test5));
            }
        }
    }
}
