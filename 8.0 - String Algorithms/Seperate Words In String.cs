using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._9___String_Algorithms
{
    /*
    http://www.dsalgo.com/2013/02/SeparateWordsInSentence.php.html
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

}
