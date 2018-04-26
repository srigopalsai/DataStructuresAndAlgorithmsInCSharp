using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using static DataStructuresAndAlgorithms.TestData;

namespace DataStructuresAndAlgorithms
{
    /* 
    ===================================================================================================================================================================================================
    In a given array 'A' and element 'E', find the 2 numbers of sum which is equals to the given element.

    If equals then return true, else return false.

    Time Complexity O(N) if the list is sorted.

    Refer P Verses NP for Un Sorted. Repat 2 loops and make sum with each element with next element (do same with all other elements in the list).

        https://leetcode.com/problems/subarray-sum-equals-k

    TODO: 
    Given set of n integers, each with absolute value bounded by some polynomial in n, contains three elements that sum to zero.
    http://en.wikipedia.org/wiki/3SUM

    http://en.wikipedia.org/wiki/Summed_area_table

    ===================================================================================================================================================================================================
    */
    partial class ArrayProblems
    {
        // 287 Medium https://leetcode.com/problems/find-the-duplicate-number
        public int FindDuplicate(int[] nums) //Modify Array
        {
            if (nums.Length <= 1)
                return 0;

            for (int indx = 0; indx < nums.Length; indx++)
            {
                if (nums[Math.Abs(nums[indx])] < 0)
                {
                    return Math.Abs(nums[indx]);
                }

                nums[Math.Abs(nums[indx])] *= -1;

            }

            return 0;
        }

        public int FindDuplicate2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int slPtr = nums[0];
            int fsPtr = nums[nums[0]];

            while (fsPtr != slPtr)
            {
                slPtr = nums[slPtr];
                fsPtr = nums[nums[fsPtr]];
            }

            fsPtr = 0;

            while (fsPtr != slPtr)
            {
                slPtr = nums[slPtr];
                fsPtr = nums[fsPtr];
            }

            return slPtr;
        }

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

