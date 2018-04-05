using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
   
    ===================================================================================================================================================================================================

    A given array contains series of N numbers from 1 to N in un-sorted order. 
    And only one number is missing and it is replaced with zero. Find the missing number.

    Find the missing number and the repeated number.

    E.g. 1    3   5   2   7   0   8   10  9   4
    Missing Number is 6
        
        Get the array elements sum and subtract it from actual sum.

    Note: Use arithmetic progression to find the sum of numbers in O(1) Constant time.  n * (n1 + n) / 2

    http://en.wikipedia.org/wiki/Arithmetic_progression
    http://www.careercup.com/question?id=6228501199847424
    
    http://stackoverflow.com/questions/3492302/easy-interview-question-got-harder-given-numbers-1-100-find-the-missing-numbe?rq=1
    http://books.google.com/books?id=415loiMd_c0C&lpg=PP1&dq=muthukrishnan%20data%20stream%20algorithms&hl=el&pg=PA1#v=onepage&q=muthukrishnan%20data%20stream%20algorithms&f=false

    TODO:
    Given a list of 'N' values and we know that a particular value occurs more than 'N/2' times, we need to determine that maximum occurring value.
    https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
    Linear Time Majority Vote Algorithm http://www.cs.utexas.edu/~moore/best-ideas/mjrty/index.html
    http://stackoverflow.com/questions/31254347/a-beautiful-algorithm-boyer-moore-voting-algorithm-does-anyone-know-similar
    
    ===================================================================================================================================================================================================
    */
    partial class ArrayProblems 
    {
        // 35 https://leetcode.com/problems/search-insert-position
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

        // https://leetcode.com/problems/first-bad-version
        public int BinarySearch(int[] nums, int noToFind)
        {
            int leftIndx = 0;
            int rightIndx = nums.Length - 1;
            int midIndx = 0;

            while (leftIndx <= rightIndx)
            {
                midIndx = (leftIndx + rightIndx) / 2;

                if (nums[midIndx] == noToFind)
                {
                    return midIndx;
                }
                else if (nums[midIndx] < noToFind)
                {
                    leftIndx = midIndx + 1;
                }
                else
                {
                    rightIndx = midIndx - 1;
                }
            }

            return -1;
        }

        // Easy 169 Moore Voting Algorithm https://leetcode.com/problems/majority-element
        // https://en.wikipedia.org/wiki/Boyer–Moore_majority_vote_algorithm
        public int MajorityElement(int[] num)
        {
            int major = num[0];
            int count = 1;

            for (int indx = 1; indx < num.Length; indx++)
            {
                if (count == 0)
                {
                    count++;
                    major = num[indx];
                }
                else if (major == num[indx])
                {
                    count++;
                }
                else
                    count--;
            }
            return major;
        }

        // Medium 81 https://leetcode.com/problems/majority-element-ii
        // Max 2 numbers can be repeated n/3 times in n.
        public List<int> MajorityElement2(int[] nums)
        {
            List<int> majList = new List<int>();

            if (nums == null || nums.Length == 0)
            {
                return majList;
            }

            int num1 = nums[0];
            int num2 = nums[0];
            int n1Cnt = 1;
            int n2Cnt = 0;

            foreach (int val in nums)
            {
                if (n1Cnt == 0)
                {
                    num1 = val;
                }
                if (n2Cnt == 0)
                {
                    num2 = val;
                }

                if (val == num1)
                {
                    n1Cnt++;
                }
                else if (val == num2)
                {
                    n2Cnt++;
                }
                else
                {
                    n1Cnt--;
                    n2Cnt--;
                }
            }

            n1Cnt = 0;
            n2Cnt = 0;

            // Get full count of each number.
            foreach (int val in nums)
            {
                if (val == num1)
                {
                    n1Cnt++;
                }
                else if (val == num2)
                {
                    n2Cnt++;
                }
            }

            // Ensure the found numbers are really Len/3
            if (n1Cnt > nums.Length / 3)
            {
                majList.Add(num1);
            }

            if (n2Cnt > nums.Length / 3)
            {
                majList.Add(num2);
            }

            return majList;
        }
        
        // 643 https://leetcode.com/problems/maximum-average-subarray-i
        public double FindMaxAverage(int[] nums, int k)
        {
            long sumVal = 0;

            for (int indx = 0; indx < k; indx++)
            {
                sumVal += nums[indx];
            }

            long maxAvg = sumVal;

            for (int indx = k; indx < nums.Length; indx++)
            {
                sumVal += nums[indx] - nums[indx - k];
                maxAvg = Math.Max(maxAvg, sumVal);
            }

            return maxAvg / 1.0 / k;
        }

        public static void FindMissingNumberInArray()
        {
            int[] inputArr = { 1, 3, 5, 2, 7, 0, 8, 10, 9, 4 };

            int arrayLen = inputArr.Length;
            int arraySum = 0;

            // O (N) Logic
            for (int lpCnt = 0; lpCnt < arrayLen; lpCnt++)
            {
                arraySum += inputArr[lpCnt];
            }
                     
            // O (N/2) Logic by using heap technique. May not be effcient for small blocks.

            //int num1 = 0;
            //int num2 = 0;
            //int Child1Idx = 0;
            //int Child2Idx = 0;

            //for (int lpCnt = 0; lpCnt < arrayLen/2; lpCnt++)
            //{
            //    Child1Idx = lpCnt * 2;
            //    Child2Idx = Child1Idx + 1;

            //    num1 = inputArr[Child1Idx];
            //    num2 = inputArr[Child2Idx];

            //    arraySum += num1 + num2;
            //}

            //Using arithmatic progression logic to find actual sum.
            int actualSum = 10 * (1 + 10) / 2;
            int missingNum = actualSum - arraySum;

            MessageBox.Show("Missing number is " + missingNum);
        }

        public static void FindMissingAndRepeatedNumbersInArray()
        {
            IDictionary HashtableObj = new Hashtable();
            int[] inputArr = { 1, 3, 5, 2, 7, 3, 8, 10, 9, 4 };

            int arrayLen = inputArr.Length;
            int arraySum = 0;
            int repeatedNum = 0;

            for (int lpCnt = 0; lpCnt < arrayLen; lpCnt++)
            {
                arraySum += inputArr[lpCnt];

                if (!HashtableObj.Contains(inputArr[lpCnt]))
                {
                    HashtableObj.Add(inputArr[lpCnt], inputArr[lpCnt]);
                }
                else
                {
                    repeatedNum = inputArr[lpCnt];
                }
            }

            //Using arithmatic progression logic to find actual sum. And remove the repeated number
            float actualSum = 10 * (1 + 10) / 2;
            float missingNum = actualSum - (arraySum - repeatedNum);

            MessageBox.Show("Missing Number is " + missingNum + Environment.NewLine + "Repeated Number is " + repeatedNum);
        }

        /*
        // 448 https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/discuss/
        Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

        Find all the elements of [1, n] inclusive that do not appear in this array.
        Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.

        E.g.    Input:  [4,3,2,7,8,2,3,1]
                Output: [5,6]  */
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> missingNums = new List<int>();

            if (nums == null || nums.Length == 0)
                return missingNums;

            // Visit array index positions based on the values and mark them as inverse (negative values). 
            // The index positions which doesn't have negatvie values are missing one's.

            for (int index = 0; index < nums.Length; index++)
            {
                // Use Math.Abs so that we get positve number for the numbers which are already visited and marked as negative.
                int absVal = Math.Abs(nums[index]) - 1;

                if (nums[absVal] > 0)
                    nums[absVal] = -nums[absVal];
            }

            //Now findout the positive numbers and consider their index + 1 as the missing numbers.
            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] > 0)
                    missingNums.Add(index + 1);
            }

            return missingNums;
        }

        // 217 Contains Duplicates https://leetcode.com/problems/contains-duplicate/discuss/
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> numsSet = new HashSet<int>();

            foreach (int num in nums)
            {
                if (numsSet.Contains(num))
                    return true;

                numsSet.Add(num);
            }

            return false;
        }

        // 219 https://leetcode.com/problems/contains-duplicate-ii
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            HashSet<int> hashSet = new HashSet<int>();

            for (int indx = 0; indx < nums.Length; indx++)
            {
                if (indx > k)
                {
                    hashSet.Remove(nums[indx - k - 1]);
                }

                if (!hashSet.Add(nums[indx]))
                {
                    return true;
                }
            }
            return false;
        }

        // https://leetcode.com/problems/contains-duplicate-iii
        // Failing to be fixed.
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || nums.Length == 0 || k <= 0)
                return false;

            SortedSet<int> values = new SortedSet<int>();

            for (int ind = 0; ind < nums.Length; ind++)
            {
                int floor = values.LastOrDefault(item => item <= nums[ind] + t);
                int ceil = values.FirstOrDefault(item => item >= nums[ind] - t);

                if (floor >= nums[ind] || ceil <= nums[ind])
                {
                    return true;
                }

                values.Add(nums[ind]);

                if (ind >= k)
                {
                    values.Remove(nums[ind - k]);
                }
            }

            return false;
        }

        /*
===================================================================================================================================================================================================
Problem:

Given an array of natural numbers from 1 to n in an array where two numbers are missing. 
So the given array size is n-2. 
We have to find the two missing numbers.
E.g. Numbers are 1..10 and 3,4 are missing. So Array length is 8. 

Solution :

1. Use extra O(n) Calculate the sum of n-2 numbers and sum of the n-2 numbers squared in one iteration. 

As we know the  sum of all numbers from 1 to n is n * ( n + 1 ) / 2. 
And the sum of all numbers squared from 1 to n is n * ( n + 1 ) * ( 2n + 1 ) / 6. 

So we can find the sum and squared sum of the missing number by subtracting it from total sum and squared sum of n numbers. 

So now we know a + b and a^2 + b^2. 

From this we can calculate a and b, the two missing numbers.

===================================================================================================================================================================================================
*/
        public void GetTwoMissingNumbersTest()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 10; ++i)
            {
                list.Add(i);
            }

            list.Remove(3);
            list.Remove(4);

            int[] missing = GetTwoMissingNumbers(list);
            MessageBox.Show("Missing Number : " + missing[0] + "," + missing[1]);
        }

        private int[] GetTwoMissingNumbers(List<int> list)
        {
            int n = list.Count + 2;

            int actualExpectedSum = n * (n + 1) / 2;
            int actualExpectedSquaredSum = n * (n + 1) * (2 * n + 1) / 6;

            int currentSum = 0;
            int currentSquaredSum = 0;

            foreach (int num in list)
            {
                currentSum += num;
                currentSquaredSum += num * num;
            }

            int APlusBSum = actualExpectedSum - currentSum;
            int ASquarePlusBSquareSum = actualExpectedSquaredSum - currentSquaredSum;

            int TwoMultipleAB = APlusBSum * APlusBSum - ASquarePlusBSquareSum;

            int AminusB = (int)Math.Sqrt(ASquarePlusBSquareSum - TwoMultipleAB);

            int missinNum1 = (APlusBSum + AminusB) / 2;
            int missingNum2 = (APlusBSum - AminusB) / 2;

            return new int[] { missinNum1, missingNum2 };
        }

        /*
        ===================================================================================================================================================================================================

        Given an array of integers where each element represents the max number of steps that can be made forward from that element. 
        Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element). 
        If an element is 0, then cannot move through that element.

        Input: arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
        Output: 3 (1-> 3 -> 8 ->9)

        First element is 1, so can only go to 3. Second element is 3, so can make at most 3 steps eg to 5 or 8 or 9.

        References :
        http://stackoverflow.com/questions/23301358/linear-time-algorithm-for-minimum-number-of-jumps-required-to-reach-end

        ===================================================================================================================================================================================================
        */

        static StringBuilder stringBldr = new StringBuilder();
        public void MinimumNumberOfJumpsToReachEndTest()
        {
            //int[] arr = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9};
            int[] arr = { 1, 1, 2, 3, 1, 4 };

            stringBldr.Clear();
            stringBldr.AppendLine("Source Array");

            for (int lpCnt = 0; lpCnt < arr.Length; lpCnt++)
            {
                stringBldr.Append("  " + arr[lpCnt]);
            }
            stringBldr.AppendLine(" No of Jums : ");

            //MinimumNumberOfJumpsToReachEnd(arr, 0, arr.Length);
            int rslt = min_jumps(arr, arr.Length);
            MessageBox.Show(stringBldr.ToString() + rslt);
        }

        int min_jumps(int[] a, int size)
        {
            int lnrLpIndex = 0;
            int jmpLpIndex = 0;

            int max = 0;
            int totalJumpCount = 0;

            while (lnrLpIndex < size)
            {
                totalJumpCount++;
                max = 0;

                for (jmpLpIndex = 0; jmpLpIndex < a[lnrLpIndex]; jmpLpIndex++)
                {
                    int maxVal = jmpLpIndex + a[jmpLpIndex];

                    if (max < maxVal)
                    {
                        max = maxVal;
                        //stringBldr.Append("  " +max);
                    }
                }
                if (max == 0)
                {
                    return Int32.MaxValue;
                }
                stringBldr.Append("  " + max);
                lnrLpIndex = lnrLpIndex + max;
            }
            return totalJumpCount;
        }

        // Returns minimum number of jumps to reach arr[h] from arr[l]
        public int MinimumNumberOfJumpsToReachEnd(int[] arr, int frontIndx, int rearIndx)
        {
            // Base case: when source and destination are same
            if (rearIndx == frontIndx)
            {
                return 0;
            }

            // When nothing is reachable from the given source
            if (arr[frontIndx] == 0)
            {
                return Int32.MaxValue;
            }

            // Traverse through all the points reachable from arr[l]. 
            // Recursively get the minimum number of jumps needed to reach arr[h] from these reachable points.
            int min = Int32.MaxValue;

            for (int lpCnt = frontIndx + 1; lpCnt <= rearIndx && (lpCnt <= (frontIndx + arr[frontIndx])); lpCnt++)
            {
                // Recursive 
                int jumps = MinimumNumberOfJumpsToReachEnd(arr, lpCnt, rearIndx);

                if (jumps != Int32.MaxValue && jumps + 1 < min)
                {
                    min = jumps + 1;
                }
            }

            stringBldr.Append("  " + min);
            return min;
        }

        //        int find_min_steps(int arr[], int n)
        //{
        //  // min_steps_dp[i] is an array which 
        //  // indicate minimum jumps required to reach i. 
        //  int min_steps_dp[20];
        //  int i, temp, next_vacant;
        //  // next_vacant : Is the index in the array whose min_steps needs to be updated
        //  // in the next iteration.
        //  next_vacant = 1;
        //  for(i=0;i<n;min_steps_dp[i++] = 500);
        //  // Minimum steps required to reach index 0 is 0
        //  min_steps_dp[0]  = 0;
        //  for(i=0;i<n && min_steps_dp[n-1] == 500;i++)
        //  {
        //    temp = i + arr[i];
        //    printf(" temp : %d i: %d arr: %d\n",temp,i,arr[i]);
        //    if(temp >= n)
        //    {
        //      min_steps_dp[n-1] = min(min_steps_dp[n-1], min_steps_dp[i] +1);
        //    }
        //    else
        //    {
        //      min_steps_dp[temp] = min(min_steps_dp[temp], min_steps_dp[i]+1);
        //    }
        //    if(temp>next_vacant)
        //    {
        //      for(;next_vacant<temp;next_vacant++)
        //      {
        //      // this loop executes only ONCE for each element in the array, so over the
        //      // course of execution, is an O(n) loop only. The order of the outer loop still
        //      // remains O(n).
        //        min_steps_dp[next_vacant] = min(min_steps_dp[next_vacant],min_steps_dp[temp]);
        //      }
        //    }
        //  }
        //  for(i=0;i<n;i++)
        //  {
        //    printf("%d ",min_steps_dp[i]);
        //  }
        //  return min_steps_dp[n-1];

        //}
        //main()
        //{
        //  int arr[] = {1,3,5,8,9,2,6,7,6,8,9};
        //  int len;
        //  len = sizeof(arr)/sizeof(arr[0]);
        //  printf("\n MIN steps : %d\n",find_min_steps(arr,len));
        //}

        // Easy 414. https://leetcode.com/problems/third-maximum-number
        public int ThirdMax(int[] nums)
        {
            int? max1st = null;
            int? max2nd = null;
            int? max3rd = null;

            foreach (int num in nums)
            {
                if (num == max1st || num == max2nd || num == max3rd)
                {
                    continue;
                }

                if (max1st == null || num > max1st)
                {
                    max3rd = max2nd;
                    max2nd = max1st;
                    max1st = num;
                }
                else if (max2nd == null || num > max2nd)
                {
                    max3rd = max2nd;
                    max2nd = num;
                }
                else if (max3rd == null || num > max3rd)
                {
                    max3rd = num;
                }
            }

            return max3rd == null ? (int)max1st : (int)max3rd;
        }

        public int ThirdMax2(int[] nums)
        {
            long max1st = long.MinValue;
            long max2nd = long.MinValue;
            long max3rd = long.MinValue;

            foreach (int num in nums)
            {
                if (num > max1st)
                {
                    max3rd = max2nd;
                    max2nd = max1st;
                    max1st = num;
                }
                else if (num == max1st)
                {
                    continue;
                }
                else if (num > max2nd)
                {
                    max3rd = max2nd;
                    max2nd = num;
                }
                else if (num == max2nd)
                {
                    continue;
                }
                else if (num > max3rd)
                {
                    max3rd = num;
                }
            }

            return max3rd == long.MinValue ? (int)max1st : (int)max3rd;
        }

        // 485 Easy https://leetcode.com/problems/max-consecutive-ones
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int maxCnt = 0;
            int curCnt = 0;

            foreach (int num in nums)
            {
                if (num == 1)
                {
                    curCnt++;
                }
                else
                {
                    curCnt = 0;
                }

                if (maxCnt < curCnt)
                {
                    maxCnt = curCnt;
                }
            }

            return maxCnt;
        }

        // 268 Easy https://leetcode.com/problems/missing-number
        // Gauss Formula
        public int MissingNumber(int[] nums)
        {
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            int totalSum = nums.Length * (nums.Length + 1) / 2;
            int missingNum = totalSum - sum;

            return missingNum;
        }

        public int MissingNumber2(int[] nums)
        {
            int indx;
            int diff = 0;

            for (indx = 0; indx < nums.Length; ++indx)
            {
                diff += indx - nums[indx];
            }

            return diff + indx;
        }
    }
}