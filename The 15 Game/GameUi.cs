using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_15_Game
{
    public class GameUi
    {
        /// <summary>
        /// Welcome Messages an game intro
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the 15 game");
            Console.WriteLine("Fokus: Put 3 numbers in one line, that result 15.");
            Console.WriteLine("Every number(1-9) will be used just one time.");
            Console.WriteLine();

        }
        static void AskUserForInput()
        {
            Console.WriteLine("Please enter your Number (1 to 9)");

        }

        /// <summary>
        /// a grid for user interface 
        /// </summary>
        /// <param name="board">2d Array to display board</param>
        public static void DisplayBoard(int?[,] board, int CursorRow, int CursorColumn)
        {
            
            int rows = board.GetLength(0);
            int colums = board.GetLength(1);
            string gridlines = "+-";
            string corners = "+";
            string vLine = "|";

            for (int c = 0; c < colums; c++)
            {
                Console.Write(gridlines);
            }
            Console.WriteLine(corners);

            for (int r = 0; r < rows; r++)
            {

                Console.Write(vLine);
                for (int c = 0; c < colums; c++)
                {
                    if (board[r, c] == null)
                    {
                        Console.Write(" ");
                    }
                    if(r == CursorRow && c == CursorColumn)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write("");
                    }
                        Console.Write(board[r, c]);
                    Console.Write(vLine);

                }
                Console.WriteLine();
                for (int c = 0; c < colums; c++)
                {
                    Console.Write(gridlines);
                }
                Console.WriteLine(corners);

            }

        }
        /// <summary>
        /// User input handle
        /// </summary>
        /// <param name="usedNumbers">List from Game.Logic who already the chosen Numbers are!</param>
        /// <returns></returns>
        public static int GetPlayerNumberInput(List<int> usedNumbers)
        {

            int number = 0;
            bool userInputNumber = false;
            while (!userInputNumber)
            {
                AskUserForInput();
                Console.WriteLine($"Already used:{string.Join(",", usedNumbers)}");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out number) && number >= 1 && number <= 9)
                {
                    userInputNumber = true;
                }
                if (usedNumbers.Contains(number))
                {
                    Console.WriteLine($"{number} is Already used!");
                }
                else
                {
                    Console.WriteLine("Please enter one Number(1-9)!!\n");
                }

            }

            return number;

        }
        public static (int, int) GetBoardPositionWithArrows(int?[,] board)
        {
            int CursorRow = 0;
            int CursorColumn = 0;
            while (true)
            {
                Console.Clear();
                DisplayBoard(board, CursorRow, CursorColumn);
                ConsoleKeyInfo key = Console.ReadKey(true);
              
                if(key.Key == ConsoleKey.LeftArrow && CursorRow <= 2)
                {
                     CursorColumn--;
                }
                
                if (key.Key == ConsoleKey.RightArrow && CursorRow >= 0)
                {
                    CursorColumn++;
                }
                if(key.Key == ConsoleKey.UpArrow && CursorColumn <= 2)
                {
                    CursorRow--;
                }
                if(key.Key == ConsoleKey.DownArrow && CursorColumn >= 0)
                {
                    CursorRow++;
                }
                if(CursorColumn < 0)
                {
                    CursorColumn = 0;
                }
                if(CursorColumn > 2)
                {
                    CursorColumn = 2;
                }
                if(CursorRow < 0)
                {
                    CursorRow = 0;
                }
                if(CursorRow > 2)
                {
                    CursorRow = 2;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

            }
            
            return (CursorRow,CursorColumn);
        }
    }
}
             