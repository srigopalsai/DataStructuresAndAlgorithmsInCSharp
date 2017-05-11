using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    A number in the array is called local minima if it is smaller than both its left and right numbers.
    Note: In an array of unique integers first two numbers are decreasing and last two numbers are increasing there ought to be a local minima.
    
    E.g. In an array 9,7,2,8,5,6,3,4      First two numbers are decreasing and last 2 numbers are increasing. 
    From the E.g. 2, 5 
    
    Solution: Use Devide and conquor method and time complexity is O(log n)

    ===================================================================================================================================================================================================  
    */
    partial class ArraySamples
    {
        public static int FindLocalMinima()
        {
            int[] arrayElements = new int[] { 9, 7, 2, 8, 5, 6, 3, 4 };

            int frontPos = 0;
            int rearPos = arrayElements.Length;

            while (frontPos < rearPos)
            {
                int midPos = (rearPos + frontPos) / 2;
                if (midPos < 0 && (midPos + 1) >= arrayElements.Length)
                {
                    //Loop reached extream and couldnt fine any, so retun -1;
                    return -1;
                }
//                if (arrayElements[midPos - 2] > arrayElements[midPos-1] && arrayElements[midPos-1] < arrayElements[midPos])
                if (arrayElements[midPos - 1] > arrayElements[midPos] && arrayElements[midPos] < arrayElements[midPos+1])
                {
                    return arrayElements[midPos];
                }

                if (arrayElements[midPos ] > arrayElements[midPos - 1])
                {
                    rearPos = midPos;
                }
                else
                {
                    frontPos = midPos;
                }
            }
            return -1;
        }
    }
}
