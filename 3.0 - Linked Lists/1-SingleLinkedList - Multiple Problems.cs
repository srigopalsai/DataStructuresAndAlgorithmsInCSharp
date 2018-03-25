using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public partial class SingleLinkedListDemo
    {
        public bool Delete(ListNode currentNode)
        {
            if (currentNode == null)
                return false;

            currentNode.NodeValue = currentNode.NextNode.NodeValue;
            currentNode.NextNode = currentNode.NextNode.NextNode;

            // Refer this link why not currentNode = currentNode.Next 
            // https://discuss.leetcode.com/topic/24163/why-node-node-next-is-incorrect/3

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
            ListNode resultNode = RemoveRecursive(HeadNode, nodeValue);

            if (resultNode != null)
            {
                HeadNode = resultNode;
                return true;
            }
            return false;
        }

        private ListNode RemoveRecursive(ListNode headNode, int nodeValue)
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
                currentNode.NextNode = RemoveRecursive(currentNode.NextNode, nodeValue);
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

        // 203 Easy https://leetcode.com/problems/remove-linked-list-elements/description/
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

        // 234 Easy https://leetcode.com/problems/palindrome-linked-list/description/
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

            for (int indx = 0; indx < length / 2; indx++)
            {
                nextNode = currNode.NextNode;
                currNode.NextNode = prevNode;

                prevNode = currNode;
                currNode = nextNode;
            }

            // Step 3: Preserve these 2 pointers to reset the list back in Step 6.
            head = prevNode;
            ListNode midNode = currNode; // 2nd half

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

        // 160 Easy https://leetcode.com/problems/intersection-of-two-linked-lists/description/

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

        // LC 382 https://leetcode.com/problems/linked-list-random-node/#/description
        public int GetRandom(ListNode head)
        {
            int result = head.NodeValue;
            ListNode node = head;

            int kResrvoir = 1;
            int ithNum = 1;

            while (node != null)
            {
                double rndVal = random.NextDouble();
                double reservVal = kResrvoir / (kResrvoir + ithNum * 1.0);

                if (rndVal <= reservVal)
                {
                    result = node.NodeValue;
                }

                ithNum++;
                node = node.NextNode;
            }

            return result;
        }

        /*
        When we read the first node head, if the stream ListNode stops here, we can just return the head.val.
        The possibility is 1/1.
        When we read the second node, we can decide if we replace the result r or not.
        The possibility is 1/2. So we just generate a random number between 0 and 1, and check if it is equal to 1. 
        If it is 1, replace r as the value of the current node, otherwise we don't touch r, so its value is still the value of head.
        When we read the third node, now the result r is one of value in the head or second node.
        We just decide if we replace the value of r as the value of current node(third node). 
        The possibility of replacing it is 1/3, namely the possibility of we don't touch r is 2/3. 
        So we just generate a random number between 0 ~ 2, and if the result is 2 we replace r.
        We can continue to do like this until the end of stream ListNode.
        */
        //http://www.geeksforgeeks.org/reservoir-sampling/
        //http://www.geeksforgeeks.org/?p=25111
        //Guid.NewGuid().GetHashCode());
       
        public int getRandom(ListNode head)
        {
            Random rand = new Random();
            ListNode currNode = head;

            int index = 0;
            int randomVal = currNode.NodeValue;

            while (true)
            {
                if (currNode == null)
                    break;

                if (rand.Next(index + 1) == index)
                    randomVal = currNode.NodeValue;

                currNode = currNode.NextNode;
                index++;
            }

            return randomVal;
        }

        // https://www.programcreek.com/2014/08/leetcode-plus-one-linked-list-java/
        public ListNode PlusOne(ListNode head)
        {
            ListNode head2 = MakeListReverseIterative(head);

            ListNode trav2 = head2;

            while (trav2 != null)
            {
                if (trav2.NodeValue < 9)
                {
                    trav2.NodeValue = trav2.NodeValue + 1;
                    break;
                }
                else
                {
                    trav2.NodeValue = 0;

                    if (trav2.NextNode == null)
                    {
                        //trav2.NextNode = new ListNode(1);
                        //break;

                        ListNode newNode = new ListNode(1);
                        newNode.NextNode = head2;
                        return newNode;
                    }

                    trav2 = trav2.NextNode;
                }
            }

            return MakeListReverseIterative(head2);
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

        // 206 Easy https://leetcode.com/problems/reverse-linked-list/description/
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.NextNode == null)
                return head;

            ListNode current = head;
            ListNode previous = null;
            ListNode NextNode = null;

            while (current != null)
            {
                NextNode = current.NextNode;

                // Change and move the link.            
                current.NextNode = previous;

                // Move currentNode and previousNode pointers by 1 node              
                previous = current;
                current = NextNode;
            }

            return previous;
        }

        public ListNode MakeListReverseRecursive()
        {
            HeadNode = MakeListReverseRecursive(HeadNode);
            return HeadNode;
        }

        public ListNode MakeListReverseRecursive(ListNode head)
        {
            if (head == null || head.NextNode == null)
            {
                return head;
            }

            ListNode newHead = MakeListReverseRecursive(head.NextNode);
            head.NextNode.NextNode = head;
            head.NextNode = null;

            return newHead;
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

            ListNode prevNode = dummyHead;

            int lpCnt = 0;

            while (++lpCnt < startPos)
                prevNode = prevNode.NextNode;

            ListNode currNode = prevNode.NextNode;
            ListNode tempNode = null;

            while (lpCnt++ < endPos)
            {
                tempNode = currNode.NextNode;
                currNode.NextNode = tempNode.NextNode;

                tempNode.NextNode = prevNode.NextNode;
                prevNode.NextNode = tempNode;
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

        // 141 Easy https://leetcode.com/problems/linked-list-cycle/description/
        public bool HasCycle(ListNode headNode)
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

        // 21 Easy https://leetcode.com/problems/merge-two-sorted-lists/description/
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode l3Head = new ListNode(0);
            ListNode l3 = l3Head;

            while (l1 != null && l2 != null)
            {
                if (l1.NodeValue <= l2.NodeValue)
                {
                    l3.NextNode = l1;
                    l1 = l1.NextNode;
                }
                else
                {
                    l3.NextNode = l2;
                    l2 = l2.NextNode;
                }

                l3 = l3.NextNode;
            }

            if (l1 != null)
                l3.NextNode = l1;

            if (l2 != null)
                l3.NextNode = l2;

            return l3Head.NextNode;
        }

        public ListNode MergeTwoListsRecursive(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;

            if (l2 == null)
                return l1;

            if (l1.NodeValue < l2.NodeValue)
            {
                l1.NextNode = MergeTwoListsRecursive(l1.NextNode, l2);
                return l1;
            }
            else
            {
                l2.NextNode = MergeTwoListsRecursive(l2.NextNode, l1);
                return l2;
            }
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
        5. Store hashcodes of list 1 into hashtable and check if hash code exists for each node in list2. O(n + m) and O(m) Extra Space where m is the length of one list.
        6. Find lengths of each list, iterate large list till it matchs with 2nd. Then use 1 loop to iterate and compare each node. O(n + m)        */

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

        // 2 https://leetcode.com/problems/add-two-numbers/description/
        public ListNode AddTwoNumbers(ListNode l1List, ListNode l2List)
        {
            int carry = 0;
            ListNode resultHead = new ListNode(0);
            ListNode resultNode = resultHead;

            while (l1List != null || l2List != null || carry != 0)
            {
                if (l1List != null)
                {
                    carry += l1List.NodeValue;
                    l1List = l1List.NextNode;
                }
                if (l2List != null)
                {
                    carry += l2List.NodeValue;
                    l2List = l2List.NextNode;
                }

                resultNode.NextNode = new ListNode(carry % 10);
                carry /= 10;
                resultNode = resultNode.NextNode;
            }

            return resultHead.NextNode;
        }

        // 61 Medium https://leetcode.com/problems/rotate-list/description/
        public ListNode RotateRight(ListNode head, int kPos)
        {
            if (head == null)
                return null;

            int lstLen = 1; // since we are already at head node

            ListNode fsNode = head;
            ListNode slNode = head;

            while (fsNode.NextNode != null)
            {
                lstLen++;

                fsNode = fsNode.NextNode;
            }

            kPos = kPos % lstLen;

            for (int indx = lstLen - kPos; indx > 1; indx--) // i>1 because we need to put slow.NextNode at the start.
            {
                slNode = slNode.NextNode;
            }

            fsNode.NextNode = head;
            head = slNode.NextNode;
            slNode.NextNode = null;

            return head;
        }

        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     int NodeValue;
         *     ListNode NextNode;
         *     ListNode(int x) { NodeValue = x; }
         * }
         */
        // 23 Hard https://leetcode.com/problems/merge-k-sorted-lists/description/

        class Solution
        {
            public ListNode MergeKLists(ListNode[] lists)
            {
                if (lists == null || lists.Length == 0)
                    return null;

                return Partition(lists, 0, lists.Length - 1);
            }

            public ListNode Partition(ListNode[] lists, int lIndx, int rIndx)
            {
                if (lIndx == rIndx)
                {
                    return lists[lIndx];
                }

                int mIndx = lIndx + (rIndx - lIndx) / 2;

                ListNode l1 = Partition(lists, lIndx, mIndx);
                ListNode l2 = Partition(lists, mIndx + 1, rIndx);

                return Merge2Lists(l1, l2);
            }

            public ListNode Merge2Lists(ListNode l1, ListNode l2)
            {
                ListNode head = new ListNode(0);
                ListNode dummy = head;

                while (l1 != null || l2 != null)
                {
                    if (l1 == null)
                    {
                        head.NextNode = l2;

                        l2 = l2.NextNode;
                    }
                    else if (l2 == null)
                    {
                        head.NextNode = l1;
                        l1 = l1.NextNode;
                    }
                    else
                    {
                        if (l1.NodeValue < l2.NodeValue)
                        {
                            head.NextNode = l1;
                            l1 = l1.NextNode;
                        }
                        else
                        {
                            head.NextNode = l2;
                            l2 = l2.NextNode;
                        }
                    }
                    head = head.NextNode;
                }
                return dummy.NextNode;
            }
        }
    }
}