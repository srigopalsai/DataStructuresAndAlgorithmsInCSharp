using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    http://stackoverflow.com/questions/4311694/maximize-the-rectangular-area-under-histogram?lq=1  
    http://stackoverflow.com/questions/4303813/find-the-row-representing-the-smallest-integer-in-row-wise-sorted-matrix?rq=1
    http://stackoverflow.com/a/4303939/2466650
    http://stackoverflow.com/questions/11446223/finding-complete-rectangles-enclosing-0?rq=1
    http://stackoverflow.com/questions/746082/how-to-find-list-of-possible-words-from-a-letter-matrix-boggle-solver?rq=1
    http://stackoverflow.com/questions/2478447/find-largest-rectangle-containing-only-zeros-in-an-n%c3%97n-binary-matrix?rq=1
    http://blog.csdn.net/arbuckle/article/details/710988
    http://www.informatik.uni-ulm.de/acm/Locals/2003/html/judge.html
    In a given binary araay Find largest sub array which can be made by zeros and return its size.
    E.g.
    
    Input:
    
    1	1	1	1	1
    0	1	0	0	0
    0	1	0	0	0
    1	0	0	0	0
    1	0	0	0	1
    
    Output: 9

    Largest Rectangle in a Histogram.
    Has different solutions from O(N^2), O(N log N) and O(N) - Using Stacks.
    Brute Force - O(N^2)
    
    Dynamic Programming
    1 1 1 0 0 0
    0 0 0 0 0 0 0 0 0 1 1 1 1 1 0

    ======================================================================================================================================
    
    Dynamic programming:
    Is a method for solving complex problems by breaking them down into simpler subproblems.
    
    Need to test

    1 1 1 1 0 0 0 0 0 1 0 0 1 1 1
    0 1 1 1 1 1 0 0 0 1 0 0 1 1 0
    0 0 0 1 1 1 1 1 0 1 0 0 1 0 0
    0 0 0 0 0 1 1 1 1 1 0 0 0 0 0
    0 0 0 0 0 0 0 1 1 
    
    It makes possible to count the number of solutions without visiting them all. 
        Imagine backtracking values for the first row – what information would we require about the remaining rows, in order to be able to accurately count the solutions obtained for each first row value? 
    
    It takes far less time than naive methods that don't take advantage of the subproblem overlap (like depth-first search).
    The idea to solve a given problem, 
    we need to solve different parts of the problem (subproblems), then combine the solutions of the subproblems to reach an overall solution.

    When using a more naive method, many of the subproblems are generated and solved many times. 
    The dynamic programming approach seeks to solve each subproblem only once, thus reducing the number of computations: once the solution to a given subproblem has been computed, 
    it is stored or "memo-ized": the next time the same solution is needed, it is simply looked up. 
    This approach is especially useful when the number of repeating subproblems grows exponentially as a function of the size of the input.

    Dynamic programming algorithms are used for optimization (for example, finding the shortest path between two points, or the fastest way to multiply many matrices). 
    A dynamic programming algorithm will examine all possible ways to solve the problem and will pick the best solution. 
    Therefore, we can roughly think of dynamic programming as an intelligent, brute-force method that enables us to go through all possible solutions to pick the best one.
    
    http://en.wikipedia.org/wiki/Dynamic_programming

    http://stackoverflow.com/questions/19610071/naive-way-to-find-largest-block-in-a-rectangle-of-1s-and-0s/19610652#19610652
    http://www.bing.com/search?q=scan+line+algorithms&form=IE11TR&src=IE11TR&pc=SNJB
    http://www.informatik.uni-ulm.de/acm/Locals/2003/html/judge.html
    http://en.wikipedia.org/wiki/Block_matrix
    ======================================================================================================================================

    */
    partial class MatrixOperations
    {
        int totalHitsInSideLoops = 0;
        int maxBlock = 0;
        int foundBlocks = 0;

        public void MaxBlock()
        {
            int[,] inputArray = {   {1,0,0,0,1},
                                    {0,0,0,1,0},
                                    {0,0,0,0,0},
                                    {1,0,1,0,1},
                                    {0,0,0,0,0}
                                };

            //int[,] inputArray = {   {1,	1,	0,	0,	1},
            //                        {0,	1,	0,	0,	0},
            //                        {0,	1,	0,	0,	0},
            //                        {1,	0,	0,	0,	0},
            //                        {1,	0,	0,	0,	1}
            //                    };

            //int[,] inputArray = {   {	0,	0,	0},
            //                        {	0,	0,	0},
            //                        {	0,	0,	0},
            //                        {	0,	0,	1}
            //                    };

            maxBlock = 0;
            foundBlocks = 0;

            int RowLen = inputArray.GetLength(0) - 1;
            int ColLen = inputArray.GetLength(1) - 1;

            totalHitsInSideLoops = 0;

            for (int lpRCnt = 0; lpRCnt <= RowLen; lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt <= ColLen; lpCCnt++)
                {
                    totalHitsInSideLoops++;

                    int RowsRemain = (RowLen + 1) - lpRCnt;
                    int ColsRemain = (ColLen + 1) - lpRCnt;

                    // Already found Max Block, so break both loops
                    //if (maxBlock >= (RowsRemain * ColsRemain))
                    //{
                    //    goto Break2Loops;
                    //}

                    if (inputArray[lpRCnt, lpCCnt] == 0)
                    {
                        MaxBlock(inputArray, lpRCnt, lpCCnt);
                    }
                }
            }

            //Break2Loops:
            //            MessageBox.Show("Biggest Zero's Block in the Matrix is " + maxBlock + "\nTotal hits " + totalHitsInSideLoops);

        }

        public void MaxBlock(int[,] matrix, int rSrcIdx, int cSrcIdx)
        {
            int rLen = matrix.GetLength(0) - 1;
            int cLen = matrix.GetLength(1) - 1;

            foundBlocks = 0;

            for (int rIndx = rSrcIdx; rIndx <= rLen; rIndx++)
            {
                for (int cIndx = cSrcIdx; cIndx <= cLen; cIndx++)
                {
                    totalHitsInSideLoops++;

                    if (matrix[rIndx, cIndx] == 0)
                    {
                        foundBlocks++;
                    }
                    else
                    {
                        // Rollback logic when 1 found. If column smaller then rollback colum cells else roll back row cells.
                        if ((rLen - rSrcIdx) > (cLen - cSrcIdx))
                        {
                            for (int indx = cIndx; indx > cSrcIdx; indx--)
                            {
                                foundBlocks--;
                            }
                        }
                        else
                        {
                            for (int indx = rIndx; indx > rSrcIdx; indx--)
                            {
                                foundBlocks--;
                            }
                        }

                        //Once rollback is done, just break 2 loops.
                        goto Break2Loops;
                    }
                }
            }

            Break2Loops:

            if (foundBlocks > maxBlock)
            {
                maxBlock = foundBlocks;
                return;
            }
        }

        public void MaxSubMatrixIndexByDPTest()
        {
            int[,] jaggaedMatrix = {{ 0, 0, 0, 0, 0 },
                                    { 1, 0, 0, 1, 1 },
                                    { 1, 0, 1, 1, 1 },
                                    { 0, 1, 1, 1, 1 },
                                    { 0, 1, 1, 1, 1 } };

            MaxSubMatrixIndexByDP(jaggaedMatrix);
        }

        public void MaxSubMatrixIndexByDP(int[,] srcMatrix)
        {
            int rIndx = 0;
            int cIndx = 0;

            int[,] tmpMatrix = new int[srcMatrix.GetLength(0), srcMatrix.GetLength(1)];

            for (rIndx = 0; rIndx < srcMatrix.GetLength(0); rIndx++)
            {
                tmpMatrix[rIndx, 0] = srcMatrix[rIndx, 0];
            }

            for (cIndx = 0; cIndx < srcMatrix.GetLength(1); cIndx++)
            {
                tmpMatrix[0, cIndx] = srcMatrix[0, cIndx];
            }

            int minEntry = 0;

            for (rIndx = 1; rIndx < srcMatrix.GetLength(0); rIndx++)
            {
                for (cIndx = 1; cIndx < srcMatrix.GetLength(1); cIndx++)
                {
                    minEntry = Math.Min(tmpMatrix[rIndx, cIndx - 1], tmpMatrix[rIndx - 1, cIndx]);
                    minEntry = Math.Min(tmpMatrix[rIndx - 1, cIndx - 1], minEntry);

                    if (srcMatrix[rIndx, cIndx] == 1)
                    {
                        tmpMatrix[rIndx, cIndx] = minEntry + 1;
                    }
                    else
                    {
                        tmpMatrix[rIndx, cIndx] = 0;
                    }
                }
            }

            // Iterate through the temp matrix to get the max size and indices - O (N X M) Time
            int maxSize = 0;
            int rowPos = -1;
            int colPos = -1;

            for (rIndx = 0; rIndx < srcMatrix.GetLength(0); rIndx++)
            {
                for (cIndx = 0; cIndx < srcMatrix.GetLength(1); cIndx++)
                {
                    if (maxSize < tmpMatrix[rIndx, cIndx])
                    {
                        maxSize = tmpMatrix[rIndx, cIndx];
                        rowPos = rIndx;
                        colPos = cIndx;
                    }
                }
            }

            MessageBox.Show("Size of the Biggest square sub-matrix: " + maxSize);
            MessageBox.Show("It starts at (" + (rowPos - maxSize + 1) + "," + (colPos - maxSize + 1) + ")");
        }

        // https://www.geeksforgeeks.org/dynamic-programming-set-27-max-sum-rectangle-in-a-2d-matrix/
        public void MaxSumSquareMatrix(int[,] srcMatrix, int kSize)
        {
            int rIndx = 0;
            int cIndx = 0;
            int rLen = srcMatrix.GetLength(0);
            int cLen = srcMatrix.GetLength(1);

            int[,] tmpMatrix = new int[rLen - kSize + 1, cLen];
            int curSum = 0;
            int maxSum = int.MinValue;

            for (cIndx = 0; cIndx < rLen; cIndx++)
            {
                curSum = 0;
                for (rIndx = 0; rIndx < kSize; rIndx++)
                {
                    curSum += srcMatrix[rIndx, cIndx];
                }

                tmpMatrix[0, cIndx] = curSum;

                for (rIndx = 1; rIndx < cLen - kSize + 1; rIndx++)
                {
                    curSum = curSum - srcMatrix[rIndx - 1, cIndx] + srcMatrix[rIndx + kSize - 1, cIndx];
                    tmpMatrix[rIndx, cIndx] = curSum;
                }
            }

            curSum = 0;

            int tmpSum = 0;
            int tmpRIndx = -1;
            int tmpCIndx = -1;

            for (rIndx = 0; rIndx < tmpMatrix.Length; rIndx++)
            {
                tmpSum = 0;

                for (cIndx = 0; cIndx < kSize; cIndx++)
                {
                    tmpSum += tmpMatrix[rIndx, cIndx];
                }

                if (tmpSum > maxSum)
                {
                    maxSum = tmpSum;
                    tmpRIndx = rIndx;
                    tmpCIndx = cIndx;
                }

                curSum = tmpSum;

                for (cIndx = 1; cIndx < cLen - kSize + 1; cIndx++)
                {
                    curSum = curSum - tmpMatrix[rIndx, cIndx - 1] + tmpMatrix[rIndx, cIndx + kSize - 1];

                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        tmpRIndx = rIndx;
                        tmpCIndx = cIndx;
                    }
                }
            }

            for (rIndx = tmpRIndx; rIndx < tmpRIndx + kSize; rIndx++)
            {
                for (cIndx = tmpCIndx; cIndx < tmpCIndx + kSize; cIndx++)
                {
                    Console.Write(srcMatrix[rIndx, cIndx] + " ");
                }

                Console.WriteLine();
            }
        }

        public void MaxSumSquareMatrixTest()
        {
            int[,] mat = {
                    { 1, 1, 1, 1, 1 },
                    { 2, 2, 2, 2, 2 },
                    { 3, 8, 6, 7, 3 },
                    { 4, 4, 4, 4, 4 },
                    { 5, 5, 5, 5, 5 },

                };

            int k = 3;

            MaxSumSquareMatrix(mat, k);
        }

        // https://www.cdn.geeksforgeeks.org/find-orientation-of-a-pattern-in-a-matrix/
        public void StringSearchTest(String[] args)
        {
            char[,] mat3 = {{ 'a', 'b', 'c', 'd', 'e' },
                        { 'f', 'g', 'h', 'i', 'j' },
                        { 'k', 'l', 'm', 'n', 'o' },
                        { 'p', 'q', 'r', 's', 't' },
                        { 'u', 'v', 'w', 'x', 'y' } };

            char[,] mat = { { 'a', 'b', 'c', 'd', 'e' },
                    { 'f', 'p', 'h', 'i', 'j' },
                    { 'k', 'q', 'm', 'n', 'o' },
                    { 'g', 'r', 'r', 's', 't' },
                    { 'u', 's', 'w', 'x', 'y' } };

            char[,] mat2 = {{ 'a', 'b', 'c', 'd', 'e' },
                    { 'f', 's', 'h', 'i', 'j' },
                    { 'k', 'r', 'm', 'n', 'o' },
                    { 'g', 'q', 'r', 's', 't' },
                    { 'u', 'p', 'w', 'x', 'y' } };

            String pattern = "pqrs";
            StringSearchByKMP(mat, pattern);
        }

        public int[] CreateIndexArray(char[,] matrix, String type, int index)
        {
            StringBuilder sb = new StringBuilder();

            if ("row".Equals(type, StringComparison.CurrentCultureIgnoreCase))
            {
                for (int rIndx = 0; rIndx < matrix.GetLength(0); rIndx++)
                {
                    sb.Append(matrix[index, rIndx]);
                }
            }
            else
            {
                for (int cIndx = 0; cIndx < matrix.GetLength(1); cIndx++)
                {
                    sb.Append(matrix[cIndx, index]);
                }
            }

            return CreateIndexArray(sb.ToString());
        }

        public int[] CreateIndexArray(String newPattern)
        {
            int[] indexArr = new int[newPattern.Length];
            int rIndx = 0;
            int cIndx = 1;
            indexArr[0] = 0;

            while (rIndx < indexArr.Length && cIndx < indexArr.Length)
            {
                // If Both index have same character then we have to increment i & j
                if (newPattern[rIndx] == newPattern[cIndx])
                {
                    indexArr[cIndx] = rIndx + 1;
                    rIndx++;
                    cIndx++;
                }
                else if (rIndx == 0)
                {
                    indexArr[cIndx++] = 0;
                }
                // If Both index have not same character then we have to set index of i to i-1's value
                else
                {
                    rIndx = indexArr[rIndx - 1];
                    continue;
                }
            }
            return indexArr;

        }

        public void StringSearchByKMP(char[,] matrix, string pattern)
        {
            // Row wise pattern matching
            for (int rIndx = 0; rIndx < matrix.GetLength(0); rIndx++)
            {
                int[] patternIndexer = CreateIndexArray(matrix, "row", rIndx);

                int rLen = matrix.GetLength(0);
                int patLen = pattern.Trim().Length;

                int cIndx = 0;
                int pIndx = 0;

                while (cIndx < rLen && pIndx < patLen)
                {
                    if (matrix[rIndx, cIndx] == pattern[pIndx])
                    {
                        pIndx++;
                        cIndx++;
                    }
                    else
                    {
                        if (pIndx - 1 >= 0 && patternIndexer[pIndx - 1] != 0)
                        {
                            pIndx = patternIndexer[pIndx - 1];
                        }
                        else if (pIndx - 1 >= 0 && patternIndexer[pIndx - 1] == 0)
                        {
                            pIndx = 0;
                        }
                        else
                        {
                            cIndx++;
                        }
                    }
                }
                if (pIndx == patLen)
                {
                    Console.WriteLine("Horizontal");
                    break;
                }
            }

            // Column wise pattern matching

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int[] patternIndexer = CreateIndexArray(matrix, "column", i);
                int maxRow = matrix.GetLength(0);
                int patternLength = pattern.Trim().Length;
                int l = 0;
                int k = 0;

                while (l < maxRow && k < patternLength)
                {
                    if (matrix[l, i] == pattern[k])
                    {
                        k++;
                        l++;
                    }
                    else
                    {
                        if (k - 1 >= 0 && patternIndexer[k - 1] != 0)
                        {
                            k = patternIndexer[k - 1];
                        }
                        else if (k - 1 >= 0 && patternIndexer[k - 1] == 0)
                        {
                            k = 0;
                        }
                        else
                        {
                            l++;
                        }
                    }
                }

                if (k == patternLength)
                {
                    Console.WriteLine("Vertical");
                    break;
                }
            }
        }

        // https://www.cdn.geeksforgeeks.org/find-a-specific-pair-in-matrix/
        // Find a specific pair in matrix
        // The function returns maximum value A(c,d) - A(a,b)
        // over all choices of indexes such that both c > a
        // and d > b.
        public int MaxValue(int[,] matrix)
        {
            int maxValue = int.MinValue;
            int rLen = matrix.GetLength(0);

            int[,] maxMatrix = new int[rLen, rLen];

            // last element of maxArr will be same's as of the input matrix
            maxMatrix[rLen - 1, rLen - 1] = matrix[rLen - 1, rLen - 1];

            // Pre Process last row
            int maxVal = matrix[rLen - 1, rLen - 1];  // Initialize max

            for (int cIndx = rLen - 2; cIndx >= 0; cIndx--)
            {
                if (matrix[rLen - 1, cIndx] > maxVal)
                {
                    maxVal = matrix[rLen - 1, cIndx];
                }
                maxMatrix[rLen - 1, cIndx] = maxVal;
            }

            // Pre Process last column
            maxVal = matrix[rLen - 1, rLen - 1];  // Initialize max

            for (int rIndx = rLen - 2; rIndx >= 0; rIndx--)
            {
                if (matrix[rIndx, rLen - 1] > maxVal)
                {
                    maxVal = matrix[rIndx, rLen - 1];
                }
                maxMatrix[rIndx, rLen - 1] = maxVal;
            }

            // Pre Process rest of the matrix from bottom
            for (int rIndx = rLen - 2; rIndx >= 0; rIndx--)
            {
                for (int cIndx = rLen - 2; cIndx >= 0; cIndx--)
                {
                    // Update maxValue
                    if (maxMatrix[rIndx + 1, cIndx + 1] - matrix[rIndx, cIndx] > maxValue)
                    {
                        maxValue = maxMatrix[rIndx + 1, cIndx + 1] - matrix[rIndx, cIndx];
                    }

                    maxMatrix[rIndx, cIndx] = Math.Max(matrix[rIndx, cIndx], Math.Max(maxMatrix[rIndx, cIndx + 1], maxMatrix[rIndx + 1, cIndx]));
                }
            }

            return maxValue;
        }

        public void MaxValueTest()
        {
            int N = 5;

            int[,] mat = {
                      { 1, 2, -1, -4, -20 },
                      { -8, -3, 4, 2, 1 },
                      { 3, 8, 6, 1, 3 },
                      { -4, -1, 1, 7, -6 },
                      { 0, -4, 10, -5, 1 }
                   };

            Console.WriteLine("Maximum Value is " + MaxValue(mat));
        }
    }

    public static class MatrixExtensions
    {
        public static IEnumerable<T> SliceRow<T>(this T[,] array, int row)
        {
            for (var i = array.GetLowerBound(1); i <= array.GetUpperBound(1); i++)
            {
                yield return array[row, i];
            }
        }

        public static IEnumerable<T> SliceColumn<T>(this T[,] array, int column)
        {
            for (var i = array.GetLowerBound(0); i <= array.GetUpperBound(0); i++)
            {
                yield return array[i, column];
            }
        }

        /// <summary>
        /// Returns the row with number 'row' of this matrix as a 1D-Array.
        /// </summary>
        public static T[] GetRow<T>(this T[,] matrix, int row)
        {
            var rowLength = matrix.GetLength(1);
            var rowVector = new T[rowLength];

            for (var i = 0; i < rowLength; i++)
                rowVector[i] = matrix[row, i];

            return rowVector;
        }

        /// <summary>
        /// Sets the row with number 'row' of this 2D-matrix to the parameter 'rowVector'.
        /// </summary>
        public static void SetRow<T>(this T[,] matrix, int row, T[] rowVector)
        {
            var rowLength = matrix.GetLength(1);

            for (var i = 0; i < rowLength; i++)
                matrix[row, i] = rowVector[i];
        }

        /// <summary>
        /// Returns the column with number 'col' of this matrix as a 1D-Array.
        /// </summary>
        public static T[] GetCol<T>(this T[,] matrix, int col)
        {
            var colLength = matrix.GetLength(0);
            var colVector = new T[colLength];

            for (var i = 0; i < colLength; i++)
                colVector[i] = matrix[i, col];

            return colVector;
        }

        /// <summary>
        /// Sets the column with number 'col' of this 2D-matrix to the parameter 'colVector'.
        /// </summary>
        public static void SetCol<T>(this T[,] matrix, int col, T[] colVector)
        {
            var colLength = matrix.GetLength(0);

            for (var i = 0; i < colLength; i++)
                matrix[i, col] = colVector[i];
        }
    }
}
	   
