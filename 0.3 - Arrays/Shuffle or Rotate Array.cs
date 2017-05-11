using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /* E.g. If n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4]. 

    http://www.geeksforgeeks.org/block-swap-algorithm-for-array-rotation/

    Mulitple ways: https://discuss.leetcode.com/topic/9801/summary-of-c-solutions/13
    https://discuss.leetcode.com/topic/24283/a-7-line-time-o-n-in-place-solution-no-reversing
    Roate the given array in 90 degrees.    
    
    Block Swap or Juggling or Reversal or Reversing Algorithms      */
    public partial class ArraySamples
    {
        public void RotateUsing3Reverse(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k % nums.Length == 0)
                return;

            k = k % nums.Length;

            // Reverse Array from first to last.
            Reverse(nums, 0, nums.Length - 1);

            // Reverse Array from first to k.
            Reverse(nums, 0, k - 1);

            // Reverse Array from k to last.
            Reverse(nums, k, nums.Length - 1);
        }

        private void Reverse(int[] array, int first, int last)
        {
            for (int lpLeftIndx = first, lpRightIndx = last; lpLeftIndx < lpRightIndx; lpLeftIndx++, lpRightIndx--)
            {
                var temp = array[lpLeftIndx];
                array[lpLeftIndx] = array[lpRightIndx];
                array[lpRightIndx] = temp;
            }
        }
        // O(k) Space.

        public void RotateUsingKPercentSpace(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k % nums.Length == 0)
                return;

            //step each time to move
            int kPos = k % nums.Length;

            int[] tmp = new int[kPos];

            //Move from k to last elements to temp array.
            for (int lpCnt = 0; lpCnt < kPos; lpCnt++)
                tmp[lpCnt] = nums[nums.Length - kPos + lpCnt];

            //Start at k pos and traverse back to begin and fill elements from left to right.
            for (int lpCnt = nums.Length - kPos - 1; lpCnt >= 0; lpCnt--)
                nums[lpCnt + kPos] = nums[lpCnt];

            // Fetch from temp and fill elements from begin to k.
            for (int lpCnt = 0; lpCnt < kPos; lpCnt++)
                nums[lpCnt] = tmp[lpCnt];
        }

        /* E.g.nums = [1, 2, 3, 4, 5, 6, 7, 8, 9] k = 3
                The replacing process is as follow:
          Iteration When swapPos = swapDone.
                    Step 1) 1->4->7     - Result Array : 7, 2, 3, 1, 5, 6, 4, 8, 9
                    Step 2) 2->5->8     - Result Array : 7, 8, 3, 1, 2, 6, 4, 5, 9
                    Step 3) 3->6->9     - Result Array : 7, 8, 9, 1, 2, 3, 4, 5, 6 
                    
        k = k % n; Not really necessary if k is always less than n */

        public void Rotate(int[] nums, int k)
        {
            if (nums ==null || nums.Length == 0 || k % nums.Length == 0)
                return;

            int swapPos = 0;
            int nextSwap = 0;

            int tmpVal = 0;
            int val2Swap = nums[0];

            for (int lpCnt = 0; lpCnt < nums.Length; lpCnt++)
            {
                swapPos = (swapPos + k) % nums.Length;

                tmpVal = nums[swapPos];
                nums[swapPos] = val2Swap;

                if (swapPos == nextSwap)
                {
                    nextSwap++;
                    swapPos = nextSwap;
                    val2Swap = nums[swapPos];
                }
                else
                    val2Swap = tmpVal;
            }
        }
        
        // Reversing or Reversal Algorithm
        public void Rotate2(int[] nums, int k)
        {
            k %= nums.Length;
            SwapItems(nums, 0, nums.Length - 1);

            SwapItems(nums, 0, k - 1);
            SwapItems(nums, k, nums.Length - 1);
        }

        public void Rotate3ExtraSpace(int[] nums) { /*TODO*/}

        public void SwapItems(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;

                start++;
                end--;
            }
        }
    }
}