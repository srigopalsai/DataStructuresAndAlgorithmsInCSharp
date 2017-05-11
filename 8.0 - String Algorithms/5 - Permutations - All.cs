using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    The number of permutations of n distinct objects is "n factorial" i.e. n!

    Permutation relates to the act of permuting, or rearranging, members of a set into a particular sequence or order 

    E.g. set {1,2,3}, namely (1,2,3), (1,3,2), (2,1,3), (2,3,1), (3,1,2), and (3,2,1) 

    Time Complexity O(n!) 
        
    For above E.g. 3! i.e 3 X 2 X 1. 
         
    Unlike combinations, which are selections that disregard order.
          
    Algoriths depend on whether one wants some randomly chosen permutations, or all permutations, and in the latter case if a specific ordering is required. 
    Whether possible equality among entries in the given sequence is to be taken into account; if so, one should only generate distinct multiset permutations of the sequence
       
    1. Recursive, 
    2. Lexicographic, and 
    3. Heap's algorithms [1]. 
    
    The Lexicographic algorithm is perfectly suited for the IEnumerable interface, since it uses the same GetNext() style and requires very little adaptation. 
    Both Recursive and Heap's algorithms are more efficient at generating permutations of integers, but need to be adapted for an IEnumerable interface by either converting to an iterative algorithm or using C# continuation.
        
    Combination : Order does NOT matter
    Permutation : Order does matter.
         
    In English. My fruit salad is a combination of apples, grapes and bananas. Can also say grapes, bananas and apples. (No need to follow Order) 
    My fligh number 240 (Here we cannot say 420 or 042)
    http://www.sanfoundry.com/java-program-generate-all-possible-combinations-given-list-numbers/
    A Permutation is an ordered Combination.
    http://www.mathsisfun.com/combinatorics/combinations-permutations.html
    http://stackoverflow.com/questions/9308986/how-to-calculate-the-time-complexity-of-back-tracking-algorithm
    0   1   2   3 
        1   2   3
            2   3
                3
    --------------
    4   2   6   12

    Each permute(a,i,n) causes n-i calls to permute(a,i+1,n)

Thus, when i == 0 there are n calls, when i == 1 there are n-1 calls... when i == n-1 there is one call.

You can find from this a recursive formula for number of iterations: 
T(1) = 1 [base] ; and T(n) = n * T(n-1) [step]

Resulting in total of T(n)  = n * T(n-1) 
                            = n * (n-1) * T(n-2) 
                            = .... 
                            = n * (n-1) * ... * 1 
                            = n!

EDIT: [small correction]: since the condition in the for loop is j <= n [and not j < n], 
    each permute() is actually invoking n-i+1 times permute(a,i+1,n), resulting in 
                            T(n) = (n+1) * T(n-1) [step] and 
                            T(0) = 1 [base], which later leads to T(n) = (n+1) * n * ... * 1 = (n+1)!. 
