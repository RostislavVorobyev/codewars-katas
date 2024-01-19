using System;
using System.Linq;

namespace Codewars
{
    public class IsKingInCheck
    {
        private const char King = 'K';
        private const char Pawn = 'P';
        private const char Rook = 'R';
        private const char Queen = 'Q';
        private const char Bishop = 'B';
        private const char Knight = 'N';

        public static bool IsTheKingInCheck(char[,] chessboard)
        {
            var kingPosition = GetKingPosition(chessboard);
            var y = kingPosition.Item2;
            var x = kingPosition.Item1;

            return IsCheckedOnHorizontal(chessboard, y, x)
                || IsCheckedOnDiagonal(chessboard, y, x)
                || IsCheckedByPawn(chessboard, y, x)
                || IsCheckedByKnight(chessboard, y, x);
        }

        private static bool IsCheckedOnHorizontal(char[,] chessboard, int y, int x)
        {
            var horAttackers = new char[] { Rook, Queen };
            return IsAttackingInDirection(chessboard, y, x, 0, 1, horAttackers)
                || IsAttackingInDirection(chessboard, y, x, 0, -1, horAttackers)
                || IsAttackingInDirection(chessboard, y, x, 1, 0, horAttackers)
                || IsAttackingInDirection(chessboard, y, x, -1, 0, horAttackers);
        }

        private static bool IsCheckedOnDiagonal(char[,] chessboard, int y, int x)
        {
            var dAttackers = new char[] { Bishop, Queen };

            return IsAttackingInDirection(chessboard, y, x, 1, 1, dAttackers) ||
                   IsAttackingInDirection(chessboard, y, x, 1, -1, dAttackers) ||
                   IsAttackingInDirection(chessboard, y, x, -1, 1, dAttackers) ||
                   IsAttackingInDirection(chessboard, y, x, -1, -1, dAttackers);
        }

        private static bool IsCheckedByPawn(char[,] chessboard, int y, int x)
        {
            return (y - 1 > 0 && x + 1 < 8 && chessboard[y - 1, x + 1] == Pawn) || (x - 1 > 0 && chessboard[y - 1, x - 1] == Pawn);
        }

        private static bool IsCheckedByKnight(char[,] chessboard, int y, int x)
        {
            return
                (y - 2 >= 0 && x - 1 >= 0 && chessboard[y - 2, x - 1] is Knight) ||
                (y - 1 >= 0 && x - 2 >= 0 && chessboard[y - 1, x - 2] is Knight) ||
                (y - 2 >= 0 && x + 1 < 8 && chessboard[y - 2, x + 1] is Knight) ||
                (y - 1 >= 0 && x + 2 < 8 && chessboard[y - 1, x + 2] is Knight) ||
                (y + 1 < 8 && x - 2 >= 0 && chessboard[y + 1, x - 2] is Knight) ||
                (y + 2 < 8 && x - 1 >= 0 && chessboard[y + 2, x - 1] is Knight) ||
                (y + 2 < 8 && x + 1 < 8 && chessboard[y + 2, x + 1] is Knight) ||
                (y + 1 < 8 && x + 2 < 8 && chessboard[y + 1, x + 2] is Knight);
        }

        private static bool IsAttackingInDirection(char[,] chessboard, int startRow, int startCol, int rowIncrement, int colIncrement, char[] attackers)
        {
            for (int i = startRow + rowIncrement, j = startCol + colIncrement; i >= 0 && i < 8 && j >= 0 && j < 8; i += rowIncrement, j += colIncrement)
            {
                var cell = chessboard[i, j];

                if (attackers.Any(x => x == cell))
                {
                    return true;
                }

                if (cell is not ' ')
                {
                    return false;
                }
            }

            return false;
        }

        private static (int, int) GetKingPosition(char[,] chessboard)
        {
            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 8; x++)
                {
                    var cell = chessboard[y, x];

                    if (chessboard[y, x] == King)
                        return (x, y);
                }
            }

            throw new Exception("No king on board.");
        }
    }
}
