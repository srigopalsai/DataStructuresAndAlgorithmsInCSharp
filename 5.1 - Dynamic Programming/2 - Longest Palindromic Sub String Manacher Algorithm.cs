using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    // Refer IsPalindrome program in String algorithms first.

    http://en.wikipedia.org/wiki/Longest_palindromic_substring
    http://www.careercup.com/question?id=4128790
    http://www.careercup.com/question?id=15074748

    http://www.dsalgo.com/2013/02/longest-palindrome-dynamic.htmls
    http://www.geeksforgeeks.org/longest-palindrome-substring-set-1/
    http://stackoverflow.com/questions/7043778/longest-palindrome-in-a-string-using-suffix-tree
    N^2 Lil Easy   http://www.sourcetricks.com/2012/07/find-longest-palindrome-in-string.html

    
    1.The left side of a palindrome is a mirror image of its right side.

    2.(Case 1) A third palindrome whose center is within the right side of a first palindrome will have exactly the same length as that of a second palindrome anchored at the mirror center on the left side, 
    if the second palindrome is within the bounds of the first palindrome by at least one character.

    3.(Case 2) If the second palindrome meets or extends beyond the left bound of the first palindrome, 
    then the third palindrome is guaranteed to have at least the length from its own center to the right outermost character of the first palindrome. 
    This length is the same from the center of the second palindrome to the left outermost character of the first palindrome.
    
    4.To find the length of the third palindrome under Case 2, the next character after the right outermost character of the first palindrome would then be compared with its mirror character around the center of the third palindrome, 
    until there is no match or no more characters to compare.

    5.(Case 3) Neither the first nor second palindrome provides information to help determine the palindromic length of a fourth palindrome whose center is outside the right side of the first palindrome.

    6.It is therefore desirable to have a palindrome as a reference (i.e., the role of the first palindrome) that possesses characters furtherest to the right in a string 
    when determining from left to right the palindromic length of a substring in the string (and consequently, 
    the third palindrome in Case 2 and the fourth palindrome in Case 3 could replace the first palindrome to become the new reference).

    7.Regarding the time complexity of palindromic length determination for each character in a string: 
    there is no character comparison for Case 1, while for Cases 2 and 3 only the characters in the string beyond the right outermost character of the reference palindrome are candidates for comparison 
    (and consequently Case 3 always results in a new reference palindrome while Case 2 does so only if the third palindrome is actually longer than its guaranteed minimum length).

    8.For even-length palindromes, the center is at the boundary of the two characters in the middle.

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Given a string S, we are to find the longest sub-string s of S such that the reverse of s is exactly the same as s.
 First insert a special character ‘#’ between each pair of adjacent characters of S, in front of S and at the back of S. After that, we only need to check palindrome sub-strings of odd length.
 Let P[i] be the largest integer d such that S[i-d,...,i+d] is a palindrome.  We calculate all P[i]s from left to right. When calculating P[i], we have to compare S[i+1] with S[i-1], S[i+2] with S[i-2] and so on. A comparison is successful if two characters are the same, otherwise it is unsuccessful. In fact, we can possibly skip some unnecessary comparisons utilizing the previously calculated P[i]s.
 Assume P[a]+a=max{ P[j]+j :  j<i }. If P[a]+a >= i, then we have 
 P[i] >= min{ P[2*a-i],  2*a-i-(a- P[a])}.
 Is it the algorithm linear time? The answer is yes.
 First the overall number of unsuccessful comparisons is obviously at most N.
 A more careful analysis show that S[i] would never be compared successfully with any S[j](j<i) after its first time successful comparison with some S[k] (k<i).
 So the number of overall comparisons is a most 2N. 

    ===================================================================================================================================================================================================    
    */
    public partial class DynamicProgrammingSamples
    {
        public void LargestPalindromeManacherAlgorithmTest()
        {
            //string strPalinSource = "ababccbcdddcecdddcbccbaba";
            //string strPalinResult = string.Empty;

            string resultString = string.Empty;

            string strPalinSource3 = "123321";
            string strPalinResult3 = LargestPalindromeManacherAlgorithm(strPalinSource3);
            resultString += ("\n Test 1 :  " + strPalinSource3 + " Result : " + strPalinResult3);

            string strPalinSource4 = "1234321";
            string strPalinResult4 = LargestPalindromeManacherAlgorithm(strPalinSource4);
            resultString += ("\n Test 2 :  " + strPalinSource4 + " Result : " + strPalinResult4);

            string strPalinSource5 = "000";
            string strPalinResult5 = LargestPalindromeManacherAlgorithm(strPalinSource5);
            resultString += ("\n Test 3 :  " + strPalinSource5 + " Result : " + strPalinResult5);


            string strPalinSource2 = "123321456";
            string strPalinResult2 = LargestPalindromeManacherAlgorithm(strPalinSource2);
            resultString += ("\n Test 4 :  " + strPalinSource2 + " Result : " + strPalinResult2);

            String strPalinSource1 = "456789123123321456789123";
            string strPalinResult1 = LargestPalindromeManacherAlgorithm(strPalinSource1);
            resultString += "\n Test 5 :  " + strPalinSource1 + " Result : " + strPalinResult1;

            MessageBox.Show(resultString);
        }
        
        public String LargestPalindromeManacherAlgorithm(String sourceString)
        {
            if (sourceString == null || sourceString.Length == 0)
            {
                return string.Empty;
            }

            //O(n) to convert to Char Array.
            char[] processedCharArray = AddBoundariesPreProcessing(sourceString.ToCharArray());
            
            //O(n) Extra Space
            int[] processedIndeces = new int[processedCharArray.Length];

            int c = 0;
            int r = 0; // Here the first element in s2 has been processed.

            int backwardCntr = 0;
            int forwardCntr = 0; // The walking indices to compare if two elements are the same

            for (int lpCnt = 1; lpCnt < processedCharArray.Length; lpCnt++)
            {
                if (lpCnt > r)
                {
                    processedIndeces[lpCnt] = 0;
                    backwardCntr = lpCnt - 1;
                    forwardCntr = lpCnt + 1;
                }
                else
                {
                    int i2 = c * 2 - lpCnt;

                    if (processedIndeces[i2] < (r - lpCnt))
                    {
                        processedIndeces[lpCnt] = processedIndeces[i2];
                        backwardCntr = -1; // This signals bypassing the while loop below. 
                    }
                    else
                    {
                        processedIndeces[lpCnt] = r - lpCnt;
                        forwardCntr = r + 1;
                        backwardCntr = lpCnt * 2 - forwardCntr;
                    }
                }

                while (backwardCntr >= 0 && forwardCntr < processedCharArray.Length && processedCharArray[backwardCntr] == processedCharArray[forwardCntr])
                {
                    processedIndeces[lpCnt]++; 
                    backwardCntr--; 
                    forwardCntr++;
                }

                if ((lpCnt + processedIndeces[lpCnt]) > r)
                {
                    c = lpCnt;
                    r = lpCnt + processedIndeces[lpCnt];
                }
            }


            int len = 0;

            c = 0;

            for (int lpCnt = 1; lpCnt < processedCharArray.Length; lpCnt++)
            {
                if (len < processedIndeces[lpCnt])
                {
                    len = processedIndeces[lpCnt];
                    c = lpCnt;
                }
            }

            char[] ss = new char[processedCharArray.Length];
            Array.Copy(processedCharArray, c - len, ss, 0, c + len + 1);

            return new string(RemoveBoundariesPostProcessing(ss));
        }

        //O(n) time
        private char[] AddBoundariesPreProcessing(char[] sourceCharArray)
        {
            if (sourceCharArray == null || sourceCharArray.Length == 0)
            {
                return "||".ToCharArray();
            }

            char[] processedCharArray = new char[sourceCharArray.Length * 2 + 1];

            for (int lpCnt = 0; lpCnt < (processedCharArray.Length - 1); lpCnt = lpCnt + 2)
            {
                processedCharArray[lpCnt] = '|';
                processedCharArray[lpCnt + 1] = sourceCharArray[lpCnt / 2];
            }

            processedCharArray[processedCharArray.Length - 1] = '|';

            return processedCharArray;
        }

        //O(n) time
        private char[] RemoveBoundariesPostProcessing(char[] sourceCharArray)
        {
            if (sourceCharArray == null || sourceCharArray.Length < 3)
            {
                return "".ToCharArray();
            }

            char[] filteredCharArray = new char[(sourceCharArray.Length - 1) / 2];

            for (int lpCnt = 0; lpCnt < filteredCharArray.Length; lpCnt++)
            {
                filteredCharArray[lpCnt] = sourceCharArray[lpCnt * 2 + 1];
            }
            return filteredCharArray;
        }
    }
}

