using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public  partial class BinaryAndBitwiseOperations
    {
        public void BasicOperations()
        {
            int frAnd6 = 4 & 6;
            int frIOr6 = 4 | 6;
            int frxOr6 = 4 ^ 6;
            int not6 = ~6;
            int frlfSft6 = 4 << 6;
            float frrSft6 = 4 >> 6;
            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            string str = " 4 & 6  : " + frAnd6;
            str += "\n 4 | 6  : " + frIOr6;
            str += "\n 4 ^ 6  : " + frxOr6;
            str += "\n ~ 6  : " + not6;
            str += "\n 4 << 6  : " + frlfSft6;
            str += "\n 4 >> 6  : " + frrSft6;

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            MessageBox.Show(str);

            int i = 10;
            int j = i << 1;
            int k = i >> 1;

            int l = i & j;
            int m = i | j;
            int n = ~j;

            // Detect if two integers have opposite signs  
            int x = 2, y = -3;

            bool f = ((x ^ y) < 0); // true iff x and y have opposite signs


            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            //char ch1 = 'A';
            //char ch2 = 'B';

            //char ch3 = ch1 << ch2;
            //char ch4 = ch1 >> ch2;
            //char ch5 = ch1 & ch2;

            //Swap With out Temp------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            
            int a = 5;
            int b = 6;
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
            //  Console.WriteLine(a);
            //  Console.WriteLine(b);

        }

        public void IsPalindromeBinaryNumber()
        {
 
        }
    }
}