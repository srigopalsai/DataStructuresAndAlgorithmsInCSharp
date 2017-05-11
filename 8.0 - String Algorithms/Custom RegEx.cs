using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class StringAlgorithms
    {
        // 'a' can occur zero or once in the beginning.
        // 'b' can occur once or more after a.
        // 'c' can occur zeor or more after b.
        string CustomRegEx = "a?b+c*";
        public bool MatchCustomRegEx(string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return false;

            int lstIndx = inputStr.Length - 1;

            if (inputStr[0] != 'a' || inputStr[0] != 'b' ||
                inputStr[1] != 'b' || inputStr[1] != 'c' ||
                inputStr[lstIndx] != 'b' || inputStr[lstIndx] != 'c')
                return false;

            int lpBCnt = 1;

            while (inputStr[++lpBCnt] != 'b') ;

            if (lpBCnt == lstIndx)
                return true;

            for (int lpCCnt = lpBCnt; lpCCnt < lstIndx; lpCCnt++)
            {
                if (inputStr[lpCCnt] != 'b')
                    return false;
            }

            return true;
        }
    }
}
