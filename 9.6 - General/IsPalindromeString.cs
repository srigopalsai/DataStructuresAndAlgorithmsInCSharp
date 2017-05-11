using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class StringAlgorithms
    {
        // O (n/2)
        public static bool IsPalindromeString(string stringText)
        {
            int startPos = 0;
            int endPos = stringText.Length-1;
            while (startPos <= endPos)
            {
                if (stringText[startPos] != stringText[endPos])
                {
                    break;
                }
                startPos++;
                endPos--;
            }
            if (startPos > endPos)
            {
                return true;
            }
            return false;
        }
    }
}
