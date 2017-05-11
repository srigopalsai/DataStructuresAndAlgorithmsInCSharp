using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    // https://leetcode.com/problems/longest-increasing-path-in-a-matrix/?tab=Description
    partial class MatrixOperations
    {
        public int LongestIncreasingPath(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            int[,] cache = new int[matrix.GetLength(0), matrix.GetLength(1)];
            int max = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int length = findSmallAround(i, j, matrix, cache, int.MaxValue);
                    max = Math.Max(length, max);
                }
            }
            return max;
        }

		//Flood Fill Approach
        private int findSmallAround(int i, int j, int[,] matrix, int[,] cache, int pre)
        {
            // if out of bond OR current cell value larger than previous cell value.
            if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1) || matrix[i, j] >= pre)
                return 0;

            // if calculated before, no need to do it again
            if (cache[i, j] > 0)
                return cache[i, j];
            else
            {
                int cur = matrix[i, j];
                int tempMax = 0;

                tempMax = Math.Max(findSmallAround(i - 1, j, matrix, cache, cur), tempMax);
                tempMax = Math.Max(findSmallAround(i + 1, j, matrix, cache, cur), tempMax);
                tempMax = Math.Max(findSmallAround(i, j - 1, matrix, cache, cur), tempMax);
                tempMax = Math.Max(findSmallAround(i, j + 1, matrix, cache, cur), tempMax);

                cache[i, j] = ++tempMax;

                return tempMax;
            }
        }
    }
}
