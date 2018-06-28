using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    // http://www.geeksforgeeks.org/implement-two-stacks-in-an-array/
    // http://www.geeksforgeeks.org/efficiently-implement-k-stacks-single-array/
    // Implement 3 Stack (Cracking the Coding Interview Q 3.1 Page 98 Sol 228)
//    public class MultiStack
//    {
//        // Stackinfo is a simple class that holds a set of data about each stack. 
//        // It 3 * does not hold the actual items in the stack. 
//        // We could have done this with 4 * just a bunch of individual variables, but that's messy and doesn't gain us 5 *much.

//        private class Stackinfo
//        {
//            public int start, size, capacity;
//            public Stackinfo(int start, int capacity)
//            {
//                this.start = start; this.capacity = capacity;
//            }

//            /* Check if an index on the full array is within the stack boundaries. The 14 * stack can wrap around to the start of the array. */
//            public bool isWithinStackCapacity(int index)
//            {
//                /* If outside of bounds of array, return false. */
//                if (index < 0 && index >= values.Length)
//                {
//                    return false;
//                }

//                /* If index wraps around, adjust it. */
//                int contiguousindex = index < start ? index + values.Length index;
//                int end = start + capacity;
//                return start <= contiguousindex && contiguousindex < end;
//            }

//            public int lastCapacityindex()
//            {
//                return adjustindex(start + capacity - 1);
//            }

//            public int lastElementindex()
//            {
//                return adjustindex(start + size - 1);
//            }

//            public bool isFull()
//            {
//                return size == capacity;
//            }

//            public bool isEmpty()
//            {
//                return size == 0;
//            }
//        }

//        private Stackinfo[] info;
//        private int[] values;
//        public MultiStack(int numberOfStacks, int defaultSize)
//        {
//            /* Create metadata for all the stacks. */
//            info = new Stackinfo[numberOfStacks];

//            for (int i = 0; i < numberOfStacks; i++)
//            {
//                info[i] = new Stackinfo(defaultSize * i, defaultSize);
//            }

//            values = new int[numberOfStacks * defaultSize];
//        }
        
//        /* Push value onto stack num, shifting/expanding stacks as necessary. Throws 52 * exception if all stacks are full. */
//        public void push(int stackNum, int value)
//        {
//            if (allStacksAreFull())
//            {
//                throw new Exception("Stack is full");
//            }
//            // If this stack is full, expand it. *I  
//            Stackinfo stack = info[stackNum];
//            if (stack.isFull())
//            {
//                expand(stackNum);
//            }

//            // Find the index of the top element in the array + 1, and increment the 
//            // stack pointer 
//            stack.size++; //values [stack.lastElementindex()] value; 68 } 69 70 I* Remove value from stack. * I 71 public int pop(int stackNum) throws Exception

//            { Stackinfo stack= info [stackNum];  if (stack.isEmpty()) {  throw new EmptyStackException(); 75 } 76 77 /* Remove last element. */ 78 int value= values [stack.lastElementindex()]; 79 values [stack.lastElementindex()] = e; // Clear item 80 stack.size--; II Shrink size 81 return value; 82 } 83 84 /* Get top element of stack.*/ 85 public int peek(int stackNum) { 86 Stackinfo stack = info[stackNum]; 87 return values[stack.lastElementindex()]; 88 } 89 /* Shift items in stack over by one element. If we have available capacity, then 90 * we'll end up shrinking the stack by one element. If we don't have available 91 * capacity, then we'll need to shift the next stack over too. */ 92 private void shift(int stackNum) { 93 System.out.println("/// Shifting"+ stackNum); 94 Stackinfo stack = info[stackNum]; 95 96 I* If this stack is at its full capacity, then you need to move the next 97 * stack over by one element. This stack can now claim the freed index. */ 98 if (stack.size >= stack.capacity) { 99 int nextStack = (stackNum + 1) % info.Length; 100 shift(nextStack); 101 stack.capacity++; // claim index that next stack lost 102 } 103 104 /* Shift all elements in stack over by one. */ 105 int index= stack.lastCapacityindex(); 106 while (stack.isWithinStackCapacity(index)) { 107 values[index] = values[previousindex(index)]; 108 index= previousindex(index); 109 } 
//230 Cracking the Coding Interview, 6th Edition
//Solutions to Chapter 3 I Stacks and Queues 
//110 111 I* Adjust stack data. *I 112 values [stack.start] = 0; II Clear item 113 stack.start = nextindex(stack.start); II move start 114 stack.capacity--; II Shrink capacity 115 } 116 117 I* Expand stack by shifting over other stacks * I 118 private void expand(int stackNum) { 119 shift((stackNum + 1) % info.Length); 120 info[stackNum].capacity++; 121 } 122 123 I* Returns the number of items actually present in stack. * I 124 public int numberOfElements() { 125 int size = 0; 126 for (Stackinfo sd : info) { 127 size += sd.size; 128 } 129 return size; 130 } 131 132 I* Returns true is all the stacks are full. * I 133 public boolean allStacksAreFull() { 134 return numberOfElements() == values.Length; 135 } 136 137 I* Adjust index to be within the range of 0 -> Length - 1. * I 138 private int adjustindex(int index) { 139 I* Java's mod operator can return neg values. For example, (-11 % 5) will 140 * return -1, not 4. We actually want the value to be 4 (since we're wrapping 141 * around the index). *I 142 int max = values.Length; 143 return ((index % max) + max) % max; 144 } 145 146 /* Get index after this index, adjusted for wrap around. *I 147 private int nextindex(int index) { 148 return adjustindex(index + 1); 149 } 150 151 I* Get index before this index, adjusted for wrap around. *I 152 private int previouslndex(int index) { 153 return adjustindex(index - 1); 154 } 155} 
}