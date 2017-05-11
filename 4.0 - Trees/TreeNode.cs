using System.Diagnostics;
using System;

namespace DataStructuresAndAlgorithms
{
    public class TreeNode
    {
        public int NodeValue { get; set; }

        public bool IsThreadedNode { get; set; }

        public TreeNode RightNode { get; set; }

        public TreeNode LeftNode { get; set; }

        public TreeNode()
        {
        }

        public TreeNode(int nodeValue)
        {
            this.NodeValue = nodeValue;
            string logMessage = "Node created successfully " + NodeValue + (RightNode == null ? string.Empty : " Next Node is " + RightNode);
            logMessage += (LeftNode == null ? string.Empty : " Previous Node is " + LeftNode);
            Debug.WriteLine(logMessage);
        }

        ~TreeNode()
        {
            string logMessage = "Node disposed successfully " + NodeValue + (RightNode == null ? string.Empty : " Next Node is " + RightNode);
            logMessage += (LeftNode == null ? string.Empty : " Previous Node is " + LeftNode);
            Debug.WriteLine(logMessage);
        } 
    }
}