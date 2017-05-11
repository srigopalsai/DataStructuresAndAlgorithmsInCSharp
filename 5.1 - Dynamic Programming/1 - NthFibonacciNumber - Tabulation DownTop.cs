using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    Time Complexity: O(Log n)
    Extra Space: O(Log n) if we consider the function call stack size, otherwise O(1).
    
    We can do recursive multiplication to get power(M, n)

  */
    partial class DynamicProgrammingSamples
    {
        // function that returns nth Fibonacci number
        static int Fib(int n)
        {
            int[][] F = new int[2][];
            F[0] = new int[2];
            F[1] = new int[2];

            // {{1,1},{1,0}};
            if (n == 0)
            {
                return 0;
            }
            power(F, n - 1);
            return F[0][0];
        }

        // Optimized version of power() in method 4
        static void power(int[][] F, int n)
        {
            if (n == 0 || n == 1)
            {
                return;
            }
            int[][] M = new int[2][];
            //= {{1,1},{1,0}};

            power(F, n / 2);
            multiply(F, F);

            if (n % 2 != 0)
            {
                multiply(F, M);
            }
        }
        static void multiply(int[][] F, int[][] M)
        {
            int x = F[0][0] * M[0][0] + F[0][1] * M[1][0];
            int y = F[0][0] * M[0][1] + F[0][1] * M[1][1];
            int z = F[1][0] * M[0][0] + F[1][1] * M[1][0];
            int w = F[1][0] * M[0][1] + F[1][1] * M[1][1];

            F[0][0] = x;
            F[0][1] = y;
            F[1][0] = z;
            F[1][1] = w;
        }
        
        //static int Fib(int n)
        //{
        //    // Declare an array to store fibonacci numbers.
        //    int[] f = new int[n + 1];

        //    // 0th and 1st number of the series are 0 and 1
        //    f[0] = 0;
        //    f[1] = 1;

        //    for (int i = 2; i <= n; i++)
        //    {
        //        // Add the previous 2 numbers in the series and store it
        //        f[i] = f[i - 1] + f[i - 2];
        //    }

        //    return f[n];
        //}

        static void NthFibonacciNumber(string[] args)
        {
            Dictionary<int, int> DP = new Dictionary<int, int>();
            DP[0] = 0;
            DP[1] = 1;

            MessageBox.Show("Nth Fibonacci number Demo " + Fib(5));
        }
    }
}