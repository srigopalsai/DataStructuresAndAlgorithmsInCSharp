/*
1. The Needleman-Wunsch algorithm, used in bioinformatics.
2. The CYK algorithm which is used the theory of formal languages and natural language processing.
3. The Viterbi algorithm used in relation to hidden Markov models.
4. Finding the string-edit distance between two strings, useful in writing spellcheckers.
5. The D/L method used in the sport of cricket.

http://en.wikipedia.org/wiki/Duckworth%E2%80%93Lewis_method
http://en.wikipedia.org/wiki/Levenshtein_distance
http://en.wikipedia.org/wiki/Viterbi_algorithm
http://en.wikipedia.org/wiki/CYK_algorithm
http://en.wikipedia.org/wiki/Needleman%E2%80%93Wunsch_algorithm
http://en.wikipedia.org/wiki/Hidden_Markov_model

http://www.geeksforgeeks.org/dynamic-programming-set-13-cutting-a-rod/


    http://www.algorithmist.com/index.php/Edit_Distance

    Edit Distance is a standard Dynamic Programming problem. 
    Given two strings s1 and s2, the edit distance between s1 and s2 is the minimum number of operations required to convert string s1 to s2. 
	
    The following operations are typically used:
        1. Replacing one character of string by another character.
        2. Deleting a character from string
        3. Adding a character to string

    Brute-Force Approach:

    If characters to be compared are equal i.e. s1[m] = s2[n], then we will compare (m+1)th character of s1 to (n+1)th character of s2 (if both exist).
    If we replace one character of string s1 then we will compare (m+1)th character of s1 to (n+1)th character of s2 (if both exist).
    If we insert one character to string s1 then we will compare mth character of s1 to (n+1)th character of s2 (if both exist).
    If we delete one character from string s1 then we will compare (m+1)th character of s1 to nth character of s2 (if both exist).

    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Pseudocode for edit distance can be written using recursion easily:

    int count(string s1, string s2, int m, int n)
    {
        if (n == s2.length()) 
        {
            return s1.length()-m;
        }
        if (m == s1.length())
        {  
            return s2.length()-n; 	
        }
        if (s1[m] == s2[n]) 
        {
            return count(s1,s2,m+1,n+1);
        }

        if (s1[m] != s2[n]) 
        {
            return 1+min(min(count(s1,s2,m,n+1), count(s1,s2,m+1,n)), count(s1,s2,m+1,n+1));
        }
    }
    
    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Dynamic Programming Approach:

    If we use Dynamic Programming, then we can find the Edit Distance in O( | s1 | * | s2 | ), here |s1| denote length of string s1 and |s2| denote length of string s2.
    Code for Edit Distance using dynamic programming is as follows:

    int count(string s1, string s2)
    {
            int m = s1.length();
            int n = s2.length();

            for (int i = 0; i <= m; i++) 
            {
                    v[i][0] = i;
            }
            for (int j = 0; j <= n; j++) 
            {
                    v[0][j] = j;
            }
 
            for (int i = 1; i <= m; i++) 
            {
                    for (int j = 1; j <= n; j++) 
                    {
                            if (s1[i] == s2[j]) 
                            {
                                v[i][j] = v[i-1][j-1];
                            }
                            else
                            {
                                v[i][j] = 1 + min(min(v[i][j-1],v[i-1][j]),v[i-1][j-1]);
                            }
                    }
            } 
            return v[m][n];
    }
    
    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    http://www.geeksforgeeks.org/dynamic-programming-set-11-egg-dropping-puzzle/

    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    http://www.dsalgo.com/2013/03/back-to-content-increasing-array.html

    Find all the subsequences of the array which has the elements in increasing order. 
    B is a subsequence of array A if B can be formed by removing some elements from the array A without disturbing the order of elements. 
    
    E.g. {2,5,6,1,3} is the input array, Then {2,5}, {2,6}, {2,6,1}, {2,1,3} are some of its subsequences. 
    In these {2,5}, {2,6} are increasing subsequences
    
    Using memorization.
    Then the complexity is O(n*k). The term k is the total possible subsequeces. Which is of the order of 2^n. 
    So in upper bound term it is O(n*2^n).
    But this complexity will only arises when all the subsequences are increasing subsequences.

    //public static void IncreasingArraySubSequence()
//{
//        int[] input = { 2, 5, 6, 1, 3 };
//  int length = input.Length;

 //   ArrayList < ArrayList < int > > table = new ArrayList < ArrayList < int > >();

 // for (int i = 0; i < length; ++i)
 // {
 //  ArrayList < ArrayList < Integer > > tempTable = new ArrayList < ArrayList < Integer > >();
 //  for (ArrayList < Integer > j : table)
 //  {
 //   if (j.get(j.size() - 1) <= input[i])
 //   {
 //    ArrayList temp = new ArrayList();
 //    temp.addAll(j);
 //    temp.add(input[i]);
 //    tempTable.add(temp);
 //   }
 //  }
 //  table.addAll(tempTable);
 //  ArrayList < Integer > temp = new ArrayList < Integer >();
 //  temp.add(input[i]);
 //  table.add(temp);
 // }

 // // output
 // for (ArrayList < Integer > i : table)
 // {
 //  for (Integer j : i)
 //  {
 //   System.out.print(j + ", ");
 //  }
 //  Console.WriteLine();
 // }
 //}

    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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

    http://www.algorithmist.com/index.php/Kadane%27s_Algorithm

    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
     KnapSackProblem

    http://www.bogotobogo.com/Algorithms/knapsack.php
    https://www.youtube.com/watch?v=1fDAOvgK11s
    https://www.youtube.com/watch?v=ImO-MbW5aCI
    https://www.youtube.com/watch?v=KdS780qvCS0

    http://www.geeksforgeeks.org/length-of-the-longest-arithmatic-progression-in-a-sorted-array/

    MaximumSubSequenceSum

    //http://www.geeksforgeeks.org/dynamic-programming-set-6-min-cost-path/
    //https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/MinCostPath.java
    //https://www.youtube.com/watch?v=lBRtnuxg-gU

    Rod Cutting
        https://www.youtube.com/watch?v=RYPsOJmhwgE

    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Subset Problem.

    http://www.geeksforgeeks.org/dynamic-programming-subset-sum-problem/
    http://www.algorithmist.com/index.php/Subset_Sum
    http://www.dsalgo.com/2013/02/back-to-content-find-subset-with-given.html

        http://www.geeksforgeeks.org/dynamic-programming-set-20-maximum-length-chain-of-pairs/
    http://analgorithmist.blogspot.com/2012/10/finding-pair-of-elements-with-maximum.html

        http://en.wikipedia.org/wiki/Viterbi_algorithm

    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*/