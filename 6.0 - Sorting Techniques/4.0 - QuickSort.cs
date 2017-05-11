using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    /*
    The quick sort works on the Divide and Conquer Algorithms. 
    First, it partitions the list of items into two sublists based on a pivot element. 
        
    All elements in the first sublist are arranged to be smaller than the pivot, while all elements in the second sublist are arranged to be larger than the pivot. 
        
    The same partitioning and arranging process is performed repeatedly on the resulting sublists until the whole list of items are processed.

    In-Place Algorithm.
    Worst Case - N X N

    Element may be exchanged multiple times before reaching its final place. 
    Also, in case of pivot duplicates in the input array, they can be spread across the right subarray, in any order. 
    This doesn't represent a partitioning failure, as further sorting will reposition and finally "glue" them together.
        
    Each recursive call to the combined quicksort function reduces the size of the array being sorted by at least one element.
    Since in each invocation the element at pivotNewIndex is placed in its final position. 
    Therefore, this algorithm is guaranteed to terminate after at most n recursive calls. 
        
    However, since partition reorders elements within a partition, this version of quicksort is not a stable sort

    The quick sort is regarded as the best sorting algorithm. 
    This is because of its significant advantage in terms of efficiency because it is able to deal well with a huge list of items. 
    It is the most effective and widely used method of sorting a list of any item size.
        
    The element a[i] is in its final place in the array for i. 
    • None of the elements a[left], ..., a[i-1] is greater than a[i]. 
    • None of the elements in a[i+1], ..., a[right] is less than a[i]. 

    Worst Case : 
    1.All elements of array are same.
    2.Array is already sorted in same order.
    3.Array is already sorted in reverse order.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    With QuickSort, the complexity always comes down to two things:

    how you deal with equal numbers (duplicates)
    which index you use to return from the partition (left or right)
    You need to decide up-front whether the pivot value is going to be in the left partition, or the right partition. 
    If the pivot is going to be in the left, then you need to return left index, and the left partition is values <= the pivot.

    ============================================================================================================================================================================================================================

    Time Complexity Calculation : 
	
    1. Using Recurrence Relation :


    ============================================================================================================================================================================================================================

    Note : 
    Quicksort has its worst performance, if the pivot is likely to be either the smallest, or the largest element in the list (e.g. the first or last element of an already sorted list).
    If, e.g. you choose the middle element of the list, an already sorted list does not have the worst case runtime.

    http://en.wikipedia.org/wiki/Quicksort

    Quick Sort Vs QSort in C Standard Library :
    Implements a polymorphic sorting algorithm for arrays of arbitrary objects according to a user-provided comparison function. 
    It is named after the quicksort algorithm, which was originally used to implement it in the Unix C library, although the C standard does not require it to implement quicksort
    http://en.wikipedia.org/wiki/Qsort
    TODO Iterative (Using stack) Quick Sort https://github.com/mission-peace/interview/blob/master/src/com/interview/sort/IterativeQuickSort.java
    ============================================================================================================================================================================================================================

    References :
    http://www.opendatastructures.org/ods-java/11_1_Comparison_Based_Sorti.html
    http://www.codecodex.com/wiki/Quicksort
    https://www.youtube.com/watch?v=MxiQa22KrSQ
    http://www.algolist.net/Algorithms/Sorting/Quicksort
    http://alienryderflex.com/quicksort/   
    http://www.sorting-algorithms.com/static/QuicksortIsOptimal.pdf
    Hacker Rank code https://www.bing.com/search?q=quick+sort+example+java&form=EDGEAR&qs=SC&cvid=a295641012624cb1b201bd93ffd958e3&pq=quick+sort+sample&elv=AXXfrEiqqD9r3GuelwApulq8GsqK*ETxLhwZ7DZhLW4XMQAhkze25l1KQRYGVsOxqn8HYV0Z1SOemEd17gJjm%21DUnbnPD7b556UtenigNdJz

    Wiki Samples : http://rosettacode.org/wiki/Sorting_algorithms/Quicksort#C.23

    TODO : Need to refer 3-way Quick (in presence of duplicate keys.
    ============================================================================================================================================================================================================================
    */

    partial class SortingSamples
    {
        public void RunQuickSortTests()
        {
            TestData.TestCasesCount = 0;
            TestData.TestCasesFailed = 0;
            TestData.TestCasesPassed = 0;

            displayMessage = "Quick Sort :";

            int tcCnt = 0;

            foreach (int[] testArray in TestData.ArraysCollection.Values)
                QuickSortTest(testArray, ++tcCnt);
            //QuickSortTest(TestData.ArraysCollection[TestData.Keys.AverageCaseFewSortedArry6], 1);

            TestData.ShowResults(displayMessage);
        }

        public void QuickSortTest(int[] listToSort, int caseNo, bool ascending = true)
        {
            if (listToSort == null)
                return;

            TestData.TestCasesCount++;

            displayMessage += TestData.ConvertArrayToString(listToSort, string.Format("\n\n{0}. Source ", caseNo));

            QuickSort(listToSort, 0, listToSort.Length - 1);
            //QuickSortSelfRecursive(listToSort, 0, listToSort.Length - 1);

            displayMessage += TestData.ConvertArrayToString(listToSort, string.Format("\n{0}. Output ", caseNo));

            bool sortValid = TestData.ValidateSort(listToSort, ascending);
            if (sortValid == false)
            {
                displayMessage += " - *** Failed ***";
                TestData.TestCasesFailed++;
            }
            else
                TestData.TestCasesPassed++;
        }
 
        public void QuickSort(int[] listToSort, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivotIndex = PartitionAndSort(listToSort, startIndex, endIndex);

                QuickSort(listToSort, startIndex, pivotIndex - 1);
                QuickSort(listToSort, pivotIndex + 1, endIndex);
            }
        }

        int PartitionAndSort(int[] nums, int leftIndx, int rightIndx)
        {
            int lastSmallIndx = leftIndx;

            for (int lpCnt = leftIndx; lpCnt < rightIndx; lpCnt++)
            {
                if (nums[lpCnt] <= nums[rightIndx]) // Best way to pick Pivot is Median of start, mid and end.
                {
                    Common.Swap(nums, lpCnt, lastSmallIndx);
                    lastSmallIndx++;
                }
            }

            // Keep the pivot at the end of all sorted elements
            Common.Swap(nums, rightIndx, lastSmallIndx);

            return lastSmallIndx;
        }

        public void QuickSortSelfRecursive(int[] nums, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
                return;

            int leftIndx = startIndex;
            int rightIndx = endIndex;
            int lastSmallIndx = leftIndx;

            //int medianPos = Common.GetMedianPosition(nums, leftIndx, rightIndx); // Failing as not handling right side. need to fix

            for (int lpCnt = leftIndx; lpCnt < rightIndx; lpCnt++)
            {
                if (nums[lpCnt] <= nums[rightIndx]) // Best way to pick Pivot is Median of start, mid and end.
                {
                    Common.Swap(nums, lpCnt, lastSmallIndx);
                    lastSmallIndx++;
                }
            }

            // Keep the pivot at the end of all sorted elements
            Common.Swap(nums, rightIndx, lastSmallIndx);

            QuickSortSelfRecursive(nums, startIndex, lastSmallIndx - 1);
            QuickSortSelfRecursive(nums, lastSmallIndx + 1, endIndex);
        }

        // Using first element as pivot
        public void QuickSort2(int[] array, int startIndx, int endIndx)
        {
            if (startIndx < endIndx)                                // If there are at least two elements to sort. I.e. (endIndx - startIndx >= 1)
            {
                int pivotVal = array[startIndx];                    // set the pivot as the first element in the partition
                int leftIndx = startIndx;                           // index of left-to-right scan
                int rightIndx = endIndx;                            // index of right-to-left scan

                while (leftIndx < rightIndx)                        // while the scan indices from left and right have not met.
                {
                    while (array[leftIndx] <= pivotVal && leftIndx < rightIndx)    // from the left, look for the first element greater than the pivot
                        leftIndx++;

                    while (pivotVal < array[rightIndx] && leftIndx <= rightIndx)   // from the right, look for the first element not greater than the pivot
                        rightIndx--;

                    if (leftIndx < rightIndx)                       // if the leftIndx  is still smaller than the rightIndx, swap the corresponding elements
                        Common.Swap(array, leftIndx, rightIndx);
                }

                Common.Swap(array, startIndx, rightIndx);           // after the indices have crossed, swap the last element in the left partition with the pivot 

                QuickSort(array, startIndx, rightIndx - 1);         // quicksort the left partition
                QuickSort(array, rightIndx + 1, endIndx);           // quicksort the right partition
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //A very inefficient way to do qsort in C# to prove C# code can be just as compact and readable as any dynamic code 
        private static IEnumerable<IComparable> empty = new List<IComparable>();

        public static IEnumerable<IComparable> QSort(IEnumerable<IComparable> iEnumerable)
        {
            if (iEnumerable.Any())
            {
                var pivot = iEnumerable.First();

                return QSort(
                               iEnumerable.Where((anItem) => pivot.CompareTo(anItem) > 0)).
                        Concat(iEnumerable.Where((anItem) => pivot.CompareTo(anItem) == 0)).
                        Concat(
                         QSort(iEnumerable.Where((anItem) => pivot.CompareTo(anItem) < 0))
                               );
            }

            return empty;
        }
    }
}