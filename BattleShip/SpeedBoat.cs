﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class SpeedBoat
    {

        public int numberOfCurrentHits;
        public int size = 2;
        public int xAxis ;
        public int yAxis ;
        public bool vertical;
        public bool fliped;
        



       


        public SpeedBoat(int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;


            Random random = new Random();
            int b = random.Next(1);

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
