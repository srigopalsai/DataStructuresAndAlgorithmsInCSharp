using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

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

    public partial class ArrayProblems
    {
        // 66 https://leetcode.com/problems/plus-one
        public int[] PlusOne(int[] digits)
        {
            for (int indx = digits.Length - 1; indx >= 0; indx--)
            {
                if (digits[indx] < 9)
                {
                    digits[indx]++;
                    return digits;
                }

                digits[indx] = 0;
            }

            int[] newNumber = new int[digits.Length + 1];
            newNumber[0] = 1;

            return newNumber;
        }

        // https://leetcode.com/problems/merge-sorted-array
        public void Merge(int[] nums1, int nums1Indx, int[] nums2, int nums2Indx)
        {
            --nums1Indx;
            --nums2Indx;

            int indx = nums1.Length - 1; 

            while (indx >= 0)
            {
                if (nums1Indx < 0 || nums2Indx < 0)
                    break;

                if (nums1[nums1Indx] > nums2[nums2Indx])
                {
                    nums1[indx] = nums1[nums1Indx];
                    nums1Indx--;
                }
                else
                {
                    nums1[indx] = nums2[nums2Indx];
                    nums2Indx--;
                }

                indx--;
            }

            while (nums2Indx >= 0)
            {
                nums1[indx] = nums2[nums2Indx];
                nums2Indx--;
                indx--;
            }
        }
    
        // 561 Array Partition I https://leetcode.com/problems/array-partition-i

        public int ArrayPairSum(int[] nums)
        {
            int[] hashArr = new int[20001];

            foreach (int element in nums)
            {
                hashArr[element + 10000] += 1;
            }

            int maxSum = 0;
            int skipKey = 0;

            for (int indx = 0; indx < 20001; indx++)
            {
                if (hashArr[indx] == 0)
                {
                    continue;
                }

                while (hashArr[indx] != 0)
                {
                    if (skipKey % 2 == 0)
                    {
                        maxSum += (indx - 10000);
                    }

                    skipKey++;
                    hashArr[indx]--;
                }
            }

            return maxSum;
        }

        // 665 https://leetcode.com/problems/non-decreasing-array
        public bool CheckPossibility(int[] nums)
        {
            int numsCnt = 0;

            for (int indx = 1; indx < nums.Length && numsCnt <= 1; indx++)
            {
                if (nums[indx - 1] > nums[indx])
                {
                    numsCnt++;

                    if (indx - 2 < 0 || nums[indx - 2] <= nums[indx])
                    {
                        nums[indx - 1] = nums[indx];    //modify nums[i-1] of a priority
                    }
                    else
                    {
                        nums[indx] = nums[indx - 1];    //have to modify nums[i]
                    }
                }
            }

            return numsCnt <= 1;
        }

        /* E.g.nums = [1, 2, 3, 4, 5, 6, 7, 8, 9] k = 3
                The replacing process is as follow:
          Iteration When swapPos = swapDone.
                    Step 1) 1->4->7     - Result Array : 7, 2, 3, 1, 5, 6, 4, 8, 9
                    Step 2) 2->5->8     - Result Array : 7, 8, 3, 1, 2, 6, 4, 5, 9
                    Step 3) 3->6->9     - Result Array : 7, 8, 9, 1, 2, 3, 4, 5, 6 
                    
        k = k % n; Not really necessary if k is always less than n 
        189 https://leetcode.com/problems/rotate-array
        */

        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k % nums.Length == 0)
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
      
        // 532 https://leetcode.com/problems/k-diff-pairs-in-an-array
        public int FindPairs2(int[] nums, int k)
        {
            if (nums == null || nums.Length < 1 || k < 0)
            {
                return 0;
            }

            Dictionary<int, int> pairs = new Dictionary<int, int>();

            int count = 0;

            for (int indx = 0; indx < nums.Length; indx++)
            {
                int currentNum = nums[indx];

                if (k == 0 && pairs.ContainsKey(currentNum) && pairs[currentNum] == 1)
                {
                    count++;
                }
                else if (!pairs.ContainsKey(currentNum))
                {
                    if (pairs.ContainsKey(currentNum + k))
                    {
                        count++;
                    }
                    if (pairs.ContainsKey(currentNum - k))
                    {
                        count++;
                    }
                    if (!pairs.ContainsKey(currentNum))
                    {
                        pairs[currentNum] = 0;
                    }
                }

                pairs[currentNum] = pairs[currentNum] + 1;

            }
            return count;
        }

        // 581 https://leetcode.com/problems/shortest-unsorted-continuous-subarray
        public int FindUnsortedSubarray(int[] nums)
        {
            int stIndx = -1;
            int endIndx = -2;
            int nunsLen = nums.Length;
            int min = nums[nunsLen - 1];
            int max = nums[0];

            for (int indx = 1; indx < nunsLen; indx++)
            {
                max = Math.Max(max, nums[indx]);
                min = Math.Min(min, nums[nunsLen - 1 - indx]);

                if (nums[indx] < max)
                {
                    endIndx = indx;
                }
                if (nums[nunsLen - 1 - indx] > min)
                {
                    stIndx = nunsLen - 1 - indx;
                }
            }

            return endIndx - stIndx + 1;
        }

        // 605 https://leetcode.com/problems/can-place-flowers

        // K: number of flowers to plant
        // N: length of flower bed
        // DP O(K) space, O(NK) time

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            //dp[i][j]: can put j flowers in first i place, i, j starting from 1
            //dp[i][j] = 
            //          dp[i-1][j] || dp[i-2][j-1], if flower[i] == 0 
            //          dp[i-2][j], if flower[i] == 1

            // Nothing to plant
            if (n == 0)
                return true;


            // No place to plant
            if (flowerbed.Length == 0)
                return false;
            
            bool[,] dp = new bool[3, n + 1];
            dp[0,0] = true;

            //init: first cIndx flowers put into non-space
            for (int cIndx = 1; cIndx <= n; cIndx++)
            {
                dp[0, cIndx] = false;
            }

            //init: first cIndx flowers put into first space
            for (int cIndx = 1; cIndx <= n; cIndx++)
            {
                dp[1,cIndx] = cIndx == 1 && flowerbed[cIndx - 1] == 0;
            }

            //init: no flowers put into first i space
            for (int rIndx = 1; rIndx < 3; rIndx++)
            {
                dp[rIndx, 0] = true;
            }

            // DP
            for (int rIndx = 2; rIndx <= flowerbed.Length; rIndx++)
            {
                for (int cIndx = 1; cIndx <= n; cIndx++)
                {
                    if (flowerbed[rIndx - 1] == 0)
                    {
                        dp[rIndx % 3, cIndx] = dp[(rIndx - 1) % 3, cIndx] || (dp[(rIndx - 2) % 3, cIndx - 1] && flowerbed[rIndx - 2] == 0);
                    }
                    else
                    {
                        dp[rIndx % 3, cIndx] = dp[(rIndx - 2) % 3, cIndx];
                    }

                    //System.out.println(i + ":" + j + ": " + dp[i%3][j]);

                }
            }

            return dp[flowerbed.Length % 3, n];
        }

        /*
        =======================================================================================================================================================
        Find 2nd Biggest in the array.
            Brute force :

            We can keep 2 variables named 1st big and 2nd big. 
            We can iterate over the list and compare each number with the first big , if the number is greater than the first big then store it in 2nd big and update first big.
            In this brute force solution the number of comparison is O(n).
            Using heap technique it is O(n/2)
        =======================================================================================================================================================
         */

        int[] ArrayOfNums = new int[] { 1, 5, 7, 3, 6, 8, 2 };

        //Best Method : O(N/2) and O(N) Time O(2) Space.
        public int GetSecondBiggest()
        {
            if (ArrayOfNums.Length == 0)
            {
                throw new Exception("Array is empty");
            }

            int FirstBigNum = 0;
            int SecndBigNum = 0;

            // Approach 1: O (N) Comarisions.
            //for (int arrayIndx = 0; arrayIndx < ArrayOfNums.Length; arrayIndx++)
            //{
            //    //When we find current element is bigger than earlier elements, then obviously the previous big element is the 2nd biggest.
            //    if (ArrayOfNums[arrayIndx] > FirstBigNum)
            //    {
            //        SecndBigNum = FirstBigNum;
            //        FirstBigNum = ArrayOfNums[arrayIndx];
            //    }
            //}

            // Approach 2: O(N/2) Comarisions.

            for (int arrayIndx = 0; arrayIndx < ArrayOfNums.Length / 2; arrayIndx++)
            {
                int num1 = ArrayOfNums[arrayIndx * 2];
                int num2 = ArrayOfNums[arrayIndx * 2 + 1];
                if (num2 > num1)
                {
                    SecndBigNum = FirstBigNum;
                    FirstBigNum = num2;
                }
                else
                {
                    SecndBigNum = FirstBigNum;
                    FirstBigNum = num1;
                }
            }
            return SecndBigNum;
        }

        // If Sort take O(N log N) time in best, average or worst case.
        public int GetSecondBiggestInNLogNTime()
        {
            if (ArrayOfNums.Length == 0)
            {
                throw new Exception("Array is empty");
            }
            Array.Sort(ArrayOfNums);
            return ArrayOfNums[(ArrayOfNums.Length - 2)];

            //IEnumerable<int> SortedArray = ArrayOfNums.OrderBy(arrayElement => arrayElement);
            //return -1;
        }

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

        // Unsorted Array http://www.geeksforgeeks.org/find-subarray-with-given-sum/
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
                    curSum += nums[indx];
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

        // 136 Easy https://leetcode.com/problems/single-number
        public int SingleNumber(int[] nums)
        {
            int result = nums[0];

            for (int index = 1; index < nums.Length; index++)
            {
                result ^= nums[index];
            }

            return result;
        }

        // 2 * (a + b + c) - (a + a + b + b + c) = c
        public int SingleNumber2(int[] nums)
        {
            HashSet<int> hsNums = new HashSet<int>(nums);
            int fullSum = 0;

            foreach (int num in nums)
            {
                fullSum += num;
            }

            int unqSum = 0;

            foreach (int num in hsNums)
            {
                unqSum += num;
            }

            return 2 * unqSum - fullSum;
        }

        /*
===================================================================================================================================================================================================

A Pythagorean triplet consists of 3 positive integers a, b, and c, such that a^2 + b^2 = c^2. 

Such a triple is commonly written (a, b, c), and a well-known example is (3, 4, 5), (6, 8, 10)
It is derived from pythagorean theorem.
a < b < c 
a = 3, b = 4, c= 5 
9 + 16 = 25

If 'c' denotes the length of the hypotenuse and 'a' and 'b' denote the lengths of the other two sides. 
The Pythagorean theorem can be expressed as the Pythagorean equation : a^2 + b^2 = c^2, 

If the length of both 'a' and 'b' are known, then 'c' can be calculated as : c = sqrt{a^2 + b^2}. 
If the length of hypotenuse 'c' and one leg (a or b) are known, then the length of the other leg can find as : a = sqrt{c^2 - b^2}. or b = sqrt{c^2 - a^2}. 

Given an un-sorted array and a value, find if there is a triplet in array whose sum is equal to the given value. 
If there is such a triplet present in array, then print the triplet and return true. Else return false. 

E.g. if the given array is {15, 4, 11, 5, 1, 9} and given sum is 15, then there is a triplet (4, 11 and 1) present in array whose sum is 15. 

Steps:

Pre Processing  : O(n)
Search Logic    : O(n X n)

1. Take extra O(N) space HashSet.
2. Pre Process: Calculate square of each array element and store in HashSet.
    E.g. Input:     1   2   3   4   
    Pre Process     1   4   6   16
3. Repeat 2 loops with O(N X N) and Calculate sum of current array element (main index) and square of its each next element in sub loop.
===================================================================================================================================================================================================
*/
        static int[] ArrayNums = new int[] { 1, 5, 7, 3, 6, 8, 2, 4 };

        // O(N) Extra Space for Pre Processing       
        public static String FindTripletInArray()
        {
            int NoOfElements = ArrayNums.Length;
            HashSet<Int64> CSquaredArrayNums = new HashSet<long>();

            // O(N) Time for Pre processing.
            for (int lpCnt = 0; lpCnt < NoOfElements; lpCnt++)
            {
                // C square
                CSquaredArrayNums.Add(ArrayNums[lpCnt] * ArrayNums[lpCnt]);
            }

            StringBuilder resultStr = new StringBuilder();

            // O(N X N ) Time for finding the triplets.
            for (int lpMCnt = 0; lpMCnt < NoOfElements - 1; lpMCnt++)
            {
                for (int lpSubCnt = lpMCnt + 1; lpSubCnt < NoOfElements; lpSubCnt++)
                {
                    // A Squae + B Square
                    long ASqrPlsBSqr = (ArrayNums[lpMCnt] * ArrayNums[lpMCnt]) + (ArrayNums[lpSubCnt] * ArrayNums[lpSubCnt]);

                    // Best Case O (1) -> Contains
                    if (CSquaredArrayNums.Contains(ASqrPlsBSqr))
                    {
                        resultStr.Append("\n  " + ArrayNums[lpMCnt] + " Sqr  +  " + ArrayNums[lpSubCnt] + " Sqr =  " + Math.Sqrt(ASqrPlsBSqr) + " Sqr");
                    }
                }
            }

            return Convert.ToString(resultStr);
        }

        public void RemoveDuplicatesTest()
        {
            //int[] inputArray = { 1, 1, 1, 2, 3, 4, 5, 3, 6, 7, 8, 2, 6, 6, 3, 9, 9, 9, 9 };
            //int[] inputArray = { 1, 2 };
            //int[] inputArray = { 1, 1, 2 };
            int[] inputArray = { 1, 2, 3, 3, 4, 4, 4, 5, 5, 5 };

            int len = RemoveDuplicatesInPlace(inputArray);
            int[] resultArray = RemoveDuplicates(inputArray);

            string resultStr = string.Empty;

            foreach (int item in resultArray)
            {
                resultStr += item + "  ";
            }

            MessageBox.Show(resultStr);
        }

        public int[] RemoveDuplicates(int[] inputArray)
        {
            HashSet<int> distinctArray = new HashSet<int>();

            for (int lpCnt = 0; lpCnt < inputArray.Length; lpCnt++)
            {
                //Contains is O(1). Add is O(1) when items with in capacity else o(n) for recreate.
                if (distinctArray.Contains(inputArray[lpCnt]))
                    continue;

                distinctArray.Add(inputArray[lpCnt]);
            }

            //Copy back from. Remember it will create new instance, will not change the souce.
            inputArray = new int[distinctArray.Count];
            distinctArray.CopyTo(inputArray);

            return inputArray;
        }

        public int RemoveDuplicatesInPlace(int[] sortedArray)
        {
            if (sortedArray == null || sortedArray.Length == 0)
                return 0;

            int uniqueItemIndx = 1;

            for (int currIndx = 1; currIndx < sortedArray.Length; currIndx++)
            {
                // When current and previous values are same then keep moving.

                if (sortedArray[currIndx] == sortedArray[currIndx - 1])
                    continue;

                // When different value found, then capture it and move to next unique index position.

                sortedArray[uniqueItemIndx] = sortedArray[currIndx]; // NextVal;
                uniqueItemIndx++;
            }
            return uniqueItemIndx;
        }

        // Allow duplictes twice eg [0,1,1,1,1,2,2,2,3,4,5,5,6] return [0,1,1,2,2,3,4,5,5,6]
        /* for (int currIndx = 2; currIndx < sortedArray.Length; currIndx++)
            {
                if (sortedArray[currIndx] != sortedArray[uniqueItemIndx - 2])
                {
                    sortedArray[uniqueItemIndx] = sortedArray[currIndx];
                    uniqueItemIndx++;
                }
            }
        */

        public int RemoveDuplicatesInPlace1(int[] sortedArray)
        {
            if (sortedArray == null)
                return 0;

            if (sortedArray.Length < 3)
                return sortedArray.Length;

            int uniqueItemIndx = 2;

            for (int currIndx = 2; currIndx < sortedArray.Length; currIndx++)
            {
                if (sortedArray[currIndx] == sortedArray[uniqueItemIndx - 2])
                    continue;

                sortedArray[uniqueItemIndx] = sortedArray[currIndx];
                uniqueItemIndx++;
            }

            return uniqueItemIndx;
        }

        /*
===================================================================================================================================================================================================

WAP to modify the array such that arr[I] = arr[arr[I]]. 
Do this in place i.e. without using additional memory. 

E.g:
Input:  arr[] = {3, 2, 0, 1}
Output: arr[] = {1, 0, 3, 2}

Input:  arr[] = {4, 0, 2, 1, 3}
Output: arr[] = {3, 4, 2, 0, 1}

Input:  arr[] = {0, 1, 2, 3}
Output: arr[] = {0, 1, 2, 3}

1) Increase every array element arr[i] by (arr[arr[i]] % n) * n.
2) Divide every element by n.

Step1:
Every value is incremented by (arr[arr[i]] % n) * n
After first step array becomes {7, 2, 12, 9}. 

The important thing is, after the increment operation of first step, every element holds both old values and new values. 
Old value can be obtained by arr[i]%n and new value can be obtained by arr[i]/n.

Step2:
All elements are updated to new or output values by doing arr[i] = arr[i]/n.
Now, array becomes {1, 0, 3, 2}


http://www.geeksforgeeks.org/rearrange-given-array-place/

===================================================================================================================================================================================================

*/

        public static void GetArrayPositionsBasedOnItsElements()
        {
            int[] arrayElements = new int[] { 2, 3, 1, 0, 6, 5, 4 };
            int size = arrayElements.Length;

            //Step1
            for (int i = 0; i < size; i++)
            {
                arrayElements[i] += (arrayElements[arrayElements[i]] % size) * size;
            }

            //Step2
            for (int i = 0; i < size; i++)
            {
                arrayElements[i] = arrayElements[i] / size;
            }

            for (int lpCnt = 0; lpCnt < size; lpCnt++)
            {
                stringBldr.Append("\t" + arrayElements[lpCnt]);
            }
        }

        /*
===================================================================================================================================================================================================

In an integer array which contains some zeros. Move the zeros to the right side of the array with minimum number of swaps. 
The order of the original array can be destroyed.

Solution: 

 * It will take O(N) time in worst case, where there are no zeros. 
 * Best and average case it will be less than O(N/2)

 * Repeat loop from front index to rear index.
 * Consider front and rear pointers which points to front and rear elements in the array.
 * Front pointer should move from front to rear. rear pointer should move from rear to front. Based on the below conditions.
    * Increment front pointer and decrement rear pointer when front element contains zero and rear element contains non zero.
    * Increment only front pointer if it contains non zero.
    * Decrement only rear pointer if it contains zero.  

===================================================================================================================================================================================================     
*/

        /*
            * Worst case O(N-1) Time. 
            * E.g if there is only one zero at the end of the array. 
            * Front Index shoul reach n-1.
            */
        public void MoveZerosToRightInArray()
        {
            //int[] arrayElements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] arrayElements = new int[] { 0, 1, 0, 2, 3, 0, 4, 0, 5, 0 };
            int[] arrayElements = new int[] { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 };

            int frontIndex = 0;
            int rearIndex = arrayElements.Length;

            while (frontIndex < rearIndex)
            {
                if (arrayElements[frontIndex] == 0 && arrayElements[rearIndex] != 0)
                {
                    int temp = arrayElements[frontIndex];
                    arrayElements[frontIndex] = arrayElements[rearIndex];
                    arrayElements[rearIndex] = temp;

                    frontIndex++;
                    rearIndex--;
                }
                else if (arrayElements[frontIndex] != 0)
                {
                    frontIndex++;
                }
                else if (arrayElements[rearIndex] == 0)
                {
                    rearIndex--;
                }
            }
        }
    }
}