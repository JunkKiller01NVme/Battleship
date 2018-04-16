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
            
            

            //string hit = "Hit";
            //string miss = "miss";
            
       // }
        //this methods job is to place the ships... problem is that we cant figure out how to use mcculloughs code to our advantage.
        void Placeships() {
            Random rnd = new Random();
            int xax = rnd.Next(0, 11);
            Random rmd = new Random();
            int yax = rmd.Next(0, 11);

            SpeedBoat speedBoat = new SpeedBoat(xax, yax);
           //SeaArray[0, 2] = Cell.LiveBoat;

        }

        
        
    
        
        static void Main(string[] args)
        {
            BattleShip b = new BattleShip();
            b.Run();
            /*Make the sea array... then make ships.
             * make it so the ships can be placed.
             * then make it so they can be attacked and stored where and what health they have.
             
            
                */





            

            
           // b.Menu();
            b.PlayingBoard();


            //Console.WriteLine(BoardToString(SeaArray));
            //Working on the if statements on if there is a ship there where you shoot
            Console.WriteLine("Enter coordinates for shoots thing x first then y after you hit enter");
            Console.ReadLine();
           // int shotx = int.Parse(Console.ReadLine());
            Console.ReadLine();
            // int shoty = int.Parse(Console.ReadLine());
            // if (shot = Cell.LiveBoat) {


            // }
          

            Console.ReadKey();

        }
    }
}
