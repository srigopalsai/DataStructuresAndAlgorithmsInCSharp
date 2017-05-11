using System;
using System.Collections.Generic;
using System.Windows;
using Keys = DataStructuresAndAlgorithms.TestData.Keys;

namespace DataStructuresAndAlgorithms
{
    public partial class LinkedListDemo : Window
    {
        IDictionary<string, int[]> ArraysCollection = TestData.ArraysCollection;

        public LinkedListDemo()
        {
            InitializeComponent();
        }

        private void SLLDemoButton_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            string outputString = string.Empty;
            SingleLinkedListDemo SingleLinkedListDemoObject = new SingleLinkedListDemo();

            // Create Single Lined List 10 to 80
            SingleLinkedListDemoObject.HeadNode = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.Sorted8DecElements]);

            outputString += "Singular Linked List creation success.";

            // Display nodes from head 
            str = SingleLinkedListDemoObject.DisplayNodes(SingleLinkedListDemoObject.HeadNode);
            outputString += Environment.NewLine + Environment.NewLine + "List Items from Head " + Environment.NewLine + str;

            //Get Middle Element
            int middleElement = SingleLinkedListDemoObject.GetMiddleElement();
            outputString += Environment.NewLine + Environment.NewLine + "Middle element value " + middleElement.ToString();

            // Display nodes from tail 
            str = SingleLinkedListDemoObject.DisplayNodesReverse(SingleLinkedListDemoObject.HeadNode);
            //str = SingleLinkedListDemoObject.DisplayNodesReverseIteraton(SingleLinkedListDemoObject.HeadNode);
            outputString += Environment.NewLine + Environment.NewLine + "Display List in Reverse " + Environment.NewLine + str;

            SingleLinkedListDemoObject.HeadNode = SingleLinkedListDemoObject.MakeListReverseRecursive();

            //Split list into multiple list at given lenght
            outputString += Environment.NewLine + Environment.NewLine + "Split List " + Environment.NewLine;
            ListNode listToSplit = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.Sorted12Elements]); // 1 to 12
            List<ListNode> listCollection = SingleLinkedListDemoObject.SplitList(listToSplit, 4);

            foreach (ListNode nodeItem in listCollection)
            {
                ListNode nodeListItem = nodeItem;

                while (nodeListItem != null)
                {
                    outputString += nodeListItem.NodeValue + " -> ";
                    nodeListItem = nodeListItem.NextNode;
                }

                outputString += Environment.NewLine;
            }

            /*      listSplit  : 3 
                    Input      : 1  ->  2   ->  3   ->  4   ->  5   ->  6   ->  7   ->  8
                    Output     : 3  ->  2   ->  1   ->  6   ->  5   ->  4   ->  8   ->  7   */

            int splitIndex = 2;
            ListNode reversedNode = SingleLinkedListDemoObject.ReverseLinkedListInParts(SingleLinkedListDemoObject.HeadNode, splitIndex);
            if (reversedNode != null)
            {
                str = SingleLinkedListDemoObject.DisplayNodes(reversedNode);

                outputString += Environment.NewLine + Environment.NewLine + "Reversed Linked List In Parts : Split 2";
                outputString += Environment.NewLine + "Result List : " + str;
            }

            //Insert in sort Order.
            bool resultStatus = SingleLinkedListDemoObject.InsertInSortOrder(SingleLinkedListDemoObject.HeadNode, 25);
            if (resultStatus == true)
            {
                str = SingleLinkedListDemoObject.DisplayNodes(SingleLinkedListDemoObject.HeadNode);
                outputString += Environment.NewLine + Environment.NewLine + "List Items from Head " + Environment.NewLine + str;
            }

            // Make List Reverse
            SingleLinkedListDemoObject.MakeListReverse();
            str = SingleLinkedListDemoObject.DisplayNodes(SingleLinkedListDemoObject.HeadNode);
            //outputString += Environment.NewLine + Environment.NewLine + "Reverse List " + Environment.NewLine + str
            //// Make List Reverse Recursive
            //SingleLinkedListDemoObject.MakeListReverseRecursive();
            //str = SingleLinkedListDemoObject.DisplayNodes(SingleLinkedListDemoObject.HeadNode);
            //outputString += Environment.NewLine + Environment.NewLine + "Reverse List Recursive " + Environment.NewLine + str;

            //Search for a node
            ListNode resultNode = SingleLinkedListDemoObject.Search(SingleLinkedListDemoObject.HeadNode, 30);
            if (resultNode == null)
            {
                outputString += Environment.NewLine + Environment.NewLine + "Search Result. Node not found";
            }
            else
            {
                outputString += Environment.NewLine + Environment.NewLine + "Search Result. " + resultNode.NodeValue;
            }

            //bool removalResult = SingleLinkedListDemoObject.Delete(resultNode);

            //Remove node from list
            bool removalResult = SingleLinkedListDemoObject.Remove(20);
            if (removalResult == true)
            {
                outputString += Environment.NewLine + Environment.NewLine + "Node '20' removal successful. List after removal. ";
                str = SingleLinkedListDemoObject.DisplayNodes(SingleLinkedListDemoObject.HeadNode);
                outputString += str;
            }
            // Insert after specic element.
            bool insertResult = SingleLinkedListDemoObject.InsertAfter(15, 10);
            if (insertResult == true)
            {
                outputString += Environment.NewLine + Environment.NewLine + "Node '15' insertion after node '10' successful. List after insertion. ";
                str = SingleLinkedListDemoObject.DisplayNodes(SingleLinkedListDemoObject.HeadNode);
                outputString += str;
            }

            // Insert before head element.
            insertResult = SingleLinkedListDemoObject.InsertAtBegin(5);
            if (insertResult == true)
            {
                outputString += Environment.NewLine + Environment.NewLine + "Node '05' insertion at begin successful. List after insertion. ";
                str = SingleLinkedListDemoObject.DisplayNodes(SingleLinkedListDemoObject.HeadNode);
                outputString += str;
            }

            SingleLinkedListDemoObject.RemoveNthFromEnd(SingleLinkedListDemoObject.HeadNode,2);

            int secondLargest = SingleLinkedListDemoObject.Find2ndLargetElement(SingleLinkedListDemoObject.HeadNode);
            outputString += Environment.NewLine + Environment.NewLine + "2nd Larget Element in the list " + secondLargest.ToString();

            int elementValue = SingleLinkedListDemoObject.FindNthElement(1);
            outputString += Environment.NewLine + Environment.NewLine + "Element in 2nd position is " + elementValue.ToString();

            ListNode palindromeList = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.Palindrome2ElementsNve]);
            bool isPalindrome = SingleLinkedListDemoObject.IsPalindrome(palindromeList);
            
            outputString += Environment.NewLine + "Is Palindrome List" + Environment.NewLine + isPalindrome.ToString();

            ListNode list1Head = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.TenTo70DecOddNums]);
            ListNode list2Head = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.TwentyTo60DecEvenNums]);

            resultNode = SingleLinkedListDemo.Merge2ListsIterative(list1Head, list2Head);
            str = SingleLinkedListDemoObject.DisplayNodes(resultNode);
            outputString += Environment.NewLine + "Merge2ListsIterative" + Environment.NewLine + str;

            // Create list in Y shape and chech if it is in Y shape, if it is in Y share return the joint node of the Y list.
            list1Head = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.TenTo70DecOddNums]);
            list2Head = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.TwentyTo60DecEvenNums]);

            ListNode list3Head = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.SeventyTo90DecNums]);

            list1Head = SingleLinkedListDemoObject.Append2List(list1Head, list3Head);
            list2Head = SingleLinkedListDemoObject.Append2List(list2Head, list3Head);

            ListNode intersectNode = SingleLinkedListDemoObject.GetIntersectionNode(list1Head, list2Head);
            outputString += Environment.NewLine + Environment.NewLine + "Intersect Node :" + intersectNode.NodeValue;

            ListNode listNode = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.Sorted4Elements]);
            SingleLinkedListDemoObject.OddEvenList(listNode);

            listNode = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.UnSorted5Elements]);
            listNode = SingleLinkedListDemoObject.InsertionSortList(listNode);

            outputString += Environment.NewLine + "Sorted List " + Environment.NewLine + SingleLinkedListDemoObject.DisplayNodes(listNode); ;

            listNode = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.SortedDup2Of3Elements]);
            listNode = SingleLinkedListDemoObject.DeleteDuplicates(listNode);
            outputString += Environment.NewLine + "Unique List " + Environment.NewLine + SingleLinkedListDemoObject.DisplayNodes(listNode);

            listNode = SingleLinkedListDemoObject.CreateList(ArraysCollection[Keys.Sorted9Elements]);
            listNode = SingleLinkedListDemoObject.ReverseBetween(listNode, 3, 6);
            outputString += Environment.NewLine + "ReverseBetween " + Environment.NewLine + SingleLinkedListDemoObject.DisplayNodes(listNode);

            MessageBox.Show(outputString);
        }

        private void CircularListDemoButton_Click(object sender, RoutedEventArgs e)
        {
            string outputString = string.Empty;
            CircularLinkedListDemo CircularLinkedListDemoObject = new CircularLinkedListDemo();

            // Create Single Lined List 
            CircularLinkedListDemoObject.CreateNode(10);
            CircularLinkedListDemoObject.CreateNode(20);
            CircularLinkedListDemoObject.CreateNode(30);
            CircularLinkedListDemoObject.CreateNode(40);

            outputString += "Circular Linked List creation success.";

            // Display nodes from head 
            string str = CircularLinkedListDemoObject.DisplayNodes(CircularLinkedListDemoObject.HeadNode);
            outputString += Environment.NewLine + Environment.NewLine + "List Items from Head " + Environment.NewLine + str;

            //Is Circular List
            bool result = CircularLinkedListDemoObject.IsCircularList1(CircularLinkedListDemoObject.HeadNode);
            outputString += Environment.NewLine + Environment.NewLine + "Is Circular List?  " + result.ToString();
                        
            //Search for a node
            ListNode resultNode = CircularLinkedListDemoObject.Search(CircularLinkedListDemoObject.HeadNode, 40);
            outputString += Environment.NewLine + Environment.NewLine + "Search Result. " + resultNode.NodeValue;

            //Remove node from list
            bool removalResult = CircularLinkedListDemoObject.Remove(30);
            if (removalResult == true)
            {
                outputString += Environment.NewLine + Environment.NewLine + "Node removal successful. List after removal. ";
                str = CircularLinkedListDemoObject.DisplayNodes(CircularLinkedListDemoObject.HeadNode);
                outputString += str;
            }
            // Insert after specic element.
            bool insertResult = CircularLinkedListDemoObject.InsertAfter(60, 20);
            if (insertResult == true)
            {
                outputString += Environment.NewLine + "Node insertion successful. List after insertion. ";
                str = CircularLinkedListDemoObject.DisplayNodes(CircularLinkedListDemoObject.HeadNode);
                outputString += str;
            }

            // Insert before head element.
            insertResult = CircularLinkedListDemoObject.InsertAtBegin(00);
            if (insertResult == true)
            {
                outputString += Environment.NewLine + "Node insertion at begin successful. List after insertion. ";
                str = CircularLinkedListDemoObject.DisplayNodes(CircularLinkedListDemoObject.HeadNode);
                outputString += str;
            }

            MessageBox.Show(outputString);
        }

        private void DoublyListDemoButton_Click(object sender, RoutedEventArgs e)
        {
            string outputString = string.Empty;
            DoublyLinkedListDemo DoublyLinkedListDemoObject = new DoublyLinkedListDemo();

            // Create Doubly Lined List 
            DoublyLinkedListDemoObject.CreateNode(10);
            DoublyLinkedListDemoObject.CreateNode(20);
            DoublyLinkedListDemoObject.CreateNode(30);
            DoublyLinkedListDemoObject.CreateNode(40);
            DoublyLinkedListDemoObject.CreateNode(50);

            outputString += "Doubly Linked List creation success.";

            // Display nodes from Front 
            string str = DoublyLinkedListDemoObject.FrontTraversal(DoublyLinkedListDemoObject.HeadNode);
            outputString += Environment.NewLine + Environment.NewLine + "List Items from Head " + Environment.NewLine + str;

            // Display nodes from Rear 
            str = DoublyLinkedListDemoObject.RearTraversal(DoublyLinkedListDemoObject.TailNode);
            outputString += Environment.NewLine + Environment.NewLine + "List Items from Tail " + Environment.NewLine + str;

            //Search for a node
            ListNode resultNode = DoublyLinkedListDemoObject.Search(DoublyLinkedListDemoObject.HeadNode, 30);
            outputString += Environment.NewLine + Environment.NewLine + "Search Result. " + resultNode.NodeValue;

            //Remove node from list
            bool removalResult = DoublyLinkedListDemoObject.RemoveNode(40);
            if (removalResult == true)
            {
                outputString += Environment.NewLine + Environment.NewLine + "Node removal successful. List after removal. ";
                str = DoublyLinkedListDemoObject.FrontTraversal(DoublyLinkedListDemoObject.HeadNode);
                outputString += str;
            }
            // Insert after specic element.
            //bool insertResult = DoublyLinkedListDemoObject.InsertAfter(40, 30);
            //if (insertResult == true)
            //{
            //    outputString += Environment.NewLine + "Node insertion successful. List after insertion. ";
            //    str = DoublyLinkedListDemoObject.DisplayNodes(DoublyLinkedListDemoObject.HeadNode);
            //    outputString += str;
            //}

            //// Insert before head element.
            //insertResult = DoublyLinkedListDemoObject.InsertAtBegin("Sairam");
            //if (insertResult == true)
            //{
            //    outputString += Environment.NewLine + "Node insertion at begin successful. List after insertion. ";
            //    str = DoublyLinkedListDemoObject.DisplayNodes(DoublyLinkedListDemoObject.HeadNode);
            //    outputString += str;
            //}

            MessageBox.Show(outputString);
        }
    }
}