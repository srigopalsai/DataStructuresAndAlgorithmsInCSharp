using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================

    Input   : 7
    Output  : 13
                         V 
    0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144.

    Time : Exponential Time. O(2^n).
    Space: O(n) - Call Stack.

    If we notice here we will be repeating the same logic many times.

    Refer Dynamic Programming for O(n) Time with O(n) Space with out recursion.

    ============================================================================================================================================================================================================================

    */
    partial class RecursionSamples
    {
        int GenerateFibonacciSequence(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            //return GenerateFibonacciSequence(n - 1) + GenerateFibonacciSequence(n - 2);

            int nMinum1 = GenerateFibonacciSequence(n - 1);
            int nMinum2 = GenerateFibonacciSequence(n - 2);
            int result = nMinum1 + nMinum2;

            return result;
        }
        public void FibonacciSequenceTest()
        {
            int result = GenerateFibonacciSequence(7);
            MessageBox.Show("Fibonacci Sequence total for given num is " + result.ToString());
        }
    }
}