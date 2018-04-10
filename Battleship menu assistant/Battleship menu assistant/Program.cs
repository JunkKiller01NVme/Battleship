// File/Project Prolog
// Name:     <PUT YOUR NAME HERE>
// Period:   <PUT YOUR PERIOD HERE>
// Username: larsorob001
// Project:  Battleship_menu_assistant
// Date:     4/10/2018 1:31:18 PM
//
// I declare that the following code was written by me or provided 
// by the instructor for this project. I understand that copying source
// code from any other source constitutes cheating, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------

using System;
using static System.Console;

namespace Battleship_menu_assistant
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your code goes below here
            while (true)
            {
                WriteLine("Welcome to B A T T L E S H I P!!!!!");
                WriteLine("You are currently in the main menu where you can do a great many things.");
                WriteLine("Enter 1 to see the instructions.");
                WriteLine("Enter 2 to start a new game.");
                WriteLine("Enter 3 to quit.");
                WriteLine("Enter 4 to enter debug mode.");
                string response = ReadLine();

                if (int.TryParse(response, out int result))
                {
                    if (result == 1)
                    {
                        // Instructions
                        break;
                    }
                    else if (result == 2)
                    {
                        // New game
                        break;
                    }
                    else if (result == 3)
                    {
                        // Terminate program
                        Environment.Exit(0);
                    }
                    else if (result == 4)
                    {
                        // debugging mode
                        break;
                    }
                    else
                    {
                        Clear();
                        WriteLine("That was not a valid response, try again.");
                        WriteLine();
                    }
                }
            }        
            // Your code goes above here
            WriteLine("Press any key to exit.");
            ReadKey();
        }
    }
}