/*
Failing code

        public string LargestPalindromeManacherAlgorithm(string sourceString)
        {
            int stringLength = sourceString.Length;
            int maxPalindromeStringLength = 0;
            int maxPalindromeStringStartIndex = 0;

            for (int lpForwardCntr = 0; lpForwardCntr < sourceString.Length; lpForwardCntr++)
            {
                int currentCharIndex = lpForwardCntr;

                for (int lpBackWardCntr = stringLength - 1; lpBackWardCntr > currentCharIndex; lpBackWardCntr--)
                {
                    bool isPalindrome = true;

                    if (sourceString[currentCharIndex] != sourceString[lpBackWardCntr])
                    {
                        continue;
                    }

                    for (int nextCharIndex = currentCharIndex + 1; nextCharIndex < lpBackWardCntr / 2; nextCharIndex++)
                    {
                        if (sourceString[nextCharIndex] != sourceString[lpBackWardCntr - 1])
                        {
                            isPalindrome = false;
                            break;
                        }
                    }

                    if (isPalindrome)
                    {
                        if (lpBackWardCntr + 1 - currentCharIndex > maxPalindromeStringLength)
                        {
                            maxPalindromeStringStartIndex = currentCharIndex;
                            maxPalindromeStringLength = lpBackWardCntr + 1 - currentCharIndex;
                        }
                    }
                    break;
                }
            }

            return sourceString.Substring(maxPalindromeStringStartIndex, maxPalindromeStringLength);
        }

-------------------------------------------------------

        public void findLargestPalindromeTest()
        {
            String str = "acbcaccccaccc";
            String result = findLargestPalindrome(str);
            MessageBox.Show(result);
        }

        private static String findLargestPalindrome(String str)
        {
            if (str == null || str.Length == 0)
            {
                return "";
            }

            bool[][] memo = new bool[str.Length][];
            for (int startIndex = 0; startIndex < str.Length; ++startIndex)
            {
                memo[startIndex] = new bool[str.Length];
            }

            int maxStart = 0;
            int maxLength = 1;

            for (int startIndex = 0; startIndex < str.Length; ++startIndex)
            {
                memo[startIndex][startIndex] = true;
            }

            for (int startIndex = 0; startIndex < str.Length - 1; ++startIndex)
            {
                if (str[startIndex] == str[startIndex + 1])
                {
                    memo[startIndex][startIndex + 1] = true;
                    maxStart = startIndex;
                    maxLength = 2;
                }
            }

            for (int length = 3; length <= str.Length; ++length)
            {
                for (int startIndex = 0; startIndex < str.Length - length + 1; ++startIndex)
                {
                    int endIndex = startIndex + length - 1;

                    if (str[startIndex] == str[endIndex] && memo[startIndex + 1][endIndex - 1] == true)
                    {
                        memo[startIndex][endIndex] = true;
                        maxStart = startIndex;
                        maxLength = length;
                    }

                }
            }
            return str.Substring(maxStart, maxStart + maxLength);
        }
*/