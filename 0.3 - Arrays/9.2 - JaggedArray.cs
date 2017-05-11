using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    //Is an array whose elements are arrays. 
    
    The elements of a jagged array can be of different dimensions and sizes. 
    // Sometimes called an "array of arrays." 
    
    int[][] jaggedArray = new int[3][];
    jaggedArray[0] = new int[] { 1, 3, 5, 7, 9 };
    jaggedArray[1] = new int[] { 0, 2, 4, 6 };
    jaggedArray[2] = new int[] { 11, 22 };

    ===================================================================================================================================================================================================
    */
    partial class ArraySamples
    {

        static void JaggedArrayDemo()
        {
            // Declare the array of two elements: 
            int[][] arr = new int[2][];
            
            string resultMessage = string.Empty;

            // Initialize the elements:
            arr[0] = new int[5] { 1, 3, 5, 7, 9 };
            arr[1] = new int[4] { 2, 4, 6, 8 };

            // Display the array elements: 
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    resultMessage += string.Format("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }

                
            }
            resultMessage += Environment.NewLine;            
            MessageBox.Show(resultMessage);
            
        }
    }
    /* Output:
        Element(0): 1 3 5 7 9
        Element(1): 2 4 6 8
    */
}