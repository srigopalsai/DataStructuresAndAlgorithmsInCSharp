using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class RecursionSamples
    {
        /* 
        O(n) Linear Time and Space: 
        
        1. Reduce the power sequentially on every call till zero. 
        2. Cumulate the number product on each call.
        */
        int PowerInLinearTime(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else if (power == 1)
            {
                return number;
            }
            else
            {
                int prevCallNum = PowerInLinearTime(number, power - 1);
                int result = number * prevCallNum;
                return  result;
            }
        }

        /* 
        O(Log n) Time and Space:

        1. Reduce the power to half on every call till zero. 
        2. Cumulate the number product on each odd call.
        3. When the call is for odd then multiply the number after making another call.
        */
        int PowerInLogTime(int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }
            else if (power == 1)
            {
                return number;
            }

            int multipliedNum = number * number;

            if (power % 2 == 0)
            {
                int prevCallNum1 = PowerInLogTime(multipliedNum, power / 2);
                return prevCallNum1;
            }
            else
            {
                int prevCallNum2 = PowerInLogTime( multipliedNum, power / 2);
                return number * prevCallNum2;
            }
        }
        
        public void PowerTest()
        {
            int result = PowerInLinearTime(2, 3);
            MessageBox.Show("Using Linear Time Approach. 2 to the power of 6 is " + result);
            
            result = PowerInLogTime(2, 12);
            MessageBox.Show("Using Logorathmic Time Approach. 2 To the Power of 9 is " + result);
        }
    }
}