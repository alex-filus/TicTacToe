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
            string columnChoice = "0";
            string rowChoice = "0";


            //grid printout
            Logic.PrintGrid(Logic.grid);
            Console.WriteLine();

            //start the main game while loop
            UI.StartGame();


        }

    }
}

