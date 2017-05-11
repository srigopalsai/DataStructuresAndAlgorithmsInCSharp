using System;

namespace DataStructuresAndAlgorithms
{
    public partial class QueueOperations
    {
        const int MAXSIZE = 10;
        int[] queueArray;// = new int[10];
        int frontIndex;
        int rearIndext;

        // Initialize stack pointer
        void InitializeQueue()
        {
            frontIndex = 0;
            rearIndext = 0;
            queueArray = new int[MAXSIZE];
        }

        bool IsQueueEmpty()
        {
            return frontIndex == 0;
        }

        bool IsQueueFull()
        {
            return rearIndext == MAXSIZE;
        }

        // Insert element to queue from back.
        void EnQueuequeueElement(int queueElement)
        {
            if (rearIndext > MAXSIZE)
            {
                Console.WriteLine("\nQUEUE is FULL\n");
                return;
            }
            else
            {
                queueArray[rearIndext] = queueElement;
                rearIndext++;
                Console.WriteLine("\nValue of rearIndext = {0} and the value of frontIndex is {1}", rearIndext, frontIndex);
            }
        }

        // Remove and get the element from queue from front.
        int DeQueuequeueElement()
        {
            int queueElement;

            if (frontIndex == rearIndext)
            {
                Console.WriteLine("\nQUEUE EMPTY\n");
                return (0);
            }
            else
            {
                queueElement = queueArray[frontIndex];
                frontIndex++;
            }
            return (queueElement);
        }

        //Return element without removing it from the queue.
        int Peek()
        {
            return queueArray[frontIndex];
        }

        object[] ToArray()
        {
            return null;
        }
        public void Demo()
        {
            int will = 1, queueElement;

            Console.WriteLine("\nQueue Operations with Arrays\n");

            // 1. Initialize queue pointers.
            InitializeQueue();

            while (will == 1)
            {
                Console.WriteLine("\n1. Add Element to queue. \n2. Delete Element from queue.\n  Any other key to exit\n");
                will = int.Parse(Console.ReadLine());

                switch (will)
                {
                    case 1:
                        {
                            Console.WriteLine("\nEnter the data... \n");
                            queueElement = int.Parse(Console.ReadLine());

                            EnQueuequeueElement(queueElement);
                            break;
                        }
                    case 2:
                        {
                            queueElement = DeQueuequeueElement();
                            Console.WriteLine("\nValue returned from queue is  %d\n", queueElement);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nInvalid Choice ... \n");
                            break;
                        }
                }
            }

            Console.WriteLine("\nPress any key to exit\n");
            Console.ReadLine();
        }
    }
}