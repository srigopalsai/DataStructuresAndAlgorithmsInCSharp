using System;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    Threaded : http://zobayer.blogspot.com/2010/09/threaded-merge-sort.html
    Not Adaptive


    Alogorithm :

    1) Divide the list into two sublists
    2) Merge sort the first sublist
    3) Merge sort the second sublist
    4) Repeat above steps till sublist length is 1.
    4) Start Merging back the sub lists back till reach the original list.

    Merge Sort or  Balanced K-Way Merge Sort

	Can implement in different ways
    1. Top - Down implementation
    1. Bottom - Up implementation
    3. Natural Merge ( Similar to Bottom - Up )

    Useful in online sorting.
    
    Concurrency : 
    
    Merge sort parallelizes well due to use of the divide-and-conquer method. 

    Types :

    1. Top-Down
    2. Bottum-Up
    ============================================================================================================================================================================================================================

    Time Complexity Calculation : 
	
        1. Using Recurrence Relation :

            (n-1)	Each time a minimum of n-1 comparisons is performed.

            If 1  element       no comparison
            If 2  elements->    max 1 comparison
            If 4  elements->    3 comparisons

        2. Using Master Theorem : 
                a=2,b=2,f(n)=n-1
                log b a=1
	
            By case 2,f(n)=Ѳ(n1 )=O(n)
                T(n)= Ѳ(n log n)

        3. By Substitution Method :

            T(n) = 2T(n/2)       + (n-1)
                 = 2 (2T(n/22 )  + ((n/2)-1)) + (n-1)
                 = 22  T(n/22 )  + (n-2)      + (n-1)
                 = 22 (2T(n/23 ) + ((n/4)-1)) + (2n-(1+2))
                 = 23 T (n/23 )  + 3n-(1+2+22 )
                        .
                        .
                 = 2k T(n/2k )+kn-(1+2+…+2k-1 )
        
           Let n = 2k
                 = 2k T(1 ) + n log n-(2k -1 )
                 = n log n-n+1
                 = Ѳ(n log n)

    Space Complexity : O (n )

	Additional array b of size n    T(n)= Ѳ(n)
    http://www.personal.kent.edu/~rmuhamma/Algorithms/MyAlgorithms/Sorting/mergeSort.htm
    http://www.algorithmist.com/index.php/Merge_sort

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	
	References :
    
    http://en.wikipedia.org/wiki/Merge_sort
    http://www.codecodex.com/wiki/Merge_sort
    http://tutorials.csharp-online.net/index.php?title=Merge_Sort
    http://www.cquestions.com/2011/07/merge-sort-program-in-c.html
    http://stackoverflow.com/questions/2571049/how-to-sort-in-place-using-the-merge-sort-algorithm
    http://www.personal.kent.edu/~rmuhamma/Algorithms/MyAlgorithms/Sorting/mergeSort.htm
    http://www.codenlearn.com/2011/10/simple-merge-sort.html
    https://www.princeton.edu/~achaney/tmve/wiki100k/docs/Merge_sort.html

    ============================================================================================================================================================================================================================
    */

    partial class SortingSamples
    {
        public void RunMergeSortTests()
        {
            TestData.TestCasesCount = 0;
            TestData.TestCasesFailed = 0;
            TestData.TestCasesPassed = 0;

            displayMessage = "Merge Sort :";

            int tcCnt = 0;

            foreach (int[] testArray in TestData.ArraysCollection.Values)
                MergeSortTest(testArray, ++tcCnt);

            TestData.ShowResults(displayMessage);
        }

        public void MergeSortTest(int[] listToSort, int caseNo)
        {
            if (listToSort == null)
                return;

            TestData.TestCasesCount++;

            displayMessage += TestData.ConvertArrayToString(listToSort, string.Format("\n\n{0}. Source ", caseNo));

            MergeSort(listToSort, 0, listToSort.Length - 1);
            displayMessage += TestData.ConvertArrayToString(listToSort, string.Format("\n{0}. Output ", caseNo));

            bool sortValid = TestData.ValidateSort(listToSort);
            if (sortValid == false)
            {
                displayMessage += " - *** Failed ***";
                TestData.TestCasesFailed++;
            }
            else
                TestData.TestCasesPassed++;
        }

        public void MergeSort(int[] listToSort, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int midIndex = (leftIndex + rightIndex) / 2;

                // Apply Merge Sort on Left half array recursively.
                MergeSort(listToSort, leftIndex, midIndex);

                // Apply Merge Sort on Right half array recursively.
                MergeSort(listToSort, midIndex + 1, rightIndex);

                PartitionAndMerge(listToSort, leftIndex, midIndex, rightIndex);
            }
        }

        // Takes extra memory.
        public void PartitionAndMerge(int[] listToSort, int startIndx, int centerIndx, int endIndx)
        {
            /* // Show Sort Progress
               Console.Write("Left: ");
               ShowArrayOnConsole(listToSort, startIndxPtr, centerIndxPtr);
               Console.Write(" Right: ");
               ShowArrayOnConsole(listToSort, centerIndxPtr + 1, endIndxPtr);
               Console.WriteLine();
            */
            
            int leftIndxPtr = startIndx;
            int tempArrayIndex = 0;
            int midIndxPtr = centerIndx + 1;

            int tempArrLen = endIndx - startIndx;
            int[] tempArray = new int[tempArrLen + 1];

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Pick elements from Left Sub Array or Right Sub Array which ever elements are smaller till one of the Sub Array finished first.
            while (leftIndxPtr <= centerIndx && midIndxPtr <= endIndx)
            {
                // Copy to temp array from Left to Mid - Smaller than Mid.
                if (listToSort[leftIndxPtr] <= listToSort[midIndxPtr])
                {
                    tempArray[tempArrayIndex] = listToSort[leftIndxPtr];
                    leftIndxPtr++;
                }

                // Copy to temp array from Mid to Right - Larger than Mid.
                else
                {
                    tempArray[tempArrayIndex] = listToSort[midIndxPtr];
                    midIndxPtr++;
                }

                tempArrayIndex++;
            }

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Pick remaining all elements from Left Sub Array, if any elements are left in above loop. 
            // Incase of Right Sub Array is larger or has more smaller elements.
            while (leftIndxPtr <= centerIndx)
            {
                // Copy to temp array from Left to Mid - Smaller than Mid.
                tempArray[tempArrayIndex] = listToSort[leftIndxPtr];

                leftIndxPtr++;
                tempArrayIndex++;
            }

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Pick remaining all elements from Right Sub Array, if any elements are left in above loop. 
            // Incase of Right Sub Array is larger or has more smaller elements.
            while (midIndxPtr <= endIndx)
            {
                // Copy to temp array from Right to Mid - Larger than Mid.
                tempArray[tempArrayIndex] = listToSort[midIndxPtr];

                midIndxPtr++;
                tempArrayIndex++;
            }

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Update back All elements from temp Array to soruce array.
            for (int lpIndxPtr = startIndx, tmpIndx =0;  lpIndxPtr <= endIndx; lpIndxPtr++, tmpIndx++)
            {
                listToSort[lpIndxPtr] = tempArray[tmpIndx];
            }

         /* Console.Write("After Merge: ");
            ShowArrayOnConsole(listToSort, startIndxPtr, endIndxPtr);
            Console.WriteLine(); */
        }
    }
}