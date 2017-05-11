using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*

    http://www.careercup.com/question?id=62240
    */
    partial class StringAlgorithms
    {
        public static void ReverseAString()
        {
            string s = "Sai";

            reverse(s);
            MessageBox.Show("Swapped String" + s);
        }
  
        static void reverse(string s)
        {
            //for (int i = 0; i < s.Length / 2; i++)
            //{
            //    Common.Swap(ref s[i], ref s[s.Length - i - 1]);
            //}
        }
    }
}