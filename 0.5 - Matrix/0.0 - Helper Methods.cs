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

    Global variables and methods being used across matrix samples.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    ============================================================================================================================================================================================================================

    Space complexity O(n) total, O(1) auxiliary - Giving Support

    */
    partial class MatrixOperations
    {
        int[,] RectangularMatrix4x4 =  {  { 01, 02, 03, 04 },
                                          { 05, 06, 07, 08 },
                                          { 09, 10, 11, 12 },
                                          { 13, 14, 15, 16 } };

        int[,] SquareEmptyMaxtix = { { } };
        int[,] SquareMaxtixSingleVal = { { 01 } };
        int[,] SquareMaxtixWith0ValSR = { { 01, 02, 00, 04 } };

        int[,] SquareMaxtixWith0ValSC = { { 01 },
                                          { 02 },
                                          { 03 },
                                          { 00 },
                                          { 05 },
                                          { 06 } };

        int[,] SquareMaxtixWith0Vals =  { { 01, 02, 03, 04 },
                                          { 05, 06, 07, 08 },
                                          { 09, 10, 11, 12 },
                                          { 13, 14, 00, 16 },
                                          { 17, 18, 19, 20 },
                                          { 21, 22, 23, 24 } };
        int[,] IncreasingSortedMatrix = { { 01, 04, 07, 11, 15 },
                                          { 02, 05, 08, 12, 19 },
                                          { 03, 06, 09, 16, 22 },
                                          { 10, 13, 14, 17, 24 },
                                          { 18, 21, 23, 26, 30 } };

        int[][] JaggaedMatrix5x5 = new int[5][];
        int[][] JaggaedMatrix4x5 = new int[4][];
        int[][] JaggaedMatrix3x5 = new int[3][];
        int[][] jaggaedMatrix2x5 = new int[2][];

        int[][] jaggaedMatrix3x2 = new int[3][];
        int[][] jaggaedMatrix4x2 = new int[4][];

        int[][] jaggaedMatrix3x7 = new int[3][];
        int[][] jaggaedMatrix5x3 = new int[5][];
        int[][] jaggaedMatrix7x3 = new int[7][];

        int[][] jaggaedMatrix7x7 = new int[7][];
        public MatrixOperations()
        {
            // Demo 1   -    5 X 5
            JaggaedMatrix5x5[0] = new int[5] { 01, 02, 03, 04, 5 };
            JaggaedMatrix5x5[1] = new int[5] { 16, 17, 18, 19, 6 };
            JaggaedMatrix5x5[2] = new int[5] { 15, 24, 25, 20, 7 };
            JaggaedMatrix5x5[3] = new int[5] { 14, 23, 22, 21, 8 };
            JaggaedMatrix5x5[4] = new int[5] { 13, 12, 11, 10, 9 };

            //Need to Investigate
            //Array.Sort(jaggaedMatrix);

            // Demo 2   -    4 X 5
            JaggaedMatrix4x5[0] = new int[5] { 01, 02, 03, 04, 05 };
            JaggaedMatrix4x5[1] = new int[5] { 14, 15, 16, 17, 06 };
            JaggaedMatrix4x5[2] = new int[5] { 13, 20, 19, 18, 07 };
            JaggaedMatrix4x5[3] = new int[5] { 12, 11, 10, 09, 08 };

            // Demo 3   -    3 X 5 (Defect need to be fixed a junk char will be displayed at end.
            JaggaedMatrix3x5[0] = new int[5] { 01, 02, 03, 04, 5 };
            JaggaedMatrix3x5[1] = new int[5] { 12, 13, 14, 15, 6 };
            JaggaedMatrix3x5[2] = new int[5] { 11, 10, 09, 08, 7 };
           
            // Demo 4   -    2 X 5
            jaggaedMatrix2x5[0] = new int[5] { 01, 02, 03, 04, 05 };
            jaggaedMatrix2x5[1] = new int[5] { 10, 09, 08, 07, 06 };

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Demo 5   -    3 X 2
            jaggaedMatrix3x2[0] = new int[2] { 1, 2 };
            jaggaedMatrix3x2[1] = new int[2] { 6, 3 };
            jaggaedMatrix3x2[2] = new int[2] { 5, 4 };

            // Demo 6   -    4 X 2
            jaggaedMatrix4x2[0] = new int[2] { 1, 2 };
            jaggaedMatrix4x2[1] = new int[2] { 8, 3 };
            jaggaedMatrix4x2[2] = new int[2] { 7, 4 };
            jaggaedMatrix4x2[3] = new int[2] { 6, 5 };

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Demo 7   -    3 X 7 (Defect need to be fixed a junk char will be displayed at end.
            jaggaedMatrix3x7[0] = new int[7] { 01, 02, 03, 04, 05, 06, 07 };
            jaggaedMatrix3x7[1] = new int[7] { 16, 17, 18, 19, 20, 21, 08 };
            jaggaedMatrix3x7[2] = new int[7] { 15, 14, 13, 12, 11, 10, 09 };

            // Demo 8   -    5 X 3 (Defect need to be fixed a junk char will be displayed at end.
            jaggaedMatrix5x3[0] = new int[3] { 01, 02, 03 };
            jaggaedMatrix5x3[1] = new int[3] { 12, 13, 04 };
            jaggaedMatrix5x3[2] = new int[3] { 11, 14, 05 };
            jaggaedMatrix5x3[3] = new int[3] { 10, 15, 06 };
            jaggaedMatrix5x3[4] = new int[3] { 09, 08, 07 };

            // Demo 9   -    7 X 3 (Defect need to be fixed a junk char will be displayed at end.

            jaggaedMatrix7x3[0] = new int[3] { 01, 02, 03 };
            jaggaedMatrix7x3[1] = new int[3] { 16, 17, 04 };
            jaggaedMatrix7x3[2] = new int[3] { 15, 18, 05 };
            jaggaedMatrix7x3[3] = new int[3] { 14, 19, 06 };
            jaggaedMatrix7x3[4] = new int[3] { 13, 20, 07 };
            jaggaedMatrix7x3[5] = new int[3] { 12, 21, 08 };
            jaggaedMatrix7x3[6] = new int[3] { 11, 10, 09 };

            // Demo 10   -    7 X 7

            jaggaedMatrix7x7[0] = new int[7] { 01, 02, 03, 04, 05, 06, 07 };
            jaggaedMatrix7x7[1] = new int[7] { 24, 25, 26, 27, 28, 29, 08 };
            jaggaedMatrix7x7[2] = new int[7] { 23, 40, 41, 42, 43, 30, 09 };
            jaggaedMatrix7x7[3] = new int[7] { 22, 39, 48, 49, 44, 31, 10 };
            jaggaedMatrix7x7[4] = new int[7] { 21, 38, 47, 46, 45, 32, 11 };
            jaggaedMatrix7x7[5] = new int[7] { 20, 37, 36, 35, 34, 33, 12 };
            jaggaedMatrix7x7[6] = new int[7] { 19, 18, 17, 16, 15, 14, 13 };
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Int64[] WorstCaseMoreDuplsArry4 = new Int64[] { 1, 3, 7, 21, 48, 112, 336, 861, 1968, 4592, 13776, 33936, 86961, 198768, 463792, 1391376, 3402672, 8382192, 21479367, 
                                                                                                                                49095696, 114556624, 343669872, 52913488, 2085837936 };
        string displayMessage = string.Empty;

        string LinearTime = " Big O Notation : O(n) - Linear Time " +
            Environment.NewLine + "Number of steps proportional to the size of the tasks. (If the size of the task increases then no of steps increases)" + Environment.NewLine;

        string QuadraticTime = " Big O Notation : O(n2) - Quadratic Time " +
            Environment.NewLine + "The number of operations is proportional to the size of the task squared." + Environment.NewLine;

        string Best2Worst = "Best to Worst Big O Notations " + Environment.NewLine + " O(1) < O (log n) < O(n) < O (n log n) < O (n2) < O(n3) < O(an) + Read '<' as 'better than'";

        StringBuilder resultArrayString = new StringBuilder();

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ArrayAPIs()
        {
            // Create a two-dimensional integer array.
            int[,] integers2d = { { 10, 20 }, { 30, 40 }, { 50, 60 }, { 70, 80 } };

            Console.WriteLine("Number of dimensions: {0}", integers2d.Rank);

            for (int ctr = 0; ctr < integers2d.Rank - 1; ctr++)
                Console.WriteLine("   Dimension {0}: from {1} to {2}", ctr, integers2d.GetLowerBound(ctr), integers2d.GetUpperBound(ctr));

            // Iterate the 2-dimensional array and display its values.
            Console.WriteLine("   Values of array elements:");

            int rowPos = integers2d.GetLowerBound(0);
            int colPos = integers2d.GetLowerBound(1);

            for (; rowPos <= integers2d.GetUpperBound(0); rowPos++)
                for (; colPos <= integers2d.GetUpperBound(1); colPos++)
                    Console.WriteLine("      {3}{0}, {1}{4} = {2}", rowPos, colPos, integers2d.GetValue(rowPos, colPos), "{", "}");

            Console.ReadLine();
        }

        void AppendMatrixToResultString( int[,] matrix,string message = "")
        {
            resultArrayString.AppendLine(message);

            for (int LpRCnt = 0; LpRCnt < matrix.GetLength(0); LpRCnt++)
            {
                for (int LpCCnt = 0; LpCCnt < matrix.GetLength(1); LpCCnt++)
                {
                    resultArrayString.Append("\t" + matrix[LpRCnt,LpCCnt]);
                }
                resultArrayString.AppendLine();
            }
        }

        void ShowResultString()
        {
            MessageBox.Show(resultArrayString.ToString());
        }

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

        void ClearDebugWindow()
        {
            Debug.Flush();
        }
        
        void DisplayInDebugWindow(int[] array)
        {   
            Debug.WriteLine("");
            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                Debug.Write(array[lpCnt] + " ");
            }
        }

        void DisplayInDebugWindow(int[] array, string message)
        {
            Debug.WriteLine("\n" + message);

            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                Debug.Write(array[lpCnt] + " ");
            }
        }
    }
}