﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;
using Console = Colorful.Console;

namespace TicTacToe
{
    class UI
    {
        public const string SYMBOL_CHOICE_O = "O";
        public const string SYMBOL_CHOICE_X = "X";
        public static string computerSymbol = " ";
        public static string symbolChoice;

        public static void StartGame()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe! Let's play!");
            Console.WriteLine();
            Console.WriteLine($"What symbol would you like to be? \nPress {SYMBOL_CHOICE_O} or {SYMBOL_CHOICE_X}.");
            symbolChoice = Console.ReadLine()?.ToUpper();

            // User chooses a symbol
            while (symbolChoice != SYMBOL_CHOICE_O && symbolChoice != SYMBOL_CHOICE_X)
            {
                Console.WriteLine("Incorrect input. Please try again.");
                symbolChoice = Console.ReadLine()?.ToUpper();
            }

            // Assigning a symbol to the computer
            Logic.ComputerSymbolAssign();

            // Testing symbol, delete when not needed
            Console.WriteLine($"Computer symbol is: {computerSymbol}");

            while (true)
            {
                if (Logic.NotFull() == true)
                {
                    // Ask user to choose a spot
                    UserTurn();

                    //Computer placing a symbol 
                    ComputerTurn();
                }

                else
                {
                    Console.WriteLine("Sorry, game over!");
                }
            }
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
                        if (Logic.grid[row, column] == " ")
                        {
                            Logic.grid[row, column] = UI.symbolChoice;
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
                    }
                }
            }
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
    }
}



