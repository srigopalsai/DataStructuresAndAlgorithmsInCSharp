using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /* 
    ===========================================================================================================================================================================================
    Counting Sort : 

	Input   :   int arrayA - An array that contains the data to be sorted.
	            int k - An integer representing the largest input value.
	Output  :   int* - The function returns a pointer to the original array with the sorted output.

    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Count Sort is linear sorting algorithm that does not use any comparison operator (>, <, >= , <= , ==) to determine the sorting order of the elements. 
    The sorting is achieved by acute logic build.

    Does not work for negative numbers.
    Assumes that each element is SMALL Integer.

    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Time    : O(Max Value - Min Value) which is linear. So it is useful when the difference is NOT large.

    Note    : Though we used 4 loops linear 4 X O(n) Below. In Big O we will consider it as O(n). So the total running time is O(n)
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    References :
    http://en.wikipedia.org/wiki/Counting_sort
    http://rosettacode.org/wiki/Sorting_algorithms/Counting_sort#C.23
    http://www.cse.iitk.ac.in/users/dsrkg/cs210/html/lectures.htm
    https://www.youtube.com/watch?v=o3FUC6l89tM
    https://www.youtube.com/channel/UCWzSgIp_DYRQnEsJuH32Fww/videos
    ===========================================================================================================================================================================================    
    */
    partial class SortingSamples
    {
        public void CountingSortTest()
        {
            resultArrayString.Clear();
            resultArrayString.Append("Count Sort : \n");

            int[] listToSort;

            //-----------------------------------------------------------------------------------------------------------------------------------------------------
            //int[] GenCaseArry = new int[] { 30, 20, 40, 10, 90, 160, 140, 100, 80, 70 };
            int[] GenCaseArry = new int[] { 6, 4, 2, 12, 8, 10 };

            listToSort = new int[GenCaseArry.Length];
            GenCaseArry.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nGeneral Case", GenCaseArry);
            CountingSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[BestCaseNearlySortedArry.Length];
            BestCaseNearlySortedArry.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nBest Case\t", BestCaseNearlySortedArry);
            CountingSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[AverageCaseFewSortedArry1.Length];
            AverageCaseFewSortedArry1.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nAverage Case 1", AverageCaseFewSortedArry1);
            CountingSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[AverageCaseFewSortedArry2.Length];
            AverageCaseFewSortedArry2.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nAverage Case 2", AverageCaseFewSortedArry2);
            CountingSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[WorstCaseReversedArry1.Length];
            WorstCaseReversedArry1.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nWorst Case 1", WorstCaseReversedArry1);
            CountingSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[WorstCaseFewDuplsArry2.Length];
            WorstCaseFewDuplsArry2.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nWorst Case 2", WorstCaseFewDuplsArry2);
            CountingSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[WorstCaseMoreDuplsArry3.Length];
            WorstCaseMoreDuplsArry3.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nWorst Case 3", WorstCaseMoreDuplsArry3);
            CountingSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            ShowResultString();
        }
        public void CountingSort(int[] sourceArray)
        {
            // Calculate the length of sourceArray.
            int lpCnt = 0;
            int sourceArrayLength = sourceArray.Length;

            // Get the max element from the source Array.
            int maxElementInArray = 0;
            for (lpCnt = 0; lpCnt < sourceArray.Length; lpCnt++)
            {
                if (maxElementInArray < sourceArray[lpCnt])
                {
                    maxElementInArray = sourceArray[lpCnt];
                }
            }

            //-------------------------------------------------------------------------------------------------------------------

            // Declare a new countArray and Initialize the elments of that array to 0.
            int[] countArray = new int[maxElementInArray + 1];
            int elementCnt = 0;

            // Count the number of each number and place that value into the countArray.
            for (lpCnt = 0; lpCnt < sourceArrayLength; lpCnt++)
            {
                elementCnt = countArray[sourceArray[lpCnt]];
                countArray[sourceArray[lpCnt]] = elementCnt + 1;
                // OR countArray[sourceArray[lpCnt]] += 1;
            }

            //Place the number of elements less than each value at i into countArray.

            for (lpCnt = 1; lpCnt < countArray.Length; lpCnt++)
            {
                countArray[lpCnt] = countArray[lpCnt] + countArray[lpCnt - 1];
            }

            //-------------------------------------------------------------------------------------------------------------------

            // Declare a new array sortedArray. sortedArray holds the sorted output.
            int[] sortedArray = new int[sourceArrayLength];

            int sourceArrElement = 0;
            int countArrElement = 0;

            //Place each element of sourceArray into its correct sorted position in the output sortedArray.
            for (lpCnt = sourceArrayLength - 1; lpCnt >= 0; lpCnt--)
            {
                sourceArrElement = sourceArray[lpCnt];
                countArrElement = countArray[sourceArrElement];

                sortedArray[countArrElement - 1] = sourceArrElement;

                // Below logic is Important when there are duplicates in input array. Reduce the count 
                //countArray[sourceArrElement] = countArrElement - 1;
                countArray[sourceArray[lpCnt]] -= 1;

            }

            //-------------------------------------------------------------------------------------------------------------------

            // Little complex logic to avoid sourceElement and countElement variables 
            //for (lpCnt = sourceArrayLength - 1; lpCnt >= 0; lpCnt--)
            //{
            //    sortedArray[countArray[sourceArray[lpCnt]] - 1] = sourceArray[lpCnt];

            //    countArray[sourceArray[lpCnt]] = countArray[sourceArray[lpCnt]] - 1;
            //}

            //-------------------------------------------------------------------------------------------------------------------
            
            // return sortedArray. If there is no rule with Input that it should modify the source.
            // Overwrite the original sourceArray with the output sortedArray. Since C# is ref type we can just change the soruce.

            for (int i = 0; i < sourceArray.Length; i++)
            {
                sourceArray[i] = sortedArray[i];
            }
        }
    }
}