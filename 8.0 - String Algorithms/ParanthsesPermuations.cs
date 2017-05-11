using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    Input  :    3
    Output :    <<<>>>
                <<><>>
                <<>><>
                <><<>>
                <><><>
    3-5
4-14
5-42
6-132
    http://stackoverflow.com/questions/3172179/valid-permutation-of-parenthesis
    */
    partial class StringAlgorithms
    {
        int LpCnt = 0;
        void BracketPermutations(int openStock, int closeStock, String permuteString)
        {
            if (openStock == 0 && closeStock == 0)
            {
                strBldr.AppendLine(++LpCnt + " : " + permuteString); // O(n) Operations
            }
            
            if (openStock > 0)
            {
                BracketPermutations(openStock - 1, closeStock + 1, permuteString + "<");
            }
            
            if (closeStock > 0)
            {
                BracketPermutations(openStock, closeStock - 1, permuteString + ">");
            }
        }

        public void BracketPermutationsTest()
        {
            LpCnt = 0;
            strBldr.Clear();
            BracketPermutations(6, 0, "");
            Debug.WriteLine(strBldr.ToString());
            MessageBox.Show(strBldr.ToString());
        }
    }
}