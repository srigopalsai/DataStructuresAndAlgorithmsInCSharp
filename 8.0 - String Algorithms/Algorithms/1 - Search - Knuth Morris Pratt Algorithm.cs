using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    http://ideone.com/qiSrUo
    http://stackoverflow.com/questions/22615838/string-matching-computing-the-longest-prefix-suffix-array-in-kmp-algorithm
    http://www.ics.uci.edu/~eppstein/161/960227.html
    Text      : banana 
    Pattern   : na

    KMP: Worst case running time is linear, i.e., O( m + n)
    KMP matching algorithm uses degenerating property (pattern having same sub-patterns appearing more than once in the pattern) of the pattern.
     Lenght of Longest Prefix is the proper suffix of PK  ( Pattern with lenght K)
    
    The Knuth-Morris-Pratt (KMP) algorithm is a good choice if we want to search for the same pattern repeatedly in many different texts.
    http://en.wikipedia.org/w/index.php?title=Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm&oldid=68814731
    http://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
    */

    //Not working as working as expected
    partial class StringAlgorithms
     {
        static int[] ComputePrefixFunction(string Patter2Search)
        {
            int patternStrLenght = Patter2Search.Length;
            int[] skipIndxTbl = new int[patternStrLenght];

            int skipIndx = 0;

            skipIndxTbl[0] = 0;

            for (int lpCnt = 1; lpCnt < patternStrLenght; lpCnt++)
            {
                while (skipIndx > 0 && Patter2Search[skipIndx] != Patter2Search[lpCnt])
                {
                    skipIndx = skipIndxTbl[skipIndx];
                }

                if (Patter2Search[skipIndx] == Patter2Search[lpCnt])
                {
                    skipIndx++;
                }

                skipIndxTbl[lpCnt] = skipIndx;
            }
            return skipIndxTbl;
        }

        static void KnuthMorrisPrattSearch(string TextString, string Patter2Search)
        {
            int nTextLength = TextString.Length;
            int mPatternLength = Patter2Search.Length;

            int[] preProcTbl = ComputePrefixFunction(Patter2Search);
            int patIndx = 0;

            for (int lptextIndx = 1; lptextIndx <= nTextLength; lptextIndx++)
            {
                while (patIndx > 0 && Patter2Search[patIndx] != TextString[lptextIndx - 1])
                {
                    patIndx = preProcTbl[patIndx - 1];
                }
                if (Patter2Search[patIndx] == TextString[lptextIndx - 1])
                {
                    patIndx++;
                }
                if (patIndx == mPatternLength)
                {
                    //Record a match was found here  
                    patIndx = preProcTbl[patIndx - 1];
                    MessageBox.Show("Knuth Morris Pratt Search :\nThe text '" + Patter2Search + "' is first found after the " + patIndx + " position.");
                }
            }
        }

        public static void RunKnuthMorrisPrattSearchDemo()
        {
            String text = "Abc Def Ghi Jkl Mno";
            String pattern = "Ghi";

            KnuthMorrisPrattSearch(text, pattern);
        }
    }      
}
/*  {
        public int[] prekmp(String pattern) 
        {
            int[] next = new int[pattern.Length];
            int i=0, j=-1;
            next[0]=-1;
            while (i	&&		while (j>=0 && pattern.charAt(i)!=pattern.charAt(j))
                    j = next[j];
                i++; 
                j++;
                next[i] = j;
            }
            return next;
        }
	
        public int kmp(String text, String pattern) 
        {
            int[] next = prekmp(pattern);
            int i=0, j=0;
            while (i			while (j>=0 && text.charAt(i)!=pattern.charAt(j))
                    j = next[j];
                i++; j++;
                if (j==pattern.length()) return i-pattern.length();
            }
            return -1;
        }

    }

    public class Test {
        public static void main(String[] args) {
            KnuthMorrisPratt k = new KnuthMorrisPratt();
            String text = "Lorem ipsum dolor sit amet";
            String pattern = "ipsum";
		
            int first_occur_position = k.kmp(text, pattern);
            Console.WriteLine("The text '" + pattern + "' is first found on the " 
                                       + first_occur_position + " position.");
        }
    }*/
