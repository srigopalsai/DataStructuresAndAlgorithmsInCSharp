using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructuresAndAlgorithms.OtherAlgorithms;

namespace DataStructuresAndAlgorithms
{
    public class HardProblems
    {
        // Hard 42 https://leetcode.com/problems/trapping-rain-water
        // O(N) Time O(1) Space - DP Prev, Curr Pointer approach
        public int Trap(int[] nums)
        {
            int lIndx = 0;
            int rIndx = nums.Length - 1;

            int capacity = 0;
            int prevMax = 0;
            int curMax = 0;

            while (lIndx <= rIndx)
            {
                curMax = Math.Min(nums[lIndx], nums[rIndx]);

                if (prevMax < curMax)
                {
                    prevMax = curMax;
                }

                if (nums[lIndx] < nums[rIndx])
                {
                    capacity += prevMax - nums[lIndx];
                    lIndx++;
                }
                else
                {
                    capacity += prevMax - nums[rIndx];
                    rIndx--;
                }
            }

            return capacity;
        }

        // O(N) Time O(1) Space - DP Left, Right Pointer approach
        public int TrapDP2(int[] nums)
        {
            int capacity = 0;

            int lIndx = 0;
            int rIndx = nums.Length - 1;

            int leftMax = 0;
            int rightMax = 0;

            while (lIndx < rIndx)
            {
                if (nums[lIndx] < nums[rIndx])
                {
                    if (nums[lIndx] >= leftMax)
                        leftMax = nums[lIndx];
                    else
                        capacity += leftMax - nums[lIndx];
                    ++lIndx;
                }
                else
                {
                    if (nums[rIndx] >= rightMax)
                        rightMax = nums[rIndx];
                    else
                        capacity += rightMax - nums[rIndx];
                    --rIndx;
                }
            }
            return capacity;
        }

        // O(n^2) - Brute Force, traverse each element and search leftMax and rightMax till the position.
        // And consider Min from leftMax or rightMax and substract it from the current element. 
        public int TrapBF(int[] nums)
        {
            int capacity = 0;
            int indx = 1;

            while (indx < nums.Length - 1)
            {
                int maxLeft = 0;
                int maxRight = 0;

                for (int lIndx = indx; lIndx >= 0; lIndx--)
                {
                    //Search the left part for max
                    maxLeft = Math.Max(maxLeft, nums[lIndx]);
                }

                for (int rIndx = indx; rIndx < nums.Length; rIndx++)
                {
                    //Search the right part for max
                    maxRight = Math.Max(maxRight, nums[rIndx]);
                }

                capacity += Math.Min(maxLeft, maxRight) - nums[indx];
                indx++;
            }

            return capacity;
        }

        // O(n) time and O(n) Space
        public int Trap2(int[] nums)
        {
            if (nums == null)
                return 0;

            int capacity = 0;
            int size = nums.Length - 1;

            int[] leftMax = new int[size];
            int[] rightMax = new int[size];

            leftMax[0] = nums[0];
            rightMax[size] = nums[size];

            // Keep taking the leftMax.
            for (int i = 1; i <= size; i++)
            {
                leftMax[i] = Math.Max(nums[i], leftMax[i - 1]);
            }

            // Keep taking the rightMax.
            for (int i = size - 1; i >= 0; i--)
            {
                rightMax[i] = Math.Max(nums[i], rightMax[i + 1]);
            }

            for (int i = 1; i < size; i++)
            {
                capacity += Math.Min(leftMax[i], rightMax[i]) - nums[i];
            }

            return capacity;
        }

