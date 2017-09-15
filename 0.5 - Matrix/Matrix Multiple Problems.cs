using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class MatrixOperations
    {
        //329 https://leetcode.com/problems/longest-increasing-path-in-a-matrix/?tab=Description

        public void LongestIncreasingPathTest()
        {
            int[,] nums1 = {  { 9, 9, 4 },
                              { 6, 6, 8 },
                              { 2, 1, 1 } };

            LongestIncreasingPath(nums1);

            int[,] nums2 = { { 3, 4, 5 },
                             { 3, 2, 6},
                             { 2, 2, 1 } };

            LongestIncreasingPath(nums2);
        }

        public int LongestIncreasingPath(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            int[,] cacheMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int maxCount = 0;

            for (int rIndx = 0; rIndx < matrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < matrix.GetLength(1); cIndx++)
                {
                    int currMaxCount = FindMaxAround(rIndx, cIndx, matrix, cacheMatrix, int.MaxValue);
                    maxCount = Math.Max(currMaxCount, maxCount);
                }
            }
            return maxCount;
        }

        // Flood Fill Approach
        private int FindMaxAround(int rIndx, int cIndx, int[,] matrix, int[,] cacheMatrix, int prevVal)
        {
            // if out of bond OR current cell value larger than previous cell value.
            if (rIndx < 0 || rIndx >= matrix.GetLength(0) || cIndx < 0 || cIndx >= matrix.GetLength(1) || matrix[rIndx, cIndx] >= prevVal)
            {
                return 0;
            }

            // if calculated before, no need to do it again
            if (cacheMatrix[rIndx, cIndx] > 0)
            {
                return cacheMatrix[rIndx, cIndx];
            }

            int curVal = matrix[rIndx, cIndx];

            int maxCount = 0;

            maxCount = Math.Max(FindMaxAround(rIndx - 1, cIndx, matrix, cacheMatrix, curVal), maxCount);
            maxCount = Math.Max(FindMaxAround(rIndx + 1, cIndx, matrix, cacheMatrix, curVal), maxCount);
            maxCount = Math.Max(FindMaxAround(rIndx, cIndx - 1, matrix, cacheMatrix, curVal), maxCount);
            maxCount = Math.Max(FindMaxAround(rIndx, cIndx + 1, matrix, cacheMatrix, curVal), maxCount);

            cacheMatrix[rIndx, cIndx] = ++maxCount;

            return maxCount;
        }

        // 541 - 0 1 Matrix https://leetcode.com/problems/01-matrix/description/
        //--------------------------------------------------------------------------------------------------------------------------------
        /*
        Given a matrix consists of 0 and 1, find the distance of the nearest 0 for each cell. 
        The distance between two adjacent cells is 1. 

        Input:  0 0 0
                0 1 0
                0 0 0
        Output: 0 0 0
                0 1 0
                0 0 0

        Input:  0 0 0
                0 1 0
                1 1 1
        Output: 0 0 0
                0 1 0
                1 2 1

        Note:   The number of elements of the given matrix will not exceed 10,000.
                There are at least one 0 in the given matrix.
                The cells are adjacent in only four directions: up, down, left and right.
        */

        public void UpdateMatrixTest()
        {
            int[,] matrix1 = { { 0, 0, 0, },
                               { 0, 1, 0, },
                               { 0, 0, 0 }};

            UpdateMatrix(matrix1);

            int[,] matrix2 = { { 0, 0, 0, },
                               { 0, 1, 0, },
                               { 1, 1, 1 }};

            UpdateMatrix(matrix2);

            int[,] matrix3 = {  {1, 0, 1, 1, 0, 0, 1, 0, 0, 1},
                                {0, 1, 1, 0, 1, 0, 1, 0, 1, 1},
                                {0, 0, 1, 0, 1, 0, 0, 1, 0, 0},
                                {1, 0, 1, 0, 1, 1, 1, 1, 1, 1},
                                {0, 1, 0, 1, 1, 0, 0, 0, 0, 1},
                                {0, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                                {0, 1, 0, 1, 0, 1, 0, 0, 1, 1},
                                {1, 0, 0, 0, 1, 1, 1, 1, 0, 1},
                                {1, 1, 1, 1, 1, 1, 1, 0, 1, 0},
                                {1, 1, 1, 1, 0, 1, 0, 0, 1, 1}};

            UpdateMatrix(matrix3);
        }

        public int[,] UpdateMatrix(int[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int rIndx = 0; rIndx < rowLength; rIndx++) // From Top and Left
            {
                for (int cIndx = 0; cIndx < colLength; cIndx++)
                {
                    if (matrix[rIndx, cIndx] != 1)
                    {
                        continue;
                    }

                    matrix[rIndx, cIndx] = Int32.MaxValue;

                    if (rIndx - 1 >= 0 && matrix[rIndx - 1, cIndx] != Int32.MaxValue)
                    {
                        matrix[rIndx, cIndx] = Math.Min(matrix[rIndx, cIndx], matrix[rIndx - 1, cIndx] + 1);
                    }

                    if (cIndx - 1 >= 0 && matrix[rIndx, cIndx - 1] != Int32.MaxValue)
                    {
                        matrix[rIndx, cIndx] = Math.Min(matrix[rIndx, cIndx], matrix[rIndx, cIndx - 1] + 1);
                    }
                }
            }

            for (int rIndx = rowLength - 1; rIndx >= 0; rIndx--) // From Bottom and Right
            {
                for (int cIndx = colLength - 1; cIndx >= 0; cIndx--)
                {
                    if (rIndx + 1 < rowLength && matrix[rIndx + 1, cIndx] != Int32.MaxValue)
                    {
                        matrix[rIndx, cIndx] = Math.Min(matrix[rIndx, cIndx], matrix[rIndx + 1, cIndx] + 1);
                    }

                    if (cIndx + 1 < colLength && matrix[rIndx, cIndx + 1] != Int32.MaxValue)
                    {
                        matrix[rIndx, cIndx] = Math.Min(matrix[rIndx, cIndx], matrix[rIndx, cIndx + 1] + 1);
                    }
                }
            }

            return matrix;
        }
    }
}