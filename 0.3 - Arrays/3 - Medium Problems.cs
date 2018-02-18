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

        https://leetcode.com/problems/subarray-sum-equals-k/#/description

    TODO: 
    Given set of n integers, each with absolute value bounded by some polynomial in n, contains three elements that sum to zero.
    http://en.wikipedia.org/wiki/3SUM

    http://en.wikipedia.org/wiki/Summed_area_table

    ===================================================================================================================================================================================================
    */
    partial class ArrayProblems
    {
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

        public int BinarySearch(int[] nums, int noToFind)
        {
            int leftIndx = 0;
            int rightIndx = nums.Length - 1;
            int midIndx = 0;

            while (leftIndx <= rightIndx)
            {
                midIndx = (leftIndx + rightIndx) / 2;

                if (nums[midIndx] == noToFind)
                    return midIndx;
                else if (nums[midIndx] < noToFind)
                    leftIndx = midIndx + 1;
                else
                    rightIndx = midIndx - 1;
            }

            return -1;
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

    }
}

/*
Testing.
Pass only one element in array.
*/