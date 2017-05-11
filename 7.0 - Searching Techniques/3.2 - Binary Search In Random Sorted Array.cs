using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class SearchingAlgorithms
    {
        //Follow Binary Search and add additional conditions to regular binary search. Time Complexity is O(log N)
        //Refer Binary search in Searching techniques to know how binary search works.
        public int BinarySearchInSortedRandomArray(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int leftIndx = 0;
            int rightIndx = nums.Length - 1;

            while (leftIndx <= rightIndx) // leftIndx less than or equals to rightIndx
            {
                int mid = (leftIndx + rightIndx) / 2;

                if (nums[mid] == target) // taget equals to mid
                    return mid;

                if (nums[leftIndx] <= nums[mid]) // left val less than or equals to mid
                {
                    if (target >= nums[leftIndx] && target < nums[mid]) // taget equals to left or between left and mid
                        rightIndx = mid - 1;
                    else
                        leftIndx = mid + 1;
                }
                else
                {
                    if (target > nums[mid] && target <= nums[rightIndx])// taget equals to right or between mid and right
                        leftIndx = mid + 1;
                    else
                        rightIndx = mid - 1;
                }
            }
            return -1;
        }

        /*  Test 3, 1, 2 fails when rightIndx = midPos
            Think about descending ordered array.
        */
        public int FindMinInSortedRotatedArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int leftIndx = 0;
            int rightIndx = nums.Length - 1;
            int midIndx = 0;

            while (leftIndx < rightIndx)
            {
                if (nums[leftIndx] < nums[rightIndx])
                    return nums[leftIndx];

                midIndx = leftIndx + ((rightIndx - leftIndx) / 2);

                if (nums[midIndx] > nums[rightIndx])
                    leftIndx = midIndx + 1;
                else
                {
                    ++leftIndx; // Optional
                    rightIndx = midIndx;
                }
            }


        /* Logic 2. Merging first if condition with while
            while (nums[leftIndx] > nums[rightIndx])
            {
                midIndx = (leftIndx + rightIndx) / 2;

                if (nums[midIndx] > nums[leftIndx])
                    leftIndx = midIndx + 1;
                else
                {
                    ++leftIndx;
                    rightIndx = midIndx;
                }
            }*/

            return nums[leftIndx];
        }
    }
}