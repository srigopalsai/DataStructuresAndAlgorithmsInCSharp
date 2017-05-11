using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using Keys = DataStructuresAndAlgorithms.TestData.Keys;
namespace DataStructuresAndAlgorithms
{
    /*

    ===================================================================================================================================================================================================
    Examples:
    arr[] = {1, 4, 45, 6, 0, 19}
    x  =  51
    Output: 3
    Minimum length subarray is {4, 45, 6}

    arr[] = {1, 10, 5, 2, 7}
    x  = 9
    Output: 1
    Minimum length subarray is {10}

    arr[] = {1, 11, 100, 1, 0, 200, 3, 2, 1, 250}
    x = 280
    Output: 4
    Minimum length subarray is {100, 1, 0, 200}

    Contiguous Sub Array:

    Try with Kadane's Algorithm.

    http://en.wikipedia.org/wiki/Maximum_subarray_problem
        http://analgorithmist.blogspot.com/2012/09/maximum-subarray-problem-kadanes.html
    http://analgorithmist.blogspot.com/2012/10/applying-kadanes-algorithm-to-2-d-array.html
    Apply Selction algorithm. http://en.wikipedia.org/wiki/Selection_algorithm

    http://www.geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value/
    
    Difference between big endian and little endian

    http://www.geeksforgeeks.org/google-mountain-view-interview/

    ===================================================================================================================================================================================================
    */

    partial class ArraySamples
    {
        IDictionary<string, int[]> ArraysCollection = TestData.ArraysCollection;

        // Returns length of smallest subarray with sum greater than x.
        // If there is no subarray with given sum, then returns n+1
        public void MaxSubArrayWithLargestSumTest()
        {
            stringBldr.Clear();
            int maxVal = MaxSubArray(ArraysCollection[Keys.Random9Till4Numbers]);

            MaxSubArrayWithPositions(ArraysCollection[Keys.Random9Till4Numbers]);

            MessageBox.Show(stringBldr.ToString());
        }

        /*  The maximum is initially nums[0], it starts at the left end (element nums[1]) and scans through to the right end (element nums[n - 1]), 
            keeping track of the maximum sum subvector seen so far. 
            Suppose we've solved the problem for nums[1 .. i - 1]; how can we extend that to nums[1 .. i]? 
            The maximum sum in the first i elements is either the maximum sum in the first i - 1 elements (which we'll call MaxSoFar), 
            or it is that of a subarray that ends in position i (which we'll call currMax).
            currMax is either nums[i] plus the previous currMax, or just nums[i], whichever is larger.  
            Note: We can see Dynamic Programming concept here (reusing sum) */
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int maxSoFar = nums[0];
            int currMax = nums[0];

            for (int lpCnt = 1; lpCnt < nums.Length; ++lpCnt)
            {
                currMax = currMax + nums[lpCnt];
                currMax = Math.Max(currMax, nums[lpCnt]);
                maxSoFar = Math.Max(currMax, maxSoFar);
            }
            return maxSoFar;
        }

        private int MaxSubArrayWithPositions(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int currStart = 0;
            int currSum = nums[0];

            int maxStart = 0;
            int maxEnd = 0;
            int maxSum = nums[0];

            for (int lpCnt = 1; lpCnt != nums.Length; lpCnt++)
            {
                currSum += nums[lpCnt];

                if (currSum <= nums[lpCnt])
                {
                    currSum = nums[lpCnt];
                    currStart = lpCnt + 1;
                }

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    maxStart = currStart;
                    maxEnd = lpCnt;
                }
            }

            stringBldr.AppendLine("Max sum         : " + maxSum);
            stringBldr.AppendLine("Max start index : " + maxStart);
            stringBldr.AppendLine("Max end index   : " + maxEnd);

            return maxSum;
        }

        // Divide and Conquer Method
        public int MaxSubArrayDividendConquer(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            return MaxSubArrayDACHelper(nums, 0, nums.Length - 1);
        }

        int MaxSubArrayDACHelper(int[] nums, int leftPos, int rightPos)
        {
            if (rightPos == leftPos)
                return nums[leftPos];

            int middlePos = leftPos + ((rightPos - leftPos ) / 2);

            int leftMax = MaxSubArrayDACHelper(nums, leftPos, middlePos);
            int rightMax = MaxSubArrayDACHelper(nums, middlePos + 1, rightPos);

            int leftCellMax = nums[middlePos];
            int righCellMax = nums[middlePos + 1];
            int tempMax = 0;

            for (int leftPartIndx = middlePos; leftPartIndx >= leftPos; leftPartIndx--)
            {
                tempMax += nums[leftPartIndx];

                if (tempMax > leftCellMax)
                    leftCellMax = tempMax;
            }

            tempMax = 0;

            for (int rightPartIndx = middlePos + 1; rightPartIndx <= rightPos; rightPartIndx++)
            {
                tempMax += nums[rightPartIndx];

                if (tempMax > righCellMax)
                    righCellMax = tempMax;
            }

            return Math.Max(Math.Max(leftMax, rightMax), leftCellMax + righCellMax);
        }
    }
}