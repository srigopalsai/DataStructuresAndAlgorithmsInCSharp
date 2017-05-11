using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    1) XOR all the array elements, let the result of XOR be X1.
    2) XOR all numbers from 1 to n, let XOR be X2. 
    3) XOR of X1 and X2 gives the missing number.

    Time Complexity: O(n)

    In method 1, if the sum of the numbers goes beyond maximum allowed integer, then there can be integer overflow and we may not get correct answer. Method 2 has no such problems.

    http://www.geeksforgeeks.org/find-the-missing-number/
    */
    class Missing_Number_in_Array
    {

        /* getMissingNo takes array and size of array as arguments*/
        int getMissingNo(int[] a, int n)
        {
            int i;
            int x1 = a[0]; /* For xor of all the elemets in arary */
            int x2 = 1; /* For xor of all the elemets from 1 to n+1 */

            for (i = 1; i < n; i++)
            {
                x1 = x1 ^ a[i];
            }
            for (i = 2; i <= n + 1; i++)
            {
                x2 = x2 ^ i;
            }
            return (x1 ^ x2);
        }

        /*program to test above function */
        void main()
        {
            int[] a = { 1, 2, 4, 5, 6 };
            int miss = getMissingNo(a, 5);
        }
    }
}