        public class TwoSumIII
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            public void Add(int number)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number] = dict[number] + 1;
                }
                else
                {
                    dict[number] = 1;
                }
            }

            public bool Find(int sum)
            {
                foreach (int num in dict.Keys)
                {
                    if (sum - num == num)
                    {
                        if (dict[num] >= 2)
                        {
                            return true;
                        }
                    }
                    else if (dict.ContainsKey(sum - num))
                    {
                        return true;
                    }
                }

                return false;
            }

            public static void TwoSumIIITest()
            {
                TwoSumIII util = new TwoSumIII();
                util.Add(1);
                util.Add(3);
                util.Add(5);

                Console.WriteLine(util.Find(4));
                Console.WriteLine(util.Find(7));
            }
        }

        public bool IsSumOf2NumsExistsInSortedInArray(int[] sortedList, int targetEle)
        {
            //int[] sortedList = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int targetEle = 12;
            //int targetEle = 6;

            int beginPtr = 0;
            int endPtr = (sortedList.Length - 1);

            // O(N) Time
            while (beginPtr != endPtr)
            {
                int sum = sortedList[beginPtr] + sortedList[endPtr];

                if (sum == targetEle)
                {
                    return true;
                }
                else if (sum > targetEle)
                {
                    endPtr--;
                }
                else
                {
                    beginPtr++;
                }
            }
            return false;
        }

        //Worst case O(n log n). Don't recommend until we get some hybrid approach like Best Case O(log n) and Worst Case O(n) 
        public int[] TwoSum(int[] numbers, int target)
        {
            int secondNumIndex = 0;
            int[] resultArray = new int[2];

            for (int lpIndex = 0; lpIndex < numbers.Length; lpIndex++)
            {
                int complement = target - numbers[lpIndex];

                secondNumIndex = BinarySearch(numbers, complement);

                if (secondNumIndex != -1)
                {
                    if (lpIndex == secondNumIndex)
                    {
                        resultArray[0] = lpIndex + 1;
                        resultArray[1] = secondNumIndex + 2;
                    }
                    else if (lpIndex < secondNumIndex)
                    {
                        resultArray[0] = lpIndex + 1;
                        resultArray[1] = secondNumIndex + 1;
                    }
                    else
                    {
                        resultArray[0] = secondNumIndex + 1;
                        resultArray[1] = lpIndex + 1;
                    }
                    return resultArray;
                }
            }
            return resultArray;
        }

        /* 
        Time Complexity O(N) and O(n) Extra Space if the list is un-sorted.
        https://leetcode.com/problems/two-sum/
        http://en.wikipedia.org/wiki/Subset_sum_problem
        */
        public int[] IsSumOf2NumsExistsInUnSortedInArray1(int[] unSortedList, int targetNumber)
        {
            Dictionary<int, int> itemsDictionary = new Dictionary<int, int>();

            int[] result = new int[2];

            for (int i = 0; i < unSortedList.Length;)
            {
                int key = targetNumber - unSortedList[i];

                if (itemsDictionary.ContainsKey(key))
                {
                    int val = -1;
                    itemsDictionary.TryGetValue(key, out val);
                    result = new int[] { val, i };
                    return result;
                }

                ++i;

                itemsDictionary.Add(unSortedList[i], i);
            }
            return result;
        }

        public int[] IsSumOf2NumsExistsInUnSortedInArray(int[] srcArray, int target)
        {
            int[] indecisArray = { 0, 0 };

            // O(n) Space worst case.
            Dictionary<int, int> numsDictionary = new Dictionary<int, int>();

            for (int index = 0; index < srcArray.Length; index++)
            {
                int firstNumAsKey = target - srcArray[index];

                // ContainsKey() constant time.
                if (numsDictionary.ContainsKey(firstNumAsKey))
                {
                    indecisArray[1] = index;    // secondNumIndex.
                    indecisArray[0] = numsDictionary[firstNumAsKey];
                    break;
                }

                // Incase duplicates exists, skip them.            
                if (!numsDictionary.ContainsKey(srcArray[index]))
                    numsDictionary.Add(srcArray[index], index);
            }
            return indecisArray;
        }

        public bool IsSumOf2ExistsInUnSortedInArray(int[] srcArray, int target)
        {
            // O(n) Space worst case.
            Dictionary<int, int> numsDictionary = new Dictionary<int, int>();

            for (int index = 0; index < srcArray.Length; index++)
            {
                int firstNumAsKey = target - srcArray[index];

                // ContainsKey() constant time.
                if (numsDictionary.ContainsKey(firstNumAsKey))
                {
                    return true;
                }

                // Incase duplicates exists, skip them.            
                if (!numsDictionary.ContainsKey(srcArray[index]))
                    numsDictionary.Add(srcArray[index], index);
            }
            return false;
        }

        public bool IsSumOf2ExistsInUnSortedInArray1(int[] nums, int sum)
        {
            Dictionary<int, int> itemsDictionary = new Dictionary<int, int>();

            for (int indx = 0; indx < nums.Length;)
            {
                int key = sum - nums[indx];

                if (itemsDictionary.ContainsKey(key))
                {
                    int val = -1;
                    itemsDictionary.TryGetValue(key, out val);
                    return true;
                }

                ++indx;

                itemsDictionary.Add(nums[indx], indx);
            }
            return false;
        }

        public void MaximumSumPathIn2ArraysTest()
        {
            // Demo 1 - Output 35
            int[] array1 = new int[] { 2, 3, 7, 10, 12 };
            int[] array2 = new int[] { 1, 5, 7, 08 };

            int resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 1 : " + resultSum);

            // Demo 2 - Output 22
            array1 = new int[] { 10, 12 };
            array2 = new int[] { 05, 07, 09 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 2 : " + resultSum);

            // Demo 3 - Output 122
            array1 = new int[] { 2, 3, 7, 10, 12, 15, 30, 34 };
            array2 = new int[] { 1, 5, 7, 08, 10, 15, 16, 19 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 3 : " + resultSum);

            // Demo 4 - Output 33
            array1 = new int[] { 5, 6, 9, 10 };
            array2 = new int[] { 1, 2, 5, 10 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 4 : " + resultSum);

            // Demo 4 - Output 43
            array1 = new int[] { 5, 6, 9, 10 };
            array2 = new int[] { 1, 2, 5, 10, 10 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 4 : " + resultSum);
        }

        private int MaximumSumPathIn2Arrays(int[] array1, int[] array2)
        {
            int ar1LpCnt = 0;
            int ar2LpCnt = 0;

            int ar1Sum = 0;
            int ar2Sum = 0;

            int maxSum = 0;

            while (ar1LpCnt < array1.Length && ar2LpCnt < array2.Length)
            {
                if (array1[ar1LpCnt] < array2[ar2LpCnt])
                {
                    ar1Sum += array1[ar1LpCnt];
                    ar1LpCnt++;
                }
                else if (array1[ar1LpCnt] > array2[ar2LpCnt])
                {
                    ar2Sum += array2[ar2LpCnt];
                    ar2LpCnt++;
                }
                // Both elements are same         
                else
                {
                    //Reset sums.
                    ar1Sum = 0;
                    ar2Sum = 0;

                    maxSum = Math.Max(ar1Sum, ar2Sum);

                    while (array1[ar1LpCnt] == array2[ar2LpCnt] && ar1LpCnt < array1.Length && ar2LpCnt < array2.Length)
                    {
                        maxSum += array1[ar1LpCnt];
                        ar1LpCnt++;
                        ar2LpCnt++;
                    }
                }
            }

            ar1Sum = 0;
            ar2Sum = 0;

            while (ar1LpCnt < array1.Length)
            {
                ar1Sum += array1[ar1LpCnt];
                ar1LpCnt++;
            }

            while (ar2LpCnt < array2.Length)
            {
                ar2Sum += array2[ar2LpCnt];
                ar2LpCnt++;
            }

            maxSum += Math.Max(ar1Sum, ar2Sum);

            return maxSum;
        }

        /*
===================================================================================================================================================================================================

A number in the array is called local minima if it is smaller than both its left and right numbers.
Note: In an array of unique integers first two numbers are decreasing and last two numbers are increasing there ought to be a local minima.

E.g. In an array 9,7,2,8,5,6,3,4      First two numbers are decreasing and last 2 numbers are increasing. 
From the E.g. 2, 5 

Solution: Use Devide and conquor method and time complexity is O(log n)

===================================================================================================================================================================================================  
*/
        public static int FindLocalMinima()
        {
            int[] arrayElements = new int[] { 9, 7, 2, 8, 5, 6, 3, 4 };

            int frontPos = 0;
            int rearPos = arrayElements.Length;

            while (frontPos < rearPos)
            {
                int midPos = (rearPos + frontPos) / 2;
                if (midPos < 0 && (midPos + 1) >= arrayElements.Length)
                {
                    //Loop reached extream and couldnt fine any, so retun -1;
                    return -1;
                }
                //                if (arrayElements[midPos - 2] > arrayElements[midPos-1] && arrayElements[midPos-1] < arrayElements[midPos])
                if (arrayElements[midPos - 1] > arrayElements[midPos] && arrayElements[midPos] < arrayElements[midPos + 1])
                {
                    return arrayElements[midPos];
                }

                if (arrayElements[midPos] > arrayElements[midPos - 1])
                {
                    rearPos = midPos;
                }
                else
                {
                    frontPos = midPos;
                }
            }
            return -1;
        }

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
Kadane’s Algorithm:
Initialize:
    max_so_far = 0
    max_ending_here = 0

Loop for each element of the array
  (a) max_ending_here = max_ending_here + a[i]
  (b) if(max_ending_here < 0)
            max_ending_here = 0
  (c) if(max_so_far < max_ending_here)
            max_so_far = max_ending_here
return max_so_far

Idea of the Kadane's algorithm is to look for all positive contiguous segments of the array 
(max_ending_here is used for this). 
And keep track of maximum sum contiguous segment among all positive segments (max_so_far is used for this). 
Each time we get a positive sum compare it with max_so_far and update max_so_far if it is greater than max_so_far
http://en.wikipedia.org/wiki/Maximum_subarray_problem
http://analgorithmist.blogspot.com/2012/09/maximum-subarray-problem-kadanes.html
http://analgorithmist.blogspot.com/2012/10/applying-kadanes-algorithm-to-2-d-array.html
Apply Selction algorithm. http://en.wikipedia.org/wiki/Selection_algorithm

http://www.geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value/

Difference between big endian and little endian

http://www.geeksforgeeks.org/google-mountain-view-interview/

===================================================================================================================================================================================================
*/

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

            int middlePos = leftPos + ((rightPos - leftPos) / 2);

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

        // 162 Medium https://leetcode.com/problems/find-peak-element
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

        // 729 Medium https://leetcode.com/problems/my-calendar-i/
        public class MyCalendar
        {
            Dictionary<int, int> bookings = new Dictionary<int, int>();

            public bool Book(int start, int end)
            {
                if (start > end)
                    return false;

                foreach (KeyValuePair<int, int> kvp in bookings)
                {
                    if (start >= kvp.Key && start < kvp.Value)
                        return false;

                    //if(end > kvp.Key && end <= kvp.Value)
                    //  return false;

                    if (start <= kvp.Key && end > kvp.Key)
                        return false;
                }

                bookings.Add(start, end);
                return true;
            }
        }

        public class MyCalendar2
        {
            public struct Interval
            {
                public int Start;
                public int End;

                public Interval(int start, int end)
                {
                    Start = start;
                    End = end;
                }
            }

            List<Interval> bookings;

            public MyCalendar2()
            {
                bookings = new List<Interval>();
            }

            public int BinSearchInsertPos(List<Interval> bookings, int start)
            {
                int lIndx = 0;
                int rIndx = bookings.Count - 1;

                while (lIndx <= rIndx)
                {
                    int mid = (lIndx + rIndx) / 2;

                    if (bookings[mid].Start == start)
                        return -1;

                    if (bookings[mid].Start < start)
                        lIndx = mid + 1;
                    else
                        rIndx = mid - 1;
                }

                return lIndx;
            }

            // First we find an insert position using binary search according to the start point of the interval
            // Then we compare the end point of the previous one (if exists) with the start point of the new one and
            // we compare the end point of the new one with the start point of the next one (if exists)
            // If it is suitable we insert it to the list and return true, otherwise we return false
            // After each call of the funciton the list stays sorted according to the start points of the intervals
            public bool Book(int start, int end)
            {
                Interval interval = new Interval(start, end - 1);
                int position = 0;
                if (bookings.Count > 0)
                {
                    position = BinSearchInsertPos(bookings, start);

                    if (position == -1) //if start point exists we cannot insert it to the list
                        return false;

                    if (position <= bookings.Count - 1 && interval.End >= bookings[position].Start)
                        return false;

                    if (position >= 1 && bookings[position - 1].End >= interval.Start)
                        return false;
                }

                bookings.Insert(position, interval);
                return true;
            }
        }

        // 731 WIP Medium https://leetcode.com/problems/my-calendar-ii
        public class MyCalendarTwo
        {
            public struct Interval
            {
                public int Start;
                public int End;
                public bool IsOverride;

                public Interval(int start, int end, bool isOverride)
                {
                    Start = start;
                    End = end;
                    IsOverride = isOverride;
                }
            }

            List<Interval> bkList = new List<Interval>();

            public bool Book(int start, int end)
            {
                if (start > end)
                    return false;

                foreach (Interval interval in bkList)
                {
                    if (start >= interval.Start && start < interval.End && interval.IsOverride == true)
                        return false;

                    //if(end > kvp.Key && end <= kvp.Value)
                    //  return false;

                    if (interval.Start > start && interval.Start <= end && interval.IsOverride == true)
                        return false;
                }

                bool foundOL = false;

                for (int indx = 0; indx < bkList.Count; indx++)
                {
                    Interval interval = bkList[indx];

                    if (start >= bkList[indx].Start && start < bkList[indx].End)
                    {
                        interval.IsOverride = true;
                        foundOL = true;
                    }

                    if (start > bkList[indx].Start && start <= bkList[indx].End && bkList[indx].IsOverride == true)
                    {
                        interval.IsOverride = true;
                        foundOL = true;
                    }
                }

                bkList.Add(new Interval(start, end, foundOL));
                return true;
            }
        }

        // 75 Medium https://leetcode.com/problems/Sort-Colors

        public void SortColors(int[] nums)
        {
            int n = nums.Length;

            int indx0 = 0;
            int indx2 = n - 1;

            for (int indx = 0; indx <= indx2; indx++)
            {
                while (nums[indx] == 2 && indx < indx2)
                {
                    Common.Swap(ref nums[indx], ref nums[indx2--]);
                }

                while (nums[indx] == 0 && indx > indx0)
                {
                    Common.Swap(ref nums[indx], ref nums[indx0++]);
                }
            }
        }

        // https://leetcode.com/problems/3sum
        // Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? 
        // Find all unique triplets in the array which gives the sum of zero.
        // Note:
        // The solution set must not contain duplicate triplets.

        // Example:
        // Given array nums = [-1, 0, 1, 2, -1, -4],           
        // A solution set is:
        // [
        //     [-1, 0, 1],
        //     [-1, -1, 2]
        // ]
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (nums == null || nums.Length == 0)
                return res;

            Array.Sort(nums);

            for (int p1 = 0; p1 < nums.Length; p1++)
            {
                if (p1 - 1 >= 0 && nums[p1] == nums[p1 - 1])
                {
                    continue;// Skip equal elements to avoid duplicates
                }

                int p2 = p1 + 1;
                int p3 = nums.Length - 1;

                while (p2 < p3)
                {
                    // Two Pointers
                    int sum = nums[p1] + nums[p2] + nums[p3];

                    if (sum == 0)
                    {
                        res.Add( new List<int>() { nums[p1], nums[p2], nums[p3] });

                        while (p2 + 1 < p3 && nums[p2] == nums[p2 + 1])// Skip equal elements to avoid duplicates
                        {
                            p2++;
                        }

                        while (p3 - 1 > p2 && nums[p3] == nums[p3 - 1])// Skip equal elements to avoid duplicates
                        {
                            p3--;
                        }

                        p2++;
                        p3--;
                    }
                    else if (sum < 0)
                    {
                        p2++;
                    }
                    else
                    {
                        p3--;
                    }
                }
            }
            return res;
        }

        // https://leetcode.com/problems/3sum-closest
        // Given an array nums of n integers and an integer target, find three integers in nums such that the sum is closest to target.
        // Return the sum of the three integers.You may assume that each input would have exactly one solution.
        // Example:
        // Given array nums = [-1, 2, 1, -4], and target = 1.
        // The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
        public int ThreeSumClosest(int[] nums, int target)
        {
            int MAX_VALUE = int.MaxValue;

            if (nums.Length < 3)
                return 0;

            Array.Sort(nums);

            int minDiff = MAX_VALUE;

            int p2;
            int p3;
            int curSum;
            int result = 0;

            for (int p1 = 0; p1 < nums.Length - 2; p1++)
            {
                p2 = p1 + 1;
                p3 = nums.Length - 1;

                while (p2 < p3)
                {
                    curSum = nums[p1] + nums[p2] + nums[p3];

                    if (curSum == target)
                    {
                        return curSum;
                    }

                    if (minDiff > Math.Abs(curSum - target))
                    {
                        minDiff = Math.Abs(curSum - target);
                        result = curSum;
                    }
                    
                    if (curSum > target)
                    {
                        p3--;
                    }
                    else
                    {
                        p2++;
                    }
                }

                while (nums[p1 + 1] == nums[p1])
                {
                    p1++;
                }
            }

            return result;
        }
    }
}