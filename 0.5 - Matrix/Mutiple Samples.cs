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

        public int[,] MatrixReshape2(int[,] nums, int nRowLen, int nColLen)
        {

            int oRowLen = nums.GetLength(0);
            int oColLen = nums.GetLength(1);

            if (nRowLen * nColLen != oRowLen * oColLen)
                return nums;

            int index = 0;
            int[,] newArr = new int[nRowLen, nColLen];

            for (int oRowIndx = 0; oRowIndx < oRowLen; oRowIndx++)
            {
                for (int oColIndx = 0; oColIndx < oColLen; oColIndx++)
                {
                    newArr[index / nColLen, index % nColLen] = nums[oRowIndx, oColIndx];
                    index++;
                }
            }

            return newArr;
        }
    }
}
