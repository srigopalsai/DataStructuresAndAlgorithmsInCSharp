using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    http://www.sanfoundry.com/java-program-implement-convert-decimal-to-binary-using-stacks/
    */

    partial class StackOperations
    {
        static string strRslt = string.Empty;

        public static void ConvertDecimalToBinary(int decimalNumber)
        {
            Stack<int> binaryNumStack = new Stack<int>();
            while (decimalNumber > 0)
            {
                int bit = decimalNumber % 2;
                binaryNumStack.Push(bit);

                decimalNumber = (decimalNumber / 2);
            }
            
            while (binaryNumStack.Count > 0)
            {
                strRslt += binaryNumStack.Pop();
            }

            MessageBox.Show("Decimal Number : " + decimalNumber + " Binary Number : " + strRslt);
        }
    }
}