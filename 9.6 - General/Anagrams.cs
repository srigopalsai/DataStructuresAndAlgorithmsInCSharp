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
        public static bool IsAnagrams(string word1, string word2)
        {

            if (string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word2))
        {
            return false;
        }

        if (word1.Length != word2.Length)
        {
            return false;
        }

            
//var values = new Dictionary<char, int>();
//        foreach (char key in word1)
//        {
//            if (!values.ContainsKey(key))
//            {
//                values[key] = 1;
//            }
//            else
//            {
//                values[key] += 1;
//            }
//        }


            
//            fore
            return false;
        }
    }
}