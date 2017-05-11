using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    Input:
    Compare values in 2 are and return true if they are same. Note : they are not in similar order.
    Array 1 :   1   2   3   4   5
    Array 2 :   1   3   2   5   4

    Output : True.

    Try less than O(n log n) time.
    http://stackoverflow.com/questions/10639661/check-if-array-b-is-a-permutation-of-a
    http://stackoverflow.com/questions/6691184/find-if-two-arrays-contain-the-same-set-of-integers-without-extra-space-and-fast

    ===================================================================================================================================================================================================    
    */
    partial class ArraySamples
    {
        public void Compare2ArraysTest()
        {
            int[] Array1 = { 1, 2, 3, 4, 5 };
            int[] Array2 = { 1, 3, 2, 5, 4 };
            bool result = false;
            
            //IntPtr intptr = &Array1;

            char[] chArray1 = new char[Array1.Length];
            char[] chArray2 = new char[Array2.Length];

//            Array.ConvertAll(Array1,chArray1, new Converter<int,char>);

            for (int lpCnt = 0; lpCnt < Array2.Length; lpCnt++)
            {
                chArray2[lpCnt] = Convert.ToChar(Array2[lpCnt] + '0');
                //Array1[lpCnt] = chArray1[lpCnt] - '0';
            }

            stringBldr.Clear();

            stringBldr.AppendLine("Source Array 1 : " + new string(Array1.Select(ch=> Convert.ToChar(ch + '0')).ToArray()));
            stringBldr.AppendLine("Source Array 2 : " + new string(chArray2));
            
            result = Compare2Arrays(Array1, Array2);
            stringBldr.AppendLine("Compare 2 Arrays result : " + result);

            MessageBox.Show(stringBldr.ToString());

        }

        public bool Compare2Arrays(int[] array1, int[] array2)
        {
            //Dictionary<int, int> intTable = new Dictionary<int, int>();
            HashSet<int> uniqueTable = new HashSet<int>();

            for (int lpCnt = 0; lpCnt < array1.Length; lpCnt++)
            {
                if (!uniqueTable.Contains(array1[lpCnt]))
                {
                    uniqueTable.Add(array1[lpCnt]);
                }
            }

            bool areSame = true;

            for (int lpCnt = 0; lpCnt < array2.Length; lpCnt++)
            {
                if (!uniqueTable.Contains(array2[lpCnt]))
                {
                    areSame = false;
                    break;
                }
            }

            return areSame;
        }
    }
}
