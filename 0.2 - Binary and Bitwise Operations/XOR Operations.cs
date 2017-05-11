using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._0._2___Binary_and_Bitwise_Operations
{
    class XOR_Operations
    {
        /*
        http://en.wikipedia.org/wiki/XOR_swap_algorithm
        */
        public void XORSwapAlgorithm(int x, int y)
        {
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;
        }
    }
}