However, it seems to be an implementation bug more then a feature :\
    http://stackoverflow.com/questions/16994668/is-there-a-way-to-measure-how-sorted-a-list-is/16994740#16994740
    http://www.cs.duke.edu/~ola/ap/recurrence.html
    ===================================================================================================================================================================================================    
    */

    partial class StringAlgorithms
    {
        //LINQ        
        // Lexographic http://www.mathblog.dk/project-euler-24-millionth-lexicographic-permutation/
        static IEnumerable<IEnumerable<T>> GetPermutationsByLexicographic<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }
            return GetPermutationsByLexicographic(list, length - 1).SelectMany(t => list, (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        static IEnumerable<IEnumerable<string>> GetPermutationsByLexicographic(IEnumerable<string> list, int length)
        {
            if (length == 1)
            {
                return list.Select(permSet => new string[] { permSet });
            }
            return GetPermutationsByLexicographic(list, length - 1).SelectMany(t => list,
                                                                             ((t1, t2) => t1.Concat(new string[] { t2 })));
        }

        // O(n * n!) - There are O(N!) permutations, but the code also prints every one of those. 
        // Each is of length N, So we need to write a string of length N for every permutation, which results in total time complexity of O(N * N!)
        // Using Recursion and Back Tracking. http://stackoverflow.com/questions/14352924/order-of-recursion-in-c
        /*
         Input PreOutptTtl  BaseCase  Total Calls
           0    *    0     +   1       =  1
           1    *    1     +   1       =  2, 
           2    *    2     +   1       =  5, 
           3    *    5     +   1       =  16,  
           4    *   16     +   1       =  65, 
           5    *   65     +   1       =  326 */
      
        static string Permute(char[] elementsList, int currentIndex)
        {
            if (currentIndex == elementsList.Length)
            {
                //We can make use of string itself, if we update the swap function accordingly.
                foreach (char element in elementsList)
                    strBldr.Append(" " + element);
                strBldr.AppendLine("");
            }
            else
            {
                for (int lpIndex = currentIndex; lpIndex < elementsList.Length; lpIndex++)
                {   
                    // Swap elements.      
                    if (lpIndex != currentIndex)
                        Common.Swap(ref elementsList[currentIndex], ref elementsList[lpIndex]);

                    Permute(elementsList, (currentIndex + 1));

                    // Undo Swap elements.
                    if (lpIndex != currentIndex)
                        Common.Swap(ref elementsList[currentIndex], ref elementsList[lpIndex]);
                }
            }
            return strBldr.ToString();
        }
       
        public static void StringPermutationsTest()
        {
            strBldr = new StringBuilder();
            Debug.Flush();

            //string resultString = Permute("A".ToCharArray(), 0);
            //string resultString = Permute("AB".ToCharArray(), 0);
            Debug.WriteLine("============================================================================================");
            string resultString = Permute("ABCD".ToCharArray(), 0);
            Debug.WriteLine("============================================================================================");
            //string resultString = Permute("ABCD".ToCharArray(), 0);
            //string resultString = Permute("ABCDE".ToCharArray(), 0);

            Debug.WriteLine(resultString);
            MessageBox.Show(resultString);

            //IEnumerable<IEnumerable<int>> EnumResult = GetPermutationsByLexicographic(Enumerable.Range(1, 3), 3);
            ////Output - a list of integer-lists:   {1,2,3} {1,3,2} {2,1,3} {2,3,1} {3,1,2} {3,2,1}

            //foreach (IEnumerable<int> elements in EnumResult)
            //{
            //    foreach (int element in elements)
            //    {
            //        strBldr.Append(element + " ");
            //    }
            //    strBldr.AppendLine();
            //}
            //MessageBox.Show("Using LINQ Enumeration" + strBldr.ToString());
        }
    }
}
/*

  public static void doAnagram(int newSize)
        {
            if (newSize == 1) // if too small,
            {
                return; // go no further
            }
            for (int j = 0; j < newSize; j++) // for each position,
            {
                doAnagram(newSize - 1); // anagram remaining

                if (newSize == 2) // if innermost,
                {
                    displayWord(); // display it
                }
                rotate(newSize); // rotate word
            }
        }
        static int size;
        static int count;
        static char[] arrChar = new char[100];
 //-----------------------------------------------------------
        // rotate left all chars from position to end
        public static void rotate(int newSize)
        {
            int j;
            int position = size - newSize;
            char temp = arrChar[position]; // save first letter

            for (j = position + 1; j < size; j++) // shift others left
            {
                arrChar[j - 1] = arrChar[j];
                arrChar[j - 1] = temp; // put first on right
            }
        }
        //-----------------------------------------------------------
        public static void displayWord()
        {

            if (count < 99)
            {
                Debug.WriteLine("");
            }
            if (count < 9)
            {
                Debug.WriteLine("");
                Debug.WriteLine(++count + "");
            }

            for (int j = 0; j < size; j++)
            {
                Debug.WriteLine(arrChar[j]);
                Debug.WriteLine("");
            }

            if (count % 6 == 0)
            {
                Debug.WriteLine("");
            }
        }

        static string Permute(char[] elementsList, int currentIndex)
        {
            if (currentIndex == 0)//elementsList.Length)
            {
                //We can make use of string itself, if we update the swap function accordingly.
                foreach (char element in elementsList)
                {
                    strBldr.Append(" " + element);
                    Debug.Write(" " + element);
                }

                strBldr.AppendLine("");
                Debug.WriteLine("");
            }
            else
            {
                //for (int lpIndex = currentIndex; lpIndex < elementsList.Length; lpIndex++)
                //{
                //    if (lpIndex != currentIndex)
                //    {
                //        Common.Swap(ref elementsList[currentIndex], ref elementsList[lpIndex]);
                //    }

                //    Permute(elementsList, (currentIndex + 1));

                //    if (lpIndex != currentIndex)
                //    {
                //        Common.Swap(ref elementsList[currentIndex], ref elementsList[lpIndex]);
                //    }
                //}
                if (currentIndex >= 0)
                {
                    for (int lpIndex = elementsList.Length-1; lpIndex >= 0; lpIndex--)
                    {
                        if (lpIndex != currentIndex)
                        {
                            Common.Swap(ref elementsList[currentIndex], ref elementsList[lpIndex]);
                        }

                        Permute(elementsList, (currentIndex - 1));

                        if (lpIndex != currentIndex)
                        {
                            Common.Swap(ref elementsList[currentIndex], ref elementsList[lpIndex]);
                        }
                    }
                }
            }
            return strBldr.ToString();
         }

Testing :

1. With Null
2. With Empty String.
3. With Regular text.
3. With Duplicate Chars.
4. Min, Max Boundary
5. Concurrent Thread.
6. 


*/
//Approach 2

