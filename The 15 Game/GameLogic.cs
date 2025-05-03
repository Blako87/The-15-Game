using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace The_15_Game
{

    public class GameLogic
    {
        public static List<int> availableNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static List<int> usedNumbers = new List<int>();
        public static List<int> playerChosenNumbers = new List<int>();
        public static int?[,] board = new int?[3, 3];
        public static List<int> GetAvailableNumbers()
        {
            List<int> result = new List<int>();
            foreach (int number in availableNumbers)
            {
                if (!usedNumbers.Contains(number))
                {
                    result.Add(number);
                }

            }
            return result;
        }
        public static bool PlaceNumber(int row, int col, int number, int player)
        {
            bool success = false;

            if (board[row, col] == null && !usedNumbers.Contains(number))
            {
                success = true;
                board[row, col] = number;
                usedNumbers.Add(number);
                playerChosenNumbers.Add(number);
                Console.WriteLine(board[row, col]);
            }
            else
            {
                success = false;
            }
            return success;
        }
        public static bool CheckWin()
        {
            bool win = false;
            int row = 3;
            int col = 3;
            int winSum = 15;
            int sum = 0;
            // vertical winings
            for (int r = 0; r < row; r++)
            {
                sum = 0;
                for (int c = 0; c < col; c++)
                {
                    if (board[r, c] != null)
                    {
                        sum += (int)board[r, c];
                        if (winSum == sum)
                        {
                            win = true;
                        }

                    }
                }

            }
            // Horizontal winnings
            for (int c = 0; c < col; c++)
            {
                for (int r = 0; r < row; r++)
                {
                    if (board[r, c] != null)
                    {
                        sum += (int)board[r, c];
                        if (winSum == sum)
                        {
                            win = true;
                        }

                    }
                }

            }
            // diagonal winings Left top to right Bottom
            for (int r = 0; r < row; r++)
            {
                if (board[r, r] != null)
                {
                    sum += (int)board[r, r];
                    if (winSum == sum)
                    {
                        win = true;
                    }

                }

            }
            // diagonal winnings from Bottom left to the right top
            for (int r = 0; r < row; r++)
            {
                int colIndex = row - 1 - r;
                if (board[r, r ] != null)
                {
                    sum += (int)board[r, colIndex];
                    if (winSum == sum)
                    {
                        win = true;
                    }

                }
            }

            return win;
        }
        public static bool IsBoardFull(int rows , int cols)
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (board[r,c] == null)
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
