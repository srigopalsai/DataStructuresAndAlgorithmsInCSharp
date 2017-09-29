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
                chars[srcStr[index] - 'a']++;
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
        // 20 https://leetcode.com/problems/valid-parentheses/description/
        
        public bool IsValid(String srcStr)
        {
            int c1Cntr = 0;
            int c2Cntr = 0;
            int c3Cntr = 0;

            for (int index = 0; index < srcStr.Length; index++)
            {
                if (srcStr[index] == '(')
                {
                    if ((index < srcStr.Length - 1) && ((srcStr[index + 1] == '}') || (srcStr[index + 1] == ']')))
                    {
                        return false;
                    }
                    c1Cntr++;
                }
                else if (srcStr[index] == '[')
                {
                    if ((index < srcStr.Length - 1) && ((srcStr[index + 1] == '}') || (srcStr[index + 1] == ')')))
                    {
                        return false;
                    }
                    c2Cntr++;
                }
                else if (srcStr[index] == '{')
                {
                    if ((index < srcStr.Length - 1) && ((srcStr[index + 1] == ')') || (srcStr[index + 1] == ']')))
                    {
                        return false;
                    }
                    c3Cntr++;
                }
                if (srcStr[index] == ')')
                {
                    c1Cntr--;
                }
                else if (srcStr[index] == ']')
                {
                    c2Cntr--;
                }
                else if (srcStr[index] == '}')
                {
                    c3Cntr--;
                }
                if (c1Cntr < 0 || c2Cntr < 0 || c3Cntr < 0)
                {
                    return false;
                }
            }

            if (c1Cntr != 0 || c2Cntr != 0 || c3Cntr != 0)
            {
                return false;
            }
            return true;
        }

        //bool IsValid(string srcStr)
        //{
        //    int top = -1;

        //    for (int i = 0; i < srcStr.Length; ++i)
        //    {
        //        if (top < 0 || !IsMatch(srcStr[top], srcStr[i]))
        //        {
        //            ++top;
        //            srcStr[top] = srcStr[i];
        //        }
        //        else
        //        {
        //            --top;
        //        }
        //    }
        //    return top == -1;
        //}
        //bool IsMatch(char c1, char c2)
        //{
        //    if (c1 == '(' && c2 == ')')
        //        return true;
        //    if (c1 == '[' && c2 == ']')
        //        return true;
        //    if (c1 == '{' && c2 == '}')
        //        return true;
        //    return false;
        //}

        public bool isValid(String srcStr)
        {
            char[] stack = new char[srcStr.Length];
            int head = 0;

            foreach (char ch in srcStr.ToCharArray())
            {
                switch (ch)
                {
                    case '{':
                    case '[':
                    case '(':
                        stack[head++] = ch;
                        break;
                    case '}':
                        if (head == 0 || stack[--head] != '{')
                            return false;
                        break;
                    case ')':
                        if (head == 0 || stack[--head] != '(')
                            return false;
                        break;
                    case ']':
                        if (head == 0 || stack[--head] != '[')
                            return false;
                        break;
                }
            }
            return head == 0;

        }
        public bool IsValid2(String srcStr)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char ch in srcStr.ToCharArray())
            {
                if (ch == '(')
                {
                    stack.Push(')');
                }
                else if (ch == '{')
                {
                    stack.Push('}');
                }
                else if (ch == '[')
                {
                    stack.Push(']');
                }
                else if (stack.Count == 0 || stack.Pop() != ch)
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }

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

        // 32 https://leetcode.com/problems/longest-valid-parentheses/description/
        // O(n) Time O(1) Space
        public int LongestValidParentheses3(string srcStr)
        {
            int longest = 0;
            int extra = 0;
            int length = 0;

            for (int index = 0; index < srcStr.Length; index++)
            {
                GetLongestStr(srcStr, index, '(', ref extra, ref length, ref longest);
            }

            length = 0;
            extra = 0;

            for (int index = srcStr.Length - 1; index >= 0; index--)
            {
                GetLongestStr(srcStr, index, ')', ref extra, ref length, ref longest);
            }
            return longest;
        }

        private void GetLongestStr(string srcStr, int index, char ch, ref int extra, ref int length, ref int longest)
        {
            if (srcStr[index] == ch)
            {
                extra++;
                length++;
            }
            else
            {
                if (extra > 0)
                {
                    extra--;
                    length++;
                    if (extra == 0)
                    {
                        longest = Math.Max(longest, length);
                    }
                }
                else
                {
                    extra = 0;
                    length = 0;
                }
            }
        }

        // O(n) Time and Space
        public int LongestValidParentheses(String srcStr)
        {
            Stack<int> stack = new Stack<int>();

            int result = 0;
            stack.Push(-1);

            for (int index = 0; index < srcStr.Length; index++)
            {
                if (srcStr[index] == ')' && stack.Count > 1 && srcStr[stack.Peek()] == '(')
                {
                    stack.Pop();
                    result = Math.Max(result, index - stack.Peek());
                }
                else
                {
                    stack.Push(index);
                }
            }
            return result;
        }

        // Dynamic programming O(n) Time and Space
        // https://leetcode.com/problems/longest-valid-parentheses/description/
        // https://leetcode.com/articles/longest-valid-parentheses/
        public int LongestValidParentheses2(String srcStr)
        {
            int result = 0;

            int[] dnyPr = new int[srcStr.Length];

            for (int index = 1; index < srcStr.Length; index++)
            {
                if (srcStr[index] == ')')
                {
                    if (srcStr[index - 1] == '(')
                    {
                        dnyPr[index] = (index >= 2 ? dnyPr[index - 2] : 0) + 2;
                    }
                    else if (index - dnyPr[index - 1] > 0 && srcStr[index - dnyPr[index - 1] - 1] == '(')
                    {
                        dnyPr[index] = dnyPr[index - 1] + ((index - dnyPr[index - 1]) >= 2 ? dnyPr[index - dnyPr[index - 1] - 2] : 0) + 2;
                    }

                    result = Math.Max(result, dnyPr[index]);
                }
            }
            return result;
        }

        /*
                int longestValidParentheses(string s)
        {
            int result = 0;

            int left = 0;
            int right = 0;

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(': left++; break;
                    case ')': right++; break;
                    default: left = right = 0; continue;
                }

                if (left == right && left + right > result)
                    result = left + right;
                if (right > left)
                    left = right = 0;
            }

            left = 0;
            right = 0;
            for (int i = s.Length; i > 0; i--)
            {
                switch (s[i - 1])
                {
                    case '(': left++; break;
                    case ')': right++; break;
                    default: left = right = 0; continue;
                }
                if (left == right && left + right > result) result = left + right;
                if (left > right) left = right = 0;
            }

            return result;
        }

        int longestValidParentheses2(string s)
        {
            int result = 0;
            int ll = 0, lr = 0, li = 0;  // left paren sum, right paren sum, left index
            int rl = 0, rr = 0, ri = s.Length;  // left paren sum, right paren sum, right index

            while (li < s.Length && ri > 0)
            {
                switch (s[li])
                {
                    case '(': ll++; break;
                    case ')': lr++; break;
                    default: ll = lr = 0; break;
                }
                switch (s[ri - 1])
                {
                    case '(': rl++; break;
                    case ')': rr++; break;
                    default: rl = rr = 0; break;
                }

                if (ll == lr && ll + lr > result)
                    result = ll + lr;

                if (rl == rr && rl + rr > result)
                    result = rl + rr;

                if (ll < lr)
                    ll = lr = 0;

                if (rl > rr)
                    rl = rr = 0;

                li++;
                ri--;
            }
            return result;
        }
        */

        //https://discuss.leetcode.com/topic/9390/c-o-n-m-solution-using-kmp/2
        public bool IsMatch(String srcStr, String matchStr)
        {
            bool[,] matchMatrix = new bool[srcStr.Length + 1, matchStr.Length + 1];

            matchMatrix[srcStr.Length, matchStr.Length] = true;

            for (int index = matchStr.Length - 1; index >= 0; index--)
            {
                if (matchStr[index] != '*')
                {
                    break;
                }
                else
                {
                    matchMatrix[srcStr.Length, index] = true;
                }
            }

            for (int rIndx = srcStr.Length - 1; rIndx >= 0; rIndx--)
            {
                for (int cIndx = matchStr.Length - 1; cIndx >= 0; cIndx--)
                {
                    if (srcStr[rIndx] == matchStr[cIndx] || matchStr[cIndx] == '?')
                    {
                        matchMatrix[rIndx, cIndx] = matchMatrix[rIndx + 1, cIndx + 1];
                    }
                    else if (matchStr[cIndx] == '*')
                    {
                        matchMatrix[rIndx, cIndx] = matchMatrix[rIndx + 1, cIndx] || matchMatrix[rIndx, cIndx + 1];
                    }
                    else
                    {
                        matchMatrix[rIndx, cIndx] = false;
                    }
                }
            }

            return matchMatrix[0, 0];
        }

        public bool isMatch(String srcStr, String matchStr)
        {
            int srcStrIndx = 0;
            int matchStrIndx = 0;
            int marked = -1;

            String p2 = matchStr + '^'; // In case that the last char in matchStr is *

            while (srcStrIndx < srcStr.Length && matchStrIndx < p2.Length)
            {
                if (srcStr[srcStrIndx] == p2[matchStrIndx] || p2[matchStrIndx] == '?')
                {
                    srcStrIndx++;
                    matchStrIndx++;
                }
                else if (p2[matchStrIndx] == '*')
                {
                    matchStrIndx++;
                    marked = matchStrIndx;
                }
                else
                {
                    if (matchStrIndx == marked)
                    {
                        srcStrIndx++;
                    }
                    else
                    {
                        if (marked != -1)
                        {
                            srcStrIndx = srcStrIndx - (matchStrIndx - marked - 1);
                            matchStrIndx = marked;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            while (matchStrIndx < matchStr.Length)
            {
                if (matchStr[matchStrIndx] != '*')
                {
                    return false;
                }
                matchStrIndx++;
            }

            return srcStrIndx >= srcStr.Length;
        }

        // https://leetcode.com/problems/longest-increasing-subsequence/description/
        // https://en.wikipedia.org/wiki/Diff_utility
        // https://en.wikipedia.org/wiki/Patience_sorting
        //NP-Hard https://en.wikipedia.org/wiki/Longest_common_subsequence_problem
        public int LongestCommonSubSequence(String word1, String word2)
        {
            int longest = LongestCommonSubSequenceHelper(word1, word2);

            return word1.Length - longest + word2.Length - longest;
        }

        private int LongestCommonSubSequenceHelper(String word1, String word2)
        {
            int[,] lkUpMtrx = new int[word1.Length + 1, word2.Length + 1];

            int maxLength = 0;

            for (int rIndx = 1; rIndx <= word1.Length; rIndx++)
            {
                for (int cIndx = 1; cIndx <= word2.Length; cIndx++)
                {
                    if (word1[rIndx - 1] == word2[cIndx - 1])
                    {
                        lkUpMtrx[rIndx, cIndx] = lkUpMtrx[rIndx - 1, cIndx - 1] + 1;
                    }
                    else
                    {
                        lkUpMtrx[rIndx, cIndx] = Math.Max(lkUpMtrx[rIndx - 1, cIndx], lkUpMtrx[rIndx, cIndx - 1]);
                    }

                    maxLength = Math.Max(lkUpMtrx[rIndx, cIndx], maxLength);
                }
            }

            return maxLength;
        }

        // 522 https://leetcode.com/problems/longest-uncommon-subsequence-ii/description/
        public int FindLUSlength(String[] srcStr)
        {
            //Arrays.sort(strs);
            int result = -1;

            for (int indexI = 0; indexI < srcStr.Length; indexI++)
            {
                int indxJ = 0;

                while(indxJ < srcStr.Length)
                {
                    if (indexI == indxJ)
                    {
                        continue;
                    }
                    if (IsSubseq(srcStr[indexI], srcStr[indxJ]))
                    {
                        break;
                    }
                    indxJ++;
                }

                if (indxJ == srcStr.Length)
                {
                    result = Math.Max(result, srcStr[indexI].Length);
                }
            }
            return result;
        }

        private bool IsSubseq(String srcStr, String trgtStr)
        {
            int indxSrc = 0;
            int indxTrgt = 0;

            while (indxSrc < srcStr.Length && indxTrgt < trgtStr.Length)
            {
                if (srcStr[indxSrc] == trgtStr[indxTrgt])
                {
                    indxSrc++;
                    indxTrgt++;
                }
                else
                {
                    indxTrgt++;
                }
            }

            return indxSrc == srcStr.Length;
        }

        // O (n/2)
        public static bool IsPalindromeString(string srcStr)
        {
            if (string.IsNullOrEmpty(srcStr))
                return true;

            int lIndx = 0;
            int rIndx = srcStr.Length - 1;

            while (lIndx <= rIndx)
            {
                if (srcStr[lIndx] != srcStr[rIndx])
                {
                    break;
                }
                lIndx++;
                rIndx--;
            }
            if (lIndx > rIndx)
            {
                return true;
            }
            return false;
        }

        /*
        The time complexity of this function in terms of Big-O notation?
        T(0) = 1 // base case
        T(1) = 1 // base case
        T(n) = 1 + T(n-2)// general case T(n-2) = 1 + T(n-4)
        T(n) = 2 + T(n-4)
        T(n) = 3 + T(n-6)
        T(n) = k + T(n-2k) ... n-2k = 1  k= (n-1)/2
        T(n) = (n-1)/2 + T(1)  O(n)
        */

        bool IsPalindromeRecursive(string srcStr, int rIndx)
        {
            if (rIndx <= 1)
            {
                return true;
            }
            else
            {
                return (srcStr[0] == srcStr[rIndx - 1] && 
                    IsPalindromeRecursive(srcStr + 1, rIndx - 2));
            }
        }

        // https://leetcode.com/problems/longest-palindromic-subsequence/description/
        public int LongestPalindromeSubseq(String srcStr)
        {
            int[,] dpLkUp = new int[srcStr.Length, srcStr.Length];

            for (int index = srcStr.Length - 1; index >= 0; index--)
            {
                dpLkUp[index, index] = 1;

                for (int indxJ = index + 1; indxJ < srcStr.Length; indxJ++)
                {
                    if (srcStr[index] == srcStr[indxJ])
                    {
                        dpLkUp[index, indxJ] = dpLkUp[index + 1, indxJ - 1] + 2;
                    }
                    else
                    {
                        dpLkUp[index, indxJ] = Math.Max(dpLkUp[index + 1, indxJ],
                                                        dpLkUp[index, indxJ - 1]);
                    }
                }
            }

            return dpLkUp[0, srcStr.Length - 1];
        }

        // 65 https://leetcode.com/problems/valid-number/description/
        public bool IsNumber(String srcStr)
        {
            srcStr = srcStr.Trim();

            bool pointSeen = false;
            bool eSeen = false;

            bool numberSeen = false;
            bool numberAfterE = true;

            for (int index = 0; index < srcStr.Length; index++)
            {
                if ('0' <= srcStr[index] && srcStr[index] <= '9')
                {
                    numberSeen = true;
                    numberAfterE = true;
                }
                else if (srcStr[index] == '.')
                {
                    if (eSeen ==true || pointSeen == true)
                    {
                        return false;
                    }
                    pointSeen = true;
                }
                else if (srcStr[index] == 'e')
                {
                    if (eSeen == true|| !numberSeen == true)
                    {
                        return false;
                    }

                    numberAfterE = false;
                    eSeen = true;
                }

                else if (srcStr[index] == '-' || srcStr[index] == '+')
                {
                    if (index != 0 && srcStr[index - 1] != 'e')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return numberSeen && numberAfterE;
        }

        // 125 https://leetcode.com/problems/valid-palindrome/description/
        public bool IsPalindrome2(String s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return true;
            }

            int head = 0;
            int tail = s.Length - 1;

            while (head <= tail)
            {
                if (!Char.IsLetterOrDigit(s[head]))
                {
                    head++;
                }
                else if (!Char.IsLetterOrDigit(s[tail]))
                {
                    tail--;
                }
                else
                {
                    if (Char.ToLower(s[head]) != Char.ToLower(s[tail]))
                    {
                        return false;
                    }
                    head++;
                    tail--;
                }
            }

            return true;
        }

        // 680 https://leetcode.com/problems/valid-palindrome-ii/description/
        public bool ValidPalindrome(String s)
        {
            int i = 0, j = s.Length - 1;

            while (i < j && s[i] == s[j])
            {
                i++; j--;
            }

            if (i >= j)
            {
                return true;
            }

            if (IsPalin(s, i + 1, j) || IsPalin(s, i, j - 1))
            {
                return true;
            }

            return false;
        }

        private bool IsPalin(String s, int i, int j)
        {
            while (i < j)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        // 409 https://leetcode.com/problems/longest-palindrome/discuss/
        public int LongestPalindrome1(String s)
        {
            int[] lowercase = new int[26];
            int[] uppercase = new int[26];
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char temp = s[i];
                if (temp >= 97) lowercase[temp - 'a']++;
                else uppercase[temp - 'A']++;
            }
            for (int i = 0; i < 26; i++)
            {
                res += (lowercase[i] / 2) * 2;
                res += (uppercase[i] / 2) * 2;
            }
            return res == s.Length ? res : res + 1;
        }

        public int LongestPalindrome2(String s)
        {
            if (s == null || s.Length == 0)
                return 0;

            HashSet<Char> hs = new HashSet<Char>();
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (hs.Contains(s[i]))
                {
                    hs.Remove(s[i]);
                    count++;
                }
                else
                {
                    hs.Add(s[i]);
                }
            }

            if (hs.Count > 0)
            {
                return count * 2 + 1;
            }

            return count * 2;
        }

        // 647 https://leetcode.com/problems/palindromic-substrings/description/
        int count = 0;

        public int CountSubstrings(String s)
        {
            count = 0;
            if (s == null || s.Length == 0) return 0;

            for (int i = 0; i < s.Length; i++)
            {
                ExtendPalindrome(s, i, i); // odd length;
                ExtendPalindrome(s, i, i + 1); // even length
            }

            return count;
        }

        private void ExtendPalindrome(String s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                count++;
                left--;
                right++;
            }
        }

        //43 https://leetcode.com/problems/multiply-strings/description/
        public String Multiply(String num1Str, String num2Str)
        {
            int num1StrLen = num1Str.Length;
            int num2StrLen = num2Str.Length;

            int[] positions = new int[num1StrLen + num2StrLen];

            for (int i = num1StrLen - 1; i >= 0; i--)
            {
                for (int j = num2StrLen - 1; j >= 0; j--)
                {
                    int mul = (num1Str[i] - '0') * (num2Str[j] - '0');
                    int p1 = i + j;
                    int p2 = i + j + 1;
                    int sum = mul + positions[p2];

                    positions[p1] += sum / 10;
                    positions[p2] = (sum) % 10;
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (int pos in positions)
            {
                if (pos != 0)
                {
                    sb.Append(pos);
                }
            }

            return sb.Length == 0 ? "0" : sb.ToString();
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