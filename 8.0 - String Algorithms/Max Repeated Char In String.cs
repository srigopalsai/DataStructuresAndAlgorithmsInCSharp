using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    partial class StringAlgorithms
    {
        public static void MaxRepeatCharInString(string text)
        {

            IDictionary<char, int> charsWithTheirCnt = new Dictionary<char, int>();
            
            char MaxChar ='\0';
            int MaxCharCnt = 0;

            // O(n)
            for (int lpCnt = 0; lpCnt < text.Length; lpCnt++)
            {
                if (charsWithTheirCnt.ContainsKey(text[lpCnt]))
                {
                    charsWithTheirCnt[text[lpCnt]] = int.Parse(charsWithTheirCnt[text[lpCnt]].ToString()) + 1;

                    // Using Constant space to store the max char and max char count.
                    if (MaxCharCnt < charsWithTheirCnt[text[lpCnt]])
                    {
                        MaxCharCnt = charsWithTheirCnt[text[lpCnt]];
                        MaxChar = text[lpCnt];
                    }
                }
                else
                {
                    //O(1)
                    charsWithTheirCnt.Add(text[lpCnt], 1);
                }
            }

            // O(1) worst case O(n)
            KeyValuePair<char, int> maxRepeatChar = charsWithTheirCnt.FirstOrDefault( aa => aa.Value == charsWithTheirCnt.Values.Max());
            //MessageBox.Show("The character repated most no of times in given string is '" + maxRepeatChar.Key + "' and its count is " + maxRepeatChar.Value);

            MessageBox.Show("The character repated most no of times in given string is '" + MaxChar + "' and its count is " + MaxCharCnt);
        }
    }
}