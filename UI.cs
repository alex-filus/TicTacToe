using System;
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
            if (symbolChoice == SYMBOL_CHOICE_O)
            {
                computerSymbol = SYMBOL_CHOICE_X;
            }
            else
            {
                computerSymbol = SYMBOL_CHOICE_O;
            }

            // Testing symbol, delete when not needed
            Console.WriteLine($"Computer symbol is: {computerSymbol}");

            while (true)
            {
                if (Logic.NotFull() == true)
                {
                    // Ask user to choose a spot
                    Logic.UserTurn();

                    //Computer placing a symbol 
                    Logic.ComputerTurn();
                }

                else
                {
                    Console.WriteLine("Sorry, game over!");
                }
            }
        }
    }
}