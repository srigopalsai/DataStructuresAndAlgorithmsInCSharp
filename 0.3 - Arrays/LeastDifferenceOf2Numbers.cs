using System;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    Find the least difference between any two elements of an integer array.

    First sort the elements of the array. 
    Then iterate over the array and find difference between consecutive elements. 
    The least of them would be the least differences between any two elements of the array. 
    
    The complexity will be O(nlogn) because of the sorting step.

    ===================================================================================================================================================================================================
    */
    partial class ArraySamples
    {
        public void LeastDifferenceOf2Numbers()
        {
            int[] arr = { 64, 57, 2, 78, 43, 73, 53, 86 };

            Array.Sort(arr);
            int minDiff = Int32.MinValue;

            for (int i = 0; i < arr.Length - 1; ++i)
            {
                int diff = Math.Abs(arr[i] - arr[i + 1]);
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
            }
            MessageBox.Show("The lease min diff of 2 nums in array is " + minDiff.ToString());
        }

    }
}