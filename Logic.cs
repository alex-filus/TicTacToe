using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Logic
    {

        public const int COLUMNS = 3;
        public const int ROWS = 3;

        public static string[,] grid =
          {
                { " ", " ", " " },
                { " ", " ", " " },
                { " ", " ", " " }
            };
        public static void PrintGrid(string[,] grid)
        {
            for (int i = 0; i < ROWS; i++)
            {
                Console.WriteLine(" --- --- ---", Color.Green);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Console.Write("| " + grid[i, j] + " ", Color.Red);
                }

                Console.WriteLine("|", Color.Red);

            }

            Console.WriteLine(" --- --- ---", Color.Green);
        }






    }
}

