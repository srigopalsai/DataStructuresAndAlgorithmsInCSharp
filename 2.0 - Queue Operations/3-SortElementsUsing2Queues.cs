using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*

    1. Store the 'Queue1' count and peek 'Queue1' element and store it in 'queue1InitialTempElement'.
    2. Repeat a loop till a flag 'IsSorted' becomes true.
    3. Once enterted in loop dequeue element from the 'Queue1' and store it in 'queue1DequedElement'.
    4. if 'queue1InitialTempElement' is grater than or equals to 'queue1DequedElement'.
        4.1. Then store 'queue1DequedElement' value in 'queue1InitialTempElement'.
        4.2. And enqueue 'queue1InitialTempElement' value in to 'Queue2'.
    5. Else store 'queue1DequedElement' back to 'Queue1'.
    6. Increment the 'lpCntProcessedElemnts' and check it if it is equals 'Queue1' length. 
        6.1. If they are not equal then continue the loop.        
    7. If the Queue2. Count is equals to 'Queue1' length.  
        7.1. If they are equal then make 'IsSorted' flag as true.
    8. Reset 'lpCntProcessedElemnts' to zero.
    9. Repeat loop till 'Queue2' Count is grater than zero and dequeue all elements from 'Queue2' and enqueue then to 'Queue1'.
    10. Peek 'Queue1' element and store it in 'queue1InitialTempElement'. 
    11. End the loop of 'IsSorted' flag. 
    */
    partial class QueueOperations
    {
        public void SortElementsUsing2Queues()
        {
            Queue<int> queue1 = new Queue<int>();
            Queue<int> queue2 = new Queue<int>();

            queue1.Enqueue(3);
            queue1.Enqueue(2);
            queue1.Enqueue(1);

            queue1.Enqueue(6);
            queue1.Enqueue(5);
            queue1.Enqueue(4);

            queue1.Enqueue(8);
            queue1.Enqueue(10);
            queue1.Enqueue(9);
            queue1.Enqueue(7);

            int queue1OriginalLength = queue1.Count;
            int queue1DequedElement = 0;
            int queue1InitialTempElement = queue1.Peek();
            int lpCntProcessedElemnts = 0;
            bool isQueueSorted = false;

            //while (isQueueSorted == false)
            while(queue1.Count > 0)
            {
                queue1DequedElement = queue1.Dequeue();

                // If the queue1Element is less than or equals to the item on the top of the sorted queue, then push it queue2 else push it back to the bottom of queue1. 
                if (queue1InitialTempElement >= queue1DequedElement)
                {
                    queue1InitialTempElement = queue1DequedElement;
                    queue2.Enqueue(queue1DequedElement);
                }
                else
                {
                    queue1.Enqueue(queue1DequedElement);
                }

                // Continue if we still have items to process. Note Queue1 lenght will be changed based on partial elements sorted.
                if (++lpCntProcessedElemnts != queue1OriginalLength)
                {
                    continue;
                }

                lpCntProcessedElemnts = 0;

                // If Queue2 length is equals to Queue1Lenght then queue is sorted.
                if (queue2.Count == queue1OriginalLength)
                {
                    isQueueSorted = true;
                    break;
                }

                // Queue2 will have partially sorted elements so push them back to queue1 to process them again. 
                while (queue2.Count > 0 )
                {
                    queue1.Enqueue(queue2.Dequeue());
                }

                // Reset back the topSortedElement.
                queue1InitialTempElement = queue1.Peek();
            }

            StringBuilder StringBuilderObj = new StringBuilder();
            StringBuilderObj.Append("Sorted Elements from the Queue:\n");
            while (queue2.Count > 0)
            {
                int queueElement = queue2.Dequeue();
                queue1.Enqueue(queueElement);
                StringBuilderObj.Append("\t" + queueElement);
            }

            //Queue2 will have sorted elements.
            MessageBox.Show(StringBuilderObj.ToString());
        }

    }
}
