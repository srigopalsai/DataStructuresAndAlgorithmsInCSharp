using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{

    /*
    http://www.dsalgo.com/2013/02/count-number-of-ones-till-n-in-binary.html
    */
    public class NumberOfOnes
    {

        /**
         * given n find the total number of ones in the binary representation of
         * numbers 1,2,3,...,n
         * 
         * @param args
         */
        public static void main(String[] args)
        {
            MessageBox.Show(Convert.ToString( getNumberOfOnes(30)));
        }

        public static int getNumberOfOnes(int num)
        {
            int p = 1, cnt = 0;

            if ((num & 1) != 0)
                cnt++;

            while (1 << (p - 1) < num)
            {
                if ((num & (1 << p)) != 0)
                    cnt += (1 << (p - 1)) * (p) + num % (1 << p) + 1;
                p++;
            }
            return cnt;
        }

    }
}
