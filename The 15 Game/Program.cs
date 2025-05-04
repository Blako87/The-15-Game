using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_15_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameUi.WelcomeMessage();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            int player = 1;

            while (true)
            {
                Console.Clear();
                GameUi.DisplayBoard(GameLogic.board, -1, -1);

                GameUi.GameStatusMessage($"Player {player}'s turn");
                List<int> usedNumbers = GameLogic.usedNumbers;
                List<int> availableNumbers = GameLogic.GetAvailableNumbers();
                (int CursorRow, int CursorColumn) = GameUi.GetBoardPositionWithArrows(GameLogic.board);
                int number = GameUi.GetPlayerNumberInput(usedNumbers, availableNumbers);
                bool success = GameLogic.PlaceNumber(CursorRow, CursorColumn, number, player);

                if (!success)
                {
                    Console.Clear();
                    GameUi.DisplayBoard(GameLogic.board, -1, -1);
                    GameUi.GameStatusMessage("Invalid Move. Try again");
                    continue;
                }

                Console.Clear();
                GameUi.DisplayBoard(GameLogic.board, -1, -1);
                if (GameLogic.CheckWin(3, 3))
                {

                    GameUi.GameStatusMessage("Congratulation you win!");
                    break;
                }
                if (GameLogic.IsBoardFull(3, 3))
                {

                    GameUi.GameStatusMessage("Its a Draw");
                    break;
                }
                player = player == 1 ? 2 : 1;

            }

        }

    }
}
