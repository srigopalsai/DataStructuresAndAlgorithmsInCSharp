using System;
using System.Collections.Generic;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===========================================================================================================================================================================================

    Lower Bound - Best Case O(n)
    Average and 
    Upper Bound - Worst Case O(N^2)

    Space               : O(1) - In Place
    No Of Comparisions  : O(n^2)
    No Of Swaps         : O(n^2)

    Adaptive            : Yes - If it takes advantage of existing order in its input
    Stability           : Yes - When sorting some kinds of data, only part of the data is examined when determining the sort order
    Comparision Sort    : Yes
    
    ===========================================================================================================================================================================================
    
    Features

    1. Popular and easy to implement. 
    2. Elements are swapped in place without using additional memory storage.
    3. Does not deal well with a list containing a huge number of items. 

    Cocktail sort, also known as Bi Directional Bubble Sort, Cocktail Shaker Sort.
    Shaker Sort (which can also refer to a variant of Selection Sort), Ripple Sort, Shuffle Sort, Shuttle Sort or Happy Hour Sort, is a variation of bubble sort that is both a stable sorting algorithm and a comparison sort. 
    
    For every iteration of upper loop 1 element will be sorted.
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    References :

    http://en.wikibooks.org/wiki/Algorithm_implementation/Sorting/Bubble_sort
    http://en.wikipedia.org/wiki/Bubble_sort

    ===========================================================================================================================================================================================
    */

    public partial class SortingSamples
    {
        public int[] BubbleSort(int[] listToSort)
        {
            int arrayLen = listToSort.Length;
            int[] list = new int[arrayLen];
            //Copy to new array so that soruce array will not be changed.
            Array.Copy(listToSort, list, listToSort.Length);

            bool hasSwaps = false;

            for (int passIndex = 1; passIndex < arrayLen; passIndex++)
            {
                // Inner loop becomes shorter every time as the largest elements are being moved to the end of the array. This is called Optimizing bubble sort.
                for (int innerLoopIndex = 0; innerLoopIndex < (arrayLen - passIndex); innerLoopIndex++)
                {
                    if (list[innerLoopIndex] > list[innerLoopIndex + 1])
                    //if (list[innerLoopIndex].CompareTo(list[innerLoopIndex + 1]) > 0)
                    {
                        hasSwaps = true;
                        Common.Swap(ref list[innerLoopIndex], ref list[innerLoopIndex + 1]);
                    }
                }
                if (hasSwaps == false)
                    break;
                else
                    hasSwaps = false;
            }
            return list;
        }
        public void BubbleSortTest()
        {
            displayMessage = "Bubble Sort:\n";

            resultArrayString.Clear();

            int[] SortedArray = BubbleSort(BestCaseNearlySortedArry);
            displayMessage += GetResultString(BestCaseNearlySortedArry, SortedArray, "Best Case Scenario. " + LinearTime);

            SortedArray = BubbleSort(AverageCaseFewSortedArry1);
            displayMessage += GetResultString(AverageCaseFewSortedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Average Case Scenario. " + QuadraticTime);

            SortedArray = BubbleSort(WorstCaseReversedArry1);
            displayMessage += GetResultString(WorstCaseReversedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Worst Case Scenario. " + QuadraticTime);

            MessageBox.Show(displayMessage);
        }

        // Generic Type
        void BubbleSort<T>(IList<T> array) where T : IComparable<T>
        {
            int i, j;
            T temp;

            for (i = array.Count - 1; i > 0; i--)
            {
                for (j = 0; j < i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        temp = array[j];
                        
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}