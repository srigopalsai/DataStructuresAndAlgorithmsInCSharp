using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    
    Fibonacci Series using Dynamic Programming.

    Read Notes.docx for more information about Dynamic Programming.

    Dynamic Programming combines solutions to sub-problems. 
    Dynamic Programming is mainly used when solutions of same subproblems are needed again and again. 

    In dynamic programming, computed solutions to subproblems are stored in a table so that these don’t have to recomputed. 
    
    Dynamic Programming is not useful when there are no common (overlapping) subproblems because there is no point storing the solutions if they are not needed again. 
    E.g. Binary Search doesn’t have common subproblems.
    
    Dynamic programming problems must have both 
    
    1. Overlapping Sub-Problems
    2. Optimal Substructure. 

    Generating the Fibonacci sequence is not a dynamic programming problem.
    It utilizes memoization because it has overlapping sub-problems, but it does not have optimal substructure (because there is no optimization problem involved).
    
    */
    partial class DynamicProgrammingSamples
    {
        static int FibMemorizationVersion(int n, Dictionary<int, int> DP)
        {
            if (DP.ContainsKey(n))
            {
                return DP[n];
            }

            int num1 = FibMemorizationVersion(n - 1, DP);

            int num2 = FibMemorizationVersion(n - 2, DP);

            DP[n] = num1 + num2;

            return DP[n];
        }

        static void NthFibonacciNumberDemo(string[] args)
        {
            Dictionary<int, int> DP = new Dictionary<int, int>();
            
            DP[0] = 0;
            DP[1] = 1;

            MessageBox.Show("Nth Fibonacci number Demo " + FibMemorizationVersion(5, DP));
        }
    }
}
