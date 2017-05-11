using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    partial class ArraySamples
    {
        public void MaximumSumPathIn2ArraysTest()
        {
            // Demo 1 - Output 35
            int[] array1 = new int[] { 2, 3, 7, 10, 12 };
            int[] array2 = new int[] { 1, 5, 7, 08 };

            int resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 1 : " + resultSum);

            // Demo 2 - Output 22
            array1 = new int[] { 10, 12 };
            array2 = new int[] { 05, 07, 09 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 2 : " + resultSum);

            // Demo 3 - Output 122
            array1 = new int[] { 2, 3, 7, 10, 12, 15, 30, 34 };
            array2 = new int[] { 1, 5, 7, 08, 10, 15, 16, 19 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 3 : " + resultSum);

            // Demo 4 - Output 33
            array1 = new int[] { 5, 6, 9, 10 };
            array2 = new int[] { 1, 2, 5, 10 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 4 : " + resultSum);

            // Demo 4 - Output 43
            array1 = new int[] { 5, 6, 9, 10 };
            array2 = new int[] { 1, 2, 5, 10, 10 };

            resultSum = MaximumSumPathIn2Arrays(array1, array2);
            MessageBox.Show("Demo 4 : " + resultSum);
        }

        private int MaximumSumPathIn2Arrays(int[] array1, int[] array2)
        {
            int ar1LpCnt = 0;
            int ar2LpCnt = 0;
            
            int ar1Sum = 0;
            int ar2Sum = 0;

            int maxSum = 0;

            while (ar1LpCnt < array1.Length && ar2LpCnt < array2.Length)
            {
                if (array1[ar1LpCnt] < array2[ar2LpCnt])
                {
                    ar1Sum += array1[ar1LpCnt];
                    ar1LpCnt++;
                }
                else if (array1[ar1LpCnt] > array2[ar2LpCnt])
                {
                    ar2Sum += array2[ar2LpCnt];
                    ar2LpCnt++;
                }
                // Both elements are same         
                else
                {
                    //Reset sums.
                    ar1Sum = 0;
                    ar2Sum = 0;

                    maxSum = Math.Max(ar1Sum, ar2Sum);

                    while (array1[ar1LpCnt] == array2[ar2LpCnt] && ar1LpCnt < array1.Length && ar2LpCnt < array2.Length)
                    {
                        maxSum += array1[ar1LpCnt];
                        ar1LpCnt++;
                        ar2LpCnt++;
                    }
                }
            }

            ar1Sum = 0;
            ar2Sum = 0;

            while (ar1LpCnt < array1.Length)
            {
                ar1Sum += array1[ar1LpCnt];
                ar1LpCnt++;
            }

            while (ar2LpCnt < array2.Length)
            {
                ar2Sum += array2[ar2LpCnt];
                ar2LpCnt++;
            }

            maxSum += Math.Max(ar1Sum, ar2Sum);

            return maxSum;
        }
    }
}