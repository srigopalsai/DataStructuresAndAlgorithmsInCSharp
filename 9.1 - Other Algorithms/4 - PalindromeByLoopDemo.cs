using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class PalindromeByLoopDemo
    {
        bool isPalindrome(string s, int len)
        {
            if (len <= 1)
            {
                return true;
            }
            else
            {
                return ((s[0] == s[len - 1]) && isPalindrome(s + 1, len - 2));
            }
        }
        /*
        What is the time complexity of this function in terms of Big-O notation?
        T(0) = 1 // base case
        T(1) = 1 // base case
        T(n) = 1 + T(n-2)// general case T(n-2) = 1 + T(n-4)
        T(n) = 2 + T(n-4)
        T(n) = 3 + T(n-6)
        T(n) = k + T(n-2k) ... n-2k = 1  k= (n-1)/2
        T(n) = (n-1)/2 + T(1)  O(n)
        */
        // This method uses an iterative to analyze a string and find out whether it is a palindrome.

        public static bool Iterative(string str)
        {
            int leftIndexPos;
            bool result = false;
            int rightIndexPos = str.Length - 1;

            if (str.Length == 1)
            {
                result = true;
            }
            else
            {
                for (leftIndexPos = 0; leftIndexPos < str.Length; leftIndexPos++, rightIndexPos--)
                {
                    if (str[leftIndexPos] == str[rightIndexPos])
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        public int RunPalindromTest()
        {
            // This variable will be used to hold the result of a method
            bool isPalindrome = false;
            // This is the value the user will enter
            string Sentence = "";

            // Request a string from the user
            Console.Write("Enter a word or a sentence: ");
            Sentence = Console.ReadLine();

            isPalindrome = Iterative(Sentence.ToLower());

            // Find out whether the user-entered string was a palindrome display the result accordingly
            if (isPalindrome == true)
            {
                Console.WriteLine(Sentence + " is a palindrome.\n");
            }
            else
            {
                Console.WriteLine(Sentence + " is not a palindrome.\n");
            }
            return 0;
        }
    }
}