        // O(n) Space and Time
        // We add the index of the bar to the stack if bar is smaller than or equal to the bar at top of stack.
        // Which means that the current bar is bounded by the previous bar in the stack.
        // If we found a bar longer than that at the top, we are sure that the bar at the top 
        //    of the stack is bounded by the current bar and a previous bar in the stack.
        // Hence, we can pop it and add resulting trapped water to capacity.
        public int Trap22(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            Stack<int> indxStack = new Stack<int>();

            int capacity = 0;
            int maxBotWater = 0;

            int indx = 0;
            int prevIndx = 0;
            int currIndx = 0;

            while (indx < nums.Length)
            {
                if (indxStack.Count() == 0 || nums[indx] <= nums[indxStack.Peek()])
                {
                    indxStack.Push(indx++);
                    continue;
                }

                currIndx = indxStack.Pop();

                if (indxStack.Count == 0) // empty means no il
                {
                    maxBotWater = 0;
                }
                else
                {
                    prevIndx = indxStack.Peek();
                    maxBotWater = (Math.Min(nums[prevIndx], nums[indx]) - nums[currIndx]) * (indx - prevIndx - 1);
                }
                capacity += maxBotWater;
            }

            return capacity;
        }

        public int TrapByStack(int[] nums)
        {
            int capacity = 0;
            
            Stack<int> st = new Stack<int>();

            for (int indx = 0; indx < nums.Length; indx++)
            {
                while (st.Count() > 0 && nums[indx] > nums[st.Peek()])
                {
                    int top = st.Pop();

                    if (st.Any() == false)
                        break;

                    int distance = indx - st.Peek() - 1;
                    int bounded_height = Math.Min(nums[indx], nums[st.Peek()]) - nums[top];

                    capacity += distance * bounded_height;
                }

                st.Push(indx);
            }

            return capacity;
        }

        // Binary indexed tree or Fenwick Tree
        // https://github.com/mission-peace/interview/blob/master/src/com/interview/tree/FenwickTree.java
        // https://www.youtube.com/watch?v=CWDQJGaN1gY
        // https://zhuhan0.blogspot.com/2017/09/leetcode-308-range-sum-query-2d-mutable.html
        class NumMatrix
        {
            private int[,] matrix;
            private int[,] tree;

            private int height;
            private int width;

            public NumMatrix(int[,] matrix)
            {
                height = matrix.GetLength(0);

                if (height == 0)
                {
                    return;
                }

                width = matrix.GetLength(0);

                this.matrix = new int[height, width];
                tree = new int[height + 1, width + 1];

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        update(i, j, matrix[i,j]);
                    }
                }
            }

            public void update(int row, int col, int val)
            {
                int diff = val - matrix[row,col];
                matrix[row,col] = val;

                for (int i = row + 1; i <= height; i += (i & -i))
                {
                    for (int j = col + 1; j <= width; j += (j & -j))
                    {
                        tree[i,j] += diff;
                    }
                }
            }

            public int sumRegion(int row1, int col1, int row2, int col2)
            {
                return sum(row2, col2) - sum(row1 - 1, col2) - sum(row2, col1 - 1) + sum(row1 - 1, col1 - 1);
            }

