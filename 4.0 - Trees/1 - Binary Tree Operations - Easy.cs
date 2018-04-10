using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public partial class BinaryTreeOperations
    {
        public TreeNode RootdNode;
        StringBuilder resultString = new StringBuilder();

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

        public bool NewMirrorTreeRecursive(TreeNode root)
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

        // For each node there can be four ways that the max path goes through the node:
        //  1. Node only
        //  2. Max path through Left Child + Node
        //  3. Max path through Right Child + Node
        //  4. Max path through Left Child + Node + Max path through Right Child
           
        // The idea is to keep trace of four paths and pick up the max one in the end. 
        // An important thing to note is, root of every subtree need to return maximum path sum such that at most one child of root is involved. 
        // This is needed for parent function call. In below code, this sum is stored in ‘max_single’ and returned by the recursive function.

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

        // 112 Easy https://leetcode.com/problems/path-sum
        // Given the below binary tree and sum = 22,               
        //           5
        //          / \
        //         4   8
        //        /   / \
        //       11  13  4
        //      /  \      \
        //     7    2      1

        // Return true, as there exist a root-to-leaf path 5 -> 4 -> 11 -> 2 which sum is 22.

        public bool HasPathSum(TreeNode root, int sum)
        {
            Stack<TreeNode> itemsStack = new Stack<TreeNode>();

            if (root == null)
                return false;

            TreeNode lastVisited = null;
            int rSum = 0;

            while (itemsStack.Count() > 0 || root != null)
            {
                while (root != null)
                {
                    itemsStack.Push(root);
                    rSum += root.NodeValue;
                    root = root.LeftNode;
                }

                root = itemsStack.Peek();

                if (root.LeftNode == null && root.RightNode == null && rSum == sum)
                    return true;

                else if (root.RightNode != null && root.RightNode != lastVisited)
                {
                    root = root.RightNode;
                }
                else
                {
                    lastVisited = root;
                    rSum -= root.NodeValue;
                    itemsStack.Pop();
                    root = null;
                }
            }

            return false;
        }

        // LC 113 https://leetcode.com/problems/path-sum-ii
        // Iterative Post Order Traversal Approach. 

        public List<List<int>> PathSumIterative(TreeNode root, int sum)
        {
            List<int> pathList = new List<int>();
            List<List<int>> resList = new List<List<int>>();

            Stack<TreeNode> stack = new Stack<TreeNode>();

            int currSum = 0;
            TreeNode curNode = root;
            TreeNode prevNode = null;

            while (curNode != null || stack.Count > 0)
            {
                while (curNode != null)
                {
                    stack.Push(curNode);
                    pathList.Add(curNode.NodeValue);

                    currSum = currSum + curNode.NodeValue;
                    curNode = curNode.LeftNode;
                }

                curNode = stack.Peek();

                if (curNode.RightNode != null && curNode.RightNode != prevNode)
                {
                    curNode = curNode.RightNode;
                    continue;
                }

                if (curNode.LeftNode == null && curNode.RightNode == null && currSum == sum)
                {
                    resList.Add(new List<int>(pathList));
                }

                stack.Pop();
                currSum = currSum - curNode.NodeValue;

                prevNode = curNode;
                curNode = null;

                pathList.RemoveAt(pathList.Count() - 1);
            }
            return resList;
        }

        // https://leetcode.com/problems/path-sum-iii/
        int count = 0;

        public int PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return 0;
            count = 0;

            Queue<TreeNode> tnQ = new Queue<TreeNode>();
            tnQ.Enqueue(root);

            TreeNode currNode;

            while (tnQ.Count > 0)
            {
                currNode = tnQ.Dequeue();

                PathSumDfsHelper(currNode, sum);

                if (currNode.LeftNode != null)
                    tnQ.Enqueue(currNode.LeftNode);

                if (currNode.RightNode != null)
                    tnQ.Enqueue(currNode.RightNode);
            }

            return count;
        }

        private void PathSumDfsHelper(TreeNode node, int sum)
        {
            if (node.NodeValue == sum)
            {
                count++;
            }

            if (node.LeftNode != null)
                PathSumDfsHelper(node.LeftNode, sum - node.NodeValue);

            if (node.RightNode != null)
                PathSumDfsHelper(node.RightNode, sum - node.NodeValue);
        }

        // 257 Easy https://leetcode.com/problems/binary-tree-paths
        // Given a binary tree, return all root-to-leaf paths.  E.g. Given the following binary tree: 
        //    1
        //  /   \
        // 2     3
        //  \
        //   5
        // All root-to-leaf paths are:  ["1->2->5", "1->3"]

        IList<string> paths = new List<string>();

        public IList<string> BinaryTreePaths(TreeNode node)
        {
            if (node == null)
                return paths;
            paths = new List<string>();
            BinaryTreePathsHelper(node, string.Empty);

            return paths;
        }

        private void BinaryTreePathsHelper(TreeNode node, string path)
        {
            if (node == null)
                return;

            path += node.NodeValue;

            if (node.LeftNode == null && node.RightNode == null)
                paths.Add(path);

            path += "->";

            BinaryTreePathsHelper(node.LeftNode, path);
            BinaryTreePathsHelper(node.RightNode, path);
        }

        // Not space efficient
        public List<String> BinaryTreePathsIteration1(TreeNode currNode)
        {
            Queue<TreeNode> nodesQ = new Queue<TreeNode>();
            Queue<String> strQ = new Queue<string>();
            List<String> resultList = new List<string>();

            if (currNode != null)
            {
                nodesQ.Enqueue(currNode);
                strQ.Enqueue(currNode.NodeValue.ToString());
            }

            while (!nodesQ.Any())
            {
                TreeNode node = nodesQ.Dequeue();

                if (node.LeftNode == null && node.RightNode == null)
                {
                    resultList.Add(strQ.Dequeue());
                }
                else
                {
                    String newStr = strQ.Dequeue();

                    if (node.LeftNode != null)
                    {
                        nodesQ.Enqueue(node.LeftNode);
                        strQ.Enqueue(newStr + "->" + node.LeftNode.NodeValue);
                    }
                    if (node.RightNode != null)
                    {
                        nodesQ.Enqueue(node.RightNode);
                        strQ.Enqueue(newStr + "->" + node.RightNode.NodeValue);
                    }
                }
            }
            return resultList;
        }

        // TODO Time limit exceeded
        public List<String> BinaryTreePathsIteration(TreeNode currNode)
        {
            Stack<TreeNode> nStack = new Stack<TreeNode>();
            List<String> resultList = new List<string>();
            List<String> valsList = new List<string>();
           
            TreeNode prevNode = null;

            if (currNode == null)
                return null;

            nStack.Push(currNode);

            while (!nStack.Any() || currNode != null)
            {
                while (currNode != null)
                {
                    nStack.Push(currNode);
                    valsList.Add(currNode.NodeValue.ToString());

                    currNode = currNode.LeftNode;
                }

                TreeNode tNode = nStack.Peek();

                if (tNode.RightNode != null && tNode.RightNode != prevNode)
                {
                    currNode = tNode.RightNode;
                    prevNode = currNode;
                    continue;
                }

                if (tNode.LeftNode == null && tNode.RightNode == null)
                {
                    StringBuilder strNodes = new StringBuilder();
                    strNodes.Append(valsList[0]);

                    for (int indx = 1; indx< valsList.Count; indx++)
                    {
                        strNodes.Append("->" + valsList[indx]);
                    }

                    resultList.Add(strNodes.ToString());
                }

                currNode = nStack.Pop();

                if (valsList.Count > 0)
                    valsList.RemoveAt(valsList.Count - 1);
            }

            return resultList;
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

        public TreeNode LowestCommonAncestorItr(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            Dictionary<TreeNode, TreeNode> childParentMap = new Dictionary<TreeNode, TreeNode>();
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            childParentMap.Add(root, null);
            nodeStack.Push(root);

            while (!childParentMap.ContainsKey(p) || !childParentMap.ContainsKey(q))
            {
                var node = nodeStack.Pop();
                if (node.LeftNode != null)
                {
                    childParentMap.Add(node.LeftNode, node);
                    nodeStack.Push(node.LeftNode);
                }

                if (node.RightNode != null)
                {
                    childParentMap.Add(node.RightNode, node);
                    nodeStack.Push(node.RightNode);
                }
            }

            HashSet<TreeNode> ancestors = new HashSet<TreeNode>();
            while (p != null)
            {
                ancestors.Add(p);
                p = childParentMap[p];
            }

            while (!ancestors.Contains(q))
            {
                q = childParentMap[q];
            }

            return q;
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

        //  226 Easy https://leetcode.com/problems/invert-binary-tree
        //  Invert a binary tree.
        //      4
        //    /   \
        //   2     7
        //  / \   / \
        // 1   3 6   9
        //  Output:
        //      4
        //    /   \
        //   7     2
        //  / \   / \
        // 9   6 3   1

        public TreeNode InvertTreeStack(TreeNode currentNode)
        {
            if (currentNode == null)
                return null;

            Stack<TreeNode> tnStack = new Stack<TreeNode>();
            tnStack.Push(currentNode);

            while (tnStack.Count > 0)
            {
                TreeNode node = tnStack.Pop();

                TreeNode temp = node.LeftNode;
                node.LeftNode = node.RightNode;
                node.RightNode = temp;

                if (node.LeftNode != null)
                    tnStack.Push(node.LeftNode);
                if (node.RightNode != null)
                    tnStack.Push(node.RightNode);
            }

            return currentNode;
        }

        public TreeNode InvertTreeQueue(TreeNode root)
        {
            if (root == null)
                return null;

            Queue<TreeNode> tnQ = new Queue<TreeNode>();

            tnQ.Enqueue(root);

            while (tnQ.Count > 0)
            {
                TreeNode current = tnQ.Dequeue();

                TreeNode temp = current.LeftNode;
                current.LeftNode = current.RightNode;
                current.RightNode = temp;

                if (current.LeftNode != null)
                    tnQ.Enqueue(current.LeftNode);

                if (current.RightNode != null)
                    tnQ.Enqueue(current.RightNode);
            }

            return root;
        }

        public TreeNode InvertTreeRecur(TreeNode root)
        {
            if (root == null)
                return null;

            TreeNode temp = root.LeftNode;
            root.LeftNode = root.RightNode;
            root.RightNode = temp;

            InvertTreeRecur(root.LeftNode);
            InvertTreeRecur(root.RightNode);

            return root;
        }

        // Encodes a tree to a single string.
        public string Serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            PreorderSerialize(root, sb);
            return sb.ToString().Trim(','); //remove trailing comma
        }

        public void PreorderSerialize(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("#,");
                return;
            }

            sb.Append(node.NodeValue);
            sb.Append(",");

            PreorderSerialize(node.LeftNode, sb);
            PreorderSerialize(node.RightNode, sb);
        }

        TreeNode PreorderDeserialize(string[] nodes, ref int pos)
        {
            if (nodes[pos] == "#")
            {
                pos++;
                return null;
            }

            TreeNode node = new TreeNode(int.Parse(nodes[pos++]));
            node.LeftNode = PreorderDeserialize(nodes, ref pos);
            node.RightNode = PreorderDeserialize(nodes, ref pos);
            return node;
        }

        // Decodes your encoded data to tree.
        public TreeNode Deserialize(string data)
        {
            int pos = 0;
            var tokens = data.Split(',');
            return PreorderDeserialize(tokens, ref pos);
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
        // Note: 1 << n does the similar to Math.Pow(2,n) << Move 32 bit int left.

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
        // 199 https://leetcode.com/problems/binary-tree-right-side-view
        public IList<int> RightSideViewIterative(TreeNode root)
        {
            List<int> result = new List<int>();
            Queue<TreeNode> tnQ = new Queue<TreeNode>();

            if (root == null)
                return result;

            tnQ.Enqueue(root);

            while (tnQ.Count() != 0)
            {
                int nodesInLevel = tnQ.Count();

                for (int index = 0; index < nodesInLevel; index++)
                {
                    TreeNode cur = tnQ.Dequeue();

                    if (index == 0)
                        result.Add(cur.NodeValue);

                    if (cur.RightNode != null)
                        tnQ.Enqueue(cur.RightNode);

                    if (cur.LeftNode != null)
                        tnQ.Enqueue(cur.LeftNode);
                }
            }
            return result;
        }

        public List<int> RightSideViewRecursive(TreeNode root)
        {
            List<int> result = new List<int>();
            RightView(root, result, 0);
            return result;
        }

        public void RightView(TreeNode curr, List<int> result, int currDepth)
        {
            if (curr == null)
                return;

            if (currDepth == result.Count())
                result.Add(curr.NodeValue);

            RightView(curr.RightNode, result, currDepth + 1);
            RightView(curr.LeftNode, result, currDepth + 1);
        }

        // https://leetcode.com/problems/maximum-depth-of-binary-tree

        // Given a binary tree, find its maximum depth.
        // The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
        // E.g:
        // Given binary tree[3, 9, 20, null, null, 15, 7],
        //     3
        //    / \
        //   9  20
        //     /  \
        //    15   7
        // return its depth = 3.

        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            int maxDepth = 0;
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                for (int curCount = queue.Count; curCount > 0; curCount--)
                {
                    TreeNode cur = queue.Dequeue();

                    if (cur.LeftNode != null)
                        queue.Enqueue(cur.LeftNode);

                    if (cur.RightNode != null)
                        queue.Enqueue(cur.RightNode);
                }
                maxDepth++;
            }
            return maxDepth;
        }

        public int MinDepth(TreeNode rootNode)
        {
            if (rootNode == null)
                return 0;

            int levelCnt = 0;

            Queue<TreeNode> prntQ = new Queue<TreeNode>();
            Queue<TreeNode> lvlQ = new Queue<TreeNode>();

            prntQ.Enqueue(rootNode);

            while (prntQ.Count > 0)
            {
                TreeNode currNode = prntQ.Dequeue();

                if (currNode.LeftNode == null && currNode.RightNode == null)
                    return ++levelCnt;

                if (currNode.LeftNode != null)
                    lvlQ.Enqueue(currNode.LeftNode);

                if (currNode.RightNode != null)
                    lvlQ.Enqueue(currNode.RightNode);

                if (prntQ.Count == 0)
                {
                    prntQ = lvlQ;
                    lvlQ = new Queue<TreeNode>();
                    ++levelCnt;
                }
            }

            return -1;
        }

        // 543 Easy https://leetcode.com/problems/diameter-of-binary-tree
        // Given a binary tree, you need to compute the length of the diameter of the tree.
        // The diameter of a binary tree is the length of the longest path between any two nodes in a tree.
        // This path may or may not pass through the root.
        //
        // Example:
        // Given a binary tree 
        //           1
        //          / \
        //         2   3
        //        / \     
        //       4   5    
        //
        // Return 3, which is the length of the path[4, 2, 1, 3] or [5,2,1,3]. 
        // Note: The length of path between two nodes is represented by the number of edges between them. 

        public int DiameterOfBinaryTree(TreeNode root)
        {
            int maxDiameter = 0;
            MaxDiameterPostOrderHelper(root, ref maxDiameter);
            return maxDiameter;
        }

        public int MaxDiameterPostOrderHelper(TreeNode root, ref int maxDiameter) // Max Left Depth + Max Right Depth + 1
        {
            if (root == null)
                return 0;

            int lMxHeight = MaxDiameterPostOrderHelper(root.LeftNode, ref maxDiameter);
            int rMxHeight = MaxDiameterPostOrderHelper(root.RightNode, ref maxDiameter);

            maxDiameter = Math.Max(maxDiameter, lMxHeight + rMxHeight);

            return 1 + Math.Max(lMxHeight, rMxHeight);
        }

        public int MaxDiameter(TreeNode root) // Max Left Depth + Max Right Depth + 1
        {
            if (root == null)
                return 0;

            Stack<TreeNode> tnStack = new Stack<TreeNode>();
            tnStack.Push(root);

            int lMxHeight = 0;
            int lCrHeight = 0;
            int rMxHeight = 0;
            int rCrHeight = 0;
            int maxDiameter = 0;

            while (tnStack.Count > 0)
            {
                TreeNode treeNode = tnStack.Pop();

                while (treeNode.LeftNode != null)
                {
                    tnStack.Push(treeNode.LeftNode);
                    lCrHeight++;
                }

                lMxHeight = Math.Max(lMxHeight, lCrHeight);
                lCrHeight = 0;

                while (treeNode.RightNode != null)
                {
                    tnStack.Push(treeNode.RightNode);
                    rCrHeight++;
                }

                rMxHeight = Math.Max(rMxHeight, rCrHeight);
                rCrHeight = 0;

                maxDiameter = Math.Max(maxDiameter, lMxHeight + rMxHeight + 1);
            }

            //int lMxHeight = MaxDiameterPostOrderHelper(root.LeftNode, ref maxDiameter);
            //int rMxHeight = MaxDiameterPostOrderHelper(root.RightNode, ref maxDiameter);

            maxDiameter = Math.Max(maxDiameter, lMxHeight + rMxHeight);

            return 1 + Math.Max(lMxHeight, rMxHeight);
        }

        // 617 https://leetcode.com/problems/merge-two-binary-trees
        // Given two binary trees and imagine that when you put one of them to cover the other, some nodes of the two trees are overlapped while the others are not.
        // You need to merge them into a new binary tree.The merge rule is that if two nodes overlap, then sum node values up as the new value of the merged node.Otherwise, the NOT null node will be used as the node of new tree.
        // Example 1:
        // Input: 
        // 	Tree 1                     Tree 2                  
        //           1                         2                             
        //          / \                       / \                            
        //         3   2                     1   3                        
        //        /                           \   \                      
        //       5                             4   7                  
        // Output: 
        // Merged tree:
        // 	     3
        // 	    / \
        // 	   4   5
        // 	  / \   \ 
        // 	 5   4   7

        // Note: The merging process must start from the root nodes of both trees.

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;

            if (t2 == null)
                return t1;

            Queue<TreeNode[]> tQ = new Queue<TreeNode[]>();

            tQ.Enqueue(new TreeNode[] { t1, t2 });

            while (tQ.Count() > 0)
            {
                TreeNode[] nodes = tQ.Dequeue();

                // If right tree has a null value for a node, then we dont need to change anything in the left tree
                if (nodes[1] == null)
                    continue;

                nodes[0].NodeValue += nodes[1].NodeValue; // Since the node exists in the right tree, lets add it to the left tree

                // If left node of 1st tree is null, then we just point to the left node of the 2nd tree

                if (nodes[0].LeftNode == null)
                {
                    nodes[0].LeftNode = nodes[1].LeftNode;
                }
                else
                {
                    tQ.Enqueue(new TreeNode[] { nodes[0].LeftNode, nodes[1].LeftNode });
                }

                // If right node of 1st tree is null, then we just point to the right node of the 2nd tree
                if (nodes[0].RightNode == null)
                {
                    nodes[0].RightNode = nodes[1].RightNode;
                }
                else
                {
                    tQ.Enqueue(new TreeNode[] { nodes[0].RightNode, nodes[1].RightNode });
                }
            }

            // Return t1, as we have been updating the nodes of t1 instead of creating a new tree
            return t1;
        }

        // 637. Easy https://leetcode.com/problems/average-of-levels-in-binary-tree/

        // Given a non-empty binary tree, return the average value of the nodes on each level in the form of an array.
        // Example 1:
        // Input:
        //     3
        //    / \
        //   9  20
        //     /  \
        //    15   7
        // Output: [3, 14.5, 11]
        //         Explanation:
        // The average value of nodes on level 0 is 3,  on level 1 is 14.5, and on level 2 is 11. Hence return [3, 14.5, 11].

        // Note:
        // The range of node's value is in the range of 32-bit signed int.

        public List<Double> AverageOfLevels(TreeNode root)
        {
            if (root == null)
                return null;

            List<Double> list = new List<double>();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count() > 0)
            {
                int nodeCnt = queue.Count();

                double sum = 0;

                for (int indx = 0; indx < nodeCnt; indx++)
                {
                    TreeNode cur = queue.Dequeue();
                    sum += cur.NodeValue;

                    if (cur.LeftNode != null)
                        queue.Enqueue(cur.LeftNode);

                    if (cur.RightNode != null)
                        queue.Enqueue(cur.RightNode);
                }

                list.Add(sum / nodeCnt);
            }

            return list;
        }

        public int FindTilt(TreeNode root)
        {
            int result = 0;
            PostOrderRecursive(root, ref result);
            return result;
        }

        // 563 https://leetcode.com/problems/binary-tree-tilt
        private int PostOrderRecursive(TreeNode root, ref int result)
        {
            if (root == null)
                return 0;

            int left = PostOrderRecursive(root.LeftNode, ref result);
            int right = PostOrderRecursive(root.RightNode, ref result);

            result += Math.Abs(left - right);

            return left + right + root.NodeValue;
        }

        // 501 Easy https://leetcode.com/problems/find-mode-in-binary-search-tree
        //        Given a binary search tree(BST) with duplicates, find all the mode(s) (the most frequently occurred element) in the given BST.
        //Assume a BST is defined as follows: 
        //The left subtree of a node contains only nodes with keys less than or equal to the node's key.
        //The right subtree of a node contains only nodes with keys greater than or equal to the node's key.
        //Both the left and right subtrees must also be binary search trees.

        //For example:
        //Given BST [1,null,2,2],
        //   1
        //    \
        //     2
        //    /
        //   2

        //return [2]. 
        //Note: If a tree has more than one mode, you can return them in any order. 
        //Follow up: Could you do that without using any extra space? (Assume that the implicit stack space incurred due to recursion does not count). 
        int prev = 0;
        int max = 0;

        public int[] FindMode(TreeNode root)
        {
            if (root == null)
                return new int[0];
            int count = 1;

            List<int> list = new List<int>();

            TraverseRecursive(root, list, ref count);

            int[] res = new int[list.Count()];

            for (int indx = 0; indx < list.Count(); ++indx)
                res[indx] = list[indx];

            return res;
        }

        private void TraverseRecursive(TreeNode root, List<int> list, ref int count)
        {
            if (root == null)
                return;

            TraverseRecursive(root.LeftNode, list, ref count);

            if (prev != null)
            {
                if (root.NodeValue == prev)
                    count++;
                else
                    count = 1;
            }

            if (count > max)
            {
                max = count;
                list.Clear();
                list.Add(root.NodeValue);
            }
            else if (count == max)
            {
                list.Add(root.NodeValue);
            }

            prev = root.NodeValue;

            TraverseRecursive(root.RightNode, list, ref count);
        }

        // Easy 110 https://leetcode.com/problems/balanced-binary-tree
        // Given a binary tree, determine if it is height-balanced.
        // For this problem, a height-balanced binary tree is defined as:
        // a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        // Example 1:
        // Given the following tree [3,9,20,null,null,15,7]:
        //     3
        //    / \
        //   9  20
        //     /  \
        //    15   7
        // Return true.

        // Example 2:
        // Given the following tree [1,2,2,3,3,null,null,4,4]:
        //        1
        //       / \
        //      2   2
        //     / \
        //    3   3
        //   / \
        //  4   4
        // Return false.
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            Dictionary<TreeNode, int> nodesDict = new Dictionary<TreeNode, int>();

            stack.Push(root);

            while (stack.Count >0)
            {
                TreeNode node = stack.Pop();

                if ((node.LeftNode == null || node.LeftNode != null && nodesDict.ContainsKey(node.LeftNode)) && 
                    (node.RightNode == null || node.RightNode != null && nodesDict.ContainsKey(node.RightNode)))
                {
                    int leftLen = node.LeftNode == null ? 0 : nodesDict[node.LeftNode];
                    int rightLen = node.RightNode == null ? 0 : nodesDict[node.RightNode];

                    if (Math.Abs(leftLen - rightLen) > 1)
                        return false;

                    nodesDict[node] = Math.Max(leftLen, rightLen) + 1;
                }
                else
                {
                    if (node.LeftNode != null && nodesDict.ContainsKey(node.LeftNode) == false)
                    {
                        stack.Push(node);
                        stack.Push(node.LeftNode);
                    }
                    else
                    {
                        stack.Push(node);
                        stack.Push(node.RightNode);
                    }
                }
            }

            return true;
        }
    }
}