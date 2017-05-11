using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
    
    WAP to modify the array such that arr[I] = arr[arr[I]]. 
    Do this in place i.e. with out using additional memory. 

    E.g:
    Input:  arr[] = {3, 2, 0, 1}
    Output: arr[] = {1, 0, 3, 2}

    Input:  arr[] = {4, 0, 2, 1, 3}
    Output: arr[] = {3, 4, 2, 0, 1}

    Input:  arr[] = {0, 1, 2, 3}
    Output: arr[] = {0, 1, 2, 3}
     
    1) Increase every array element arr[i] by (arr[arr[i]] % n) * n.
    2) Divide every element by n.

    Step1:
    Every value is incremented by (arr[arr[i]] % n) * n
    After first step array becomes {7, 2, 12, 9}. 
    
    The important thing is, after the increment operation of first step, every element holds both old values and new values. 
    Old value can be obtained by arr[i]%n and new value can be obtained by arr[i]/n.

    Step2:
    All elements are updated to new or output values by doing arr[i] = arr[i]/n.
    Now, array becomes {1, 0, 3, 2}


    http://www.geeksforgeeks.org/rearrange-given-array-place/
    
    ===================================================================================================================================================================================================
    
    */

    partial class ArraySamples
    {
        static StringBuilder stringBldr = new StringBuilder();
        public static void GetArrayPositionsBasedOnItsElements()
        {
            int[] arrayElements = new int[] { 2, 3, 1, 0, 6, 5, 4 };
            int size = arrayElements.Length;

            //Step1
            for (int i = 0; i < size; i++)
            {
                arrayElements[i] += (arrayElements[arrayElements[i]] % size) * size;
            }

            //Step2
            for (int i = 0; i < size; i++)
            {
                arrayElements[i] = arrayElements[i]/ size;
            }

            for (int lpCnt = 0; lpCnt < size; lpCnt++)
            {
                stringBldr.Append("\t" + arrayElements[lpCnt]);
            }
        }
    }
}