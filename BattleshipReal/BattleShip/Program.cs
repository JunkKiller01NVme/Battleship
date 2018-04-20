using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Program
    {



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


         enum Cell { Water, LiveBoat, HitBoat, SunkBoat };

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

        static void CellLive(int x, int y)
        {
            b.SeaArray[x, y] = BattleShip.Cell.LiveBoat;
        }

        static void PlaceSpeedBoat()
        {
            SpeedBoat speedBoat = new SpeedBoat(4, 4);
            CellLive(speedBoat.xAxis, speedBoat.yAxis);
        }
        public static BattleShip b = new BattleShip();

        static void Main(string[] args)
        {
            //BattleShip b = new BattleShip();
            
            b.Run();
            
            //BattleShip.SeaArray[1, 2] = Cell.LiveBoat;
            

            b.YouWin();

            //Cell[,] SeaArray = new Cell[10, 10];
            //Console.WriteLine(BoardToString(SeaArray));
            //SeaArray[1, 2] = Cell.LiveBoat;




            //Console.WriteLine(BoardToString(SeaArray));
            //Working on the if statements on if there is a ship there where you shoot
            // Console.WriteLine("Enter coordinates for shoots thing x first then y after you hit enter");
            // Console.ReadLine();
            // int shotx = int.Parse(Console.ReadLine());
            Console.ReadLine();
            // int shoty = int.Parse(Console.ReadLine());
            // if (shot = Cell.LiveBoat) {


            // }




        }
    }
}
