using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public partial class ArraySamples
    {
        /*  Given a non-empty integer array of size n, find the minimum number of moves required to make all array elements equal, 
			where a move is incrementing n - 1 elements by 1.

			E.g.	Input:	[1,2,3]
					Output:	3

			Explanation:	Only three moves are needed (remember each move increments two elements):
							[1,2,3]  =>  [2,3,3]  =>  [3,4,3]  =>  [4,4,4]      */
        public int MinMoves(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int minVal = int.MaxValue;

            for (int lpCnt = 0; lpCnt < nums.Length; lpCnt++)
                if (nums[lpCnt] < minVal)
                    minVal = nums[lpCnt];

            int sumVal = 0;
            for (int lpCnt = 0; lpCnt < nums.Length; lpCnt++)
                sumVal = sumVal + nums[lpCnt];

            return sumVal - (minVal * nums.Length);
        }

        /*  Given a non-empty integer array, find the minimum number of moves required to make all array elements equal, 
               where a move is incrementing a selected element by 1 or decrementing a selected element by 1.

            E.g. Only two moves are needed (remember each move increments or decrements one element):
            [1,2,3]  =>  [2,2,3]  =>  [2,2,2]   */

        public int MinMoves2(int[] nums)
        {
            if (nums == null | nums.Length == 0)
                return 0;

            Array.Sort(nums);

            int medium = nums[nums.Length / 2];

            int minMovesCnt = 0;
            foreach (int num in nums)
                minMovesCnt += Math.Abs(num - medium);

            return minMovesCnt;
        }

        /*  Given an array of n integers where n > 1, nums, 
            return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

            E.g. nums = [1,2,3,4], return [24,12,8,6].              Solve it without division and in O(n).  

            Note if we do sum and divide it by each array element then these will fail  Input: [1,0] Output: [0,0] Input: [1,1]  Output: [2, 2] */
        /*  Solution:
            Given numbers [2, 3, 4, 5], regarding the third number 4, the product of array except 4 is 2*3*5 which consists of two parts: left 2*3 and right 5. 
            The product is left*right. We can get lefts and rights:
                Numbers:     2    3    4     5
                Lefts:            2  2*3 2*3*4
                Rights:  3*4*5  4*5    5      

                Let’s fill the empty with 1:
                Numbers:     2    3    4     5
                Lefts:       1    2  2*3 2*3*4
                Rights:  3*4*5  4*5    5     1

            We can calculate lefts and rights in 2 loops. The time complexity is O(n).
            We store lefts in result array. If we allocate a new array for rights. The space complexity is O(n). 
            To make it O(1), we just need to store it in a variable which is right  
            http://stackoverflow.com/questions/2680548/given-an-array-of-numbers-return-array-of-products-of-all-other-numbers-no-div        */

        public int[] ProductExceptSelf(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            int arrayLen = nums.Length;
            int[] outputArr = new int[arrayLen];
            outputArr[0] = 1;

            // Calculate left part product and store in output.
            for (int lpCnt = 1; lpCnt < arrayLen; lpCnt++)
                outputArr[lpCnt] = outputArr[lpCnt - 1] * nums[lpCnt - 1];

            int rightPartProduct = 1;

            // Calculate right part product and store it in tempRight first and use it cumulative way.
            for (int lpCnt = arrayLen - 1; lpCnt >= 0; lpCnt--)
            {
                outputArr[lpCnt] = outputArr[lpCnt] * rightPartProduct;
                rightPartProduct = nums[lpCnt] * rightPartProduct;
            }

            return outputArr;
        }
    }
}