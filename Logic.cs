using System;
using System.Collections.Generic;
using System.Data.Common;
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

        //Computer placing a symbol
        public static void ComputerTurn()
        {           
            Console.WriteLine("Computer's turn....");
            Thread.Sleep(3000);
            Console.WriteLine();

            Random random = new Random();

            int randomColumn;
            int randomRow;

            // generate a random spot only if not taken
            do
            {
                randomRow = random.Next(0, 3);
                randomColumn = random.Next(0, 3);
            }

            while (Logic.grid[randomRow, randomColumn] != " ");

            Logic.grid[randomRow, randomColumn] = UI.computerSymbol;
            Logic.PrintGrid(Logic.grid);
            Console.WriteLine();
        }

        // Ask user to choose a spot
        public static void UserTurn()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Where would you like to place the {UI.symbolChoice}?");
                Console.WriteLine("Which column? Type 0, 1 or 2.");
                string columnChoice = Console.ReadLine();
                Console.WriteLine("Which row? Type 0, 1 or 2.");
                string rowChoice = Console.ReadLine();
                int row;
                int column;

                if (int.TryParse(columnChoice, out column) && int.TryParse(rowChoice, out row))
                {
                    if (row >= 0 && row < 3 && column >= 0 && column < 3)
                    {
                        if (grid[row, column] == " ")
                        {
                            grid[row, column] = UI.symbolChoice;
                            PrintGrid(grid);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Spot taken! Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid spot. Try again.");
                    }
                }
            }
        }

        public static bool NotFull()
        {
            {
                for (int row = 0; row < Logic.ROWS; row++)
                {
                    for (int col = 0; col < Logic.COLUMNS; col++)
                    {
                        if (Logic.grid[row, col] == " ")
                            return true;
                    }
                }
                return false;
            }
        }

    }
}

