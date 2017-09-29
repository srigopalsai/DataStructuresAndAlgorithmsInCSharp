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
            Word Wrap:            http://www.sanfoundry.com/java-program-implement-word-wrap-problem/
            String Break:            http://algorithmstuff.wordpress.com/2013/10/14/string-break/
            Sorting:     http://www.sanfoundry.com/c-program-sort-names-alphabetical-order/

            Seperate Words in Sentence:  http://www.dsalgo.com/2013/02/SeparateWordsInSentence.php.html

            Implement Cut/Paste Functionality.

            Input:

            String      = "SaiSri" 
            Start       = 0
            Stop        = 2
            Destination = 5

            Output:     "SriSai"
    */

        //   public class SeparateWordsInSentence
        //   {
        //       public static void main(String[] args)
        //{
        // String sentence = "therearesomewordshiddenhere";
        // String[] dictionary =
        // { "the", "a", "i", "here", "so", "hid", "there", "are", "some", "word",
        //   "words", "hid", "hi", "hidden", "he", "here", "her", "rear",
        //   "me", "den" };
        // String[] words = getSeparatedWords(sentence, dictionary);
        // for (String word : words)
        //  Console.WriteLine(word);

        //}

        //       private static String[] getSeparatedWords(String sentence,
        //         String[] dictionary)
        //{
        // Set<String> validWords = new HashSet<String>();
        // for (String validWord : dictionary)
        //  validWords.add(validWord);
        // Stack<String> words = new Stack<String>();
        // if (isSeparable(sentence, validWords, 0, words))
        // {
        //  return words.toArray(new String[] {});
        // }
        // return null;
        //}

        //       private static boolean isSeparable(String sentence, Set<String> validWords,
        //         int startIndex, Stack<String> foundWords)
        //       {
        //           if (startIndex == sentence.length())
        //               return true;
        //           boolean hasWord = false;
        //           for (int i = startIndex + 1; i <= sentence.length(); ++i)
        //           {
        //               String currentSubstring = sentence.substring(startIndex, i);
        //               if (validWords.contains(currentSubstring))
        //               {
        //                   foundWords.push(currentSubstring);
        //                   if (isSeparable(sentence, validWords, i, foundWords))
        //                   {
        //                       hasWord = true;
        //                       break;
        //                   }
        //                   foundWords.pop();
        //               }
        //           }
        //           if (!hasWord)
        //               return false;
        //           return true;
        //       }
        //   }

        /*
===================================================================================================================================================================================================

Reverse the words in given strings.
E.g Input  : Hello     World
    Output : World     Hello

Time Complexity  O(2N) - [ O(N) Traversing entire array + O(N) Traversing each word again ]
Space Complexity O(N)

===================================================================================================================================================================================================

 */

        void RemoveAandIFromString(char[] s)
        {
            int p = 0;
            int i = 0;

            for (i = 0; s[i] != 0; i++)
            {
                if (s[i] == 'a' || s[i] == 'i')
                {
                    p++;
                }
                else
                {
                    s[i - p] = s[i];
                }
                // s[i - p] = 0;
                // MessageBox.Show(s);

            }
        }

        public static void ReverseWordsInString()
        {
            string newStr = string.Empty;
            string inputWord = "Hello   World";
            int strLen = inputWord.Length - 1;

            int wordChrLpCnt = 0;
            int wordChrsLen = strLen;

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

//            MessageBox.Show("Input String : " + inputWord + Environment.NewLine + "Output String : " + newStr);
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

        // LC 345 https://leetcode.com/problems/reverse-vowels-of-a-string/description/
        public string ReverseVowels(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            char[] chars = s.ToCharArray();

            int lPos = 0;
            int rPos = s.Length - 1;

            char temp = '\0';

            while (lPos < rPos)
            {
                bool isLCOvl = IsVowel(s[lPos]);
                bool isRCOvl = IsVowel(s[rPos]);

                if (isLCOvl == false)
                {
                    lPos++;
                    continue;
                }
                if (isRCOvl == false)
                {
                    rPos--;
                    continue;
                }

                temp = chars[lPos];
                chars[lPos] = chars[rPos];
                chars[rPos] = temp;

                lPos++;
                rPos--;
            }

            return new string(chars);
        }

        public bool IsVowel(char ch)
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' ||
               ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
                return true;
            else
                return false;
        }

        // 541 https://leetcode.com/problems/reverse-string-ii/description/
        public string ReverseStr(string srcStr, int k)
        {
            if (string.IsNullOrWhiteSpace(srcStr))
                return srcStr;

            int frwdIndx = 0;
            int bkwdIndx = 0;

            char[] chars = new char[srcStr.Length];
            int kPosIndx = Math.Min(k - 1, srcStr.Length - 1);

            while (frwdIndx < srcStr.Length)
            {
                for (bkwdIndx = kPosIndx; frwdIndx <= kPosIndx; bkwdIndx--)
                {
                    chars[frwdIndx] = srcStr[bkwdIndx];
                    frwdIndx++;
                }

                kPosIndx = Math.Min(kPosIndx + k, srcStr.Length - 1);

                while (frwdIndx <= kPosIndx)
                {
                    chars[frwdIndx] = srcStr[frwdIndx];
                    frwdIndx++;
                }

                kPosIndx = Math.Min(kPosIndx + k, srcStr.Length - 1);
            }

            return new string(chars);
        }

        // 434 https://leetcode.com/problems/number-of-segments-in-a-string/description/
        public int CountSegments(string srcStr)
        {
            if (string.IsNullOrWhiteSpace(srcStr))
                return 0;

            int spaceCnt = 0;

            for (int index = 0; index < srcStr.Length; index++)
            {
                if (srcStr[index] != ' ' && (index == 0 || srcStr[index - 1] == ' '))
                    spaceCnt++;
            }

            return spaceCnt;
        }

        // 125 https://leetcode.com/problems/valid-palindrome/description/

        public bool IsPalindrome(string srcStr)
        {
            if (string.IsNullOrWhiteSpace(srcStr))
                return true;

            int lftPos = 0;
            int rhtPos = srcStr.Length - 1;

            while (lftPos < rhtPos)
            {
                while (lftPos < rhtPos && !IsChar(srcStr[lftPos]))
                    lftPos++;
                while (lftPos < rhtPos && !IsChar(srcStr[rhtPos]))
                    rhtPos--;

                if (lftPos < rhtPos && srcStr[lftPos++] != srcStr[rhtPos--])
                    return false;
            }

            return true;
        }

        public bool IsChar(char ch)
        {
            return (ch >= '0' && ch <= '9') || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }

        public bool IsPalindrome1(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            s = s.ToLower();
            int lftPos = 0;
            int rhtPos = s.Length - 1;

            while (true)
            {
                while (lftPos <= rhtPos && !char.IsLetterOrDigit(s[lftPos]))
                    ++lftPos;

                while (rhtPos >= lftPos && !char.IsLetterOrDigit(s[rhtPos]))
                    --rhtPos;

                if (lftPos >= rhtPos)
                    return true;

                if (s[lftPos] != s[rhtPos])
                    return false;

                ++lftPos;
                --rhtPos;
            }
        }

        // LC 49 https://leetcode.com/problems/group-anagrams/discuss/
        public IList<IList<String>> GroupAnagrams(String[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return null;
            }

            Dictionary<string, List<String>> anagramMap = new Dictionary<string, List<string>>();

            foreach (String word in strs)
            {
                string key = GetKey(word); // Unique for each anagram

                if (anagramMap.ContainsKey(key) == false)
                {
                    anagramMap[key] = new List<string>();
                }

                anagramMap[key].Add(word);
            }

            return new List<IList<string>>(anagramMap.Values);
        }

        // Count Sort string. E.g. Input eat. Output aet
        public string GetKey(String srcStr)
        {
            int[] counters = new int[26];

            foreach (char ch in srcStr.ToCharArray())
            {
                counters[ch - 'a']++;
            }

            StringBuilder strBldr = new StringBuilder();

            for (int index = 0; index < counters.Length; index++)
            {
                int chrCnt = counters[index];

                for (int lpCnt = 0; lpCnt < chrCnt; lpCnt++)
                {
                    strBldr.Append((char)(index + 'a'));
                }
            }

            return strBldr.ToString();
        }

        public IList<IList<String>> GroupAnagramsUsingPrimes(String[] words)
        {
            //rod  7 * 97 * 11 // dye 7 * 61 *47
            int[] primes26 = {  02, 03, 05, 07, 11, 13, 17, 19, 23, 29,
                            31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
                            73, 79, 83, 89, 97, 101};

            List<IList<String>> resultLists = new List<IList<string>>();
            Dictionary<int, int> anagramDict = new Dictionary<int, int>();

            foreach (String word in words)
            {
                int uniqueKey = 1;

                foreach (char chr in word.ToCharArray())
                {
                    uniqueKey *= primes26[chr - 'a'];
                }

                if (anagramDict.ContainsKey(uniqueKey))
                {
                    resultLists[anagramDict[uniqueKey]].Add(word);
                }
                else
                {
                    List<String> newList = new List<string>();
                    newList.Add(word);

                    anagramDict[uniqueKey] = resultLists.Count;
                    resultLists.Add(newList);
                }
            }
            return resultLists;
        }

        // 415 Implement LargeInt Additions https://leetcode.com/problems/add-strings/description/
        public String AddStrings(String num1Str, String num2Str)
        {
            StringBuilder strBldr = new StringBuilder();

            int num1 = 0;
            int num2 = 0;

            int num1Indx = num1Str.Length - 1;
            int num2Indx = num2Str.Length - 1;

            int carry = 0;
            int curSum = 0;

            while ( num1Indx >= 0 || num2Indx >= 0 || carry == 1)
            {
                num1 = num1Indx < 0 ? 0 : num1Str[num1Indx] - '0';
                num2 = num2Indx < 0 ? 0 : num2Str[num2Indx] - '0';

                curSum = num1 + num2 + carry;

                strBldr.Append(curSum % 10);
                carry = curSum / 10;

                num1Indx--;
                num2Indx--;
            }

            return  new string(strBldr.ToString().Reverse().ToArray());
        }

        public string AddStrings2(string num1Str, string num2Str)
        {
            StringBuilder strBldr = new StringBuilder();
            int q = 0;
            int c = 0;

            int num1Len = num1Str.Length;
            int num2Len = num2Str.Length;

            for (int index = 0; index < Math.Max(num1Len, num2Len); index++)
            {
                int da = index < num1Len ? num1Str[num1Len - index - 1] - '0' : 0;
                int db = index < num2Len ? num2Str[num2Len - index - 1] - '0' : 0;

                c = da + db + q;

                strBldr.Append((char)((int)'0' + (c % 10)));

                q = c / 10;
            }

            if (q > 0)
            {
                strBldr.Append('1');
            }

            return new string(strBldr.ToString().Reverse().ToArray());
        }
    }
}