/*

0	0	0	0	0
1	0	1	1	1
1	0	1	1	1
0	1	1	1	1
0	1	1	1	1

*/

//static int min(int a, int b, int c)
//{
//    return ((a<b)?((a<c)?a:c):((b<c)?b:c));
//}

//static int Largest_matrix(int[,] input, int[,] temp, int size)
//{
//    int i, j;

//    int max=0; // this variable stores maximum value 

//    /* last row values storing in temp*/
//    for (i = size - 1, j = 0; j < size; j++)
//    {
//        temp[i,j] = input[i,j] ^ 1;
//    }
//    /* last column values storing in temp */
//    for (i = 0, j = size - 1; i < size - 1; i++)
//    {
//        temp[i,j] = input[i,j] ^ 1;
//    }

//    for (i = size - 2; i >= 0; i--)
//    {
//        for (j = size - 2; j >= 0; j--)
//        {
//            if ((input[i,j] == 0) && !(input[i,j] ^ input[i + 1,j] ^ input[i + 1,j + 1] ^ input[i,j + 1]))
//            {
//                temp[i,j] = 1 + min(temp[i + 1,j], temp[i + 1,j + 1], temp[i,j + 1]);
//                if (max < temp[i,j])
//                    max = temp[i,j];
//            }
//            else
//            {
//                temp[i,j] = input[i,j] ^ 1;
//            }
//        }
//    }
//    return max;
//}


