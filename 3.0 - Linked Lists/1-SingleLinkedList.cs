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
    public class SingleLinkedListDemo
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

        //=============================================================================================================================================

        public bool Delete(ListNode currentNode)
        {
            if (currentNode == null)
                return false;

            currentNode.NodeValue = currentNode.NextNode.NodeValue;
            currentNode.NextNode = currentNode.NextNode.NextNode;

            // Refer thik why not currentNode = currentNode.Next https://discuss.leetcode.com/topic/24163/why-node-node-next-is-incorrect/3
            return true;
        }

        public ListNode DeleteDuplicates(ListNode srcHead)
        {
            if (srcHead == null) return null;

            ListNode currNode = srcHead;
            ListNode fakeHead = new ListNode(0);
            fakeHead.NextNode = srcHead;

            ListNode uniqueHead = fakeHead;

            while (currNode != null)
            {
                while (currNode.NextNode != null && currNode.NodeValue == currNode.NextNode.NodeValue)
                    currNode = currNode.NextNode;

                // Note here node values might be same but not the same nodes.
                if (currNode == uniqueHead.NextNode)
                    uniqueHead = uniqueHead.NextNode;
                else
                    uniqueHead.NextNode = currNode.NextNode;

                currNode = currNode.NextNode;
            }

            return fakeHead.NextNode;
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

        private ListNode Remove(ListNode headNode, int nodeValue)
        {
            ListNode currentNode = headNode;

            if (currentNode == null)
            {
                //throw new Exception("Node not found");
                return null;
            }
            else if (currentNode != null && currentNode.NodeValue == nodeValue)
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

        //https://discuss.leetcode.com/topic/5397/my-short-c-solution/14
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummyHead = new ListNode(0);

            dummyHead.NextNode = head;

            ListNode slowRunner = dummyHead;
            ListNode fastRunner = dummyHead;

            //Move fast in front so that the gap between slow and fast becomes n
            while (n > 0)
            {
                fastRunner = fastRunner.NextNode;
                n--;
            }

            //Move fast to the end, maintaining the gap
            while (fastRunner.NextNode != null)
            {
                fastRunner = fastRunner.NextNode;
                slowRunner = slowRunner.NextNode;
            }

            //Delete - Replace the node to be deleted.
            slowRunner.NextNode = slowRunner.NextNode.NextNode;

            return dummyHead.NextNode;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;

            ListNode traverser = head;

            while (traverser.NextNode != null)
            {
                if (traverser.NextNode.NodeValue == val)
                    traverser.NextNode = traverser.NextNode.NextNode;
                else
                    traverser = traverser.NextNode;

            }

            if (head.NodeValue == val) return head.NextNode;

            return head;
        }

        public ListNode RemoveElementsUsingFakeHead(ListNode head, int val)
        {
            ListNode fakeHead = new ListNode(0);
            fakeHead.NextNode = head;

            ListNode traverseNode = fakeHead;

            while (traverseNode.NextNode != null)
            {
                if (traverseNode.NextNode.NodeValue == val)
                    traverseNode.NextNode = traverseNode.NextNode.NextNode;
                else
                    traverseNode = traverseNode.NextNode;
            }

            return fakeHead.NextNode;
        }

        public ListNode RemoveElementsRecursive(ListNode head, int val)
        {
            if (head == null) return null;

            head.NextNode = RemoveElements(head.NextNode, val);

            return head.NodeValue == val ? head.NextNode : head;
        }

        public ListNode RemoveDuplicates(ListNode head)
        {
            ListNode currNode = head;

            while (currNode != null && currNode.NextNode != null)
            {
                if (currNode.NodeValue == currNode.NextNode.NodeValue)
                    currNode.NextNode = currNode.NextNode.NextNode;
                else
                    currNode = currNode.NextNode;
            }

            return head;
        }

        // Just replace current node with its next node info so the current node will become null and cleared by GC
        public void RemoveNodeIterative(ListNode currentNode, int nodeValue)
        {
            while (currentNode != null)
            {
                if (currentNode.NodeValue == nodeValue)
                {
                    break;
                }
                currentNode = currentNode.NextNode;
            }
            if (currentNode.NextNode != null)
            {
                currentNode.NodeValue = currentNode.NextNode.NodeValue;
                currentNode.NextNode = currentNode.NextNode.NextNode;
            }
        }

        //=============================================================================================================================================

        public bool IsListEmpty()
        {
            return HeadNode == null;
        }

        // Using global start pointer and recursion.
        ListNode front = null;
        public bool IsPalindrome1(ListNode head)
        {
            front = head;
            return isPalindrome(head);
        }

        public bool isPalindrome(ListNode back)
        {
            if (back == null)
                return true;

            bool result = isPalindrome(back.NextNode);

            if (result == false || front.NodeValue != back.NodeValue)
                return false;

            front = front.NextNode;
            return true;
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.NextNode == null)
                return true;

            // Step 1 : Get length of the list.
            int length = GetLength(head);

            // Step 2: Reverse first half of the list 
            ListNode currNode = head;
            ListNode prevNode = null;
            ListNode nextNode = null;

            for (int lpCnt = 0; lpCnt < length / 2; lpCnt++)
            {
                nextNode = currNode.NextNode;
                currNode.NextNode = prevNode;

                prevNode = currNode;
                currNode = nextNode;
            }

            // Step 3: Preserve these 2 pointers to reset the list back in Step 6.
            head = prevNode;
            ListNode midNode = currNode;

            // Step 4: if odd list then skip the midNode.
            if (length % 2 != 0)
                currNode = currNode.NextNode;

            // Step 5: Compare the 1st and 2nd half lists.
            while (currNode != null)
            {
                if (prevNode.NodeValue != currNode.NodeValue)
                    return false;

                prevNode = prevNode.NextNode;
                currNode = currNode.NextNode;
            }

            //Step 6 : TODO reverse back the first half list and attach the second list.
            return true;
        }

        private int GetLength(ListNode head)
        {
            int length = 0;

            while (head != null)
            {
                length++;
                head = head.NextNode;
            }

            return length;
        }

        // Get the middle element in the list.
        public int GetMiddleElement()
        {
            //int middleNodeValue = -1;
            ListNode loopNode = HeadNode;
            ListNode jumpNode = HeadNode;
            int i = 0;

            while (jumpNode != null)
            {
                jumpNode = jumpNode.NextNode;
                i++;
                if (i % 2 == 0)
                {
                    loopNode = loopNode.NextNode;
                }
            }
            if (loopNode != null)
            {
                return loopNode.NodeValue;
            }
            return -1;
        }

        /*• Maintain two pointers pA and pB initialized at the head of A and B, respectively. 
              Then let them both traverse through the lists, one node at a time.
          • When pA reaches the end of a list, then redirect it to the head of B (yes, B, that's right.).
              Similarly when pB reaches the end of a list, redirect it the head of A.
          • If at any point pA meets pB, then pA/pB is the intersection node.  
          Sol2: Another Solution would be reverse the list and start comparing for overlap and reverse it before returing. 
          Sol3: First find the lengths of the two lists and calculate the difference. Then make the delta as the starting point in the longer list.
          Then move in parallel in both lists until links to next node match. Once you find a match, that's the location where the intersection happens. 
          This will give a time complexity of O(max(m,n)) while still keeping the space complexity at O(1).*/

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode currA = headA;
            ListNode currB = headB;

            while (currA != currB)
            {
                currA = currA == null ? headB : currA.NextNode;
                currB = currB == null ? headA : currB.NextNode;
            }

            return currA;
        }

        // https://leetcode.com/problems/linked-list-random-node/
        // https://discuss.leetcode.com/topic/53795/reservoir-sampling-seems-inefficient/4
        // We can count the length in constructor and use it for random mumber generation.

        public int GetRandomNodeValue()
        {
            ListNode result = HeadNode;
            ListNode currNode = HeadNode;

            int size = 1;

            while (currNode != null)
            {
                if (random.Next(size) == 0)
                    result = currNode;

                size++;
                currNode = currNode.NextNode;
            }

            return result.NodeValue;
        }

        //=============================================================================================================================================

        // 10       20      30      40      50
        // 100      200     300     400     NULL

        // traverseNode = 10, 100
        // currentNode = NULL

        // Time Complexit : O(n) Space Complexity : O(n)

        public ListNode MakeListReverse()
        {
            HeadNode = MakeListReverseIterative(HeadNode);

            return HeadNode;
        }

        ListNode MakeListReverseIterative(ListNode currentNode)
        {
            ListNode previousNode = null;
            ListNode nextNode = null;

            while (currentNode != null)
            {
                nextNode = currentNode.NextNode;

                // Change and move the link.
                currentNode.NextNode = previousNode;

                // Move currentNode and previousNode pointers by 1 node  
                previousNode = currentNode;
                currentNode = nextNode;
            }

            return previousNode;
        }

        public ListNode MakeListReverseRecursive()
        {
            HeadNode = MakeListReverseRecursive(HeadNode);
            return HeadNode;
        }

        //Not working
        ListNode MakeListReverseRecursive(ListNode currentNode)
        {
            if (currentNode == null || currentNode.NextNode == null)
                return currentNode;

            // Traverse till reach tail node first.
            ListNode head = MakeListReverseRecursive(currentNode.NextNode);

            currentNode.NextNode.NextNode = currentNode;
            currentNode.NextNode = null;

            return head;
        }

        ListNode MakeListReverseRecursive2(ListNode currentNode, ListNode nextNode)
        {
            if (nextNode == null)
                return currentNode;

            var tempNext = nextNode.NextNode;
            nextNode.NextNode = currentNode;

            currentNode = tempNext;
            tempNext = currentNode;

            return MakeListReverseRecursive2(currentNode, tempNext);
        }

        /*
listSplit  : 3 
Input      : 1  ->  2   ->  3   ->  4   ->  5   ->  6   ->  7   ->  8
Output     : 3  ->  2   ->  1   ->  6   ->  5   ->  4   ->  8   ->  7

*/
        // Time Complexit : O(n) Space Complexity : O(n)
        public ListNode ReverseLinkedListInParts(ListNode currentNode, int listSplit)
        {
            List<ListNode> listCollection = SplitList(currentNode, listSplit);

            ListNode reversedMainList = new ListNode();

            // Just a Pointer to the reversedMainList Head node, as reversedMainList is used for iteration.
            ListNode reversedMainListHead = reversedMainList;
            reversedMainListHead.NodeValue = 0; // Replace this at the end.

            if (listCollection != null)
            {
                // O(SplitCnt) // Ignore
                foreach (ListNode list in listCollection)
                {
                    ListNode reversedSubList = MakeListReverseIterative(list);

                    // O(n). For all sub child lists. 
                    while (reversedMainList.NextNode != null)
                    {
                        reversedMainList = reversedMainList.NextNode;
                    }

                    reversedMainList.NextNode = reversedSubList;
                }
            }

            // Replacing the zero.
            reversedMainListHead = reversedMainListHead.NextNode;
            return reversedMainListHead;
        }

        public ListNode ReverseBetween1(ListNode srcHead, int startPos, int endPos)
        {
            if (srcHead == null || startPos < 1 || endPos <= startPos)
                return srcHead;

            ListNode dummyHead = new ListNode(0);
            dummyHead.NextNode = srcHead;

            ListNode newList = dummyHead;

            int lpCnt = 0;

            while (++lpCnt < startPos)
                newList = newList.NextNode;

            ListNode currNode = newList.NextNode;
            ListNode nextNode = null;

            while (lpCnt++ < endPos)
            {
                nextNode = currNode.NextNode;
                currNode.NextNode = nextNode.NextNode;

                nextNode.NextNode = newList.NextNode;
                newList.NextNode = nextNode;
            }

            return dummyHead.NextNode;
        }
        // TODO failing tests in LC
        public ListNode ReverseBetween(ListNode currNode, int m, int n)
        {
            if (currNode == null || currNode.NextNode == null)
                return currNode;

            int lpCnt = 1;

            ListNode list1Head = new ListNode(0);
            list1Head.NextNode = currNode;

            while (++lpCnt < m)
                currNode = currNode.NextNode;

            ListNode list1End = currNode;
            currNode = currNode.NextNode;
            ListNode list2End = currNode;

            ListNode nextNode = null;
            ListNode prevNode = null;

            while (currNode != null && lpCnt <= n)
            {
                nextNode = currNode.NextNode;
                currNode.NextNode = prevNode;

                prevNode = currNode;
                currNode = nextNode;

                lpCnt++;
            }

            list1End.NextNode = prevNode;
            list2End.NextNode = currNode;

            return list1Head.NextNode;
        }

        public ListNode OddEvenList(ListNode srcHead)
        {
            if (srcHead == null || srcHead.NextNode == null) return srcHead;

            ListNode currNode = srcHead;
            ListNode oddList = currNode;
            ListNode evenList = currNode.NextNode;
            ListNode evenHead = evenList;

            currNode = currNode.NextNode.NextNode;
            int lpCnt = 3;

            while (currNode != null)
            {
                if (lpCnt % 2 == 0)
                {
                    Console.Write("Even Item : " + evenList.NodeValue);

                    evenList.NextNode = currNode;
                    evenList = evenList.NextNode;
                }
                else
                {
                    Console.Write(" Odd Item : " + oddList.NodeValue);

                    oddList.NextNode = currNode;
                    oddList = oddList.NextNode;
                }
                Console.Write(" Curr Item : " + currNode.NodeValue);

                currNode = currNode.NextNode;
                ++lpCnt;

            }

            if (evenList != null)
                evenList.NextNode = null;

            if (oddList != null)
                oddList.NextNode = evenHead;

            return srcHead;
        }

        public ListNode OddEvenList2(ListNode srcHead)
        {
            if (srcHead == null) return null;

            ListNode oddList = srcHead;
            ListNode evenList = srcHead.NextNode;
            ListNode evenListHead = evenList;

            while (evenList != null && evenList.NextNode != null)
            {
                oddList.NextNode = evenList.NextNode;
                oddList = oddList.NextNode;

                evenList.NextNode = oddList.NextNode;
                evenList = evenList.NextNode;
            }

            oddList.NextNode = evenListHead;
            return srcHead;
        }

        public ListNode oddEvenList(ListNode srcHead)
        {
            if (srcHead == null) return null;

            ListNode oddList = srcHead;
            ListNode evenList = srcHead.NextNode;
            ListNode evenListHead = evenList;

            while (evenList != null && evenList.NextNode != null)
            {
                oddList.NextNode = oddList.NextNode.NextNode;
                oddList = oddList.NextNode;

                evenList.NextNode = evenList.NextNode.NextNode;
                evenList = evenList.NextNode;
            }

            oddList.NextNode = evenListHead;
            return srcHead;
        }

        Random random = new Random();

        // Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x. 
        // You should preserve the original relative order of the nodes in each of the two partitions.
        // E.g. Given 1 -> 4 -> 3 -> 2 -> 5 -> 2 and x = 3, return 1 -> 2 -> 2 -> 4 -> 3 -> 5.  https://leetcode.com/problems/partition-list/

        public ListNode Partition(ListNode srcHead, int x)
        {
            //create two new nodelist for larger and smaller nodes
            ListNode leftList = new ListNode(0);
            ListNode rightList = new ListNode(0);

            ListNode leftListHead = leftList;
            ListNode rightListHead = rightList;

            ListNode currNode = srcHead;
            ListNode currNext = null;

            while (currNode != null)
            {
                currNext = currNode.NextNode;
                currNode.NextNode = null;

                if (currNode.NodeValue < x)
                {
                    leftList.NextNode = currNode;
                    leftList = leftList.NextNode;
                }
                else
                {
                    rightList.NextNode = currNode;
                    rightList = rightList.NextNode;
                }

                currNode = currNext;
            }

            leftList.NextNode = rightListHead.NextNode;
            return leftListHead.NextNode;
        }

        // O(1) extra space
        public List<ListNode> SplitList(ListNode currentNode, int splitCnt)
        {
            int lpCnt = 1;

            ListNode headFixdPtr = currentNode;
            List<ListNode> nodeList = new List<ListNode>();

            while (currentNode != null)
            {
                if (lpCnt == splitCnt)
                {
                    ListNode tempNode = currentNode.NextNode;
                    currentNode.NextNode = null;

                    nodeList.Add(headFixdPtr);

                    currentNode = tempNode;
                    headFixdPtr = currentNode;
                    lpCnt = 1;
                }
                else
                {
                    currentNode = currentNode.NextNode;
                    lpCnt++;
                }
            }

            if (headFixdPtr != null)
            {
                nodeList.Add(headFixdPtr);
            }

            return nodeList;
        }

        // Extra O(n) space.
        public List<ListNode> SplitList2(ListNode currentNode, int splitCnt)
        {
            int lpCnt = 1;
            ListNode iterationNode = new ListNode();
            ListNode headFixdPtr = iterationNode;

            List<ListNode> nodeList = new List<ListNode>();

            while (currentNode != null)
            {
                iterationNode.NodeValue = currentNode.NodeValue;
                currentNode = currentNode.NextNode;

                if (lpCnt == splitCnt || currentNode == null)
                {
                    nodeList.Add(headFixdPtr);
                    iterationNode = new ListNode();
                    headFixdPtr = iterationNode;

                    lpCnt = 1;
                }
                else
                {
                    iterationNode.NextNode = new ListNode();
                    iterationNode = iterationNode.NextNode;
                    lpCnt++;
                }
            }

            return nodeList;
        }

        public int Find2ndLargetElement(ListNode currentNode)
        {
            ListNode rootNode = currentNode;
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

        //Need to implement
        public int FindNthLargetElement(ListNode currentNode, int position)
        {
            ListNode rootNode = currentNode;
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

        public int FindNthElement(int elementPosition)
        {
            ListNode currentNode = HeadNode;
            for (int position = 0; position < elementPosition; position++)
            {
                if (currentNode != null)
                {
                    currentNode = currentNode.NextNode;
                }
                else
                {
                    return -1;
                }
            }
            if (currentNode != null)
            {
                return currentNode.NodeValue;
            }
            return -1;
        }

        //=============================================================================================================================================

        // http://www.dontforgettothink.com/2011/11/23/merge-sort-of-linked-list/       
        public void SortList()
        {
            //MergeSort()
            //GetMiddleNode()
            //PartitionAndMerge
        }

        public static ListNode Merge2ListsIterative(ListNode l1Node, ListNode l2Node)
        {
            ListNode fakeHead = new ListNode(0);
            ListNode traverseNode = fakeHead;

            while (l1Node != null && l2Node != null)
            {
                if (l1Node.NodeValue < l2Node.NodeValue)
                {
                    traverseNode.NextNode = l1Node;
                    l1Node = l1Node.NextNode;
                }
                else
                {
                    traverseNode.NextNode = l2Node;
                    l2Node = l2Node.NextNode;
                }

                traverseNode = traverseNode.NextNode;
            }

            if (l1Node != null)
                traverseNode.NextNode = l1Node;

            else if (l2Node != null)
                traverseNode.NextNode = l2Node;

            return fakeHead.NextNode;
        }

        public static ListNode Merge2ListsRecursive(ListNode l1Node, ListNode l2Node)
        {
            if (l1Node == null) return l2Node;
            if (l2Node == null) return l1Node;

            ListNode mergeHead;

            if (l1Node.NodeValue < l2Node.NodeValue)
            {
                mergeHead = l1Node;
                mergeHead.NextNode = Merge2ListsRecursive(l1Node.NextNode, l2Node);
            }
            else
            {
                mergeHead = l2Node;
                mergeHead.NextNode = Merge2ListsRecursive(l1Node, l2Node.NextNode);
            }

            return mergeHead;
        }

        public ListNode Append2List(ListNode sourceList, ListNode list2Append)
        {
            ListNode head = sourceList;
            while (sourceList.NextNode != null)
                sourceList = sourceList.NextNode;

            sourceList.NextNode = list2Append;
            return head;
        }

        //http://stackoverflow.com/questions/2663115/how-to-detect-a-loop-in-a-linked-list?rq=1
        // https://en.wikipedia.org/wiki/Cycle_detection#Brent.27s_algorithm (Optimiged of Floyd's Tortoice and hare.)
        public bool IsCyclicLinkedList(ListNode headNode)
        {
            if (headNode == null)
                return false;

            ListNode slowNode = headNode;
            ListNode fastNode = headNode.NextNode;

            while (fastNode != null && fastNode.NextNode != null)
            {
                if (slowNode == fastNode)
                    return true;

                slowNode = slowNode.NextNode;
                fastNode = fastNode.NextNode.NextNode;
            }

            return false;
        }

        // With O(n) space.
        public static bool IsCyclicLinkedListWithExtraSpace(LinkedList<ListNode> list)
        {
            HashSet<ListNode> visited = new HashSet<ListNode>();

            foreach (ListNode n in list)
            {
                visited.Add(n);

                if (visited.Contains(n.NextNode))
                    return true;
            }

            return false;
        }

        /*  Cycle = length of the cycle, if exists.
            C is the beginning of Cycle, S is the distance of slow pointer from C when slow pointer meets fast pointer.

            Distance(slow) = C + S, Distance(fast) = 2 * Distance(slow) = 2 * (C + S). 
            To let slow poiner meets fast pointer, only if fast pointer run 1 cycle more than slow pointer.
            Distance(fast) - Distance(slow) = Cycle

            => 2 * (C + S) - (C + S) = Cycle
            => C + S = Cycle
            => C = Cycle - S
            => This means if slow pointer runs(Cycle - S) more, it will reaches C.So at this time, if there's another point2 running from head
            => After C distance, point2 will meet slow pointer at C, where is the beginning of the cycle.   */
        public ListNode DetectCycle(ListNode headNode)
        {
            ListNode slowNode = headNode;
            ListNode fastNode = headNode;

            while (fastNode != null && fastNode.NextNode != null)
            {
                fastNode = fastNode.NextNode.NextNode;
                slowNode = slowNode.NextNode;

                if (slowNode == fastNode)
                {
                    while (slowNode != headNode)
                    {
                        slowNode = slowNode.NextNode;
                        headNode = headNode.NextNode;
                    }
                    return slowNode;
                }
            }
            return null;
        }

        /*  Two lists:

            List 1 : 1 -  2 -  3 -  4 -  5
                                            9  - 10 - 11 - 12
            List 2 :           6 -  7 -  8

        Intersection point is : 9

        1. Brute Force: Repeat 2 loops Outer and inner for 2 lists.
        2. If we can edit the list then mark each node as visited.
        3. Use lists count diff.
        4. Make one list as Circular first and see 2nd list where
        5. Store hashcodes of list 1 into hashtable and check if hash code exists for each node in list2. O(n + m) and O(m) Extra Space where m is the lenght of one list.
        6. Find lenghts of each list, iterate large list till it matchs with 2nd. Then use 1 loop to iterate and compare each node. O(n + m)        */

        public ListNode FindInterSectionOf2Lists(ListNode listNode1, ListNode listNode2)
        {
            int len1, len2, diff;
            ListNode head1 = listNode1;
            ListNode head2 = listNode2;

            len1 = 0; // getlength(head1);  
            len2 = 0; // getlength(head2);  

            diff = len1 - len2;

            if (len1 < len2)
            {
                head1 = listNode2;
                head2 = listNode1;
                diff = len2 - len1;
            }

            for (int i = 0; i < diff; i++)
            {
                head1 = head1.NextNode;
            }

            while (head1 != null && head2 != null)
            {
                if (head1 == head2)
                    return head1;

                head1 = head1.NextNode;
                head2 = head2.NextNode;
            }

            return null;
        }

        public void CompareNodes()
        {
            ListNode n1 = new ListNode();
            n1.NodeValue = 20;

            ListNode n5 = n1;

            if (n1.GetHashCode() == n5.GetHashCode()) // True
            {
                Console.WriteLine("Same hashcode : " + n1.GetHashCode() + " " + n5.GetHashCode());
            }

            if (n1 == n5)                             // True
            {
                Console.WriteLine("Both are same");
            }

            ListNode n6 = new ListNode();
            n6 = n1;

            if (n1 == n6)                             // True
            {
                Console.WriteLine("Both Objs are same");
            }

            ListNode n2 = new ListNode();
            n2.NodeValue = 30;

            if (n1 == n2)                              // False
            {
                Console.WriteLine("Both Objs are same n2 ");
            }

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