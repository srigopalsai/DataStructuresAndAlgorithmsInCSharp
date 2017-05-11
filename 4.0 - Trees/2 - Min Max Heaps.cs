using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Trees.HeapOperations
{
    /*
    Reference Links:
    http://www.sanfoundry.com/java-program-implement-max-heap/
    http://www.sanfoundry.com/java-program-implement-min-heap/
    */

    public abstract class Heap
    {
        protected int[] HeapArray;

        protected int CurrentIndex { get; set; }

        protected int Maxsize { get; set; }

        protected int FrontIndex
        {
            get
            {
                return 1;
            }
        }

        protected Heap(int maxsize)
        {
            this.Maxsize = maxsize;
            this.CurrentIndex = 0;
            HeapArray = new int[this.Maxsize + 1];           
        }

        protected int GetParentIndex(int index)
        {
            return index / 2;
        }

        protected int GetLeftChildIndex(int index)
        {
            return (2 * index);
        }

        protected int GetRightChildIndex(int index)
        {
            return (2 * index) + 1;
        }

        protected bool IsLeafIndex(int index)
        {
            if (index >= (CurrentIndex / 2) && index <= CurrentIndex)
            {
                return true;
            }
            return false;
        }

        protected void Swap(int leftIndex, int rightIndex)
        {
            int tmp = HeapArray[leftIndex];
            HeapArray[leftIndex] = HeapArray[rightIndex];
            HeapArray[rightIndex] = tmp;
        }
           
        public abstract bool CanSwap(int currVal, int parentVal);

        public abstract bool ChildComparer(int leftChild, int rightChild);

        public abstract bool ParentChildComparer(int parent, int leftChild, int rightChild);

        public void Display()
        {
            for (int i = 1; i < CurrentIndex; i++)
            {
                Console.Write(HeapArray[i] + "\t");
            }
            Console.WriteLine();

            for (int i = 1; i <= CurrentIndex / 2; i++)
            {
                Console.Write(" PARENT : " + HeapArray[i] + " LEFT CHILD : " + HeapArray[2 * i]
                      + " RIGHT CHILD :" + HeapArray[2 * i + 1]);
                Console.WriteLine();
            }
        }

        public void Add(int element)
        {
            HeapArray[++CurrentIndex] = element;
            int currIndex = CurrentIndex;

            // Start from last index and keep comparing current item with its parent.
            // While it satisfies the condition keep swapping it with its parent and consider parent index as currIndex.
            while (CanSwap(HeapArray[currIndex], HeapArray[GetParentIndex(currIndex)]) == true)
            {
                Swap(currIndex, GetParentIndex(currIndex));
                currIndex = GetParentIndex(currIndex);
            }
        }

        public void BuildHeap()
        {
            for (int index = (CurrentIndex / 2); index >= 1; index--)
            {
                Heapify(index);
            }
        }

        protected void Heapify(int currIndex)
        {
            if (!IsLeafIndex(currIndex))
            {
                bool compareResult = ParentChildComparer(HeapArray[currIndex], HeapArray[GetLeftChildIndex(currIndex)], HeapArray[GetRightChildIndex(currIndex)]);

                if (compareResult == true)
                {
                    if (ChildComparer(HeapArray[GetLeftChildIndex(currIndex)], HeapArray[GetRightChildIndex(currIndex)]) == true)
                    {
                        Swap(currIndex, GetLeftChildIndex(currIndex));
                        Heapify(GetLeftChildIndex(currIndex));
                    }
                    else
                    {
                        Swap(currIndex, GetRightChildIndex(currIndex));
                        Heapify(GetRightChildIndex(currIndex));
                    }
                }
            }
        }
      
        public int Remove()
        {
            int popped = HeapArray[FrontIndex];
            HeapArray[FrontIndex] = HeapArray[CurrentIndex--];
            Heapify(FrontIndex);
            return popped;
        }
    }

    public class MaxHeap : Heap
    {
        public MaxHeap(int maxsize): base(maxsize)
        {
            HeapArray[0] = int.MaxValue;
        }

        public override bool ParentChildComparer(int parent, int leftChild, int rightChild)
        {
            return (parent < leftChild || parent < rightChild) ? true : false;
        }

        public override bool ChildComparer(int leftChild, int rightChild)
        {
            return (leftChild > rightChild) ? true : false;
        }

        public override bool CanSwap(int currVal, int parentVal)
        {
            return (currVal > parentVal) ? true : false;
        }
    }

    public class MinHeap : Heap
    {
        public MinHeap(int maxsize): base(maxsize)
        {
            HeapArray[0] = int.MinValue;
        }
      
        public override bool ParentChildComparer(int parent, int leftChild, int rightChild)
        {
            return (parent > leftChild || parent > rightChild) ? true : false;
        }

        public override bool ChildComparer(int leftChild, int rightChild)
        {
            return (leftChild < rightChild) ? true : false;
        }

        public override bool CanSwap(int currVal, int parentVal)
        {
            return (currVal < parentVal) ? true : false;
        }
    }

    public class HeapDemo
    {
        public void HeapTest()
        {
            Console.Clear();
            Console.WriteLine("The Max Heap 2 is ");
            MaxHeap2 maxHeap2 = new MaxHeap2();

            maxHeap2.Add(1);
            maxHeap2.Add(2);
            maxHeap2.Add(3);
            maxHeap2.Add(4);
            maxHeap2.Add(5);
            maxHeap2.Add(6);
            maxHeap2.Add(7);
            maxHeap2.Add(8);
            maxHeap2.Add(9);


            maxHeap2.Display();

            Console.WriteLine("The max val is " + maxHeap2.Remove());

            //==========================================================================================================

            Console.WriteLine("The Max Heap 1 is ");
            MaxHeap maxHeap = new MaxHeap(15);

            maxHeap.Add(1);
            maxHeap.Add(2);
            maxHeap.Add(3);
            maxHeap.Add(4);
            maxHeap.Add(5);
            maxHeap.Add(6);
            maxHeap.Add(7);
            maxHeap.Add(8);
            maxHeap.Add(9);

            maxHeap.BuildHeap();
            maxHeap.Display();

            Console.WriteLine("The max val is " + maxHeap.Remove());

            //==========================================================================================================

            Console.WriteLine("\nThe Min Heap is ");
            MinHeap minHeap = new MinHeap(15);

            minHeap.Add(9);
            minHeap.Add(8);
            minHeap.Add(7);
            minHeap.Add(6);
            minHeap.Add(5);
            minHeap.Add(4);
            minHeap.Add(3);
            minHeap.Add(2);
            minHeap.Add(1);

            minHeap.BuildHeap();
            minHeap.Display();

            Console.WriteLine("The Min val is " + minHeap.Remove());
        }
    }
}