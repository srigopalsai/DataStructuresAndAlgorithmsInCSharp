using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /// Array Problems

    partial class DynamicProgrammingProblems
    {
        // 62 https://leetcode.com/problems/unique-paths/description/
        public int UniquePaths(int m, int n)
        {
            int[,] dpLkUp = new int[m, n];

            for (int rIndx = 0; rIndx < m; rIndx++)
            {
                for (int cIndx = 0; cIndx < n; cIndx++)
                {
                    if (rIndx == 0 || cIndx == 0)
                    {
                        dpLkUp[rIndx, cIndx] = 1;
                    }
                    else
                    {
                        dpLkUp[rIndx, cIndx] = dpLkUp[rIndx, cIndx - 1] + dpLkUp[rIndx - 1, cIndx];
                    }
                }
            }
            return dpLkUp[m - 1, n - 1];
        }

        public int UniquePaths2(int m, int n)
        {
            if (m <= 0 || n <= 0)
                return 0;

            if (m == 1 || n == 1)
                return 1;

            int[] dpLkUp = new int[n];

            for (int indx = 0; indx < n; indx++)
            {
                dpLkUp[indx] = 1;
            }

            for (int rIndx = 1; rIndx < m; rIndx++)
            {
                for (int cIndx = 1; cIndx < n; cIndx++)
                {
                    dpLkUp[cIndx] = dpLkUp[cIndx] + dpLkUp[cIndx - 1];
                }
            }

            return dpLkUp[n - 1];
        }

        // 63 https://leetcode.com/problems/unique-paths-ii/description/
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            int rowLen = obstacleGrid.GetLength(0);
            int colLen = obstacleGrid.GetLength(1);

            int[,] dpLkUp = new int[rowLen, colLen];

            for (int cIndx = 0; cIndx < colLen; cIndx++)
            {
                if (obstacleGrid[0, cIndx] == 0)
                    dpLkUp[0, cIndx] = 1;
                else
                    break;//supoose ob[0,3]=1 then not only res[0,3]=0 but all grids behind it are also zeros(res[0,4], etc);
            }

            for (int rIndx = 0; rIndx < rowLen; rIndx++)
            {
                if (obstacleGrid[rIndx, 0] == 0)
                    dpLkUp[rIndx, 0] = 1;
                else
                    break;
            }

            for (int rIndx = 1; rIndx < rowLen; rIndx++)
            {
                for (int cIndx = 1; cIndx < colLen; cIndx++)
                {
                    if (obstacleGrid[rIndx, cIndx] == 0)
                    {
                        dpLkUp[rIndx, cIndx] = dpLkUp[rIndx - 1, cIndx] + dpLkUp[rIndx, cIndx - 1];
                    }
                    else
                    {
                        dpLkUp[rIndx, cIndx] = 0;
                    }
                }
            }

            return dpLkUp[rowLen - 1, colLen - 1];
        }

        public int UniquePathsWithObstacles1(int[,] matrix)
        {
            int[] dpLkUp = new int[matrix.GetLength(1)];

            dpLkUp[0] = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        dpLkUp[col] = 0;
                    }
                    else if (col > 0)
                    {
                        dpLkUp[col] += dpLkUp[col - 1];
                    }
                }
            }

            return dpLkUp[matrix.GetLength(0) - 1];
        }

        // 64 https://leetcode.com/problems/minimum-path-sum/description/
        public int MinPathSum(int[,] matrix)
        {
            int[] dpLkUp = new int[matrix.GetLength(1)];

            dpLkUp[0] = matrix[0, 0];

            for (int cIndx = 1; cIndx < matrix.GetLength(1); cIndx++)
            {
                dpLkUp[cIndx] = dpLkUp[cIndx - 1] + matrix[0, cIndx];
            }

            for (int rIndx = 1; rIndx < matrix.GetLength(0); rIndx++)
            {
                dpLkUp[0] += matrix[rIndx, 0];

                for (int cIndx = 1; cIndx < matrix.GetLength(1); cIndx++)
                {
                    dpLkUp[cIndx] = Math.Min(dpLkUp[cIndx - 1], dpLkUp[cIndx]) + matrix[rIndx, cIndx];
                }
            }

            return dpLkUp[matrix.GetLength(1) - 1];
        }

        public int MinPathSum1(int[,] matrix)
        {
            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);

            int[,] dpLkUp = new int[rowLen, colLen];

            //First column
            dpLkUp[0, 0] = matrix[0, 0];

            for (int rIndx = 1; rIndx < rowLen; rIndx++)
            {
                dpLkUp[rIndx, 0] = dpLkUp[rIndx - 1, 0] + matrix[rIndx, 0];
            }

            //Top row
            for (int cIndx = 1; cIndx < colLen; cIndx++)
            {
                dpLkUp[0, cIndx] = dpLkUp[0, cIndx - 1] + matrix[0, cIndx];
            }

            for (int rIndx = 1; rIndx < rowLen; rIndx++)
            {
                for (int cIndx = 1; cIndx < colLen; cIndx++)
                {
                    dpLkUp[rIndx, cIndx] = Math.Min(dpLkUp[rIndx - 1, cIndx], dpLkUp[rIndx, cIndx - 1]) +
                                            matrix[rIndx, cIndx];
                }
            }
            return dpLkUp[rowLen - 1, colLen - 1];
        }

        public int MinPathSum2(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);

            for (int rIndx = 1; rIndx < rowLen; rIndx++)
            {
                matrix[rIndx, 0] = matrix[rIndx - 1, 0] + matrix[rIndx, 0];
            }

            for (int cIndx = 1; cIndx < colLen; cIndx++)
            {
                matrix[0, cIndx] = matrix[0, cIndx - 1] + matrix[0, cIndx];
            }

            for (int rIndx = 1; rIndx < rowLen; rIndx++)
            {
                for (int cIndx = 1; cIndx < colLen; cIndx++)
                {
                    matrix[rIndx, cIndx] = matrix[rIndx, cIndx] + Math.Min(matrix[rIndx - 1, cIndx], matrix[rIndx, cIndx - 1]);
                }
            }

            return matrix[rowLen - 1, colLen - 1];
        }

        // ----------------------------------------------------------------------------------------

        // http://www.geeksforgeeks.org/count-possible-paths-top-left-bottom-right-nxm-matrix/

        //2^n Exponential Time.
        public int NumberOfPathsNaive(int m, int n)
        {
            // If either given row number is first or given column number is first
            if (m == 1 || n == 1)
                return 1;

            // If diagonal movements are allowed then the last addition
            // is required.
            return NumberOfPathsNaive(m - 1, n) + NumberOfPathsNaive(m, n - 1);
            // + numberOfPaths(m-1,n-1);
        }

        // Returns count of possible paths to reach cell at row number m and column
        // number n from the topmost leftmost cell (cell at 1, 1)
        public int NumberOfPaths(int m, int n)
        {
            // Create a 2D table to store results of subproblems
            int[,] count = new Int32[m,n];

            // Count of paths to reach any cell in first column is 1
            for (int i = 0; i < m; i++)
                count[i,0] = 1;

            // Count of paths to reach any cell in first column is 1
            for (int j = 0; j < n; j++)
                count[0,j] = 1;

            // Calculate count of paths for other cells in bottom-up manner using
            // the recursive solution
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)

                    // By uncommenting the last part the code calculatest he total
                    // possible paths if the diagonal Movements are allowed
                    count[i,j] = count[i - 1,j] + count[i,j - 1]; //+ count[i-1,j-1];

            }
            return count[m - 1,n - 1];
        }

        public int NumberOfPathsTest()
        {
            NumberOfPaths(3, 3);
            return 0;
        }

        // Triangle https://www.programcreek.com/2013/01/leetcode-triangle-java/
        /*
        Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
        For example, given the following triangle
        [
             [2],
            [3,4],
           [6,5,7],
          [4,1,8,3]
        ]
        The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).

        Bottom-Up (Good Solution)        We can actually start from the bottom of the triangle.
        */

        public int minimumTotal(List<List<int>> triangle)
        {
            int[] total = new int[triangle.Count];
            int length = triangle.Count() - 1;

            for (int indx = 0; indx < triangle[length].Count(); indx++)
            {
                total[indx] = triangle[length][indx];
            }

            // iterate from last second row
            for (int indx = triangle.Count() - 2; indx >= 0; indx--)
            {
                for (int j = 0; j < triangle[indx + 1].Count() - 1; j++)
                {
                    total[j] = triangle[indx][j] + Math.Min(total[j], total[j + 1]);
                }
            }

            return total[0];
        }

        // 276 Paint Fence (locked) https://www.programcreek.com/2014/05/leetcode-pain-fence-java/
        // https://discuss.leetcode.com/category/345/paint-fence
        public int NumWays(int n, int k)
        {
            int[] lkUp = { 0, k, k * k, 0 };

            if (n <= 2)
            {
                return lkUp[n];
            }

            for (int indx = 2; indx < n; indx++)
            {
                lkUp[3] = (k - 1) * (lkUp[1] + lkUp[2]);
                lkUp[1] = lkUp[2];
                lkUp[2] = lkUp[3];
            }

            return lkUp[3];
        }

        // 256 Paint House https://discuss.leetcode.com/category/324/paint-house

        // ----------------------------------------------------------------------------------------

        //303 https://leetcode.com/problems/range-sum-query-immutable/description/
        /*
            Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
            Example:
            Given nums = [-2, 0, 3, -5, 2, -1]

            sumRange(0, 2) -> 1
            sumRange(2, 5) -> -1
            sumRange(0, 5) -> -3

            Note:
            You may assume that the array does not change.
            There are many calls to sumRange function.
                 * */
        public class NumArray
        {
            int[] nums;

            public NumArray(int[] nums)
            {
                for (int indx = 1; indx < nums.Length; indx++)
                {
                    nums[indx] += nums[indx - 1];
                }
                this.nums = nums;
            }

            public int SumRange(int stIndx, int edIndx)
            {
                if (stIndx == 0)
                {
                    return nums[edIndx];
                }
                return nums[edIndx] - nums[stIndx - 1];
            }
        }

        // 304 https://leetcode.com/problems/range-sum-query-2d-immutable/
        /*
        Time complexity construction O(n*m)
        Time complexity of query O(1)
        Space complexity is O(n*m)
        */

        public class Immutable2DSumRangeQuery
        {
            private int[,] lkUpMat;

            public Immutable2DSumRangeQuery(int[,] srcMatrix)
            {

                lkUpMat = new int[srcMatrix.GetLength(0) + 1, srcMatrix.GetLength(1) + 1];

                for (int rIndx = 1; rIndx < lkUpMat.GetLength(0); rIndx++)
                {
                    for (int cIndx = 1; cIndx < lkUpMat.GetLength(1); cIndx++)
                    {
                        lkUpMat[rIndx, cIndx] = lkUpMat[rIndx - 1, cIndx] + lkUpMat[rIndx, cIndx - 1] +
                                                srcMatrix[rIndx - 1, cIndx - 1] - lkUpMat[rIndx - 1, cIndx - 1];
                    }
                }
            }

            public int SumQuery(int r1, int c1, int r2, int c2)
            {
                r1++;
                c1++;
                r2++;
                c2++;

                return lkUpMat[r2, c2] - lkUpMat[r1 - 1, c2] - lkUpMat[r2, c1 - 1]
                     + lkUpMat[r1 - 1, c1 - 1];
            }

            public static void Immutable2DSumRangeQueryTest()
            {
                int[,] input = {{3, 0, 1, 4, 2},
                        {5, 6, 3, 2, 1},
                        {1, 2, 0, 1, 5},
                        {4, 1, 0, 1, 7},
                        {1, 0, 3, 0, 5}};

                int[,] input1 = { { 2, 0, -3, 4 }, { 6, 3, 2, -1 }, { 5, 4, 7, 3 }, { 2, -6, 8, 1 } };
                Immutable2DSumRangeQuery isr = new Immutable2DSumRangeQuery(input1);
                Console.WriteLine(isr.SumQuery(1, 1, 2, 2));
            }
        }

        //===========================================================================================

        //303 https://leetcode.com/problems/range-sum-query-immutable/description/
        /*
            Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
            Example:
            Given nums = [-2, 0, 3, -5, 2, -1]

            sumRange(0, 2) -> 1
            sumRange(2, 5) -> -1
            sumRange(0, 5) -> -3

            Note:
            You may assume that the array does not change.
            There are many calls to sumRange function.
                 * */
        public class NumArray2
        {
            int[] nums;

            public NumArray2(int[] nums)
            {
                for (int indx = 1; indx < nums.Length; indx++)
                {
                    nums[indx] += nums[indx - 1];
                }
                this.nums = nums;
            }

            public int SumRange(int stIndx, int edIndx)
            {
                if (stIndx == 0)
                {
                    return nums[edIndx];
                }
                return nums[edIndx] - nums[stIndx - 1];
            }
        }

        // 304 https://leetcode.com/problems/range-sum-query-2d-immutable/
        /*
        Time complexity construction O(n*m)
        Time complexity of query O(1)
        Space complexity is O(n*m)
        */

        public class Immutable2DSumRangeQuery2
        {
            private int[,] lkUpMat;

            public Immutable2DSumRangeQuery2(int[,] srcMatrix)
            {

                lkUpMat = new int[srcMatrix.GetLength(0) + 1, srcMatrix.GetLength(1) + 1];

                for (int rIndx = 1; rIndx < lkUpMat.GetLength(0); rIndx++)
                {
                    for (int cIndx = 1; cIndx < lkUpMat.GetLength(1); cIndx++)
                    {
                        lkUpMat[rIndx, cIndx] = lkUpMat[rIndx - 1, cIndx] + lkUpMat[rIndx, cIndx - 1] +
                                                srcMatrix[rIndx - 1, cIndx - 1] - lkUpMat[rIndx - 1, cIndx - 1];
                    }
                }
            }

            public int SumQuery(int r1, int c1, int r2, int c2)
            {
                r1++;
                c1++;
                r2++;
                c2++;

                return lkUpMat[r2, c2] - lkUpMat[r1 - 1, c2] - lkUpMat[r2, c1 - 1]
                     + lkUpMat[r1 - 1, c1 - 1];
            }

            public static void Immutable2DSumRangeQueryTest()
            {
                int[,] input = {{3, 0, 1, 4, 2},
                        {5, 6, 3, 2, 1},
                        {1, 2, 0, 1, 5},
                        {4, 1, 0, 1, 7},
                        {1, 0, 3, 0, 5}};

                int[,] input1 = { { 2, 0, -3, 4 }, { 6, 3, 2, -1 }, { 5, 4, 7, 3 }, { 2, -6, 8, 1 } };
                Immutable2DSumRangeQuery isr = new Immutable2DSumRangeQuery(input1);
                Console.WriteLine(isr.SumQuery(1, 1, 2, 2));
            }
        }
    }
}