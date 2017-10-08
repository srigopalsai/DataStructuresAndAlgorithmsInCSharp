using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /// String Problems

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

            /*dp[i][j] means from index i to index j, the longest palindromic subsequence*/
            int[,] lkUpMat = new int [strLen + 1, strLen + 1];

            /*dp initialization dp[i,i] means contains one character so it equals one*/
            for (int indx = 1; indx <= strLen; ++indx)
            {
                lkUpMat[indx , indx] = 1;
            }

            for (int lIndx = 1; lIndx < strLen; ++lIndx)
            {
                for (int rIndx = lIndx - 1; rIndx >= 0; --rIndx)
                {
                    if (str[rIndx] == str[lIndx])
                    {
                        lkUpMat[rIndx,lIndx] = Math.Max(lkUpMat[rIndx + 1,lIndx - 1] + 2, 
                                            Math.Max(lkUpMat[rIndx + 1,lIndx], lkUpMat[rIndx,lIndx - 1]));
                    }
                    else
                    {
                        lkUpMat[rIndx,lIndx] = Math.Max(lkUpMat[rIndx + 1,lIndx - 1],
                                        Math.Max(lkUpMat[rIndx + 1,lIndx], lkUpMat[rIndx,lIndx - 1]));
                    }
                }
            }
            return lkUpMat[0 ,strLen - 1];
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

        /*
        http://www.dsalgo.com/2013/02/longest-common-subsequence.html
        http://www.geeksforgeeks.org/longest-common-substring/

        */
        public int LongestCommonSubStringDP(string str1, string str2)
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
        public void LongestCommonSubStringDPTest(String[] args)
        {
            String str1 = "OldSite:GeeksforGeeks.org";
            String str2 = "NewSite:GeeksQuiz.com";

            MessageBox.Show("Length of Longest Common Substring is " + LongestCommonSubStringDP(str1, str2));
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
        public class NumArray1
        {
            int[] nums;

            public NumArray1(int[] nums)
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

        public class Immutable2DSumRangeQuery1
        {
            private int[,] lkUpMat;

            public Immutable2DSumRangeQuery1(int[,] srcMatrix)
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