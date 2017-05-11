using System;
using System.Text;
using System.Windows;

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    Refer Iterative versions for sort here http://www.cims.nyu.edu/~brettb/dsSum2016/Lecture15.pdf
    Adaptive Sort       : If it takes advantage of existing order in its input.
                          It benefits from the presortedness in the input sequence – or a limited amount of disorder for various definitions of measures of disorder – and sorts faster. 
                          Adaptive sorting is usually performed by modifying existing sorting algorithms.
                          http://en.wikipedia.org/wiki/Adaptive_sort
    
    E.g. When O(n) nearly sorted then Bubble Sort, Insertion Sort.

    Not Adaptive        : Selection, Quiick Sort, Merge Sort, Heap
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Stable Sort         : When sorting some kinds of data, only part of the data is examined when determining the sort order
                          http://en.wikipedia.org/wiki/Sorting_algorithm#Stability
    
    E.g. Bubble Sort, Insertion Sort, Merge Sort.
    
    In Bubble Sort if the elements are 1, 2, 3, 4, 8, 5, 7, 6, 10, 12, 11
    1 can just examine with next element 2. and will stay in its position. No need examine with remaining elements.

    Not Stable: Selection, Quick, Heap.

    A stable sort preserves the order of elements that are equal. 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Comparision (Or Un Stable) Sort    : Only reads the list elements through a single abstract comparison operation (often a "<=" operator or a three-way comparison) that determines which of two elements should occur first in the final sorted list. 
                          The only requirement is that the operator obey two of the properties of a total order:

    A "less than or equal to" comparison operation determines which of two elements should occur first in the final sorted list. 
    However, if two elements are equal, their original order might not be preserved. 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Online Algorithm    : Is one that can process its input piece-by-piece in a serial fashion, i.e., in the order that the input is fed to the algorithm, without having the entire input available from the start. 
    
    Offline Algorithm   : Is given the whole problem data from the beginning and is required to output an answer which solves the problem at hand. 
                          E.g. Selection sort requires that the entire list be given before it can sort it, while insertion sort doesn't.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    All Sorting Samples : http://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting

        http://en.potiori.com/Batcher_sort.html

  

    ============================================================================================================================================================================================================================

    Space complexity O(n) total, O(1) auxiliary - Giving Support

    */

    // Common Variables and methods being used across sorting samples.  --------------------------------------------------------------------------------------------------------------------------------------------------------

    partial class SortingSamples
    {
        // 1. Random.
        // 2. Nearly Sorted.
        // 3. Reversed.
        // 4. Few Unique

        int[] BestCaseNearlySortedArry = new int[] { 1, 2, 3, 4, 6, 5 };

        int[] AverageCaseFewSortedArry1 = new int[] { 3, 2, 1, 4, 5, 6 };
        int[] AverageCaseFewSortedArry2 = new int[] { 6, 2, 3, 1, 5, 4 };
        int[] AverageCaseFewSortedArry3 = new int[] { 1, 12, 5, 26, 7, 14, 3, 7, 2 };
        int[] AverageCaseFewSortedArry4 = new int[] { 3, 7, 8, 5, 2, 1, 9, 5, 4 };

        int[] WorstCaseReversedArry1 = new int[] { 6, 5, 4, 3, 2, 1 };
        int[] WorstCaseFewDuplsArry2 = new int[] { 1, 3, 1, 2, 1, 3 };
        int[] WorstCaseMoreDuplsArry3 = new int[] { 1, 1, 2, 2, 1, 2 };
        int[] WorstCaseMoreDuplsArry4 = new int[] { 4, 5, 6, 1, 2, 3 };

        Int64[] WorstCaseMoreDuplsArry5 = new Int64[] { 1, 3, 7, 21, 48, 112, 336, 861, 1968, 4592, 13776, 33936, 86961, 198768, 463792, 1391376, 3402672, 8382192, 21479367, 
                                                                                                                                49095696, 114556624, 343669872, 52913488, 2085837936 };
        // Bugs in Quick Sort,
        int[] RandomElementsArray1 = new int[] { -6, -6, 2, 2, 2, 10, 10, 10, 6, -6, 2, 2, 2, 2, 2 };
        int[] RandomElementsArray2 = new int[] { -6, -6, 2, 2, 2, 10, 10, 10, -6, 6, 2, 2, 2, 2, 2 };
        int[] RandomElementsArray3 = new int[] { -6, -6, 2, 2, 2, 10, 10, 10, -6, -6, 2, 2, 2, 2, 2 };
        int[] RandomElementsArray4 = new int[] { 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 15 };

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        string displayMessage = string.Empty;

        string LinearTime = " Big O Notation : O(n) - Linear Time " +
            Environment.NewLine + "Number of steps proportional to the size of the tasks. (If the size of the task increases then no of steps increases)" + Environment.NewLine;

        string QuadraticTime = " Big O Notation : O(n2) - Quadratic Time " +
            Environment.NewLine + "The number of operations is proportional to the size of the task squared." + Environment.NewLine;

        string Best2Worst = "Best to Worst Big O Notations " + Environment.NewLine + " O(1) < O (log n) < O(n) < O (n log n) < O (n2) < O(n3) < O(an) + Read '<' as 'better than'";

        StringBuilder resultArrayString = new StringBuilder();

  
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        void AppendArrayToResultString(string message, int[] list)
        {
            List<string> slist = new List<string>();
            HashSet<string> hset = new HashSet<string>();
            ArrayList alist = new ArrayList();
            Hashtable htable = new Hashtable();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            SortedList<int, string> srtlist = new SortedList<int, string>();


            string st = string.Empty;
            foreach (int item in list)
            {
                st += item + "   ";
            }

            resultArrayString.AppendLine(string.Format("{0}\t : {1}", message, st));
            //displayMessage += Environment.NewLine + resultArrayString.ToString();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        void ShowResultString()
        {
            MessageBox.Show(resultArrayString.ToString());
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        string GetResultString(int[] UnSortedList, int[] SortedList)
        {            
            resultArrayString.Clear();
            resultArrayString.AppendLine();

            resultArrayString.Append(Environment.NewLine + "Un Sorted elements  :  ");

            foreach (int item in UnSortedList)
            {
                resultArrayString.Append(item + "   ");
            }

            resultArrayString.Append(Environment.NewLine + "      Sorted elements  :  ");

            foreach (int item in SortedList)
            {
                resultArrayString.Append(item + "   ");
            }

            return Convert.ToString(resultArrayString);
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        void ClearDebugWindow()
        {
            Debug.Flush();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        void DisplayInDebugWindow(int[] array)
        {   
            Debug.WriteLine("");
            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                Debug.Write(array[lpCnt] + " ");
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        void DisplayInDebugWindow(int[] array, string message)
        {
            Debug.WriteLine("\n" + message);

            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                Debug.Write(array[lpCnt] + " ");
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        string GetResultString(int[] UnSortedList, int[] SortedList, string prefixMessage)
        {
            return GetResultString(UnSortedList, SortedList);

            /*
            resultArrayString.Append( prefixMessage + Environment.NewLine + "E.g. Un Sorted elements  : ");

            foreach (int item in UnSortedList)
            {
                resultArrayString.Append(item + "   ");
            }

            resultArrayString.Append(Environment.NewLine + "   Sorted elements  : ");

            foreach (int item in SortedList)
            {
                resultArrayString.Append(item + "   ");
            }

            return Convert.ToString(resultArrayString);
        */
        }
    }
}