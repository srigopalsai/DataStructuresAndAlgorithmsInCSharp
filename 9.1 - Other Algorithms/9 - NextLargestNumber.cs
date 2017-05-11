using System;
using System.Collections.Generic;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    1. Keep checking each digit (consider as minDigit) with its next digit (consider as minPrevDigit) from right to left if it is larger than minDigit.
    2. Break the loop and store the minDigit and minDigitPos. 
       If minDigitPos is -1 then there is no next large number. 

    3. After breaking find the nextLargeDigit of minDigit. 
       Swap it with minDigit.
    4. Now sort all digits of right sub array in assesnding order.

    Input       :   38457
    Round - 1   :   38475
    Round - 2   :   38547
    Round - 3   :   38574
    Round - 4   :   38745       
    Round - 5   :   38754
    Round - 6   :   43578       

    http://stackoverflow.com/questions/9368205/given-a-number-find-the-next-higher-number-which-has-the-exact-same-set-of-digi

    */
    partial class OtherAlgorithmSamples
    {
        public void FindNextBiggestNumberTest()
        {
            Int64 nextLargestNum = 0;
            string result = "Find next largest number : \n";

            Int64 sourceNum = 38457;
            nextLargestNum = FindNextBiggestNumber(sourceNum);
            result += "\n Source Num : " + sourceNum + " Next Largest : " + nextLargestNum;

            sourceNum = 567643231;
            nextLargestNum = FindNextBiggestNumber(sourceNum);
            result += "\n Source Num : " + sourceNum + " Next Largest : " + nextLargestNum;

            sourceNum = 7027277630;
            nextLargestNum = FindNextBiggestNumber(sourceNum);
            result += "\n Source Num : " + sourceNum + " Next Largest : " + nextLargestNum;

            sourceNum = 54321;
            nextLargestNum = FindNextBiggestNumber(sourceNum);
            result += "\n Source Num : " + sourceNum + " Next Largest : " + nextLargestNum;

            sourceNum = 22222;
            nextLargestNum = FindNextBiggestNumber(sourceNum);
            result += "\n Source Num : " + sourceNum + " Next Largest : " + nextLargestNum;

            result += "\n\n Note : -1 denotes there is no next big number";
            MessageBox.Show(result);
        }

        public Int64 FindNextBiggestNumber(Int64 sourceNum)
        {
            // Step 1. Convert number to number array or list.
            List<Int64> inputNums = IntToIntArr(sourceNum);

            Int64 numToSwap = inputNums[inputNums.Count - 1];

            Int64 smallDigit = -1;
            int smallDigitPos = -1;

            // Step 2. Find the 'smaller digit next to larger digit' from right to left.
            for (int lpbackwrdIndx = inputNums.Count - 1; lpbackwrdIndx > 0; lpbackwrdIndx--)
            {
                // Left side digit should be less than right side digit.
                if (inputNums[lpbackwrdIndx - 1] < inputNums[lpbackwrdIndx])
                {
                    smallDigitPos = (lpbackwrdIndx - 1);
                    smallDigit = inputNums[lpbackwrdIndx - 1];
                    break;
                }
            }

            if (smallDigitPos == -1)
            {
                return -1;
            }

            Int64 minNextBigDigit = 9;
            int minNextPos = inputNums.Count - 1;
            Int64 currentDigit = 0;

            // Step 3. Check the next larger digit for the 'smaller digit' on the right side of the sub array and get its position.
            for (int lpCntRghtArrIndx = smallDigitPos + 1;  lpCntRghtArrIndx < inputNums.Count; lpCntRghtArrIndx++)
            {
                currentDigit = inputNums[lpCntRghtArrIndx];

                if (currentDigit > smallDigit && currentDigit <= minNextBigDigit)
                {
                    minNextBigDigit = currentDigit;
                    minNextPos = lpCntRghtArrIndx;
                }
            }

            // Step 4. Swap the number with smallest.
            Int64 temp = inputNums[smallDigitPos];
            inputNums[smallDigitPos] = inputNums[minNextPos];
            inputNums[minNextPos] = temp;

            // Step 5. Sort the right side array.
            SortRightSubArray(inputNums, smallDigitPos + 1);

            // Step 6. Convert 'number array' or list back to number.
            return IntArrToInt(inputNums);
        }

        public List<Int64> IntToIntArr(Int64 Num)
        {
            Int64 reminderDigit = 0;
            List<Int64> digitsList = new List<Int64>();

            while (Num > 0)
            {
                reminderDigit = Num % 10;
                digitsList.Add(reminderDigit);
                Num = Num / 10;
            }

            digitsList.Reverse();
            return digitsList;
        }

        public Int64 IntArrToInt(List<Int64> numberArray)
        {
            Int64 Num = 0;
            for (int lpCnt = 0; lpCnt < numberArray.Count; lpCnt++)
            {
                Num = Num * 10 + numberArray[lpCnt];
            }
            return Num;
        }

        private void SortRightSubArray(List<Int64> inputNums, int stRightStPos)
        {
            inputNums.Sort(stRightStPos, (inputNums.Count - stRightStPos), new IntEqualsComparer());
        }
    }

    class IntEqualsComparer : IComparer<Int64>
    {
        public int Compare(Int64 x, Int64 y)
        {
            return x.CompareTo(y);
        }
    }
}