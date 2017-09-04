using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*

    Performs the comparisons from left to right.
    Preprocessing : O(m) Space and Time Complexity
    Searching     : O(n+m) Time Complexity (independent from the alphabet size).
    Performs at most 2n-1 information gathered during the scan of the text.
    Delay bounded by m.
    
    */
    partial class StringAlgorithms
    {
        void MorrisPrattPreProcessing(string x, int m, int[] mpNext)
        {
            int i, j;

            i = 0;
            j = mpNext[0] = -1;

            while (i < m)
            {
                while (j > -1 && x[i] != x[j])
                {
                    j = mpNext[j];
                }
                mpNext[++i] = ++j;
            }
        }


        //void MorrisPrattSearch(string x, int m, string y, int n)
        //{
        //    int i, j;
        //    int[] mpNext;

        //    /* Preprocessing */
        //    MorrisPrattPreProcessing(x, m, mpNext);

        //    /* Searching */
        //    i = j = 0;
        //    while (j < n)
        //    {
        //        while (i > -1 && x[i] != y[j])
        //        {
        //            i = mpNext[i];
        //        }
        //        i++;
        //        j++;
        //        if (i >= m)
        //        {
        //            //         OUTPUT(j - i);
        //            i = mpNext[i];
        //        }
        //    }
        //}
    }
}