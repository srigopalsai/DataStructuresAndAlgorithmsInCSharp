using System.Text;
using System;
using System.Collections;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/XOR_linked_list
    */
    public class DoublyLinkedListDemo
    {
        public ListNode HeadNode;
        public ListNode TailNode;

        public bool IsListEmpty()
        {
            return HeadNode == null;
        }

        public void CreateNode(int nodeIntValue)
        {
            HeadNode = CreateNode(HeadNode, nodeIntValue);            
        }

        private ListNode CreateNode(ListNode NodeToCreate, int nodeIntValue)
        {
            if (NodeToCreate == null)
            {
                // Header node creation
                NodeToCreate = new ListNode();
                NodeToCreate.NodeValue = nodeIntValue;
                //PreviousNode will be null if list is not Circular.
                NodeToCreate.PreviousNode = null;
            }
            else if (NodeToCreate.NextNode == null)
            {
                //For Other than header Node.
                ListNode TempNode = new ListNode();
                TempNode.NodeValue = nodeIntValue;
                TempNode.PreviousNode = NodeToCreate;
                NodeToCreate.NextNode = TempNode;

                // Assign last node to Tail node always
                TailNode = TempNode;
            }
            else
            {
                CreateNode(NodeToCreate.NextNode, nodeIntValue); 
            }
            return NodeToCreate;
        }

        public bool InsertAfter(int valueToInsert, int afterValue)
        {
            return InsertAfter(HeadNode, valueToInsert, afterValue);
        }

        private bool InsertAfter(ListNode traversalNode, int valueToInsert, int afterNodeValue)
        {
            if (traversalNode == null)
            {
                throw new Exception("Invalid node");
            }
            else if (traversalNode.NodeValue == afterNodeValue)
            {
                return false;
            }
            else
            {
                return InsertAfter(traversalNode.NextNode, valueToInsert, afterNodeValue); 
            }
        }

        public string FrontTraversal(ListNode traversalNode)
        { 
            StringBuilder resultString = new StringBuilder();
            while (traversalNode != null)
            {
                resultString.Append("  " + traversalNode.NodeValue);
                traversalNode = traversalNode.NextNode;
            }
            return resultString.ToString();
        }
        
        public string RearTraversal(ListNode traversalNode)
        {
            StringBuilder resultString = new StringBuilder();
            while (traversalNode != null)
            {
                resultString.Append("  " + traversalNode.NodeValue);
                traversalNode = traversalNode.PreviousNode;
            }
            return resultString.ToString();
        }
        
        public ListNode Search(ListNode traversalNode, int valueToFind)
        {
            while (traversalNode != null)
            {
                if (traversalNode.NodeValue == valueToFind) 
                {
                    return traversalNode;
                }
                traversalNode = traversalNode.NextNode;
            }
            return null;
        }
        
        public bool RemoveNode(int nodeValueToRemove)
        {
            bool result = RemoveNode(HeadNode, nodeValueToRemove);
            return result;
        }

        private bool RemoveNode(ListNode traversalNode, int nodeValueToRemove)
        {
            if (traversalNode == null)
            {
                throw new Exception("Node not found");                 
            }
            else if (traversalNode.NodeValue == nodeValueToRemove)
            {
                //For Tail node
                if (traversalNode.NextNode == null)
                {
                     traversalNode.PreviousNode.NextNode = null;
                    return true;
                }
                //For Head node
                else if ( traversalNode.PreviousNode == null)
                {
                    traversalNode.NextNode.PreviousNode = null;
                    HeadNode = traversalNode.NextNode;
                    traversalNode = null;
                    return true;
                }
                else
                {
                    traversalNode.NextNode.PreviousNode = traversalNode.PreviousNode;
                    traversalNode.PreviousNode.NextNode = traversalNode.NextNode;
                    traversalNode = null;
                    return true;
                }
            }
            else
            {
                return RemoveNode(traversalNode.NextNode, nodeValueToRemove);
            }          
        }

        //Need to implement
        int Find2ndLargetElement()
        {
            return -1;
        }

        //ListAsCollection

    }
}