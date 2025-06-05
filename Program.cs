using System;
using System.Drawing;
using Console = Colorful.Console;
using System.Threading;

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
            string computerSymbol = " ";


            Console.WriteLine("Welcome to Tic-Tac-Toe! Let's play!");
            Console.WriteLine();
            Console.WriteLine("What symbol would you like to be? \nPress O or X.");
            string symbolChoice = Console.ReadLine()?.ToUpper();

            //User chooses a symbol
            while (symbolChoice != SYMBOL_CHOICE_O && symbolChoice != SYMBOL_CHOICE_X)
            {

                Console.WriteLine("Incorrect input. Please try again.");
                symbolChoice = Console.ReadLine()?.ToUpper();
            }

            //assigning a symbol to the computer
            if (symbolChoice == SYMBOL_CHOICE_O)
            {
                computerSymbol = SYMBOL_CHOICE_X;
            }
            else
            {
                computerSymbol = SYMBOL_CHOICE_O;
            }
            //Testing symbol, delete when not needed
            Console.WriteLine($"Computer symbol is: {computerSymbol}");


            //grid printout
            Logic.PrintGrid(Logic.grid);
            Console.WriteLine();

            while (true)
            {
                //Ask user to choose a spot
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Where would you like to place the {symbolChoice}?");
                    Console.WriteLine("Which column? Type 0, 1 or 2.");
                    columnChoice = Console.ReadLine();
                    Console.WriteLine("Which row? Type 0, 1 or 2.");
                    rowChoice = Console.ReadLine();

                    if (int.TryParse(columnChoice, out int column) && int.TryParse(rowChoice, out int row))
                    {
                        if (row >= 0 && row < 3 && column >= 0 && column < 3)
                        {
                            if (Logic.grid[row, column] == " ")
                            {
                                Logic.grid[row, column] = symbolChoice;
                                Logic.PrintGrid(Logic.grid);
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
                            Console.ReadLine();
                        }
                    }
                }
                    //Computer placing a symbol 

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

                    Logic.grid[randomRow, randomColumn] = computerSymbol;
                    Logic.PrintGrid(Logic.grid);
                    Console.WriteLine();



                

            }

        }
    }
}
