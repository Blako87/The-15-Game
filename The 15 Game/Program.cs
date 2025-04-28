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
            int?[,] board = new int?[3, 3];
            (int CursorRow, int CursorColumn) = GameUi.GetBoardPositionWithArrows(board);
                                   
            

           
        }

    }
}
