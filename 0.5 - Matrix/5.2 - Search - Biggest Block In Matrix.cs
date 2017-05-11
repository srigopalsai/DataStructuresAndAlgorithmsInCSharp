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

        public void FindBiggestBlockInMatrix()
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
                        FindBigBlock(inputArray, lpRCnt, lpCCnt);
                    }
                }
            }

            //Break2Loops:
//            MessageBox.Show("Biggest Zero's Block in the Matrix is " + maxBlock + "\nTotal hits " + totalHitsInSideLoops);
  
            GetMaxSubMatrixIndexByDyanmicProgramming();
        }

        void FindBigBlock(int[,] inputArray, int RIdx, int CIdx)
        {
            int RLen = inputArray.GetLength(0) - 1;
            int CLen = inputArray.GetLength(1) - 1;

            foundBlocks = 0;

            for (int lpRCnt = RIdx; lpRCnt <= RLen; lpRCnt++)
            {
                for (int lpCCnt = CIdx; lpCCnt <= CLen; lpCCnt++)
                {
                    totalHitsInSideLoops++;

                    if (inputArray[lpRCnt, lpCCnt] == 0)
                    {
                        foundBlocks++;
                    }
                    else
                    {
                        // Rollback logic when 1 found. If column smaller then rollback colum cells else roll back row cells.
                        if ((RLen - RIdx) > (CLen - CIdx))
                        {
                            for (int lpCnt = lpCCnt; lpCnt > CIdx; lpCnt--)
                            {
                                foundBlocks--;
                            }
                        }
                        else
                        {
                            for (int lpCnt = lpRCnt; lpCnt > RIdx; lpCnt--)
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
            }
        }

        public void GetMaxSubMatrixIndexByDyanmicProgramming()
        {
            int[][] jaggaedMatrix = new int[5][];

            jaggaedMatrix[0] = new int[5] { 0, 0, 0, 0, 0 };
            jaggaedMatrix[1] = new int[5] { 1, 0, 0, 1, 1 };
            jaggaedMatrix[2] = new int[5] { 1, 0, 1, 1, 1 };
            jaggaedMatrix[3] = new int[5] { 0, 1, 1, 1, 1 };
            jaggaedMatrix[4] = new int[5] { 0, 1, 1, 1, 1 };

            MaxSubMatrixIndexByDP(jaggaedMatrix, jaggaedMatrix.Length, jaggaedMatrix[0].Length);
        }
        void MaxSubMatrixIndexByDP(int[][] sourceMatrix, int nRows, int nCols)
        {
            int lpRowCnt = 0;
            int lpColCnt = 0;

            // Temp Matrix Initialization -  O (N X M) Extra Space.
            int[][] tempMatrix = new int[nRows][];
            
            for (lpRowCnt = 0; lpRowCnt < nRows; lpRowCnt++)
            {
                tempMatrix[lpRowCnt] = new int[nCols];
            }

            // Copy the first column as it is to tempMatrix.
            for (lpRowCnt = 0; lpRowCnt < nRows; lpRowCnt++)
            {
                tempMatrix[lpRowCnt][0] = sourceMatrix[lpRowCnt][0];
            }

            // Copy the first row as it is to tempMatrix.
            for (lpColCnt = 0; lpColCnt < nCols; lpColCnt++)
            {
                tempMatrix[0][lpColCnt] = sourceMatrix[0][lpColCnt];
            }

            int minEntry = 0;
            
            // Calculate and fill tempMatrix - O (N X M) Time
            for (lpRowCnt = 1; lpRowCnt < nRows; lpRowCnt++)
            {
                for (lpColCnt = 1; lpColCnt < nCols; lpColCnt++)
                {
                    minEntry = Math.Min(tempMatrix[lpRowCnt][lpColCnt - 1], tempMatrix[lpRowCnt - 1][lpColCnt]);

                    minEntry = Math.Min(tempMatrix[lpRowCnt - 1][lpColCnt - 1], minEntry);

                    if (sourceMatrix[lpRowCnt][lpColCnt] == 1)
                    {
                        tempMatrix[lpRowCnt][lpColCnt] = minEntry + 1;
                    }
                    else
                    {
                        tempMatrix[lpRowCnt][lpColCnt] = 0;
                    }
                }
            }

            // Iterate through the temp matrix to get the max size and indices - O (N X M) Time
            int maxSize = 0;
            int rowPos = -1;
            int colPos = -1;

            for (lpRowCnt = 0; lpRowCnt < nRows; lpRowCnt++)
            {
                for (lpColCnt = 0; lpColCnt < nCols; lpColCnt++)
                {
                    if (maxSize < tempMatrix[lpRowCnt][lpColCnt])
                    {
                        maxSize = tempMatrix[lpRowCnt][lpColCnt];
                        rowPos = lpRowCnt;
                        colPos = lpColCnt;
                    }
                }
            }

            //r - maxSize + 1, c - maxSize + 1 indicates starting point for required sub-matrix
  
            MessageBox.Show("Size of the Biggest square sub-matrix: " + maxSize);
            MessageBox.Show("It starts at (" + (rowPos - maxSize + 1) + "," + (colPos - maxSize + 1) + ")");
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

//static int Largest_matrix(int[][] input, int[][] temp, int size)
//{
//    int i, j;

//    int max=0; // this variable stores maximum value 

//    /* last row values storing in temp*/
//    for (i = size - 1, j = 0; j < size; j++)
//    {
//        temp[i][j] = input[i][j] ^ 1;
//    }
//    /* last column values storing in temp */
//    for (i = 0, j = size - 1; i < size - 1; i++)
//    {
//        temp[i][j] = input[i][j] ^ 1;
//    }

//    for (i = size - 2; i >= 0; i--)
//    {
//        for (j = size - 2; j >= 0; j--)
//        {
//            if ((input[i][j] == 0) && !(input[i][j] ^ input[i + 1][j] ^ input[i + 1][j + 1] ^ input[i][j + 1]))
//            {
//                temp[i][j] = 1 + min(temp[i + 1][j], temp[i + 1][j + 1], temp[i][j + 1]);
//                if (max < temp[i][j])
//                    max = temp[i][j];
//            }
//            else
//            {
//                temp[i][j] = input[i][j] ^ 1;
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

//    int[][] temp[5][5] = {0};

//    printf("\n largest matrix is %d\n", Largest_matrix(input, temp, 5));

//    for(int i=0; i<;5; i++ )
//    {
//        for(int j=0; j<;5; j++ )
//        {
//            printf("%d, ", temp[i][j] );
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