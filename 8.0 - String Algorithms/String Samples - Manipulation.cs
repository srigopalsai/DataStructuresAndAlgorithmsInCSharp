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
    }
}