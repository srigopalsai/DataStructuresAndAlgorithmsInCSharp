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

        http://www.careercup.com/question?id=3353669
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

        //-----------------------------------------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------------------------------------

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

        public static void MaxRepeatCharInString(string text)
        {

            IDictionary<char, int> charsWithTheirCnt = new Dictionary<char, int>();

            char MaxChar = '\0';
            int MaxCharCnt = 0;

            // O(n)
            for (int lpCnt = 0; lpCnt < text.Length; lpCnt++)
            {
                if (charsWithTheirCnt.ContainsKey(text[lpCnt]))
                {
                    charsWithTheirCnt[text[lpCnt]] = int.Parse(charsWithTheirCnt[text[lpCnt]].ToString()) + 1;

                    // Using Constant space to store the max char and max char count.
                    if (MaxCharCnt < charsWithTheirCnt[text[lpCnt]])
                    {
                        MaxCharCnt = charsWithTheirCnt[text[lpCnt]];
                        MaxChar = text[lpCnt];
                    }
                }
                else
                {
                    //O(1)
                    charsWithTheirCnt.Add(text[lpCnt], 1);
                }
            }

            // O(1) worst case O(n)
            KeyValuePair<char, int> maxRepeatChar = charsWithTheirCnt.FirstOrDefault(aa => aa.Value == charsWithTheirCnt.Values.Max());
            //MessageBox.Show("The character repated most no of times in given string is '" + maxRepeatChar.Key + "' and its count is " + maxRepeatChar.Value);

            Console.WriteLine("The character repated most no of times in given string is '" + MaxChar + "' and its count is " + MaxCharCnt);
        }

        //-----------------------------------------------------------------------------------------------------------------------
        /*
        Parentheses Balancing:
        Write a function which verifies parentheses are balanced in a string. 
        Each open parentheses should have a corresponding close parentheses and they should correspond correctly.
    
        E.g. 1: The function should return true for the following strings:
        (if (any? x) sum (/1 x))
        I said (it's not (yet) complete). (she didn't listen)

        E.g. 2: The function should return false for the following strings:
        :-)
        ())(   */
        public void AreParenthesesBalancedTest()
        {
            strBldr = new StringBuilder();

            bool result = false;
            result = AreParenthesesBalanced("(if (any? x) sum (/1 x))");
            strBldr.Append("\n1. if (any? x) sum (/1 x)) Result : " + result);

            result = AreParenthesesBalanced("I said (it's not (yet) complete). (she didn't listen)");
            strBldr.Append("\n2. I said (it's not (yet) complete). (she didn't listen) Result : " + result);

            result = AreParenthesesBalanced(":-)");
            strBldr.Append("\n3. :-) Result : " + result);

            result = AreParenthesesBalanced("())(");
            strBldr.Append("\n4. ())( Result : " + result);


            result = AreParenthesesBalancedRecursive("(if (any? x) sum (/1 x))", 0, 0);
            strBldr.Append("\n1. if (any? x) sum (/1 x)) Result : " + result);

            result = AreParenthesesBalancedRecursive("I said (it's not (yet) complete). (she didn't listen)", 0, 0);
            strBldr.Append("\n2. I said (it's not (yet) complete). (she didn't listen) Result : " + result);

            result = AreParenthesesBalancedRecursive(":-)", 0, 0);
            strBldr.Append("\n3. :-) Result : " + result);

            result = AreParenthesesBalancedRecursive("())(", 0, 0);
            strBldr.Append("\n4. ())( Result : " + result);

            /*
            for s in ["()", "(()", "(())", "()()", ")("]:
                print "{}: {}".format(s, AreParenthesesBalanced(s))
            */
            Console.WriteLine(strBldr.ToString());
        }

        public bool AreParenthesesBalanced(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new Exception("inputString cannot be null or empty");
            }

            if (inputString.Length > Int32.MaxValue)
            {
                throw new Exception("No of Open Paranthses allowed in string is " + Int64.MaxValue);
            }

            Int64 leftParenthesesCnt = 0;

            foreach (char inputChar in inputString)
            {
                if (inputChar == '(')
                {
                    leftParenthesesCnt++;
                }

                else if (inputChar == ')')
                {
                    if (leftParenthesesCnt > 0)
                    {
                        leftParenthesesCnt--;
                    }
                    else
                    {
                        // There are more right Paratheses than left.
                        return false;
                    }
                }
            }

            // There are more left Paratheses than right.
            return leftParenthesesCnt == 0 ? true : false;
        }

        public bool AreParenthesesBalancedRecursive(string inputString, int currentPosition, int leftParenthesesCnt)
        {
            // Base Conditions.
            // 1. Once visited all chars in string and if leftParenthesesCnt is zero then return true else return false.
            if (currentPosition == inputString.Length)
            {
                return leftParenthesesCnt == 0;
            }

            // 2. Found ')' more than '('. Or found ')' before '(' 
            if (leftParenthesesCnt < 0)
            {
                return false;
            }

            // 3. Visit each char in string linearly and call recursively by increasing the leftParenthesesCnt if '(' found or decreasing the leftParenthesesCnt.  
            // For general characters do not increment the leftParenthesesCnt.
            if (inputString[currentPosition] == '(')
            {
                return AreParenthesesBalancedRecursive(inputString, currentPosition + 1, leftParenthesesCnt + 1);

            }
            else if (inputString[currentPosition] == ')')
            {
                return AreParenthesesBalancedRecursive(inputString, currentPosition + 1, leftParenthesesCnt - 1);
            }
            else
            {
                // For general characters in the inputString.
                return AreParenthesesBalancedRecursive(inputString, currentPosition + 1, leftParenthesesCnt);
            }
        }

        //for (int lpCnt = 0; lpCnt < inputString.Length; lpCnt++)
        //{
        //    if (inputString[lpCnt] == '(')
        //    {
        //        leftParenthesesCnt++;
        //    }

        //    else if (inputString[lpCnt] == ')')
        //    {
        //        if (leftParenthesesCnt > 0)
        //        {
        //            leftParenthesesCnt--;
        //        }
        //        else
        //        {
        //            // There are more right Paratheses than left.
        //            return false;
        //        }
        //    }
        //}

        // 451 https://leetcode.com/problems/sort-characters-by-frequency/description/
        public string FrequencySort(string srcStr)
        {
            Dictionary<char, int> charsDict = new Dictionary<char, int>();

            foreach (char ch in srcStr)
            {
                if (charsDict.ContainsKey(ch))
                {
                    charsDict[ch] = charsDict[ch] + 1;
                }
                else
                {
                    charsDict[ch] = 1;
                }
            }

            List<char>[] bucket = new List<char>[srcStr.Length + 1];

            foreach (char key in charsDict.Keys)
            {
                int frequency = charsDict[key];

                if (bucket[frequency] == null)
                {
                    bucket[frequency] = new List<char>();
                }

                bucket[frequency].Add(key);
            }

            StringBuilder strBldr = new StringBuilder();

            for (int index = bucket.Length - 1; index >= 0; index--)
            {
                if (bucket[index] != null)
                {
                    foreach (char num in bucket[index])
                    {
                        for (int i = 0; i < charsDict[num]; i++)
                        {
                            strBldr.Append(num);
                        }
                    }
                }
            }

            return strBldr.ToString();
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