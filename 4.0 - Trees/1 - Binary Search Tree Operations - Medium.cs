using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public partial class BinarySearchTreeOperations
    {
        //http://cslibrary.stanford.edu/109/TreeListRecursion.html
        public void Convert2CircularDoublyLinkedList()
        {

        }

        /// <summary>
        /// The nodes in the doubly linked list are arranged in a sequence formed by a zig-zag level order traversal
        /// </summary>
        /// <param name="currNode"></param>
        /// <returns></returns>
        public TreeNode ConvertToLinkedList(TreeNode currNode)
        {
            if (currNode.LeftNode == null && currNode.RightNode == null)
                return currNode;

            TreeNode temp = null;

            if (currNode.LeftNode != null)
            {
                temp = ConvertToLinkedList(currNode.LeftNode);

                while (temp.RightNode != null)
                    temp = temp.RightNode;

                temp.RightNode = currNode;
                currNode.LeftNode = temp;
            }

            if (currNode.RightNode != null)
            {
                temp = ConvertToLinkedList(currNode.RightNode);

                while (temp.LeftNode != null)
                    temp = temp.LeftNode;

                temp.LeftNode = currNode;
                currNode.RightNode = temp;
            }
            return currNode;
        }

        ListNode listNode;
        public TreeNode CreateTreeFromSLLTest()
        {
            listNode = new ListNode(1);
            listNode.NextNode = new ListNode(2);
            listNode.NextNode.NextNode = new ListNode(3);
            listNode.NextNode.NextNode.NextNode = new ListNode(4);
            listNode.NextNode.NextNode.NextNode.NextNode = new ListNode(5);
            listNode.NextNode.NextNode.NextNode.NextNode.NextNode = new ListNode(6);
            listNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = new ListNode(7);
            listNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = new ListNode(8);
            listNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode.NextNode = new ListNode(9);

            int listLen = GetSLLLen(listNode);
            //            TreeNode treeNode = createTreeFromSLL(listLen);
            TreeNode treeNode = CreateTreeFromSLLIterative(1, listLen);
            return treeNode;
        }

        private TreeNode CreateTreeFromSLLRecurisve(int n)
        {
            if (n <= 0)
                return null;

            TreeNode treenode = new TreeNode(0);
            treenode.LeftNode = CreateTreeFromSLLRecurisve(n / 2);
            treenode.NodeValue = listNode.NodeValue;

            listNode = listNode.NextNode;
            treenode.RightNode = CreateTreeFromSLLRecurisve(n - n / 2 - 1);
            return treenode;
        }

        public TreeNode CreateTreeFromSLLIterative(int leftPos, int rightPos)
        {
            if (leftPos > rightPos) // Creation done.
                return null;

            int mid = (leftPos + (rightPos - leftPos) / 2);

            // Mid Creation
            TreeNode parentNode = new TreeNode();

            // Left side exclude mid.
            parentNode.LeftNode = CreateTreeFromSLLIterative(leftPos, mid - 1);
            parentNode.NodeValue = listNode.NodeValue;

            listNode = listNode.NextNode;
            // Right side exclude mid.
            parentNode.RightNode = CreateTreeFromSLLIterative(mid + 1, rightPos);
            return parentNode;
        }

        public TreeNode ConverToAdjustcentList(TreeNode currentNode)
        {
            if (currentNode == null)
                return null;

            Queue<TreeNode> parentQueue = new Queue<TreeNode>();
            Queue<TreeNode> childQueue = new Queue<TreeNode>();

            parentQueue.Enqueue(currentNode);

            TreeNode leftTraverseList = currentNode;
            TreeNode rightTraverseList = null;
            TreeNode rightTraverseParent = currentNode;

            while (parentQueue.Count > 0)
            {
                TreeNode dqNode = parentQueue.Dequeue();

                // Push left and right
                if (dqNode.LeftNode != null)
                {
                    childQueue.Enqueue(dqNode.LeftNode);
                    dqNode.LeftNode = null;
                }

                if (dqNode.RightNode != null)
                {
                    childQueue.Enqueue(dqNode.RightNode);
                    dqNode.RightNode = null;
                }

                // Right first node.
                if (rightTraverseList == null)
                {
                    rightTraverseList = dqNode;
                    rightTraverseParent = rightTraverseList;
                }
                // All other right nodes (except right first)
                else
                {
                    rightTraverseList.RightNode = dqNode;
                    rightTraverseList = rightTraverseList.RightNode;
                }

                // Level Completes
                if (parentQueue.Count == 0)
                {
                    // So Traverse down to next level(i.e. left)
                    parentQueue = childQueue;
                    childQueue = new Queue<TreeNode>();

                    leftTraverseList.LeftNode = rightTraverseParent;
                    leftTraverseList = leftTraverseList.LeftNode;

                    rightTraverseList = null;
                }
            }

            return currentNode;
        }

        public TreeNode ToAdjacencyList(TreeNode node)
        {
            if (node == null)
                return node;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);

            Stack<TreeNode> childStack = new Stack<TreeNode>();

            TreeNode treeNode = new TreeNode(-1);
            TreeNode newTree = treeNode;
            TreeNode rightTree = null;

            while (stack.Count != 0)
            {
                TreeNode currentNode = stack.Pop();
                if (currentNode.RightNode != null)
                    childStack.Push(currentNode.RightNode);

                if (currentNode.LeftNode != null)
                    childStack.Push(currentNode.LeftNode);

                if (stack.Count == 0)
                {
                    stack = childStack;
                    childStack = new Stack<TreeNode>();
                    treeNode.LeftNode = new TreeNode(currentNode.NodeValue);
                    treeNode = treeNode.LeftNode;
                    rightTree = null;
                }
                else
                {
                    if (rightTree == null)
                        rightTree = new TreeNode(currentNode.NodeValue);
                    else
                    {
                        rightTree.RightNode = new TreeNode(currentNode.NodeValue);
                        rightTree = rightTree.RightNode;
                    }
                }
            }

            return newTree.LeftNode;
        }

        // 538 https://leetcode.com/problems/convert-bst-to-greater-tree
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root == null)
                return null;

            int sum = 0;

            Stack<TreeNode> tnStack = new Stack<TreeNode>();
            TreeNode currNode = root;

            while (tnStack.Count > 0 || currNode != null)
            {
                while (currNode != null)
                {
                    tnStack.Push(currNode);
                    currNode = currNode.RightNode;
                }

                currNode = tnStack.Pop();

                sum += currNode.NodeValue;
                currNode.NodeValue = sum;

                currNode = currNode.LeftNode;
            }

            return root;
        }

        public TreeNode ConvertToDLL(TreeNode currentNode)
        {
            if (currentNode == null)
                return null;

            ConvertToDLL(currentNode.LeftNode);

            if (PrevNode != null)
                PrevNode.RightNode = currentNode;

            currentNode.LeftNode = PrevNode;
            PrevNode = currentNode;

            ConvertToDLL(currentNode.RightNode);
            return PrevNode;
        }

        // Construct Balenced BST
        public TreeNode ConstructTreeByInOrder(int[] sortedArray)
        {
            TreeNode rootNode = ConstructTreeByInOrderRecursion(sortedArray, 0, sortedArray.Length - 1);
            return rootNode;
        }

        public TreeNode ConstructTreeByInOrderRecursion(int[] inOrder, int lIndx, int rIndx)
        {
            if (lIndx > rIndx)
                return null;

            int mid = (lIndx + (rIndx - lIndx) / 2);

            TreeNode parentNode = new TreeNode(inOrder[mid]);

            parentNode.LeftNode = ConstructTreeByInOrderRecursion(inOrder, lIndx, mid - 1);
            parentNode.RightNode = ConstructTreeByInOrderRecursion(inOrder, mid + 1, rIndx);

            return parentNode;
        }

        public TreeNode ConstructTreeByInOrderIteration(int[] inOrder)
        {
            int leftPos = 0;
            int rightPos = inOrder.Length;

            Stack<TreeNode> nodesStack = new Stack<TreeNode>();

            int mid = (leftPos + (rightPos - leftPos) / 2);

            TreeNode rootNode = new TreeNode(inOrder[mid]);
            nodesStack.Push(rootNode);

            while (nodesStack.Count > 0)
            {
                TreeNode parentNode = nodesStack.Pop();

                mid = (leftPos + (rightPos - leftPos) / 2);

                parentNode.LeftNode = new TreeNode(mid);
                nodesStack.Push(parentNode.LeftNode);

                // Left side exclude mid.
                // parentNode.LeftNode = ConstructTreeByInOrderRecursion(inOrder, leftPos, mid - 1);

                // Right side exclude mid.
                // parentNode.RightNode = ConstructTreeByInOrderRecursion(inOrder, mid + 1, rightPos);

            }
            return rootNode;
        }

        // https://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversa/
        TreeNode ConstructTreeByPreOrderRecursive(int[] preOrder)
        {
            int preIndex = 0;
            return ConstructTreeByPreOrderHeler(preOrder, ref preIndex, preOrder[0], int.MinValue, int.MaxValue);
        }

        public TreeNode ConstructTreeByPreOrderHeler(int[] preOrder, ref int preIndex, int key, int minVal, int maxVal)
        {
            if (preIndex >= preOrder.Length || key <= minVal || key >= maxVal)
                return null;

            TreeNode root = new TreeNode(key);
            preIndex = preIndex + 1;

            if (preIndex >= preOrder.Length)
                return root;

            root.LeftNode = ConstructTreeByPreOrderHeler(preOrder, ref preIndex, preOrder[preIndex], minVal, key);
            root.RightNode = ConstructTreeByPreOrderHeler(preOrder, ref preIndex, preOrder[preIndex], key, maxVal);

            return root;
        }

        // http://www.geeksforgeeks.org/construct-a-binary-search-tree-from-given-postorder/

        // 606 Medium https://leetcode.com/problems/construct-string-from-binary-tree/description/
        //You need to construct a string consists of parenthesis and integers from a binary tree with the preorder traversing way.
        //The null node needs to be represented by empty parenthesis pair "()". And you need to omit all the empty parenthesis pairs that don't affect the one-to-one mapping relationship between the string and the original binary tree.
        //Example 1:
        //Input: Binary tree: [1,2,3,4]
        //       1
        //     /   \
        //    2     3
        //   /    
        //  4     

        //Output: "1(2(4))(3)"

        //Explanation: Originallay it needs to be "1(2(4)())(3()())", 
        //but you need to omit all the unnecessary empty parenthesis pairs.
        //And it will be "1(2(4))(3)".

        //Example 2:
        //Input: Binary tree: [1,2,3,null,4]
        //       1
        //     /   \
        //    2     3
        //     \  
        //      4 

        //Output: "1(2()(4))(3)"

        //Explanation: Almost the same as the first example, 
        //except we can't omit the first parenthesis pair to break the one-to-one mapping relationship between the input and the output.

        public string Tree2String(TreeNode currentNode)
        {
            if (currentNode == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode peekNode = null;
            TreeNode lastVisitedNode = null;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    sb.Append("(" + currentNode.NodeValue.ToString());
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    peekNode = stack.Peek();

                    if (peekNode.RightNode != null && peekNode.RightNode != lastVisitedNode)
                    {
                        if (peekNode.LeftNode == null)
                        {
                            sb.Append("()");
                        }
                        currentNode = peekNode.RightNode;
                    }
                    else
                    {
                        sb.Append(")");
                        stack.Pop();
                        //resultString.Append("  " + peekNode.val;
                        lastVisitedNode = peekNode;
                    }
                }
            }

            return sb.ToString().Substring(1, sb.ToString().Length - 2);//Convert.ToString(resultString);
        }
    }
}