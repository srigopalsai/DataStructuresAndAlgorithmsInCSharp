using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/Binary_heap
    http://www.sanfoundry.com/java-program-implement-heap/
    http://www.cse.iitk.ac.in/users/dsrkg/cs210/html/lectures.htm
    http://stackoverflow.com/questions/5527437/rolling-median-in-c-turlach-implementation
    https://simpledevcode.wordpress.com/2015/08/05/the-heap-data-structure-c-java-c/
    http://stackoverflow.com/questions/10229797/heap-data-structure-in-net
    http://stackoverflow.com/questions/1309263/rolling-median-algorithm-in-c
    http://stackoverflow.com/questions/10657503/find-running-median-from-a-stream-of-integers
    http://www.ardendertat.com/2011/11/03/programming-interview-questions-13-median-of-integer-stream/
    http://code.geeksforgeeks.org/8eO055

    Applications :
    1. Find Median of Stream of Integers.       http://www.geeksforgeeks.org/median-of-stream-of-integers-running-integers/
    Using Queues http://stackoverflow.com/questions/1309263/rolling-median-algorithm-in-c
    https://gist.github.com/Vedrana/3675434
    https://miafish.wordpress.com/2015/03/16/median-in-a-stream-of-integers/
    Find with finite space
    http://stackoverflow.com/questions/3378506/probability-of-finding-the-median-with-finite-space

    Medians of Median using selection algorithm https://en.wikipedia.org/wiki/Median_of_medians
    Histogram http://stackoverflow.com/questions/21052053/find-a-median-of-n2-numbers-having-memory-for-n-of-them?noredirect=1&lq=1
    2. Find Kth Largest of Stream of Integers.  http://www.geeksforgeeks.org/kth-largest-element-in-a-stream/

    Heap or Binary Heap :

     * A binary tree that stores priorities. (or prioirty element) pairs at nodes.
     * Structural Property: All levels except last are full. Last level is left-filled.
     * Heap Property: Priority of node is at least as large as that of its parent.
     * Priority of node is less than or equals to its children.
     *
    In computer science, a heap is a specialized tree-based data structure that satisfies the heap property: 
	
    If A is a parent node of B then key(A) is ordered with respect to key(B) with the same ordering applying across the heap. 
    Either the keys of parent nodes are always greater than or equal to those of the children and the highest key is in the root node (this kind of heap is called max heap).
    Or the keys of parent nodes are less than or equal to those of the children and the lowest key is in the root node (min heap). 
    Heaps are crucial in several efficient graph algorithms such as Dijkstra's algorithm, and in the sorting algorithm heapsort.
		
    The operations commonly performed with a heap are:

    1.    Create-Heap                   : reate an empty heap
    2.    Heapify                       : Create a heap out of given array of elements
    3.    Find - Max or Find - Min      : Find the maximum item of a max-heap or a minimum item of a min-heap, respectively (aka, peek)
    4.    Delete - Max or Delete - Min  : Removing the root node of a max- or min-heap, respectively
    5.    Increase - Key or Decrease-Key: Updating a key within a max- or min-heap, respectively
    6.    Insert                        : Adding a new key to the heap
    7.    Merge                         : Joining two heaps to form a valid new heap containing all the elements of both.

    Heap	                        Swap elements	Delete element	Sorted array	Notes
    8, 6, 7, 4, 5, 3, 2, 1	        8, 1			                                swap 8 and 1 in order to delete 8 from heap
    1, 6, 7, 4, 5, 3, 2, 8		                     8		                        delete 8 from heap and add to sorted array
    1, 6, 7, 4, 5, 3, 2	            1, 7		                                8	swap 1 and 7 as they are not in order in the heap
    7, 6, 1, 4, 5, 3, 2	            1, 3		                                            8	swap 1 and 3 as they are not in order in the heap
    7, 6, 3, 4, 5, 1, 2	            7, 2		8	swap 7 and 2 in order to delete 7 from heap
    2, 6, 3, 4, 5, 1, 7		                        7	8	delete 7 from heap and add to sorted array
    2, 6, 3, 4, 5, 1	            2, 6		7, 8	swap 2 and 6 as they are not in order in the heap
    6, 2, 3, 4, 5, 1	            2, 5		7, 8	swap 2 and 5 as they are not in order in the heap
    6, 5, 3, 4, 2, 1	            6, 1		7, 8	swap 6 and 1 in order to delete 6 from heap
    1, 5, 3, 4, 2, 6		        6	7, 8	delete 6 from heap and add to sorted array
    1, 5, 3, 4, 2	                1, 5		6, 7, 8	swap 1 and 5 as they are not in order in the heap
    5, 1, 3, 4, 2	                1, 4		6, 7, 8	swap 1 and 4 as they are not in order in the heap
    5, 4, 3, 1, 2	                5, 2		6, 7, 8	swap 5 and 2 in order to delete 5 from heap
    2, 4, 3, 1, 5		            5	6, 7, 8	delete 5 from heap and add to sorted array
    2, 4, 3, 1	                    2, 4		5, 6, 7, 8	swap 2 and 4 as they are not in order in the heap
    4, 2, 3, 1	                    4, 1		5, 6, 7, 8	swap 4 and 1 in order to delete 4 from heap
    1, 2, 3, 4		                4	5, 6, 7, 8	delete 4 from heap and add to sorted array
    1, 2, 3	1, 3		            4, 5, 6, 7, 8	swap 1 and 3 as they are not in order in the heap
    3, 2, 1	3, 1		            4, 5, 6, 7, 8	swap 3 and 1 in order to delete 3 from heap
    1, 2, 3		                    3	4, 5, 6, 7, 8	delete 3 from heap and add to sorted array
    1, 2	1, 2		            3, 4, 5, 6, 7, 8	swap 1 and 2 as they are not in order in the heap
    2, 1	2, 1		            3, 4, 5, 6, 7, 8	swap 2 and 1 in order to delete 2 from heap
    1, 2		                    2	3, 4, 5, 6, 7, 8	delete 2 from heap and add to sorted array
    1		                        1	2, 3, 4, 5, 6, 7, 8	delete 1 from heap and add to sorted array
                1, 2, 3, 4, 5, 6, 7, 8	completed

    */


    /*
    No Answer 
    http://stackoverflow.com/questions/3440905/find-the-median-from-a-stream-of-integers/3441042#3441042
    http://stackoverflow.com/questions/10657503/find-running-median-from-a-stream-of-integers
    http://stackoverflow.com/questions/3440905/find-the-median-from-a-stream-of-integers
    http://stackoverflow.com/questions/2579912/how-do-i-find-the-median-of-numbers-in-linear-time-using-heaps
    http://stackoverflow.com/questions/3572640/interview-question-find-median-from-mega-number-of-integers?rq=1
    http://stackoverflow.com/questions/21052053/find-a-median-of-n2-numbers-having-memory-for-n-of-them?noredirect=1&lq=1
    http://stackoverflow.com/questions/9841416/find-median-in-a-fixed-size-moving-window-along-a-long-sequence-of-data?rq=1
    http://stackoverflow.com/questions/5527437/rolling-median-in-c-turlach-implementation
    http://stackoverflow.com/questions/2579912/how-do-i-find-the-median-of-numbers-in-linear-time-using-heaps?rq=1
    http://stackoverflow.com/questions/1058813/on-line-iterator-algorithms-for-estimating-statistical-median-mode-skewnes?rq=1
    http://stackoverflow.com/questions/3888036/finding-median-of-large-set-of-numbers-too-big-to-fit-into-memory?rq=1
     */
    //=======================================================================================================================================================================
    public delegate bool CompareDelegate(int num1, int num2); 

    public class Heap
    {
        public int[] HeapArray { get; set; }

        public int HeapIndex { get; set; }

        public CompareDelegate Compare { get; set; }

        // Initializes heap array and comparator required in heapification
        public Heap()
        {
            HeapIndex = -1;
        }

        public int left(int i)
        {
            return 2 * i + 1;
        }

        public int right(int i)
        {
            return 2 * (i + 1);
        }

        public int GetParentIndex(int childIndex)
        {
            if (childIndex <= 0) return -1;

            return (childIndex - 1) / 2;
        }

        public int top()
        {
            int max = -1;

            if (HeapIndex >= 0)
                max = HeapArray[0];

            return max;
        }

        public int count()
        {
            return HeapIndex + 1;
        }

        // Note that, for the current median tracing problem we need to heapify only towards root, always
        public void Heapify(int index)
        {
            int parentIndex = GetParentIndex(index);

            // comp - differentiate MaxHeap and MinHeap percolates up
            //if (parentIndex >= 0 && comp(A[i], A[parentIndex]))
            {
                Common.Swap(HeapArray, index, parentIndex);
                Heapify(parentIndex);
            }
        }

        // Helper to insert key into Heap
        public bool InsertLast(int key)
        {
            bool success = false;

            if (HeapIndex < 128) //MAX_HEAP_SIZE
            {
                success = true;
                HeapIndex++;
                HeapArray[HeapIndex] = key;

                Heapify(HeapIndex);
            }

            return success;
        }

        public int DeleteTop()
        {
            int delVal = -1;

            if (HeapIndex > -1)
            {
                delVal = HeapArray[0];

                Common.Swap(HeapArray, 0, HeapIndex);
                HeapIndex--;
                int parentIndex = GetParentIndex(HeapIndex + 1);
                Heapify(parentIndex);
            }

            return delVal;
        }
    }

    public class MaxHeap : Heap
    {
        public int GetTop()
        {
            return top();
        }

        public int GetCount()
        {
            return count();
        }

        public bool Insert(int key)
        {
            return InsertLast(key);
        }

        public int ExtractTop()
        {
            return DeleteTop();
        }

        // Greater and Smaller are used as comparators
        bool Compare(int a, int b)
        {
            return a > b;
        }

        int Average(int a, int b)
        {
            return (a + b) / 2;
        }
    }

    public class MinHeap : Heap
    {
        public int GetTop()
        {
            return top();
        }

        public int GetCount()
        {
            return count();
        }

        public bool Insert(int key)
        {
            return InsertLast(key);
        }

        public int ExtractTop()
        {
            return DeleteTop();
        }

        bool Compare(int a, int b)
        {
            return a < b;
        }
    }

    public class HeapTest
    {
        public int Average(int a, int b)
        {
            return (a + b) / 2;
        }

        int Signum(int a, int b)
        {
            //  0  if a == b  - heaps are balanced
            // -1  if a <  b  - left contains less elements than right
            //  1  if a >  b  - left contains more elements than right

            if (a == b)
                return 0;

            return a < b ? -1 : 1;
        }

        void getMedian(int e, ref int median, MaxHeap maxHeap, MinHeap minHeap)
        {
            // Are heaps balanced? If yes, sig will be 0
            int sig = Signum(maxHeap.GetCount(), minHeap.GetCount());

            switch (sig)
            {
                case 1: // More elements in left (max) heap

                    if (e < median) // current element fits in left (max) heap
                    {
                        // Remore top element from left heap and insert into right heap
                        minHeap.Insert(maxHeap.ExtractTop());

                        // current element fits in left (max) heap
                        maxHeap.Insert(e);
                    }
                    else
                    {
                        // current element fits in right (min) heap
                        minHeap.Insert(e);
                    }

                    // Both heaps are balanced
                    median = Average(maxHeap.GetTop(), minHeap.GetTop());

                    break;

                case 0: // The left and right heaps contain same number of elements

                    if (e < median) // current element fits in left (max) heap
                    {
                        maxHeap.Insert(e);
                        median = maxHeap.GetTop();
                    }
                    else
                    {
                        // current element fits in right (min) heap
                        minHeap.Insert(e);
                        median = minHeap.GetTop();
                    }

                    break;

                case -1: // There are more elements in right (min) heap

                    if (e < median) // current element fits in left (max) heap
                    {
                        maxHeap.Insert(e);
                    }
                    else
                    {
                        // Remove top element from right heap and insert into left heap
                        maxHeap.Insert(minHeap.ExtractTop());

                        // current element fits in right (min) heap
                        minHeap.Insert(e);
                    }

                    // Both heaps are balanced
                    median = Average(maxHeap.GetTop(), minHeap.GetTop());

                    break;
            }
        }

        // Driver code
        int GetMedianForStreamOfDataTest()
        {
            // In lieu of A, we can also use data read from a stream
            int[] A = { 5, 15, 1, 3, 2, 8, 7, 9, 10, 6, 11, 4 };

            int median = 0; // effective median
            MaxHeap leftMaxHeap = new MaxHeap();
            MinHeap rightMinHeap = new MinHeap();

            for (int i = 0; i < A.Length; i++)
            {
                getMedian(A[i], ref median, leftMaxHeap, rightMinHeap);
                Console.Write(median + "  ");
            }
            return 0;
        }
    }

    //============================================================================================================================================================================

    // Given a stream of unsorted integers, find the median element in sorted order at any given time.
    // http://www.ardendertat.com/2011/11/03/programming-interview-questions-13-median-of-integer-stream/
    // https://gist.github.com/Vedrana/3675434
    public class MedianOfIntegerStream
    {

        public Queue<int> MinHeap;
        public Queue<int> MaxHeap;
        public int numOfElements;

        public MedianOfIntegerStream()
        {
            MinHeap = new Queue<int>();
            MaxHeap = new Queue<int>();// (10, new MaxHeapComparator()); // To sort the elements in the queue.

            numOfElements = 0;
        }

        public void AddNumberToMediansList(int num)
        {
            MaxHeap.Enqueue(num);
            MaxHeap = new Queue<int>(MaxHeap.OrderBy(item => item));

            if (numOfElements % 2 == 0)
            {
                if (MinHeap.Count == 0)
                {
                    numOfElements++;
                    return;
                }
                else if (MaxHeap.Peek() > MinHeap.Peek())
                {
                    int maxHeapRoot = MaxHeap.Dequeue();
                    int minHeapRoot = MinHeap.Dequeue();

                    MaxHeap.Enqueue(minHeapRoot);
                    MinHeap.Enqueue(maxHeapRoot);
                }
            }
            else
            {
                MinHeap.Enqueue(MaxHeap.Dequeue());
            }
            numOfElements++;
        }

        public int GetMedian()
        {
            if (MaxHeap == null)
                return -1;
            if (numOfElements % 2 != 0)
                return (MaxHeap.Peek());
            else
                return (MaxHeap.Peek() + MinHeap.Peek()) / 2;
        }

        public void GetMedianTest()
        {
            Console.Clear();
            MedianOfIntegerStream streamMedian = new MedianOfIntegerStream();

            streamMedian.AddNumberToMediansList(1);
            Console.WriteLine(streamMedian.GetMedian()); // should be 1

            streamMedian.AddNumberToMediansList(5);
            streamMedian.AddNumberToMediansList(10);
            streamMedian.AddNumberToMediansList(12);
            streamMedian.AddNumberToMediansList(2);
            Console.WriteLine(streamMedian.GetMedian()); // should be 5

            streamMedian.AddNumberToMediansList(3);
            streamMedian.AddNumberToMediansList(8);
            streamMedian.AddNumberToMediansList(9);
            Console.WriteLine(streamMedian.GetMedian()); // should be 6.5
        }
    }

    /*
    Calling Code:
        MaxHeap mh = new MaxHeap();
        mh.Add(10);
        mh.Add(5);
        mh.Add(2);
        mh.Add(1);
        mh.Add(50);
        int maxVal  = mh.Remove();
        int newMaxVal = mh.Remove();
    */
}
/*
		
 // Java Program to Implement Heap



 

import java.util.Scanner;

 

 Class Heap 

class Heap

{

 

    //private int[] heapArray;

    ////size of array 

    //private int maxSize; 

    //// number of nodes in array *

    //private int heapSize; 

 

    //Constructor *

    //public Heap(int mx) 

    //{

    //    maxSize = mx;

    //    heapSize = 0;

    //    heapArray = new int[maxSize]; 

    //}

    //// Check if heap is empty 

    //public boolean isEmpty() 

    //{

    //    return heapSize == 0;

    //}

    //// Function to insert element

    //public boolean insert(int ele) 

    //{

    //    if (heapSize + 1 == maxSize)

            return false;

        heapArray[++heapSize] = ele;

        int pos = heapSize;

        while (pos != 1 && ele > heapArray[pos/2])

        {

            heapArray[pos] = heapArray[pos/2];

            pos /=2;

        }

        heapArray[pos] = ele;    

        return true;

    } 

 

    /** function to remove element *

    public int remove()

    {

        int parent, child;

        int item, temp;

        if (isEmpty() )

            throw new RuntimeException("Error : Heap empty!");

 

        item = heapArray[1];

        temp = heapArray[heapSize--];

 

        parent = 1;

        child = 2;

        while (child <= heapSize)

        {

            if (child < heapSize && heapArray[child] < heapArray[child + 1])

                child++;

            if (temp >= heapArray[child])

                break;

 

            heapArray[parent] = heapArray[child];

            parent = child;

            child *= 2;

        }

        heapArray[parent] = temp;

 

        return item;

    }

 

    /** Function to print values *

    public void displayHeap()

    {

        /* Array format 

        System.out.print("\nHeap array: ");    

        for(int i = 1; i <= heapSize; i++)

            System.out.print(heapArray[i] +" ");

        Console.WriteLine("\n");

    }  

}

 

/** Class HeapTest *

public class HeapTest

{
            /*
   public static void main(String[] args)
   {
       Scanner scan = new Scanner(System.in);
       Console.WriteLine("Heap Test\n\n");
       Console.WriteLine("Enter size of heap");
       Heap h = new Heap(scan.nextInt() );

       char ch;

       //  Perform Heap operations 

       do    

       {

           Console.WriteLine("\nHeap Operations\n");

            Console.WriteLine("1. insert ");

            Console.WriteLine("2. delete item with max key ");

            Console.WriteLine("3. check empty");

 

            boolean chk;       

            int choice = scan.nextInt();            

            switch (choice)

            {

            case 1 : 

                Console.WriteLine("Enter integer element to insert");

                chk = h.insert( scan.nextInt() ); 

                if (chk)

                    Console.WriteLine("Insertion successful\n");

                else

                    Console.WriteLine("Insertion failed\n");                    

                break;                          

            case 2 : 

                Console.WriteLine("Enter integer element to delete");

                if (!h.isEmpty())

                    h.remove();

                else

                    Console.WriteLine("Error. Heap is empty\n");   

                break;

            case 3 : 

                Console.WriteLine("Empty status = "+ h.isEmpty());

                break;         

            default : 

                Console.WriteLine("Wrong Entry \n ");

                break;       

            }
            h.displayHeap();  

 

            Console.WriteLine("\nDo you want to continue (Type y or n) \n");

            ch = scan.next().charAt(0);                        

        } while (ch == 'Y'|| ch == 'y');  

    }
}
*/
