using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144.
   
    http://en.wikipedia.org/wiki/Fibonacci_number

    Time : O(n) Time with O(n) Space.

    If we notice here we are storing the previous logic for next iteration by using the Dynamic Programming technique.
    
    
    If we see the recursion technique.
    Time : Exponential Time. O(2^n).
    Space: O(n) - Call Stack.

    ===================================================================================================================================================================================================

    */
    partial class DynamicProgrammingSamples
    {
        int GenerateFibonacciSequence(int n)
        {
            int[] resultArray = new int[n + 1];

            resultArray[0] = 0;
            resultArray[1] = 1;

            for (int lpIndx = 2; lpIndx <= n ; lpIndx++)
            {
                resultArray[lpIndx] = resultArray[lpIndx - 2] + resultArray[lpIndx - 1];
            }

            return resultArray[n];
        }
        public void FibonacciSequenceTest()
        {
            int result = GenerateFibonacciSequence(7);
            MessageBox.Show("Fibonacci Sequence total for givne num is " + result.ToString());
        }
    }
}