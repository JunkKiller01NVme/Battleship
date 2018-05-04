using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class SpeedBoat
    {

        public int size = 2;
        public int xAxis ;
        public int yAxis ;
        public bool vertical;
        



       


        public SpeedBoat(int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;


            Random random = new Random();
            int b = random.Next(0,2);

            if (b == 0)
            {
                vertical = true;
            }
            else {

                vertical = false;

            }

        }

       


    }
}
