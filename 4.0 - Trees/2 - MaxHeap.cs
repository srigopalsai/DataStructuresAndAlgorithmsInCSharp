using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Trees
{
    //http://stackoverflow.com/a/41974651/2466650
    public class MaxHeap2
    {
        static int capacity = 100;

        int CurrentIndex { get; set; }

        int[] items = new int[capacity];

        public MaxHeap2()
        {
            //items[0] = int.MaxValue;
        }

        private int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int getLeftChild(int parentIndex)
        {
            return this.items[getLeftChildIndex(parentIndex)];
        }

        private int getRightChild(int parentIndex)
        {
            return this.items[getRightChildIndex(parentIndex)];
        }

        private int getParent(int childIndex)
        {
            return this.items[getParentIndex(childIndex)];
        }

        private bool hasLeftChild(int parentIndex)
        {
            return getLeftChildIndex(parentIndex) < CurrentIndex;
        }

        private bool hasRightChild(int parentIndex)
        {
            return getRightChildIndex(parentIndex) < CurrentIndex;
        }

        private bool hasParent(int childIndex)
        {
            return getLeftChildIndex(childIndex) > 0;
        }

        private void Swap(int indexOne, int indexTwo)
        {
            int temp = this.items[indexOne];
            this.items[indexOne] = this.items[indexTwo];
            this.items[indexTwo] = temp;
        }

        private void hasEnoughCapacity()
        {
            if (this.CurrentIndex == capacity)
            {
                Array.Resize(ref this.items, capacity * 2);
                capacity *= 2;
            }
        }

        private void heapifyUp()
        {
            int index = this.CurrentIndex - 1;

            while (hasParent(index) && this.items[index] > getParent(index))
            {
                Swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }

        private void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                int bigChildIndex = getLeftChildIndex(index);

                if (hasRightChild(index) && getLeftChild(index) < getRightChild(index))
                {
                    bigChildIndex = getRightChildIndex(index);
                }

                if (this.items[bigChildIndex] < this.items[index])
                {
                    break;
                }
                else
                {
                    Swap(bigChildIndex, index);
                    index = bigChildIndex;
                }
            }
        }

        public void Add(int item)
        {
            this.hasEnoughCapacity();

            this.items[this.CurrentIndex] = item;
            this.CurrentIndex++;

            heapifyUp();
        }

        public int Remove()
        {
            int item = this.items[0];
            this.items[0] = this.items[this.CurrentIndex - 1];
            this.items[this.CurrentIndex - 1] = 0;
            this.CurrentIndex--;

            heapifyDown();
            return item;
        }

        public void Display()
        {
            for (int i = 1; i <= CurrentIndex; i++)
            {
                Console.Write(items[i] + "\t");
            }
            Console.WriteLine();

            for (int i = 1; i <= CurrentIndex / 2; i++)
            {
                Console.Write(" PARENT : " + items[i] + " LEFT CHILD : " + items[2 * i]
                      + " RIGHT CHILD :" + items[2 * i + 1]);
                Console.WriteLine();
            }
        }
    }
}
