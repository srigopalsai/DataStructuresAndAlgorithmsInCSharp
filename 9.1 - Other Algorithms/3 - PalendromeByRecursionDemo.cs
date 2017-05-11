using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome1
{
    public class DataStructuresAndAlgorithms
    {
        // This method uses an iterative to analyze a string
        // and find out whether it is a palindrome
        private static bool Iterative(string strSubmitted)
        {
            int fromLeft;
            bool result = false;
            int fromRight = strSubmitted.Length - 1;

            if (strSubmitted.Length == 1)
                result = true;
            else
            {
                for (fromLeft = 0;
                    fromLeft < strSubmitted.Length;
                    fromLeft++, fromRight--)
                {
                    if (strSubmitted[fromLeft] == strSubmitted[fromRight])
                        result = true;
                    else
                        result = false;
                }
            }

            return result;
        }

        public static int RunDemo()
        {
            // This variable will be used to hold the result of a method
            bool isPalindrome = false;
            // This is the value the user will enter
            string Sentence = "";

            // Request a string from the user
            Console.Write("Enter a word or a sentence: ");
            Sentence = Console.ReadLine();

            isPalindrome = Iterative(Sentence.ToLower());

            // Find out whether the user-entered string was a palindrome
            // Display the result accordingly
            if (isPalindrome == true)
                Console.WriteLine(Sentence + " is a palindrome.\n");
            else
                Console.WriteLine(Sentence + " is not a palindrome.\n");

            return 0;
        }
    }
}