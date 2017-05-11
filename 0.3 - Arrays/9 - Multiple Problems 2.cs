using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class RandomArrayProblems
    {
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
    }
}
