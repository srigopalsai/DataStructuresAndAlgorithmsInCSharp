using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class KthSmallestInSortedMatrix
    {
        /*
         Input:     1   3    5
                    2   4    7
                    6   8    9
         http://stackoverflow.com/questions/19028613/kth-smallest-element-in-a-matrix-with-sorted-rows-and-columns
         Kth Largest :
         http://www.dsalgo.com/2013/02/find-kth-largest-element-in-sorted.html
        http://www.geeksforgeeks.org/forums/topic/kth-smallest-element-in-a-mxn-matrix/
         

        // O(n) linear time
         
        Binary Search!
        [ 1,  5,  9],
        [10, 11, 13],
        [12, 13, 15]
        8
        
        (1 + 15) / 2 = 8, we are search where 8 is;
        We start from 12, 
        Case 1: 12 > 8, so move to 10, then to 1 (Target is smaller, move to UP!)
        Case 2: 1 < 8, move to 5 (res += 0 + 1), and move to 9 (res += 1 + 1); (Target is larger, move right, but add i + 1 (add the col!))
        
        return 2; 2 < 8, that means our guess is too small!
        
        */

        public int KthSmallest(int[,] matrix, int k)
        {
            int rowLen = matrix.GetLength(0) - 1;
            int colLen = matrix.GetLength(1) - 1;

            int loIndx = matrix[0, 0];
            int hiIndx = matrix[rowLen, colLen];

            while (loIndx < hiIndx)
            {
                int midIndx = loIndx + (hiIndx - loIndx) / 2;
                int kIndx = 0;
                int colIndx = colLen;

                for (int rowIndx = 0; rowIndx <= rowLen; rowIndx++)
                {
                    while (colIndx >= 0 && matrix[rowIndx, colIndx] > midIndx)
                    {
                        colIndx--;
                    }
                    kIndx += (colIndx + 1);
                }

                if (kIndx < k)
                {
                    loIndx = midIndx + 1;
                }
                else
                {
                    hiIndx = midIndx;
                }
            }

            return loIndx;
        }
    }
}