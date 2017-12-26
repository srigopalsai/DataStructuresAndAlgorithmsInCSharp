using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/Substitution_matrix
    http://en.wikipedia.org/wiki/Distance_matrix
    http://en.wikipedia.org/wiki/Similarity_matrix
    http://en.wikipedia.org/wiki/Transpose

    */

    partial class MatrixOperations
    {
        // 566 https://leetcode.com/problems/reshape-the-matrix/
        public int[,] MatrixReshape(int[,] nums, int newRLen, int newCLen)
        {
            int oldRLen = nums.GetLength(0);
            int oldCLen = nums.GetLength(1);

            if (newRLen * newCLen != oldRLen * oldCLen)
            {
                return nums;
            }

            int[,] resultMat = new int[newRLen, newCLen];

            for (int index = 0; index < newRLen * newCLen; index++)
            {
                resultMat[index / newCLen, index % newCLen] = nums[index / oldCLen, index % oldCLen];
            }

            return resultMat;
        }

        // 498 https://leetcode.com/problems/diagonal-traverse/description/
        public int[] FindDiagonalOrder(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return new int[0];

            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);

            int[] result = new int[m * n];
            int row = 0;
            int col = 0;
            int d = 0;

            int[,] dirs = { { -1, 1 }, { 1, -1 } };

            for (int indx = 0; indx < m * n; indx++)
            {
                result[indx] = matrix[row, col];

                row += dirs[d, 0];
                col += dirs[d, 1];

                if (row >= m)
                {
                    row = m - 1;
                    col += 2;
                    d = 1 - d;
                }

                if (col >= n)
                {
                    col = n - 1;
                    row += 2;
                    d = 1 - d;
                }

                if (row < 0)
                {
                    row = 0;
                    d = 1 - d;
                }

                if (col < 0)
                {
                    col = 0;
                    d = 1 - d;
                }
            }

            return result;
        }

        public int[] FindDiagonalOrder2(int[,] matrix)
        {
            if (matrix.Length == 0)
            {
                return new int[0];
            }

            int rIndx = 0;
            int cIndx = 0;

            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);

            int[] arr = new int[rLen * cLen];

            for (int indx = 0; indx < arr.Length; indx++)
            {
                arr[indx] = matrix[rIndx, cIndx];

                if ((rIndx + cIndx) % 2 == 0)
                {
                    // moving up
                    if (cIndx == cLen - 1)
                    {
                        rIndx++;
                    }
                    else if (rIndx == 0)
                    {
                        cIndx++;
                    }
                    else
                    {
                        rIndx--;
                        cIndx++;
                    }
                }
                else
                {
                    // moving down
                    if (rIndx == rLen - 1)
                    {
                        cIndx++;
                    }
                    else if (cIndx == 0)
                    {
                        rIndx++;
                    }
                    else
                    {
                        rIndx++;
                        cIndx--;
                    }
                }
            }
            return arr;
        }
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

        public void Rotate(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col < matrix.GetLength(1); col++)
                {
                    int temp = 0;
                    temp = matrix[row, col];
                    matrix[row, col] = matrix[col, row];
                    matrix[col, row] = temp;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int temp = 0;
                    temp = matrix[row, col];
                    matrix[row, col] = matrix[row, matrix.GetLength(1) - 1 - col];
                    matrix[row, matrix.GetLength(1) - 1 - col] = temp;
                }
            }
        }

        public void Rotate2(int[,] matrix)
        {
            int length = matrix.GetLength(0);

            for (int layer = 0; layer < length / 2; layer++) // Top Left
            {
                // For every layer change, consider new left, top, right positions.
                int top = layer;
                int left = layer;
                int right = length - 1 - layer;

                while (top < right)
                {
                    int bottom = right - (top - layer);

                    int tempTop = matrix[left, top];

                    matrix[left, top] = matrix[bottom, left];

                    matrix[bottom, left] = matrix[right, bottom];

                    matrix[right, bottom] = matrix[top, right];

                    matrix[top, right] = tempTop;

                    top++;
                }
            }
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


        // 304 https://leetcode.com/problems/range-sum-query-2d-immutable/description/
        public class NumMatrix
        {
            private int[,] dpMat;

            public NumMatrix(int[,] matrix)
            {
                if (matrix == null || matrix.Length == 0 )
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
                        dpMat[rIndx, cIndx] = dpMat[rIndx - 1, cIndx] + dpMat[rIndx, cIndx - 1] - 
                                           dpMat[rIndx - 1, cIndx - 1] + matrix[rIndx - 1, cIndx - 1];
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                int r1Indx = Math.Min(row1, row2);
                int r2Indx = Math.Max(row1, row2);

                int c1Indx = Math.Min(col1, col2);
                int c2Indx = Math.Max(col1, col2);

                return  dpMat[r2Indx + 1, c2Indx + 1] - dpMat[r2Indx + 1, c1Indx] - 
                        dpMat[r1Indx, c2Indx + 1] + dpMat[r1Indx, c1Indx];
            }
        }
    }
}