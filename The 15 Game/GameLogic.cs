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

        public static List<int> player1Numbers = new List<int>();
        public static List<int> player2Numbers = new List<int>();

        public static int?[,] board = new int?[3, 3];
        /// <summary>
        /// Printing on console the numbers from the AvailableList
        /// </summary>
        /// <returns></returns>
        public static List<int> GetAvailableNumbers()
        {                                  
            return new List<int>(availableNumbers);
        }
        /// <summary>
        /// The user cann place in the Board his choice Numbers
        /// </summary>
        /// <param name="row">Rows</param>
        /// <param name="col">Columns</param>
        /// <param name="number">Player input</param>
        /// <param name="player">Wich player is Aktualy</param>
        /// <returns></returns>
        public static bool PlaceNumber(int row, int col, int number, int player)
        {


            if (board[row, col] != null || usedNumbers.Contains(number))
            {
                return false;

            }

            board[row, col] = number;
            usedNumbers.Add(number);
            availableNumbers.Remove(number);    
            Console.WriteLine(board[row, col]);

            if (player == 1)
            {
                player1Numbers.Add(number);
            }
            else
            {
                player2Numbers.Add(number);
            }

            return true;
        }
        /// <summary>
        /// Winning if the case is "15"
        /// </summary>
        /// <param name="row">Rows</param>
        /// <param name="col">Colums</param>
        /// <returns></returns>
        public static bool CheckWin(int row, int col)
        {
            int winSum = 15;

            //  Check all rows
            for (int r = 0; r < row; r++)
            {
                int sum = 0;
                bool allFilled = true;

                for (int c = 0; c < col; c++)
                {
                    if (board[r, c] == null)
                    {
                        allFilled = false;
                        break;
                    }

                    sum += (int)board[r, c];
                }

                if (allFilled && sum == winSum)
                    return true;
            }

            // Check all columns
            for (int c = 0; c < col; c++)
            {
                int sum = 0;
                bool allFilled = true;

                for (int r = 0; r < row; r++)
                {
                    if (board[r, c] == null)
                    {
                        allFilled = false;
                        break;
                    }

                    sum += (int)board[r, c];
                }

                if (allFilled && sum == winSum)
                    return true;
            }

            //  Diagonal: top-left to bottom-right
            int diagSum1 = 0;
            bool diagFilled1 = true;
            for (int i = 0; i < row; i++)
            {
                if (board[i, i] == null)
                {
                    diagFilled1 = false;
                    break;
                }

                diagSum1 += (int)board[i, i];
            }

            if (diagFilled1 && diagSum1 == winSum)
                return true;

            //  Diagonal: top-right to bottom-left
            int diagSum2 = 0;
            bool diagFilled2 = true;
            for (int i = 0; i < row; i++)
            {
                int j = col - 1 - i;
                if (board[i, j] == null)
                {
                    diagFilled2 = false;
                    break;
                }

                diagSum2 += (int)board[i, j];
            }

            if (diagFilled2 && diagSum2 == winSum)
                return true;

            // No win found
            return false;
        }
        /// <summary>
        /// Reprezenting a Draw
        /// </summary>
        /// <param name="rows">Rows</param>
        /// <param name="cols">Columns</param>
        /// <returns></returns>
        public static bool IsBoardFull(int rows, int cols)
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[r, c] == null)
                    {
                        return false;
                    }
                }

            }
            return true;
        }
    }
}
