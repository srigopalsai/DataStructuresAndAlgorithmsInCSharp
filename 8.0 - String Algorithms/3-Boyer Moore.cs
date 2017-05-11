using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Collections;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    http://heim.ifi.uio.no/bjarneh/other/inf2220/textalgorithms/TextAlgorithms.java.html
    String.IndexOf to use Boyer-Moore. 

    The Boyer-Moore algorithm is considered as the most efficient string-matching algorithm in usual applications.
 
    A simplified version of it or the entire algorithm is often implemented in text editors for the «search» and «substitute» commands.

    In case of a mismatch (or a complete match of the whole pattern) it uses two precomputed functions to shift the window to the right. 
    
    1. Good-Suffix Shift Or Matching Shift.     The good-suffix shift function is stored in a table bmGs of size m+1.
    
    2. Bad-Character Shift Or Occurrence Shift. (Bad Match Table)
        The bad-character rule considers the character in T at which the comparison process failed (assuming such a failure occurred).

    Also can set or use the index as Shift or Skip characters.

    Pre Processing Time     : O(m + sigma)      Space   :  O(m + sigma) 
    Characters Comparisons  : 3n
    Searching Phase         : O(mn) Worst Case
    
    O(nm) when there is no pre processing.
    
    E.g. Input Text = "Abc Def Ghi Jkl Mno";
         Pattern = "Def";

    Pre Processing:
      0 to size - 1 of no of Alphabets. Worst case 0 to 26
      Find Shift Size for all letters.
    
    The execution time can actually be sub-linear: 
    It doesn't need to actually check every character of the string to be searched but rather skips over some of them 
     (check right-most character of the block of m first, if not found in pattern can skip entire rest of block). 
     Actually works better (on average) with longer m! 

    Performs the comparisons from right to left;
    Preprocessing phase in O(m + sigma) time and space complexity;
    3n text character comparisons in the worst case when searching for a non periodic pattern;
    O(n / m) best performance. In the best case, only one in m characters needs to be checked. 
    
     
    Boyer-Moore is probably the fastest non-indexed text-search algorithm known. 
    
    E.g. Input Text = "Abc Deff Ghi Jkl Mno";
         Pattern = "Deff";
    From the above example find the shift size for Patter.
     D e f
     0 1 3 are the shift size for each character. If char is already exists then replace it.

    * Methods vary on the exact form the table for the bad character rule should take.
    
    L P S- Longest Prefix Suffix 

    Helpful Links:
    
    http://www.movsd.com/bm.htm  
    http://www-igm.univ-mlv.fr/~lecroq/string/
    http://java.dzone.com/articles/algorithm-week-boyer-moore

    http://www.boost.org/doc/libs/1_55_0/libs/algorithm/doc/html/the_boost_algorithm_library/Searching/BoyerMooreHorspool.html
    http://www.cs.uku.fi/~kilpelai/BSA05/lectures/slides03.pdf

    ===================================================================================================================================================================================================
    
    */

    partial class StringAlgorithms
    {
        int CHAR_MAX = 256;
    
        /*
         pattern to look for
         text to search for pattern
         if pattern not found, else return offset of first match
         */
        
        public int boyer_moore(String pattern, String text)
        {

            if (pattern == null || text == null || pattern.Length > text.Length) 
            { 
                return -1; 
            }

            // finding a needle in a haystack
            char[] needle = pattern.ToCharArray();
            char[] haystack = text.ToCharArray();
            
            /* good suffix shift see goodshift(char[], int) below */

            int[] good_shift = new int[needle.Length];

            for (int i = 0; i < needle.Length; i++)
            {
                good_shift[i] = goodshift(needle, i);
            }

            /* bad shift section same argument as simpleBadShift */

            int[] bad_shift = new int[CHAR_MAX];

            for (int i = 0; i < CHAR_MAX; i++)
            {
                bad_shift[i] = needle.Length;
            }

            // offset at which match was found
            int offset = 0;
            int scan = 0;
            int last = needle.Length - 1;
            int maxoffset = haystack.Length - needle.Length;
            
            for (int i = 0; i < last; i++)
            {
                bad_shift[needle[i]] = last - i;
            }
            
            // needle can still be inside haystack
            while (offset <= maxoffset)
            {
                // start at end of pattern and match backwards
                for (scan = last; needle[scan] == haystack[scan + offset]; scan--)
                {
                    // we have a match
                    if (scan == 0)
                    {
                        return offset;
                    }
                }

                // shift as much as possible based on the good and bad shift
                offset += Math.Max(bad_shift[haystack[offset + last]], good_shift[last - scan]);

            }

            // indicates no match
            return -1;
        }

        /**
     * @param pattern to look for
     * @param text to search for pattern
     * @return -1 if pattern not found, else return offset of first match
     */
        public int boyer_moore_horspool(String pattern, String text)
        {

            if (pattern == null || text == null ||                   pattern.Length > text.Length) 
            { 
                return -1; 
            }

            // finding a needle in a haystack
            char[] needle = pattern.ToCharArray();
            char[] haystack = text.ToCharArray();


            /* bad shift section same argument as simpleBadShift */

            int[] bad_shift = new int[CHAR_MAX];

            for (int i = 0; i < CHAR_MAX; i++)
            {
                bad_shift[i] = needle.Length;
            }

            // offset at which match was found
            int offset = 0;
            int scan = 0;
            int last = needle.Length - 1;
            int maxoffset = haystack.Length - needle.Length;

            /* Filling in the bad_shift is a bit more complex in this example, 
               since we add distance to the first possible match inside our pattern
             *
             *
             * now we know that our pattern will not match until we get a 'd' to align up with the 'd' we have in our pattern. 
             *
             *
             * text     = [a,b,c,d,e,f,d,.................]
             * pattern  = [a,c,d,e,s,g,h]
             *                         ^  
             *                         
             * with the simpleBadShift we only skipped once we found a character which did not occur inside 
             * our pattern, but this time we skip to the next possible match in our pattern, which in this case is the first 'd'
             *
             *
             * text     = [a,b,c,d,e,f,d,.................]
             * pattern  =         [a,c,d,e,s,g,h]
             *                         ^
             *
             * so with this strategy we can skip a bit even when we locate characters which are present inside our pattern, but badly aligned
             *
             */

            for (int i = 0; i < last; i++)
            {
                bad_shift[needle[i]] = last - i;
            }


            // needle can still be inside haystack
            while (offset <= maxoffset)
            {

                // start at end of pattern and match backwards
                for (scan = last; needle[scan] == haystack[scan + offset]; scan--)
                {

                    // we have a match
                    if (scan == 0)
                    {
                        return offset;
                    }
                }

                offset += bad_shift[haystack[offset + last]];
            }
            // indicates no match
            return -1;
        }

        /**
    * @param pattern to look for
    * @param text to search for pattern
    * @return -1 if pattern not found, else return offset of first match
    */
        public int simpleBadShift(String pattern, String text)
        {

            if (pattern == null || text == null ||                    pattern.Length > text.Length)
            { 
                return -1; 
            }

            // finding a needle in a haystack
            char[] needle = pattern.ToCharArray();
            char[] haystack = text.ToCharArray();
            
            /* bad shift section:
             *
             * note that we fill the whole bad_shift array with
             * a skip value which skips entire word. this is 
             * relevant in this situation
             *
             *                          
             * text     = [a,b,c,d,e,f,z,.................]
             * pattern  = [a,c,d,e,s,g,h]
             *                         ^  
             *                         
             * since 'z' is not part of our pattern
             * moving one step downwards like this:
             *
             *
             * text     = [a,b,c,d,e,f,z,.................]
             * pattern  =   [a,c,d,e,s,g,h]
             *                         ^
             *
             * makes very little sense, since 'z' will NEVER
             * match any character inside our pattern, so we
             * might as well move our pattern a complete
             * pattern.length, like this
             *
             *
             * text     = [a,b,c,d,e,f,z,.................]
             * pattern  =               [a,c,d,e,s,g,h]
             *
             */

            int[] bad_shift = new int[CHAR_MAX];

            for (int i = 0; i < CHAR_MAX; i++)
            {
                bad_shift[i] = needle.Length;
            }

            // all characters present in needle will
            // only allow a skip value of 1

            for (int i = 0; i < needle.Length; i++)
            {
                bad_shift[needle[i]] = 1;
            }

            // offset at which match was found
            int offset = 0;
            int scan = 0;
            int last = needle.Length - 1;
            int maxoffset = haystack.Length - needle.Length;

            // needle can still be inside haystack
            while (offset <= maxoffset)
            {

                // start at end of pattern and match backwards
                for (scan = last; needle[scan] == haystack[scan + offset]; scan--)
                {

                    // we have a match
                    if (scan == 0)
                    {
                        return offset;
                    }
                }

                offset += bad_shift[haystack[offset + last]];
            }
            // indicates no match
            return -1;
        }

        /**
         * Calculate the good shift.
         *
         * the good suffix shift is the number of 'shifts'
         * to the left we can move the needle and possibly
         * get another match, based on how far the needle
         * matched in the first place. since knowing the
         * number of matches (which is stored in the 'matches' variable)
         * says something about the structure of the actual
         * 'haystack' we are looking at.
         *
         * or using figures:
         *
         * text     = [a,b,c,d,e,f,d,.................]
         * pattern  = [a,c,d,e,s,f,d]
         *                         ^  
         * now the bad-shift would move the needle to the
         * next time the two last characters match like this:
         *
         * text     = [a,b,c,d,e,f,d,.................]
         * pattern  =         [a,c,d,e,s,f,d]
         *
         * but if we know that we got two matches before
         * we failed to match the third character, there
         * is no reason to move to anything but the suffix
         * 
         * !s f d
         *
         * where !s = some character which is not s
         *
         * since that is the sequence of characters
         * we are dealing with in the haystack now, and
         * since our needle does not contain any other
         * instance of:
         *
         * !s f d
         *
         * we might as well skip the whole needle.
         *
         *
         *
         * @param needle we investigate
         * @param matches that we got
         */
        int goodshift(char[] needle, int matches)
        {

            if (matches >= needle.Length || matches < 0)
            {
                return -1;
            }

            if (matches == 0) { return 1; } // leave it for badshift

            int max = needle.Length - 1;
            int offset = max;
            int last = matches - 1;


            // keep going as long as we have needle left..
            while (offset >= 1)
            {

                --offset;

                // keep on comparing the elements as long as we got any needle
                // left, and when you have located matches for the entire suffix
                // make sure that the next element is a missmatch.
                for (int i = 0; (offset - i >= 0) && needle[(max - i)] == needle[(offset - i)]; i++)
                {

                    if ((offset - i) == 0)
                    {
                        return max - offset;
                    }

                    if (i == last)
                    {
                        // next char must be missmatch for this to count
                        if (needle[(max - matches)] != needle[(offset - matches)])
                        {
                            return max - offset;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            // if no suffix found return entire needle.length 
            // which is legal shift value
            return needle.Length;
        }

        //void PreBadCharacterShiftOrOccurrenceShift(string pattern, int patternLenght, int[] badMatchCharTbl)
        //{
        //    for(int lpCnt =0; lpCnt < pattern.Length; ++lpCnt)
        //    {
        //        badMatchCharTbl[lpCnt] = patternLenght;
        //    }
        //    for (int lpCnt = 0; lpCnt < 255; ++lpCnt)
        //    {
        //        badMatchCharTbl[pattern[lpCnt]] = patternLenght - lpCnt - 1;
        //    }
        //}
        //void Suffixes(string pattern, int m, int[] suffixesTbl)
        //{
        //    int f =0;
        //    int g = 0;
        //    int i = 0;

        //    suffixesTbl[m - 1] = m;
        //    g = m - 1;
        //    for (i = m - 2; i >= 0; --i)
        //    {
        //        if (i > g && suffixesTbl[i + m - 1 - f] < i - g)
        //        {
        //            suffixesTbl[i] = suffixesTbl[i + m - 1 - f];
        //        }
        //        else
        //        {
        //            if (i < g)
        //            {
        //                if (i < g)
        //                {
        //                    g = i;
        //                }
        //                f = i;
        //                while (g >= 0 && pattern[g] == pattern[g + m - 1 - f])
        //                {
        //                    --g;
        //                }
        //                suffixesTbl[i] = f - g;
        //            }
        //        }
        //    }
        //}
        //void PreGoodSuffixShiftOrMatchingShift(string pattern, int m, int[] goodSuffixShiftTbl)
        //{
        //    int i, j;
        //    int[] suff = new int[pattern.Length];

        //    Suffixes(pattern, m, suff);

        //    for(i=0;i<m;++i)
        //    {
        //        goodSuffixShiftTbl[i] = m;
        //    }

        //    j = 0;

        //    for (i = m - 1; i >= -1; --i)
        //    {
        //        if (i == -1 || suff[i] == i + 1)
        //        {
        //            for(; j <m-1-i;++j)
        //            {
        //                if (goodSuffixShiftTbl[j] == m)
        //                {
        //                    goodSuffixShiftTbl[j] = m - 1 - i;
        //                }
        //            }
        //        }
        //    }

        //    for (i = 0; i <= m - 2; ++i)
        //    {
        //        goodSuffixShiftTbl[m - 1 - suff[i]] = m - 1 - i;
        //    }
        //}

        //void BoyerMooreSearch(string text, string pattern, int m, int n)
        //{
        //    int i, j;
        //    int[] bmGs = new int[pattern.Length];

        //    int[] bmBc = new int[pattern.Length];
        //    PreGoodSuffixShiftOrMatchingShift(pattern, m, bmGs);
        //   // PreBadCharacterShiftOrOccurrenceShift(pattern, m, bmBc);

        //    j = 0;
        //    while (j <= n - m)
        //    {
        //        for (i = m - 1; i >= 0 && pattern[i] == text[i + j]; --i) ;
        //        if (i < 0)
        //        {
        //            MessageBox.Show(j.ToString());
        //            j += bmGs[0];
        //        }
        //        else
        //        {
        //            j += Math.Max(bmGs[i], bmBc[text[i + j]] - m + 1 + i);
        //        }
        //    }
        //}
        
        //public void RunBoyerMooreSearchDemo()
        //{
        //    //String text = "AbcDefGhiJklMnoPqrStuVwxYz";
        //    //String pattern = "StuVwxYz";

        //    String text = "WE HOLD THESE TRUTHS TO BE SELF-EVIDENT";
        //    String pattern = "TRUTH";
        //    int[] badCharTbl = new int[255];
        //    //PreBadCharacterShiftOrOccurrenceShift(pattern,pattern.Length,badCharTbl);
        //    //int firstOccurPosition = BoyerMooreSearch2UsingAscii(text.ToCharArray(), pattern.ToCharArray());

        //    //int firstOccurPosition = BoyerMooreSearch(text.ToCharArray(), pattern.ToCharArray());
        //    //MessageBox.Show("Boyer Moore Search Algorithm Demo:\nThe text '" + pattern + "' is first found at the position '" + firstOccurPosition + "'.");
        //}
        //Dictionary<char, int> ShiftSizeTable = new Dictionary<char, int>();
        
        ////Calculate Shifit/Skip count for each element in pattern text. So that we can skip that many no of Characters in given text while searching.
        //public void PreProcessBMSBadMatchTable(char[] patternCharacters)
        //{
        //    ShiftSizeTable.Clear();

        //    int totalCharacters = patternCharacters.Length;

        //    for (int lpIndex = 0; lpIndex < totalCharacters; lpIndex++)
        //    {
        //        //If the charater is already exists in the ShiftSize table then replace it else add it to ShiftSize table.
        //        if (ShiftSizeTable.ContainsKey(patternCharacters[lpIndex]))
        //        {
        //            ShiftSizeTable.Remove(patternCharacters[lpIndex]);
        //        }

        //        //Calculate the shift size for each character in the string or char array.
        //        int ShiftSize = Math.Max(1, (totalCharacters - 1) - lpIndex);

        //        ShiftSizeTable.Add(patternCharacters[lpIndex], ShiftSize);
        //    }
        //}

        ////Use the PreProcessed Shift/Skip table to find the pattern Characters in text and skip the bad Characters in the text.
        //public int BoyerMooreSearch1UsingDictionary(char[] textCharacters, char[] patternCharacters)
        //{        
        //    PreProcessBMSBadMatchTable(patternCharacters);

        //    int SkipLength;
        //    int patternCharactersLenght = patternCharacters.Length;
        //    int textCharactersLenght = textCharacters.Length;

        //    // Step2. Use Loop through each character in source text use ShiftArrayTable to skip the elements.
        //    for (int lpTextIndex = 0; lpTextIndex <= (textCharactersLenght - patternCharactersLenght); lpTextIndex += SkipLength)
        //    {
        //        SkipLength = 0;

        //        for (int lpPatIndex = patternCharactersLenght - 1; lpPatIndex >= 0; lpPatIndex--)
        //        {
        //            if (patternCharacters[lpPatIndex] != textCharacters[lpTextIndex + lpPatIndex])
        //            {
        //                int PatSkipLenCount = lpPatIndex - ShiftSizeTable[patternCharacters[lpPatIndex]];
        //                SkipLength = Math.Max(1, PatSkipLenCount);
        //                break;
        //            }
        //        }
        //        if (SkipLength == 0)
        //        {
        //            return lpTextIndex;     // Found
        //        }
        //    }
        //    return -1;      // Not found
        //}

        ////Using ASCII code Length table as Shift/Skip table.
        //public int BoyerMooreSearch2UsingAscii(char[] textCharacters, char[] patternCharacters)
        //{
        //    //Step1. Pre Processing. Also called as haystack.
        //    //Calculate Shifit/Skip count for each element in pattern text. So that we can skip that many no of Characters in given text while searching.
        //    int[] ShiftArrayTable = new int[256];

        //    for (int lpIndex = 0; lpIndex < patternCharacters.Length; lpIndex++)
        //    {
        //        //Get the ASCII code for each pattern character and use that as index postion to store the loopIndex i.e. Each pattern character position.
        //        // http://www.asciitable.com/
        //        int charAsciiCode = patternCharacters[lpIndex];
        //        ShiftArrayTable[charAsciiCode] = lpIndex;
        //    }

        //    int SkipLength;
        //    int patternLength= patternCharacters.Length;
        //    int sourceTextLenght = textCharacters.Length;

        //    // Step2. Use Loop through each character in source text use ShiftArrayTable to skip the elements.
        //    for (int lpTextIndex = 0; lpTextIndex <= sourceTextLenght - patternLength; lpTextIndex += SkipLength)
        //    {
        //        SkipLength = 0;

        //        for (int lpPatIndex = patternLength - 1; lpPatIndex >= 0; lpPatIndex--)
        //        {
        //            if (patternCharacters[lpPatIndex] != textCharacters[lpTextIndex + lpPatIndex])
        //            {
        //                SkipLength = Math.Max(1, lpPatIndex - ShiftArrayTable[textCharacters[lpTextIndex + lpPatIndex]]);
        //                break;
        //            }
        //        }
        //        if (SkipLength == 0)
        //        {
        //            return lpTextIndex;    // Found
        //        }
        //    }
        //    return -1; // Not found
        //}
    }
}