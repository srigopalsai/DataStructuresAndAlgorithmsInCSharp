using System;

namespace DataStructuresAndAlgorithms
{
    /*
     Circular queue is a linear data structure. It follows FIFO principle. 

         •In circular queue the last node is connected back to the first node to make a circle. 
         •Circular linked list fallow the First In First Out principle
         •Elements are added at the rear end and the elements are deleted at front end of the queue
         •Both the front and the rear pointers points to the beginning of the array.
         •It is also called as “Ring buffer".
         •Items can inserted and deleted from a queue in O(1) time. 
    
     Circular Queue can be created in 3 ways they are 

     1· Using single linked list
     2· Using double linked list
     3· Using arrays
     */

    public class CircularLinkedListDemo
    {
        public ListNode HeadNode;

        public bool IsListEmpty()
        {
            return HeadNode == null;
        }

        public void CreateNode(int listNodeValue)
        {
            HeadNode = CreateNode(HeadNode, listNodeValue);
        }

        private ListNode CreateNode(ListNode currentNode, int listNodeValue)
        {
            if (currentNode == null)
            {
                currentNode = new ListNode(listNodeValue);
                currentNode.NextNode = currentNode;
            }
            else if (currentNode.NextNode == HeadNode)
            {

                //Store head node always to the new node
                ListNode tempNode = new ListNode(listNodeValue);
                tempNode.NextNode = HeadNode;
                currentNode.NextNode = tempNode;
            }
            else
            {
                // Recursive call to the current function.
                currentNode.NextNode = CreateNode(currentNode.NextNode, listNodeValue);
            }
            return currentNode;
        }

        public string DisplayNodes(ListNode startNode)
        {
            string Data = string.Empty;
            while (startNode.NextNode != HeadNode)
            {
                Data += "   " + startNode.NodeValue;
                startNode = startNode.NextNode;
            }

            //Need to consider last node as while condition used it to break.
            Data += "   " + startNode.NodeValue;
            return Data;
        }

        public ListNode Search(ListNode currentNode, int nodeValue)
        {
            while (currentNode.NextNode != HeadNode)
            {
                if (currentNode.NodeValue == nodeValue)
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }

            //Need to consider last node as while condition used it to break.
            if (currentNode.NodeValue == nodeValue)
            {
                return currentNode;
            }
            return null;
        }

        public bool InsertAtBegin(int nodeValueToInsert)
        {
            // Insert after first element.
            return InsertAfter(nodeValueToInsert, HeadNode.NodeValue);
        }

        public bool InsertAfter(int nodeValueToInsert, int afterNodeValue)
        {
            ListNode nodeToAttach = Search(HeadNode, afterNodeValue);
            if (nodeToAttach != null)
            {
                ListNode tempNode = new ListNode();
                tempNode.NextNode = nodeToAttach.NextNode;
                tempNode.NodeValue = nodeValueToInsert;

                nodeToAttach.NextNode = tempNode;

                return true;
            }
            return false;
        }

        public bool Remove(int nodeValue)
        {
            ListNode resultNode = Remove(HeadNode, nodeValue);

            if (resultNode != null)
            {
                HeadNode = resultNode;
                return true;
            }
            return false;
        }

        private ListNode Remove(ListNode currentNode, int nodeValue)
        {
            if (currentNode == null)
            {
                throw new Exception("Node not found");
            }
            else if (currentNode.NodeValue == nodeValue)
            {
                currentNode = currentNode.NextNode;
            }
            else
            {
                // Recursive call to the current function.
                currentNode.NextNode = Remove(currentNode.NextNode, nodeValue);
            }
            return currentNode;
        }
                
        public bool IsCircularList(ListNode currentNode)
        {
            ListNode rootNode = currentNode;

            if (currentNode == null)
            {
                throw new Exception("List is empty");
            }

            while (currentNode.NextNode != null && currentNode.NextNode != HeadNode)
            {
                currentNode = currentNode.NextNode;
            }
            if (currentNode.NextNode == HeadNode)
            {
                return true;
            }
            return false;
        }

        public bool IsCircularList1(ListNode currentNode)
        {
            bool resultFlag = false;

            if (currentNode == null)
            {
                throw new Exception("List is empty");
            }
            
            ListNode RootNode = currentNode;

            while (true)
            {
                if (currentNode.NextNode == RootNode)
                {
                    resultFlag = true;
                    break;
                }                
                currentNode = currentNode.NextNode;
                if (currentNode == null)
                {
                    resultFlag = false;
                    break;
                }
            }
            return resultFlag;
        }

        // In O(1) Time. 
        public void SplitListInto2Lists(ListNode currentNode)
        {
 
        }
        //Need to test
        public int Find2ndLargetElement(ListNode currentNode , ListNode rootNode)
        {
            int firstLargest = 0;
            int secondLargest = 0;

            if (currentNode == null)
            {
                return -1;
            }
            
            while (currentNode.NextNode != null && currentNode.NextNode != HeadNode)
            {
                if (currentNode.NodeValue > firstLargest)
                {
                    firstLargest = currentNode.NodeValue;
                }
                if (currentNode.NodeValue > secondLargest && currentNode.NodeValue < firstLargest)
                {
                    secondLargest = currentNode.NodeValue;
                }
                currentNode = currentNode.NextNode;
            }
            //Consider the last node value
            if (currentNode.NodeValue > secondLargest && currentNode.NodeValue < firstLargest)
            {
                secondLargest = currentNode.NodeValue;
            }
            return secondLargest;
        }
    }
}