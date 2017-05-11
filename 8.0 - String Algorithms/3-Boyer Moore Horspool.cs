using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    BMH: Best performance in practice, as it often runs in sublinear time.
    In Text t, patter p compare each character in text with pattern from right to left, if it doesn't match then skip p lenght of charaters in text. 
    The worst case running time is as bad as that of the naive algorithm.
    
    Time Complexity O(n + m)

    C++ http://www.boost.org/doc/libs/1_55_0/libs/algorithm/doc/html/the_boost_algorithm_library/Searching/BoyerMooreHorspool.html
    http://www.mathcs.emory.edu/~cheung/Courses/323/Syllabus/Text/Progs/BM-Horspool/Horspool.java
    http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.133.4896&rep=rep1&type=pdf

    Boyer-Moore-Horspool is the same as for Boyer-Moore. 
    The worst case for Boyer-Moore-Horspool is quite a bit worse than for Boyer-Moore. 
    For typical use, Boyer-Moore-Horspool tends to be about the same as Boyer-Moore, but with a little better (lower) overhead and initialization costs.

    Horspool Algorithm uses only one of its shift function and the order in which the text character comparisions are performed is reelevant.

    Text    : WE HOLD THESE TRUTHS TO BE SELF-EVIDENT
    Patter  : TRUTH

    Pre Processing:

    Build Bad Match Table: 
    
    Last char and lenght will be replaced with '?' or '*'    
    And also which ever character from text is not found in bad match table it will skip no of chars in '?'

    MAX(1, Lenght - 1 - Index)

    Index   :   ?   T   R   U
    Value   :   5   1   3   2

    Text    :   WE HOLD THESE TRUTHS TO BE SELF-EVIDENT
    Round1  :   TRUTH                   - 'O' is not found in Bad Match Table, Skip 5 Chars.
    Round2  :        TRUTH              - 'H' and 'T' are matching. But Space is not found in Bad Match Table, So Skip 5 Chars again.
    Round3  :             TRUTH         - 'T' exists in Bad Match Table, so slide 1 char. 
    Round4  :              TRUTH        - 'R' exists in Bad Match Table, so slide 3 chars. 
    Round5  :                 TRUTH     - 'H' matches so continue matching other chars. 

    ===================================================================================================================================================================================================

    */
    partial class StringAlgorithms
    {
        private static int[] BuildBadCharTable(char[] needle)
        {
            int[] badShift = new int[256];
            for (int i = 0; i < 256; i++)
            {
                badShift[i] = needle.Length;
            }
            int last = needle.Length - 1;
            for (int i = 0; i < last; i++)
            {
                badShift[(int)needle[i]] = last - i;
            }
            return badShift;
        }

        public static int boyerMooreHorsepool(String pattern, String text)
        {
            char[] needle = pattern.ToCharArray();
            char[] haystack = text.ToCharArray();

            if (needle.Length > haystack.Length)
            {
                return -1;
            }
            int[] badShift = BuildBadCharTable(needle);
            int offset = 0;
            int scan = 0;
            int last = needle.Length - 1;
            int maxoffset = haystack.Length - needle.Length;
            while (offset <= maxoffset)
            {
                for (scan = last; (needle[scan] == haystack[scan + offset]); scan--)
                {
                    if (scan == 0)
                    { //Match found
                        return offset;
                    }
                }
                offset += badShift[(int)haystack[offset + last]];
            }
            return -1;
        }

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
        //public int BoyerMooreHorspoolSearch(char[] textCharacters, char[] patternCharacters)
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
        //    int patternLength = patternCharacters.Length;
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

        //public void RunBoyerMooreHorspoolSearchDemo()
        //{
        //    //String text = "AbcDefGhiJklMnoPqrStuVwxYz";
        //    //String pattern = "StuVwxYz";

        //    String text = "WE HOLD THESE TRUTHS TO BE SELF-EVIDENT";
        //    String pattern = "TRUTH";

        //    //int firstOccurPosition = BoyerMooreSearch2UsingAscii(text.ToCharArray(), pattern.ToCharArray());

        //    int firstOccurPosition = BoyerMooreHorspoolSearch(text.ToCharArray(), pattern.ToCharArray());
        //    MessageBox.Show("Boyer Moore Search Algorithm Demo:\nThe text '" + pattern + "' is first found at the position '" + firstOccurPosition + "'.");
        //}

        //int BoyerMooreHorspoolSearch(string text, string pattern)
        //{
        //    char[] textArr = text.ToCharArray();
        //    char[] patternArr = pattern.ToCharArray();

        //    int textLenght = text.Length;
        //    int patternLength = pattern.Length;

        //    // Repeat loop from zero to length of the text.
        //    for (int lpTextShiftIndex = 0; lpTextShiftIndex < textLenght; lpTextShiftIndex++)
        //    {
        //        for (int patternIndex = patternLength - 1; patternIndex >= 0; patternIndex--)
        //        {
        //            //If pattern does'nt match then skip the patten length of chars in text.
        //            if (textArr[lpTextShiftIndex] != patternArr[patternIndex])
        //            {
        //                lpTextShiftIndex += patternLength;
        //                break;
        //            }
        //        }
        //    }
        //    return -1;
        //}

        //public void RunBoyerMooreHorspoolSearchDemo()
        //{
        //    String text = "Abc Def Ghi Jkl Mno";
        //    String pattern = "Ghi";

        //    int firstOccurPosition =  BoyerMooreHorspoolSearch(text, pattern);
        //    MessageBox.Show("NaiveSearchAlgorithm Demo:\nThe text '" + pattern + "' is first found after the " + firstOccurPosition + " position.");
        //}
    }
}