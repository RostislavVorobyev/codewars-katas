/*
 * Tic-Tac-Toe Checker: https://www.codewars.com/kata/525caa5c1bf619d28c000335
 */

namespace Codewars
{
    public class TicTacToe
    {
        public int IsSolved(int[,] board)
        {
            if (IsPlayerWon(1, board)) { return 1; };
            if (IsPlayerWon(2, board)) { return 2; };
            if (IsDraw(board)) { return 0; };

            return -1;
        }

        private bool IsDraw(int[,] board)
        {
            foreach (var cell in board)
            {
                if (cell == 0) { return false; }
            }

            return true;
        }

        private bool IsPlayerWon(int player, int[,] board)
        {
            if ((int)board.GetValue(0, 0) == player && (int)board.GetValue(0, 1) == player && (int)board.GetValue(0, 2) == player) { return true; }
            if ((int)board.GetValue(1, 0) == player && (int)board.GetValue(1, 1) == player && (int)board.GetValue(1, 2) == player) { return true; }
            if ((int)board.GetValue(2, 0) == player && (int)board.GetValue(2, 1) == player && (int)board.GetValue(2, 2) == player) { return true; }

            if ((int)board.GetValue(0, 0) == player && (int)board.GetValue(1, 0) == player && (int)board.GetValue(2, 0) == player) { return true; }
            if ((int)board.GetValue(0, 1) == player && (int)board.GetValue(1, 1) == player && (int)board.GetValue(2, 1) == player) { return true; }
            if ((int)board.GetValue(0, 2) == player && (int)board.GetValue(1, 2) == player && (int)board.GetValue(2, 2) == player) { return true; }

            if ((int)board.GetValue(0, 0) == player && (int)board.GetValue(1, 1) == player && (int)board.GetValue(2, 2) == player) { return true; }
            if ((int)board.GetValue(0, 2) == player && (int)board.GetValue(1, 1) == player && (int)board.GetValue(2, 0) == player) { return true; }

            return false;
        }
    }
}
