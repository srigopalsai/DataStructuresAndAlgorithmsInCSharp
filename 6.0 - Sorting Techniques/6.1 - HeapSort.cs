using System;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
        ========================================================================================================================================================================================================================
        Key Point(S) : Parent Index can start from 0 or 1.
                       Constuct Max Heap or Min Heap.

        A heap can be seen as a complete binary tree OR as an array.

            E.g. in an array A

            • The root node is A[1] or A[0]    * Array index can starts with 1 or 0. 
            • Node i is A[i]            i denotes index of the element in array A         

            * Parent   Node of i poistion element  =  i / 2     i  / 2
            * Left     Node of i poistion element  = 2i         i  X 2
            * Right    Node of i poistion element  = 2i + 1     i  X 2 + 1

            Index i :   0       1       2       3       4       5       6       7       8       9       10
            Array   :   0       160     140     100     80     70       90      30      20      40      10
         
            Element 10 Parent is its index is 9 and its parent is 9/2 = 4  i.e 70
            Note : Index elements started from 1.
        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                        160
                       /   \  
                      /     \
                     /       \
                    140      100
                   /  \       /\
                  /    \     /  \  
                 80     70  90   30
                /  \    /          
               20  40  10

            If we want to maintain index from 0 then. 
            
            • The root node is A[1]     * Array index starts with 0. 
            • Node i is A[i]            i denotes index of the element in array A

            * Parent   Node of i poistion element  =  i - 1/2   A[(i - 1) /2] (note: integer divide)
            * Left     Node of i poistion element  = 2i + 1     A[2i + 1]
            * Right    Node of i poistion element  = 2i + 2     A[2i + 2]

        Note : If the Array Lenght is Even then there wont be a rightChild.
        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Property:

        Min Heap Property: ( Parent <= Child )
            In an Array Parent element should be less than or equal to its child. Array[Parent(i)] <= Array[i] 
                 2 
                / \
               4   6
         
        Max Heap Property: ( Parent >= Child )
            In an Array Parent element should be grater than or equal to its child. Array[Parent(i)] >= Array[i]

                 8 
                / \
               2   4
        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        How Heap sort works?

        It starts with building a heap by inserting the elements entered by the user, in its place.

        1. Increase the size of the heap as a value is inserted.
        2. Insert the entered value in the last place.
        3. Processing.
            1st Phase   : Build Heap. O(n) (Referred as Insert or Create Heap)

                    Compare the inserted value with its parent, until it satisfies the heap property and then place it at its right position.
                    Building a heap uses Heapify on every node.

            2nd Phase   : n Deletions. O (log n) for each element total O(n log n) 
                
                    Heap sort algorithm takes biggest/smallest element 'off the heap' (delete from heap) and places it at the end of an array. 
                    In other words, Remove the elements from top to bottom, while maintaining the heap property to obtain the sorted list of entered values.
                    This phase continue until all the elements are placed in the array that are in sorted order.      
       
            So total time O(n) + O(n log n) = O(n log n)

            Best Case : O(n) Worst Case : O(n log n)
        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Example :

        1. Compare the inserted value with its parent, until it satisfies the heap property and then place it at its right position.
        2. heap[1] is the minimum element. So we remove heap[1]. Size of the heap is decreased.
        3. Now heap[1] has to be filled. We put the last element in its place and see if it fits. If it does not fit, take minimum element among both its children and replaces parent with it.
        4. Again see if the last element fits in that place.

        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Best Case performance       – Input array is already sorted     O(n log n)
        Worst case performance      – Input array is in reverse order   O(n log n)
        Average case performance    – Input array is sorted 50%         O(n log n)

        Space                       - O(1) Extra space.

        Not Stable
        Not Really Adaptive

        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Operations :
    
        Create-heap                   : Create an empty heap
        Heapify                       : Create a heap out of given array of elements
        Find-max or find-min          : Find the maximum item of a max-heap or a minimum item of a min-heap, respectively (aka, peek)
        Delete-max or delete-min      : Removing the root node of a max- or min-heap, respectively
        Increase-key or decrease-key  : Updating a key within a max- or min-heap, respectively
        Insert                        : Adding a new key to the heap
        Merge                         : Joining two heaps to form a valid new heap containing all the elements of both.
        Meld(h1,h2)                   : Return the heap formed by taking the union of the item-disjoint heaps h1 and h2. Melding destroys h1 and h2.
        Size                          : Return the number of items in the heap.
        IsEmpty()                     : Returns true if the heap is empty, false otherwise.
        BuildHeap(list)               : Builds a new heap from a list of keys.
        ExtractMin() OR ExtractMax()  : Returns the node of minimum value from a min heap [or maximum value from a max heap] after removing it from the heap
        Union()                       : Creates a new heap by joining two heaps given as input.
        Shift - Up                    : Move a node up in the tree, as long as needed (depending on the heap condition: min-heap or max-heap)
        Shift - Down                  : Move a node down in the tree, similar to Shift-up

        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Uses :

        1. Priority Queues  : Priority queues can be efficiently implemented using Binary Heap because it supports insert(), delete() and extractmax(), decreaseKey() operations in O(log n) time. 
        2. Binary Heap      : Binomoial Heap and Fibonacci Heap are variations of Binary Heap. These variations perform union also in O(logn) time which is a O(n) operation in Binary Heap. 
        3. In Graphs        : Heap Implemented priority queues are used in Graph algorithms like Prim’s Algorithm and Dijkstra’s algorithm.
        4. Kth Smallest     : Can be used to efficiently find the kth smallest (or biggest) element in an array.

        For dynamic memory Allocation    http://www.geeksforgeeks.org/forums/topic/regarding-heap-for-dynamic-memory-allocation/
        Sort Nos Stored in differnt Machines http://www.geeksforgeeks.org/sort-numbers-stored-on-different-machines/

        Quick Sort vs Heap Sort. http://www.geeksforgeeks.org/forums/topic/quick-sort-vs-heap-sort/
    
        Limitation :
        
        Cannot works well with Linked Lists. http://www.geeksforgeeks.org/a-data-structure-question/

        ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Reference Links :
        
        http://en.wikipedia.org/wiki/Heap_%28data_structure%29
        http://en.wikipedia.org/wiki/Heapsort
        http://en.wikipedia.org/wiki/Binary_heap
        http://stackoverflow.com/questions/9478268/heapsort-what-is-the-difference-relation-between-percolate-down-shift-down-and/9487846#9487846
        http://www.codecodex.com/wiki/Heapsort

        https://www.youtube.com/watch?v=q7R_upR81FU&list=PLJ7II9mlYqWjUc3_E_AO9JmXVfxMSC-3n&index=24
        https://www.youtube.com/watch?v=D_B3HN4gcUA&list=PLJ7II9mlYqWjUc3_E_AO9JmXVfxMSC-3n&index=26
        https://www.youtube.com/watch?v=JhCe8nhndPA
        http://www.youtube.com/watch?v=B7hVxCmfPtM
        https://www.youtube.com/watch?v=-6-xKgLOZPM

        http://www.personal.kent.edu/~rmuhamma/Algorithms/MyAlgorithms/Sorting/heapSort.htm
        http://www.thelearningpoint.net/computer-science/arrays-and-sorting-heap-sort--with-c-program-source-code
        http://www.cprogramming.com/tutorial/computersciencetheory/heapsort.html
        http://www.bogotobogo.com/Algorithms/heapsort.php
        http://stackoverflow.com/questions/13012291/array-index-in-heapsort/13012446#13012446
        Not written in proper standard : http://www.sanfoundry.com/c-program-heap-sort-algorithm/
        

        http://www.cs.sfu.ca/CourseCentral/307/petra/2009/SLN_2.pdf
        http://www.sanfoundry.com/java-program-implement-heap/

        Heap Corruption : http://www.efnetcpp.org/wiki/Heap_Corruption
        ========================================================================================================================================================================================================================
