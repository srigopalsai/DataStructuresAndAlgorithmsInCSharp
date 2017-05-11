using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://www.dsalgo.com/2013/02/CalculatePower.php.html
    */
    partial class BinaryAndBitwiseOperations
    {
        public static void CalculatePower(String[] args)
        {
            int x = 4;
            int y = 10;
            long power = x;
            long answer = 1;
 
            while (y != 0)
            {
                if ((y & 1) == 1)
                {
                    answer *= power;
                }
                y >>= 1;
                power *= power;
            }

            Console.WriteLine(answer);
        }
    }
}
