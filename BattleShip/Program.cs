using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {

        //int  ShootingMethod(int x, int y) {
            //takes x and y input. and puts it into a (,)
            //make a bunch of if statements to see if the the shot is a hit or miss
            //I would like to tell you "Hit" or "Miss"
            
            

            string hit = "Hit";
            string miss = "miss";
            
        //}

        void Placeships() {
            Random rnd = new Random();
            int xax = rnd.Next(0, 11);
            Random rmd = new Random();
            int yax = rmd.Next(0, 11);

            SpeedBoat speedBoat = new SpeedBoat(xax, yax);
           SeaArray[0, 2] = Cell.LiveBoat;

        }

        
        
    
        enum Cell { Water, LiveBoat, HitBoat, SunkBoat };

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

        static string BoardToString(Cell[,] board)
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
        static void Main(string[] args)
        {
            /*Make the sea array... then make ships.
             * make it so the ships can be placed.
             * then make it so they can be attacked and stored where and what health they have.
             
            
                */


            Placeships();
            

           Cell[,] SeaArray = new Cell[10,10];

            SeaArray[0, 2] = Cell.LiveBoat;
            SeaArray[2, 2] = Cell.LiveBoat;
           
            SeaArray[1, 1] = Cell.HitBoat;
           
            
            Console.WriteLine(BoardToString(SeaArray));
            Console.WriteLine("Enter coordinates for shoots thing");

            Console.ReadKey();

        }
    }
}
