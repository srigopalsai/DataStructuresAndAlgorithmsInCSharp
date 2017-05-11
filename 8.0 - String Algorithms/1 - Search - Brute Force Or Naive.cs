using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    In text t and pattern p, Simply considers all possible starting positions i of a matching string within t, and compares p to the substring of t beginning at each such position i.
    The worst-case complexity of this algorithm is O((n-m+1) * m), where m denotes the length of p and n denotes the length of t.
    Brute Force also referred as Naive (basic) search.
      
    L P S- Longest Prefix Suffix 

    Natural Language Processing : https://www.youtube.com/watch?v=dctzCcYt4AM

    ===================================================================================================================================================================================================    
    */
    public partial class StringAlgorithms
    {
        HashSet<int> BruteForceOrNaiveSearch(string text, string pattern)
        {            
            char[] textArr = text.ToCharArray();
            char[] patternArr = pattern.ToCharArray();

            int nTextLenght = text.Length;
            int mPatternLenght = pattern.Length;

            HashSet<int> positionsFound = new HashSet<int>();

            // Repeat lool from 0 to Lenght of String - Pattern Lenght.
            for (int lpTextShiftIndex = 0; lpTextShiftIndex < (textArr.Length - patternArr.Length); lpTextShiftIndex++)
            {
                int lpPatIndex = 0; // Keep it out side to compare with lenght at the end of each check.
                for (; lpPatIndex < patternArr.Length; lpPatIndex++)
                {
                    //If any of pattern chars not match then break the innner loop.
                    if (textArr[lpTextShiftIndex + lpPatIndex] != patternArr[lpPatIndex])
                    {
                        break;
                    }
                }
                if (lpPatIndex == pattern.Length)
                {
                    positionsFound.Add(lpTextShiftIndex + 1);
                    
                }
            }
            return positionsFound;
        }
        
        public void BruteForceOrNaiveSearchDemo()
        {
            String text = "SaiSriMahi";
            
            MaxRepeatCharInString(text);

            String pattern = "Def";
            StringBuilder sb = new StringBuilder();

            HashSet<int> PositionsFound = BruteForceOrNaiveSearch(text, pattern);
            foreach (int position in PositionsFound)
            {
                sb.Append(position + ",  ");
            }

            MessageBox.Show("NaiveSearchAlgorithm Demo:\nThe text '" + pattern + "' is found at position(s) " + Convert.ToString(sb) );
        }
    }
}
