using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace The_15_Game
{

    public class GameLogic
    {

        public static List<int> Player1Numbers(List<int> player1Numbers)
        {
            return new List<int>(player1Numbers);
        }
        public static List<int> Player2Numbers(List<int> player2Numbers)
        {
            return new List<int>(player2Numbers);
        }
        public static List<int> GetUsedNumbers(List<int> usedNumbers)
        {
            return new List<int>(usedNumbers);
        }
        /// <summary>
        /// Printing on console the numbers from the AvailableList
        /// </summary>
        /// <returns></returns>
        public static List<int> GetAvailableNumbers(List<int> availableNumbers)
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
        public static bool PlaceNumber(int?[,] board, int row, int col, int number, int player, List<int> availableNumbers, List<int> usedNumbers, List<int> player1Numbers, List<int> player2Numbers)
        {


            if (board[row, col] != null || usedNumbers.Contains(number))
            {
                return false;

            }

            board[row, col] = number;
            usedNumbers.Add(number);
            availableNumbers.Remove(number);


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
        /// check center grid imput
        /// </summary>
        /// <param name="board"></param>
        /// <param name="gridSize">d</param>
        /// <param name="CursorRow">d</param>
        /// <param name="CursorColum">d</param>
        /// <returns></returns>
        public static bool CheckCenterGridImputNumber(int gridSize, int CursorRow, int CursorColum, int number)
        {

            int centerGrid = gridSize / 2;
            int magicNumber = 5;

            if (centerGrid == CursorRow && centerGrid == CursorColum && magicNumber == number)
            {
                return true;
            }

            return false;
        }
        public static (int row, int col, int number) GetKiMove(int?[,] board, int winNumber, List<int> availableNumbers)
        {
            var winMove = KiCanYouWin(board,availableNumbers,winNumber);
            if (winMove != null)
            {
                return winMove.Value;
            }
            return GetRandomMove(board,availableNumbers);
            
        }
        private static (int row, int col, int missingNumber)? KiCanYouWin(int?[,] board, List<int> availableNumbers, int gameWinNumber)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);

            int missingNumber = 0;
            //checking Rows
            for (int r = 0; r < row; r++)
            {
                int sumNumbers = 0;
                int nullRow = -1;
                int nullCol = -1;
                int nullCounter = 0;
                for (int c = 0; c < col; c++)
                {
                    if (board[r, c] == null)
                    {
                        nullCounter++;
                        nullRow = r;
                        nullCol = c;

                    }
                    else
                    {
                        sumNumbers += (int)board[r, c];
                    }

                }
                if (nullCounter == 1)
                {
                    missingNumber = gameWinNumber - sumNumbers;
                    if (availableNumbers.Contains(missingNumber))
                    {
                        return (nullRow, nullCol, missingNumber);
                    }
                }
            }
            //Checking Cols

            for (int c = 0; c < col; c++)
            {
                int sumNumbers = 0;
                int nullRow = -1;
                int nullCol = -1;
                int nullCounter = 0;
                for (int r = 0; r < row; r++)
                {
                    if (board[r, c] == null)
                    {
                        nullCounter++;
                        nullRow = r;
                        nullCol = c;

                    }
                    else
                    {
                        sumNumbers += (int)board[r, c];
                    }

                }
                if (nullCounter == 1)
                {
                    missingNumber = gameWinNumber - sumNumbers;
                    if (availableNumbers.Contains(missingNumber))
                    {
                        return (nullRow, nullCol, missingNumber);
                    }
                }
            }
            //check diagonals left top to bottom
            for (int i = 0; i < row; i++)
            {
                int sumNumbers = 0;
                int nullRow = -1;
                int nullCol = -1;
                int nullCounter = 0;

                if (board[i, i] == null)
                {
                    nullCounter++;
                    nullRow = i;
                    nullCol = i;

                }
                else
                {
                    sumNumbers += (int)board[i, i];
                }

                if (nullCounter == 1)
                {
                    missingNumber = gameWinNumber - sumNumbers;
                    if (availableNumbers.Contains(missingNumber))
                    {
                        return (nullRow, nullCol, missingNumber);
                    }
                }
            }
            for (int i = 0; i < row; i++)
            {
                int sumNumbers = 0;
                int nullRow = -1;
                int nullCol = -1;
                int nullCounter = 0;
                int j = col - 1 - i;
                if (board[i, j] == null)
                {
                    nullCounter++;
                    nullRow = i;
                    nullCol = j;

                }
                else
                {
                    sumNumbers += (int)board[i, j];
                }

                if (nullCounter == 1)
                {
                    missingNumber = gameWinNumber - sumNumbers;
                    if (availableNumbers.Contains(missingNumber))
                    {
                        return (nullRow, nullCol, missingNumber);
                    }
                }
            }
            return null;
        }
       
        private static (int row, int col, int number) GetRandomMove(int?[,] board, List<int> availableNumbers)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            List<(int row, int col)> emptyCells = new List<(int, int)>();
            Random random = new Random();
           
            for (int r = 0; r < row; r++)
            {

                for (int c = 0; c < col; c++)
                {
                    if (board[r, c] == null)
                    {
                        emptyCells.Add((r, c));

                    }


                }

            }
            var (emptyRow, emptyCol) = emptyCells[random.Next(emptyCells.Count)];
            int chossenNumber = availableNumbers[random.Next(availableNumbers.Count)];
            return (emptyRow, emptyCol, chossenNumber);
        }

        /// <summary>
        /// Winning if the case is "15"
        /// </summary>
        /// <param name="row">Rows</param>
        /// <param name="col">Colums</param>
        /// <returns></returns>
        public static bool CheckWin(int?[,] board, int winNumber)
        {
            int row = board.GetLength(0);
            int col = board.GetLength(1);
            int winSum = winNumber;
            int sum = 0;
            //  Check all rows
            for (int r = 0; r < row; r++)
            {

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
                {
                    return true;
                }

            }

            // Check all columns
            for (int c = 0; c < col; c++)
            {

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
                {
                    return true;
                }

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
            {
                return true;
            }


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
            {
                return true;
            }


            // No win found
            return false;
        }
        /// <summary>
        /// Reprezenting a Draw
        /// </summary>
        /// <param name="rows">Rows</param>
        /// <param name="cols">Columns</param>
        /// <returns></returns>
        public static bool IsBoardFull(int?[,] board, int rows, int cols)
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
