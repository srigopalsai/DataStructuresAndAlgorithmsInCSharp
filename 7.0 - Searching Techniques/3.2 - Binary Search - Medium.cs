using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public partial class SearchingAlgorithms
    {
        // Medium https://leetcode.com/problems/find-the-duplicate-number
        public int FindDuplicate3(int[] nums)
        {
            int lIndx = 0;
            int rIndx = nums.Length - 1;

            while (lIndx <= rIndx)
            {
                int mIndx = lIndx + (rIndx - lIndx) / 2;
                int count = 0;

                foreach (int num in nums)
                {
                    if (num <= mIndx)
                    {
                        count++;
                    }
                }

                if (count <= mIndx)
                    lIndx = mIndx + 1;
                else
                    rIndx = mIndx - 1;
            }

            return lIndx;
        }

        //153 Medium https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
        // Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        // (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
        // Find the minimum element.
        // You may assume no duplicate exists in the array.

        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int stPos = 0;
            int endPos = nums.Length - 1;
            int midPos = 0;

            while (stPos < endPos)
            {
                midPos = stPos + ((endPos - stPos) / 2);

                if (nums[midPos] > nums[endPos])
                {
                    stPos = midPos + 1;
                }
                else
                {
                    //++stPos;
                    endPos = midPos;
                }
            }

            return nums[stPos];
        }

        // 154 Medium https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii
        // Follow up for "Find Minimum in Rotated Sorted Array":
        // What if duplicates are allowed?
        // Would this affect the run-time complexity? How and why?
        // Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        // (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
        // Find the minimum element.
        // The array may contain duplicates.
        public int FindMin2(int[] nums)
        {
            int lIndx = 0;
            int rIndx = nums.Length - 1;

            while (lIndx < rIndx)
            {
                int mid = lIndx + (rIndx - lIndx) / 2;

                if (nums[mid] == nums[rIndx])
                {
                    rIndx--;
                }
                else if (nums[mid] > nums[rIndx])
                {
                    lIndx = mid + 1;
                }
                else
                {
                    rIndx = mid;
                }               
            }

            return nums[lIndx];
        }

        // 162 Medium https://leetcode.com/problems/find-peak-element
        // A peak element is an element that is greater than its neighbors.
        // Given an input array where num[i] ≠ num[i + 1], find a peak element and return its index.
        // The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
        // You may imagine that num[-1] = num[n] = -∞.
        // For example, in array[1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.
        // Note: Your solution should be in logarithmic complexity.
        public int FindPeakElement(int[] num)
        {
            int lIndx = 0;
            int rIndx = num.Length - 1;

            while (lIndx < rIndx)
            {
                int mIndx1 = (lIndx + rIndx) / 2;
                int mIndx2 = mIndx1 + 1;

                if (num[mIndx1] < num[mIndx2])
                    lIndx = mIndx2;
                else
                    rIndx = mIndx1;
            }

            return lIndx;
        }

        // 33 Medium https://leetcode.com/problems/search-in-rotated-sorted-array
        // Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        // (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
        // You are given a target value to search.If found in the array return its index, otherwise return -1.
        // You may assume no duplicate exists in the array.
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int leftIndx = 0;
            int rightIndx = nums.Length - 1;

            while (leftIndx <= rightIndx)
            {
                int mid = (leftIndx + rightIndx) / 2;

                if (nums[mid] == target) // taget equals to mid
                    return mid;

                if (nums[leftIndx] <= nums[mid]) // Is roated and left is large values
                {
                    if (target >= nums[leftIndx] && target <= nums[mid]) // taget equals to left or between left and mid
                        rightIndx = mid - 1;
                    else
                        leftIndx = mid + 1;
                }
                else
                {
                    if (target >= nums[mid] && target <= nums[rightIndx])// taget equals to right or between mid and right
                        leftIndx = mid + 1;
                    else
                        rightIndx = mid - 1;
                }
            }
            return -1;
        }

        // 81 Medium https://leetcode.com/problems/search-in-rotated-sorted-array-ii
        // Follow up for "Search in Rotated Sorted Array":
        // What if duplicates are allowed?
        // Would this affect the run-time complexity? How and why?
        // Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
        // (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
        // Write a function to determine if a given target is in the array.
        // The array may contain duplicates.
        public bool SearchII(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int mid;

            while (left <= right)
            {
                mid = (left + right) >> 1;

                if (nums[mid] == target)
                    return true;

                // the only difference from the first one, trickly case, just updat left and right
                if (nums[mid] == nums[left] && nums[mid] == nums[right])
                {
                    ++left;
                    --right;
                }

                else if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target <= nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                }
                else
                {
                    if (nums[mid] <= target && target <= nums[right])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }
            return false;
        }

        public bool SearchII2(int[] nums, int target)
        {
            int lIndx = 0;
            int rIndx = nums.Length - 1;
            int mIndx = -1;

            while (lIndx <= rIndx)
            {
                mIndx = (lIndx + rIndx) / 2;

                if (nums[mIndx] == target)
                {
                    return true;
                }

                //If we know for sure right side is sorted or left side is unsorted
                if (nums[mIndx] < nums[rIndx] || nums[mIndx] < nums[lIndx])
                {
                    if (target >= nums[mIndx] && target <= nums[rIndx])
                    {
                        lIndx = mIndx + 1;
                    }
                    else
                    {
                        rIndx = mIndx - 1;
                    }
                }

                //If we know for sure left side is sorted or right side is unsorted            
                else if (nums[mIndx] > nums[lIndx] || nums[mIndx] > nums[rIndx])
                {
                    if (target <= nums[mIndx] && target >= nums[lIndx])
                    {
                        rIndx = mIndx - 1;
                    }
                    else
                    {
                        lIndx = mIndx + 1;
                    }
                }
                else
                {
                    //If we get here, that means nums[start] == nums[mid] == nums[end], then shifting out
                    //any of the two sides won't change the result but can help remove duplicate from
                    //consideration, here we just use end-- but left++ works too
                    lIndx++;
                    rIndx--;
                }
            }

            return false;
        }

        // 209 Medium https://leetcode.com/problems/minimum-size-subarray-sum
        // Given an array of n positive integers and a positive integer s, find the minimal length of a contiguous subarray of which the sum ≥ s.
        // If there isn't one, return 0 instead. 
        // For example, given the array[2, 3, 1, 2, 4, 3] and s = 7,
        // the subarray[4, 3] has the minimal length under the problem constraint.
        public int MinSubArrayLen(int s, int[] nums)
        {
            int cSum = 0;
            int indx1 = 0;
            int sLen = int.MaxValue;

            for (int indx2 = 0; indx2 < nums.Length; indx2++)
            {
                cSum += nums[indx2];

                while (cSum >= s)
                {
                    sLen = Math.Min(sLen, indx2 - indx1 + 1);
                    cSum -= nums[indx1];
                    indx1++;
                }
            }

            return (sLen == int.MaxValue) ? 0 : sLen;
        }

        public int[] SearchRange(int[] nums, int target)
        {
            int stIndx = Search1stGreaterEqual(nums, target);

            if (stIndx == nums.Length || nums[stIndx] != target)
            {
                return new int[] { -1, -1 };
            }

            return new int[] { stIndx, Search1stGreaterEqual(nums, target + 1) - 1 };
        }

        //Get the first occurance of the target value 

        private int Search1stGreaterEqual(int[] nums, int target)
        {
            int lIndx = 0;
            int rIndx = nums.Length;

            while (lIndx < rIndx)
            {
                int mid = (lIndx + rIndx) / 2;

                if (nums[mid] < target)
                {
                    lIndx = mid + 1;
                }

                else
                {
                    rIndx = mid;
                }
            }

            return lIndx;
        }

        // 74 Medium https://leetcode.com/problems/search-a-2d-matrix
        public bool SearchMatrix(int[,] matrix, int target)
        {

            if (matrix == null || matrix.Length == 0)
                return false;

            if (matrix.Length == 1)
                return matrix[0, 0] == target;

            int stIndx = 0;
            int endIndx = matrix.GetLength(0) * matrix.GetLength(1) - 1;
            int colLen = matrix.GetLength(1);

            while (stIndx <= endIndx)
            {
                int midIndx = stIndx + (endIndx - stIndx) / 2;

                int rIndx = midIndx / colLen;
                int cIndx = midIndx % colLen;

                if (target == matrix[rIndx, cIndx])
                {
                    return true;
                }
                else if (target < matrix[rIndx, cIndx])
                {
                    endIndx = midIndx - 1;
                }
                else
                {
                    stIndx = midIndx + 1;
                }
            }
            return false;
        }
    }
}