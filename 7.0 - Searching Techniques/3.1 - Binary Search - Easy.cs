using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================

    Arrays should be in sorted order
    
    Worst case performance      O(log n) 
    Best case performance       O(1) 
    Average case performance    O(log n) 

    Worst case space complexity O(1)
    
    http://en.wikipedia.org/wiki/Binary_search_algorithm
        
    E.g.  Sorted List Contains. 1   2   3   4   5   6   7   8   9   10
    ElementToSearch 2.

    ============================================================================================================================================================================================================================
    
    Iteration 1:
    
    startPos = 0
    endPos = 10 
    midPos = 5      i.e 10 - 0 /2 + 0
    midElement = 6
    
    if  ElementToSearch < midElement
        endPos = midIndex--
    so endPos = 4

    Iteration 2:
     
    startPos = 0
    endPos = 4
    midPos = 2      i.e 4 - 0 /2 + 0
    midElement = 3
    if  ElementToSearch < midElement
        endPos = midIndex--
    so endPos = 4

    Binary Search is a type of dichotomic search that operates by selecting between two distinct alternatives (dichotomies) at each step

    Split/Slice/Segment.
   
    Time Calculation:

    t(n) = c + t (n/2)  + c + c + t (n/4)  .... ( Constant time for gettting mid element and checking it)
         = c + c + .... t(n/n)              How many contants time required.
         = c log n + t(1)                   Log n times of c required.

    ============================================================================================================================================================================================================================    
    */
    public partial class SearchingAlgorithms
    {
        public void BinarySearchTest()
        {
            int[] ArrayToSort = new int[] { 11, 22, 33, 44, 55, 66 };
            int resultPosition = BinarySearchArray(ArrayToSort, 11);

            MessageBox.Show("Position of 44 in array is " + resultPosition);

        }

        public int BinarySearchArray(int[] sortedList, int elementToSearch) 
        {
            int startPosition = 0;
            int endPosition = sortedList.Length - 1;

            while (startPosition < endPosition) 
            {
                // Split the array into 2.

                //Avoids overflow exception.
                //int midIndex = ((endPosition - startPosition) / 2) +startPosition; 

                int midIndex = ((endPosition + startPosition) / 2);               
                // Get the middle element from the array.
                int midElementValue = sortedList[midIndex]; 

                // Compare with mid element in the array
                if (elementToSearch > midElementValue) 
                {
                    //Found element in right half.
                    startPosition = ++midIndex; 
                } 
                else if (elementToSearch < midElementValue) 
                {
                    //Found element in left half.
                    endPosition = --midIndex; 
                } 
                else 
                { 
                    //Found the position.
                    return midIndex; 
                } 
            }             
            return -1; 
        }

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

        // Worst case O(n log n)
        public int[] TwoSum(int[] nums, int target)
        {
            int resIndx = 0;
            int[] resArr = new int[2];

            if (nums == null || nums.Length == 0)
                return resArr;

            for (int indx = 0; indx < nums.Length; indx++)
            {
                int complement = target - nums[indx];

                resIndx = BinarySearch(nums, complement);

                if (resIndx == -1)
                    continue;

                if (indx == resIndx)
                {
                    resArr[0] = indx + 1;
                    resArr[1] = resIndx + 2;
                }
                else if (indx < resIndx)
                {
                    resArr[0] = indx + 1;
                    resArr[1] = resIndx + 1;
                }
                else
                {
                    resArr[0] = resIndx + 1;
                    resArr[1] = indx + 1;
                }

                return resArr;
            }

            return resArr;
        }

        public int BinarySearch(int[] nums, int complement)
        {
            int first = 0;
            int last = nums.Length - 1;
            int mid = 0;

            while (first <= last)
            {
                mid = (first + last) / 2;

                if (nums[mid] == complement)
                    return mid;
                else if (nums[mid] < complement)
                    first = mid + 1;
                else
                    last = mid - 1;
            }
            return -1;
        }

        // 35 Easy https://leetcode.com/problems/search-insert-position
        public int SearchInsert(int[] nums, int target)
        {
            int lIndx = 0;
            int rIndx = nums.Length - 1;

            while (lIndx <= rIndx)
            {
                int mIndx = (lIndx + rIndx) / 2;

                if (nums[mIndx] == target)
                {
                    return mIndx;
                }
                else if (nums[mIndx] > target)
                {
                    rIndx = mIndx - 1;
                }
                else
                {
                    lIndx = mIndx + 1;
                }
            }
            return lIndx;
        }
        /*TODO

    Given an array of 1s and 0s which has all 1s first followed by all 0s. Find the number of 0s. 
    Count the number of zeroes in the given array.

    Examples:
    Input: arr[] = {1, 1, 1, 1, 0, 0}
    Output: 2

    Input: arr[] = {1, 0, 0, 0, 0}
    Output: 4

    Input: arr[] = {0, 0, 0}
    Output: 3

    Input: arr[] = {1, 1, 1, 1}
    Output: 0
    http://www.geeksforgeeks.org/find-number-zeroes/
        */

    }
}