//int main()
//{
//    int[,] input = {
//        {1,0,0,0,1},
//        {0,0,0,0,0},
//        {0,0,0,0,0},
//        {1,0,1,0,0},
//        {0,0,0,0,0}
//    };

//    int[,] temp[5,5] = {0};

//    printf("\n largest matrix is %d\n", Largest_matrix(input, temp, 5));

//    for(int i=0; i<;5; i++ )
//    {
//        for(int j=0; j<;5; j++ )
//        {
//            printf("%d, ", temp[i,j] );
//        }
//        printf("\n");
//    }

//}

//public int solution3(int[] height)
//{

//    int n = height.Length;
//    if (n == 0) return 0;

//    Stack<Int32> left = new Stack<Int32>();
//    Stack<Int32> right = new Stack<Int32>();

//    int[] width = new int[n];// widths of intervals.

//    Array.fill(width, 1);// all intervals should at least be 1 unit wide.

//    for (int i = 0; i < n; i++)
//    {
//        // count # of consecutive higher bars on the left of the (i+1)th bar
//        while (!left.isEmpty() && height[i] <= height[left.Peek()])
//        {
//            // while there are bars stored in the stack, we check the bar on the top of the stack.
//            left.Pop();
//        }

//        if (left.isEmpty())
//        {
//            // all elements on the left are larger than height[i].
//            width[i] += i;
//        }
//        else
//        {
//            // bar[left.peek()] is the closest shorter bar.
//            width[i] += i - left.Peek() - 1;
//        }
//        left.Push(i);
//    }

//    for (int i = n - 1; i >= 0; i--)
//    {

//        while (!right.isEmpty() && height[i] <= height[right.Peek()])
//        {
//            right.Pop();
//        }

//        if (right.isEmpty())
//        {
//            // all elements to the right are larger than height[i]
//            width[i] += n - 1 - i;
//        }
//        else
//        {
//            width[i] += right.Peek() - i - 1;
//        }
//        right.Push(i);
//    }

//    int max = Int32.MinValue;
//    for (int i = 0; i < n; i++)
//    {
//        // find the maximum value of all rectangle areas.
//        max = Math.Max(max, width[i] * height[i]);
//    }

//    return max;
//}