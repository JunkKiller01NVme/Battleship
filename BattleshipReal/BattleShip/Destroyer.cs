using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Destroyer
    {
        public int numberOfCurrentHits;
        public int size = 4;
        public int xAxis;
        public int yAxis;
        public bool vertical;
        public bool fliped;

        


        

        public Destroyer(int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;
            


        }


    }
}
