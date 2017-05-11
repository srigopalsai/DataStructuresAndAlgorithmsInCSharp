using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataStructuresAndAlgorithms
{
    //Also called as linear search
    public partial class SearchingAlgorithms
    {
        //Compare each element in array with search element. End search if element found.
        public int SequentialOrLinearSearch()
        {
            //Input 4   3   7   8   2   9   5   1   6   0 (Unsorted Array)
            int[] ArrayElements = { 4, 3, 7, 8, 2, 9, 5, 1, 6, 0 };

            int elementToFind = 9;

            for (int lpCnt = 0; lpCnt < ArrayElements.Length; lpCnt++)
            {
                if (elementToFind == ArrayElements[lpCnt])
                {
                    return lpCnt;
                }
            }

            return -1;
        }
    }
}
