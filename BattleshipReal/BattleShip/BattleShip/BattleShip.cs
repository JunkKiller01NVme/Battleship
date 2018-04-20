using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BattleShip
{
    class BattleShip
    {

        public string playerName = "";
        public



        BattleShip() {


        }

        public void Run() {
            //start the menu
            //Menu();
            //make the board
            //PlayingBoard();
            //place the ships 
            //PlaceShips();
            // start the game
           // Start();
        }


        public void Menu() {
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


                        PlayingBoard();



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








        public void PlayingBoard() {
           
        }
        
            
        

           

       static string CellToString(Cell c)
            {
                switch (c)
                {
                    case Cell.Water: return "_";
                    case Cell.LiveBoat: return "O";
                    case Cell.HitBoat: return "*";
                    case Cell.SunkBoat: return "X";
                    default: return "?";
                }
            }
        
        
             public enum Cell { Water, LiveBoat, HitBoat, SunkBoat };
        string BoardToString(Cell[,] board)
            {
                StringBuilder sb = new StringBuilder();

                // Column labels
                sb.Append("  ");
                for (int i = 1; i <= 10; i++)
                {
                    sb.Append(i + " ");
                }
                sb.AppendLine();

                // Rows
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    char rowLabel = (char)('A' + i);
                    sb.Append(rowLabel + " ");
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        Cell c = board[i, j];
                        sb.Append(CellToString(c) + " ");
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            Cell[,] SeaArray = new Cell[10, 10];

        }

    }
    

}

    


   