/*
        public static void GetPermutations(String str)
        {
            permutation(string.Empty, str);
        }

        //Note Consider Inbuilt string function complexities.
        private static void permutation(String permuteString, String sourceString)
        {
            int sourceStrLength = sourceString.Length;

            if (sourceStrLength == 0)
            {
                Debug.WriteLine(permuteString);
            }
            else
            {
                for (int lpCurrentIndx = 0; lpCurrentIndx < sourceStrLength; lpCurrentIndx++)
                {
                    string _permuteString = permuteString + sourceString[lpCurrentIndx];
                    string _sourceString = sourceString.Substring(0, lpCurrentIndx) + sourceString.Substring(lpCurrentIndx + 1, (sourceStrLength - lpCurrentIndx) - 1);
                    permutation(_permuteString, _sourceString);
                }
            }
        }

*/

// 1. remove first char 
// 2. find permutations of the rest of chars
// 3. Attach the first char to each of those permutations.
//     3.1  for each permutation, move firstChar in all indexes to produce even more permutations.
// 4. Return list of possible permutations.

//public string[] FindPermutations(string word)
//{
//    if (word.Length == 2)
//    {
//        char[] _c = word.ToCharArray();
//        string s = new string(new char[] { _c[1], _c[0] });
//        return new string[]{ word,  s};
//    }

//    List<string> _result = new List<string>();

//    string[] _subsetPermutations = FindPermutations(word.Substring(1));
//    char _firstChar = word[0];

//    foreach (string s in _subsetPermutations)
//    {
//        string _temp = _firstChar.ToString() + s;
//        _result.Add(_temp);
//        char[] _chars = _temp.ToCharArray();

//        for (int i = 0; i < _temp.Length - 1; i++)
//        {
//            char t = _chars[i];
//            _chars[i] = _chars[i + 1];
//            _chars[i + 1] = t;
//            string s2 = new string(_chars);
//            _result.Add(s2);
//        }
//    }
//    return _result.ToArray();
//}
// Check duplicates
//static string Permute(char[] elementsList, int startIndex)
//       {

//           char lastChar = '\0';

//           if (startIndex == elementsList.Length)
//           {
//               foreach (char element in elementsList)
//               {
//                   strBldr.Append(" " + element);
//               }
//               strBldr.AppendLine("");
//           }
//           else
//           {

//               for (int tempIndex = startIndex; tempIndex <= elementsList.Length - 1; tempIndex++)
//               {
//                   if (lastChar == elementsList[tempIndex])
//                   {
//                       continue;
//                   }
//                   else
//                   {
//                       lastChar = elementsList[tempIndex];
//                   }

//                   Common.Swap(ref elementsList[startIndex], ref elementsList[tempIndex]);

//                   Permute(elementsList, (startIndex + 1));

//                   Common.Swap(ref elementsList[startIndex], ref elementsList[tempIndex]);
//               }
//           }

//           return strBldr.ToString();
//       }
//static List<string> PermuteStr(string str, int startIndex)
//      {
//          if (startIndex == str.Length - 1)
//          {
//              List<string> permutation = new List<string>();
//              permutation.Add(str.Substring(startIndex));
//              return permutation;
//          }

//          List<string> permutations = PermuteStr(str, ++startIndex);
//          List<string> newPermutations = new List<string>();

//          foreach (string permutation in permutations)
//          {
//              for (int i = 0; i < permutation.Length; i++)
//              {
//                  newPermutations.Add(permutation.Insert(i, str[startIndex].ToString()));
//              }
//          }

//          return newPermutations;
//      }