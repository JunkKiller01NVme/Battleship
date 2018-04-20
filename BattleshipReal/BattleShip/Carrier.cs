using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Carrier
    {
        public int numberOfCurrentHits;
        public int size = 5;
        public int xAxis;
        public int yAxis;
        public bool vertical;
        public bool fliped;



        public Carrier(int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;



        }


    }
}
