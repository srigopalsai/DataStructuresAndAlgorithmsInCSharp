using System;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    Find 2nd Biggest in the array.
        Brute force :

        We can keep 1 variables named 1st big and 2nd big. 
        We can iterate over the list and compare each number with the first big , if the number is greater than the first big then store it in 2nd big and update first big.
        In this brute force solution the number of comparison is O(n).
        Using heap technique it is O(n/2)
    ===================================================================================================================================================================================================
     */
    public partial class ArraySamples
    {
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
    }
}