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
    http://www.geeksforgeeks.org/dynamic-programming-set-4-longest-common-subsequence/
    */
    partial class DynamicProgrammingSamples
    {
        // Time Complexity O(2^N) Exponential Time. Returns length of LCS for X[0..m-1], Y[0..n-1]
        int LongestCommonSubSequenceNaive(string inputStr1, string inputStr2, int inputStr1Idx, int inputStr2Idx)
        {
            if (inputStr1Idx == 0 || inputStr2Idx == 0)
            {
                return 0;
            }

            if (inputStr1[inputStr1Idx - 1] == inputStr2[inputStr2Idx - 1])
            {
                return 1 + LongestCommonSubSequenceNaive(inputStr1, inputStr2, inputStr1Idx - 1, inputStr2Idx - 1);
            }

            else
            {
                return Math.Max(LongestCommonSubSequenceNaive(inputStr1, inputStr2, inputStr1Idx, inputStr2Idx - 1), LongestCommonSubSequenceNaive(inputStr1, inputStr2, inputStr1Idx - 1, inputStr2Idx));
            }
        }

        // Time Complexity O(N X M) Returns length of LCS for X[0..m-1], Y[0..n-1]
        int LongestCommonSubSequenceDP(string inputStr1, string inputStr2, int inputStr1Idx, int inputStr2Idx)
        {
            int[][] tempMatrix = new int[inputStr1Idx + 1][];

            for (int lpCnt = 0; lpCnt < (inputStr1Idx +1) ; lpCnt++)
            {
                tempMatrix[lpCnt] = new int[inputStr2Idx + 1];
            }

            // Following steps build L[m+1][n+1] in bottom up fashion. 
            // Note that L[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1] 
            for (int str1LpCnt = 0; str1LpCnt <= inputStr1Idx; str1LpCnt++)
            {
                for (int str2LpCnt = 0; str2LpCnt <= inputStr2Idx; str2LpCnt++)
                {
                    if (str1LpCnt == 0 || str2LpCnt == 0)
                    {
                        tempMatrix[str1LpCnt][str2LpCnt] = 0;
                    }
                    else if (inputStr1[str1LpCnt - 1] == inputStr2[str2LpCnt - 1])
                    {
                        tempMatrix[str1LpCnt][str2LpCnt] = tempMatrix[str1LpCnt - 1][str2LpCnt - 1] + 1;
                    }
                    else
                    {
                        tempMatrix[str1LpCnt][str2LpCnt] = Math.Max(tempMatrix[str1LpCnt - 1][str2LpCnt], tempMatrix[str1LpCnt][str2LpCnt - 1]);
                    }
                }
            }

            // tempMatrix[inputStr1Idx][inputStr2Idx] contains length of LCS for inputStr1[0..n-1] and inputStr2[0..m-1]
            return tempMatrix[inputStr1Idx][inputStr2Idx];
        }
        
        public void LongestCommonSubSequenceDPTest()
        {
            //string inputStr1 = "I Am Good";
            //string inputStr2 = "You Are Good";

            //string inputStr1 = "ABCDGH";
            //string inputStr2 = "AEDFHR";

            string inputStr1 = "AGGTAB";
            string inputStr2 = "GXTXAYB";
            
            MessageBox.Show("Length of LCS is \n" + LongestCommonSubSequenceDP(inputStr1, inputStr2, inputStr1.Length, inputStr2.Length));
        }
    }
}