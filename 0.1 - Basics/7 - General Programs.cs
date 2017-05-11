using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    ===================================================================================================================================================================================================
    */
    partial class BinaryAndBitwiseOperations
    {
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
    }
}