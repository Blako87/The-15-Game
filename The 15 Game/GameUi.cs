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
        public static void GameStatusMessage(string message)
        {
            
            Console.WriteLine(message);
            Console.WriteLine();
        }
        static void AskUserForInput()
        {
            Console.WriteLine("Please enter your Number ");

        }
        static void AskUserForGridInput()
        {
            Console.WriteLine("Please enter the size of the grid (odd!)");
            Console.WriteLine("like 3x3 !");
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
                   
                    if(r == CursorRow && c == CursorColumn)
                    {
                        Console.Write("x");
                    }
                    else if (board[r,c] != null)
                    {
                        Console.Write(board[r,c]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                        
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
        public static int GetPlayerGridsizeInput()
        {
           
            int sizeNumber = 0;
           
            bool userInputSizeNumber = false;
            while (!userInputSizeNumber)
            {
                AskUserForGridInput();
                string userSizeinput = Console.ReadLine();
                if (! int.TryParse(userSizeinput,out sizeNumber))
                {
                    Console.WriteLine("please enter a valid number:3,4 etc....");
                    continue;
                }
                if (sizeNumber== 1 || sizeNumber ==2)
                {
                    Console.WriteLine("Minimum Gridsize 3x3");
                    continue;
                }
                if (sizeNumber % 2 == 0)
                {
                    Console.WriteLine("Gridsize musst be odd not Even!");
                    continue;
                }
                userInputSizeNumber = true;
            }
            return sizeNumber;
        }
        /// <summary>
        /// User input handle
        /// </summary>
        /// <param name="usedNumbers">List from Game.Logic who already the chosen Numbers are!</param>
        /// <returns></returns>
        public static int GetPlayerNumberInput(List<int> usedNumbers, List<int> availableNumbers,List<int> player1Numbers,List<int>player2Numbers,int player)
        {

            int number = 0;
            bool userInputNumber = false;
            while (!userInputNumber)
            {
                AskUserForInput();
                if (player ==1)
                {
                    Console.WriteLine($"Player1 used:{string.Join(",", player1Numbers)}");
                }
                else
                {
                    Console.WriteLine($"Player2 used:{string.Join(",", player2Numbers)}");
                }
                    
                Console.WriteLine($"Available Numbers :{string.Join(",", availableNumbers)}");
                Console.WriteLine("Enter your Choice Number");
                string userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out number))
                {
                    Console.WriteLine("Please enter one Number(1-9)!!");
                    continue;
                    
                }
                if (number < 1 || number >9)
                {
                    Console.WriteLine("only Numbers from 1 to 9 allowed!");
                    continue;
                }
                if (!availableNumbers.Contains(number))
                {
                    Console.WriteLine($"{number} is Already used or not availible!");
                    continue;
                }
                userInputNumber = true;

            }

            return number;

        }
        /// <summary>
        /// Get user position from Arrows
        /// </summary>
        /// <param name="board">Gameboard that the user cann see</param>
        /// <returns></returns>
        public static (int, int) GetBoardPositionWithArrows(int?[,] board)
        {
            int CursorRow = 0;
            int CursorColumn = 0;
            while (true)
            {
                Console.SetCursorPosition(0,0);
                DisplayBoard(board, CursorRow, CursorColumn);
                ConsoleKeyInfo key = Console.ReadKey(true);
              
                if(key.Key == ConsoleKey.LeftArrow && CursorColumn > 0)
                {
                     CursorColumn--;
                }
                
                if (key.Key == ConsoleKey.RightArrow && CursorColumn <board.GetLength(1))
                {
                    CursorColumn++;
                }
                if(key.Key == ConsoleKey.UpArrow && CursorRow >0)
                {
                    CursorRow--;
                }
                if(key.Key == ConsoleKey.DownArrow && CursorRow <board.GetLength(1))
                {
                    CursorRow++;
                }
                if(CursorColumn < 0)
                {
                    CursorColumn = 0;
                }
                if(CursorColumn >= board.GetLength(1))
                {
                    CursorColumn = board.GetLength(1) -1;
                }
                if(CursorRow < 0)
                {
                    CursorRow = 0;
                }
                if(CursorRow >= board.GetLength(1))
                {
                    CursorRow = board.GetLength(1)-1;
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
             