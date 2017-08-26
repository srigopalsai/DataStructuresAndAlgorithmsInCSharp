using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class StringAlgorithms
    {
        /*
        MARY   -   ARMY
        DEBIT CARD - BAD CREDIT
        s = "anagram", t = "nagaram", return true.
        s = "rat", t = "car", return false. 
        Note:
        You may assume the string contains only lowercase alphabets.
        Follow up:
        What if the inputs contain unicode characters? How would you adapt your solution to such case?

         */
        // LC 242 https://leetcode.com/problems/valid-anagram/description/
        public bool IsAnagram(string srcStr, string trgtStr)
        {
            if (String.IsNullOrWhiteSpace(srcStr) || String.IsNullOrWhiteSpace(trgtStr))
                return true;

            if (srcStr.Length != trgtStr.Length)
                return false;

            int[] charCnts = new int[26];

            for (int index = 0; index < srcStr.Length; index++)
            {
                charCnts[srcStr[index] - 'a']++;
                charCnts[trgtStr[index] - 'a']--;
            }

            foreach (int indexCnt in charCnts)
            {
                if (indexCnt != 0)
                {
                    return false;
                }
            }

            return true;
        }

        // LC 87 https://leetcode.com/problems/scramble-string/description/
        public bool IsScramble(string s1, string s2)
        {
            return false;
        }

        // LC 387 https://leetcode.com/problems/first-unique-character-in-a-string/discuss/
        public static int FirstUniqChar(string srcStr)
        {
            int[] charsFreq = new int[26];
            int charPos = 0;

            for (int index = 0; index < srcStr.Length; index++)
            {
                charPos = srcStr[index] - 'a';
                charsFreq[charPos]++;
            }

            for (int index = 0; index < srcStr.Length; index++)
            {
                charPos = srcStr[index] - 'a';
                if (charsFreq[charPos] == 1)
                {
                    return index;
                }
            }

            return -1;
        }

        // LC 500 https://leetcode.com/problems/keyboard-row/description/
        public string[] FindWords(string[] words)
        {
            if (words == null)
                return null;

            List<string> strList = new List<string>();

            HashSet<char> set1 = new HashSet<char>() { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            HashSet<char> set2 = new HashSet<char>() { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            HashSet<char> set3 = new HashSet<char>() { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            string word = "";

            foreach (string aword in words)
            {
                word = aword.ToLower();
                if (IsWordInSingleRow(word, set1) || IsWordInSingleRow(word, set2) || IsWordInSingleRow(word, set3))
                {
                    strList.Add(aword);
                }
            }

            return strList.ToArray();
        }

        private bool IsWordInSingleRow(string word, HashSet<char> charSet)
        {
            foreach (char ch in word)
            {
                if (!charSet.Contains(ch))
                    return false;
            }

            return true;
        }

        // LC 599 https://leetcode.com/problems/minimum-index-sum-of-two-lists/description/
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            if (list1 == null || list2 == null)
                return null;

            Dictionary<string, int> l1Dictionary = new Dictionary<string, int>();

            for (int l1Indx = 0; l1Indx < list1.Length; l1Indx++)
                l1Dictionary.Add(list1[l1Indx], l1Indx);

            int minIndexSum = list1.Length + list2.Length; //Not precise, but large enough.

            List<string> resultList = new List<string>();

            for (int l2Indx = 0; l2Indx < list2.Length; l2Indx++)
            {
                string l2Item = list2[l2Indx];

                if (l1Dictionary.ContainsKey(l2Item))
                {
                    int indexSum = l1Dictionary[l2Item] + l2Indx;

                    //Meet a  new min, we update the min, then clear the res and add l2Item
                    if (indexSum < minIndexSum)
                    {
                        minIndexSum = indexSum;
                        resultList.Clear();
                        resultList.Add(l2Item);
                    }
                    else if (indexSum == minIndexSum) //Meet a tie
                    {
                        resultList.Add(l2Item);
                    }
                }
            }
            return resultList.ToArray();
        }

        // LC 557 https://leetcode.com/problems/reverse-words-in-a-string-iii/description/
        public string ReverseWords(string srcStr)
        {
            if (string.IsNullOrWhiteSpace(srcStr))
                return srcStr;

            StringBuilder strBldr = new StringBuilder();

            int endPos = -1;
            int stPos = 0;

            for (int lpIndx = 0; lpIndx < srcStr.Length; lpIndx++)
            {
                if (srcStr[lpIndx] != ' ')
                    continue;

                stPos = lpIndx - 1;

                while (stPos > endPos)
                {
                    strBldr.Append(srcStr[stPos]);
                    stPos--;
                }

                strBldr.Append(' ');
                endPos = lpIndx;
            }

            stPos = srcStr.Length - 1;

            while (stPos > endPos)
            {
                strBldr.Append(srcStr[stPos]);
                stPos--;
            }

            return strBldr.ToString().Trim();
        }

        // LC 412 https://leetcode.com/problems/fizz-buzz/description/
        public IList<string> FizzBuzz(int nLen)
        {
            List<string> strNums = new List<string>();

            int n = 1;
            while (n <= nLen)
            {
                if (n % 5 == 0 && n % 3 == 0)
                {
                    strNums.Add("FizzBuzz");
                }
                else if (n % 5 == 0)
                {
                    strNums.Add("Buzz");
                }
                else if (n % 3 == 0)
                {
                    strNums.Add("Fizz");
                }
                else
                {
                    strNums.Add(n.ToString());
                }
                n++;
            }

            return strNums;
        }

        // 389 https://leetcode.com/problems/find-the-difference/description/
        public char FindTheDifference(string srcStr, string trgtStr)
        {
            int charCode = trgtStr[srcStr.Length];

            for (int index = 0; index < srcStr.Length; ++index)
            {
                charCode -= srcStr[index];
                charCode += trgtStr[index];
            }

            return (char)charCode;
        }

        public char FindTheDifference1(string srcStr, string trgtStr)
        {
            int r = 0;

            int[] chars = new int[26];

            foreach (char ch in srcStr)
            {
                int pos = ch - 'a';
                chars[pos] += 1;
            }

            foreach (char ch in trgtStr)
            {
                int pos = ch - 'a';

                if (chars[pos] == 0)
                    return ch;

                chars[pos] -= 1;
            }

            return '\0';
        }

        public char FindTheDifference2(String srcStr, String trgtStr)
        {
            byte[] chars = new byte[26]; // Or char array
            int index;

            for (index = 0; index != srcStr.Length; index++)
            {
                chars[srcStr[index]  - 'a']++;
                chars[trgtStr[index] - 'a']--;
            }

            while (index < trgtStr.Length)
            {
                chars[trgtStr[index] - 'a']--;
                index++;
            }

            for (index = 0; index != 26; index++)
            {
                if (chars[index] != 0)
                {
                    return (char)('a' + index);
                }
            }
            return ' ';
        }

        public char FindTheDifference3XOR(string srcStr, string trgtStr)
        {
            int result = 0;

            foreach (char ch in srcStr)
                result ^= ch;

            foreach (char ch in trgtStr)
                result ^= ch;

            return (char)result;
        }

        // 383 https://leetcode.com/problems/ransom-note/description/
        public bool CanConstruct(string ransomNote, string magazine)
        {
            int[] chars = new int[26];

            for (int index = 0; index < magazine.Length; index++)
            {
                int pos = magazine[index] - 'a';
                chars[pos]++;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                int pos = ransomNote[i] - 'a';
                --chars[pos];

                if (chars[pos] < 0)
                    return false;
            }

            return true;
        }

        // 409 https://leetcode.com/problems/longest-palindrome/description/
        public int LongestPalindrome(string srcStr)
        {
            if (String.IsNullOrWhiteSpace(srcStr))
                return 0;

            Dictionary<char, int> charsDict = new Dictionary<char, int>();

            foreach (char ch in srcStr)
            {
                if (charsDict.ContainsKey(ch))
                    charsDict[ch] += 1;
                else
                    charsDict.Add(ch, 1);
            }

            int palCount = 0;

            foreach (KeyValuePair<char, int> keyPair in charsDict)
            {
                palCount += keyPair.Value;

                if (keyPair.Value % 2 != 0)
                    palCount -= 1;
            }

            return (palCount < srcStr.Length) ? palCount + 1 : palCount;
        }

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
            //MessageBox.Show("Max Length of Longest SubString Without Repeating Chars : " + maxDistinctChars.Count + " ");
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

            //MessageBox.Show("Max Length of Longest SubString Without Repeating Chars : " + maxStringLenght);
        }

    }
    public static class AnagramExtensions
    {
        // Using LINQ Sort word1, Sort word2 and compare both
        public static bool IsAnagramOf(this string word1, string word2)
        {
            return word1.OrderBy(x => x).SequenceEqual(word2.OrderBy(x => x));
        }
    }
}