using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public partial class SearchingAlgorithms
    {
        // 4 Hard https://leetcode.com/problems/median-of-two-sorted-arrays
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
            int n1Len = nums1.Length;
            int n2Len = nums2.Length;

            if (n1Len < n2Len)
            {
                return FindMedianSortedArrays(nums2, nums1);    // Make sure nums2 is the shorter one.
            }

            int lIndx = 0;
            int rIndx = n2Len * 2;

            while (lIndx <= rIndx)
            {
                int m2Indx = (lIndx + rIndx) / 2;   // Try Cut 2 
                int m1Indx = n1Len + n2Len - m2Indx;  // Calculate Cut 1 accordingly

                double n1LMidVal = (m1Indx == 0) ? int.MinValue : nums1[(m1Indx - 1) / 2];    // Get L1, R1, L2, R2 respectively
                double n2LMidVal = (m2Indx == 0) ? int.MinValue : nums2[(m2Indx - 1) / 2];

                double n1RMidVal = (m1Indx == n1Len * 2) ? int.MaxValue : nums1[(m1Indx) / 2];
                double n2RMidVal = (m2Indx == n2Len * 2) ? int.MaxValue : nums2[(m2Indx) / 2];

                if (n1LMidVal > n2RMidVal)
                {
                    lIndx = m2Indx + 1;
                }
                else if (n2LMidVal > n1RMidVal)
                {
                    rIndx = m2Indx - 1;
                }
                else
                {
                    return (Math.Max(n1LMidVal, n2LMidVal) + Math.Min(n1RMidVal, n2RMidVal)) / 2;
                }
            }

            return -1;
        }        
    }
}