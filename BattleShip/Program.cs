using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BattleShip
{
    class Program
    {

        

       

        static void Main(string[] args)
        {
           BattleShip b = new BattleShip();
            
            b.Run();
            
            //BattleShip.SeaArray[1, 2] = Cell.LiveBoat;
            

            b.YouWin();

            //Cell[,] SeaArray = new Cell[10, 10];
            //Console.WriteLine(BoardToString(SeaArray));
            //SeaArray[1, 2] = Cell.LiveBoat;
            

            Console.WriteLine();
            
            


            //Console.WriteLine(BoardToString(SeaArray));
            //Working on the if statements on if there is a ship there where you shoot
            // Console.WriteLine("Enter coordinates for shoots thing x first then y after you hit enter");
            // Console.ReadLine();
            // int shotx = int.Parse(Console.ReadLine());
            Console.ReadKey();
            // int shoty = int.Parse(Console.ReadLine());
            // if (shot = Cell.LiveBoat) {


            // }




        }
    }
}
