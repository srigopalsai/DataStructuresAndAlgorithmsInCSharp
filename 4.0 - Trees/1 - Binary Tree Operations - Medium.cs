using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public partial class BinaryTreeOperations
    {
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

        // Note Build Right node first
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

        // https://www.geeksforgeeks.org/construct-tree-inorder-level-order-traversals/

        //Input: Two arrays that represent Inorder and level order traversals of a Binary Tree
        //in[]    = {4, 8, 10, 12, 14, 20, 22};
        //level[] = {20, 8, 22, 4, 12, 10, 14};
        //Output: Construct the tree represented by the two arrays.
        //     20
        //    /  \
        //   8   22
        //  / \ 
        // 4   12
        //    /  \
        //   10   14
        public TreeNode BuildTreeFromInAndLevelOrder(TreeNode currNode, int[] levelOrder, int[] inOrder, int inStart, int inEnd)
        {
            if (inStart > inEnd)
                return null;

            if (inStart == inEnd)
                return new TreeNode(inOrder[inStart]);

            bool found = false;
            int rootIndx = 0;

            // it represents the index in inOrder array of element that appear first in levelOrder array.
            for (int indxLvlOrdr = 0; indxLvlOrdr < levelOrder.Length - 1; indxLvlOrdr++)
            {
                int lvlOrdrVal = levelOrder[indxLvlOrdr];

                for (int indxInOrdr = inStart; indxInOrdr < inEnd; indxInOrdr++)
                {
                    if (lvlOrdrVal == inOrder[indxInOrdr])
                    {
                        currNode = new TreeNode(lvlOrdrVal);
                        rootIndx = indxInOrdr;
                        found = true;
                        break;
                    }
                }

                if (found == true)
                    break;
            }

            currNode.LeftNode = BuildTreeFromInAndLevelOrder(currNode, levelOrder, inOrder, inStart, rootIndx - 1);
            currNode.RightNode = BuildTreeFromInAndLevelOrder(currNode, levelOrder, inOrder, rootIndx + 1, inEnd);

            return currNode;
        }

        // https://www.geeksforgeeks.org/full-and-complete-binary-tree-from-given-preorder-and-postorder-traversals/

        public TreeNode BuildFullCompleteTree(int[] preOrder, int[] postOrder, int pstLIndx, int pstRIndx, ref int preIndx)
        {
            if (preIndx >= preOrder.Length || pstLIndx > pstRIndx)
                return null;

            TreeNode root = new TreeNode(preOrder[preIndx]);
            preIndx++;

            // If the current subarry has only one element, No need to recur or preIndex > size after incrementing

            if (pstLIndx == pstRIndx || preIndx >= preOrder.Length)
                return root;

            int pstCIndx;

            // Search the next element of pre[] in post[]

            for (pstCIndx = pstLIndx; pstCIndx <= pstRIndx; pstCIndx++)
            {
                if (postOrder[pstCIndx] == preOrder[preIndx])
                    break;
            }

            // Use the index of element found in postorder to divide postorder array in two parts. 

            if (pstCIndx <= pstRIndx)
            {
                root.LeftNode = BuildFullCompleteTree(preOrder, postOrder, pstLIndx, pstCIndx, ref preIndx);
                root.RightNode = BuildFullCompleteTree(preOrder, postOrder, pstCIndx + 1, pstRIndx, ref preIndx);
            }

            return root;
        }

        // https://www.geeksforgeeks.org/construct-a-special-tree-from-given-preorder-traversal/
        // Input:  pre[]   = {10, 30, 20, 5, 15},  
        //         preLN[] = {'N', 'N', 'L', 'L', 'L'} // Leaf or Non Leaf
        // Output: Root of following tree
        //              10
        //             /  \
        //            30   15
        //           /  \
        //          20   5
        public TreeNode BuildSpecialTree(int[] preOrder, char[] preLN, ref int curIndx, TreeNode cNode)
        {
            // Base Case: All nodes are constructed
            if (curIndx == preOrder.Length)
                return null;

            int index = curIndx;

            cNode = new TreeNode(preOrder[index]);
            curIndx++;

            // If this is an internal node, construct left and right subtrees and link the subtrees
            if (preLN[index] == 'N')
            {
                cNode.LeftNode = BuildSpecialTree(preOrder, preLN, ref curIndx,  cNode.LeftNode);
                cNode.RightNode = BuildSpecialTree(preOrder, preLN, ref curIndx, cNode.RightNode);
            }

            return cNode;
        }

        // Medium 654 https://leetcode.com/submissions/detail/120667189/
        // Given an integer array with no duplicates, build A maximum tree building as follow: 
        // The root is the maximum number in the array. 
        // The left  subtree is the maximum tree constructed from left  part subarray divided by the maximum number.
        // The right subtree is the maximum tree constructed from right part subarray divided by the maximum number.
           
        // Construct the maximum tree by the given array and output the root node of this tree.
        // Example 1:
        // Input: [3,2,1,6,0,5]
        // Output: return the tree root node representing the following tree:
           
        //       6
        //     /   \
        //    3     5
        //     \    / 
        //      2  0   
        //        \
        //         1
           
        // Note:
        // The size of the given array will be in the range [1,1000].
        public TreeNode BuildMaximumBinaryTree(int[] nums)
        {
            return BuildMaximumBinaryTreeHelper(nums, 0, nums.Length - 1);
        }

        // maxIndex denotes the index of the maximum number in range [left, right]
        public TreeNode BuildMaximumBinaryTreeHelper(int[] nums, int lIndx, int rIndx)
        {
            if (lIndx > rIndx)
                return null;

            int maxIndx = lIndx;

            for (int indx = lIndx; indx <= rIndx; indx++)
            {
                if (nums[indx] > nums[maxIndx])
                    maxIndx = indx;
            }

            TreeNode root = new TreeNode(nums[maxIndx]);

            root.LeftNode = BuildMaximumBinaryTreeHelper(nums, lIndx, maxIndx - 1);
            root.RightNode = BuildMaximumBinaryTreeHelper(nums, maxIndx + 1, rIndx);

            return root;
        }

        // https://www.geeksforgeeks.org/construct-tree-from-ancestor-matrix/
        // Given an ancestor matrix mat[n][n] where Ancestor matrix is defined as below.
        // mat[i][j] = 1 if i is ancestor of j mat[i][j] = 0, otherwise
        //
        // Construct a Binary Tree from given ancestor matrix where all its values of nodes are from 0 to n-1.
        // 1. It may be assumed that the input provided the program is valid and tree can be constructed out of it.
        // 2. Many Binary trees can be constructed from one input. The program will construct any one of them. 
        //
        // Examples: 
        //      Input: 0 1 1
        //             0 0 0 
        //             0 0 0 
        //      Output: Root of one of the below trees.
        //          0                0
        //        /   \     OR     /   \
        //       1     2          2     1
        //
        //      Input: 0 0 0 0 0 0 
        //             1 0 0 0 1 0 
        //             0 0 0 1 0 0 
        //             0 0 0 0 0 0 
        //             0 0 0 0 0 0 
        //             1 1 1 1 1 0
        //      Output: Root of one of the below trees.
        //            5              5               5
        //         /    \           / \            /   \
        //        1      2   OR    2   1    OR    1     2  OR....
        //       /  \   /        /    /  \       / \    /
        //      0   4  3        3    0    4     4   0  3
        // There are different possible outputs because ancestor
        // matrix doesn't store that which child is left and which is right.

        // https://www.geeksforgeeks.org/construct-ancestor-matrix-from-a-given-binary-tree/
        //  Given a Binary Tree where all values are from 0 to n-1. Construct an ancestor matrix mat[n][n]. 
        // Ancestor matrix is defined as mat[i][j] = 1 if i is ancestor of j mat[i][j] = 0, otherwise
        //
        //      Examples:
        //      Input: Root of below Binary Tree.
        //                0
        //              /   \
        //             1     2
        //      Output: 0 1 1
        //              0 0 0 
        //              0 0 0 
        //
        //      Input: Root of below Binary Tree.
        //                 5
        //              /    \
        //             1      2
        //            /  \    /
        //           0    4  3
        //      Output: 0 0 0 0 0 0 
        //              1 0 0 0 1 0 
        //              0 0 0 1 0 0 
        //              0 0 0 0 0 0 
        //              0 0 0 0 0 0 
        //              1 1 1 1 1 0

        // https://www.geeksforgeeks.org/construct-a-binary-tree-from-parent-array-representation/

        // Given an array that represents a tree in such a way that array indexes are values in tree nodes and array values give the parent node of that particular index(or node). 
        // The value of the root node index would always be -1 as there is no parent for root.Construct the standard linked representation of given Binary Tree from this given representation.
        //  Input: parent[] = { 1, 5, 5, 2, 2, -1, 3}
        //  Output: root of below tree
        //            5
        //          /  \
        //         1    2
        //        /    / \
        //       0    3   4
        //           /
        //          6 
        //  Explanation: 
        //  Index of -1 is 5.  So 5 is root.
        //  5 is present at indexes 1 and 2.  So 1 and 2 are
        //  children of 5.  
        //  1 is present at index 0, so 0 is child of 1.
        //  2 is present at indexes 3 and 4.  So 3 and 4 are
        //  children of 2.  
        //  3 is present at index 6, so 6 is child of 3.
        //
        //  Input: parent[] = {-1, 0, 0, 1, 1, 3, 5};
        //  Output: root of below tree
        //           0
        //         /   \
        //        1     2
        //       / \
        //      3   4
        //     /
        //    5 
        //   /
        //  6

        // https://www.geeksforgeeks.org/inorder-tree-traversal-without-recursion-and-without-stack/
        // 1. Initialize current as root 
        // 2. While current is not NULL
        //    If current does not have left child
        //      a) Print current’s data
        //      b) Go to the right, i.e., current = current->right
        //    Else
        //      a) Make current as right child of the rightmost
        //         node in current's left subtree
        //      b) Go to this left child, i.e., current = current->left

        public void MorrisInOrderTraversal(TreeNode rootNode)
        {
            if (rootNode == null)
                return;

            TreeNode prevNode;
            TreeNode currentNode = rootNode;

            while (currentNode != null)
            {
                if (currentNode.LeftNode == null)
                {
                    Console.WriteLine(currentNode.NodeValue + " ");
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    prevNode = currentNode.LeftNode;

                    while (prevNode.RightNode != null && prevNode.RightNode != currentNode)
                    {
                        prevNode = prevNode.RightNode;
                    }

                    // Make current as right child of its inorder predecessor
                    if (prevNode.RightNode == null)
                    {
                        prevNode.RightNode = currentNode;
                        currentNode = currentNode.LeftNode;
                    }

                    // Revert the changes made in if part to restore the original tree i.e.,fix the right child of predecssor
                    else
                    {
                        prevNode.RightNode = null;
                        Console.WriteLine(currentNode.NodeValue + " ");

                        currentNode = currentNode.RightNode;
                    }
                }
            }
        }

        // https://www.geeksforgeeks.org/morris-traversal-for-preorder/
        // Preorder traversal without recursion and without stack
        // 1...If left child is null, print the current node data.Move to right child.
        // ….Else, Make the right child of the inorder predecessor point to the current node.Two cases arise:
        // ………a) The right child of the inorder predecessor already points to the current node.Set right child to NULL. Move to right child of current node.
        // ………b) The right child is NULL. Set it to current node. Print current node’s data and move to left child of current node.
        // 2...Iterate until current node is not NULL.
        public void MorrisTraversalPreOrder(TreeNode node)
        {
            while (node != null)
            {
                // If left child is null, print the current node data. Move to right child.
                if (node.LeftNode == null)
                {
                    Console.Write(node.NodeValue + " ");
                    node = node.RightNode;
                }
                else
                {
                    // Find inorder predecessor
                    TreeNode currNode = node.LeftNode;

                    while (currNode.RightNode != null && currNode.RightNode != node)
                    {
                        currNode = currNode.RightNode;
                    }

                    // If the right child of inorder predecessor already points to this node
                    if (currNode.RightNode == node)
                    {
                        currNode.RightNode = null;
                        node = node.RightNode;
                    }

                    // If right child doesn't point to this node, then print this
                    // node and make right child point to this node
                    else
                    {
                        Console.Write(node.NodeValue + " ");
                        currNode.RightNode = node;
                        node = node.LeftNode;
                    }
                }
            }
        }

        // https://www.geeksforgeeks.org/iterative-diagonal-traversal-binary-tree/
        // Iterative function to print diagonal view
        public void DiagonalPrint(TreeNode root)
        {
            // base case
            if (root == null)
                return;

            // inbuilt queue of Treenode
            Queue<TreeNode> tnQ = new Queue<TreeNode>();

            // push root
            tnQ.Enqueue(root);

            // push delimiter
            tnQ.Enqueue(null);

            while (tnQ.Count > 0)
            {
                TreeNode currNode = tnQ.Dequeue();

                // If current is delimiter then insert another for next diagonal and cout nextline
                if (currNode == null)
                {
                    if (tnQ.Count > 0)
                        return;

                    Console.WriteLine();

                    tnQ.Enqueue(null);
                }
                else
                {
                    while (currNode != null)
                    {
                        Console.Write(currNode.NodeValue + " ");

                        // if left child is present push into queue

                        if (currNode.LeftNode != null)
                            tnQ.Enqueue(currNode.LeftNode);

                        // current equals to right child
                        currNode = currNode.RightNode;
                    }
                }
            }
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

        // 366 Medium https://leetcode.com/problems/find-leaves-of-binary-tree
        // Given a binary tree, collect a tree's nodes as if you were doing this: Collect and remove all leaves, repeat until the tree is empty. 
        // Example:
        // Given binary tree 
        //           1
        //          / \
        //         2   3
        //        / \     
        //       4   5    

        // Returns[4, 5, 3], [2], [1]. 
        // Explanation:
        // 1. Removing the leaves[4, 5, 3] would result in this tree: 
        //           1
        //          / 
        //         2          

        // 2. Now removing the leaf[2] would result in this tree: 
        //           1             
        // 3. Now removing the leaf[1] would result in the empty tree: 
        //           []   
        //    Returns[4, 5, 3], [2], [1]. 

        // https://leetcode.com/problems/second-minimum-node-in-a-binary-tree

        //  Given a non-empty special binary tree consisting of nodes with the non-negative value, where each node in this tree has exactly two or zero sub-node.If the node has two sub-nodes, then this node's value is the smaller value among its two sub-nodes. 
        //  Given such a binary tree, you need to output the second minimum value in the set made of all the nodes' value in the whole tree. 
        //  If no such second minimum value exists, output -1 instead.
        //  Example 1:
        //  Input: 
        //      2
        //     / \
        //    2   5
        //       / \
        //      5   7
        //  Output: 5
        //  Explanation: The smallest value is 2, the second smallest value is 5.
        //  Example 2:
        //  Input: 
        //      2
        //     / \
        //    2   2
        //  Output: -1
        //  Explanation: The smallest value is 2, but there isn't any second smallest value.
        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null)
                return -1;

            int rootValue = root.NodeValue;
            int secondMinVal = int.MaxValue;

            Queue<TreeNode> tnQ = new Queue<TreeNode>();
            tnQ.Enqueue(root);

            while (tnQ.Count > 0)
            {
                TreeNode node = tnQ.Dequeue();

                if (node.NodeValue != rootValue && node.NodeValue < secondMinVal)
                {
                    secondMinVal = node.NodeValue;
                }

                if (node.LeftNode != null)
                {
                    if (node.LeftNode.NodeValue < secondMinVal)
                        tnQ.Enqueue(node.LeftNode);

                    if (node.RightNode.NodeValue < secondMinVal)
                        tnQ.Enqueue(node.RightNode);
                }
            }

            return secondMinVal == int.MaxValue ? -1 : secondMinVal;
        }
    }
}