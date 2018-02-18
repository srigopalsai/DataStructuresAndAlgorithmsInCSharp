using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    TODO 
    Sorted Vector:    http://www.sanfoundry.com/java-program-sorted-vecto/
    Alternate Positive and Negative     http://www.geeksforgeeks.org/rearrange-array-alternating-positive-negative-items-o1-extra-space/

*/
    class RandomArrayProblems
    {
        StringBuilder stringBldr = new StringBuilder();
        public void Test()
        {
            int[] srcArray = { 4, 5, 6, 0, 0, 0 };
            int[] trgtArray = { 1, 2, 3 };
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] result = Intersection(nums1, nums2);
            Merge2SortedArrays(srcArray, 3, trgtArray, 3);

        }

        public void Merge2SortedArrays(int[] nums1, int nums1Indx, int[] nums2, int nums2Indx)
        {
            --nums1Indx;
            --nums2Indx;

            int lpCnt = nums1.Length - 1;

            while (lpCnt >= 0)
            {
                if (nums1Indx < 0 || nums2Indx < 0)
                    break;

                if (nums1[nums1Indx] > nums2[nums2Indx])
                {
                    nums1[lpCnt] = nums1[nums1Indx];
                    nums1Indx--;
                }
                else
                {
                    nums1[lpCnt] = nums2[nums2Indx];
                    nums2Indx--;
                }
                lpCnt--;
            }

            while (nums1Indx >= 0)
            {
                nums1[lpCnt] = nums1[nums1Indx];
                nums1Indx--;
                lpCnt--;
            }
            while (nums2Indx >= 0)
            {
                nums1[lpCnt] = nums2[nums2Indx];
                nums2Indx--;
                lpCnt--;
            }
        }

        public int[] IntersectionOf2ArraysIncludeDups(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null || Math.Min(nums1.Length, nums2.Length) == 0)
                return new int[] { };

            Dictionary<int, int> nums1Set = new Dictionary<int, int>();
            Dictionary<int, int> nums2Set = new Dictionary<int, int>();
            List<int> resultItems = new List<int>();

            int itemKey;
            int nums2ItemVal;

            // Store all nums1 items counts. Key as item and Count as Value.
            for (int lpCnt = 0; lpCnt < nums1.Length; lpCnt++)
            {
                itemKey = nums1[lpCnt];

                if (nums1Set.ContainsKey(itemKey))
                    nums1Set[itemKey] = nums1Set[itemKey] + 1;
                else
                    nums1Set.Add(itemKey, 1);
            }

            // Store all nums2 items counts. Key as item and Count as Value.
            for (int lpCnt = 0; lpCnt < nums2.Length; lpCnt++)
            {
                itemKey = nums2[lpCnt];

                if (nums2Set.ContainsKey(itemKey))
                    nums2Set[itemKey] = nums2Set[itemKey] + 1;
                else
                    nums2Set.Add(itemKey, 1);
            }

            //Pick Min of nums1 or nums2 and generate numbers.
            foreach (var nums1Item in nums1Set)
            {
                nums2Set.TryGetValue(nums1Item.Key, out nums2ItemVal);

                int minCnt = Math.Min(nums1Item.Value, nums2ItemVal);

                for (int lpCnt = 0; lpCnt < minCnt; lpCnt++)
                    resultItems.Add(nums1Item.Key);
            }

            return resultItems.ToArray();
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> nums1Set = new HashSet<int>();
            HashSet<int> resultSet = new HashSet<int>();

            for (int lpCnt = 0; lpCnt < nums1.Length; lpCnt++)
                nums1Set.Add(nums1[lpCnt]);

            for (int lpCnt = 0; lpCnt < nums2.Length; lpCnt++)
            {
                if (nums1Set.Contains(nums2[lpCnt]))
                    if (!resultSet.Contains(nums2[lpCnt]))
                        resultSet.Add(nums2[lpCnt]);
            }

            return resultSet.ToArray();
        }

        public void LongestPalindromeTest()
        {
            int[] palindromeNum = { 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 1 };
            IsPalindrome(palindromeNum);

            palindromeNum = new int[] { 1, 2, 3, 3, 2, 1 };
            IsPalindrome(palindromeNum);

        }

        public void IsPalindrome(int[] palindromeNum)
        {
            int lpleftCntr = palindromeNum.Length / 2;
            int lpRightCntr = (lpleftCntr + 1);

            if (palindromeNum.Length % 2 == 0)
            {
                lpRightCntr++;
            }

            while (lpleftCntr >= 0 && lpRightCntr < palindromeNum.Length)
            {
                if (palindromeNum[lpleftCntr] != palindromeNum[lpRightCntr])
                {
                    break;
                }

                lpleftCntr--;
                lpRightCntr++;
            }

            stringBldr.Clear();

            for (int lpCnt = lpleftCntr + 1; lpCnt < lpRightCntr; lpCnt++)
            {
                stringBldr.AppendLine("  " + palindromeNum[lpCnt]);
            }

            MessageBox.Show(stringBldr.ToString());
        }

        /*
===================================================================================================================================================================================================

Input:
Compare values in 2 are and return true if they are same. Note : they are not in similar order.
Array 1 :   1   2   3   4   5
Array 2 :   1   3   2   5   4

Output : True.

Try less than O(n log n) time.
http://stackoverflow.com/questions/10639661/check-if-array-b-is-a-permutation-of-a
http://stackoverflow.com/questions/6691184/find-if-two-arrays-contain-the-same-set-of-integers-without-extra-space-and-fast

===================================================================================================================================================================================================    
*/

        public void Compare2ArraysTest()
        {
            int[] Array1 = { 1, 2, 3, 4, 5 };
            int[] Array2 = { 1, 3, 2, 5, 4 };
            bool result = false;

            //IntPtr intptr = &Array1;

            char[] chArray1 = new char[Array1.Length];
            char[] chArray2 = new char[Array2.Length];

            //            Array.ConvertAll(Array1,chArray1, new Converter<int,char>);

            for (int lpCnt = 0; lpCnt < Array2.Length; lpCnt++)
            {
                chArray2[lpCnt] = Convert.ToChar(Array2[lpCnt] + '0');
                //Array1[lpCnt] = chArray1[lpCnt] - '0';
            }

            stringBldr.Clear();

            stringBldr.AppendLine("Source Array 1 : " + new string(Array1.Select(ch => Convert.ToChar(ch + '0')).ToArray()));
            stringBldr.AppendLine("Source Array 2 : " + new string(chArray2));

            result = Compare2Arrays(Array1, Array2);
            stringBldr.AppendLine("Compare 2 Arrays result : " + result);

            MessageBox.Show(stringBldr.ToString());

        }

        public bool Compare2Arrays(int[] array1, int[] array2)
        {
            //Dictionary<int, int> intTable = new Dictionary<int, int>();
            HashSet<int> uniqueTable = new HashSet<int>();

            for (int lpCnt = 0; lpCnt < array1.Length; lpCnt++)
            {
                if (!uniqueTable.Contains(array1[lpCnt]))
                {
                    uniqueTable.Add(array1[lpCnt]);
                }
            }

            bool areSame = true;

            for (int lpCnt = 0; lpCnt < array2.Length; lpCnt++)
            {
                if (!uniqueTable.Contains(array2[lpCnt]))
                {
                    areSame = false;
                    break;
                }
            }

            return areSame;
        }

        /*
===================================================================================================================================================================================================

Find the least difference between any two elements of an integer array.

First sort the elements of the array. 
Then iterate over the array and find difference between consecutive elements. 
The least of them would be the least differences between any two elements of the array. 

The complexity will be O(nlogn) because of the sorting step.

===================================================================================================================================================================================================
*/
        public void LeastDifferenceOf2Numbers()
        {
            int[] arr = { 64, 57, 2, 78, 43, 73, 53, 86 };

            Array.Sort(arr);
            int minDiff = Int32.MinValue;

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int diff = Math.Abs(arr[i] - arr[i + 1]);
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }
            MessageBox.Show("The lease min diff of 2 nums in array is " + minDiff.ToString());
        }

        /* E.g. If n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4]. 

http://www.geeksforgeeks.org/block-swap-algorithm-for-array-rotation/

Mulitple ways: https://discuss.leetcode.com/topic/9801/summary-of-c-solutions/13
https://discuss.leetcode.com/topic/24283/a-7-line-time-o-n-in-place-solution-no-reversing
Roate the given array in 90 degrees.    

Block Swap or Juggling or Reversal or Reversing Algorithms      */

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

        // 4 https://leetcode.com/problems/median-of-two-sorted-arrays/description/
        // FindMedianSortedArrays(new int[] { 10, 30, 50, 70, 90 }, new int[] { 20, 40, 60, 80, 100 });
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int nums1Length = nums1.Length;
            int Nmus2Length = nums2.Length;

            if (nums1Length < Nmus2Length)
            {
                return FindMedianSortedArrays(nums2, nums1);    // Make sure nums2 is the shorter one.
            }

            int lowIndx = 0;
            int hiIndx = Nmus2Length * 2;

            while (lowIndx <= hiIndx)
            {
                int mid2Indx = (lowIndx + hiIndx) / 2;   // Try Cut 2 
                int mid1Indx = nums1Length + Nmus2Length - mid2Indx;  // Calculate Cut 1 accordingly

                double nums1LeftMidVal = (mid1Indx == 0) ? int.MinValue : nums1[(mid1Indx - 1) / 2];    // Get L1, R1, L2, R2 respectively
                double nums2LeftMidVal = (mid2Indx == 0) ? int.MinValue : nums2[(mid2Indx - 1) / 2];

                double nums1RightMidVal = (mid1Indx == nums1Length * 2) ? int.MaxValue : nums1[mid1Indx / 2];
                double nums2RightMidVal = (mid2Indx == Nmus2Length * 2) ? int.MaxValue : nums2[mid2Indx / 2];

                if (nums1LeftMidVal > nums2RightMidVal)
                {
                    lowIndx = mid2Indx + 1;
                }
                else if (nums2LeftMidVal > nums1RightMidVal)
                {
                    hiIndx = mid2Indx - 1;
                }
                else
                {
                    return (Math.Max(nums1LeftMidVal, nums2LeftMidVal) + Math.Min(nums1RightMidVal, nums2RightMidVal)) / 2;
                }
            }

            return -1;
        }

        public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int nums1Len = nums1.Length;
            int nums2Len = nums2.Length;

            int totalLen = nums1Len + nums2Len;

            if (totalLen % 2 == 0)
            {
                return (FindKthValue(nums1, nums2, totalLen / 2) + FindKthValue(nums1, nums2, (totalLen / 2) + 1)) / 2.0;
            }
            else
            {
                return FindKthValue(nums1, nums2, (totalLen / 2) + 1);
            }
        }

        private int FindKthValue(int[] nums1, int[] nums2, int kthPos)
        {
            int num1Indx = 0;
            int num2Indx = 0;

            for (int index = 0; index < kthPos - 1; index++)
            {
                if (num1Indx >= nums1.Length && num2Indx < nums2.Length)
                {
                    num2Indx++;
                }
                else if (num1Indx < nums1.Length && num2Indx >= nums2.Length)
                {
                    num1Indx++;
                }
                else if (nums1[num1Indx] > nums2[num2Indx])
                {
                    num2Indx++;
                }
                else
                {
                    num1Indx++;
                }
            }

            if (num1Indx >= nums1.Length)
            {
                return nums2[num2Indx];
            }
            else if (num2Indx >= nums2.Length)
            {
                return nums1[num1Indx];
            }
            else
            {
                return Math.Min(nums1[num1Indx], nums2[num2Indx]);
            }
        }

        public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0 || nums2 == null || nums2.Length == 0)
                return 0.0;

            int nums1Indx = 0;
            int nums2Indx = 0;

            int leftMidVal = 0;
            int rightMidVal = 0;

            int totalLength = nums1.Length + nums2.Length;

            for (int index = 0; index < totalLength / 2 + 1; index++)
            {
                rightMidVal = leftMidVal;

                if (nums2Indx >= nums2.Length || (nums1Indx < nums1.Length && nums1[nums1Indx] <= nums2[nums2Indx]))
                {
                    leftMidVal = nums1[nums1Indx];
                    nums1Indx++;
                }
                else
                {
                    leftMidVal = nums2[nums2Indx];
                    nums2Indx++;
                }
            }

            if (totalLength % 2 == 1)
            {
                return leftMidVal;
            }
            else
            {
                return (leftMidVal + rightMidVal) / 2.0;
            }
        }


        //480 https://leetcode.com/problems/sliding-window-median/description/
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0)
                return new double[0];

            int liPos1 = (k >> 1);
            int liPos2 = liPos1 + (k & 1) - 1;

            List<double> llist = new List<double>();
            List<double> llistSlid = new List<double>();

            for (int index = 0; index < nums.Length; ++index)
            {
                if (index >= k)
                {
                    llistSlid.Remove(nums[index - k]);
                }

                int liIndex = llistSlid.BinarySearch(nums[index]);

                if (liIndex < 0)
                {
                    liIndex = ~liIndex;
                }

                llistSlid.Insert(liIndex, nums[index]);

                if (index >= k - 1)
                {
                    llist.Add(liPos1 == liPos2 ? llistSlid[liPos1] : ((llistSlid[liPos1] + llistSlid[liPos2]) / 2));
                }
            }

            return llist.ToArray<double>();
        }

        // 128 https://leetcode.com/problems/longest-consecutive-sequence/description/       
        public int LongestConsecutive(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            HashSet<int> numSet = new HashSet<int>(nums);

            int longestCnt = 1;

            foreach (int currVal in nums)
            {
                if (!numSet.Contains(currVal))
                    continue;

                numSet.Remove(currVal);

                int prevVal = currVal - 1;
                int nextVal = currVal + 1;

                while (numSet.Contains(prevVal))
                {
                    numSet.Remove(prevVal);
                    prevVal--;
                }

                while (numSet.Contains(nextVal))
                {
                    numSet.Remove(nextVal);
                    nextVal++;
                }

                longestCnt = Math.Max(longestCnt, nextVal - prevVal - 1);
            }

            return longestCnt;
        }

        public int LongestConsecutive2(int[] nums)
        {
            int result = 0;
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int n in nums)
            {
                if (!dictionary.ContainsKey(n))
                {
                    int left = dictionary.ContainsKey(n - 1) ? dictionary[n - 1] : 0;
                    int right = dictionary.ContainsKey(n + 1) ? dictionary[n + 1] : 0;

                    // sum: length of the sequence n is in
                    int sum = left + right + 1;
                    dictionary[n] = sum;

                    // keep track of the max length 
                    result = Math.Max(result, sum);

                    // extend the length to the boundary(s) of the sequence
                    // will do nothing if n has no neighbors
                    dictionary[n - left] = sum;
                    dictionary[n + right] = sum;
                }
                else
                {
                    // Duplicates
                    continue;
                }
            }
            return result;
        }

        // 55 https://leetcode.com/problems/jump-game/
        // https://leetcode.com/problems/jump-game/solution/
        bool CanJump(int[] nums)
        {
            int currMaxJump = 0;
            int index = 0;

            while (index < nums.Length && index <= currMaxJump)
            {
                currMaxJump = Math.Max(currMaxJump, index + nums[index]);
                ++index;
            }

            return index == nums.Length;
        }

        // 45 https://leetcode.com/problems/jump-game-ii/
        public int Jump(int[] nums)
        {
            int stepCount = 0;
            int prevMaxJump = 0;
            int currMaxJump = 0;

            for (int index = 0; index < nums.Length - 1; index++)
            {
                currMaxJump = Math.Max(currMaxJump, index + nums[index]);

                if (index == prevMaxJump)
                {
                    stepCount++;
                    prevMaxJump = currMaxJump;
                }
            }

            return stepCount;
        }

        //------------------------------------------------------------------------------------
        /* 300 https://leetcode.com/problems/longest-increasing-subsequence/description/ 
          http://www.geeksforgeeks.org/longest-increasing-subsequence/
         The length of the longest increasing subsequence in arr[] of size n */
        public int LengthOfLIS(int[] nums)
        {
            List<int> list = new List<int>();

            foreach (int num in nums)
            {
                if (list.Count == 0)
                {
                    list.Add(num);
                    continue;
                }
                if (list[list.Count - 1] < num)
                {
                    list.Add(num);
                    continue;
                }

                int rightIndx = list.Count - 1;
                Console.WriteLine("rightIndx " + rightIndx);

                rightIndx = Array.BinarySearch(nums, 0, rightIndx, num);

                if (rightIndx < 0)
                    rightIndx = -(rightIndx + 1);

                list[rightIndx] = num;
            }

            return list.Count;
        }

        public int LengthOfLIS1(int[] nums)
        {
            int[] dpLkUp = new int[nums.Length];
            int lisCnt = 0;

            foreach (int num in nums)
            {
                int index = Array.BinarySearch(dpLkUp, 0, lisCnt, num);

                if (index < 0)
                    index = -(index + 1);

                dpLkUp[index] = num;

                if (index == lisCnt)
                    lisCnt++;
            }

            return lisCnt;
        }

        /*  O(n^2) time O(n) Space 
           O (n log n) here http://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/*/
        public int LongestIncreasingSubsequence(int[] nums)
        {
            int srcNumLen = nums.Length;
            int[] lookUp = new int[srcNumLen];

            // Initialize LIS values for all indexes
            for (int index = 0; index < srcNumLen; index++)
                lookUp[index] = 1;

            // Compute optimized LIS values in bottom up manner
            for (int indxI = 1; indxI < srcNumLen; indxI++)
            {
                for (int indxJ = 0; indxJ < indxI; indxJ++)
                {
                    if (nums[indxI] > nums[indxJ] &&
                         lookUp[indxI] < lookUp[indxJ] + 1)
                    {
                        lookUp[indxI] = lookUp[indxJ] + 1;
                    }
                }
            }

            int maxLIS = 0;

            // Pick maximum of all LIS values
            for (int index = 0; index < srcNumLen; index++)
            {
                if (maxLIS < lookUp[index])
                {
                    maxLIS = lookUp[index];
                }
            }
            return maxLIS;
        }

        public void LongestIncreasingSubsequenceTest()
        {
            int[] nums = { 10, 22, 9, 33, 21, 50, 41, 60 };
            Console.WriteLine("Length of lis is " + LongestIncreasingSubsequence(nums) + "n");
        }

        //------------------------------------------------------------------------------------

        // 673 https://leetcode.com/problems/number-of-longest-increasing-subsequence/description/
        public int FindNumberOfLIS(int[] nums)
        {
            int numsLen = nums.Length;
            int resCnt = 0;
            int maxLen = 0;

            int[] lenLIS = new int[numsLen];   // Is the length of longest subsequence ending with nums[k];            
            int[] totalLIS = new int[numsLen]; // Is total number of longest subsequence ending with nums[k];

            for (int indxI = 0; indxI < numsLen; indxI++)
            {
                lenLIS[indxI] = totalLIS[indxI] = 1;

                for (int indxJ = 0; indxJ < indxI; indxJ++)
                {
                    if (nums[indxI] > nums[indxJ])
                    {
                        if (lenLIS[indxI] == lenLIS[indxJ] + 1)
                        {
                            totalLIS[indxI] += totalLIS[indxJ];
                        }
                        if (lenLIS[indxI] < lenLIS[indxJ] + 1)
                        {
                            lenLIS[indxI] = lenLIS[indxJ] + 1;
                            totalLIS[indxI] = totalLIS[indxJ];
                        }
                    }
                }

                if (maxLen == lenLIS[indxI])
                {
                    resCnt += totalLIS[indxI];
                }
                else if (maxLen < lenLIS[indxI])
                {
                    maxLen = lenLIS[indxI];
                    resCnt = totalLIS[indxI];
                }
            }

            return resCnt;
        }

        // 334 https://leetcode.com/problems/increasing-triplet-subsequence/description/
        public bool IncreasingTriplet(int[] nums)
        {
            // Start with two largest values, as soon as we find a number bigger than both
            // while both have been updated, return true.

            int smallVal = int.MaxValue;
            int bigVal = int.MaxValue;

            foreach (int num in nums)
            {
                if (num <= smallVal)
                {
                    smallVal = num;
                }
                // Update small if n is smaller than both
                else if (num <= bigVal)
                {
                    bigVal = num;
                }
                // Update big only if greater than small but smaller than big
                else
                {
                    // Return if you find a number bigger than both
                    return true;
                }
            }
            return false;
        }

        //57 - https://leetcode.com/problems/insert-interval/description/
        public class Interval
        {
            public int start { get; set; }
            public int end { get; set; }
        }

        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            List<Interval> result = new List<Interval>();

            foreach (Interval curIntval in intervals)
            {
                if (newInterval == null || curIntval.end < newInterval.start)
                {
                    result.Add(curIntval);
                }
                else if (curIntval.start > newInterval.end)
                {
                    result.Add(newInterval);
                    result.Add(curIntval);
                    newInterval = null;
                }
                else
                {
                    newInterval.start = Math.Min(newInterval.start, curIntval.start);
                    newInterval.end = Math.Max(newInterval.end, curIntval.end);
                }
            }

            if (newInterval != null)
                result.Add(newInterval);

            return result;
        }

        // 56 https://leetcode.com/problems/merge-intervals/description/
        public IList<Interval> Merge(IList<Interval> intervals)
        {
            IEnumerable<Interval> sortedList = intervals.OrderBy(item => item.start);
            intervals = sortedList.ToList();

            List<Interval> resultList = new List<Interval>();
            Interval prevInterval = null;

            foreach (Interval curInterval in intervals)
            {
                if (prevInterval == null || curInterval.start > prevInterval.end)
                {
                    resultList.Add(curInterval);
                    prevInterval = curInterval;
                }
                else if (curInterval.end > prevInterval.end)
                {
                    // Modify the element already in list
                    prevInterval.end = curInterval.end;
                }
            }

            return resultList;
        }

        // https://leetcode.com/problems/largest-rectangle-in-histogram/description/
        public int LargestRectangleArea1(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int top = 0;
            int indx = 0;
            int area = 0;
            int MaxArea = 0;

            while (indx < heights.Length)
            {
                if (stack.Count == 0 || heights[stack.Peek()] <= heights[indx])
                {
                    stack.Push(indx++);
                }
                else
                {
                    top = stack.Pop();

                    if (stack.Count == 0)
                    {
                        area = heights[top] * indx;
                    }
                    else
                    {
                        area = heights[top] * (indx - stack.Peek() - 1);
                    }
                }

                MaxArea = Math.Max(area, MaxArea);
            }

            while (stack.Count > 0)
            {
                top = stack.Pop();

                if (stack.Count == 0)
                {
                    area = heights[top] * indx;
                }
                else
                {
                    area = heights[top] * (indx - stack.Peek() - 1);
                }

                MaxArea = Math.Max(area, MaxArea);
            }

            return MaxArea;
        }

        public int LargestRectangleArea(int[] heights)
        {
            int area = 0;
            int maxArea = 0;

            Stack<int> stack = new Stack<int>();

            for (int indx = 0; indx <= heights.Length; indx++)
            {
                int curHeight = indx == heights.Length ? 0 : heights[indx];

                if (stack.Count == 0 || curHeight >= heights[stack.Peek()])
                {
                    stack.Push(indx);
                    continue;
                }

                while (stack.Count > 0 && curHeight < heights[stack.Peek()])
                {
                    int top = stack.Pop();

                    area = heights[top] * (stack.Count == 0 ? indx : indx - 1 - stack.Peek());

                    maxArea = Math.Max(maxArea, area);
                }

                stack.Push(indx);
            }

            return maxArea;
        }

        // https://leetcode.com/problems/container-with-most-water/description/
        public int MaxArea(int[] heights)
        {
            int maxArea = 0;
            int curMaxArea = 0;
            int maxHeight = 0;

            int lIndx = 0;
            int rIndx = heights.Length - 1;

            while (lIndx < rIndx)
            {
                maxHeight = Math.Min(heights[lIndx], heights[rIndx]);
                curMaxArea = (rIndx - lIndx) * maxHeight;
                maxArea = Math.Max(maxArea, curMaxArea);

                while (heights[lIndx] <= maxHeight && lIndx < rIndx)
                {
                    lIndx++;
                }

                while (heights[rIndx] <= maxHeight && lIndx < rIndx)
                {
                    rIndx--;
                }
            }

            return maxArea;
        }
    }
}