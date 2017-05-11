using System.Collections.Generic;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    // O(n) Time O(n) Space.
    partial class ArraySamples
    {
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
    }
}
