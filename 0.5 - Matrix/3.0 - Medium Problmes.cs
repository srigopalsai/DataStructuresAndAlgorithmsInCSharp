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

        // Find maxSum in array return {maxSum, left, right}
        public static int[] MaxSumByKadane(int[] nums)
        {
            //result[0] == maxSum, result[1] == start, result[2] == end;
            int[] result = new int[] { int.MinValue, 0, -1 };

            int curSum = 0;
            int stIndx = 0;

            for (int curIndx = 0; curIndx < nums.Length; curIndx++)
            {
                curSum += nums[curIndx];

                if (curSum < 0)
                {
                    curSum = 0;
                    stIndx = curIndx + 1;
                }
                else if (curSum > result[0])
                {
                    result[0] = curSum;
                    result[1] = stIndx;
                    result[2] = curIndx;
                }
            }

            //all numbers in a are negative
            if (result[2] == -1)
            {
                result[0] = 0;

                for (int indx = 0; indx < nums.Length; indx++)
                {
                    if (nums[indx] > result[0])
                    {
                        result[0] = nums[indx];
                        result[1] = indx;
                        result[2] = indx;
                    }
                }
            }

            return result;
        }

        // To find and print maxSum, (left, top),(right, bottom)
 
        public static void FindMaxSubMatrix(int[,] matrix)
        {
            int colLen = matrix.GetLength(1);
            int rowLen = matrix.GetLength(0);

            int[] curResult;
            int maxSum = int.MinValue;

            int top = 0;
            int left = 0;
            int right = 0;
            int bottom = 0;

            for (int lftColIndx = 0; lftColIndx < colLen; lftColIndx++)
            {
                int[] tmpArray = new int[rowLen];

                for (int rghtColInd = lftColIndx; rghtColInd < colLen; rghtColInd++)
                {
                    for (int indx = 0; indx < rowLen; indx++)
                    {
                        tmpArray[indx] += matrix[indx,rghtColInd];
                    }

                    curResult = MaxSumByKadane(tmpArray);

                    if (curResult[0] > maxSum)
                    {
                        maxSum = curResult[0];
                        left = lftColIndx;
                        top = curResult[1];
                        right = rghtColInd;
                        bottom = curResult[2];
                    }
                }
            }

            Console.WriteLine("MaxSum: " + maxSum + ", range: [(" + left + ", " + top + ")(" + right + ", " + bottom + ")]");
        }

        // https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k
        public int MaxSumSubmatrix(int[,] matrix, int maxK)
        {
            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);

            int[,] dpLkUp = new int[rLen, cLen];

            for (int rIndx = 0; rIndx < rLen; ++rIndx)
            {
                dpLkUp[rIndx, 0] = matrix[rIndx, 0];

                for (int cIndx = 1; cIndx < cLen; ++cIndx)
                {
                    // Cumulate sum for each cell in each row
                    dpLkUp[rIndx, cIndx] += dpLkUp[rIndx, cIndx - 1] + matrix[rIndx, cIndx];
                }
            }

            int[] dpSum = new int[rLen];
            int maxVal = int.MinValue;

            for (int cIndx = 0; cIndx < cLen; ++cIndx)
            {
                for (int j = -1; j < cIndx; ++j)
                {
                    for (int rIndx = 0; rIndx < rLen; ++rIndx)
                    {
                        dpSum[rIndx] = dpLkUp[rIndx, cIndx] - (j == -1 ? 0 : dpLkUp[rIndx, j]) + (rIndx == 0 ? 0 : dpSum[rIndx - 1]);
                    }

                    for (int rIndx = 0; rIndx < rLen; ++rIndx)
                    {
                        for (int n = -1; n < rIndx; ++n)
                        {
                            int curMaxVal = dpSum[rIndx] - (n == -1 ? 0 : dpSum[n]);

                            if (curMaxVal == maxK)
                            {
                                return maxK;
                            }

                            if (curMaxVal <= maxK)
                            {
                                maxVal = Math.Max(maxVal, curMaxVal);
                            }
                        }
                    }
                }
            }
            return maxVal;
        }

        public int FindMaxSubarraySum(int[] arr, int sum)
        {
            // To store current sum and maxSum of subarrays
            int curSum = arr[0];
            int maxSum = 0;
            int start = 0;

            for (int indx = 1; indx < arr.Length; indx++)
            {
                // If curSum becomes greater than sum subtract starting elemetns of array
                while (curSum > sum && start < indx)
                {
                    curSum -= arr[start];
                    start++;
                }

                // Update maxSum if it becomes greater than curSum
                maxSum = Math.Max(maxSum, curSum);

                // Add elements to curSum
                curSum += arr[indx];
            }

            // Adding an extra check for last subarray
            if (curSum <= sum)
            {
                maxSum = Math.Max(maxSum, curSum);
            }

            return maxSum;
        }      

        // https://leetcode.com/problems/cut-off-trees-for-golf-event/description/

        // 766 https://leetcode.com/problems/toeplitz-matrix/description/
        /* A matrix is Toeplitz if every diagonal from top-left to bottom-right has the same element.
        Now given an M x N matrix, return True if and only if the matrix is Toeplitz.

        Example 1:
        Input: matrix = [ [1, 2, 3, 4],
                          [5, 1, 2, 3],
                          [9, 5, 1, 2]]
        Output: True
        Explanation:
        1234
        5123
        9512

        In the above grid, the diagonals are "[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]", 
        and in each diagonal all elements are the same, return true.
        */

        public bool IsToeplitzMatrix(int[,] matrix)
        {
            for (int rIndx = 0; rIndx < matrix.GetLength(0) - 1; rIndx++)
            {
                for (int cIndx = 0; cIndx < matrix.GetLength(1) - 1; cIndx++)
                {
                    if (matrix[rIndx, cIndx] != matrix[rIndx + 1, cIndx + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //73 https://leetcode.com/problems/set-matrix-zeroes/description/

        public void SetZeroes(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return;

            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);
            int row0cIndx = 0;

            // Find first row has zeros or not?
            for (; row0cIndx < colLen && matrix[0, row0cIndx] != 0; ++row0cIndx) ;
            //for (; col0RowIndx < rowLen && matrix[col0RowIndx, 0] != 0; ++col0RowIndx) ; // Can avoid if we traverse column backwards while filling zeros

            // Use 1st Row and 1st Column as reference indicators.
            for (int rIndx = 1; rIndx < rowLen; ++rIndx)
            {
                for (int cIndx = 0; cIndx < colLen; ++cIndx)
                {
                    if (matrix[rIndx, cIndx] == 0)
                        matrix[0, cIndx] = matrix[rIndx, 0] = 0;
                }
            }

            // Set the zeros in the matrix excluding first row. And by start columns from backwards.
            for (int rIndx = 1; rIndx < rowLen; ++rIndx)
            //for (int lpRCnt = rowLen - 1; lpRCnt >=0 ; --lpRCnt)
            {
                for (int cIndx = colLen - 1; cIndx >= 0; --cIndx) // Can avoid zeroth column test and refilling for zeros.
                                                                     //for (int lpCCnt = 0; lpCCnt < colLen; ++lpCCnt)
                {
                    if (matrix[0, cIndx] == 0 || matrix[rIndx, 0] == 0)
                        matrix[rIndx, cIndx] = 0;
                }
            }

            // Now set zeros for the first row if required
            if (row0cIndx < colLen)
            {
                for (int lpCCnt = 0; lpCCnt < matrix.GetLength(1); lpCCnt++)
                    matrix[0, lpCCnt] = 0;
            }

            // Now set zeros for the first column if required. // Can avoid if we traverse column backwards while filling zeros
            //if (col0RowIndx < rowLen)
            //{
            //    for (int lpRCnt = 0; lpRCnt < matrix.GetLength(0); lpRCnt++)
            //        matrix[lpRCnt, 0] = 0;
            //}
        }

        // 304 https://leetcode.com/problems/range-sum-query-2d-immutable/description/
        public class NumMatrix
        {
            private int[,] dpMat;

            public NumMatrix(int[,] matrix)
            {
                if (matrix == null || matrix.Length == 0)
                {
                    return;
                }

                int rLen = matrix.GetLength(0);
                int cLen = matrix.GetLength(1);

                dpMat = new int[rLen + 1, cLen + 1];

                for (int rIndx = 1; rIndx <= rLen; rIndx++)
                {
                    for (int cIndx = 1; cIndx <= cLen; cIndx++)
                    {
                        dpMat[rIndx, cIndx] = dpMat[rIndx - 1, cIndx] + dpMat[rIndx, cIndx - 1] + matrix[rIndx - 1, cIndx - 1] - dpMat[rIndx - 1, cIndx - 1];
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                int r1Indx = Math.Min(row1, row2);
                int r2Indx = Math.Max(row1, row2) + 1;

                int c1Indx = Math.Min(col1, col2);
                int c2Indx = Math.Max(col1, col2) + 1;

                return dpMat[r2Indx, c2Indx] - dpMat[r2Indx, c1Indx] -
                       dpMat[r1Indx, c2Indx] + dpMat[r1Indx, c1Indx];
            }
        }
    }
}