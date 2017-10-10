using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
        http://en.wikipedia.org/wiki/Array_slicing
        MSDN Notes http://msdn.microsoft.com/en-us/library/vstudio/26ts046k(v=vs.100).aspx
        C# Sample http://www.dotnetperls.com/array-slice

        var myArray = new Array(4,3,5,65);

        // Copy all but the last element of myArray
        // into newArray1.
        var newArray1 = myArray.slice(0, -1)

        // Copy only the last two elements of MyArray
        // into newArray2.
        var newArray2 = myArray.slice(-2)
        -------------------------

        http://www.sanfoundry.com/java-program-implement-vector/

        ---------------------------

         Associative array, map, symbol table, or dictionary is an abstract data type composed of a collection of (key, value) pairs, such that each possible key appears at most once in the collection.

        Operations associated with this data type:

        The addition of pairs to the collection
        The removal of pairs from the collection
        The modification of the values of existing pairs
        The lookup of the value associated with a particular key

        An e.g. By using hash table we can implement associative arrays.
        Refer Hash table example (work in progress) in 7 - Searching Techniques

        A multimap (sometimes also multihash) is a generalization of a map or associative array abstract data type in which more than one value may be associated with and returned for a given key.

        http://www.sanfoundry.com/java-program-associate-array/
---------------
        //http://en.wikipedia.org/wiki/Bit_array
        //A bit array (also known as bitmap, bitset, bit string, or bit vector) is an array data structure that compactly stores bits.
        //A bit array is effective at exploiting bit-level parallelism in hardware to perform operations quickly.
        -----------

            http://en.wikipedia.org/wiki/Dynamic_array
    A dynamic array, growable array, resizable array, dynamic table, mutable array, or array list is a random access, 
        variable-size list data structure that allows elements to be added or removed. 
    It is supplied with standard libraries in many modern mainstream programming languages.

    A dynamic array is not the same thing as a dynamically allocated array, which is a fixed-size array whose size is fixed when the array is allocated.
    Although a dynamic array may use such a fixed-size array as a back end.[1]

    function insertEnd(dynarray a, element e)
    if (a.size = a.capacity)
        // resize a to twice its current capacity:
        a.capacity ← a.capacity * 2  
        // (copy the contents to the new memory location here)
    a[a.size] ← e
    a.size ← a.size + 1
-----------------
    http://en.wikipedia.org/wiki/Judy_array
    A Judy array is a data structure that has high performance, low memory usage and implements an associative array. 
    Unlike normal arrays, Judy arrays may be sparse, that is, they may have large ranges of unassigned indices. 
    They can be used for storing and looking up values using integer or string keys. 
    The key benefits of using a Judy array is its scalability, high performance, memory efficiency and ease of use
    Drawbacks: The HP (SourceForge) implementation of Judy arrays appears to be the subject of US patent 6735595
    http://www.google.com/patents/US6735595

    Find repeated elements.
    N/2 elements are distinct.
----------------
    //http://en.wikipedia.org/wiki/Parallel_array
    //stride of an array (also referred to as increment, pitch or step size) refers to the number of locations in memory between beginnings of successive array elements, measured in bytes or in units of the size of the array's elements

