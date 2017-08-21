using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
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
    public static class AnagramExtensions
    {
        // Using LINQ Sort and Comare.
        // Sort word1, Sort word2 and compare both
        public static bool IsAnagramOf(this string word1, string word2)
        {
            return word1.OrderBy(x => x).SequenceEqual(word2.OrderBy(x => x));
        }
    }

    partial class StringAlgorithms
    {
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
    }
}