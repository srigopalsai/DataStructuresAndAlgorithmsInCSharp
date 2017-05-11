using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /* 
    ===========================================================================================================================================================================================
    Count Sort or Pigeon Hole Sort: (Different from counting sort)

    Is suitable for sorting lists of elements where the number of elements (n) and the number of possible key values (N) are approximately the same.
    It requires O(n + N) time.

    The difference between pigeonhole sort and counting sort is that in counting sort, the auxiliary array does not contain lists of input elements, only counts.
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    References :
    http://en.wikipedia.org/wiki/Count_sort
    http://www.sanfoundry.com/c-program-pigeonhole-sort/

    ===========================================================================================================================================================================================    
    */
    partial class SortingSamples
    {
        public void CountSortTest()
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
            CountSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[BestCaseNearlySortedArry.Length];
            BestCaseNearlySortedArry.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nBest Case", BestCaseNearlySortedArry);
            CountSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[AverageCaseFewSortedArry1.Length];
            AverageCaseFewSortedArry1.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nAverage Case 1", AverageCaseFewSortedArry1);
            CountSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[AverageCaseFewSortedArry2.Length];
            AverageCaseFewSortedArry2.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nAverage Case 2", AverageCaseFewSortedArry2);
            CountSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[WorstCaseReversedArry1.Length];
            WorstCaseReversedArry1.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nWorst Case 1", WorstCaseReversedArry1);
            CountSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[WorstCaseFewDuplsArry2.Length];
            WorstCaseFewDuplsArry2.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nWorst Case 2", WorstCaseFewDuplsArry2);
            CountSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            listToSort = new int[WorstCaseMoreDuplsArry3.Length];
            WorstCaseMoreDuplsArry3.CopyTo(listToSort, 0);

            AppendArrayToResultString("\nWorst Case 3", WorstCaseMoreDuplsArry3);
            CountSort(listToSort);
            AppendArrayToResultString("Sorted Array", listToSort);

            //-----------------------------------------------------------------------------------------------------------------------------------------------------

            ShowResultString();
        }
        public void CountSort(int[] sourceArray)
        {
        }
    }
}