using System;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
    
    Reverse the words in given strings.
    E.g Input  : Hello     World
        Output : World     Hello
    
    Time Complexity  O(2N) - [ O(N) Traversing entire array + O(N) Traversing each word again ]
    Space Complexity O(N)

    ===================================================================================================================================================================================================
     
     */
    partial class StringAlgorithms
    {
        public static void ReverseWordsInString()
        {
            string newStr = string.Empty;
            string inputWord = "Hello   World";
            int strLen = inputWord.Length - 1;

            int wordChrLpCnt = 0;
            int wordChrsLen  = strLen;
            
            // Repeat loop from back to front.
            for (int lpCnt = strLen; lpCnt >= 0; lpCnt--)
            {
                if (inputWord[lpCnt] == ' ' || lpCnt == 0)
                {
                    //If it is not first word then increment so that we can skip space.
                    wordChrLpCnt = (lpCnt != 0) ? lpCnt + 1 : lpCnt;

                    while (wordChrLpCnt <= wordChrsLen)
                    {
                        newStr += inputWord[wordChrLpCnt];
                        wordChrLpCnt++;
                    }

                    newStr = newStr + " ";

                    // Move Word Length to previous word and ignore white space.
                    wordChrsLen = lpCnt - 1;
                }
            }

            MessageBox.Show("Input String : " + inputWord + Environment.NewLine + "Output String : " + newStr);
        }
    }
}