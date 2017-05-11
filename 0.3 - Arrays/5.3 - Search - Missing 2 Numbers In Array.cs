
using System;
using System.Collections.Generic;
using System.Windows;
namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
    Problem:

    Given an array of natural numbers from 1 to n in an array where two numbers are missing. 
    So the given array size is n-2. 
    We have to find the two missing numbers.
    E.g. Numbers are 1..10 and 3,4 are missing. So Array length is 8. 
    
    Solution :

    1. Use extra O(n) Calculate the sum of n-2 numbers and sum of the n-2 numbers squared in one iteration. 
    
    As we know the  sum of all numbers from 1 to n is n * ( n + 1 ) / 2. 
    And the sum of all numbers squared from 1 to n is n * ( n + 1 ) * ( 2n + 1 ) / 6. 
    
    So we can find the sum and squared sum of the missing number by subtracting it from total sum and squared sum of n numbers. 
    
    So now we know a + b and a^2 + b^2. 
    
    From this we can calculate a and b, the two missing numbers.
    
    ===================================================================================================================================================================================================
    */
    partial class ArraySamples
    {
        public void GetTwoMissingNumbersTest()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 10; ++i)
            {
                list.Add(i);
            }

            list.Remove(3);
            list.Remove(4);

            int[] missing = GetTwoMissingNumbers(list);
            MessageBox.Show("Missing Number : " + missing[0] + "," + missing[1]);
        }

        private int[] GetTwoMissingNumbers(List<int> list)
        {
            int n = list.Count + 2;

            int actualExpectedSum = n * (n + 1) / 2;
            int actualExpectedSquaredSum = n * (n + 1) * (2 * n + 1) / 6;

            int currentSum = 0;
            int currentSquaredSum = 0;

            foreach (int num in list)
            {
                currentSum += num;
                currentSquaredSum += num * num;
            }

            int APlusBSum = actualExpectedSum - currentSum;
            int ASquarePlusBSquareSum = actualExpectedSquaredSum - currentSquaredSum;

            int TwoMultipleAB = APlusBSum * APlusBSum - ASquarePlusBSquareSum;

            int AminusB = (int)Math.Sqrt(ASquarePlusBSquareSum - TwoMultipleAB);

            int missinNum1 = (APlusBSum + AminusB) / 2;
            int missingNum2 = (APlusBSum - AminusB) / 2;

            return new int []{ missinNum1, missingNum2 };
        }

    }
}
