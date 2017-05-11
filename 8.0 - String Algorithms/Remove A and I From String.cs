
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms._9___String_Algorithms
{
    /*
    ===================================================================================================================================================================================================

    http://www.careercup.com/question?id=15321835

    ===================================================================================================================================================================================================    
    */
    class RemoveAandIFromString
    {
        void c15321835RemoeAI(char[] s)
        {
            int p = 0;
            int i = 0;

            for (i = 0; s[i] != 0; i++)
            {
                if (s[i] == 'a' || s[i] == 'i')
                {
                    p++;
                }
                else
                {
                    s[i - p] = s[i];
                }
                // s[i - p] = 0;
                // MessageBox.Show(s);

            }
        }
    }
}