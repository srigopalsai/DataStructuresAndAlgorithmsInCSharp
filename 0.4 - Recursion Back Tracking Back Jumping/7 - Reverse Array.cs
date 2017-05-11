using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================

    http://www.geeksforgeeks.org/program-for-array-rotation-continued-reversal-algorithm/
    http://stackoverflow.com/questions/11322514/reverse-an-array-without-using-iteration

    ============================================================================================================================================================================================================================    
    */
    partial class RecursionSamples
    {
        public void ReverseArrayTest()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Source Array: ");
            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                Console.Write(array[lpCnt] + " ");
            }
         
            ReverseArray(array, 0, array.Length - 1);

            Console.WriteLine("Reverse Array: ");
            for (int lpCnt = 0; lpCnt < array.Length; lpCnt++)
            {
                Console.Write(array[lpCnt] + " ");
            }
        }
        public void ReverseArray(int[] array, int stIndx, int lstIndx)
        {
            if (stIndx < lstIndx)
            {
                Common.Swap(ref array[stIndx], ref array[lstIndx]);
                ReverseArray(array, stIndx + 1, lstIndx - 1);
            }
        }
    }
}