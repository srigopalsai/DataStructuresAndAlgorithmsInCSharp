using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    Requires 2 Stacks.

    Time Complexity:
    EnQueue : O(1)
    DeQueue : O(n)
    */

    public class QueueSamples
    {
        private static Stack<int> inbox = new Stack<int>();
        private static Stack<int> outbox = new Stack<int>();

        public static void QueueOperationsWithStack()
        {
            EnQueue(1);
            EnQueue(2);
            EnQueue(3);
            EnQueue(4);

            StringBuilder StringBuilderObj = new StringBuilder();
            StringBuilderObj.Append("De Queue items from Stack:\n");

            StringBuilderObj.Append(DeQueue() + "\n");
            StringBuilderObj.Append(DeQueue() + "\n");
            StringBuilderObj.Append(DeQueue() + "\n");
            StringBuilderObj.Append(DeQueue() + "\n");

            MessageBox.Show(Convert.ToString(StringBuilderObj));
        }

        // Push elements into inbox stack.
        public static void EnQueue(int item)
        {
            inbox.Push(item);
        }

        // Pop elements from inbox and push them into outbox stack. So they will get stored in reverse.
        // Pop each element from outbox, so that we will get the first element which got inserted.
        public static int DeQueue()
        {
            if (outbox.Count == 0)
            {
                while (inbox.Count>0)
                {
                    outbox.Push(inbox.Pop());
                }
            }
            return outbox.Pop();
        }
    }
}