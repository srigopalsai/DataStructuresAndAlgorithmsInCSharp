using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public partial class BinaryTreeOperations
    {
        // Medium 654 https://leetcode.com/submissions/detail/120667189/
        //public TreeNode constructMaximumBinaryTree(int[] nums)
        //{
        //    if (nums == null || nums.Length == 0)
        //        return null;

        //    Queue<TreeNode> st = new Queue<TreeNode>();
        //    foreach (int num in nums)
        //    {
        //        TreeNode cur = new TreeNode(num);

        //        while (!st.isEmpty() && st.peekLast().val < num)
        //        {
        //            cur.LeftNode = st.removeLast();
        //        }

        //        if (!st.isEmpty())
        //            st.peekLast().right = cur;

        //        st.addLast(cur);
        //    }

        //    return st.peekFirst();
        //}

        // 236 Medium https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
        // Given a binary tree, find the lowest common ancestor(LCA) of two given nodes in the tree.
        // The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).
        //         _______3______
        //        /              \
        //     ___5__ ___1__
        //    /      \        /      \
        //    6      _2       0       8
        //          /  \
        //          7   4
        // E.g1. The lowest common ancestor(LCA) of nodes 5 and 1 is 3. 
        // E.g2. LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.

        bool foundFlag = false;
        private TreeNode LowestCommonAncestor(TreeNode currentNode, int NodeValue1, int NodeValue2)
        {
            if (currentNode == null || currentNode.NodeValue == NodeValue1 || currentNode.NodeValue == NodeValue2)
                return currentNode;

            TreeNode leftNode = LowestCommonAncestor(currentNode.LeftNode, NodeValue1, NodeValue2);

            TreeNode rightNode = null;
            if (foundFlag == false)
                rightNode = LowestCommonAncestor(currentNode.RightNode, NodeValue1, NodeValue2);

            if (leftNode != null && rightNode != null)
            {
                foundFlag = true;
                return currentNode;
            }
            else if (leftNode != null)
                return leftNode;
            else
                return rightNode;
        }

        //LC 103. https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
        // https://discuss.leetcode.com/topic/4545/accepted-c-recursive-solution-with-no-queues
        // https://discuss.leetcode.com/topic/33809/4ms-concise-dfs-c-implementation
        public IList<IList<int>> ZigzagLevelOrder()
        {
            TreeNode rootNode = this.RootdNode;
            Stack<TreeNode> evenStack = new Stack<TreeNode>();
            Stack<TreeNode> oddStack = new Stack<TreeNode>();

            IList<IList<int>> itemsColl = new List<IList<int>>();
            IList<int> items = new List<int>();

            oddStack.Push(rootNode);

            while (evenStack.Count > 0 || oddStack.Count > 0)
            {
                if (oddStack.Count > 0)
                {
                    while (oddStack.Count > 0)
                    {
                        TreeNode currNode = oddStack.Pop();
                        items.Add(currNode.NodeValue);

                        if (currNode.LeftNode != null)
                            evenStack.Push(currNode.LeftNode);

                        if (currNode.RightNode != null)
                            evenStack.Push(currNode.RightNode);
                    }
                }
                else
                {
                    while (evenStack.Count > 0)
                    {
                        TreeNode currNode = evenStack.Pop();
                        items.Add(currNode.NodeValue);

                        if (currNode.RightNode != null)
                            oddStack.Push(currNode.RightNode);

                        if (currNode.LeftNode != null)
                            oddStack.Push(currNode.LeftNode);
                    }
                }

                itemsColl.Add(items);
                items = new List<int>();
            }
            return itemsColl;
        }

        // 105 Medium https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal
        // Given preorder and inorder traversal of a tree, construct the binary tree.
        // Note:
        // You may assume that duplicates do not exist in the tree.
        // E.g
        // preorder = [3, 9, 20, 15, 7]
        // inorder = [9, 3, 15, 20, 7]
        // Return the following binary tree:
        //     3
        //    / \
        //   9  20
        //     /  \
        //    15   7
        // Time O(N^2)
        public TreeNode BuildTreeFromPreAndInOrder(int[] preOrder, int[] inOrder)
        {
            if (preOrder == null || preOrder.Length == 0 || inOrder == null || inOrder.Length == 0)
                return null;

            int preIndx = 0;
            return BuildTreeFromPreAndInOrderHelper(preOrder, inOrder, ref preIndx, 0, inOrder.Length - 1);
        }

        private TreeNode BuildTreeFromPreAndInOrderHelper(int[] preNums, int[] inNums, ref int preIndx, int inStrt, int inEnd)
        {
            if (inStrt > inEnd)
                return null;

            TreeNode tNode = new TreeNode(preNums[preIndx]);
            preIndx++;

            // When there is no childern for the current node then return
            if (inStrt == inEnd)
                return tNode;

            // Else find the index of the current node in Inorder traversal
            int inIndex = SearchIndex(inNums, inStrt, inEnd, tNode.NodeValue);

            // Using index in Inorder traversal, construct left and right subtress
            tNode.LeftNode = BuildTreeFromPreAndInOrderHelper(preNums, inNums, ref preIndx, inStrt, inIndex - 1);
            tNode.RightNode = BuildTreeFromPreAndInOrderHelper(preNums, inNums, ref preIndx, inIndex + 1, inEnd);

            return tNode;
        }

        // https://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversa/


        // Do binary search, since in Array is sorted if no duplicates.
        public int SearchIndex(int[] nums, int start, int end, int val)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            int indx = -1;

            for (indx = start; indx <= end; indx++)
            {
                if (nums[indx] == val)
                    return indx;
            }

            return indx;
        }

        // 106 Medium https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal
        // Given inorder and postorder traversal of a tree, construct the binary tree.
        // You may assume that duplicates do not exist in the tree.
        // For example, given inorder = [9, 3, 15, 20, 7]
        // postorder = [9, 15, 7, 20, 3]
        // Return the following binary tree:
        //    3
        //   / \
        //  9  20
        //    /  \
        //   15   7
        public TreeNode BuildTreeFromInAndPostOrder(int[] inOrder, int[] postOrder)
        {
            if (postOrder == null || postOrder.Length == 0 || inOrder == null || inOrder.Length == 0)
                return null;

            int postIndx = postOrder.Length - 1;
            return BuildTreeFromInAndPostOrderHelper(inOrder, postOrder, ref postIndx, 0, inOrder.Length - 1);
        }

        private TreeNode BuildTreeFromInAndPostOrderHelper(int[] inOrder, int[] postOrder, ref int postIndex, int inStrt, int inEnd)
        {
            if (inStrt > inEnd)
                return null;

            TreeNode node = new TreeNode(postOrder[postIndex]);
            postIndex--;

            // If current node has has no children then return current node.
            if (inStrt == inEnd)
                return node;

            // Else find the index of this node in Inorder  traversal
            int inCurIndex = SearchIndex(inOrder, inStrt, inEnd, node.NodeValue);

            // Right node first and left node next
            node.RightNode = BuildTreeFromInAndPostOrderHelper(inOrder, postOrder, ref postIndex, inCurIndex + 1, inEnd);
            node.LeftNode = BuildTreeFromInAndPostOrderHelper(inOrder, postOrder, ref postIndex, inStrt, inCurIndex - 1);

            return node;
        }

        // https://www.geeksforgeeks.org/full-and-complete-binary-tree-from-given-preorder-and-postorder-traversals/

        public TreeNode ConstructFullCompleteTree(int[] pre, int[] post, int stIndx, int endIndx, int size, ref int preIndx)
        {
            if (preIndx >= size || stIndx > endIndx)
                return null;

            // The first node in preorder traversal is root.
            // So take the node at preIndex from preorder and make it root, and increment
            // preIndex

            TreeNode root = new TreeNode(pre[preIndx]);
            preIndx++;

            // If the current subarry has only one element,
            // No need to recur or preIndex > size after incrementing

            if (stIndx == endIndx || preIndx >= size)
                return root;

            int indx;

            // Search the next element of pre[] in post[]

            for (indx = stIndx; indx <= endIndx; indx++)
            {
                if (post[indx] == pre[preIndx])
                    break;
            }

            // Use the index of element found in postorder to divide postorder array in two parts. 
            // Left subtree and right subtree

            if (indx <= endIndx)
            {
                root.LeftNode = ConstructFullCompleteTree(pre, post, stIndx, indx, size, ref preIndx);
                root.RightNode = ConstructFullCompleteTree(pre, post, indx + 1, endIndx, size, ref preIndx);
            }

            return root;
        }

        // https://www.geeksforgeeks.org/construct-a-special-tree-from-given-preorder-traversal/
        
        public TreeNode ConstructSpecialTree(int[] pre, char[] preLN, ref int curIndx, int n, TreeNode temp)
        {
            // Base Case: All nodes are constructed
            if (curIndx == n)
                return null;

            int index = curIndx;

            temp = new TreeNode(pre[index]);
            curIndx++;

            // If this is an internal node, construct left and right subtrees and link the subtrees
            if (preLN[index] == 'N')
            {
                temp.LeftNode = ConstructSpecialTree(pre, preLN, ref curIndx, n, temp.LeftNode);
                temp.RightNode = ConstructSpecialTree(pre, preLN, ref curIndx, n, temp.RightNode);
            }

            return temp;
        }
    }
}