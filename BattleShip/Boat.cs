﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Boat
    {
        public int numberOfCurrentHits;
        public int size = 3;
        public int xAxis = 2;
        public int yAxis = 5;
        public bool vertical;
        public bool fliped;
        // trash code
        #region
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


        public enum Cell { Water, LiveBoat, HitBoat, SunkBoat };

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
        #endregion

        public Boat(int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;
            Cell[,] SeaArray = new Cell[10, 10];
            SeaArray[xAxis, yAxis] = Cell.LiveBoat;


        }
    }
}
