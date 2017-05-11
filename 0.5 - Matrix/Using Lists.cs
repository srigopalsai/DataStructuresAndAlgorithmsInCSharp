using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    ===================================================================================================================================================================================================    
    */

    partial class MatrixOperations
    {
        public void UsingListsTest()
        {
            List<int[]> intlist = new List<int[]>();
            intlist.Add(new int[] { 1, 2, 3 });
            intlist.Add(new int[] { 4, 5, 6 });
            intlist.Add(new int[] { 7, 8, 9 });

            List<int>[]  a = new List<int>[100];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new List<int>();
            }

            List<List<int>> myList = new List<List<int>>(); //{ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        }

        public void UsingLists()
        {

        }
    }
}
