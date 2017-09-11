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

    /*
    public class MedianFinder
{
    private MinHeap minHeap;
    private MaxHeap maxHeap;
    private double median;

    // initialize your data structure here. 
    public MedianFinder()
    {
        minHeap = new MinHeap();
        maxHeap = new MaxHeap();
        median = -1;
    }

    private HeapStatus GetHeapStatus()
    {
        if (minHeap.Size == maxHeap.Size)
            return HeapStatus.Balanced;
        else if (maxHeap.Size > minHeap.Size)
            return HeapStatus.LeftHeavy;
        else
            return HeapStatus.RightHeavy;
    }

    public void AddNum(int num)
    {
        HeapStatus status = GetHeapStatus();

        switch (status)
        {
            case HeapStatus.LeftHeavy:
                {
                    if (median > num)
                    {
                        int top = maxHeap.ExtractTop();
                        minHeap.Insert(top);
                        maxHeap.Insert(num);
                    }
                    else
                    {
                        minHeap.Insert(num);
                    }

                    median = ((double)(minHeap.GetTop() + maxHeap.GetTop())) / 2;

                    break;
                }

            case HeapStatus.RightHeavy:
                {
                    if (median < num)
                    {
                        int top = minHeap.ExtractTop();
                        maxHeap.Insert(top);
                        minHeap.Insert(num);
                    }
                    else
                    {
                        maxHeap.Insert(num);
                    }

                    median = ((double)(minHeap.GetTop() + maxHeap.GetTop())) / 2;

                    break;
                }

            case HeapStatus.Balanced:
                {
                    if (median < num)
                    {
                        minHeap.Insert(num);
                        median = minHeap.GetTop();
                    }
                    else
                    {
                        maxHeap.Insert(num);
                        median = maxHeap.GetTop();
                    }

                    break;
                }
        }
    }

    public double FindMedian()
    {
        return median;
    }
}

public class MaxHeap : Heap
{
    private List<int> elements;

    public MaxHeap()
    {
        elements = new List<int>();
    }

    public int Size
    {
        get
        {
            return elements.Count;
        }
    }

    public void Insert(int num)
    {
        elements.Add(num);

        int i = elements.Count - 1;

        int parent = GetParent(elements.Count - 1);

        while (parent >= 0 && elements[parent] < elements[i])
        {
            Swap(elements, parent, i);
            i = parent;
            parent = GetParent(i);
        }
    }

    public int GetTop()
    {
        return Size > 0 ? elements[0] : -1;
    }

    public int ExtractTop()
    {
        int top = -1;

        if (Size > 0)
        {
            top = elements[0];

            Swap(elements, 0, elements.Count - 1);

            elements.RemoveAt(elements.Count - 1);

            MaxHeapify(0);
        }

        return top;
    }

    public void MaxHeapify(int i)
    {
        int left = GetLeft(i);
        int right = GetRight(i);

        int largest = i;

        if (left < Size && elements[left] > elements[i])
        {
            largest = left;
        }

        if (right < Size && elements[right] > elements[largest])
        {
            largest = right;
        }

        if (largest != i)
        {
            Swap(elements, largest, i);
            MaxHeapify(largest);
        }
    }
}

public enum HeapStatus
{
    LeftHeavy,
    RightHeavy,
    Balanced
}

public class MinHeap : Heap
{
    private List<int> elements;

    public MinHeap()
    {
        elements = new List<int>();
    }

    public int Size
    {
        get
        {
            return elements.Count;
        }
    }

    public void Insert(int num)
    {
        elements.Add(num);

        int i = elements.Count - 1;

        int parent = GetParent(elements.Count - 1);

        while (parent >= 0 && elements[parent] > elements[i])
        {
            Swap(elements, parent, i);
            i = parent;
            parent = GetParent(i);
        }
    }

    public int GetTop()
    {
        return Size > 0 ? elements[0] : -1;
    }

    public int ExtractTop()
    {
        int top = -1;

        if (Size > 0)
        {
            top = elements[0];

            Swap(elements, 0, elements.Count - 1);

            elements.RemoveAt(elements.Count - 1);

            MinHeapify(0);
        }

        return top;
    }

    public void MinHeapify(int i)
    {
        int left = GetLeft(i);
        int right = GetRight(i);

        int smallest = i;

        if (left < Size && elements[left] < elements[i])
        {
            smallest = left;
        }

        if (right < Size && elements[right] < elements[smallest])
        {
            smallest = right;
        }

        if (smallest != i)
        {
            Swap(elements, smallest, i);
            MinHeapify(smallest);
        }
    }
}

public class Heap
{
    public int GetParent(int i)
    {
        return (i - 1) / 2;
    }

    public int GetLeft(int i)
    {
        return (2 * i) + 1;
    }

    public int GetRight(int i)
    {
        return (2 * i) + 2;
    }

    public void Swap(List<int> elements, int i, int j)
    {
        int temp = elements[i];
        elements[i] = elements[j];
        elements[j] = temp;
    }
} */
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