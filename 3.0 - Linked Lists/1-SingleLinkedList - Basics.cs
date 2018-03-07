using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    
    Unrolled List, each node maintains list of elements (array of elements) http://en.wikipedia.org/wiki/Unrolled_linked_list

    
    Hash linking :
    The link fields need not be physically part of the nodes. If the data records are stored in an array and referenced by their indices, the link field may be stored in a separate array with the same indices as the data records.


    The Josephus problem is an election method that works by having a group of people stand in a circle. Starting at a predetermined person, you count around the circle n times. 
    Once you reach the nth person, take them out of the circle and have the members close the circle. 
    Then count around the circle the same n times and repeat the process, until only one person is left. That person wins the election.
    This shows the strengths and weaknesses of a linked list vs. a dynamic array, because if you view the people as connected nodes in a circular linked list then it shows how easily the linked list is able to delete nodes (as it only has to rearrange the links to the different nodes). 
    However, the linked list will be poor at finding the next person to remove and will need to search through the list until it finds that person. 
    A dynamic array, on the other hand, will be poor at deleting nodes (or elements) as it cannot remove one node without individually shifting all the elements up the list by one. 
    However, it is exceptionally easy to find the nth person in the circle by directly referencing them by their position in the array.

    The list ranking problem concerns the efficient conversion of a linked list representation into an array. Although trivial for a conventional computer, solving this problem by a parallel algorithm is complicated and has been the subject of much research.

    A balanced tree has similar memory access patterns and space overhead to a linked list while permitting much more efficient indexing, taking O(log n) time instead of O(n) for a random access. 
    However, insertion and deletion operations are more expensive due to the overhead of tree manipulations to maintain balance. Schemes exist for trees to automatically maintain themselves in a balanced state: AVL trees or red-black trees.

    Double-linked lists require more space per node (unless one uses XOR-linking), and their elementary operations are more expensive; but they are often easier to manipulate because they allow fast and easy sequential access to the list in both directions. 

    List handles :
    Since a reference to the first node gives access to the whole list, that reference is often called the address, pointer, or handle of the list. 
    Algorithms that manipulate linked lists usually get such handles to the input lists and return the handles to the resulting lists. In fact, 

    A singly linked linear list is a recursive data structure, because it contains a pointer to a smaller object of the same type. 
    For that reason, many operations on singly linked linear lists (such as merging two lists, or enumerating the elements in reverse order) often have very simple recursive algorithms, much simpler than any solution using iterative commands. 
    While those recursive solutions can be adapted for doubly linked and circularly linked lists, the procedures generally need extra arguments and more complicated base cases.

    Another disadvantage of linked lists is the extra storage needed for references, which often makes them impractical for lists of small data items such as characters or boolean values, because the storage overhead for the links may exceed by a factor of two or more the size of the data. 

    An XOR linked list is a data structure used in computer programming. It takes advantage of the bitwise XOR operation to decrease storage requirements for doubly linked lists.
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ============================================================================================================================================================================================================================

    */
    public partial class SingleLinkedListDemo
    {
        public ListNode HeadNode;
        string Data = string.Empty;

        public void Clear()
        {
            HeadNode = null;
        }

        public void CreateNode(int listNodeValue)
        {
            HeadNode = AddNodeToList(HeadNode, listNodeValue);
        }

        public ListNode CreateList(int[] srcArray)
        {
            if (srcArray == null || srcArray.Length == 0)
                return null;

            ListNode head = new ListNode(srcArray[0]);
            ListNode currNode = head;

            for (int lpCnt = 1; lpCnt < srcArray.Length; lpCnt++)
            {
                currNode.NextNode = new ListNode(srcArray[lpCnt]);
                currNode = currNode.NextNode;
            }
            return head;
        }

        private ListNode AddNodeToList(ListNode currentNode, int listNodeValue)
        {
            if (currentNode == null)
            {
                currentNode = new ListNode(listNodeValue);
            }
            else
            {
                // Recursive call to the current function.
                //currentNode.NextNode = AddNodeToList(currentNode.NextNode, listNodeValue);
                ListNode traverseNode = currentNode;
                while (traverseNode.NextNode != null)
                {
                    traverseNode = traverseNode.NextNode;
                }
                traverseNode.NextNode = new ListNode(listNodeValue);
            }
            return currentNode;
        }

        public string DisplayNodes(ListNode currentNode)
        {
            string Data = string.Empty;
            while (currentNode != null)
            {
                Data += "   " + currentNode.NodeValue;
                currentNode = currentNode.NextNode;
            }
            return Data;
        }

        //Display Linked List in Reverse using recursion. Time : O(2n) Space: O(n) - Call Stack
        public string DisplayNodesReverse(ListNode currentNode)
        {
            if (currentNode != null)
            {
                DisplayNodesReverse(currentNode.NextNode);
                Data += "   " + currentNode.NodeValue;
            }
            return Data;
        }

        //Display Linked List in Reverse using While. Time : O(2n) Space: O(n) - User Stack
        public string DisplayNodesReverseIteraton(ListNode currentNode)
        {
            Stack<int> listItems = new Stack<int>();

            while (currentNode != null)
            {
                listItems.Push(currentNode.NodeValue);
                currentNode = currentNode.NextNode;
            }

            while (listItems.Count > 0)
            {
                Data += "   " + listItems.Pop();
            }

            return Data;
        }

        public ListNode Search(ListNode currentNode, int nodeValue)
        {
            while (currentNode != null)
            {
                if (currentNode.NodeValue == nodeValue)
                {
                    return currentNode;
                }
                currentNode = currentNode.NextNode;
            }
            return null;
        }

        public bool InsertAtBegin(int nodeValueToInsert)
        {
            ListNode tempNode = new ListNode();
            tempNode.NextNode = HeadNode;
            tempNode.NodeValue = nodeValueToInsert;
            HeadNode = tempNode;
            return true;
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

        public bool InsertInSortOrder(ListNode currentNode, int NodeValueToInsert)
        {
            if (currentNode == null)
            {
                currentNode = new ListNode();
                currentNode.NodeValue = NodeValueToInsert;
                return true;
            }
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.NextNode != null)
                    {
                        if (NodeValueToInsert > currentNode.NodeValue && NodeValueToInsert < currentNode.NextNode.NodeValue)
                        {
                            ListNode tempNode = new ListNode();
                            tempNode.NodeValue = NodeValueToInsert;
                            tempNode.NextNode = currentNode.NextNode;
                            currentNode.NextNode = tempNode;
                            return true;
                        }
                    }
                    else
                    {
                        // Bigger than Last node. 
                        ListNode tempNode = new ListNode();
                        tempNode.NodeValue = NodeValueToInsert;
                        currentNode.NextNode = tempNode;
                        return true;
                    }
                    currentNode = currentNode.NextNode;
                }
            }
            return false;
        }

        public ListNode InsertionSortList(ListNode currNode)
        {
            ListNode dummyNewHead = new ListNode(int.MinValue);
            ListNode prevNode = dummyNewHead;
            ListNode currNextNode = null;

            while (currNode != null)
            {
                currNextNode = currNode.NextNode;

                // Reset prevNode to head only when currNode value is smaller than the prevNode.
                // Otherwise let it be as last node of sorted list.

                if (currNode.NodeValue <= prevNode.NodeValue)
                    prevNode = dummyNewHead;

                while (prevNode.NextNode != null && prevNode.NextNode.NodeValue < currNode.NodeValue)
                    prevNode = prevNode.NextNode;

                // Swap current and next node.
                currNode.NextNode = prevNode.NextNode;
                prevNode.NextNode = currNode;

                currNode = currNextNode;
            }

            return dummyNewHead.NextNode;
        }

        public bool IsListEmpty()
        {
            return HeadNode == null;
        }
    }
}
/*
1. Null node.
2. List with one node.
3. List with even number of nodes.
4. List with odd number of nodes.
5. Original list is maintained after any appropriate operation.
*/