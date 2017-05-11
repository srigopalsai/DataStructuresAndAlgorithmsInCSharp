using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
     Input:     1   3    5
                2   4    7
                6   8    9
     http://stackoverflow.com/questions/19028613/kth-smallest-element-in-a-matrix-with-sorted-rows-and-columns
     Kth Largest :
     http://www.dsalgo.com/2013/02/find-kth-largest-element-in-sorted.html
    http://www.geeksforgeeks.org/forums/topic/kth-smallest-element-in-a-mxn-matrix/
     */
    class KthSmallestInSortedMatrix
    {
        public int KthSmallest(int[,] sortedArray)
        {
            int rowLen = sortedArray.GetUpperBound(0);
            int colLen = sortedArray.GetUpperBound(0);

            Stack<int> kItems = new Stack<int>();

            //            int kthSmallest = KthSmallestUsingHeap(sortedArray, kItems, 4, 0, 0);
            return -1;
        }

        //private int KthSmallestUsingHeap(int[,] sortedArray, Stack<int> kItems, int kthIndx, int rowIndx, int colIndx)
        //{
        //    if (colIndx > sortedArray.GetUpperBound(0) || rowIndx > sortedArray.GetUpperBound(0))
        //        return -1;

        //    kItems.Push(sortedArray[rowIndx, colIndx]);

        //    if (kItems.Count == kthIndx)
        //        return sortedArray[rowIndx, colIndx];


        //    if (sortedArray[rowIndx, colIndx + 1] > sortedArray[rowIndx + 1, colIndx])
        //        KthSmallestUsingHeap(sortedArray, kItems, kthIndx, rowIndx + 1, colIndx);


        //            if (sortedArray[lpRCnt,lpCCnt] < sortedArray[lp )
        //        }
        //    }
        //    return -1;
        //}    
    }
}