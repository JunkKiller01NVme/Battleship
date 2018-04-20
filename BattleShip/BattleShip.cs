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
        public int timesShot = 0;
        public Cell[,] SeaArray;
        public SpeedBoat Sb;
        
        public BattleShip()
        {
            SeaArray = new Cell[10, 10];

        }

        public void Run()
        {
            //start the menu
            Menu();
            //make the board
            //PlayingBoard();
            //starts shoots
            Shootsthings(0, 0);
            //place the ships 
            //PlaceShips();
            // start the game
            // Start();
        }

        public void Menu()
        {
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
                        Write("To shoot. enter the 'X' value first, hit enter; then enter the 'Y' value.");
                        Write("Back to the menu? (y/n)");

                        if (ReadLine() == "y")
                        {

                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (result == 2)
                    {
                        // New game

                        Placeships();
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
                        PlayingBoard();
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



        //Makes the Sea board print to the screen
        public void PlayingBoard()
        {
            Clear();
            WriteLine(BoardToString(SeaArray));
           

        }
        //this methods job is to place the ships... problem is that we cant figure out how to use mcculloughs code to our advantage.
        public void Placeships()
        {
            Random rnd = new Random();
            int xax = rnd.Next(0, 11);
            Random rmd = new Random();
            int yax = rmd.Next(0, 11);



            // Cell[,] SeaArray = new Cell[10, 10];

            SpeedBoat speedBoat = new SpeedBoat(xax, yax);
            //SeaArray[speedBoat.xAxis-1, speedBoat.yAxis-1] = Cell.LiveBoat;
           // WriteLine(String.Join("\n", Enumerable.Range(0, SeaArray.GetLength(0)).Select(i => String.Join(", ", Enumerable.Range(0, SeaArray.GetLength(1)).Select(j => SeaArray[i, j]))))); //#### NO TOUCH #### E V E R ####
            PlayingBoard();
        }

        // This method takes in two inputs and relates them to the board.
        public void Shootsthings(int x, int y)
        {
            Write("Ok you are now ready to shoot at your opponent. Remember: X first, enter, and then Y.");
            WriteLine();
            x = Int32.Parse(ReadLine());
            y = Int32.Parse(ReadLine());



            if (x == y) { }

            this.timesShot++;
        }

        public void YouWin()
        {
            Clear();
            WriteLine("You Win!!! You took " + timesShot + " shots to win!.");

        }


    }


}

    


   

