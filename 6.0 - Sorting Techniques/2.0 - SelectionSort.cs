using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{

    /*
    http://en.wikipedia.org/wiki/Selection_sort

    Time Complexity : Best, Average, Worst O(N^2) Space O(N)
    Space : O(1)

     * Selection sort makes n-1 passes over the data, finding the largest remaining value on each pass. 
       A common optimization is that the index of the potentially largest element is saved, so that at the end of a pass, an exchange (swap) only needs to be done once.
     
     Advantage:

     * Performs well on a small list. 
     * In-place sorting algorithm - No additional temporary storage is required beyond what is needed to hold the original list. 

     Disadvantage:
     
     * Poor efficiency when dealing with a huge list of items. 
     * Similar to the bubble sort, the selection sort requires n^2 steps for sorting n elements. 
     * Its performance is easily influenced by the initial ordering of the items before the sorting process. 
     
     When to use :
     
     * Suitable for a list of few elements that are in random order.
    
    An online algorithm is one that can process its input piece-by-piece in a serial fashion, i.e., in the order that the input is fed to the algorithm, without having the entire input available from the start. 
    In contrast, an offline algorithm is given the whole problem data from the beginning and is required to output an answer which solves the problem at hand. 
    E.g. selection sort requires that the entire list be given before it can sort it, while insertion sort doesn't.

    http://www.algolist.net/Algorithms/Sorting/Selection_sort
    http://stackoverflow.com/questions/12887629/efficency-of-insertion-sort-vs-bubble-sort-vs-selection-sort
    http://stackoverflow.com/questions/4043861/straight-selection-sort-vs-exchange-selection-sort
    Nice Explanation : http://www.cs.ucf.edu/~dmarino/ucf/cop3502/lec_biswas/search_sort.pdf
    
    */
    partial class SortingSamples
    {
        public int[] SelectionSort(int[] listToSort)
        {
            int NoOfElements = listToSort.Length;
            int[] list = new int[NoOfElements];

            //Copy to new array so that soruce array will not be changed.
            listToSort.CopyTo(list, 0);
            
            int passIndex = 0;
            int innerLoopIndex = 0;
            int selectedSmallestElementIndex;

            for (passIndex = 0; passIndex < (NoOfElements - 1); passIndex++)
            {
                // Assume this is smallest element position. Note: Starts from Zero element to n -1.
                selectedSmallestElementIndex = passIndex;

                // Find the smallest in remaining elements in the array.
                for (innerLoopIndex = passIndex + 1; innerLoopIndex < NoOfElements; innerLoopIndex++)
                {
                    //If any element in the array is less than smallest element swap it. 
                    if (list[innerLoopIndex] < list[selectedSmallestElementIndex])
                    {
                        selectedSmallestElementIndex = innerLoopIndex;
                    }
                }

                if (selectedSmallestElementIndex != passIndex)
                {
                    //--- Swap smallest remaining element
                    Common.Swap(ref list[selectedSmallestElementIndex], ref list[passIndex]);
                    
                }
            }
            return list;
        }

        public void SelectionSortTest()
        {
            displayMessage = "Selection Sort:\n";

            int[] SortedArray = SelectionSort(BestCaseNearlySortedArry);
            displayMessage += GetResultString(BestCaseNearlySortedArry, SortedArray, "Best Case Scenario. " + QuadraticTime);

            SortedArray = SelectionSort(AverageCaseFewSortedArry1);
            displayMessage += GetResultString(AverageCaseFewSortedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Average Case Scenario. " + QuadraticTime);

            SortedArray = SelectionSort(WorstCaseReversedArry1);
            displayMessage += GetResultString(WorstCaseReversedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Worst Case Scenario. " + QuadraticTime);

            MessageBox.Show(displayMessage);
        }
    }
}
/* Using Recursion :

public static int findMin(int[] array, int index)
{
    int min = index - 1;
    if (index < array.length - 1)
        min = findMin(array, index + 1);
    if (array[index] < array[min])
        min = index;
    return min;
}
 
public static void selectionSort(int[] array)
{
    selectionSort(array, 0);
}
 
public static void selectionSort(int[] array, int left)
{
    if (left < array.length - 1)
    {
        Common.Swap(array, left, findMin(array, left));
        selectionSort(array, left+1);
    }
}
 
public static void Common.Swap(int[] array, int index1, int index2)
{
    int temp = array[index1];
    array[index1] = array[index2];
    array[index2] = temp;
}
*/