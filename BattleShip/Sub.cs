using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Sub
    {
        public int numberOfCurrentHits;
        public int size = 3;
        public int xAxis;
        public int yAxis;
        public bool vertical;
        public bool fliped;
        

        public Sub(int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;
            


        }



    }
}
