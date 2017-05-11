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
    partial class StringAlgorithms
    {
        //Assuming HashSet methods used below like Add, Clear, Contains takes O(1), based on the unique hashcode.
        public static void LongestSubStringWithoutRepeatingCharacters()
        {
            string inputString = "SaiSri";

            Dictionary<char, char> maxDistinctChars = new Dictionary<char, char>();
            Dictionary<char, char> currDistinctChars = new Dictionary<char, char>();

            for (int lpCnt = 0; lpCnt < inputString.Length; lpCnt++)
            {
                if (!currDistinctChars.ContainsKey(inputString[lpCnt]))
                {
                    currDistinctChars.Add(inputString[lpCnt], inputString[lpCnt]);
                }
                else
                {
                    if (currDistinctChars.Count > maxDistinctChars.Count)
                    {
                        //Note: O(n) time in Worst Case when there are no duplicates.
                        currDistinctChars.Clear();
                        currDistinctChars.Add(inputString[lpCnt], inputString[lpCnt]);
                    }
                }
            }
            if (currDistinctChars.Count > maxDistinctChars.Count)
            {
                //Note: O(n) time in Worst Case when there are no duplicates.
                maxDistinctChars = currDistinctChars;
            }
            //HashSet<char> maxDistinctChars = new HashSet<char>();
            //HashSet<char> currDistinctChars = new HashSet<char>();

            //for (int lpCnt = 0; lpCnt < inputString.Length; lpCnt++)
            //{
            //    if (!currDistinctChars.Contains(inputString[lpCnt]))
            //    {
            //        currDistinctChars.Add(inputString[lpCnt]);
            //        maxDistinctChars.Add(inputString[lpCnt]);
            //    }
            //    else
            //    {
            //        if (currDistinctChars.Count > maxDistinctChars.Count)
            //        {
            //            //Note: O(n) time in Worst Case when there are no duplicates.
            //            maxDistinctChars = currDistinctChars;
            //            currDistinctChars.Clear();
            //        }
            //    }
            //}
            MessageBox.Show("Max Length of Longest SubString Without Repeating Chars : " + maxDistinctChars.Count + " " );
        }

        void longestUniqueSubsttr(string inputString)
        {
            int inputStrLength = inputString.Length;
            int currentSubStrLenght = 1;  // To store the lenght of current substring
            int maxStringLenght = 1;  // To store the result
            int previousIndex;  // To store the previous index

            int lpCnt;

            int[] visitedCharsPosArray = new int[256];

            // Initialize the visited array as -1, -1 is used to indicate that character has not been visited yet.
            for (lpCnt = 0; lpCnt < inputStrLength; lpCnt++)
            {
                visitedCharsPosArray[lpCnt] = -1;
            }

            // Mark first character as visited by storing the index of first  character in visited array.
            //visitedCharsPosArray[inputString[0]] = 0;

            /* Start from the second character. First character is already processed
               (cur_len and max_len are initialized as 1, and visited[str[0]] is set */
            for (lpCnt = 0; lpCnt < inputStrLength; lpCnt++)
            {
                previousIndex = visitedCharsPosArray[inputString[lpCnt]];

                /* If the currentt character is not present in the already processed
                   substring or it is not part of the current NRCS, then do cur_len++ */
                if (previousIndex == -1 || lpCnt - currentSubStrLenght > previousIndex)
                {
                    currentSubStrLenght++;
                }
                /* If the current character is present in currently considered NRCS,
                   then update NRCS to start from the next character of previous instance. */
                else
                {
                    /* Also, when we are changing the NRCS, we should also check whether 
                      length of the previous NRCS was greater than max_len or not.*/
                    if (currentSubStrLenght > maxStringLenght)
                    {
                        maxStringLenght = currentSubStrLenght;
                    }
                    currentSubStrLenght = lpCnt - previousIndex;
                }

                visitedCharsPosArray[inputString[lpCnt]] = lpCnt; // update the index of current character
            }

            // Compare the length of last NRCS with max_len and update max_len if needed
            if (currentSubStrLenght > maxStringLenght)
            {
                maxStringLenght = currentSubStrLenght;
            }

            MessageBox.Show("Max Length of Longest SubString Without Repeating Chars : " + maxStringLenght);
        }
    }
}