using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    /* 
    ===================================================================================================================================================================================================
    In a given array 'A' and element 'E', find the 2 numbers of sum which is equals to the given element.

    If equals then return true, else return false.

    Time Complexity O(N) if the list is sorted.

    Refer P Verses NP for Un Sorted. Repat 2 loops and make sum with each element with next element (do same with all other elements in the list).

        https://leetcode.com/problems/subarray-sum-equals-k/#/description

    ===================================================================================================================================================================================================
    */
    partial class ArraySamples
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
    }
}

/*
Testing.
Pass only one element in array.
*/