using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public class SudokuBoardValidator
    {
        public static bool Validate(int[][] board)
        {
            for (int x = 0; x < board.Length; x++)
            {
                var col = GetColumn(board, x);

                if (col.Any(x => x == 0) || col.Distinct().Count() != col.Count())
                {
                    return false;
                }

                var row = GetRow(board, x);

                if (row.Any(x => x== 0) || row.Distinct().Count() != row.Count())
                {
                    return false;
                }

                if (x % 3 == 0)
                {
                    for (int j = 0; j < 9; j+=3)
                    {
                        var square = GetSquare(board, x, j);

                        if (square.Any(x => x == 0) || square.Distinct().Count() != square.Count())
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static IEnumerable<int> GetColumn(int[][] board, int i)
        {
            return Enumerable.Range(0, board.Length).Select(x => board[x][i]);
        }

        private static IEnumerable<int> GetRow(int[][] board, int i)
        {
            return Enumerable.Range(0, board.Length).Select(x => board[i][x]);
        }

        private static IEnumerable<int> GetSquare(int[][] board, int i, int j)
        {
            var a = j + 3;
            return  Enumerable.Range(i, 3).Select(x => board[x][j..a]).SelectMany(x => x);

        }
    }
}
