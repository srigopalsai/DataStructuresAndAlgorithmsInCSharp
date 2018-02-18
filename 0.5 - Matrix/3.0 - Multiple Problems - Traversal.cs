using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
     
     Input:
      1    2   3
      8    9   4
      7    6   5
     
    Output: 1   2   3   4   5   6   7   8   9
    
    We will first print the periphery of the matrix by the help of 4 for loops. 
    Then recursively call this function to do the same thing with inner concentric rectangles. 
    We will pass this information by a variable named depth, which will tell how many layers from outside should be ignored

    //int[,] squareMatrix =   {   { 1,  2,  3,  4,  5 },
    //                            { 16, 17, 18, 19, 6 },
    //                            { 15, 24, 25, 20, 7 },
    //                            { 14, 23, 22, 21, 8 },
    //                            { 13, 12, 11, 10, 9 }};
    
    //int[,] rectMatrix =     {   { 1,  2,  3,  4,  5 },
    //                            { 12, 13, 14, 15, 6 },
    //                            { 11, 10, 9,  8,  7 }};

    Yet to refer the logic.
    http://www.geeksforgeeks.org/print-a-given-matrix-in-spiral-form/
    
    // Anti Spiral
    http://www.geeksforgeeks.org/print-matrix-antispiral-form/

    To display in anti-spiral order we need to visit in spiral order and push them into stack and print them.
    ===================================================================================================================================================================================================
    */

    public partial class MatrixOperations
    {
        StringBuilder strRslt = new StringBuilder();

        public void DisplayMatrixInSpiralTest()
        {
            strRslt.Clear();

            strRslt.AppendLine("Demo 1   -    5 X 5 : ");
            DisplayMatrixInSpiral(JaggaedMatrix5x5);

            strRslt.AppendLine("\n\nDemo 2   -    4 X 5 : ");
            DisplayMatrixInSpiral(JaggaedMatrix4x5);

            strRslt.AppendLine("\n\nDemo 3   -    3 X 5 : ");
            DisplayMatrixInSpiral(JaggaedMatrix3x5);

            strRslt.AppendLine("\n\nDemo 4   -    2 X 5 : ");
            DisplayMatrixInSpiral(jaggaedMatrix2x5);

            strRslt.AppendLine("\n\nDemo 5   -    3 X 2 : ");
            DisplayMatrixInSpiral(jaggaedMatrix3x2);

            strRslt.AppendLine("\n\nDemo 6   -    4 X 2 : ");
            DisplayMatrixInSpiral(jaggaedMatrix4x2);

            strRslt.AppendLine("\n\nDemo 7   -    5 X 3 : ");
            DisplayMatrixInSpiral(jaggaedMatrix5x3);

            strRslt.AppendLine("\n\nDemo 8   -    7 X 3 : ");
            DisplayMatrixInSpiral(jaggaedMatrix7x3);

            strRslt.AppendLine("\n\nDemo 9   -    7 X 3 : ");
            DisplayMatrixInSpiral(jaggaedMatrix7x3);

            strRslt.AppendLine("\n\nDemo 10  -    7 X 7 : ");
            DisplayMatrixInSpiral(jaggaedMatrix7x7);
            //Need to Investigate
            //Array.Sort(jaggaedMatrix);

            MessageBox.Show(Convert.ToString(strRslt));

            Array.Sort(JaggaedMatrix4x5, (a, b) => a[0].CompareTo(b[0]));
        }

        // http://www.geeksforgeeks.org/create-a-matrix-with-alternating-rectangles-of-0-and-x/
        // http://algorithmstuff.wordpress.com/2013/10/13/print-a-matrix-in-spiral-order/

        public void DisplayMatrixInSpiral(int[][] MatrixArray)
        {
            int lpCnt;
            int topRowIndx = 0;
            int leftColIndx = 0;

            int bottomRowIndx = MatrixArray.Length - 1;
            int rightColIndx = MatrixArray[0].Length - 1;

            while (topRowIndx <= bottomRowIndx && leftColIndx <= rightColIndx)
            {
                //Top 
                for (lpCnt = leftColIndx; lpCnt <= rightColIndx; lpCnt++)
                {
                    strRslt.Append(MatrixArray[topRowIndx][lpCnt] + " ");
                }

                topRowIndx++;

                //Right column
                for (lpCnt = topRowIndx; lpCnt <= bottomRowIndx; lpCnt++)
                {
                    strRslt.Append(MatrixArray[lpCnt][rightColIndx] + " ");
                }

                rightColIndx--;

                // If boundaries are crossed, it means we are done with traversal.
                if (leftColIndx > rightColIndx || topRowIndx > bottomRowIndx)
                    break;

                //Bottom
                for (lpCnt = rightColIndx; lpCnt >= leftColIndx; lpCnt--)
                {
                    strRslt.Append(MatrixArray[bottomRowIndx][lpCnt] + " ");
                }
                bottomRowIndx--;

                //Left column
                for (lpCnt = bottomRowIndx; lpCnt >= topRowIndx; lpCnt--)
                {
                    strRslt.Append(MatrixArray[lpCnt][leftColIndx] + " ");
                }

                leftColIndx++;
            }
        }

        IList<int> DisplayMatrixInSpiral(int[,] matrix)
        {
            IList<int> spiralList = new List<int>();

            int lpCnt;
            int topRowIndx = 0;
            int bottomRowIndx = matrix.GetLength(0) - 1;

            int leftColIndx = 0;
            int rightColIndx = matrix.GetLength(1) - 1;

            while (leftColIndx <= rightColIndx && topRowIndx <= bottomRowIndx)
            {
                //Go left to right for top Row---->
                for (lpCnt = leftColIndx; lpCnt <= rightColIndx; lpCnt++)
                {
                    spiralList.Add(matrix[topRowIndx, lpCnt]);
                }

                topRowIndx++; // Move Down to Next Top Row. (step down for next iteration)

                //Go top to bottom for right column ↓ 
                for (lpCnt = topRowIndx; lpCnt <= bottomRowIndx; lpCnt++)
                {
                    spiralList.Add(matrix[lpCnt, rightColIndx]);
                }

                rightColIndx--; // Move Left to Inside Column.

                // If boundaries are crossed, it means we are done with traversal.
                if (leftColIndx > rightColIndx || topRowIndx > bottomRowIndx)
                    break;

                //Go right to left for bottom row <------
                for (lpCnt = rightColIndx; lpCnt >= leftColIndx; lpCnt--)
                {
                    spiralList.Add(matrix[bottomRowIndx, lpCnt]);
                }

                bottomRowIndx--; //Move Up to Next Bottom Row. 

                //Go bottom to top for left column ↑
                for (lpCnt = bottomRowIndx; lpCnt >= topRowIndx; lpCnt--)
                {
                    spiralList.Add(matrix[lpCnt, leftColIndx]);
                }

                leftColIndx++; // Move Left to Next Column
            }

            return spiralList;
        }

        // https://www.geeksforgeeks.org/print-given-matrix-zigzag-form/
        public void PrintZigZag(int[,] matrix)
        {
            int evenRow = 0;
            int oddRow = 1;

            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);

            while (evenRow < rowLen && oddRow < rowLen)
            {
                for (int indx = 0; indx < colLen; indx++)
                {
                    Console.Write(matrix[evenRow, indx] + " ");
                }

                Console.WriteLine();

                evenRow = evenRow + 2;

                for (int indx = colLen - 1; indx >= 0; indx--)
                {
                    Console.WriteLine(matrix[oddRow, indx] + " ");
                }

                oddRow = oddRow + 2;
            }
        }

        // http://www.geeksforgeeks.org/print-matrix-diagonally/
        // https://www.geeksforgeeks.org/zigzag-or-diagonal-traversal-of-matrix/
        public void DiagonalOrder(int[,] matrix)
        {
            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);

            // There will be ROW+COL-1 lines in the output
            for (int lineIndx = 1; lineIndx <= (rowLen + colLen - 1); lineIndx++)
            {
                // Get column index of the first element in this line of output.
                // The index is 0 for first ROW lines and line - ROW for remaining lines
                int cStIndx = Math.Max(0, lineIndx - rowLen);

                /* The count of elements is equal to minimum of line number, COLLen-start_col and ROWLen */
                // No of items in each line.
                int itemCount = Math.Min(lineIndx, Math.Min((colLen - cStIndx), rowLen));

                for (int indx = 0; indx < itemCount; indx++)
                {
                    int rIndx = Math.Min(rowLen, lineIndx) - indx - 1;
                    int cIndx = cStIndx + indx;

                    Console.Write(matrix[rIndx, cIndx]);
                }  

                Console.WriteLine();
            }
        }

        public static void DiagnolTraversal(int[,] mat)
        {
            int rStartIndx = 0;
            int cStartIndx = mat.GetLength(1) - 1;

            while (rStartIndx < mat.GetLength(0))
            {
                int rIndx = rStartIndx;
                int cIndx = cStartIndx;
                int indx = Math.Abs(cStartIndx - rStartIndx);

                while (indx < mat.GetLength(0))
                {
                    Console.Write(mat[rIndx, cIndx] + " ");
                    rIndx++;
                    cIndx++;
                    indx++;
                }

                if (cStartIndx == 0)
                    rStartIndx++;
                else
                    cStartIndx--;

                Console.WriteLine();
            }
        }

        //741 https://leetcode.com/problems/cherry-pickup/description/
        public int CherryPickup(int[,] grid)
        {
            int nLen = grid.GetLength(0);

            if (nLen == 0 || grid.GetLength(0) != grid.GetLength(1))
                return 0;

            int[,] dpArr1 = new int[nLen, nLen];

            for (int rIndx = 0; rIndx < nLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < nLen; cIndx++)
                {
                    dpArr1[rIndx, cIndx] = -1;
                }
            }

            int maxLen = nLen * 2 - 2;
            dpArr1[0, 0] = grid[0, 0];

            for (int pIndx = 1; pIndx <= maxLen; pIndx++)
            {
                int[,] dpArr2 = new int[nLen, nLen];

                for (int rIndx = 0; rIndx < nLen; rIndx++)
                {
                    for (int cIndx = 0; cIndx < nLen; cIndx++)
                    {
                        dpArr2[rIndx, cIndx] = -1;
                    }
                }

                for (int rIndx = 0; rIndx <= Math.Min(pIndx, nLen - 1); rIndx++)
                {
                    for (int cIndx = 0; cIndx <= Math.Min(pIndx, nLen - 1); cIndx++)
                    {
                        if (pIndx - rIndx >= nLen || pIndx - cIndx >= nLen)
                            continue; //y coord overflow

                        if (grid[rIndx, pIndx - rIndx] == -1 || grid[cIndx, pIndx - cIndx] == -1)
                            continue;

                        int curCherry = dpArr1[rIndx, cIndx];

                        if (rIndx > 0)
                        {
                            curCherry = Math.Max(curCherry, dpArr1[rIndx - 1, cIndx]);
                        }
                        if (cIndx > 0)
                        {
                            curCherry = Math.Max(curCherry, dpArr1[rIndx, cIndx - 1]);
                        }
                        if (rIndx > 0 && cIndx > 0)
                        {
                            curCherry = Math.Max(curCherry, dpArr1[rIndx - 1, cIndx - 1]);
                        }
                        if (curCherry < 0)
                        {
                            continue; //no possible way to here
                        }
                        if (rIndx == cIndx)
                        {
                            dpArr2[rIndx, cIndx] = curCherry + grid[rIndx, pIndx - rIndx];
                        }
                        else
                        {
                            dpArr2[rIndx, cIndx] = curCherry + grid[rIndx, pIndx - rIndx] + grid[cIndx, pIndx - cIndx];
                        }
                    }
                }

                dpArr1 = dpArr2;
            }
            return Math.Max(0, dpArr1[nLen - 1, nLen - 1]);
        }

        // 661 https://leetcode.com/problems/image-smoother/description/
        public int[,] ImageSmoother(int[,] matrix)
        {
            if (matrix == null)
                return null;

            if (matrix.Length == 0)
                return new int[0, 0];

            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);

            int[,] result = new int[rLen, cLen];

            for (int rIndx = 0; rIndx < rLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    int sum = 0;
                    int count = 0;

                    foreach (int rDirection in new int[] { -1, 0, 1 })
                    {
                        foreach (int cDirection in new int[] { -1, 0, 1 })
                        {
                            if (IsValid(rIndx + rDirection, cIndx + cDirection, rLen, cLen))
                            {
                                count++;
                                sum += matrix[rIndx + rDirection, cIndx + cDirection];
                            }
                        }
                    }

                    result[rIndx, cIndx] = sum / count;
                }
            }

            return result;
        }

        private bool IsValid(int rIndx, int cIndx, int rLen, int cLen)
        {
            return rIndx >= 0 && rIndx < rLen && cIndx >= 0 && cIndx < cLen;
        }

        // 547 https://leetcode.com/problems/friend-circles/description/
        public int FindCircleNum(int[,] matrix)
        {
            int result = 0;
            bool[] visited = new bool[matrix.GetLength(0)];

            for (int rIndx = 0; rIndx <= matrix.GetLength(0) - 1; rIndx++)
            {
                if (!visited[rIndx])
                {
                    DFSTraversal(rIndx, matrix, visited);
                    result++;
                }
            }
            return result;
        }

        private void DFSTraversal(int startNode, int[,] graph, bool[] visited)
        {
            visited[startNode] = true;

            for (int cIndx = 0; cIndx <= graph.GetLength(1) - 1; cIndx++)
            {
                if (startNode == cIndx)
                {
                    continue;
                }

                if (graph[startNode, cIndx] == 1 && !visited[cIndx])
                {
                    DFSTraversal(cIndx, graph, visited);
                }
            }
        }

        /*Union Approach
         * public class Solution {
        class UnionFind {
                private int count = 0;
                private int[] parent, rank;
        
                public UnionFind(int n) {
                    count = n;
                    parent = new int[n];
                    rank = new int[n];
                    for (int i = 0; i < n; i++) {
                        parent[i] = i;
                    }
                }
        
                public int find(int p) {
        	        while (p != parent[p]) {
                        parent[p] = parent[parent[p]];    // path compression by halving
                        p = parent[p];
                    }
                    return p;
                }
        
                public void union(int p, int q) {
                    int rootP = find(p);
                    int rootQ = find(q);
                    if (rootP == rootQ) return;
                    if (rank[rootQ] > rank[rootP]) {
                        parent[rootP] = rootQ;
                    }
                    else {
                        parent[rootQ] = rootP;
                        if (rank[rootP] == rank[rootQ]) {
                            rank[rootP]++;
                        }
                    }
                    count--;
                }
        
                public int count() {
                    return count;
                }
            }
    
            public int findCircleNum(int[][] M) {
                int n = M.length;
                UnionFind uf = new UnionFind(n);
                for (int i = 0; i < n - 1; i++) {
                    for (int j = i + 1; j < n; j++) {
                        if (M[i][j] == 1) uf.union(i, j);
                    }
                }
                return uf.count();
            }
        }
                 * 
                 * BFS Approach
                public int findCircleNum(int[][] M) {
            int count = 0;
            for (int i=0; i<M.length; i++)
                if (M[i][i] == 1) { count++; BFS(i, M); }
            return count;
        }

        public void BFS(int student, int[][] M) {
            Queue<Integer> queue = new LinkedList<>();
            queue.add(student);
            while (queue.size() > 0) {
                int queueSize = queue.size();
                for (int i=0;i<queueSize;i++) {
                    int j = queue.poll();
                    M[j][j] = 2; // marks as visited
                    for (int k=0;k<M[0].length;k++) 
                        if (M[j][k] == 1 && M[k][k] == 1) queue.add(k);
                }
            }
        }
        */

        // 529 https://leetcode.com/problems/minesweeper/description/
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            int m = board.GetLength(0);
            int n = board.GetLength(1);

            int row = click[0];
            int col = click[1];

            if (board[row][col] == 'M')
            {   // Mine
                board[row][col] = 'X';
            }
            else
            { 
                // Get number of mines first.
                int count = 0;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (i == 0 && j == 0)
                            continue;
                        int r = row + i;
                        int c = col + j;

                        if (r < 0 || r >= m || c < 0 || c < 0 || c >= n)
                            continue;

                        if (board[r][c] == 'M' || board[r][c] == 'X')
                            count++;
                    }
                }

                if (count > 0)
                { 
                    // If it is not a 'B', stop further DFS.
                    board[row][col] = (char)(count + '0');
                }
                else
                { 
                    // Continue DFS to adjacent cells.
                    board[row][col] = 'B';
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                                continue;
                            int r = row + i;
                            int c = col + j;

                            if (r < 0 || r >= m || c < 0 || c < 0 || c >= n)
                                continue;

                            if (board[r][c] == 'E')
                                UpdateBoard(board, new int[] { r, c });
                        }
                    }
                }
            }

            return board;
        }

        // BFS Approach
        public char[][] UpdateBoard2(char[][] board, int[] click)
        {
            int m = board.GetLength(0);
            int n = board.GetLength(1);

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(click);

            while (queue.Count() > 0)
            {
                int[] cell = queue.Dequeue();
                int row = cell[0];
                int col = cell[1];

                if (board[row][col] == 'M')
                {
                    board[row][col] = 'X';
                }
                else
                { 
                    // Get number of mines first.
                    int count = 0;

                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0)
                                continue;

                            int r = row + i, c = col + j;

                            if (r < 0 || r >= m || c < 0 || c < 0 || c >= n)
                                continue;

                            if (board[r][c] == 'M' || board[r][c] == 'X')
                                count++;
                        }
                    }

                    if (count > 0)
                    { 
                        // If it is not a 'B', stop further BFS.
                        board[row][col] = (char)(count + '0');
                    }
                    else
                    { 
                        // Continue BFS to adjacent cells.
                        board[row][col] = 'B';

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                if (i == 0 && j == 0)
                                    continue;

                                int r = row + i, c = col + j;

                                if (r < 0 || r >= m || c < 0 || c < 0 || c >= n)
                                    continue;

                                if (board[r][c] == 'E')
                                {
                                    queue.Enqueue(new int[] { r, c });
                                    board[r][c] = 'B'; // Avoid to be added again.
                                }
                            }
                        }
                    }
                }
            }

            return board;
        }
    }
}