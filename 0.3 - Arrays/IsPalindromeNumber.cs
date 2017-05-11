using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
    ===================================================================================================================================================================================================
    */
    partial class ArraySamples
    {
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

    }
}