            private int sum(int row, int col)
            {
                int sum = 0;
                for (int i = row + 1; i > 0; i -= (i & -i))
                {
                    for (int j = col + 1; j > 0; j -= (j & -j))
                    {
                        sum += tree[i,j];
                    }
                }
                return sum;
            }
        }

        /**
         * Your NumMatrix object will be instantiated and called as such:
         * NumMatrix obj = new NumMatrix(matrix);
         * obj.update(row,col,val);
         * int param_2 = obj.sumRegion(row1,col1,row2,col2);
         */

        //https://leetcode.com/problems/trapping-rain-water-ii
        // https://leetcode.com/problems/trapping-rain-water-ii/discuss/89460/Alternative-approach-using-Dijkstra-in-O(rc-max(log-r-log-c))-time
        int[,] dirs = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

        public int trapRainWater(int[,] heightMap)
        {
            int m = heightMap.GetLength(0);

            int n = (m == 0 ? 0 : heightMap.GetLength(1));
            int res = 0;

//            PriorityQueue<int[]> pq = new PriorityQueue<>( (a, b)->a[2] - b[2]);

            //bool[,] visited = new bool[m,n];

            //for (int i = 0; i < m; i++)
            //{
            //    pq.Enqueue(new int[] { i, 0, heightMap[i,0] });
            //    pq.Enqueue(new int[] { i, n - 1, heightMap[i,n - 1] });

            //    visited[i,0] = visited[i,n - 1] = true;
            //}

            //for (int j = 1; j < n - 1; j++)
            //{
            //    pq.Enqueue(new int[] { 0, j, heightMap[0,j] });
            //    pq.Enqueue(new int[] { m - 1, j, heightMap[m - 1, j] });
            //    visited[0,j] = visited[m - 1,j] = true;
            //}

            //while (pq.Count > 0)
            //{
            //    int[] cell = pq.Dequeue();

            //    //for (int[] d : dirs)
            //    //{
            //    //    int i = cell[0] + d[0], j = cell[1] + d[1];
            //    //    if (i < 0 || i >= m || j < 0 || j >= n || visited[i,j])
            //    //        continue;

            //    //    res += Math.Max(0, cell[2] - heightMap[i,j]);

            //    //    pq.Enqueue(new int[] { i, j, Math.Max(heightMap[i,j], cell[2]) });

            //    //    visited[i,j] = true;
            //    //}
            //}

            return res;
        }

        /*
         https://codefightssolver.wordpress.com/2016/11/04/reverse-on-diagonals/

         Input  [[1, 2, 3],
                 [4, 5, 6],
                 [7, 8, 9]]

         Output [[9, 2, 7],
                 [4, 5, 6],
                 [3, 8, 1]]
        */

        public int[,] ReverseOnDiagonals(int[,] matrix)
        {
            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);

            int[,] result = new int[rLen, cLen];

            for (int rIndx = 0; rIndx < rLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    if (rIndx == cIndx || rIndx + cIndx + 1 == rLen)
                    {
                        result[rIndx, cIndx] = matrix[rLen - 1 - rIndx, cLen - 1 - cIndx];
                    }
                }
            }

            return result;
        }

        //https://www.geeksforgeeks.org/matrix-exponentiation/
        // // C# program to find value of f(n) where 
        // f(n) is defined as
        // F(n) = F(n-1) + F(n-2) + F(n-3), n >= 3
        // Base Cases :
        // F(0) = 0, F(1) = 1, F(2) = 1 
        class MatrixExponentiation
        {
            static void Multiply(int[,] a, int[,] b)
            {

                // Creating an auxiliary matrix to store 
                // elements of the multiplication matrix
                int[,] mul = new int[3, 3];

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        mul[i, j] = 0;
                        for (int k = 0; k < 3; k++)
                            mul[i, j] += a[i, k] * b[k, j];
                    }
                }

                // storing the muliplication resul 
                // in a[][]
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)

                        // Updating our matrix
                        a[i, j] = mul[i, j];
            }

            // Function to compute F raise to power n-2.
            static int Power(int[,] F, int n)
            {

                int[,] M = { { 1, 1, 1 }, { 1, 0, 0 },
                                        { 0, 1, 0 } };

                // Multiply it with initial values i.e
                // with F(0) = 0, F(1) = 1, F(2) = 1
                if (n == 1)
                    return F[0, 0] + F[0, 1];

                Power(F, n / 2);

                Multiply(F, F);

                if (n % 2 != 0)
                    Multiply(F, M);

                // Multiply it with initial values i.e 
                // with F(0) = 0, F(1) = 1, F(2) = 1
                return F[0, 0] + F[0, 1];
            }

            // Return n'th term of a series defined using below recurrence relation.
            // f(n) is defined as
            // f(n) = f(n-1) + f(n-2) + f(n-3), n>=3
            // Base Cases :
            // f(0) = 0, f(1) = 1, f(2) = 1
            static int FindNthTerm(int n)
            {
                int[,] F = { { 1, 1, 1 }, { 1, 0, 0 },
                                        { 0, 1, 0 } };

                return Power(F, n - 2);
            }

            public void MatrixExponentiationTest()
            {
                int n = 5;

                Console.WriteLine("F(5) is " + FindNthTerm(n));
            }
        }
    }
}