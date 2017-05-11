using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://www.dsalgo.com/2013/02/next-power-of-two.html
    */
    public class NextPowerOfTwo
    {
        public static void main(String[] args)
        {
            long num = 128;
            long result = findNextPowerOfTwo(num);
            Console.WriteLine(result);
        }

        private static long findNextPowerOfTwo(long num)
        {
            long result = 1;
            while (num != 0)
            {
                num >>= 1;
                result <<= 1;
            }
            return result;
        }
    }

}
