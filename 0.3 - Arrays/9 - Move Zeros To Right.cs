using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    In an integer array which contains some zeros. Move the zeros to the right side of the array with minimum number of swaps. 
    The order of the original array can be destroyed.
    
    Solution: 
     
     * It will take O(N) time in worst case, where there are no zeros. 
     * Best and average case it will be less than O(N/2)
     
     * Repeat loop from front index to rear index.
     * Consider front and rear pointers which points to front and rear elements in the array.
     * Front pointer should move from front to rear. rear pointer should move from rear to front. Based on the below conditions.
        * Increment front pointer and decrement rear pointer when front element contains zero and rear element contains non zero.
        * Increment only front pointer if it contains non zero.
        * Decrement only rear pointer if it contains zero.  

    ===================================================================================================================================================================================================     
    */
    partial class ArraySamples
    {
        /*
         * Worst case O(N-1) Time. 
         * E.g if there is only one zero at the end of the array. 
         * Front Index shoul reach n-1.
         */ 
        public void MoveZerosToRightInArray()
        {
            //int[] arrayElements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] arrayElements = new int[] { 0, 1, 0, 2, 3, 0, 4, 0, 5, 0 };
            int[] arrayElements = new int[] { 0, 0, 0, 0, 0, 1, 2, 3, 4, 5 };

            int frontIndex = 0;
            int rearIndex = arrayElements.Length;

            while (frontIndex < rearIndex)
            {
                if (arrayElements[frontIndex] == 0 && arrayElements[rearIndex] != 0)
                {
                    int temp = arrayElements[frontIndex];
                    arrayElements[frontIndex] = arrayElements[rearIndex];
                    arrayElements[rearIndex] = temp;

                    frontIndex++;
                    rearIndex--;
                }
                else if ( arrayElements[frontIndex] != 0)
                {
                    frontIndex++;
                }
                else if (arrayElements[rearIndex] == 0)
                {
                    rearIndex--;
                }
            }
        }
    }
}
