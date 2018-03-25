using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    partial class DynamicProgrammingStringSamples
    {
        // 718 Medium https://leetcode.com/problems/maximum-length-of-repeated-subarray/description/
        // Given two integer arrays A and B, return the maximum length of an subarray that appears in both arrays.
        // Example 1:
        // Input:
        // A: [1,2,3,2,1]
        // B: [3,2,1,4,7]
        // Output: 3
        // Explanation: 
        // The repeated subarray with maximum length is [3, 2, 1].
   
        // Note:
        // 1 <= len(A), len(B) <= 1000
        // 0 <= A[i], B[i] < 100

        public int FindLength(int[] nums1, int[] nums2)
        {
            int maxSubArrayLen = 0;

            int[,] memo = new int[nums1.Length + 1, nums2.Length + 1];

            for (int rIndx = nums1.Length- 1; rIndx >= 0; --rIndx)
            {
                for (int cIndx = nums2.Length - 1; cIndx >= 0; --cIndx)
                {
                    if (nums1[rIndx] == nums2[cIndx])
                    {
                        memo[rIndx,cIndx] = memo[rIndx + 1,cIndx + 1] + 1;

                        maxSubArrayLen = Math.Max(maxSubArrayLen, memo[rIndx, cIndx]);
                    }
                }
            }

            return maxSubArrayLen;
        }
    }
}