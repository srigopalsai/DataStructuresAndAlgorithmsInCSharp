using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public partial class SearchingAlgorithms
    {
        // 4 Hard https://leetcode.com/problems/median-of-two-sorted-arrays/description/
        // There are two sorted arrays nums1 and nums2 of size m and n respectively.
        // Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).
        // Example 1:
        // nums1 = [1, 3]
        // nums2 = [2]

        // The median is 2.0

        // Example 2:
        // nums1 = [1, 2]
        // nums2 = [3, 4]

        // The median is (2 + 3)/2 = 2.5
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int nums1Len = nums1.Length;
            int nums2Len = nums2.Length;

            int totalLen = nums1Len + nums2Len;

            if (totalLen % 2 == 0)
            {
                return (FindKthValue(nums1, nums2, totalLen / 2) + FindKthValue(nums1, nums2, (totalLen / 2) + 1)) / 2.0;
            }
            else
            {
                return FindKthValue(nums1, nums2, (totalLen / 2) + 1);
            }
        }

        private int FindKthValue(int[] nums1, int[] nums2, int kthPos)
        {
            int num1Indx = 0;
            int num2Indx = 0;

            for (int index = 0; index < kthPos - 1; index++)
            {
                if (num1Indx >= nums1.Length && num2Indx < nums2.Length)
                {
                    num2Indx++;
                }
                else if (num1Indx < nums1.Length && num2Indx >= nums2.Length)
                {
                    num1Indx++;
                }
                else if (nums1[num1Indx] > nums2[num2Indx])
                {
                    num2Indx++;
                }
                else
                {
                    num1Indx++;
                }
            }

            if (num1Indx >= nums1.Length)
            {
                return nums2[num2Indx];
            }
            else if (num2Indx >= nums2.Length)
            {
                return nums1[num1Indx];
            }
            else
            {
                return Math.Min(nums1[num1Indx], nums2[num2Indx]);
            }
        }
    }
}