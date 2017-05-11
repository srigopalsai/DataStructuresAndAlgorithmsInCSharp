using System;
using System.Collections.Generic;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*

    ============================================================================================================================================================================================================================

    For finding the kth smallest number in a list or array; such a number is called the kth order statistic. 
    This includes the cases of finding the minimum, maximum, and median elements.

    Input 4   3   7   8   2   9   5   1   6   0 (Unsorted Array)
    
    Find 4th biggest

    Use Selection Algorithm (Note it is differnt from selection sort) http://en.wikipedia.org/wiki/Selection_algorithm
    http://www.geeksforgeeks.org/k-largestor-smallest-elements-in-an-array/
    http://www.geeksforgeeks.org/forums/topic/kth-largest-element/

    Time complexity = O(n)
    Discard half each time: n+(n/2)+(n/4)..1 = n + (n-1) = O(2n-1) = O(n), because n/2+n/4+n/8+..1=n-1.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 
    Few Selection Algorithm Types:

    1. Partial Selection Sort.
    2. Quick Select.
    3. Online Select.
    4. Quikc Select.
    5. Using Heap.
    6. Using Prioirty Queue.

    Build a heap/priority queue.  O(n)
    Pop top element.  O(log n)
    Pop top element.  O(log n)
    Pop top element.  O(log n)

    Total = O(n) + 3 O(log n) = O(n) 

    Worst Case : O(n) (linear time) , O (1) for Sorted Data.

    Best Case of this Algo : Finding the minimum (or maximum) element by iterating through the list, keeping track of the running minimum – the minimum so far – (or maximum) and can be seen as related to the selection sort. 
    Hardest Case : Finding the median, and this necessarily takes n/2 storage. 
    
    n + n / 2 + n / 4 + n / 8 + n / 16 + ... = n (1 + 1/2 + 1/4 + 1/8 + ...) = 2n
    
    http://stackoverflow.com/questions/8783408/why-is-the-runtime-of-the-selection-algorithm-on
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Testing :

    1. NULL array and pass size as 0.
    2. Array with duplicates.
    3. Array which is already sorted or sorted in reverse order and we are finding 1st biggest or Nth biggest.
    4. Find something in between. Like given an array like {-6, -6, 2, 2, 2, 10, 10, 10, -6, -6, 2, 2, 2, 2, 2}, try finding different Nth biggest.
    5. Try also with array having all distinct elements. Something like {14, 13, 12, 11, 10,  9, 8, 7, 6, 5, 4, 3, 2, 1, 15}.

    ============================================================================================================================================================================================================================
    */
    partial class SearchingAlgorithms
    {
        public void SelectionAlgorithmKthSmallestTest()
        {
            //int[] ArrayElements = { -1, 2, 0 };
            //// Fails for 7,8
            //int kthSmallest = 2;

            //kthSmallest = ArrayElements.Length - kthSmallest;

            //int resultVal = QuickSelect(ArrayElements, 0, (ArrayElements.Length - 1), kthSmallest);
            //MessageBox.Show(kthSmallest + " Smallest Element in Array " + resultVal);

            TestData.Reset();
            RunNtSelectTest();
            TestData.ShowResultsFromTestData();
        }

        private void RunNtSelectTest()
        { 
            TestData.TestCasesCount++;

            foreach (KeyValuePair<string, KeyValuePair<int,int[]>> nthKVPair in TestData.ArraysWithKthPosition)
            {
                int kthPos = nthKVPair.Value.Key;
                int[] array = nthKVPair.Value.Value;

                TestData.AppendArrayToStrBldrMessage(array, string.Format("\n\n{0}. Source ", ++TestData.TestCaseNo), string.Format(" Kth Pos {0}", kthPos));

                if (array.Length == 0)
                    continue;
                kthPos = array.Length - kthPos;

                //int result = QuickSelect(array, 0, array.Length - 1, kthPos);
                int result = FindKthLargest(array, kthPos);
                TestData.AppendMessageToStrBldrMessage(string.Format(" Result Val {0}", result));
            }
        }

        //https://discuss.leetcode.com/topic/29537/concise-java-solution-based-on-quick-select
        //https://discuss.leetcode.com/topic/15256/4-c-solutions-using-partition-max-heap-priority_queue-and-multiset-respectively
        //https://discuss.leetcode.com/topic/14597/solution-explained

        //private int QuickSelectPartition(int[] arrayElements, int leftPos, int rightPos, int pivotIndx)
        //{
        //    int pivotElement = arrayElements[pivotIndx];

        //    int beginIndx = leftPos;

        //    Common.Swap(ref arrayElements[pivotIndx], ref arrayElements[rightPos]);

        //    for (int lpCnt = leftPos; lpCnt < rightPos; lpCnt++)
        //    {
        //        if (arrayElements[lpCnt] < pivotElement)
        //        {
        //            Common.Swap(ref arrayElements[beginIndx], ref arrayElements[lpCnt]);
        //            beginIndx++;
        //        }
        //    }

        //    Common.Swap(ref arrayElements[beginIndx], ref arrayElements[rightPos]);

        //    return beginIndx;
        //}

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //1. O(KN) Partial Selection Sort : Yields a simple selection algorithm.
        //This is asymptotically inefficient when k =n, but can be sufficiently efficient if K is small, and is easy to implement. 

        public int SelectKthSmallest(int[] arrayElements, int kthSmallest)
        {
            // Note : Changes original list.
            for (int kthLpCnt = 0; kthLpCnt < kthSmallest; kthLpCnt++)
            {
                int minIndex = kthLpCnt;
                int minValue = arrayElements[kthLpCnt];

                for (int linearLpCnt = kthLpCnt + 1; linearLpCnt < arrayElements.Length; linearLpCnt++)
                {
                    if (arrayElements[linearLpCnt] < minValue)
                    {
                        minIndex = linearLpCnt;
                        minValue = arrayElements[linearLpCnt];
                        
                        Common.Swap(ref   arrayElements[kthLpCnt], ref arrayElements[minIndex]);
                    }
                }
            }
            return arrayElements[kthSmallest];
        }

        public int FindKthLargest(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k > nums.Length)
                return -1;
            if (nums.Length == 1 && (k == 1 || k ==0))
                return nums[0];

            return findKthLargest(nums, 0, nums.Length - 1, k - 1);
        }

        int findKthLargest(int[] nums, int head, int tail, int kPos)
        {
            int leftIndx = head;
            int rightIndx = tail;
            int pivotVal = nums[leftIndx];

            while (leftIndx < rightIndx)
            {
                while (leftIndx < rightIndx && nums[rightIndx] <= pivotVal)
                    rightIndx--;

                nums[leftIndx] = nums[rightIndx];

                while (leftIndx < rightIndx && nums[leftIndx] >= pivotVal)
                    leftIndx++;

                nums[rightIndx] = nums[leftIndx];
            }

            nums[leftIndx] = pivotVal;

            if (leftIndx == kPos)
                return nums[leftIndx];

            if (leftIndx < kPos)
                return findKthLargest(nums, leftIndx + 1, tail, kPos);

            if (leftIndx > kPos)
                return findKthLargest(nums, head, leftIndx - 1, kPos);

            return -1;
        }

        // TODO : Heap Sort Approach.

        /*
        int mid = start + (end - start)/2;
        int pivotVal = choosePivot(nums[mid], nums[start], nums[end]);
         */

        private int choosePivot(int a, int b, int c)
        {
            if (a > b)
            {
                if (c > a)
                {
                    return a;
                }
                else if (c > b)
                {
                    return c;
                }
                else
                {
                    return b;
                }
            }
            else
            {
                if (c > b)
                {
                    return b;
                }
                else if (c > a)
                {
                    return c;
                }
                else
                {
                    return a;
                }
            }
        }

        //Use median-of-three strategy to choose pivot
        private int medianOf3(int[] nums, int left, int right)
        {
            int mid = left + (right - left) / 2;

            if (nums[right] > nums[left])
            {
                swap(nums, left, right);
            }

            if (nums[right] > nums[mid])
            {
                swap(nums, right, mid);
            }

            if (nums[mid] > nums[left])
            {
                swap(nums, left, mid);
            }

            return mid;
        }

        private void swap(int[] nums, int a, int b)
        {
            int temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}