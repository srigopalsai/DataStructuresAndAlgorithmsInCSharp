using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    partial class BinaryAndBitwiseOperations
    {
        public void MultiplyUsingStrings(string num1, string num2)
        {
            int result = 0;
            for (int i = 0; i < num1.Length; i++)
            {
                for (int j = 0; j < num2.Length; j++)
                {
                    result += (num1[i] - '0') * (num2[j] - '0')

                            * (int)Math.Pow(10, num1.Length * 2 - (i + j + 2));
                }
            }

            MessageBox.Show("Multiplication of 2 Numbers, Num1 : " + num1 + " Num2 : " + num2 + " Result : " + result);
        }
        public string Multiply(string num1, string num2)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(num1))
                {
                    throw new Exception("Num1 cannot be null,empty or whitespace");
                }
                else if (string.IsNullOrWhiteSpace(num2))
                {
                    throw new Exception("Num1 cannot be null,empty or whitespace");
                }
                foreach (Char digit in num1)
                {
                    if (digit < '0' || digit > '9')
                    {
                        throw new Exception("Num1 has invalid char");
                    }
                }

                //--------------------------------------------------------------
                int product = 0;
                int carry = 0;
                int sum = 0;

                string result = string.Empty;
                string partial = string.Empty;

                List<string> partialList = new List<string>();

                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    partial = string.Empty;
                    carry = 0;

                    for (int i = num1.Length - 1; i >= 0; i--)
                    {
                        product = ((num1[i] - '0') * (num2[2] - '0')) + carry;
                        carry = product / 10;
                        partial = (product % 10).ToString() + partial;
                    }

                    if (carry != 0)
                    {
                        partial = carry.ToString() + partial;
                    }

                    partialList.Add(partial);

                }
                for (int i = 0; i < partialList.Count(); i++)
                {
                    //partialList.Set(i,partialList.Get(i) + new string('0', i));
                }
                return string.Empty;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong :" + ex.Message);
                Console.WriteLine("Stack Trace :" + ex.StackTrace.ToString());
                throw ex;
            }
        }
    }
}