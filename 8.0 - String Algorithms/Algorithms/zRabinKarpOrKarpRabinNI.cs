using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    
    Simple Randomized algorithm. 
    Run in linear time in most scenarios of practical interest.
    
    Worst Case Time 0(M X N) As bad as naive algorithm.    
    Best and Average Time O(N + M).
    

    Preprocessing phase in O(M) Time and O(1) Space
     
    Like the Naive Algorithm, Rabin-Karp algorithm also slides the pattern one by one. 
    But unlike the Naive algorithm, Rabin Karp algorithm matches the hash value of the pattern with the hash value of current substring of text,
    And if the hash values match then only it starts matching individual characters. 
     
    So Rabin Karp algorithm needs to calculate hash values for following strings.

    1) Pattern itself.
    2) All the substrings of text of length m. 
 
    */

    partial class StringAlgorithms
    {
        void RabinKarpOrKarpRabinNI(string text, int m, string pattern, int n)
        {
            int hx, hy, i, j;

            // Preprocessing Step 1.
            /* computes d = 2^(m-1) with the left-shift operator */
            for (int d = i = 1; i < m; ++i)
            {
                d = (d << 1);
            }
            
            // Preprocessing Step 2.
            for (hy = hx = i = 0; i < m; ++i)
            {
                hx = ((hx << 1) + text[i]);
                hy = ((hy << 1) + pattern[i]);
            }

            // Actual Search.
            //j = 0;
            //while (j <= n - m)
            //{
            //    if (hx == hy && memcmp(text, pattern + j, m) == 0)
            //    {
            //        OUTPUT(j);
            //    }
                
            //    hy = REHASH(pattern[j], pattern[j + m], hy);
            //    ++j;
            //}
        }
    }
}
