using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._8._1___Dynamic_Programming
{
    /*
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

    */
    class EditDistance
	{
	}
}
