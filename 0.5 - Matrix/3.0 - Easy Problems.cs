using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    //http://en.wikipedia.org/wiki/Substitution_matrix
    //http://en.wikipedia.org/wiki/Distance_matrix
    //http://en.wikipedia.org/wiki/Similarity_matrix
    //http://en.wikipedia.org/wiki/Transpose

    partial class MatrixOperations
    {
        public void TransposeMatrixTest()
        {
            resultArrayString.Clear();
            AppendMatrixToResultString(RectangularMatrix4x4, "Input Matrix");

            TransposeMatrix(RectangularMatrix4x4);

            List<int> matrixList = new List<int>();

            AppendMatrixToResultString(RectangularMatrix4x4, "Output Matrix");
            ShowResultString();
        }

        // Assuming square matrix.
        public void TransposeMatrix(int[,] matrix)
        {
            int tempElement = 0;

            for (int lpDiagCnt = 0; lpDiagCnt < matrix.GetLength(0); lpDiagCnt++)
            {
                for (int lpBackCnt = lpDiagCnt - 1; lpBackCnt >= 0; lpBackCnt--)
                {
                    tempElement = matrix[lpDiagCnt, lpBackCnt];
                    matrix[lpDiagCnt, lpBackCnt] = matrix[lpBackCnt, lpDiagCnt];
                    matrix[lpBackCnt, lpDiagCnt] = tempElement;
                }
            }
        }

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
        // 498 https://leetcode.com/problems/diagonal-traverse
        // Index Bound Error if we change the order of if condition blocks

        public int[] FindDiagonalOrder(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0)
            {
                return new int[0];
            }

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int[] result = new int[rowLength * colLength];
            int rowIndx = 0;
            int colIndx = 0;
            int dIndx = 0;

            int[,] directions = { { -1, 1 }, { 1, -1 } };

            for (int index = 0; index < rowLength * colLength; index++)
            {
                result[index] = matrix[rowIndx, colIndx];

                rowIndx += directions[dIndx, 0];
                colIndx += directions[dIndx, 1];

                if (rowIndx >= rowLength)
                {
                    rowIndx = rowLength - 1;
                    colIndx += 2;
                    dIndx = 1 - dIndx;
                }
                if (colIndx >= colLength)
                {
                    colIndx = colLength - 1;
                    rowIndx += 2;
                    dIndx = 1 - dIndx;
                }
                if (rowIndx < 0)
                {
                    rowIndx = 0;
                    dIndx = 1 - dIndx;
                }
                if (colIndx < 0)
                {
                    colIndx = 0;
                    dIndx = 1 - dIndx;
                }
            }

            return result;
        }

        public int[] FindDiagonalOrder1(int[,] matrix)
        {
            if (matrix.Length == 0)
            {
                return new int[0];
            }

            int rowIndx = 0;
            int colIndx = 0;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            int[] resultArray = new int[rowLength * colLength];

            for (int index = 0; index < resultArray.Length; index++)
            {
                resultArray[index] = matrix[rowIndx, colIndx];

                if ((rowIndx + colIndx) % 2 == 0) // Move Up
                {
                    if (colIndx == colLength - 1)
                        rowIndx++;
                    else if (rowIndx == 0)
                        colIndx++;
                    else
                    {
                        rowIndx--;
                        colIndx++;
                    }
                }
                else // Move Down
                {
                    if (rowIndx == rowLength - 1)
                        colIndx++;
                    else if (colIndx == 0)
                        rowIndx++;
                    else
                    {
                        rowIndx++;
                        colIndx--;
                    }
                }
            }
            return resultArray;
        }

        public void DiagonalOrderDisplay(int[,] matrix)
        {
            int ROW = matrix.GetLength(0);
            int COL = matrix.GetLength(1);

            // There will be ROW+COL-1 lines in the output
            for (int line = 1; line <= (ROW + COL - 1); line++)
            {
                /* Get column index of the first element in this line of output.
                   The index is 0 for first ROW lines and line - ROW for remaining lines  */
                int start_col = Math.Max(0, line - ROW);

                /* Get count of elements in this line. 
                 * The count of elements is equal to minimum of line number, COL-start_col and ROW */
                int count = Math.Min(line, Math.Min((COL - start_col), ROW));

                for (int j = 0; j < count; j++)
                {
                    Console.WriteLine(matrix[Math.Min(ROW, line) - j - 1, start_col + j]);
                }
                Console.WriteLine();
            }
        }

        // Driver program to test above functions
        int DiagonalOrderDisplayTest()
        {
            int[,] M = {{1, 2, 3, 4},
                       {5, 6, 7, 8},
                       {9, 10, 11, 12},
                       {13, 14, 15, 16},
                       {17, 18, 19, 20},
                      };

            Console.WriteLine("\nDiagonal printing of matrix is \n");
            DiagonalOrderDisplay(M);
            return 0;
        }

        public static void DiagnolTraversalTR2BL(int[,] mat)
        {
            int rTrvIndx = 0;
            int cTrvIndx = mat.GetLength(1) - 1;

            while (rTrvIndx < mat.GetLength(0))
            {
                int rIndx = rTrvIndx;
                int cIndx = cTrvIndx;
                int indx = Math.Abs(cTrvIndx - rTrvIndx);

                while (indx < mat.GetLength(0))
                {
                    Console.Write(mat[rIndx, cIndx] + " ");
                    rIndx++;
                    cIndx++;
                    indx++;
                }

                if (cTrvIndx == 0)
                    rTrvIndx++;
                else
                    cTrvIndx--;

                Console.WriteLine();
            }
        }

        static void DiagnolTraversalTR2BLTest(string[] args)
        {
            int[,] mat = new int[,] {  {01,02,03,04,05},
                                        {06,07,08,09,10},
                                        {11,12,13,14,15},
                                        {16,17,18,19,20},
                                        {21,22,23,24,25} };

            DiagnolTraversalTR2BL(mat);
        }
        // 329 https://leetcode.com/problems/longest-increasing-path-in-a-matrix/?tab=Description

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

        // https://www.geeksforgeeks.org/inplace-rotate-square-matrix-by-90-degrees/
        // https://www.geeksforgeeks.org/rotate-matrix-90-degree-without-using-extra-space-set-2/
        //Uses : Imagae Rotation
        //http://en.wikipedia.org/wiki/Rotation_matrix

        //http://stackoverflow.com/questions/42519/how-do-you-rotate-a-two-dimensional-array?rq=1
        //http://stackoverflow.com/questions/2893101/how-to-rotate-a-n-x-n-matrix-by-90-degrees

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

        // 541 - 0 1 Matrix https://leetcode.com/problems/01-matrix
        /*  Given a matrix consists of 0 and 1, find the distance of the nearest 0 for each cell. 
            The distance between two adjacent cells is 1. 

            Input:  0 0 0                   Output: 0 0 0
                    0 1 0                           0 1 0
                    0 0 0                           0 0 0

            Input:  0 0 0                   Output: 0 0 0  
                    0 1 0                           0 1 0
                    1 1 1                           1 2 1

            Note:   The number of elements of the given matrix will not exceed 10,000.
                    There are at least one 0 in the given matrix.
                    The cells are adjacent in only four directions: up, down, left and right.        */

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


        /**
         Video link - https://youtu.be/2xvJ41-hsoE
 
         Given a 2D matrix of 0s and 1s. Find largest rectangle of all 1s in this matrix.
 
         Maintain a temp array of same size as number of columns. 
         Copy first row to this temp array and find largest rectangular area for histogram. 
         Then keep adding elements of next row to this temp array if they are not zero. 
         If they are zero then put zero there. Every time calculate max area in histogram.
 
         Time complexity - O(rows*cols)
         Space complexity - 2 X O(cols) - if number of cols is way higher than rows then do this process for rows and not columns.
 
         References:

         https://leetcode.com/problems/maximal-rectangle
         */

        public int MaximalRectangle(char[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return 0;

            int area = 0;
            int maxArea = 0;

            int[] dpLkUp = new int[matrix.GetLength(1)];

            for (int rIndx = 0; rIndx < matrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < matrix.GetLength(1); cIndx++)
                {
                    if (matrix[rIndx, cIndx] == '0')
                    {
                        dpLkUp[cIndx] = 0;
                    }
                    else
                    {
                        dpLkUp[cIndx] += 1;//(int)Char.GetNumericValue(matrix[rIndx, cIndx]);
                    }
                }

                area = MaxAreaHistogram(dpLkUp);

                maxArea = Math.Max(area, maxArea);
            }
            return maxArea;
        }

        public int MaxAreaHistogram(int[] heights)
        {
            int area = 0;
            int maxArea = 0;

            Stack<int> stack = new Stack<int>();

            for (int indx = 0; indx <= heights.Length; indx++)
            {
                int curHeight = indx == heights.Length ? 0 : heights[indx];

                if (stack.Count == 0 || curHeight >= heights[stack.Peek()])
                {
                    stack.Push(indx);
                    continue;
                }

                while (stack.Count > 0 && curHeight < heights[stack.Peek()])
                {
                    int top = stack.Pop();

                    area = heights[top] * (stack.Count == 0 ? indx : indx - 1 - stack.Peek());

                    maxArea = Math.Max(maxArea, area);
                }

                stack.Push(indx);
            }

            return maxArea;
        }

        // 223 https://leetcode.com/problems/rectangle-area
        int ComputeArea(int tl1, int tr1, int bl1, int br1, int tl2, int tr2, int bl2, int br2)
        {

            int left = Math.Max(tl1, tl2);
            int right = Math.Max(Math.Min(bl1, bl2), left);

            int bottom = Math.Max(tr1, tr2);
            int top = Math.Max(Math.Min(br1, br2), bottom);

            return (bl1 - tl1) * (br1 - tr1) -
                   (right - left) * (top - bottom) +
                   (bl2 - tl2) * (br2 - tr2);
        }        
    }
}