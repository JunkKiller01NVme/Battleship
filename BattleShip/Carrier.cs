using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Carrier
    {
        public int size = 5;
        public int xAxis;
        public int yAxis;
        public bool vertical;
        public Random random;
        
        public Carrier(int x, int y)
        {
            random = new Random();
            this.xAxis = x;
            this.yAxis = y;

            int b = random.Next(0, 2);

            if (b == 0)
            {
                vertical = true;
            }
            else
            {
                vertical = false;
            }
        }
    }
}
