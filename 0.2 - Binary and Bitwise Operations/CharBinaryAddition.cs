using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://www.careercup.com/question?id=10353662
    "1001"+"101"="1110"

    */
    class CharBinaryAddition
    {
        void Add_Num(int a, int b)
        {
            if (b == 0)
            {
                return;
            }

            int sum = a ^ b;
            int carry = (a & b) << 1;


            Add_Num(sum, carry);

        }
    }
}