*/

    partial class SortingSamples
    {
        public void RunHeapSortTests()
        {
            TestData.TestCasesCount = 0;
            TestData.TestCasesFailed = 0;
            TestData.TestCasesPassed = 0;

            displayMessage = "Heap Sort :";

            int tcCnt = 0;

            foreach (int[] testArray in TestData.ArraysCollection.Values)
                HeapSortTest(testArray, ++tcCnt);

            TestData.ShowResults(displayMessage);
        }

        public void HeapSortTest(int[] listToSort, int caseNo)
        {
            if (listToSort == null)
                return;

            TestData.TestCasesCount++;

            displayMessage += TestData.ConvertArrayToString(listToSort, string.Format("\n\n{0}. Source ", caseNo));

            HeapSort(listToSort);
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

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void HeapSort(int[] listToSort)
        {
            int currentHeapSize = listToSort.Length;

            //BuildMaxHeap(listToSort, currentHeapSize);
            int parentIndex = (currentHeapSize - 1) / 2; // Start from mid array.

            while (parentIndex >= 0)
            {
                Heapify(listToSort, parentIndex, currentHeapSize);
                parentIndex--;
            }

            // Keep moving out max element from the heap till the size of the heap is 1.
            while (currentHeapSize > 1)
            {
                //Move(swap with last) each largest element from max heap to last.
                Common.Swap(listToSort, 0, currentHeapSize - 1);

                //Reduce heap size by 1 as excluding the sorted item from heap.
                currentHeapSize--;

                // Re heapify from root as it gets moved everytime to last for sorting.
                Heapify(listToSort, 0, currentHeapSize);
            }
        }

        // O(n log n)
        public void BuildMaxHeap(int[] listToSort, int currentHeapSize)
        {
            int parentIndex = (currentHeapSize - 1) / 2; // Start from mid array.

            while (parentIndex >= 0)
            {
                Heapify(listToSort, parentIndex, currentHeapSize);
                parentIndex--;
            }
        }

        // O (log n)
        public void Heapify(int[] listToSort, int parentIndex, int currentHeapSize)
        {
            int largestItemIndex = parentIndex;
            int leftChildIndex = 2 * parentIndex + 1;
            int rightChildIndex = 2 * parentIndex + 2;

            if (leftChildIndex < currentHeapSize && listToSort[leftChildIndex] > listToSort[largestItemIndex])
            {
                largestItemIndex = leftChildIndex;
            }

            if (rightChildIndex < currentHeapSize && listToSort[rightChildIndex] > listToSort[largestItemIndex])
            {
                largestItemIndex = rightChildIndex;
            }

            // If largest is not parent, then it might be left or right child so need to swap them.
            if (largestItemIndex != parentIndex)
            {
                Common.Swap(listToSort, largestItemIndex, parentIndex);
                Heapify(listToSort, largestItemIndex, currentHeapSize);
            }
        }
    }
}