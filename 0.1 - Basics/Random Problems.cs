using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class RandomProblems
    {
        public bool IsPerfectSquare(long number)
        {
            if (number <= 0)
                return false;

            if (number == 1)
                return true;

            long leftIndx = 1;
            long rightIndx = number;

            while (leftIndx <= rightIndx)
            {
                long midIndx = leftIndx + (rightIndx - leftIndx) / 2;
                long square = midIndx * midIndx;

                if (square == number)
                    return true;
                else if (square > number)
                    rightIndx = midIndx - 1;
                else
                    leftIndx = midIndx + 1;
            }

            return false;
        }
    }
}
