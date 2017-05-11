using System.Diagnostics;
using System;

namespace DataStructuresAndAlgorithms
{
    public class ListNode
    {
        public int NodeValue { get; set; }

        public ListNode NextNode { get; set; }

        public ListNode PreviousNode { get; set; }

        public ListNode()
        {
        }

        public ListNode(int nodeValue)
        {
            this.NodeValue = nodeValue;
            string logMessage = "Node created successfully " + NodeValue + (NextNode == null ? string.Empty : " Next Node is " + NextNode);
            logMessage += (PreviousNode == null ? string.Empty : " Previous Node is " + PreviousNode);
            Debug.WriteLine(logMessage);
        }
    }
}