using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    */

    partial class MathLogicSamples
    {
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 633. https://leetcode.com/problems/sum-of-square-numbers
        public bool JudgeSquareSum(int num)
        {
            if (num < 0)
                return false;

            int leftNum = 0;
            int rightNum = (int)Math.Sqrt(num);

            while (leftNum <= rightNum)
            {
                int cur = leftNum * leftNum + rightNum * rightNum;

                if (cur < num)
                {
                    leftNum++;
                }
                else if (cur > num)
                {
                    rightNum--;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public bool JudgeSquareSum2(int num)
        {
            // a*a + b*b = c;
            // b*b = c - a*a;

            for (int leftNum = 0; leftNum <= Math.Sqrt(num); leftNum++)
            {
                var rem = num - (leftNum * leftNum);
                var root = (int)Math.Sqrt(rem);

                if (rem == root * root)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPrimeNumber(int primeNumber)
        {
            for (int divisor = 2; divisor < primeNumber; divisor++)
            {
                if (divisor % primeNumber == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPalidromeNumber(int palindromeNumer)
        {
            int tempNumber = palindromeNumer;
            int reverseNumber = 0;

            float reminder = 0;
            float sumOfDigits = 0;

            while (tempNumber > 0)
            {
                reminder = tempNumber % 10;
                sumOfDigits = (reverseNumber * 10) + reminder;
                tempNumber = tempNumber / 10;
            }

            if (palindromeNumer == reverseNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        http://stackoverflow.com/questions/3980416/time-complexity-of-euclids-algorithm?rq=1
        Time Complexity : 
        http://en.wikipedia.org/wiki/Euclidean_algorithm#Algorithmic_efficiency
        The greatest common divisor is often written as gcd(a, b) or, more simply, as (a, b),[
        Synonyms for the GCD include the greatest common factor (GCF), the highest common factor (HCF), and the greatest common measure (GCM). 
        */

        public int EuclidsGcd(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        // 273 https://leetcode.com/problems/integer-to-english-words
        String[] LessThan20Pos = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        String[] TensPos       = {"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
        String[] ThousandsPos  = {"", "Thousand", "Million", "Billion"};

        public String NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            int index = 0;
            String words = string.Empty;

            while (num > 0)
            {
                if (num % 1000 != 0)
                {
                    words = GetWordHelper(num % 1000) + ThousandsPos[index] + " " + words;
                }

                num = num / 1000;
                index++;
            }

            return words.Trim();
        }

        private String GetWordHelper(int num)
        {
            string result = string.Empty;

            if (num == 0)
                return result;

            if (num < 20)
            {
                result = LessThan20Pos[num] + " ";
            }
            else if (num < 100)
            {
                result = TensPos[num / 10] + " ";
                result += GetWordHelper(num % 10);
            }
            else
            {
                result = LessThan20Pos[num / 100] + " Hundred ";
                result += GetWordHelper(num % 100);
            }

            return result;
        }

        public String NumberToWords2(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }
            return DigitToTextHelper(num);
        }

        private String DigitToTextHelper(int num)
        {
            String result = string.Empty;

            if (num < 20)
            {
                result = LessThan20Pos[num];
            }
            else if (num < 100)
            {
                result = TensPos[num / 10] + " ";

                result += DigitToTextHelper(num % 10);
            }
            else if (num < 1000)        // 3 Zeros
            {
                result = DigitToTextHelper(num / 100);
                result += " Hundred ";
                result += DigitToTextHelper(num % 100);
            }
            else if (num < 1000000)     // 6 Zeros
            {
                result = DigitToTextHelper(num / 1000);
                result += " Thousand ";
                result += DigitToTextHelper(num % 1000);
            }
            else if (num < 1000000000)  // 9 Zeros
            {
                result = DigitToTextHelper(num / 1000000);
                result += " Million "; 
                result += DigitToTextHelper(num % 1000000);
            }
            else
            {
                result = DigitToTextHelper(num / 1000000000);
                result += " Billion ";
                result += DigitToTextHelper(num % 1000000000);
            }

            return result.Trim();
        }
    }
}