--------------

    Given an Array, replace each element in the Array with its Next Element(To its RHS) which is Larger than it. If no such element exists, then no need to replace. 
    Ex: 
    i/p: {2,12,8,6,5,1,2,10,3,2} 
    o/p:{12,12,10,10,10,2,10,10,3,2}http://www.careercup.com/question?id=6311825561878528

        */

    public partial class ArraySamples
    {
        // O(n) Space http://www.geeksforgeeks.org/rearrange-array-maximum-minimum-form/

        public void ReArrange(int[] nums)
        {
            // Auxiliary array to hold modified array
            int[] tmpNums = new int[nums.Length];

            int leftIndx = 0;
            int rightIndx = nums.Length - 1;

            bool swapFlag = true;

            for (int indx = 0; indx < nums.Length; indx++)
            {
                if (swapFlag == true)
                {
                    tmpNums[indx] = nums[rightIndx--];
                }
                else
                {
                    tmpNums[indx] = nums[leftIndx++];
                }

                swapFlag = !swapFlag;
            }

            Array.Copy(tmpNums, nums, tmpNums.Length);
        }

        // O(1) Space - Use multiplication and modular trick to store two elements at an index. 
        /*
        How does expression “arr[i] += arr[maxIndx] % maxVal * maxVal” work ?
        The purpose of this expression is to store two elements at index arr[i]. 
        arr[rightIndx] is stored as multiplier and “arr[i]” is stored as remainder. 
        For example in {1 2 3 4 5 6 7 8 9}, maxVal is 10 and we store 91 at index 0. 
        With 91, we can get original element as 91 % 10 and new element as 91/10.

        http://www.geeksforgeeks.org/rearrange-array-maximum-minimum-form-set-2-o1-extra-space/
        */

        public void ReArrange1(int[] nums)
        {
            int leftIndx = 0;
            int rightIndx = nums.Length - 1;

            // Store maximum element of array + 1
            int maxVal = nums[nums.Length - 1] + 1;

            for (int indx = 0; indx < nums.Length; indx++)
            {
                // Put maximum element
                if (indx % 2 == 0)
                {
                    nums[indx] = nums[indx] + (nums[rightIndx] % maxVal) * maxVal;
                    rightIndx--;
                }

                // Put minimum element
                else
                {
                    nums[indx] = nums[indx] + (nums[leftIndx] % maxVal) * maxVal;
                    leftIndx++;
                }
            }

            for (int indx = 0; indx < nums.Length; indx++)
            {
                nums[indx] = nums[indx] / maxVal;
            }
        }

        // http://www.geeksforgeeks.org/segregate-0s-and-1s-in-an-array-by-traversing-array-once/
        public void Segregate0and1(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                while (nums[left] == 0 && left < right)
                    left++;

                while (nums[right] == 1 && left < right)
                    right--;

                // If left is smaller than right then there is a 1 at left and a 0 at right.  Exchange arr[left] and arr[right]
                if (left < right)
                {
                    nums[left] = 0;
                    nums[right] = 1;
                    left++;
                    right--;
                }
            }
        }

        // http://www.geeksforgeeks.org/find-subarray-with-given-sum/
        public bool SubArraySum(int[] nums, int targetSum)
        {
            int start = 0;
            int curSum = nums[0];

            for (int indx = 1; indx <= nums.Length; indx++)
            {
                // If curSum exceeds the sum, then remove the starting elements
                while (curSum > targetSum && start < indx - 1)
                {
                    curSum = curSum - nums[start];
                    start++;
                }

                if (curSum == targetSum)
                {
                    Console.WriteLine("Sum found between indexes " + start + " and " + (indx - 1));
                    return true;
                }

                if (indx < nums.Length)
                {
                    curSum = curSum + nums[indx];
                }
            }

            Console.WriteLine("No subarray found");
            return false;
        }

        //http://www.geeksforgeeks.org/find-maximum-sum-triplets-array-j-k-ai-aj-ak/

        // http://www.geeksforgeeks.org/count-strictly-increasing-subarrays/
        /*a sorted subarray of length ‘len’ adds len*(len-1)/2 to result. For example, {10, 20, 30, 40} adds 6 to the result.*/
        public int CountIncreasing(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int totalIncrCnt = 0; 
            int curIncrCnt = 1;

            for (int indx = 0; indx < nums.Length - 1; ++indx)
            {
                if (nums[indx + 1] > nums[indx])
                {
                    curIncrCnt++;
                }
                else
                {
                    totalIncrCnt += (((curIncrCnt - 1) * curIncrCnt) / 2);
                    curIncrCnt = 1;
                }
            }

            // If last length is more than 1
            if (curIncrCnt > 1)
            {
                totalIncrCnt += (((curIncrCnt - 1) * curIncrCnt) / 2);
            }

            return totalIncrCnt;
        }


        //http://www.geeksforgeeks.org/maximize-sum-consecutive-differences-circular-array/

        // Return the maximum Sum of difference between consecutive elements.
        static int maxSum(int[] nums)
        {
            int sum = 0;

            Array.Sort(nums);

            // Subtracting a1, a2, a3,....., a(n/2)-1, an/2 twice and adding a(n/2)+1, a(n/2)+2, a(n/2)+3,....., an - 1, an twice.
            for (int indx = 0; indx < nums.Length / 2; indx++)
            {
                sum -= (2 * nums[indx]);
                sum += (2 * nums[nums.Length - indx - 1]);
            }

            return sum;
        }

        // http://www.geeksforgeeks.org/find-a-sorted-subsequence-of-size-3-in-linear-time/
        public void find3Numbers(int[] arr)
        {
            int n = arr.Length;
            int rightMax = n - 1;
            int leftMin = 0;

            // Create an array that will store index of a smaller element on left side. 
            // If there is no smaller element on left side, then smaller[i] will be -1.

            int[] smaller = new int[n];
            smaller[0] = -1;  // first entry will always be -1

            for (int indx = 1; indx < n; indx++)
            {
                if (arr[indx] <= arr[leftMin])
                {
                    leftMin = indx;
                    smaller[indx] = -1;
                }
                else
                    smaller[indx] = leftMin;
            }

            // Create another array that will store index of a greater element on right side. 
            // If there is no greater element on right side, then greater[i] will be -1.

            int[] greater = new int[n];
            greater[n - 1] = -1;  // last entry will always be -1

            for (int indx = n - 2; indx >= 0; indx--)
            {
                if (arr[indx] >= arr[rightMax])
                {
                    rightMax = indx;
                    greater[indx] = -1;
                }
                else
                {
                    greater[indx] = rightMax;
                }
            }

            // Now find a number which has both a greater number on right side and smaller number on left side
            for (int indx = 0; indx < n; indx++)
            {
                if (smaller[indx] != -1 && greater[indx] != -1)
                {
                    Console.WriteLine(arr[smaller[indx]] + " " + arr[indx] + " " + arr[greater[indx]]);
                    return;
                }
            }

            // If we reach number, then there are no such 3 numbers
            Console.WriteLine("No such triplet found");
            return;
        }

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

        public void MoveZeroes(int[] nums)
        {
            int zeroCnt = 0;
            int temp = 0;

            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] == 0)
                {
                    zeroCnt++;
                    continue;
                }

                temp = nums[index - zeroCnt];
                nums[index - zeroCnt] = nums[index];
                nums[index] = temp;
            }
        }

        public void MoveZeroes1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return;

            int index = 0;

            foreach (int num in nums)
            {
                if (num != 0)
                    nums[index++] = num;
            }

            while (index < nums.Length)
            {
                nums[index++] = 0;
            }
        }

        // 136 https://leetcode.com/problems/single-number/description/
        public int SingleNumber(int[] nums)
        {
            int result = nums[0];

            for (int index = 1; index < nums.Length; index++)
            {
                result ^= nums[index];
            }

            return result;
        }
    }
}