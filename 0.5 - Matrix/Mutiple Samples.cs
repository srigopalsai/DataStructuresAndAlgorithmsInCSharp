using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class MatrixSamples
    {
        // 566 https://leetcode.com/problems/reshape-the-matrix/description/
        public int[,] MatrixReshape(int[,] nums, int rowLength, int colLength)
        {
            int matRowLength = nums.GetLength(0);
            int matColLength = nums.GetLength(1);

            if (rowLength * colLength != matRowLength * matColLength)
            {
                return nums;
            }

            int[,] resultMatrix = new int[rowLength, colLength];

            for (int index = 0; index < rowLength * colLength; index++)
            {
                resultMatrix[index / colLength, index % colLength] = nums[index / matColLength, index % matColLength];
            }

            return resultMatrix;
        }
    }
}
