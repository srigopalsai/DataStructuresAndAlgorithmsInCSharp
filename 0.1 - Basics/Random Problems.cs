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

        // 231 https://leetcode.com/problems/power-of-two
        public bool IsPowerOfTwo(int n)
        {
            if (n == 0)
                return false;

            while (n % 2 == 0)
                n /= 2;

            return (n == 1);
        }

        // 326 https://leetcode.com/problems/power-of-three/discuss/
        public bool IsPowerOfThree(int n)
        {
            if (n == 0)
                return false;

            while (n % 3 == 0)
                n /= 3;

            return (n == 1);
        }

        int Max3PowerInt = 1162261467; // 3^19, 3^20 = 3486784401 > MaxInt32
        int MaxInt32 = 2147483647; // 2^31 - 1
        bool IsPowerOfThreeConst(int n)
        {
            if (n <= 0 || n > Max3PowerInt) return false;
            return Max3PowerInt % n == 0;
        }

        // 342 https://leetcode.com/problems/power-of-four/discuss/

        public bool IsPowerOfFour(int n)
        {
            if (n == 0)
                return false;

            while (n % 4 == 0)
                n /= 4;

            return (n == 1);
        }

        public bool IsPowerOfFourConst(int num)
        {
            return num > 0 && (num & (num - 1)) == 0 && (num & 0x55555555) != 0;
            //0x55555555 is to get rid of those power of 2 but not power of 4
            //so that the single 1 bit always appears at the odd position 
        }
    }
}
