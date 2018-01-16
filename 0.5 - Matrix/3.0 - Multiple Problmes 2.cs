using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class MatrixSamples
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

        // Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.
        // A region is captured by flipping all 'O's into 'X's in that surrounded region.
        // https://leetcode.com/problems/surrounded-regions/
        // TBD https://www.geeksforgeeks.org/sparse-matrix-representation/

        public void FillOsWIthXsIfSurroundedByXs(char[,] board)
        {
            if (board.GetLength(0) == 0 || board.GetLength(1) == 0)
                return;

            for (int rIndx = 0; rIndx < board.GetLength(0); rIndx++)
            {
                DfsTraversal(board, rIndx, 0);
                DfsTraversal(board, rIndx, board.GetLength(0) - 1);
            }

            for (int cIndx = 0; cIndx < board.GetLength(1); cIndx++)
            {
                DfsTraversal(board, 0, cIndx);
                DfsTraversal(board, board.Length - 1, cIndx);
            }

            for (int rIndx = 0; rIndx < board.Length; rIndx++)
            {
                for (int cIndx = 0; cIndx < board.GetLength(0); cIndx++)
                {
                    if (board[rIndx, cIndx] == 'O')
                    {
                        board[rIndx, cIndx] = 'X';
                    }
                    else if (board[rIndx, cIndx] == '1')
                    {
                        board[rIndx, cIndx] = 'O';
                    }
                }
            }
        }

        private void DfsTraversal(char[,] board, int rIndx, int cIndx)
        {
            if (rIndx < 0 || rIndx >= board.Length || cIndx < 0 || cIndx >= board.GetLength(0) 
                || board[rIndx, cIndx] != 'O')
            {
                return;
            }

            board[rIndx, cIndx] = '1';

            if (rIndx < board.Length - 2)
            {
                DfsTraversal(board, rIndx + 1, cIndx);
            }
            if (rIndx > 1)
            {
                DfsTraversal(board, rIndx - 1, cIndx);
            }
            if (cIndx < board.GetLength(0) - 2)
            {
                DfsTraversal(board, rIndx, cIndx + 1);
            }
            if (cIndx > 1)
            {
                DfsTraversal(board, rIndx, cIndx - 1);
            }
        }

        public void FillOsWIthXsIfSurroundedByXsTest()
        {
            char[,] board ={{'X','X','X','X'},
                          {'X','X','O','X'},
                          {'X','O','X','X'},
                          {'X','X','O','X'}};

            FillOsWIthXsIfSurroundedByXs(board);
        }

        // https://leetcode.com/problems/cut-off-trees-for-golf-event/description/
        public void TBDCutTrees()
        {

        }

        // 417 https://leetcode.com/problems/pacific-atlantic-water-flow/description/

        public List<int[]> pacificAtlantic(int[,] matrix)
        {
            List<int[]> res = new List<int[]>();

            if (matrix == null || matrix.Length == 0)
                return res;

            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);

            bool[,] pacific = new bool[rLen, cLen];
            bool[,] atlantic = new bool[rLen, cLen];

            for (int rIndx = 0; rIndx < rLen; rIndx++)
            {
                DfsHelper(matrix, pacific, rIndx, 0);
                DfsHelper(matrix, atlantic, rIndx, cLen - 1);
            }

            for (int cIndx = 0; cIndx < cLen; cIndx++)
            {
                DfsHelper(matrix, pacific, 0, cIndx);
                DfsHelper(matrix, atlantic, rLen - 1, cIndx);
            }

            for (int rIndx = 0; rIndx < rLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    if (pacific[rIndx, cIndx] == true && atlantic[rIndx, cIndx] == true)
                    {
                        res.Add(new int[] { rIndx, cIndx });
                    }
                }
            }
            return res;
        }
        int[,] dirs = { { -1, 0 }, { 0, -1 }, { 1, 0 }, { 0, 1 } };

        public void DfsHelper(int[,] matrix, bool[,] visited, int rIndx, int cIndx)
        {
            visited[rIndx,cIndx] = true;

            for (int dIndx = 0; dIndx < dirs.GetLength(0); dIndx++)
            {
                int crIndx = dirs[dIndx, 0] + rIndx;
                int ccIndx = dirs[dIndx, 1] + cIndx;

                if (IsValidCell(matrix.GetLength(0), matrix.GetLength(1), crIndx, ccIndx) && !visited[crIndx, ccIndx] && matrix[crIndx, ccIndx] >= matrix[rIndx, cIndx])
                {
                    DfsHelper(matrix, visited, crIndx, ccIndx);
                }
            }
        }

        public bool IsValidCell(int rLen, int cLen, int rIndx, int cIndx)
        {
            return rIndx >= 0 && rIndx < rLen && cIndx >= 0 && cIndx < cLen;
        }

        // 207 https://leetcode.com/problems/course-schedule/description/
        // BFS, Can also solve with DFS, Topological Sort, UnionFind
        public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            int[,] tmpMatrix = new int[numCourses, numCourses]; // i -> j
            int[] tmpDegree = new int[numCourses];

            for (int rIndx = 0; rIndx < prerequisites.GetLength(0); rIndx++)
            {
                int ready = prerequisites[rIndx, 0];
                int pre = prerequisites[rIndx, 1];

                if (tmpMatrix[pre, ready] == 0)
                {
                    tmpDegree[ready]++; //In case duplicate
                }

                tmpMatrix[pre, ready] = 1;
            }

            int count = 0;
            Queue<int> queue = new Queue<int>();

            for (int indx = 0; indx < tmpDegree.Length; indx++)
            {
                if (tmpDegree[indx] == 0)
                    queue.Enqueue(indx);
            }

            while (queue.Count() > 0)
            {
                int course = queue.Dequeue();
                count++;

                for (int indx = 0; indx < numCourses; indx++)
                {
                    if (tmpMatrix[course, indx] != 0)
                    {
                        if (--tmpDegree[indx] == 0)
                            queue.Enqueue(indx);
                    }
                }
            }

            return count == numCourses;
        }

        public bool TopologicalSort(List<List<int>> graph, Dictionary<int, int> visited, int rIndx)
        {
            int visit = visited[rIndx];

            if (visit == 2)
            {
                //when visit = 2, which means the subtree whose root is i has been dfs traversed.
                // and all the nodes in subtree has been put in the result(if we request).
                // So we do not need to traverse it again
                return true;
            }

            if (visit == 1)
            {
                return false;
            }

            visited[rIndx] = 1;

            foreach (int cIndx in graph[rIndx])
            {
                if (!TopologicalSort(graph, visited, cIndx))
                    return false;
            }

            visited[rIndx] = 2;
            
            //res.Add(i); if required.
            return true;
        }

        // 363 https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/description/
        //public int maxSumSubmatrix(int[][] matrix, int k)
        //{
        //    int row = matrix.GetLength(0);
        //    int col = matrix.GetLength(1);
        //    int max = int.MinValue;

        //    for (int rIndx = 0; rIndx < row; rIndx++)
        //    {
        //        int[] colSum = new int[col];
        //        for (int cIndx = rIndx; cIndx < row; cIndx++)
        //        {
        //            for (int c = 0; c < col; c++)
        //            {
        //                colSum[c] += matrix[cIndx][c];
        //            }
        //            max = Math.Max(max, findMax(colSum, k));
        //        }
        //    }
        //    return max;
        //}

        //private int findMax(int[] nums, int k)
        //{
        //    int max = Integer.MIN_VALUE;
        //    int sum = 0;
        //    TreeSet<Integer> s = new TreeSet();
        //    s.add(0);

        //    for (int i = 0; i < nums.length; i++)
        //    {
        //        int t = sum + nums[i];
        //        sum = t;
        //        Integer gap = s.ceiling(sum - k);
        //        if (gap != null) max = Math.max(max, sum - gap);
        //        s.add(t);
        //    }

        //    return max;
        //}

        ////Solution I, O(n ^ 4):
        //public int maxSumSubmatrix(int[,] matrix, int k)
        //{
        //    if (matrix == null || matrix.Length == 0)
        //        return 0;

        //    int rLen = matrix.GetLength(0);
        //    int cLen = matrix.GetLength(1);
        //    int[,] areas = new int[rLen, cLen];

        //    for (int rIndx = 0; rIndx < rLen; rIndx++)
        //    {
        //        for (int cIndx = 0; cIndx < cLen; cIndx++)
        //        {
        //            int area = matrix[rIndx, cIndx];

        //            if (rIndx - 1 >= 0)
        //                area += areas[rIndx - 1, cIndx];

        //            if (cIndx - 1 >= 0)
        //                area += areas[rIndx, cIndx - 1];

        //            if (rIndx - 1 >= 0 && cIndx - 1 >= 0)
        //                area -= areas[rIndx - 1, cIndx - 1];

        //            areas[rIndx, cIndx] = area;
        //        }
        //    }

        //    int max = int.MinValue;

        //    for (int rIndx = 0; rIndx < rLen; rIndx++)
        //    {
        //        for (int cIndx = 0; cIndx < cLen; cIndx++)
        //        {
        //            for (int rIndx2 = rIndx; rIndx2 < rLen; rIndx2++)
        //            {
        //                for (int cIndx2 = cIndx; cIndx2 < cLen; cIndx2++)
        //                {
        //                    int area = areas[rIndx2,cIndx2];

        //                    if (rIndx - 1 >= 0)
        //                        area -= areas[rIndx - 1,cIndx2];

        //                    if (cIndx - 1 >= 0)
        //                        area -= areas[rIndx2,cIndx - 1];

        //                    if (rIndx - 1 >= 0 && cIndx - 1 >= 0)
        //                        area += areas[rIndx - 1,cIndx - 1];

        //                    if (area <= k)
        //                        max = Math.Max(max, area);
        //                }
        //            }
        //        }
        //    }
        //    return max;
        //}

        //// Solution II(O(n^3logn)
        //public int maxSumSubmatrix(int[,] matrix, int k)
        //{
        //    if (matrix == null || matrix.Length == 0)
        //        return 0;

        //    int rows = matrix.GetLength(0);
        //    int cols = matrix.GetLength(1);

        //    int[,] areas = new int[rows,cols];

        //    for (int rIndx = 0; rIndx < rows; rIndx++)
        //    {
        //        for (int cIndx = 0; cIndx < cols; cIndx++)
        //        {
        //            int area = matrix[rIndx,cIndx];

        //            if (rIndx - 1 >= 0)
        //                area += areas[rIndx - 1,cIndx];

        //            if (cIndx - 1 >= 0)
        //                area += areas[rIndx,cIndx - 1];

        //            if (rIndx - 1 >= 0 && cIndx - 1 >= 0)
        //                area -= areas[rIndx - 1,cIndx - 1];

        //            areas[rIndx,cIndx] = area;
        //        }
        //    }

        //    int max = int.MinValue;

        //    for (int rIndx1 = 0; rIndx1 < rows; rIndx1++)
        //    {
        //        for (int rIndx2 = rIndx1; rIndx2 < rows; rIndx2++)
        //        {
        //            TreeSet<Integer> tree = new TreeSet<>();
        //            tree.add(0);    // padding

        //            for (int cIndx = 0; cIndx < cols; cIndx++)
        //            {
        //                int area = areas[rIndx2,cIndx];

        //                if (rIndx1 - 1 >= 0)
        //                    area -= areas[rIndx1 - 1,cIndx];

        //                int ceiling = tree.ceiling(area - k);

        //                if (ceiling != 0)
        //                    max = Math.Max(max, area - ceiling);

        //                tree.add(area);
        //            }
        //        }
        //    }
        //    return max;
        //}

        // 407 https://leetcode.com/problems/trapping-rain-water-ii/description/
        public int TrapRainWater(int[,] heightMap)
        {
            return -1;
        }
    }
}