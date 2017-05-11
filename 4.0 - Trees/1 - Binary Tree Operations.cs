using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    class BinaryTreeOperations
    {
        public TreeNode RootdNode;
        StringBuilder resultString;

        public string PreOrderDisplay()
        {
            resultString.Clear();
            PreOrderDisplayRecursion(RootdNode);
            return resultString.ToString();
        }

        private void PreOrderDisplayRecursion(TreeNode currentNode)
        {
            if (currentNode == null)
                return;

            resultString.Append("   " + currentNode.NodeValue);
            PreOrderDisplayRecursion(currentNode.LeftNode);
            PreOrderDisplayRecursion(currentNode.RightNode);
        }

        public string InOrderDisplay()
        {
            resultString.Clear();
            InOrderDisplayRecursion(RootdNode);
            return resultString.ToString();
        }

        private void InOrderDisplayRecursion(TreeNode currentNode)
        {
            if (currentNode == null)
                return;

            InOrderDisplayRecursion(currentNode.LeftNode);
            resultString.Append("   " + currentNode.NodeValue);
            InOrderDisplayRecursion(currentNode.RightNode);
        }

        public string PostOrderDisplay()
        {
            resultString.Clear();
            PostOrderDisplayRecursion(RootdNode);
            return resultString.ToString();
        }

        private void PostOrderDisplayRecursion(TreeNode currentNode)
        {
            if (currentNode != null)
                return;

            PostOrderDisplayRecursion(currentNode.LeftNode);
            PostOrderDisplayRecursion(currentNode.RightNode);
            resultString.Append("  " + currentNode.NodeValue);
        }

        public bool IsSymmetricRecursive(TreeNode root)
        {
            if (root == null)
                return true;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root.LeftNode);
            stack.Push(root.RightNode);

            while (stack.Count() > 0)
            {
                TreeNode n1Left = stack.Pop();
                TreeNode n2Left = stack.Pop();

                if (n1Left == null && n2Left == null)
                    continue;

                if (n1Left == null || n2Left == null || n1Left.NodeValue != n2Left.NodeValue)
                    return false;

                stack.Push(n1Left.LeftNode);
                stack.Push(n2Left.RightNode);

                stack.Push(n1Left.RightNode);
                stack.Push(n2Left.LeftNode);
            }

            return true;
        }

        // Mirror image of itself 
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;

            return isSymmetricHelp(root.LeftNode, root.RightNode);
        }

        private bool isSymmetricHelp(TreeNode t1, TreeNode t2)
        {

            if (t1 == null || t2 == null)
                return t1 == t2;

            else if (t1.NodeValue != t2.NodeValue)
                return false;

            return isSymmetricHelp(t1.LeftNode, t2.RightNode) && isSymmetricHelp(t1.RightNode, t2.LeftNode);
        }

        int maxVal = int.MinValue;

        /*
        For each node there can be four ways that the max path goes through the node:
         1. Node only
         2. Max path through Left Child + Node
         3. Max path through Right Child + Node
         4. Max path through Left Child + Node + Max path through Right Child

        The idea is to keep trace of four paths and pick up the max one in the end. 
        An important thing to note is, root of every subtree need to return maximum path sum such that at most one child of root is involved. 
        This is needed for parent function call. In below code, this sum is stored in ‘max_single’ and returned by the recursive function.
        */

        // Refer MaxPathSum.png for e.g.
        public int MaxPathSum(TreeNode node)
        {
            if (node == null)
                return 0;
            FindMaxVal(node);
            return maxVal;
        }

        private int FindMaxVal(TreeNode node)
        {
            if (node == null)
                return 0;
            int left = Math.Max(0, FindMaxVal(node.LeftNode));
            int right = Math.Max(0, FindMaxVal(node.RightNode));
            int curMaxSum = left + right + node.NodeValue;

            // Keep cummulate & calculate the max Value.
            maxVal = Math.Max(maxVal, curMaxSum);

            // Calculate left and right max values by considering max of left and right + current node val.
            return Math.Max(left, right) + node.NodeValue;
        }

        /*  Given the below binary tree and sum = 22,               
                  5
                 / \
                4   8
               /   / \
              11  13  4
             /  \      \
            7    2      1

        Return true, as there exist a root-to-leaf path 5 -> 4 -> 11 -> 2 which sum is 22.

         */

        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
                return false;

            if (root.LeftNode == null && root.RightNode == null && sum == root.NodeValue)
                return true;

            return HasPathSum(root.LeftNode, sum - root.NodeValue) || HasPathSum(root.RightNode, sum - root.NodeValue);
        }

        /*  Given a binary tree, return all root-to-leaf paths.  E.g. Given the following binary tree: 

           1
         /   \
        2     3
         \
          5

            All root-to-leaf paths are:  ["1->2->5", "1->3"]
        */

        IList<string> paths = new List<string>();

        public IList<string> BinaryTreePaths(TreeNode node)
        {
            if (node == null)
                return paths;
            paths = new List<string>();
            binaryTreePaths(node, string.Empty);

            return paths;
        }
        // TODO: Need to use string builder so that we can recreating string on every string append.

        private void binaryTreePaths(TreeNode node, string path)
        {
            if (node == null)
                return;

            path += node.NodeValue;

            if (node.LeftNode == null && node.RightNode == null)
                paths.Add(path);

            path += "->";

            binaryTreePaths(node.LeftNode, path);
            binaryTreePaths(node.RightNode, path);
        }

        public TreeNode LowestCommonAncestor(TreeNode node, TreeNode p, TreeNode q)
        {
            if (node == null)
                return null;

            // Ensure we compare nodes, not node values as duplicate values might exists.
            if (node == p || node == q)
                return node;

            TreeNode leftParent = LowestCommonAncestor(node.LeftNode, p, q);
            TreeNode rightParent = LowestCommonAncestor(node.RightNode, p, q);

            // TODO: Add a foundflag so that we can skip tree traversal after finding the LCA.        
            if (leftParent != null && rightParent != null)
                return node;
            else if (leftParent != null)
                return leftParent;
            else
                return rightParent;
        }

        public bool IsValidSerialization(string preorderStr)
        {
            string[] nodesList = preorderStr.Split(',');

            if (nodesList.Length == 0)
                return true;

            if (nodesList.Length == 1)
            {
                if (nodesList[0].Equals("#"))
                    return true;
                else
                    return false;
            }

            int index = 0;

            bool traverseResult = ValidatePreOrder(nodesList, ref index);

            // If the traversal failed or skipped in middle then return false else return true.
            return traverseResult && (index == nodesList.Length);
        }

        private bool ValidatePreOrder(string[] nodesList, ref int index)
        {
            if (index == nodesList.Length)
                return true;

            if (nodesList[index].Equals("#"))
            {
                index++;
                return true;
            }

            index++;

            // If it reached here and finished traversal then we found a parent without left/right child beigh #.
            if (index == nodesList.Length)
                return false;

            bool leftVisitResult = ValidatePreOrder(nodesList, ref index);

            // Before visiting right if the traversal completed then its invalid. Valid traversal always ends with last right child being #.
            if (index == nodesList.Length)
                return false;

            bool rightVisitResult = ValidatePreOrder(nodesList, ref index);
            return leftVisitResult && rightVisitResult;
        }

        // Encodes a tree to a single string.
        public string Serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            preorderSerialize(root, sb);
            return sb.ToString().Trim(','); //remove trailing comma
        }

        void preorderSerialize(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("#,");
                return;
            }

            sb.Append(node.NodeValue);
            sb.Append(",");

            preorderSerialize(node.LeftNode, sb);
            preorderSerialize(node.RightNode, sb);
        }

        TreeNode preorderDeserialize(string[] nodes, ref int pos)
        {
            if (nodes[pos] == "#")
            {
                pos++;
                return null;
            }

            TreeNode node = new TreeNode(int.Parse(nodes[pos++]));
            node.LeftNode = preorderDeserialize(nodes, ref pos);
            node.RightNode = preorderDeserialize(nodes, ref pos);
            return node;
        }

        // Decodes your encoded data to tree.
        public TreeNode Deserialize(string data)
        {
            int pos = 0;
            var tokens = data.Split(',');
            return preorderDeserialize(tokens, ref pos);
        }

        /*        public void helper(List<String> rst, StringBuilder sb, TreeNode root)
        {
            if (root == null) return;
            int tmp = sb.length();
            if (root.left == null && root.right == null)
            {
                sb.append(root.val);
                rst.add(sb.toString());
                sb.delete(tmp, sb.length());
                return;
            }
            sb.append(root.val + "->");
            helper(rst, sb, root.left);
            helper(rst, sb, root.right);
            sb.delete(tmp, sb.length());
            return;
        }*/

        //https://leetcode.com/problems/count-complete-tree-nodes/
        //https://discuss.leetcode.com/topic/54231/divide-and-conquer-binary-search-java-solution-beats-80-with-comments
        //https://discuss.leetcode.com/topic/31392/my-java-solution-with-explanation-which-beats-99 
        // Note: 1 << n does the similar to Math.Pow(2,n) << Move 32 bit integer left.

        // Solution only count when the root is not a perfect tree root, which saves half time each iteration, so it's log(n) solution
        public int CountNodesRecursive(TreeNode root)
        {

            int leftDepth = GetLeftDepth(root);
            int rightDepth = GetRightDepth(root);

            if (leftDepth == rightDepth)
                return (1 << leftDepth) - 1; // Or return Mat.Pow(2, leftDepth);
            else
                return 1 + CountNodesRecursive(root.LeftNode) + CountNodesRecursive(root.RightNode);

        }

        private int GetRightDepth(TreeNode root)
        {
            int depth = 0;
            while (root != null)
            {
                root = root.RightNode;
                depth++;
            }
            return depth;
        }

        private int GetLeftDepth(TreeNode root)
        {
            int depth = 0;
            while (root != null)
            {
                root = root.LeftNode;
                depth++;
            }
            return depth;
        }
        /*
        1st we need to find the height of the binary tree and count the nodes above the last level.
        Then we should find a way to count the nodes on the last level.

        Use binary search and define the "midNode" of the last level as a node following the path "root->left->right->right->...->last level".
        If midNode is null, then it means we should count the nodes on the last level in the left subtree.
        If midNode is not null, then we add half of the last level nodes to our result and then count the nodes on the last level in the right subtree.
        */

        public int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            if (root.LeftNode == null)
                return 1;

            int height = 0;
            int nodesCount = 0;
            TreeNode curr = root;

            while (curr.LeftNode != null)
            {
                nodesCount += (1 << height);
                height++;
                curr = curr.LeftNode;
            }

            return nodesCount + CountLastLevel(root, height);
        }

        private int CountLastLevel(TreeNode root, int height)
        {
            if (height == 1)
            {
                if (root.RightNode != null)
                    return 2;
                else if (root.LeftNode != null)
                    return 1;
                else
                    return 0;
            }

            TreeNode midNode = root.LeftNode;
            int currHeight = 1;

            while (currHeight < height)
            {
                currHeight++;
                midNode = midNode.RightNode;
            }

            if (midNode == null)
                return CountLastLevel(root.LeftNode, height - 1);

            else
                return (1 << (height - 1)) + CountLastLevel(root.RightNode, height - 1);
        }

        /*
         Visit nodes from right to left in DFS. 
         E.g.       6
                4        8
            3       5       9
        1       2
        Return: 6
                8,4
                9,8,3
                2,1
         */
        public IList<int> RightSideViewIterative(TreeNode root)
        {
            List<int> result = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            if (root == null) return result;

            queue.Enqueue(root);

            while (queue.Count() != 0)
            {
                int size = queue.Count();

                for (int levelCnt = 0; levelCnt < size; levelCnt++)
                {
                    TreeNode cur = queue.Dequeue();

                    if (levelCnt == 0)
                        result.Add(cur.NodeValue);

                    if (cur.RightNode != null)
                        queue.Enqueue(cur.RightNode);

                    if (cur.LeftNode != null)
                        queue.Enqueue(cur.LeftNode);
                }
            }
            return result;
        }

        public List<int> RightSideViewRecursive(TreeNode root)
        {
            List<int> result = new List<int>();
            rightView(root, result, 0);
            return result;
        }

        public void rightView(TreeNode curr, List<int> result, int currDepth)
        {
            if (curr == null)
                return;

            if (currDepth == result.Count())
                result.Add(curr.NodeValue);

            rightView(curr.RightNode, result, currDepth + 1);
            rightView(curr.LeftNode, result, currDepth + 1);
        }

        /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
        public class Solution
        {
            public TreeNode BuildTreeFromPreAndInOrder(int[] preorder, int[] inorder)
            {
                return buildTree(preorder, inorder, 0, 0, inorder.Length - 1 );
            }

            public TreeNode buildTree(int[] preorder, int[] inorder, int preOrderRootPos, int inStart, int inEnd)
            {
                if (preOrderRootPos > preorder.Length - 1 || inStart > inEnd)
                    return null;

                TreeNode rootNode = new TreeNode(preorder[preOrderRootPos]);

                int inRootIndex = 0;

                for (int lpCnt = inStart; lpCnt <= inEnd; lpCnt++)
                {
                    if (inorder[lpCnt] == rootNode.NodeValue)
                    {
                        inRootIndex = lpCnt;
                        break;
                    }
                }

                rootNode.LeftNode = buildTree(preorder, inorder,  preOrderRootPos + 1, inStart, inRootIndex - 1);

                int preOrderRightRootPos = preOrderRootPos + (inRootIndex - inStart) + 1;
                rootNode.RightNode = buildTree(preorder, inorder, preOrderRightRootPos, inRootIndex + 1, inEnd);

                return rootNode;
            }
        }

        public TreeNode BuildTreeFromInOrderAndPostOrder(int[] inorder, int[] postorder)
        {
            return build(inorder, postorder, 0, inorder.Length - 1, postorder.Length - 1);
        }

        private TreeNode build(int[] inorder, int[] postorder, int inStart, int inEnd, int postStart)
        {
            if (inStart > inEnd)
                return null;

            TreeNode root = new TreeNode(postorder[postStart]);

            if (inEnd == inStart)
                return root;

            int inOrdRootPos = 0;

            for (inOrdRootPos = inEnd; inOrdRootPos >= inStart; inOrdRootPos--)
                if (inorder[inOrdRootPos] == root.NodeValue)
                    break;

            root.RightNode = build(inorder, postorder, inOrdRootPos + 1, inEnd, postStart - 1);
            int postOrderRightRootPos = postStart - (inEnd - inOrdRootPos) - 1;
            root.LeftNode = build(inorder, postorder, inStart, inOrdRootPos - 1, postOrderRightRootPos);

            return root;
        }
        private TreeNode BuildTree(int[] inorder, int[] postorder, TreeNode endNode, ref int inOrderPos, ref int postOrderPos)
        {
            if (postOrderPos < 0)
                return null;

            TreeNode currentNode = new TreeNode(postorder[postOrderPos]);
            postOrderPos--;

            // if right node exist, create right subtree
            if (inorder[inOrderPos] != currentNode.NodeValue)
                currentNode.RightNode = BuildTree(inorder, postorder, currentNode, ref inOrderPos, ref postOrderPos);

            inOrderPos--;

            // if left node exist, create left subtree
            if ((endNode == null) || (inorder[inOrderPos] != endNode.NodeValue))
                currentNode.LeftNode = BuildTree(inorder, postorder, endNode, ref inOrderPos, ref postOrderPos);

            return currentNode;
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            int inOrderPos = inorder.Length - 1;
            int postOrderPos = postorder.Length - 1;

            return BuildTree(inorder, postorder, null, ref inOrderPos, ref postOrderPos);
        }
    }
}
