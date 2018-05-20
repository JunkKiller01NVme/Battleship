﻿using System;
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
        public Cell[,] PlayerArray;
        public SpeedBoat Sb;
        public Sub Sub;
        public Destroyer des;
        public Carrier car;
        public Boat b;
        public Random rand;

        // Constructor
        public BattleShip()
        {
            PlayerArray = new Cell[10, 10];
            SeaArray = new Cell[10, 10];
            rand = new Random();
        }

        // Runs the game at base level by calling original methods.
        public void Run()
        {
            //start the menu
            Menu();
            //make the board
            //PlayingBoard();
            //starts shoots
            Shootsthings();
            //place the ships 
            //PlaceShips();
            // start the game
            // Start();
        }

        // Menu interface
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
                        while (true)
                        {
                            WriteLine("To shoot. enter the number first, hit enter; then enter the letter that you would like to shoot at.");
                            WriteLine("Would you like to look at what the different symbols mean? (y/n)");
                            string input = ReadLine();
                            if (input == "y" || input == "Y")
                            {
                                WriteLine("Empty Water/A live boat (You never know): _");
                                WriteLine("Hit Boat: *");
                                WriteLine("A missed shot: @");
                            }
                            WriteLine("Would you like to see it again? (y/n)");
                            string input2 = ReadLine();
                            if (input2 == "y" || input2 == "Y")
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else if (result == 2)
                    {
                        // New game
                        PlayerBoard();
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

        // Parts of the board to actual symbols.
        static string CellToString(Cell c)
        {
            switch (c)
            {
                case Cell.Water: return "_";
                case Cell.LiveBoat: return "O";
                case Cell.HitBoat: return "*";
                case Cell.SunkBoat: return "X";
                case Cell.Missed: return "@";
                default: return "?";
            }
        }

        // Parts of the board
        public enum Cell { Water, LiveBoat, HitBoat, SunkBoat, Missed };

        // Labels and making board display?
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
            WriteLine("Enemy Board");
            WriteLine();
            WriteLine(BoardToString(SeaArray));
            WriteLine();
            WriteLine("Player Board");
            WriteLine();
            WriteLine(BoardToString(PlayerArray));
        }

        //this methods job is to place the ships.
        public void Placeships()
        {
            //All Ships
            #region

            SpeedBoat speedBoat = new SpeedBoat(Yint(), Xint());
            Sb = speedBoat;

            Sub sub = new Sub(Yint(), Xint());
            Sub = sub;

            Destroyer destroyer = new Destroyer(Yint(), Xint());
            des = destroyer;

            Carrier carrier = new Carrier(Yint(), Xint());
            car = carrier;

            Boat boat = new Boat(Yint(), Xint());
            b = boat;
            #endregion



            // WriteLine(String.Join("\n", Enumerable.Range(0, SeaArray.GetLength(0)).Select(i => String.Join(", ", Enumerable.Range(0, SeaArray.GetLength(1)).Select(j => SeaArray[i, j]))))); //#### NO TOUCH #### E V E R ####
            PlayingBoard();
            PlaceShipSegments();

        }

        //This method will place the rest of the ship(s)
        public void PlaceShipSegments()
        {

            //The up most left piece of ship is the main piece.
            //Going off of the main peice I need to figure out if it has space to be placed horizontaly of verticly... If not randomize the main peice again
            //Or... Whenever the main peice is placed it determines if the rest of the ship can be placed. if not (again) it will try to flip it, or turn it. AAnnd if that doesnt work itll replace it.


            //Speedboat
            #region
            while (true)
            {
                if (!Sb.vertical)
                {
                    if (Sb.xAxis + (Sb.size - 1) > 9)
                    {
                        Sb = new SpeedBoat(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (Sb.yAxis + (Sb.size - 1) > 9)
                    {
                        Sb = new SpeedBoat(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!Sb.vertical)
            {
                //Checks to see if the space next
                if (SeaArray[Sb.yAxis, Sb.xAxis + (Sb.size - 1)] == Cell.Water)
                {

                    for (int i = 0; i <= Sb.size - 1; i++)
                    {
                        SeaArray[Sb.yAxis, Sb.xAxis + i] = Cell.LiveBoat;

                    }

                }
                else
                {
                    for (int i = 0; i < Sb.size; i++)
                    {
                        SeaArray[Sb.yAxis, Sb.xAxis - i] = Cell.LiveBoat;
                    }
                }
            }
            else
            {
                if (SeaArray[Sb.yAxis + (Sb.size - 1), Sb.xAxis] == Cell.Water)
                {
                    for (int i = 0; i < Sb.size; i++)
                    {
                        SeaArray[Sb.yAxis + i, Sb.xAxis] = Cell.LiveBoat;
                    }
                }
                else
                {
                    for (int i = 0; i < Sb.size; i++)
                    {
                        SeaArray[Sb.yAxis - i, Sb.xAxis] = Cell.LiveBoat;
                    }

                }

            }
            #endregion

            //Sub  
            #region
            while (true)
            {
                if (!Sub.vertical)
                {
                    if (Sub.xAxis + (Sub.size - 1) > 9)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (SeaArray[Sub.yAxis, Sub.xAxis] != Cell.Water)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.xAxis + 2 > 9)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.xAxis - 2 < 0)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.yAxis + 2 > 9)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.yAxis - 2 < 0)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (Sub.yAxis + (Sub.size - 1) > 9)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (SeaArray[Sub.yAxis, Sub.xAxis] != Cell.Water)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.xAxis + 2 > 9)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.xAxis - 2 < 0)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.yAxis + 2 > 9)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else if (Sub.yAxis - 2 < 0)
                    {
                        Sub = new Sub(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!Sub.vertical)
            {
                //Checks to see if the space next
                if (SeaArray[Sub.yAxis, Sub.xAxis + (Sub.size - 1)] == Cell.Water && SeaArray[Sub.yAxis, Sub.xAxis + (Sub.size - 2)] == Cell.Water)
                {

                    for (int i = 0; i < Sub.size; i++)
                    {
                        SeaArray[Sub.yAxis, Sub.xAxis + i] = Cell.LiveBoat;

                    }

                }
                else
                {
                    for (int i = 0; i < Sub.size; i++)
                    {

                        SeaArray[Sub.yAxis, Sub.xAxis - i] = Cell.LiveBoat;

                    }
                }
            }
            else
            {
                if (SeaArray[Sub.yAxis + (Sub.size - 1), Sub.xAxis] == Cell.Water && SeaArray[Sub.yAxis + (Sub.size - 2), Sub.xAxis] == Cell.Water)
                {
                    for (int i = 0; i < Sub.size; i++)
                    {
                        SeaArray[Sub.yAxis + i, Sub.xAxis] = Cell.LiveBoat;
                    }
                }
                else
                {
                    for (int i = 0; i < Sub.size; i++)
                    {
                        SeaArray[Sub.yAxis - i, Sub.xAxis] = Cell.LiveBoat;
                    }

                }

            }

            #endregion

            //Destroyer  
            #region
            while (true)
            {
                if (!des.vertical)
                {
                    if (des.xAxis + (des.size - 1) > 9)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (SeaArray[des.yAxis, des.xAxis] != Cell.Water)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.xAxis + 2 > 9)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.xAxis - 2 < 0)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.yAxis + 2 > 9)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.yAxis - 2 < 0)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (des.yAxis + (des.size - 1) > 9)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (SeaArray[des.yAxis, des.xAxis] != Cell.Water)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.xAxis + 2 > 9)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.xAxis - 2 < 0)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.yAxis + 2 > 9)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else if (des.yAxis - 2 < 0)
                    {
                        des = new Destroyer(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!des.vertical)
            {
                //Checks to see if the space next
                if (SeaArray[des.yAxis, des.xAxis + (des.size - 1)] == Cell.Water && SeaArray[des.yAxis, des.xAxis + (des.size - 2)] == Cell.Water)
                {

                    for (int i = 0; i < des.size; i++)
                    {
                        SeaArray[des.yAxis, des.xAxis + i] = Cell.LiveBoat;

                    }

                }
                else
                {
                    for (int i = 0; i < des.size; i++)
                    {

                        SeaArray[des.yAxis, des.xAxis - i] = Cell.LiveBoat;

                    }
                }
            }
            else
            {
                if (SeaArray[des.yAxis + (des.size - 1), des.xAxis] == Cell.Water && SeaArray[des.yAxis + (des.size - 2), des.xAxis] == Cell.Water)
                {
                    for (int i = 0; i < des.size; i++)
                    {
                        SeaArray[des.yAxis + i, des.xAxis] = Cell.LiveBoat;
                    }
                }
                else
                {
                    for (int i = 0; i < des.size; i++)
                    {
                        SeaArray[des.yAxis - i, des.xAxis] = Cell.LiveBoat;
                    }

                }

            }
            #endregion

            //Carrier   
            #region
            while (true)
            {
                if (!car.vertical)
                {
                    if (car.xAxis + (car.size - 1) > 9)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (SeaArray[car.yAxis, car.xAxis] != Cell.Water)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.xAxis + 4 > 9)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.xAxis - 4 < 0)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.yAxis + 4 > 9)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.yAxis - 4 < 0)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (car.yAxis + (car.size - 1) > 9)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (SeaArray[car.yAxis, car.xAxis] != Cell.Water)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.xAxis + 4 > 9)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.xAxis - 4 < 0)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.yAxis + 4 > 9)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else if (car.yAxis - 4 < 0)
                    {
                        car = new Carrier(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!car.vertical)
            {
                //Checks to see if the space next
                if (SeaArray[car.yAxis, car.xAxis + (car.size - 1)] == Cell.Water && SeaArray[car.yAxis, car.xAxis + (car.size - 2)] == Cell.Water && SeaArray[car.yAxis, car.xAxis + (car.size - 3)] == Cell.Water && SeaArray[car.yAxis, car.xAxis + (car.size - 4)] == Cell.Water)
                {

                    for (int i = 0; i < car.size; i++)
                    {
                        SeaArray[car.yAxis, car.xAxis + i] = Cell.LiveBoat;

                    }

                }
                else
                {
                    for (int i = 0; i < car.size; i++)
                    {

                        SeaArray[car.yAxis, car.xAxis - i] = Cell.LiveBoat;

                    }
                }
            }
            else
            {
                if (SeaArray[car.yAxis + (car.size - 1), car.xAxis] == Cell.Water && SeaArray[car.yAxis + (car.size - 2), car.xAxis] == Cell.Water && SeaArray[car.yAxis + (car.size - 3), car.xAxis] == Cell.Water && SeaArray[car.yAxis + (car.size - 4), car.xAxis] == Cell.Water)
                {
                    for (int i = 0; i < car.size; i++)
                    {
                        SeaArray[car.yAxis + i, car.xAxis] = Cell.LiveBoat;
                    }
                }
                else
                {
                    for (int i = 0; i < car.size; i++)
                    {
                        SeaArray[car.yAxis - i, car.xAxis] = Cell.LiveBoat;
                    }

                }

            }
            #endregion

            //Boat    
            #region
            while (true)
            {
                if (!b.vertical)
                {
                    if (b.xAxis + (b.size - 1) > 9)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (SeaArray[b.yAxis, b.xAxis] != Cell.Water)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.xAxis + 3 > 9)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.xAxis - 3 < 0)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.yAxis + 3 > 9)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.yAxis - 3 < 0)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (b.yAxis + (b.size - 1) > 9)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (SeaArray[b.yAxis, b.xAxis] != Cell.Water)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.xAxis + 3 > 9)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.xAxis - 3 < 0)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.yAxis + 3 > 9)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else if (b.yAxis - 3 < 0)
                    {
                        b = new Boat(Yint(), Xint());
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!b.vertical)
            {
                //Checks to see if the space next
                if (SeaArray[b.yAxis, b.xAxis + (b.size - 1)] == Cell.Water && SeaArray[b.yAxis, b.xAxis + (b.size - 2)] == Cell.Water && SeaArray[b.yAxis, b.xAxis + (b.size - 3)] == Cell.Water)
                {

                    for (int i = 0; i < b.size; i++)
                    {
                        SeaArray[b.yAxis, b.xAxis + i] = Cell.LiveBoat;

                    }

                }
                else
                {
                    for (int i = 0; i < b.size; i++)
                    {

                        SeaArray[b.yAxis, b.xAxis - i] = Cell.LiveBoat;

                    }
                }
            }
            else
            {
                if (SeaArray[b.yAxis + (b.size - 1), b.xAxis] == Cell.Water && SeaArray[b.yAxis + (b.size - 2), b.xAxis] == Cell.Water && SeaArray[b.yAxis + (b.size - 3), b.xAxis] == Cell.Water)
                {
                    for (int i = 0; i < b.size; i++)
                    {
                        SeaArray[b.yAxis + i, b.xAxis] = Cell.LiveBoat;
                    }
                }
                else
                {
                    for (int i = 0; i < b.size; i++)
                    {
                        SeaArray[b.yAxis - i, b.xAxis] = Cell.LiveBoat;
                    }

                }

            }
            #endregion

        }

        // This method takes in two inputs and relates them to the board.
        public void Shootsthings()
        {
            while (true)
            {
                PlayingBoard();
                WriteLine("Ok you are now ready to shoot at your opponent.");
                WriteLine("@ = Miss");
                WriteLine("* = Hit");
                WriteLine();
                int fireX = 0;
                int fireY = 0;
                while (true)
                {
                    while (true)
                    {
                        WriteLine("First the numbers...");

                        if (int.TryParse(ReadLine(), out int xx))
                        {
                            if (xx > 10)
                            {
                                WriteLine("That number was too high.");
                                continue;
                            }
                            else
                            {
                                fireX = xx - 1;
                                break;
                            }
                        }
                        else
                        {
                            PlayingBoard();
                            WriteLine("Something didn't work, let's try that again.");
                        }
                    }
                    while (true)
                    {
                        WriteLine("Now the letters...");
                        string letterInput = ReadLine();
                        if (int.TryParse(letterInput, out int bleh))
                        {
                            PlayingBoard();
                            WriteLine("That wasn't a letter, try again.");
                        }
                        else if (char.TryParse(letterInput, out char yy))
                        {
                            if (char.ToLower(yy) > 'j')
                            {
                                WriteLine("That letter was past J");
                                continue;
                            }
                            else
                            {
                                fireY = LetterToRow(yy);
                                break;
                            }
                        }
                        else
                        {
                            PlayingBoard();
                            WriteLine("Something didn't work, let's try that again.");
                        }
                    }
                    break;
                }
                if (SeaArray[fireY, fireX] != Cell.Missed && SeaArray[fireY, fireX] != Cell.HitBoat)
                {
                    timesShot++;
                    if (SeaArray[fireY, fireX] == Cell.LiveBoat)
                    {
                        SeaArray[fireY, fireX] = Cell.HitBoat;
                    }

                    else
                    {
                        Console.WriteLine("You missed!");
                        SeaArray[fireY, fireX] = Cell.Missed;
                    }
                }
                else
                {
                    WriteLine("You have already fired there, try another spot.");
                    Console.ReadKey();
                }

                if (SeaArray.Cast<Cell>().Contains(Cell.LiveBoat))
                {
                    continue;
                }
                else
                {
                    YouWin();
                    break;
                }
            }

        }

        // Used for letter input conversion
        public int LetterToRow(char input)
        {
            return Char.ToUpper(input) - 'A';
            switch (Char.ToUpper(input))
            {
                case 'A': return 0;
                case 'B': return 1;

            }
        }

        // Win messages etc...
        public void YouWin()
        {
            Clear();
            WriteLine("You Win!!! You took " + timesShot + " shots to win!.");
            Console.ReadKey();
        }

        // Randomly Generates number
        public int Xint()
        {
            int x = rand.Next(0, 10);

            return x;
        }

        // Randomly generates number
        public int Yint()
        {

            int y = rand.Next(0, 10);
            return y;
        }

        // Generates the players board
        public void PlayerBoard()
        {
            WriteLine("Let's place your ships.");
            WriteLine("Ships will be placed from left to right, top to bottom.");
            WriteLine("");
            WriteLine("We will start with your Carrier.");
            PlayerCarrier();
            WriteLine("Next we will place your Battleship.");
            PlayerBoat();
            WriteLine("Now we will partake in the action of placing your Submarine.");
            PlayerSub();
            WriteLine("Now we shall place your Destroyer.");
            PlayerDestroyer();
            WriteLine("Finally the SpeedBoat");
            PlayerSpeedBoat();
            PlayingBoard();
        }

        // Generates the player's carrier
        public void PlayerCarrier()
        {
            bool vertical = false;
            int number = 0;
            int letter = 0;
            while (true)
            {
                while (true)
                {
                    WriteLine("Will your ship be placed horizontal or vertical?");
                    string input = ReadLine();
                    if (input == "horizontal" || input == "Horizontal" || input == "HORIZONTAL")
                    {
                        vertical = false;
                        break;
                    }
                    else if (input == "vertical" || input == "Vertical" || input == "VERTICAL")
                    {
                        vertical = true;
                        break;
                    }
                    else
                    {
                        WriteLine("Something wasn't quite right, try again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What number should the left most piece of your carrier be at?");
                    string input = ReadLine();
                    if (int.TryParse(input, out int numb))
                    {
                        if (numb - 1 <= 9 && numb - 1 >= 0)
                        {
                            number = numb;
                            break;
                        }
                        else
                        {
                            WriteLine("That number was beyond the existing numbers on the array.");
                        }
                    }
                    else
                    {
                        WriteLine("Something went wrong, let's try that again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What letter should the upper most piece of your carrier be located at?");
                    string input = ReadLine();
                    if (int.TryParse(input, out int bleh))
                    {
                        WriteLine("That wasn't a letter, try again.");
                    }
                    else if (char.TryParse(input, out char lett))
                    {
                        if (char.ToLower(lett) > 'j')
                        {
                            WriteLine("That was past the letter 'J'.");
                            continue;
                        }
                        else
                        {
                            letter = LetterToRow(lett);
                            break;
                        }
                    }
                    else
                    {
                        WriteLine("Something didn't work, let's try again.");
                        continue;
                    }
                }
                if (vertical)
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter + 1, number] == Cell.Water && PlayerArray[letter + 2, number] == Cell.Water && PlayerArray[letter + 3, number] == Cell.Water && PlayerArray[letter + 4, number] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter + i, number] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
                else
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter, number + 1] == Cell.Water && PlayerArray[letter, number + 2] == Cell.Water && PlayerArray[letter, number + 3] == Cell.Water && PlayerArray[letter, number + 4] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter, number + i] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
            }
        }

        // Generates the player's battleship
        public void PlayerBoat()
        {
            bool vertical = false;
            int number = 0;
            int letter = 0;
            while (true)
            {
                while (true)
                {
                    WriteLine("Will your ship be placed horizontal or vertical?");
                    string input = ReadLine();
                    if (input == "horizontal" || input == "Horizontal" || input == "HORIZONTAL")
                    {
                        vertical = false;
                        break;
                    }
                    else if (input == "vertical" || input == "Vertical" || input == "VERTICAL")
                    {
                        vertical = true;
                        break;
                    }
                    else
                    {
                        WriteLine("Something wasn't quite right, try again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What number should the left most piece of your battleship be at?");
                    string input = ReadLine();
                    if (int.TryParse(input, out int numb))
                    {
                        if (numb - 1 <= 9 && numb - 1 >= 0)
                        {
                            number = numb;
                            break;
                        }
                        else
                        {
                            WriteLine("That number was beyond the existing numbers on the array.");
                        }
                    }
                    else
                    {
                        WriteLine("Something went wrong, let's try that again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What letter should the upper most piece of your battleship be located at?");
                    string input = ReadLine();
                    if (char.TryParse(input, out char lett))
                    {
                        if (int.TryParse(input, out int bleh))
                        {
                            WriteLine("That wasn't a letter, try again.");
                        }
                        if (char.ToLower(lett) > 'j')
                        {
                            WriteLine("That was past the letter 'j'.");
                            continue;
                        }
                        else
                        {
                            letter = LetterToRow(lett);
                            break;
                        }
                    }
                    else
                    {
                        WriteLine("Something didn't work, let's try again.");
                        continue;
                    }
                }
                if (vertical)
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter + 1, number] == Cell.Water && PlayerArray[letter + 2, number] == Cell.Water && PlayerArray[letter + 3, number] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter + i, number] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
                else
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter, number + 1] == Cell.Water && PlayerArray[letter, number + 2] == Cell.Water && PlayerArray[letter, number + 3] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter, number + i] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
            }
        }

        // Generates the player's submarine
        public void PlayerSub()
        {
            bool vertical = false;
            int number = 0;
            int letter = 0;
            while (true)
            {
                while (true)
                {
                    WriteLine("Will your ship be placed horizontal or vertical?");
                    string input = ReadLine();
                    if (input == "horizontal" || input == "Horizontal" || input == "HORIZONTAL")
                    {
                        vertical = false;
                        break;
                    }
                    else if (input == "vertical" || input == "Vertical" || input == "VERTICAL")
                    {
                        vertical = true;
                        break;
                    }
                    else
                    {
                        WriteLine("Something wasn't quite right, try again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What number should the left most piece of your Submarine be at?");
                    string input = ReadLine();
                    if (int.TryParse(input, out int numb))
                    {
                        if (numb - 1 <= 9 && numb - 1 >= 0)
                        {
                            number = numb;
                            break;
                        }
                        else
                        {
                            WriteLine("That number was beyond the existing numbers on the array.");
                        }
                    }
                    else
                    {
                        WriteLine("Something went wrong, let's try that again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What letter should the upper most piece of your Submarine be located at?");
                    string input = ReadLine();
                    if (char.TryParse(input, out char lett))
                    {
                        if (int.TryParse(input, out int bleh))
                        {
                            WriteLine("That wasn't a letter, try again.");
                        }
                        if (char.ToLower(lett) > 'j')
                        {
                            WriteLine("That was past the letter 'j'.");
                            continue;
                        }
                        else
                        {
                            letter = LetterToRow(lett);
                            break;
                        }
                    }
                    else
                    {
                        WriteLine("Something didn't work, let's try again.");
                        continue;
                    }
                }
                if (vertical)
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter + 1, number] == Cell.Water && PlayerArray[letter + 2, number] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter + i, number] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
                else
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter, number + 1] == Cell.Water && PlayerArray[letter, number + 2] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter, number + i] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
            }
        }

        // Generates the player's destroyer
        public void PlayerDestroyer()
        {
            bool vertical = false;
            int number = 0;
            int letter = 0;
            while (true)
            {
                while (true)
                {
                    WriteLine("Will your ship be placed horizontal or vertical?");
                    string input = ReadLine();
                    if (input == "horizontal" || input == "Horizontal" || input == "HORIZONTAL")
                    {
                        vertical = false;
                        break;
                    }
                    else if (input == "vertical" || input == "Vertical" || input == "VERTICAL")
                    {
                        vertical = true;
                        break;
                    }
                    else
                    {
                        WriteLine("Something wasn't quite right, try again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What number should the left most piece of your Destroyer be at?");
                    string input = ReadLine();
                    if (int.TryParse(input, out int numb))
                    {
                        if (numb - 1 <= 9 && numb - 1 >= 0)
                        {
                            number = numb;
                            break;
                        }
                        else
                        {
                            WriteLine("That number was beyond the existing numbers on the array.");
                        }
                    }
                    else
                    {
                        WriteLine("Something went wrong, let's try that again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What letter should the upper most piece of your Destroyer be located at?");
                    string input = ReadLine();
                    if (char.TryParse(input, out char lett))
                    {
                        if (int.TryParse(input, out int bleh))
                        {
                            WriteLine("That wasn't a letter, try again.");
                        }
                        if (char.ToLower(lett) > 'j')
                        {
                            WriteLine("That was past the letter 'j'.");
                            continue;
                        }
                        else
                        {
                            letter = LetterToRow(lett);
                            break;
                        }
                    }
                    else
                    {
                        WriteLine("Something didn't work, let's try again.");
                        continue;
                    }
                }
                if (vertical)
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter + 1, number] == Cell.Water && PlayerArray[letter + 2, number] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter + i, number] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
                else
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter, number + 1] == Cell.Water && PlayerArray[letter, number + 2] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter, number + i] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
            }
        }

        // Generates the player's speedboat
        public void PlayerSpeedBoat()
        {
            bool vertical = false;
            int number = 0;
            int letter = 0;
            while (true)
            {
                while (true)
                {
                    WriteLine("Will your ship be placed horizontal or vertical?");
                    string input = ReadLine();
                    if (input == "horizontal" || input == "Horizontal" || input == "HORIZONTAL")
                    {
                        vertical = false;
                        break;
                    }
                    else if (input == "vertical" || input == "Vertical" || input == "VERTICAL")
                    {
                        vertical = true;
                        break;
                    }
                    else
                    {
                        WriteLine("Something wasn't quite right, try again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What number should the left most piece of your Speedboat be at?");
                    string input = ReadLine();
                    if (int.TryParse(input, out int numb))
                    {
                        if (numb - 1 <= 9 && numb - 1 >= 0)
                        {
                            number = numb;
                            break;
                        }
                        else
                        {
                            WriteLine("That number was beyond the existing numbers on the array.");
                        }
                    }
                    else
                    {
                        WriteLine("Something went wrong, let's try that again.");
                        continue;
                    }
                }
                while (true)
                {
                    WriteLine("What letter should the upper most piece of your speedboat be located at?");
                    string input = ReadLine();
                    if (char.TryParse(input, out char lett))
                    {
                        if (int.TryParse(input, out int bleh))
                        {
                            WriteLine("That wasn't a letter, try again.");
                        }
                        if (char.ToLower(lett) > 'j')
                        {
                            WriteLine("That was past the letter 'j'.");
                            continue;
                        }
                        else
                        {
                            letter = LetterToRow(lett);
                            break;
                        }
                    }
                    else
                    {
                        WriteLine("Something didn't work, let's try again.");
                        continue;
                    }
                }
                if (vertical)
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter + 1, number] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter + i, number] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
                else
                {
                    if (PlayerArray[letter, number] == Cell.Water && PlayerArray[letter, number + 1] == Cell.Water)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            PlayerArray[letter, number + i] = Cell.LiveBoat;
                        }
                        break;
                    }
                    else
                    {
                        WriteLine("The ship didn't fit there. Let's start over.");
                        WriteLine();
                        continue;
                    }
                }
            }
        }
    }
    //static int GetValueFromArray(int[] array, int index) { }
}







