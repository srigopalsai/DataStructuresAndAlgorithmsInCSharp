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

        //Bubble sorts are O(N2) on the average (and worst), but have O(N) best case performance. 
        //The one efficient aspect of bubble sorts is that they can quit early if the elements are almost sorted. Selection sorts have O(N2) efficiency. 
        //If you need a faster sort, use Quicksort (best O(log N), average O(log N), worst O(N2)) or heap sort (best, average, and worst are all O(log N)) in the library. 
        //Note : O(log N) can be MUCH better than O(N)

        //Fixed number of passes
        //It makes a fixed number of passes (length of the array - 1). 
        //Each inner loop is one shorter than the previous one because the largest elements are being moved to the end of the array. 
        public static void bubbleSort1(int[] x, int n)
        {
            for (int pass = 1; pass < n; pass++)
            {
                // count how many times
                // This next loop becomes shorter and shorter
                for (int i = 0; i < n - pass; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        // exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                    }
                }
            }
        }

        //Stop when no exchanges
        //This version of bubble sort continues making passes over the array as long as there were any exchanges. 
        //If the array is already sorted, this sort will stop after only one pass. 
        //Disadvantage: This algorithm doesn't shorten the range each time by 1 as it could. See below. 
        public static void bubbleSort2(int[] x, int n)
        {
            bool exchanges;
            do
            {
                exchanges = false;  // assume no exchanges
                for (int i = 0; i < n - 1; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        exchanges = true;  // after exchange, must look again
                    }
                }
            } while (exchanges);
        }

        //Stop when no exchanges, shorter range each time
        //This version of bubble sort combines ideas from the previous versions. 
        //It stops when there are no more exchanges, and it also sorts a smaller range each time
        //Disadvantage: After the first pass it may not be necessary to examine the entire range of the array -- 
        //only from where the lowest exchange occurred to where the highest exchange occurred. 
        //The parts above and below must already be sorted. See below. 
        public static void bubbleSort3(int[] x, int n)
        {
            bool exchanges;
            do
            {
                n--;               // make loop smaller each time.
                exchanges = false; // assume this is last pass over array
                for (int i = 0; i < n; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        exchanges = true;  // after an exchange, must look again 
                    }
                }
            } while (exchanges);
        }

        //Sort only necessary range
        //Here's a version of bubble sort that, on each pass, looks only at the region of array where more exchanges might be necessary. 
        // After a pass in bubble sort, it's only necessary to sort from just below the first exchange (small values may move lower)
        // to just before the last exchange (largest values won't move higher). 
        // Everything that wasn't exchanged must be in the correct order. 
        // After each pass, the upper and lower bounds for the next pass are set from the positions of the first and last exchanges on prev pass.
        //Disadvantage: Notice that the largest unsorted element will always be moved all the way to its correct position in the array, but small elements are shifted down by only one place on each pass. 
        public static void bubbleSortRange(int[] x, int n)
        {
            int lowerBound = 0;    // First position to compare.
            int upperBound = n;    // First position NOT to compare.

            //--- Continue making passes while there is a potential exchange.
            while (lowerBound <= upperBound)
            {
                int firstExchange = n;  // assume impossibly high index for low end.
                int lastExchange = -1; // assume impossibly low index for high end.

                //--- Make a pass over the appropriate range.
                for (int i = lowerBound; i < upperBound; i++)
                {
                    if (x[i] > x[i + 1])
                    {
                        //--- exchange elements
                        int temp = x[i];
                        x[i] = x[i + 1];
                        x[i + 1] = temp;
                        //--- Remember first and last exchange indexes.
                        if (i < firstExchange)
                        { // true only for first exchange.
                            firstExchange = i;
                        }
                        lastExchange = i;
                    }
                }

                //--- Prepare limits for next pass.
                lowerBound = firstExchange - 1;
                if (lowerBound < 0)
                {
                    lowerBound = 0;
                }
                upperBound = lastExchange;
            }
        }
    }
}