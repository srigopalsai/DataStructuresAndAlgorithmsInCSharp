using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    
    ============================================================================================================================================================================================================================

    Given a Stack    S  -    1   2   3   4   5
    Output           S  -    5   4   3   2   1

    Can use another empty stack and a variable, but should return reversed elements with Stack S only.
    
    1. Pop top one element from SourceStack and store it in tempVar.
    2. Push all remaining element to TempStack 
    3. Push tempVar to SourceStack 
    4. Push all elements back from TempStack to SourceStack.

       This will get first element of s in correct reverse position. 
       Continue for all other elements by keeping a count of how many elements are reversed

    5. Execlude the one reversed item in each iteration.
    ============================================================================================================================================================================================================================

    */
    partial class StackOperations
    {
        static StringBuilder StringBuilderStObj;
        public static void ReturnSameStackInReverseOrder()
        {
            Stack<int> sourceStack = new Stack<int>();
            StringBuilderStObj = new StringBuilder();

            sourceStack.Push(1);
            sourceStack.Push(2);
            sourceStack.Push(3);
            sourceStack.Push(4);
            sourceStack.Push(5);

            StringBuilderStObj.Append("Input Stack : ");

            while (sourceStack.Count > 0)
            {
                StringBuilderStObj.Append(sourceStack.Pop() + "  ");
            }

            sourceStack.Push(1);
            sourceStack.Push(2);
            sourceStack.Push(3);
            sourceStack.Push(4);
            sourceStack.Push(5);

            ReverseStack(sourceStack);

            StringBuilderStObj.Append("\nOutput Stack : ");
    
            while (sourceStack.Count > 0)
            {
                StringBuilderStObj.Append(sourceStack.Pop() + "  ");
            }

            MessageBox.Show(Convert.ToString(StringBuilderStObj));
        }

        public static Stack<int> ReverseStack(Stack<int> sourceStack)
        {
            int ReversedItems = sourceStack.Count;

            Stack<int> targetStack = new Stack<int>();

            //1. On every iteration one item will be revesed.
            while (ReversedItems-- > 0)
            {
                //2. Pull out the first item from Stack.
                int sourceTopItem = sourceStack.Pop();

                int remainingItems = 0;

                //3. Push remaining items to Target Stack. Note : excluding the reversed item(s) on each iteration
                while (remainingItems++ < ReversedItems)
                {
                    targetStack.Push(sourceStack.Pop());
                }

                //4. Now push the first item. So x item(s) reversed.
                sourceStack.Push(sourceTopItem);

                //5. Push back to list to soruce.
                while (targetStack.Count() > 0)
                {
                    sourceStack.Push(targetStack.Pop());
                }
            }
            return sourceStack;
        } 
    }
}