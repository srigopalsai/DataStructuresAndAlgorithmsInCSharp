using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Average Time : Log(Log N))
    Worst Case : O(N)

    In the worst case (for instance where the numerical values of the keys increase exponentially) it can make up to O(n) comparisons.

    http://www.geeksforgeeks.org/g-fact-84/
    http://en.wikipedia.org/wiki/Interpolation_search
    */
    partial class SearchingAlgorithms
    {
        public int interpolationSearch(int[] sortedArray, int toFind)
        {
            // Returns index of toFind in sortedArray, or -1 if not found
            int low = 0;
            int high = sortedArray.Length - 1;
            int mid;

            while (sortedArray[low] <= toFind && sortedArray[high] >= toFind)
            {
                mid = low +
                      ((toFind - sortedArray[low]) * (high - low)) /
                      (sortedArray[high] - sortedArray[low]);  //out of range is possible  here

                if (sortedArray[mid] < toFind)
                {
                    low = mid + 1;
                }
                else if (sortedArray[mid] > toFind)
                {
                    // Repetition of the comparison code is forced by syntax limitations.
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (sortedArray[low] == toFind)
            {
                return low;
            }
            else
            {
                return -1; // Not found
            }
        }
        //bool InterpolationSearch(int[] array, int low, int high, int toFind, int size)
        //{
        //    int mid;

        //    while (array[low] <= toFind && array[high] >= toFind)
        //    {

        //        mid = low + ((toFind - array[low]) * (high - low)) / (array[high] - array[low]);

        //        if (array[mid] == toFind)
        //        {
        //            return true;
        //        }
        //        else if (array[mid] > toFind)
        //        {
        //            high = mid - 1;
        //        }
        //    }
        //    return false;
        //}
    }
}