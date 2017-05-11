using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    A Pythagorean triplet consists of 3 positive integers a, b, and c, such that a^2 + b^2 = c^2. 

    Such a triple is commonly written (a, b, c), and a well-known example is (3, 4, 5), (6, 8, 10)
    It is derived from pythagorean theorem.
    a < b < c 
    a = 3, b = 4, c= 5 
    9 + 16 = 25
    
    If 'c' denotes the length of the hypotenuse and 'a' and 'b' denote the lengths of the other two sides. 
    The Pythagorean theorem can be expressed as the Pythagorean equation : a^2 + b^2 = c^2, 

    If the length of both 'a' and 'b' are known, then 'c' can be calculated as : c = sqrt{a^2 + b^2}. 
    If the length of hypotenuse 'c' and one leg (a or b) are known, then the length of the other leg can find as : a = sqrt{c^2 - b^2}. or b = sqrt{c^2 - a^2}. 
    
    Given an un-sorted array and a value, find if there is a triplet in array whose sum is equal to the given value. 
    If there is such a triplet present in array, then print the triplet and return true. Else return false. 
    
    E.g. if the given array is {15, 4, 11, 5, 1, 9} and given sum is 15, then there is a triplet (4, 11 and 1) present in array whose sum is 15. 

    Steps:
    
    Pre Processing  : O(n)
    Search Logic    : O(n X n)

    1. Take extra O(N) space HashSet.
    2. Pre Process: Calculate square of each array element and store in HashSet.
        E.g. Input:     1   2   3   4   
        Pre Process     1   4   6   16
    3. Repeat 2 loops with O(N X N) and Calculate sum of current array element (main index) and square of its each next element in sub loop.
    ===================================================================================================================================================================================================
    */
    public partial class ArraySamples
    {
        static int[] ArrayNums = new int[] { 1, 5, 7, 3, 6, 8, 2, 4 };

        // O(N) Extra Space for Pre Processing
        static HashSet<Int64> CSquaredArrayNums = new HashSet<long>();

        public static String FindTripletInArray()
        {
            int NoOfElements = ArrayNums.Length;
            CSquaredArrayNums.Clear();

            // O(N) Time for Pre processing.
            for (int lpCnt = 0; lpCnt < NoOfElements ; lpCnt++)
            {
                // C square
                CSquaredArrayNums.Add(ArrayNums[lpCnt] * ArrayNums[lpCnt]);
            }
            
            StringBuilder resultStr = new StringBuilder();
            
            // O(N X N ) Time for finding the triplets.
            for (int lpMCnt = 0; lpMCnt < NoOfElements -1 ; lpMCnt++)
            {
                for (int lpSubCnt = lpMCnt + 1 ; lpSubCnt < NoOfElements; lpSubCnt++)
                {
                    // A Squae + B Square
                    long ASqrPlsBSqr = (ArrayNums[lpMCnt] * ArrayNums[lpMCnt]) + (ArrayNums[lpSubCnt] * ArrayNums[lpSubCnt]);
                    
                    // Best Case O (1) -> Contains
                    if (CSquaredArrayNums.Contains(ASqrPlsBSqr))
                    {
                        resultStr.Append("\n  " + ArrayNums[lpMCnt] + " Sqr  +  " + ArrayNums[lpSubCnt] + " Sqr =  " + Math.Sqrt(ASqrPlsBSqr) + " Sqr");
                    }
                }
            }

            return Convert.ToString(resultStr);
        }
    }
}