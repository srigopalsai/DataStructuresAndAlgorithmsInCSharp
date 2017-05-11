using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class Point
    {
        public int xPos { get; set; }

        public int yPos { get; set; }

        Point PreviousPoint { get; set; }

        public Point() { }

        public Point(int x, int y, Point prevPoint)
        {
            this.xPos = x;
            this.yPos = y;
            this.PreviousPoint = prevPoint;
        }

        public Point GetPreviousPoint()
        {
            return this.PreviousPoint;
        }

        public static bool IsSafePoint(int[,] matrix, int xPos, int yPos, int safeVal = 1)
        {
            if (xPos >= 0 && xPos < matrix.GetLength(0) &&
                yPos >= 0 && yPos < matrix.GetLength(1) &&
                matrix[xPos, yPos] == safeVal)
            {
                return true;
            }
            return false;
        }
    }
}
