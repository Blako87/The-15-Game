using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace The_15_Game
{
    internal class Program
    {

        static void Main(string[] args)
        {
            const int WINNNUMBER = 15;
            List<int> availableNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> usedNumbers = new List<int>();
            List<int> player1Numbers = new List<int>();
            List<int> player2Numbers = new List<int>();
            GameUi.WelcomeMessage();
            int gridSize = GameUi.GetPlayerGridsizeInput();
            int rows = gridSize;
            int cols = rows;
            int?[,] board = new int?[rows, cols];
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            int player = 1;

            while (true)
            {
                Console.Clear();
                GameUi.DisplayBoard(board, -1, -1);
               
                GameUi.GameStatusMessage($"Player {player} please choice your cube with Arrows and press enter");
                GameUi.GameStatusMessage($"Player {player}'s turn");
                GameLogic.GetUsedNumbers(usedNumbers);
                GameLogic.GetAvailableNumbers(availableNumbers);
                (int CursorRow, int CursorColumn) = GameUi.GetBoardPositionWithArrows(board);
                int number = GameUi.GetPlayerNumberInput(usedNumbers, availableNumbers, player1Numbers, player2Numbers, player);
                bool magicNumber = GameLogic.CheckCenterGridImputNumber(gridSize, CursorRow, CursorColumn, number);
                if (magicNumber)
                {

                    GameUi.GameStatusMessage("To easy please place this number in another place!");
                    Thread.Sleep(2000);
                    continue;
                }
                bool success = GameLogic.PlaceNumber(board, CursorRow, CursorColumn, number, player, availableNumbers, usedNumbers, player1Numbers, player2Numbers);
                
                if (!success)
                {
                    Console.Clear();
                    GameUi.DisplayBoard(board, -1, -1);
                    GameUi.GameStatusMessage("Invalid Move. Try again");
                    continue;
                }
                
                Console.Clear();
                GameUi.DisplayBoard(board, -1, -1);
                if (GameLogic.CheckWin(board,WINNNUMBER))
                {

                    GameUi.GameStatusMessage("Congratulation you win!");
                    break;
                }
                if (GameLogic.IsBoardFull(board, CursorRow, CursorColumn))
                {

                    GameUi.GameStatusMessage("Its a Draw");
                    break;
                }
                
                player = player == 1 ? 2 : 1;

            }

        }

    }
}
