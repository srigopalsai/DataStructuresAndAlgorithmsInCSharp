using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    
    1. Create 2 stacks named RegularStack and MinStack.
    2. RegularStack: Implement normal push(), pop() and top() functions. 
    3. MinStack: Maintain the minimum element in RegularStack as its top.

    Perform this Operation.
    
    1) Push: 
        While pushing an element into RegularStack, Compare this element with the top element in MinStack. 
        If it is smaller, then push that element into MinStack at the same time. 
        Else do nothing.
    
    2) Pop:
        While popping an element out from RegularStack, Compare this element with the top element in MinStack. 
        If they are equal, we pop out the top element from MinStack at the same time. Otherwise, we do nothing.
    
    3. Get:
        Peek element from MinStack and Return.

    */
    public partial class StackOperations
    {
        Stack<int> RegularStack = new Stack<int>();
        Stack<int> MinStack = new Stack<int>();
        StringBuilder StringBuilderObj = new StringBuilder(); 

        public void PushPopGetMinWithConstantTime()
        {
            Push(3);
            Push(4);
            Push(5);
            Push(1);
            Push(2);
            StringBuilderObj.Append("\nElements Pushed into Stack:\n 3,   4,  5,  1,  2");
            
            int minElement = GetMinElement();
            StringBuilderObj.Append("\n\nMin Element in Stack:\t" + Convert.ToString(minElement));
        
            int poppedElement = Pop();
            poppedElement = Pop();
            StringBuilderObj.Append("\n\nElements 1,  2 popped out from Stack.\t");

            StringBuilderObj.Append("\n\nRemaining Elements in Stack:\n 3,   4,  5");

            minElement = GetMinElement();
            StringBuilderObj.Append("\n\nMin Element in Stack:\t" + Convert.ToString(minElement));

            MessageBox.Show(Convert.ToString(StringBuilderObj));
        }

        public void Push(int elementToPush)
        {
            //Push element to RegularStack
            RegularStack.Push(elementToPush);

            //If the elementToPush is less than the currentMinElement in MinStack then insert elementToPush to MinStack
            //Else do nothing.
            int? currentMinElement = null;

            if (MinStack.Count > 0)
            {
                currentMinElement = MinStack.Peek();
            }

            if (currentMinElement == null || elementToPush < currentMinElement)
            {
                MinStack.Push(elementToPush);
            }
        }

        public int Pop()
        {
            if (RegularStack.Count == 0)
            {
                throw new Exception("No elements in stack to pop");
            }

            //Pop element from RegularStack.
            int elementPopped = RegularStack.Pop();

            //Get element from MinStack and check if it is same as elementPopped, then pop out it from the MinStack as well.
            int currentMinElement = MinStack.Peek();
            if (elementPopped == currentMinElement)
            {
                MinStack.Pop();
            }

            return elementPopped;

        }
        
        public int GetMinElement()
        {
            if (MinStack.Count == 0)
            {
                throw new Exception("No elements in stack to pop");
            }

            //Get element from MinStack and return.
            int currentMinElement = MinStack.Peek();
            return currentMinElement;
        }
    }
}
