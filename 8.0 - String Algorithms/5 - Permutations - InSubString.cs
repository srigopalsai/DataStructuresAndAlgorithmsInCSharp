using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{

    /*
    https://leetcode.com/problems/permutation-in-string
    https://discuss.leetcode.com/topic/87861/c-java-clean-code-with-explanation
    https://discuss.leetcode.com/topic/87845/java-solution-sliding-window
    https://discuss.leetcode.com/topic/87846/java-o-n-time-o-1-space-sliding-window
    https://discuss.leetcode.com/topic/87884/8-lines-slide-window-solution-in-java
    */
    partial class StringAlgorithms
    {
        public bool CheckInclusive(string s1, string s2)
        {
            char[] ca1 = s1.ToCharArray(), ca2 = s2.ToCharArray();
            int[] cnts = new int[256];

            foreach (char ch in ca1)
                cnts[ch]++;

            int left = ca1.Length;

            for (int i = 0, j = 0; j < ca2.Length; j++)
            {
                if (cnts[ca2[j]]-- > 0)
                    left--;

                while (left == 0)
                {
                    if (j + 1 - i == ca1.Length)
                        return true;
                    if (++cnts[ca2[i++]] > 0)
                        left++;
                }
            }

            return false;
        }

        public bool HasPermutations(string srcStr, string permutatinStr)
        {
            if (string.IsNullOrWhiteSpace(srcStr) || string.IsNullOrWhiteSpace(permutatinStr) || srcStr.Length < permutatinStr.Length)
                return false;

            int lpIndx = 0;

            HashSet<char> visited = new HashSet<char>();
            HashSet<char> permChars = new HashSet<char>(permutatinStr.ToCharArray());

            while (lpIndx < srcStr.Length)
            {
                if (permChars.Contains(srcStr[lpIndx]))
                {
                    visited.Add(srcStr[lpIndx]);
                    if (visited.Count == permChars.Count)
                        return true;
                }
                else if (!permChars.Contains(srcStr[lpIndx]) && visited.Count > 0)
                {
                    visited.Clear();
                }
                lpIndx++;
            }

            if (visited.Count == permutatinStr.Length)
                return true;

            return false;
        }
    }
}