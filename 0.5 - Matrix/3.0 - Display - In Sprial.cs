using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
     
     Input:
      1    2   3
      8    9   4
      7    6   5
     
    Output: 1   2   3   4   5   6   7   8   9
    
    We will first print the periphery of the matrix by the help of 4 for loops. 
    Then recursively call this function to do the same thing with inner concentric rectangles. 
    We will pass this information by a variable named depth, which will tell how many layers from outside should be ignored

    //int[,] squareMatrix =   {   { 1,  2,  3,  4,  5 },
    //                            { 16, 17, 18, 19, 6 },
    //                            { 15, 24, 25, 20, 7 },
    //                            { 14, 23, 22, 21, 8 },
    //                            { 13, 12, 11, 10, 9 }};
    
    //int[,] rectMatrix =     {   { 1,  2,  3,  4,  5 },
    //                            { 12, 13, 14, 15, 6 },
    //                            { 11, 10, 9,  8,  7 }};

    Yet to refer the logic.
    http://www.geeksforgeeks.org/print-a-given-matrix-in-spiral-form/

    To display in anti-spiral order we need to visit in spiral order and push them into stack and print them.
    ===================================================================================================================================================================================================
    */

    public partial class MatrixOperations
    {
        StringBuilder strRslt = new StringBuilder();

        //Need to fix. WIP
        public void DisplayMatrixInSpiralTest()
        {
            strRslt.Clear();

            strRslt.AppendLine("Demo 1   -    5 X 5 : ");
            DisplayMatrixInSpiral(JaggaedMatrix5x5);

            strRslt.AppendLine("\n\nDemo 2   -    4 X 5 : ");
            DisplayMatrixInSpiral(JaggaedMatrix4x5);

            strRslt.AppendLine("\n\nDemo 3   -    3 X 5 : ");
            DisplayMatrixInSpiral(JaggaedMatrix3x5);

            strRslt.AppendLine("\n\nDemo 4   -    2 X 5 : ");
            DisplayMatrixInSpiral(jaggaedMatrix2x5);

            strRslt.AppendLine("\n\nDemo 5   -    3 X 2 : ");
            DisplayMatrixInSpiral(jaggaedMatrix3x2);

            strRslt.AppendLine("\n\nDemo 6   -    4 X 2 : ");
            DisplayMatrixInSpiral(jaggaedMatrix4x2);

            strRslt.AppendLine("\n\nDemo 7   -    5 X 3 : ");
            DisplayMatrixInSpiral(jaggaedMatrix5x3);

            strRslt.AppendLine("\n\nDemo 8   -    7 X 3 : ");
            DisplayMatrixInSpiral(jaggaedMatrix7x3);
            
            strRslt.AppendLine("\n\nDemo 9   -    7 X 3 : ");
            DisplayMatrixInSpiral(jaggaedMatrix7x3);

            strRslt.AppendLine("\n\nDemo 10  -    7 X 7 : "); 
            DisplayMatrixInSpiral(jaggaedMatrix7x7);
            //Need to Investigate
            //Array.Sort(jaggaedMatrix);

            MessageBox.Show(Convert.ToString(strRslt));

            Array.Sort(JaggaedMatrix4x5, (a, b) => a[0].CompareTo(b[0]));
        }

        void DisplayMatrixInSpiral(int[][] MatrixArray)
        {
            int lpCnt;
            int topRowIndx = 0;
            int leftColIndx = 0;

            int bottomRowIndx = MatrixArray.Length - 1;
            int rightColIndx = MatrixArray[0].Length - 1;

            while (topRowIndx <= bottomRowIndx && leftColIndx <= rightColIndx)
            {
                //Top 
                for (lpCnt = leftColIndx; lpCnt <= rightColIndx; lpCnt++)
                {
                    strRslt.Append(MatrixArray[topRowIndx][lpCnt] + " ");
                }

                topRowIndx++;

                //Right column
                for (lpCnt = topRowIndx; lpCnt <= bottomRowIndx; lpCnt++)
                {
                    strRslt.Append(MatrixArray[lpCnt][rightColIndx] + " ");
                }

                rightColIndx--;

                // If boundaries are crossed, it means we are done with traversal.
                if (leftColIndx > rightColIndx || topRowIndx > bottomRowIndx)
                    break;

                //Bottom
                for (lpCnt = rightColIndx; lpCnt >= leftColIndx; lpCnt--)
                {
                    strRslt.Append(MatrixArray[bottomRowIndx][lpCnt] + " ");
                }
                bottomRowIndx--;

                //Left column
                for (lpCnt = bottomRowIndx; lpCnt >= topRowIndx; lpCnt--)
                {
                    strRslt.Append(MatrixArray[lpCnt][leftColIndx] + " ");
                }

                leftColIndx++;
            }
        }

        IList<int> DisplayMatrixInSpiral(int[,] matrix)
        {
            IList<int> spiralList = new List<int>();

            int lpCnt;
            int topRowIndx = 0;
            int bottomRowIndx = matrix.GetLength(0) - 1;

            int leftColIndx = 0;
            int rightColIndx = matrix.GetLength(1) - 1;

            while (leftColIndx <= rightColIndx && topRowIndx <= bottomRowIndx)
            {
                //Go left to right for top Row---->
                for (lpCnt = leftColIndx; lpCnt <= rightColIndx; lpCnt++)
                {
                    spiralList.Add(matrix[topRowIndx, lpCnt]);
                }

                topRowIndx++; // Move Down to Next Top Row. (step down for next iteration)

                //Go top to bottom for right column ↓ 
                for (lpCnt = topRowIndx; lpCnt <= bottomRowIndx; lpCnt++)
                {
                    spiralList.Add(matrix[lpCnt, rightColIndx]);
                }

                rightColIndx--; // Move Left to Inside Column.

                // If boundaries are crossed, it means we are done with traversal.
                if (leftColIndx > rightColIndx || topRowIndx > bottomRowIndx)
                    break;

                //Go right to left for bottom row <------
                for (lpCnt = rightColIndx; lpCnt >= leftColIndx; lpCnt--)
                {
                    spiralList.Add(matrix[bottomRowIndx, lpCnt]);
                }

                bottomRowIndx--; //Move Up to Next Bottom Row. 

                //Go bottom to top for left column ↑
                for (lpCnt = bottomRowIndx; lpCnt >= topRowIndx; lpCnt--)
                {
                    spiralList.Add(matrix[lpCnt, leftColIndx]);
                }

                leftColIndx++; // Move Left to Next Column
            }

            return spiralList;
        }

        public int[,] GenerateMatrix(int n)
        {
            if (n == 0)
                return new int[0, 0];

            int[,] matrix = new int[n, n];

            int leftColIndx = 0;
            int rightColIndx = n - 1;

            int topRowIndx = 0;
            int bottomRowIndx = n - 1;

            int val = 1;
            int lpCnt = 0;

            while (leftColIndx <= rightColIndx && topRowIndx <= bottomRowIndx)
            {
                // Go left to right for top row
                for (lpCnt = leftColIndx; lpCnt <= rightColIndx; lpCnt++)
                {
                    matrix[topRowIndx, lpCnt] = val;
                    val++;
                }

                topRowIndx++;

                // Go top to bottom for right column
                for (lpCnt = topRowIndx; lpCnt <= bottomRowIndx; lpCnt++)
                {
                    matrix[lpCnt, rightColIndx] = val;
                    val++;
                }

                rightColIndx--;

                if (leftColIndx > rightColIndx || topRowIndx > bottomRowIndx)
                    break;

                // Go right to left for bottom row
                for (lpCnt = rightColIndx; lpCnt >= leftColIndx; lpCnt--)
                {
                    matrix[bottomRowIndx, lpCnt] = val;
                    val++;
                }

                bottomRowIndx--;

                // Go bottom to top for left column
                for (lpCnt = bottomRowIndx; lpCnt >= topRowIndx; lpCnt--)
                {
                    matrix[lpCnt, leftColIndx] = val;
                    val++;
                }

                leftColIndx++;
            }

            return matrix;
        }

        private void Add2SB(IList<int> items)
        {
            for (int lpCnt = 0; lpCnt < items.Count; lpCnt++)
            {
                strRslt.Append(items[lpCnt] + " ");
            }
        }
    }
}