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

        // 152 https://leetcode.com/problems/maximum-product-subarray/description/
        // 2, 3, -2, 4, 5, -6  Output 1440
        // 2, 3, -2, 0, 5, -6  Output 6

        public int MaxProduct(int[] nums)
        {
            int finalMax = nums[0];
            int curMax = nums[0];
            int curMin = nums[0];

            for (int indx = 1; indx < nums.Length; indx++)
            {
                // Multiplied by a negative makes big number smaller, small number bigger so we redefine the extremums by swapping them

                if (nums[indx] < 0)
                    Common.Swap(ref curMax, ref curMin);

                curMin = Math.Min(curMin, curMin * nums[indx]);
                curMax = Math.Max(curMax, curMax * nums[indx]);

                finalMax = Math.Max(finalMax, curMax);
            }
            return finalMax;
        }

        public int MaxProduct1(int[] nums)
        {
            int finalMax = nums[0];
            int curMax = nums[0];
            int curMin = nums[0];

            for (int indx = 1; indx < nums.Length; indx++)
            {
                // Multiplied by a negative makes big number smaller, small number bigger so we redefine the extremums by swapping them

                if (nums[indx] < 0)
                    Common.Swap(ref curMax, ref curMin);

                if (nums[indx] < curMin * nums[indx])
                    curMin = nums[indx];
                else
                    curMin = curMin * nums[indx];

                if (nums[indx] > curMax * nums[indx])
                    curMax = nums[indx];
                else
                    curMax = curMax * nums[indx];

                finalMax = Math.Max(finalMax, curMax);
            }
            return finalMax;
        }

        // 628 https://leetcode.com/problems/maximum-product-of-three-numbers/description/
        // 2 3 -3 4 5 -6 Output = 90
        public int MaximumProduct(int[] nums)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            int max3 = int.MinValue;

            int min1 = int.MaxValue;
            int min2 = int.MaxValue;

            foreach (int num in nums)
            {
                if (num > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = num;
                }
                else if (num > max2)
                {
                    max3 = max2;
                    max2 = num;
                }
                else if (num > max3)
                {
                    max3 = num;
                }

                if (num < min1)
                {
                    min2 = min1;
                    min1 = num;
                }
                else if (num < min2)
                {
                    min2 = num;
                }
            }

            return Math.Max(max1 * max2 * max3, 
                            max1 * min1 * min2);
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

        /*Given an array, you should start at index 0, and you can jump from the current index to a max of " current index + arr[current index]
and make it out of the array at the other end in minimum number of hops.*/

        public String GetHopsGuide(int[] nums)
        {
            if (nums == null || nums.Length == 0 || nums[0] == 0)
                return "failure";

            int[] hopsLkUp = new int[nums.Length + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length + 1; j++)
                {
                    int alternatePath = 0;

                    if (j <= i + nums[i])
                    {
                        alternatePath = j - i;
                        hopsLkUp[j] = Math.Max(hopsLkUp[j], alternatePath);
                    }
                    else
                        break;
                }
            }

            if (hopsLkUp[hopsLkUp.Length - 1] > 0)
            {
                String path = "out";

                for (int i = hopsLkUp.Length - 1; i > 0;)
                {
                    i -= hopsLkUp[i];
                    path = i + " " + path;
                }

                return path;
            }
            else
            {
                return "failure";
            }
        }

        public void GetHopsGuideTest(string[] args)
        {
            int[] arr = { 5, 6, 0, 4, 2, 4, 1, 0, 0, 4 };
            //int[] arr1 = { 2,1,2,4,0,0,0};
            //int[] arr1 = {  };

            String hopsguide = null;

            try
            {
                hopsguide = GetHopsGuide(arr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(hopsguide);
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

        public int MinimumTotal(List<List<int>> triangle)
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

        /*
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Assume we have collection 1 Coins, 2 Coins and 3 Coins.

    Now we need minimum no of coins for the amount 5. 

    1. {1,1,1,1,1}  5 Coins.
    2. {2,2,1}      3 Coins.
    3. {3,2}        2 Coins. -- This is the solution.

    1. Optimal Sub Structure : 
       All sub problems solutions should be optimal

    2. Overlapping Sub Problem : (Recursion)

    C(P) = Min No Of Coins Required to make change for the amount P.

    P - Sum

    C(P) = Min { C(P-Vi)} + 1  Where i = 1...N
            i
    C(P) = Min { C(P-V1), C(P-V2), C(P-V3)......C(P-Vn)} + 1
            i
    V1 = 1, V2 = 2, V3 = 3

    C(0) = 0

    C(1) = Min { C(1 - 1) } + 1                     = 1 Coin.
            i

    C(2) = Min { C(2 - 1), C(2 - 2) } + 1     
            1
         = Min { 1, 0 } + 1                         = 1 Coin.

    C(3) = Min { C(3 - 1), C(3 - 2), C(3 - 3) } + 1     
            1
         = Min { C(2), C(1), C(0) } + 1             
         = Min {1, 1, 0} + 1                        = 1 Coin.      

    C(4) = Min { C(4 - 1), C(4 - 2), C(4 - 3) } + 1     
            1
         = Min { 1, 1, 1 } + 1                      = 2 Coins. 

    C(5) = Min { C(5 - 1), C(5 - 2), C(5 - 3) } + 1     
            1
         = Min { C(4), C(3), C2) } + 1
         = Min { 2, 1, 1 } + 1 
         = 1 + 1                                    = 2 Coins.

    C(5) = Min { C(6 - 1), C(6 - 2), C(6 - 3) } + 1     
            1

         = Min { C(5), C(4), C(3)) } + 1
         = Min { 2, 1, 1 } + 1 
         = 1 + 1                                    = 2 Coins.

    It shows that minimum no of coins required for each amount V1, V2, V3. Every sub problem is optimal.

    We can implement a dynamic programming algorithm in at least two different approaches. One is the top-down approach using memoization, the other is the bottom-up iterative approach.

    For a beginner to dynamic programming, Start with top-down approach first since this will help them understand the recurrence relationships in dynamic programming

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Memoization is a technique that is associated with Dynamic Programming. The concept is to cache the result of a function given its parameter so that the calculation will not be repeated; it is simply retrieved, or memo-ed. Most of the time a simple array is used for the cache table, but a hash table or map could also be employed. 


    A modified version of dynamic programming where, at the end, you work backwards to produce a solution. 
    E.g Instead of "find the least number of coins needed to make change" you would actually have to output the list of coins.
    Variants on this technique include producing the lexicographically-first solution when multiple solutions exist.

    */
        StringBuilder resultStrBldr = new StringBuilder();
        public int GetMinimumCoins(int[] denominationCoins, int amountRequested)
        {
            int NoOfCoins = 0;
            int CoinsIndx;
            int[] CoinsCount = new int[amountRequested + 1];

            // Loop for Total Amount Requested.
            for (int lpAmntIndx = 1; lpAmntIndx <= amountRequested; lpAmntIndx++)
            {
                NoOfCoins = Int32.MaxValue;

                // Loop for No of Denomication Available.
                for (int lpDenomIndx = 0; lpDenomIndx < denominationCoins.Length; lpDenomIndx++)
                {
                    // Coin value should not exceed the amount itself
                    if (denominationCoins[lpDenomIndx] <= lpAmntIndx)
                    {
                        CoinsIndx = lpAmntIndx - denominationCoins[lpDenomIndx];
                        NoOfCoins = Math.Min(NoOfCoins, CoinsCount[CoinsIndx]);
                    }
                }

                if (NoOfCoins < Int32.MaxValue)
                {
                    CoinsCount[lpAmntIndx] = NoOfCoins + 1;
                }
                else
                {
                    CoinsCount[lpAmntIndx] = Int32.MaxValue;
                }
            }

            NoOfCoins = CoinsCount[amountRequested];
            return NoOfCoins;
        }

        static int GetMinimumCoinsRec(int[] denominationCoins, int amountRequested)
        {
            if (amountRequested == 0)
                return 0;

            int result = int.MaxValue;

            // Try every coin that has smaller value than V
            for (int indx = 0; indx < denominationCoins.Length; indx++)
            {
                if (denominationCoins[indx] <= amountRequested)
                {
                    int subResult = GetMinimumCoinsRec(denominationCoins, amountRequested - denominationCoins[indx]);

                    // Check for IntMax to avoid overflow and see if result can minimized
                    if (subResult != int.MaxValue && subResult + 1 < result)
                    {
                        result = subResult + 1;
                    }
                }
            }

            return result;
        }

        public void MinimumCoinsTest()
        {
            int NoOfDenominations = 5;

            int[] DenominationCoins = new int[NoOfDenominations];

            for (int lpDenomination = 0; lpDenomination < NoOfDenominations; lpDenomination++)
            {
                DenominationCoins[lpDenomination] = lpDenomination + 1;
            }
            int NoOfCoins = 0;

            NoOfCoins = GetMinimumCoins(DenominationCoins, 50);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 50 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 16);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 16 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 15);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 15 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 10);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 10 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 9);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 9 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 8);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 8 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 7);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 7 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 6);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 6 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 5);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 5 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 4);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 4 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 3);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 3 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 2);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 2 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 1);
            resultStrBldr.AppendLine("Minimum number of coins for Amount 1 : " + NoOfCoins);

            MessageBox.Show(Convert.ToString(resultStrBldr));
        }

        // 221 https://leetcode.com/submissions/detail/122418976/
        // https://leetcode.com/articles/maximal-square/
        // Can be solved with DFS 
        // DP O(m)
        public int MaximalSquare(char[,] matrix)
        {
            int[] dpLkUp = new int[matrix.GetLength(1) + 1];
            int tempPrev = 0;
            int prevMax = 0;
            int maxSqLen = 0;

            for (int rIndx = 1; rIndx <= matrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 1; cIndx <= matrix.GetLength(1); cIndx++)
                {
                    tempPrev = dpLkUp[cIndx];

                    if (matrix[rIndx - 1, cIndx - 1] == '1')
                    {
                        dpLkUp[cIndx] = Math.Min(dpLkUp[cIndx], Math.Min(dpLkUp[cIndx - 1], prevMax)) + 1;
                        maxSqLen = Math.Max(maxSqLen, dpLkUp[cIndx]);
                    }
                    else
                    {
                        dpLkUp[cIndx] = 0;
                    }

                    prevMax = tempPrev;
                }
            }
            return maxSqLen * maxSqLen;
        }

        // DP O(m X n)
        public int MaximalSquare2(char[,] srcMatrix)
        {
            if (srcMatrix == null || srcMatrix.Length == 0)
                return 0;

            int maxSqLen = 0;
            int cLen = srcMatrix.GetLength(1);
            int rLen = srcMatrix.GetLength(0);

            int[,] tmpMatrix = new int[cLen + 1, rLen + 1];

            for (int rIndx = 1; rIndx <= cLen; rIndx++)
            {
                for (int cIndx = 1; cIndx <= rLen; cIndx++)
                {
                    if (srcMatrix[rIndx - 1, cIndx - 1] == '1')
                    {
                        tmpMatrix[rIndx, cIndx] = Math.Min(tmpMatrix[rIndx - 1, cIndx - 1], 
                                                            Math.Min(tmpMatrix[rIndx - 1, cIndx], 
                                                                     tmpMatrix[rIndx, cIndx - 1])
                                                           ) + 1;
                        maxSqLen = Math.Max(maxSqLen, tmpMatrix[rIndx, cIndx]);
                    }
                }
            }

            return maxSqLen * maxSqLen;
        }

        // 363 https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/description/
        // 85 https://leetcode.com/problems/maximal-rectangle/description/
        public int MaximalRectangle(char[,] srcMatrix)
        {
            int cLen = srcMatrix.GetLength(1);
            int maxA = 0;

            int[,] tmpMatrix = new int[cLen, 3]; //[i, 0] is left; [i, 1] is right; [i, 2] is height

            for (int rIndx = 0; rIndx < cLen; rIndx++)
            {
                tmpMatrix[rIndx, 1] = cLen;
            }

            for (int rIndx = 0; rIndx < srcMatrix.GetLength(0); rIndx++)
            {
                int curLeft = 0;
                int curRight = cLen;

                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    if (srcMatrix[rIndx, cIndx] == '1')     // compute height (can do this from either side)
                    {
                        tmpMatrix[cIndx, 2]++;
                    }
                    else
                    {
                        tmpMatrix[cIndx, 2] = 0;
                    }
                    if (srcMatrix[rIndx, cIndx] == '1')     // compute left (from left to right)
                    {
                        tmpMatrix[cIndx, 0] = Math.Max(tmpMatrix[cIndx, 0], curLeft);
                    }
                    else
                    {
                        tmpMatrix[cIndx, 0] = 0;
                        curLeft = cIndx + 1;
                    }
                }
                // compute right (from right to left)
                for (int cIndx = cLen - 1; cIndx >= 0; cIndx--)
                {
                    if (srcMatrix[rIndx, cIndx] == '1')
                    {
                        tmpMatrix[cIndx, 1] = Math.Min(tmpMatrix[cIndx, 1], curRight);
                    }
                    else
                    {
                        tmpMatrix[cIndx, 1] = cLen;
                        curRight = cIndx;
                    }
                }
                // compute the area of rectangle (can do this from either side)
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    maxA = Math.Max(maxA, (tmpMatrix[cIndx, 1] - tmpMatrix[cIndx, 0]) * tmpMatrix[cIndx, 2]);
                }
            }
            return maxA;
        }

        public int MaximalRectangle2BFS(int[,] matrix)
        {
            if (matrix.Length == 0)
                return 0;

            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);
            int maxArea = 0;

            for (int rIndx = 0; rIndx < rLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    if (matrix[rIndx, cIndx] == '1')
                    {
                        maxArea = Math.Max(maxArea, BFSHelperForMR(matrix, rIndx, cIndx));
                    }
                }
            }
            return maxArea;
        }

        int BFSHelperForMR(int[,] matrix, int curRIndx, int curCIndx)
        {
            int trvRIndx = curRIndx - 1;
            int maxArea = 0;

            while (trvRIndx >= 0 && matrix[trvRIndx,curCIndx] == '1')
            {
                trvRIndx--;
            }

            for (int cIndx = curCIndx; cIndx >= 0 && matrix[curRIndx,cIndx] == '1'; cIndx--)
            {
                for (int rIndx = trvRIndx + 1; rIndx <= curRIndx; rIndx++)
                { 
                    if (matrix[rIndx,cIndx] == '0')
                    {
                        trvRIndx = Math.Max(trvRIndx, rIndx);
                    }

                    maxArea = Math.Max(maxArea, (curRIndx - trvRIndx) * (curCIndx - cIndx + 1));
                }
            }
            return maxArea;
        }

        public int MaximalRectangle3DFS(char[,] matrix)
        {
            var rLen = matrix.GetLength(0);
            var cLen = matrix.GetLength(1);
            int maxArea = 0;

            int[] heightsDP = new int[cLen];
            Stack<int> stack = new Stack<int>();

            for (int rIndx = 0; rIndx < rLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    heightsDP[cIndx] = matrix[rIndx, cIndx] == '0' ? 0 : heightsDP[cIndx] + 1;
                }

                for (int cIndx = 0; cIndx < cLen + 1; cIndx++)
                {
                    var hVal = cIndx == cLen ? 0 : heightsDP[cIndx];

                    if (stack.Count == 0 || heightsDP[stack.Peek()] < hVal)
                    {
                        stack.Push(cIndx);
                    }
                    else
                    {
                        int mid = stack.Pop();
                        int left = stack.Count == 0 ? -1 : stack.Peek();

                        maxArea = Math.Max(maxArea, heightsDP[mid] * (cIndx-- - left - 1));
                    }
                }

                stack.Pop();
            }

            return maxArea;
        }

        public int maximalRectangleHistogram(char[,] matrix)
        {
            if (matrix.Length == 0)
                return 0;

            int maxArea = 0;
            int rLen = matrix.GetLength(0);
            int cLen = matrix.GetLength(1);

            int[] height = new int[cLen]; // height

            for (int rIndx = 0; rIndx < rLen; rIndx++)
            {
                for (int cIndx = 0; cIndx < cLen; cIndx++)
                {
                    if (matrix[rIndx,cIndx] == '0')
                    {
                        height[cIndx] = 0;
                        continue;
                    }

                    height[cIndx]++;
                    int pre = height[cIndx];

                    for (int cur = cIndx - 1 ; cur >= 0; cur--)
                    {
                        if (height[cur] == 0)
                            break;

                        pre = Math.Min(pre, height[cur]);
                        maxArea = Math.Max(maxArea, (cIndx - cur + 1) * pre);
                    }

                    maxArea = Math.Max(maxArea, height[cIndx]);
                }
            }
            return maxArea;
        }

        // 486 https://leetcode.com/problems/predict-the-winner/description/
        public bool PredictTheWinner(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return true;

            int nLen = nums.Length;
            int[] dpLkUp = new int[nLen];

            for (int p1Indx = nLen - 1; p1Indx >= 0; p1Indx--)
            {
                for (int p2Indx = p1Indx; p2Indx < nLen; p2Indx++)
                {
                    if (p1Indx == p2Indx)
                    {
                        dpLkUp[p1Indx] = nums[p1Indx];
                    }
                    else
                    {
                        dpLkUp[p2Indx] = Math.Max(nums[p1Indx] - dpLkUp[p2Indx],
                                                    nums[p2Indx] - dpLkUp[p2Indx - 1]);
                    }
                }
            }

            return dpLkUp[nLen - 1] >= 0;
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
         */

        public class NumArray
        {
            private int[] sum;

            public NumArray(int[] nums)
            {
                sum = new int[nums.Length + 1];
                for (int idx = 0; idx < nums.Length; idx++)
                {
                    sum[idx + 1] = sum[idx] + nums[idx];
                }
            }

            public int SumRange(int i, int j)
            {
                return sum[j + 1] - sum[i];
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

        // 53 https://leetcode.com/problems/maximum-subarray/
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int maxSoFar = nums[0];
            int currMax = nums[0];

            for (int lpCnt = 1; lpCnt < nums.Length; ++lpCnt)
            {
                currMax = Math.Max(nums[lpCnt], currMax + nums[lpCnt] );
                maxSoFar = Math.Max(maxSoFar, currMax);
            }
            return maxSoFar;
        }

        // Kadanes Algorithm  https://en.wikipedia.org/wiki/Maximum_subarray_problem 
        // Should have one positve number to work
        public int MaxSubArray2(int[] nums)
        {
            int[] dp = new int[nums.Length];

            dp[0] = nums[0];
            int max = dp[0];

            for (int idx = 1; idx < nums.Length; idx++)
            {
                dp[idx] = Math.Max(nums[idx] + dp[idx - 1], nums[idx]);
                max = Math.Max(max, dp[idx]);
            }

            return max;
        }

        public int MaxProduct2(int[] nums)
        {
            int maxPro = nums[0];
            int curMax = maxPro;
            int curMin = maxPro;

            // Store max/min product of subarray that ends with the current number A[i]
            for (int indx = 1; indx < nums.Length; indx++)
            {
                // multiplied by a negative makes big number smaller, small number bigger
                // so we redefine the extremums by swapping them
                if (nums[indx] < 0)
                    Swap(ref curMax, ref curMin);

                // max/min product for the current number is either the current number itself
                // or the max/min by the previous number times the current one

                curMax = Math.Max(nums[indx], curMax * nums[indx]);
                curMin = Math.Min(nums[indx], curMin * nums[indx]);
                maxPro = Math.Max(maxPro, curMax);

            }
            return maxPro;
        }

        private static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}