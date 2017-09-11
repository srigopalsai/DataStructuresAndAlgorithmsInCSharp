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

            for (int rIndx = 0; rIndx < matrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < matrix.GetLength(1); cIndx++)
                {
                    int length = FindLargestAround(rIndx, cIndx, matrix, cache, int.MaxValue);
                    max = Math.Max(length, max);
                }
            }
            return max;
        }

		//Flood Fill Approach
        private int FindLargestAround(int rIndx, int cIndx, int[,] matrix, int[,] cache, int prevVal)
        {
            // if out of bond OR current cell value larger than previous cell value.
            if (rIndx < 0 || rIndx >= matrix.GetLength(0) || cIndx < 0 || cIndx >= matrix.GetLength(1) || matrix[rIndx, cIndx] >= prevVal)
                return 0;

            // if calculated before, no need to do it again
            if (cache[rIndx, cIndx] > 0)
                return cache[rIndx, cIndx];

            int cur = matrix[rIndx, cIndx];
            int tempMax = 0;

            tempMax = Math.Max(FindLargestAround(rIndx - 1, cIndx, matrix, cache, cur), tempMax);
            tempMax = Math.Max(FindLargestAround(rIndx + 1, cIndx, matrix, cache, cur), tempMax);
            tempMax = Math.Max(FindLargestAround(rIndx, cIndx - 1, matrix, cache, cur), tempMax);
            tempMax = Math.Max(FindLargestAround(rIndx, cIndx + 1, matrix, cache, cur), tempMax);

            cache[rIndx, cIndx] = ++tempMax;

            return tempMax;           
        }
    }
}
