using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===========================================================================================================================================================================================

    O(m log n) m - Total Sum of elements for all lists. n - no of elements in each list.
        http://www.dsalgo.com/2013/02/merge-two-sorted-arrays-in-single-array.html
        http://en.wikipedia.org/wiki/Merge_algorithm
        http://www.algolist.net/Algorithms/Merge/Sorted_arrays
        http://stackoverflow.com/questions/11947315/why-merge-operation-in-merge-sort-is-on/11947537#11947537

        http://www.geeksforgeeks.org/merge-k-sorted-arrays/
    ===========================================================================================================================================================================================
     */
    class MergeSortedArrays
    {
        // Not implemented completely yet.
        public int[] Merge2SortedArrays(int[] leftArray, int[] rightArray)
        {

            int leftArrayEnd = leftArray.Length - 1;
            int rightArrayEnd = rightArray.Length - 1;

            int leftArrayBegin = 0;
            int rightArrayBegin = 0;

            int numElements = leftArray.Length + rightArray.Length;

            int[] resultArray = new int[numElements];
            int resultArrayBegin = 0;

            // Find the smallest element in both these array and add it to the temp array i.e you may have a array of the form [1,5] [2,4]
            // We need to sort the above as [1,2,4,5]
            while (leftArrayBegin <= leftArrayEnd && rightArrayBegin <= rightArrayEnd)
            {
                if (leftArray[leftArrayBegin] <= rightArray[rightArrayBegin])
                {
                    resultArray[resultArrayBegin++] = leftArray[leftArrayBegin++];
                }
                else
                {
                    resultArray[resultArrayBegin++] = rightArray[rightArrayBegin++];
                }
            }

            // After the main loop completed we may have few more elements in left array so copy them
            while (leftArrayBegin <= leftArrayEnd)
            {
                resultArray[resultArrayBegin++] = leftArray[leftArrayBegin++];
            }

            // After the main loop completed we may have few more elements in right array so copy them
            while (rightArrayBegin <= rightArrayEnd)
            {
                resultArray[resultArrayBegin++] = rightArray[rightArrayBegin++];
            }

            return resultArray;
        }
    }
}