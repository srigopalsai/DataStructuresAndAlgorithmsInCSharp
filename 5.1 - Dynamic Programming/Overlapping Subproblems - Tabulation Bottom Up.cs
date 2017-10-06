using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    Input : Str1: I Am Good.
            Str2: You Are Good.

    Output:  Longest Common Sub Sequence : AGood.
    
    http://en.wikipedia.org/wiki/Longest_common_subsequence_problem
    http://www.algorithmist.com/index.php/Longest_Common_Subsequence
    https://www.youtube.com/watch?v=P-mMvhfJhu8
    https://www.youtube.com/watch?v=IFQfU5pQ8-I
    http://www.geeksforgeeks.org/longest-common-subsequence/
    http://www.geeksforgeeks.org/dynamic-programming-set-4-longest-common-subsequence/
    http://www.geeksforgeeks.org/dynamic-programming-set-12-longest-palindromic-subsequence/
    http://www.geeksforgeeks.org/manachers-algorithm-linear-time-longest-palindromic-substring-part-2/
    https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/LongestPalindromicSubsequence.java
    https://www.hackerearth.com/practice/algorithms/string-algorithm/manachars-algorithm/tutorial/
    */
    partial class DynamicProgrammingSamples
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

        // Time Complexity O(N X M) Returns length of LCS for X[0..m-1], Y[0..n-1]
        int LongestCommonSubSequenceDP(string s1, string s2)
        {
            int[,] lkUpMtrx = new int[s1.Length + 1, s2.Length + 1];

            // Following steps build L[m+1,n+1] in bottom up fashion. 
            for (int s1in = 1; s1in <= s1.Length; s1in++)
            {
                for (int s2in = 1; s2in <= s2.Length; s2in++)
                {
                    if (s1[s1in - 1] == s2[s2in - 1])
                    {
                        lkUpMtrx[s1in, s2in] = lkUpMtrx[s1in - 1, s2in - 1] + 1;
                    }
                    else
                    {
                        lkUpMtrx[s1in, s2in] = Math.Max(lkUpMtrx[s1in - 1, s2in],
                                                        lkUpMtrx[s1in, s2in - 1]);
                    }
                }
            }

            // Contains length of LCS for inputStr1[0..n-1] and inputStr2[0..m-1]
            return lkUpMtrx[s1.Length, s2.Length];
        }

        // Time Complexity O(2^N) Exponential Time. Returns length of LCS for X[0..m-1], Y[0..n-1]

        int LongestCommonSubSequenceRec(string str1, string str2, int str1Indx, int str2Indx)
        {
            if (str1Indx == 0 || str2Indx == 0)
                return 0;

            if (str1[str1Indx - 1] == str2[str2Indx - 1])
                return 1 + LongestCommonSubSequenceRec(str1, str2, str1Indx - 1, str2Indx - 1);

            return Math.Max(LongestCommonSubSequenceRec(str1, str2, str1Indx, str2Indx - 1),
                            LongestCommonSubSequenceRec(str1, str2, str1Indx - 1, str2Indx));
        }

        public void LongestCommonSubSequenceDPTest()
        {            
            string str1 = "IAmGood";
            string str2 = "UAreGood"; // AGood is the CSS.

            //string str1 = "ABCDGH";
            //string str2 = "AEDFHR";

            //string str1 = "AGGTAB";
            //string str2 = "GXTXAYB";

            //MessageBox.Show("Length of LCS is \n" + LongestCommonSubSequenceRec(str1, str2, str1.Length, str2.Length));
            MessageBox.Show("Length of LCS is \n" + LongestCommonSubSequenceDP(str1, str2));
        }

        // https://leetcode.com/problems/longest-uncommon-subsequence-ii/description/
        int LongestUnCommonSubSequenceDP(string str1, string str2)
        {
            int[,] lkUpMtrx = new int[str1.Length + 1, str2.Length + 1];

            // Following steps build L[m+1,n+1] in bottom up fashion. 
            for (int str1Indx = 0; str1Indx <= str1.Length; str1Indx++)
            {
                for (int str2Indx = 0; str2Indx <= str2.Length; str2Indx++)
                {
                    if (str1Indx == 0 || str2Indx == 0)
                    {
                        lkUpMtrx[str1Indx, str2Indx] = 0;
                    }
                    else if (str1[str1Indx - 1] == str2[str2Indx - 1])
                    {
                        lkUpMtrx[str1Indx, str2Indx] = lkUpMtrx[str1Indx - 1, str2Indx - 1] + 1;
                    }
                    else
                    {
                        lkUpMtrx[str1Indx, str2Indx] = Math.Max(lkUpMtrx[str1Indx - 1, str2Indx],
                                                                    lkUpMtrx[str1Indx, str2Indx - 1]);
                    }
                }
            }

            // Contains length of LCS for inputStr1[0..n-1] and inputStr2[0..m-1]
            return lkUpMtrx[str1.Length, str2.Length];
        }

        public int LongestPalindromeSubseq(string str)
        {
            int strLen = str.Length;
            if (strLen <= 1)
            {
                return strLen;
            }

            /*dp[i,j] means from index i to index j, the longest palindromic subsequence*/
            int[,] lkUp = new int [strLen + 1, strLen + 1];

            /*dp initialization dp[i,i] means contains one character so it equals one*/
            for (int indx = 1; indx <= strLen; ++indx)
            {
                lkUp[indx , indx] = 1;
            }

            for (int lIndx = 1; lIndx < strLen; ++lIndx)
            {
                for (int rIndx = lIndx - 1; rIndx >= 0; --rIndx)
                {
                    if (str[rIndx] == str[lIndx])
                    {
                        lkUp[rIndx,lIndx] = Math.Max(lkUp[rIndx + 1,lIndx - 1] + 2, 
                                            Math.Max(lkUp[rIndx + 1,lIndx], lkUp[rIndx,lIndx - 1]));
                    }
                    else
                    {
                        lkUp[rIndx,lIndx] = Math.Max(lkUp[rIndx + 1,lIndx - 1],
                                        Math.Max(lkUp[rIndx + 1,lIndx], lkUp[rIndx,lIndx - 1]));
                    }
                }
            }
            return lkUp[0 ,strLen - 1];
        }

        public int LongestPalindromeSubseq2(String str)
        {
            int[,] lkUp = new int[str.Length, str.Length];

            for (int lIndx = str.Length - 1; lIndx >= 0; lIndx--)
            {
                lkUp[lIndx, lIndx] = 1;

                for (int rIndx = lIndx + 1; rIndx < str.Length; rIndx++)
                {
                    if (str[lIndx] == str[rIndx])
                    {
                        lkUp[lIndx, rIndx] = lkUp[lIndx + 1, rIndx - 1] + 2;
                    }
                    else
                    {
                        lkUp[lIndx, rIndx] = Math.Max(lkUp[lIndx + 1, rIndx], 
                                                      lkUp[lIndx, rIndx - 1]);
                    }
                }
            }

            return lkUp[0, str.Length - 1];
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
        /*
        http://www.dsalgo.com/2013/02/longest-common-subsequence.html
        http://www.geeksforgeeks.org/longest-common-substring/

        */
        static int LongestCommonSubStringDP(string str1, string str2)
        {
            //Note that LCSuff[i,j] contains length of longest common suffix of X[0..i-1] and Y[0..j-1].
            //The first row and first column entries have no logical meaning, they are used only for simplicity of program

            int[,] lkUp = new int[str1.Length + 1, str2.Length + 1];
            int result = 0;

            // Following steps build lkUp[m+1,n+1] in bottom up fashion
            for (int str1Indx = 0; str1Indx <= str1.Length; str1Indx++)
            {
                for (int str2Indx = 0; str2Indx <= str2.Length; str2Indx++)
                {
                    if (str1Indx == 0 || str2Indx == 0)
                    {
                        lkUp[str1Indx, str2Indx] = 0;
                    }
                    else if (str1[str1Indx - 1] == str2[str2Indx - 1])
                    {
                        lkUp[str1Indx, str2Indx] = lkUp[str1Indx - 1, str2Indx - 1] + 1;
                        result = Math.Max(result, lkUp[str1Indx, str2Indx]);
                    }
                    else
                    {
                        lkUp[str1Indx, str2Indx] = 0;
                    }
                }
            }

            return result;
        }

        // Driver Program to test above function
        public static void LongestCommonSubStringDPTest(String[] args)
        {
            String str1 = "OldSite:GeeksforGeeks.org";
            String str2 = "NewSite:GeeksQuiz.com";

            MessageBox.Show("Length of Longest Common Substring is " + LongestCommonSubStringDP(str1, str2));
        }
    }
}