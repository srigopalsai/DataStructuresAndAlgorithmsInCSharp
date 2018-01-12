using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class MatrixSamples
    {
        /*  Given a N x N matrix, find K x K Sub-Matrix that has maximum sum. 

        Input:      1   2   3   4               Output:     11  12
                    5   6   7   8                           15  16
                    9   10  11  12
                    13  14  15  16

        Input:      1   2   3   4               Output:     5   6
                    5   6   7   8                           9   10
                    9   10  1   2
                    3   4   5   6

        https://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
        Area of Consecutive Sub Matrix
        http://stackoverflow.com/questions/7770945/largest-rectangular-sub-matrix-with-the-same-number
        =======================================================================================================================================================================================================
        */

        public static void MaximumSubMatrixSum()
        {

        }

        // https://www.geeksforgeeks.org/count-negative-numbers-in-a-column-wise-row-wise-sorted-matrix/
        // [-3, -2, -1,  1]
        // [-2,  2,  3,  4]
        // [ 4,  5,  7,  8]

        // Here's the idea:
        // [-3, -2,  ↓,  ←] -> Found 3 negative numbers in this row
        // [ ↓,  ←,  ←,  4] -> Found 1 negative number  in this row
        // [ ←,  5,  7,  8] -> No      negative numbers in this row

        public int CountNegative(int[,] matrix)
        {
            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);

            int rIndx = 0;
            int cIndx = rLen - 1;

            int numCount = 0;

            while (rIndx < rLen && cIndx >= 0)
            {
                if (matrix[rIndx, cIndx] < 0)
                {
                    // cIndx is the index of the last negative number in this row. So there must be ( j+1 )
                    numCount += cIndx + 1;
                    rIndx++;
                }

                // Move to the left and see if we can find a negative number there
                else
                {
                    cIndx--;
                }
            }

            return numCount;
        }

        // https://www.geeksforgeeks.org/common-elements-in-all-rows-of-a-given-matrix/

        public void PrintCommonElements(int[,] matrix)
        {
            Dictionary<int, int> elementsDict = new Dictionary<int, int>();
            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);
            int key = 0;

            // Initalize 1st row elements with value 1
            for (int cIndx = 0; cIndx < cLen; cIndx++)
            {
                elementsDict.Add(matrix[0,cIndx], 1);
            }

            // Traverse the matrix from second row.
            for (int rIndx = 1; rIndx < rLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    key = matrix[rIndx, cIndx];

                    if (!elementsDict.ContainsKey(key))
                        continue;

                    // If element is present in the map and is not duplicated in current row.
                    if (elementsDict[key] == rIndx)
                    {
                        // We increment counthmnhmnm of the element in map by 1
                        elementsDict[key] = rIndx + 1;

                        if (rIndx == rLen - 1) // Last Row
                        {
                            Console.Write(key + " ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        // 59 Generate Spiral Matrix https://leetcode.com/problems/spiral-matrix-ii/description/
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

        // https://www.geeksforgeeks.org/create-a-matrix-with-alternating-rectangles-of-0-and-x/
        public void Fill0AndX(int bottomRIndx, int rightCIndx)
        {
            int indx;
            int topRIndx = 0;
            int leftCIndx = 0;

            char[,] matrix = new char[bottomRIndx, rightCIndx];
            char xChar = 'X';

            while (topRIndx < bottomRIndx && leftCIndx < rightCIndx)
            {
                for (indx = leftCIndx; indx < rightCIndx; ++indx)
                {
                    matrix[topRIndx, indx] = xChar;
                }

                topRIndx++;

                for (indx = topRIndx; indx < bottomRIndx; ++indx)
                {
                    matrix[indx, rightCIndx - 1] = xChar;
                }

                rightCIndx--;

                if (topRIndx < bottomRIndx)
                {
                    for (indx = rightCIndx - 1; indx >= leftCIndx; --indx)
                    {
                        matrix[bottomRIndx - 1, indx] = xChar;
                    }

                    bottomRIndx--;
                }

                if (leftCIndx < rightCIndx)
                {
                    for (indx = bottomRIndx - 1; indx >= topRIndx; --indx)
                    {
                        matrix[indx, leftCIndx] = xChar;
                    }

                    leftCIndx++;
                }

                xChar = (xChar == '0') ? 'X' : '0';
            }

            for (int rIndx = 0; rIndx < matrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < matrix.GetLength(1); cIndx++)
                {
                    Console.Write(matrix[rIndx, cIndx]);
                }
                Console.WriteLine();
            }
        }

        // https://leetcode.com/problems/cut-off-trees-for-golf-event/description/
    }
}