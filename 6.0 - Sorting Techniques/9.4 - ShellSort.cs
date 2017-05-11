using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._6___Sorting_Techniques
{
    /*

    ===========================================================================================================================================================================================

    Shellsort is a sequence of interleaved insertion sorts based on an increment sequence. 
    The increment size is reduced after each pass until the increment size is 1. 
    
    With an increment size of 1, the sort is a basic insertion sort, but by this time the data is guaranteed to be almost sorted, which is insertion sort's "best case". 
    Any sequence will sort the data as long as it ends in 1, but some work better than others. 
    Empirical studies have shown a geometric increment sequence with a ratio of about 2.2 work well in practice
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Not Stable.
    In Place.
    Comparison.

    Can be seen as either a generalization of sorting by exchange (bubble sort) or sorting by insertion (insertion sort).
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    The running time of Shellsort is heavily dependent on the gap sequence it uses.

    Best Case   : O(n log n)
    Worst Case  : O(n^2)
    Space       : O(1)  - Worst Case : O(n)
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Uses :
    Shellsort is now rarely used in serious applications. It performs more operations and has higher cache miss ratio than quicksort. 
    However, since it can be implemented using little code and does not use the call stack, some implementations of the qsort function in the C standard library targeted at embedded systems use it instead of quicksort.

    ===========================================================================================================================================================================================
    
    http://en.wikipedia.org/wiki/Shell_sort
    http://www.codecodex.com/wiki/Shell_sort
    http://rosettacode.org/wiki/Sorting_algorithms/Shell_sort
    http://www.sanfoundry.com/c-program-perform-shell-sort-without-using-recursion/

    ===========================================================================================================================================================================================
    */
    class ShellSort
    {
        public static void Sort(int[] list)
        {
            int n = list.Length;

            int[] incs = { 1, 3, 7, 21, 48, 112, 336, 861, 1968, 4592, 13776, 33936, 86961, 198768, 463792, 1391376, 3402672, 8382192, 21479367, 49095696, 114556624, 343669872, 52913488, 2085837936 };

            for (int l = incs.Length / incs[0]; l > 0; )
            {
                int m = incs[--l];

                for (int i = m; i < n; ++i)
                {
                    int j = i - m;

                    if (list[i].CompareTo(list[j]) < 0)
                    {
                        int tempItem = list[i];
                        
                        do
                        {
                            list[j + m] = list[j];
                            j -= m;
                        } 
                        while ((j >= 0) && (tempItem.CompareTo(list[j]) < 0));

                        list[j + m] = tempItem;
                    }
                }
            }
        }


        void shellSort(int[] numbers, int array_size)
        {
            int i;
            int j;
            int increment;
            int temp;

            increment = array_size / 2;
            while (increment > 0)
            {
                for (i = 0; i < array_size; i++)
                {
                    j = i;
                    temp = numbers[i];
                    while ((j >= increment) && (numbers[j - increment] > temp))
                    {
                        numbers[j] = numbers[j - increment];
                        j = j - increment;
                    }
                    numbers[j] = temp;
                }

                if (increment == 2)
                {
                    increment = 1;
                }
                else
                {
                    increment = increment * 5 / 11;
                }
            }
        }

    }
}
