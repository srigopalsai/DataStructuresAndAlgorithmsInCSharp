using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    For a given problem, it is usually a good idea to check if DP is applicable to it.

    Dynamic Programming is a technique that takes advantage of overlapping subproblems, optimal substructure, and trades space for time to improve the runtime complexity of algorithms.
    
    2 types of Dynamic Programming: 

    1. Top-Down. (often called Memoization)
        Memoization is a technique that is associated with Dynamic Programming. 
        The concept is to cache the result of a function given its parameter so that the calculation will not be repeated; it is simply retrieved, or memo-ed. Most of the time a simple array is used for the cache table, but a hash table or map could also be employed.

        By saving the results of calculations when we do them and simply returning that result when asked for the same calcuation later. 
    
        array map [0...n] = { 0 => 0, 1 => 1 }
        fib( n )
        if ( map( n ) is cached )
            return map( n )
        return map( n ) = fib( n - 1 ) + fib( n - 2 )

    2. Bottom-Up. 
        We start from smaller cases and store the calculated values in a table for future use, an effective strategy to most dependency-based problems. 
        This avoids calculating the subproblem twice.
        
        fib( n )
            array map [0...n] = { 0 => 0, 1 => 1 }
            for ( i from 2 to n )
                map[i] = map[i-1] + map[i-2]
            return map[ n ]

    
    http://www.bogotobogo.com/Algorithms/dynamic_programming.php
    http://www.algorithmist.com/index.php/Dynamic_Programming
    http://www.geeksforgeeks.org/dynamic-programming-set-7-coin-change/
    http://www.codeproject.com/Articles/50054/The-Coin-Changing-Problem
    https://www.youtube.com/watch?v=GafjS0FfAC0&list=PL962BEE1A26238CA3
    http://comproguide.blogspot.com/2013/12/minimum-coin-change-problem.html
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Assume we have collection 1 Coins, 2 Coins and 3 Coins.
    
    Now we need minimum no of coins for the amount 5. 
    
    1. {1,1,1,1,1}  5 Coins.
    2. {2,2,1}      3 Coins.
    3. {3,2}        2 Coins. -- This is the solution.

    1. Optimal Sub Structure : 
       All sub problems solutions should be optimal
    
    2. Overlapping Sub Problem : (Recursion)

    C(P) = Min No Of Coins Required to make change for the amount P.
    
    P - Sum

    C(P) = Min { C(P-Vi)} + 1  Where i = 1...N
            i
    C(P) = Min { C(P-V1), C(P-V2), C(P-V3)......C(P-Vn)} + 1
            i
    V1 = 1, V2 = 2, V3 = 3

    C(0) = 0
    
    C(1) = Min { C(1 - 1) } + 1                     = 1 Coin.
            i
    
    C(2) = Min { C(2 - 1), C(2 - 2) } + 1     
            1
         = Min { 1, 0 } + 1                         = 1 Coin.
    
    C(3) = Min { C(3 - 1), C(3 - 2), C(3 - 3) } + 1     
            1
         = Min { C(2), C(1), C(0) } + 1             
         = Min {1, 1, 0} + 1                        = 1 Coin.      

    C(4) = Min { C(4 - 1), C(4 - 2), C(4 - 3) } + 1     
            1
         = Min { 1, 1, 1 } + 1                      = 2 Coins. 

    C(5) = Min { C(5 - 1), C(5 - 2), C(5 - 3) } + 1     
            1
         = Min { C(4), C(3), C2) } + 1
         = Min { 2, 1, 1 } + 1 
         = 1 + 1                                    = 2 Coins.

    C(5) = Min { C(6 - 1), C(6 - 2), C(6 - 3) } + 1     
            1

         = Min { C(5), C(4), C(3)) } + 1
         = Min { 2, 1, 1 } + 1 
         = 1 + 1                                    = 2 Coins.

    It shows that minimum no of coins required for each amount V1, V2, V3. Every sub problem is optimal.
    
    We can implement a dynamic programming algorithm in at least two different approaches. One is the top-down approach using memoization, the other is the bottom-up iterative approach.

    For a beginner to dynamic programming, Start with top-down approach first since this will help them understand the recurrence relationships in dynamic programming

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Memoization is a technique that is associated with Dynamic Programming. The concept is to cache the result of a function given its parameter so that the calculation will not be repeated; it is simply retrieved, or memo-ed. Most of the time a simple array is used for the cache table, but a hash table or map could also be employed. 


    A modified version of dynamic programming where, at the end, you work backwards to produce a solution. 
    E.g Instead of "find the least number of coins needed to make change" you would actually have to output the list of coins.
    Variants on this technique include producing the lexicographically-first solution when multiple solutions exist.

    */
    partial class DynamicProgrammingSamples
    {
        StringBuilder resultStringBldr = new StringBuilder();
        int GetMinimumCoins(int[] denominationCoins, int amountRequested)
        {
            int[] CoinsCount = new int[amountRequested + 1];
            int NoOfCoins = 0;

            int lpAmntIndx;
            int lpDenomIndx;
            int CoinsPos;

            // Loop for Total Amount Requested.
            for (lpAmntIndx = 1; lpAmntIndx <= amountRequested; lpAmntIndx++)
            {
                NoOfCoins = Int32.MaxValue;
                
                // Loop for No of Denomication Available.
                for (lpDenomIndx = 0; lpDenomIndx < denominationCoins.Length; lpDenomIndx++)
                {
                    // Coin value should not exceed the amount itself
                    if (denominationCoins[lpDenomIndx] <= lpAmntIndx)
                    {
                        CoinsPos = lpAmntIndx - denominationCoins[lpDenomIndx];
                        NoOfCoins = Math.Min(NoOfCoins, CoinsCount[CoinsPos]);
                    }
                }

                if (NoOfCoins < Int32.MaxValue)
                {
                    CoinsCount[lpAmntIndx] = NoOfCoins + 1;
                }
                else
                {
                    CoinsCount[lpAmntIndx] = Int32.MaxValue;
                }
            }

            NoOfCoins = CoinsCount[amountRequested];
            return NoOfCoins;
        }

        public void MinimumCoinsTest()
        {
            int NoOfDenominations = 5;
            
            int[] DenominationCoins = new int[NoOfDenominations];

            for (int lpDenomination = 0; lpDenomination < NoOfDenominations; lpDenomination++)
            {
                DenominationCoins[lpDenomination] = lpDenomination + 1;
            }
            int NoOfCoins = 0;
            
            NoOfCoins = GetMinimumCoins(DenominationCoins, 50);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 50 : " + NoOfCoins);
            
            NoOfCoins = GetMinimumCoins(DenominationCoins, 16);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 16 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 15);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 15 : " + NoOfCoins);
            
            NoOfCoins = GetMinimumCoins(DenominationCoins, 10);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 10 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 9);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 9 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 8);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 8 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 7);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 7 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 6);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 6 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 5);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 5 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 4);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 4 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 3);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 3 : " + NoOfCoins);
            
            NoOfCoins = GetMinimumCoins(DenominationCoins, 2);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 2 : " + NoOfCoins);

            NoOfCoins = GetMinimumCoins(DenominationCoins, 1);
            resultStringBldr.AppendLine("Minimum number of coins for Amount 1 : " + NoOfCoins);

            MessageBox.Show(Convert.ToString(resultStringBldr));
        }
    }
}