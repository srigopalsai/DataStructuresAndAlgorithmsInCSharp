using System;
using System.Text;
using System.Windows;
namespace DataStructuresAndAlgorithms
{
    public partial class StackOperations
    {
        int[] stackArray;
        int stackIndex = 0;

        //	Initialize stack pointer
        public void InitializeStack(int sizeOftheStack)
        {
            stackIndex = 0;
            stackArray = new int[sizeOftheStack];
        }

        //	Push an element into stack. Pre Condition: The stack is not full
        public void PushElementToStack( int element)
        {
            if (stackIndex == stackArray.Length)
            {
                throw new Exception("Stack is full");
            }
            stackArray[stackIndex] = element;
            stackIndex++;
        }

        //  Pop an element from stack. Pre Condition: stack is not empty
        public int PopElementFromStack()
        {
            if (stackIndex < 0)
            {
                throw new Exception("Stack is empty");
            }
            return stackArray[--stackIndex];
        }

        //	check if stack is full nor not. Return 1 if stack is full, otherwise return 0
        public bool IsStackFull()
        {
            return stackIndex == stackArray.Length  ? true : false;
        }

        //	Check if stack is empty or not. Return 1 if the stack is empty, otherwise return 0
        public bool IsStackEmpty()
        {
            return stackIndex == 0 ? true : false;
        }

        public void StackOperationsDemo()
        {
            StringBuilder outputString = new StringBuilder();

            outputString.Append("Stack Operations with Arrays.");
            StackOperations StackDemoObject = new StackOperations();

            // 1. Initialize stack pointer.
            StackDemoObject.InitializeStack(3);

            // 2. Push elements into stack.
            StackDemoObject.PushElementToStack(1);
            StackDemoObject.PushElementToStack(2);
            StackDemoObject.PushElementToStack(3);

            outputString.Append(Environment.NewLine + Environment.NewLine + "Data inserted into stack.");

            if (StackDemoObject.IsStackFull())
            {
                outputString.Append(Environment.NewLine + Environment.NewLine + "Stack is full." + Environment.NewLine);
            }

            // 3. Pop elements from stack.
            while (!StackDemoObject.IsStackEmpty())
            {
                int element = StackDemoObject.PopElementFromStack();
                outputString.Append(Environment.NewLine + element + " Poped element from stack.");
            }

            // 4. Check If stack is empty.
            if (StackDemoObject.IsStackEmpty() == true)
            {
                outputString.Append(Environment.NewLine + Environment.NewLine + "Stack is empty.");
            }

            MessageBox.Show(Convert.ToString(outputString));
        }
    }
}
