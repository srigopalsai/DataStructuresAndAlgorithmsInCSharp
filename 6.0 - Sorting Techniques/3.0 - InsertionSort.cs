using System;
using System.Windows;
namespace DataStructuresAndAlgorithms
{
    /*
    ===========================================================================================================================================================================================

    1. Simple.
    2. Best for Smaller Lists.
    3. Twice faster than Bubble Sort, 40% faster than Selection Sort.

    The insertion sorts repeatedly scans the list of items, each time inserting the item in the unordered sequence into its correct position.
    When humans manually sort something (E.g. a deck of playing cards), most use similar to insertion sort
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Lower Bound - Best Case O(n)   O(n + d), where d is the number of inversions (improper ordered elements http://en.wikipedia.org/wiki/Inversion_(discrete_mathematics)) 
    Average and 
    Upper Bound - Worst Case O(N)

    Space               : O(1) In-Place 
    No Of Comparisions  : O(n - 1) When list is sorted. Similar to Selection when list is sorted in reverse. 
    No Of Swaps         : O(n^2)

    Adaptive            : Yes - If it takes advantage of existing order in its input
    Stability           : Yes - Does not change the relative order of elements with equal keys
    Comparision Sort    : Yes

    The insertion sort is an in-place sorting algorithm so the space requirement is minimal. 
    The disadvantage of the insertion sort is that it does not perform as well as other, better sorting algorithms. 
    With n-squared steps required for every n element to be sorted, the insertion sort does not deal well with a huge list. 
    Therefore, the insertion sort is particularly useful only when sorting a list of few items.
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Big O Notation same as Bubble Sort.
    
    Wiki: http://en.wikipedia.org/wiki/Insertion_sort
    Graphysical Example: http://en.wikipedia.org/wiki/File:Insertion-sort-example-300px.gif

    An online algorithm is one that can process its input piece-by-piece in a serial fashion, i.e., in the order that the input is fed to the algorithm, without having the entire input available from the start. 
    In contrast, an offline algorithm is given the whole problem data from the beginning and is required to output an answer which solves the problem at hand. 
    E.g. selection sort requires that the entire list be given before it can sort it, while insertion sort doesn't.
    http://www.algolist.net/Algorithms/Sorting/Insertion_sort

    ===========================================================================================================================================================================================
       */
    partial class SortingSamples
    {
        public void InsertionSortTest()
        {
            int[] SortedArray = InsertionSort(BestCaseNearlySortedArry);
            displayMessage = GetResultString(BestCaseNearlySortedArry, SortedArray, "Best Case Scenario. " + LinearTime);

            SortedArray = InsertionSort(AverageCaseFewSortedArry1);
            displayMessage += GetResultString(AverageCaseFewSortedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Average Case Scenario. " + QuadraticTime);

            SortedArray = InsertionSort(WorstCaseReversedArry1);
            displayMessage += GetResultString(WorstCaseReversedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Worst Case Scenario. " + QuadraticTime);

            MessageBox.Show(displayMessage);

        }

        // Insertion Sort Algorithm
        int[] InsertionSort(int[] listToSort)
        {
            int NoOfElements = listToSort.Length;
            int[] list = new int[NoOfElements];

            //Copy to new array so that soruce array will not be changed.
            listToSort.CopyTo(list, 0);

            for (int iLoopCount = 1; iLoopCount < list.Length; iLoopCount++)
            {
                // Pick element to Comare. Here current element in the loop.
                int itemToCompare = list[iLoopCount];

                //Start the inner loop from the current element.
                int cLoopCount = iLoopCount;

                // Move all elements to their next cells which are grater than then current element.
                for (; cLoopCount > 0 && list[cLoopCount - 1] > itemToCompare; cLoopCount--)
                {
                    list[cLoopCount] = list[cLoopCount - 1];
                }

                list[cLoopCount] = itemToCompare;
            }
            return list;
        }
    }
}