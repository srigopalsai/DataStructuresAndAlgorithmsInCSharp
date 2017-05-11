using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    If we XOR a number with itself odd  number of times the result is 0. 
    If we XOR a number with itself even number of times the result is the number itself.

    So, if we XOR all the elements in the array, the result is the odd occurring element itself. 
    
    Because all even occurring elements will be XORed with themselves odd number of times, producing 0. 
    And the only odd occurring element will be XORed with itself even number of times, producing its own value . 
    Also XOR of an element with 0 gives the element itself.

    http://www.geeksforgeeks.org/find-the-number-occurring-odd-number-of-times/

    =======================================================================================================================================================================================================
    */

    partial class BinaryAndBitwiseOperations
    {
        public void NumberOccurringOddNumberOfTimesTest()
        {
            int[] ar = { 2, 3, 5, 4, 5, 2, 4, 3, 5, 2, 4, 4, 2 };
            int result = NumberOccurringOddNumberOfTimes(ar);

            MessageBox.Show("Number Occurring Odd Number Of Times " + result);
        }

        int NumberOccurringOddNumberOfTimes(int[] ar)
        {
            int i;
            int res = 0;

            for (i = 0; i < ar.Length; i++)
            {
                res = res ^ ar[i];
            }
            return res;
        }
    }
}