using System;
using System.Drawing;
using Console = Colorful.Console;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SYMBOL_CHOICE_O = "O";
            const string SYMBOL_CHOICE_X = "X";
            string columnChoice = "0";
            string rowChoice = "0";

            Console.WriteLine("Welcome to Tic-Tac-Toe! Let's play!");
            Console.WriteLine();
            Console.WriteLine("What symbol would you like to be? \nPress O or X.");
            string symbolChoice = Console.ReadLine()?.ToUpper();

            while (symbolChoice != SYMBOL_CHOICE_O && symbolChoice != SYMBOL_CHOICE_X)
            {
                Console.WriteLine("Incorrect input. Please try again.");
                symbolChoice = Console.ReadLine()?.ToUpper();
            }

            //grid printout
            Logic.PrintGrid(Logic.grid);
            Console.WriteLine();


            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Where would you like to place the {symbolChoice}?");
                Console.WriteLine("Which column? Type 0, 1 or 2.");
                columnChoice = Console.ReadLine();
                Console.WriteLine("Which row? Type 0, 1 or 2.");
                rowChoice = Console.ReadLine();

                if (int.TryParse(columnChoice, out int column) && int.TryParse(rowChoice, out int row))
                    if (row >= 0 && row < 3 && column >= 0 && column < 3)
                    {
                        Logic.grid[row, column] = symbolChoice;
                        Logic.PrintGrid(Logic.grid);

                    }
                    else
                    {
                        Console.WriteLine("Invalid spot. Try again.");
                        Console.ReadLine();
                    }

                //AI placing a symbol 



            }

            }
        }
    }
