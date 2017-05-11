using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/Odd-even_sort
    is a relatively simple sorting algorithm, developed originally for use on parallel processors with local interconnections. It is a comparison sort related to bubble sort, with which it shares many characteristics
    //  Odd–Even sort or Odd–Even Transposition Sort also known as Brick Sort 
    
        Worst case performance          O(n^2) 
        Best case performance           O(n) 
        Worst case space complexity     O(1) 

     */
    partial class SortingSamples
    {
        public void OddEvenOrBrickSortTest()
        {
            int[] SortedArray = OddEvenOrBrickSort(BestCaseNearlySortedArry);
            displayMessage = GetResultString(BestCaseNearlySortedArry, SortedArray, "Best Case Scenario. " + LinearTime);

            SortedArray = OddEvenOrBrickSort(AverageCaseFewSortedArry1);
            displayMessage += GetResultString(AverageCaseFewSortedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Average Case Scenario. " + QuadraticTime);

            SortedArray = OddEvenOrBrickSort(WorstCaseReversedArry1);
            displayMessage += GetResultString(WorstCaseReversedArry1, SortedArray, Environment.NewLine + Environment.NewLine + "Worst Case Scenario. " + QuadraticTime);

            MessageBox.Show(displayMessage);
        }
        public int[] OddEvenOrBrickSort(int[] listToSort)
        {
            int NoOfElements = listToSort.Length;
            int[] listOfElements = new int[NoOfElements];

            //Copy to new array so that soruce array will not be changed.
            listToSort.CopyTo(listOfElements, 0);

            bool IsSorted = false;

            while (!IsSorted)
            {
                IsSorted = true;
                for (int lpOddCntr = 1; lpOddCntr < listOfElements.Length - 1; lpOddCntr += 2)
                {
                    if (listOfElements[lpOddCntr] > listOfElements[lpOddCntr + 1])
                    {
                        SwapElements(listOfElements, lpOddCntr, lpOddCntr + 1);
                        IsSorted = false;
                    }
                }

                for (int lpEvenCntr = 0; lpEvenCntr < listOfElements.Length - 1; lpEvenCntr += 2)
                {
                    if (listOfElements[lpEvenCntr] > listOfElements[lpEvenCntr + 1])
                    {
                        SwapElements(listOfElements, lpEvenCntr, lpEvenCntr + 1);
                        IsSorted = false;
                    }
                }
            }
            return listOfElements;
        }
        private static void SwapElements(int[] inputArray, int xPos, int yPos)
        {
            int temp = inputArray[xPos];
            inputArray[xPos] = inputArray[yPos];
            inputArray[yPos] = temp;
        }
    }
}