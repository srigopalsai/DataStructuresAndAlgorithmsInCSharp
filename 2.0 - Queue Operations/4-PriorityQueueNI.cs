using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{

    /*
     Priority queues typically use a heap as their backbone, giving O(log n) performance for inserts and removals, and O(n) to build initially. 
     */

    public interface IPriorityQueue<TItem, TPriority> : IEnumerable<TItem>
    {
        // Full Source Code https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp/wiki/Using-the-SimplePriorityQueue
        void Enqueue(TItem node, TPriority priority);
        TItem Dequeue();
        void Clear();
        bool Contains(TItem node);
        void Remove(TItem node);
        void UpdatePriority(TItem node, TPriority priority);
        TItem First { get; }
        int Count { get; }
    }
    /* http://www.bogotobogo.com/Algorithms/queue.php
       http://www.sanfoundry.com/java-program-priority-queue/
       Priority Queues: Often the items added to a queue have a priority  associated with them: this priority determines the order in which they exit the queue - 
       highest priority items are removed first. 
       To improve performance, priority queues typically use a heap as their backbone, giving O(log n) performance for inserts and removals, and O(n) to build initially. 
    
       Alternatively, when a self-balancing binary search tree is used, insertion and removal also take O(log n) time, although building trees from existing sequences of 
       elements takes O(n log n) time; this is typical where one might already have access to these data structures, such as with third-party or standard libraries.
        */
    partial class QueueOperations
    {
        public void PriorityQueue()
        { }
    }
}
