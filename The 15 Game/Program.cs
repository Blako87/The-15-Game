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
            int?[,] board = GameLogic.board;
            (int CursorRow, int CursorColumn) = GameUi.GetBoardPositionWithArrows(board);
            List<int> usedNumbers = GameLogic.usedNumbers;
            int number = GameUi.GetPlayerNumberInput(usedNumbers);
            int player = 1;
            bool success = GameLogic.PlaceNumber(CursorRow, CursorColumn, number, player);
            GameLogic.CheckWin();
            GameLogic.IsBoardFull(3, 3);
            Console.WriteLine(CursorRow);
            Console.WriteLine(CursorColumn);
            GameLogic.GetAvailableNumbers();
           
           
            
           
                                   
            

           
        }

    }
}
