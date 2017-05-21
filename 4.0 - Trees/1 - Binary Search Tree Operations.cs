using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.potiori.com/Balanced_binary_search_tree.html
    ============================================================================================================================================================================================================================
    
    Root            - the top most node in a tree.
    Parent          - the converse notion of child.
    Siblings        - nodes with the same parent.
    Descendant      - a node reachable by repeated proceeding from parent to child.
    Leaf            - a node with no children.
    Internal node   - a node with at least one child.
    Degree          - number of sub trees of a node.
    Edge            - connection between one node to another.
    Path            - a sequence of nodes and edges connecting a node with a descendant.
    Level           - The level of a node is defined by 1 + the number of connections between the node and the root.
    Height          - The height of a node is the length of the longest downward path between the node and a leaf.
    Forest          - A forest is a set of n ≥ 0 disjoint trees.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Demo Tree Data 

                   F
                /     \
             /           \
            B               G
          /   \               \
        A       D               I
              /   \            /
            C       E         H

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                 6                  Depth - 0 Height - 3
                /  \
               /    \ 
              /      \
             /        \
            2          7            Depth - 1 Height - 2
           /  \         \  
         1     4        9           Depth - 2 Height - 1
              / \      /            
            3     5   8             Depth - 3 Height - 0


    Depth of Tree : Number of edges/arcs from the Root node to the Leaf node of the tree is called as the Depth of the Tree. 
    Depth of Node : Number of edges/arcs from the Root node to that node is called as the Depth of that node.
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Pre-order :  RtLR

    1.Visit the root.
    2.Traverse the left subtree.
    3.Traverse the right subtree.
    Pre-order traversal sequence:   F, B, A, D, C, E, G, I, H
                                    6, 2, 1, 4, 3, 5, 7, 9, 8
    In-order (symmetric) :   LRtR

    1.Traverse the left subtree.
    2.Visit the root.
    3.Traverse the right subtree.
    In-order traversal sequence:    A, B, C, D, E, F, G, H, I
                                    1, 2, 3, 4, 5, 6, 7, 8, 9
    Post-order :             LRRt

    1.Traverse the left subtree.
    2.Traverse the right subtree.
    3.Visit the root.
    Post-order traversal sequence:  A, C, E, D, B, H, I, G, F 
                                    1, 3, 5, 4, 2, 8, 9, 7, 6
    
    The traversal will visit every node on the left. 
    Once it reaches the last node on the left, it begins working its way back along the right-side nodes. 
    This is a depth-first search (DFS) traversal. As such, each node is visited only once, and the algorithm runs in O(n) time.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Binary Tree vs Binary Search Tree :

    Both has up to two childs/leaves.

    Binary tree         : The left child node and the right child node contains value which can be either greater, less, or equal to parent node.
    Binary Search Tree  : The left child contains nodes with values less than the parent node and where the right child only contains nodes with values greater than or equal to the parent.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    1. Balanced binary search trees are hard to implement.
    2. Rebalancing the tree after insert / delete is complex.
    3. Well known implementations of balanced binary search trees
        3.1 AVL trees – ideally balanced, very complex
        3.2 Red-black trees – roughly balanced, more simple
        3.3 AA-Trees – relatively simple to implement
    4. Find / insert / delete operations need log(n) steps

    B-trees are generalization of the concept of ordered binary search trees
B-tree of order d has between d and 2*d keys in a node and between d+1 and 2*d+1 child nodes
The keys in each node are ordered increasingly
All keys in a child node have values between their left and right parent keys
If the b-tree is balanced, its search / insert / add operations take about log(n) steps
B-trees can be efficiently stored on the disk

.NET Framework has several built-in implementations of balanced search trees:
SortedDictionary<K,V>
Red-black tree based map of key-value pairs
OrderedSet<T>
Red-black tree based set of elements
External libraries like "Wintellect Power Collections for .NET" are more flexible
http://powercollections.codeplex.com 



    89. Serialize and De serialize a given binary tree




    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Types Of BST's:

    1. Self Balancing Search Tree   - Is any node-based binary search tree that automatically keeps its height (maximal number of levels below the root) small in the face of arbitrary item insertions and deletions    
                                      http://en.wikipedia.org/wiki/Self-balancing_binary_search_tree

    2. AVL Tree                     - Is a type of SBST.
                                      In an AVL tree, the heights of the two child subtrees of any node differ by at most one; if at any time they differ by more than one, rebalancing is done to restore this property. 
                                      Lookup, insertion, and deletion all take O(log n) time in both the average and worst cases.
                                      http://en.wikipedia.org/wiki/AVL_tree

    3. Red-Black Tree               - Is a type of SBST.
                                      Balance is preserved by painting each node of the tree with one of two colors (typically called 'red' and 'black') in a way that satisfies certain properties, which collectively constrain how unbalanced the tree can become in the worst case. 
                                      When the tree is modified, the new tree is subsequently rearranged and repainted to restore the coloring properties. 
                                      The properties are designed in such a way that this rearranging and recoloring can be performed efficiently.
                                      http://en.wikipedia.org/wiki/Red%E2%80%93black_tree

    4. Splay Tree                   - Automatically moves frequently accessed elements nearer to the root
    
    5. Treap (Tree Heap)            - Also called as Randomized Binary Search Tree
                                      Each node also holds a (randomly chosen) priority and the parent node has higher priority than its children. 
                                      http://en.wikipedia.org/wiki/Treap

    6. Tango Tree                   - Optimized for fast searches
    7. Optimal Binary Search Tree   - Static and Dynamic
                                      Provides the smallest possible search time (or expected search time) for a given sequence of accesses (or access probabilities). 
    
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Operations  :

    Create      :   Lower Bound - O(n log n)  for n elements  Upper Bound - Worst Case : O(n^2)
    Insert      :   Lower Bound - O(log N) for 1 element.     Upper Bound - Worst Case : O(n)
    Delete      :   Lower Bound - O(log N)                    Upper Bound - Worst Case : O(n)
    Search      :   Lower Bound - O(log N)                    Upper Bound - Worst Case : O(n)
    Traverse    :   Lower Bound - O(n) Pre Order, In Order, Post Order
 
    Find Max            :
    Find Min            :
    Find Largest        :
       
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    References  : 
    
    http://en.wikipedia.org/wiki/Pruning_(algorithm) 
    http://en.wikipedia.org/wiki/Grafting_(algorithm)
    http://en.wikipedia.org/wiki/Breadth-first_search
    http://en.wikipedia.org/wiki/Binary_search_tree
    http://en.wikipedia.org/wiki/Optimal_binary_search_tree
    http://en.wikipedia.org/wiki/Randomized_binary_search_tree
    http://en.wikibooks.org/wiki/Data_Structures/Trees

    http://www.bogotobogo.com/cplusplus/binarytree.php
    http://cslibrary.stanford.edu/110/BinaryTrees.html


    //Given a node in a binary tree, find all the nodes which are at distance K from it. Root node is also given

    http://www.geeksforgeeks.org/forums/topic/google-interview-question-17/
    http://stackoverflow.com/questions/3742772/how-to-convert-a-binary-search-tree-into-a-doubly-linked-list
    
    http://analgorithmist.blogspot.com/2013/06/the-great-tree-list-recursion-problem.html
    http://algorithmsandme.blogspot.in/search/label/algorithms#.U-in2410xUQ

    ============================================================================================================================================================================================================================
    */

    public class BinarySearchTreeOperations
    {
        public TreeNode RootdNode;
        StringBuilder resultString;
        bool removeSuccessFlag = false;

        // Basic Operations ====================================================================================================================================================================================================

        public BinarySearchTreeOperations()
        {
            resultString = new StringBuilder();
        }

        public void AddNodeToTree(int valueToAdd)
        {
            RootdNode = AddNodeToTree(RootdNode, valueToAdd);
        }

        private TreeNode AddNodeToTree(TreeNode currentNode, int valueToAdd)
        {
            // Create root node
            if (currentNode == null)
            {
                currentNode = new TreeNode(valueToAdd);
            }
            //Add to right if value is larger than parent
            else if (valueToAdd > currentNode.NodeValue)
            {
                currentNode.RightNode = AddNodeToTree(currentNode.RightNode, valueToAdd);
            }
            //Add to left if value is smaller than parent
            else if (valueToAdd < currentNode.NodeValue)
            {
                currentNode.LeftNode = AddNodeToTree(currentNode.LeftNode, valueToAdd);
            }
            else
            {
                throw new Exception("Node already exists");
            }
            return currentNode;
        }

        public void AddNodeToTreeWhile(int valueToAdd)
        {
            if (RootdNode == null)
            {
                RootdNode = new TreeNode(valueToAdd);
            }
            else
            {
                AddNodeToTreeWhile(RootdNode, valueToAdd);
            }
        }

        private void AddNodeToTreeWhile(TreeNode currentNode, int valueToAdd)
        {
            // Assuming root node has been created
            if (currentNode == null)
            {
                throw new Exception("Rootnode cannot be null");
            }

            while (currentNode != null)
            {
                //Add to right if value is larger than parent
                if (valueToAdd >= currentNode.NodeValue)
                {
                    if (currentNode.RightNode != null)
                    {
                        currentNode = currentNode.RightNode;
                    }
                    else
                    {
                        currentNode.RightNode = new TreeNode(valueToAdd);
                        break;
                    }
                }
                //Add to left if value is smaller than parent
                else if (valueToAdd <= currentNode.NodeValue)
                {
                    if (currentNode.LeftNode != null)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    else
                    {
                        currentNode.LeftNode = new TreeNode(valueToAdd);
                        break;
                    }
                }
                else
                {
                    throw new Exception("Node already exists");
                }
            }
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

        public TreeNode InvertTree(TreeNode currentNode)
        {
            //if (currentNode == null)
            //    return null;

            //TreeNode rightNode = InvertTree(currentNode.RightNode);
            //TreeNode leftNode = InvertTree(currentNode.LeftNode);

            //currentNode.LeftNode = rightNode;
            //currentNode.RightNode = leftNode;

            //return currentNode;

            if (currentNode == null)
                return null;

            Stack<TreeNode> nodesStack = new Stack<TreeNode>();
            nodesStack.Push(currentNode);

            while (nodesStack.Count > 0)
            {
                TreeNode node = nodesStack.Pop();
                TreeNode temp = node.LeftNode;
                node.LeftNode = node.RightNode;
                node.RightNode = temp;

                if (node.LeftNode != null)
                    nodesStack.Push(node.LeftNode);
                if (node.RightNode != null)
                    nodesStack.Push(node.RightNode);
            }

            return currentNode;
        }

        public bool RemoveNode(int NodeValue)
        {
            removeSuccessFlag = false;
            //RootdNode = RemoveNode(RootdNode, NodeValue);
            removeSuccessFlag = RemoveNodeIteration(RootdNode, NodeValue);
            return removeSuccessFlag;
        }

        private TreeNode RemoveNode(TreeNode currentNode, int NodeValue)
        {
            if (currentNode != null && currentNode.NodeValue == NodeValue)
            {
                // If there are no childs
                if (currentNode.LeftNode == null && currentNode.RightNode == null)
                {
                    currentNode = null;
                }
                // If there are childs for both left and right nodes.
                else if (currentNode.LeftNode != null && currentNode.RightNode != null)
                {
                    TreeNode lastRightChild = FindMinValue(currentNode.RightNode);
                    currentNode.NodeValue = lastRightChild.NodeValue;
                    lastRightChild = null;
                }
                // If there are child nodes to left node and right node is null then set the left node.
                else if (currentNode.LeftNode != null)
                {
                    currentNode = currentNode.LeftNode;
                }
                // If there are child nodes to right node and left node is null then set the right node.
                else if (currentNode.RightNode != null)
                {
                    currentNode = currentNode.RightNode;
                }
                removeSuccessFlag = true;
            }
            //Recursive call to right side.
            if (currentNode != null && removeSuccessFlag == false && NodeValue > currentNode.NodeValue)
            {
                currentNode.RightNode = RemoveNode(currentNode.RightNode, NodeValue);
            }
            //Recursive call to left side.
            if (currentNode != null && removeSuccessFlag == false && NodeValue < currentNode.NodeValue)
            {
                currentNode.LeftNode = RemoveNode(currentNode.LeftNode, NodeValue);
            }
            return currentNode;
        }

        private bool RemoveNodeIteration(TreeNode _currentNode, int NodeValue)
        {
            bool removeSuccess = false;
            TreeNode currentNode = _currentNode;
            while (currentNode != null & removeSuccess == false)
            {
                if (NodeValue > currentNode.NodeValue)
                {
                    currentNode = currentNode.RightNode;
                }
                else if (NodeValue < currentNode.NodeValue)
                {
                    currentNode = currentNode.LeftNode;
                }
                else// NodeValue = currentNode.NodeValue
                {
                    // If there are no childs
                    if (currentNode.LeftNode == null && currentNode.RightNode == null)
                    {
                        currentNode = null;
                    }
                    // If there are childs for both left and right nodes.
                    else if (currentNode.LeftNode != null && currentNode.RightNode != null)
                    {
                        //currentNode.NodeValue = FindMinValue(currentNode.RightNode).NodeValue;
                        //currentNode.RightNode = RemoveNode(currentNode.RightNode, currentNode.NodeValue);
                        TreeNode iterNode = currentNode.LeftNode;

                        while (iterNode != null && iterNode.RightNode != null)
                        {
                            iterNode = iterNode.RightNode;
                        }

                        TreeNode tempNode = new TreeNode();
                        tempNode.NodeValue = iterNode.NodeValue;
                        tempNode.LeftNode = currentNode.LeftNode;
                        tempNode.RightNode = currentNode.RightNode;
                        currentNode = tempNode;
                    }
                    // If there are child nodes to left node and right node is null then set the left node.
                    else if (currentNode.LeftNode != null)
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    // If there are child nodes to right node and left node is null then set the right node.
                    else if (currentNode.RightNode != null)
                    {
                        currentNode = currentNode.RightNode;
                    }
                    removeSuccess = true;
                }
            }
            return removeSuccess;
        }

        public void DeleteTree(TreeNode _currentNode)
        {
            if (_currentNode != null)
            {
                DeleteTree(_currentNode.LeftNode);
                DeleteTree(_currentNode.RightNode);

                _currentNode = null;
            }
        }

        public TreeNode SortedArrayToBST(int[] sortedArray)
        {
            TreeNode tn = createTreeFromSortedArray(sortedArray, 0, sortedArray.Length - 1);
            return tn;
        }

        public TreeNode createTreeFromSortedArray(int[] sortedArray, int leftPos, int rightPos)
        {
            if (leftPos > rightPos) // Creation done.
                return null;

            int mid = (leftPos + (rightPos - leftPos) / 2);

            // Mid Creation
            TreeNode parentNode = new TreeNode(sortedArray[mid]);

            // Left side exclude mid.
            parentNode.LeftNode = createTreeFromSortedArray(sortedArray, leftPos, mid - 1);

            // Right side exclude mid.
            parentNode.RightNode = createTreeFromSortedArray(sortedArray, mid + 1, rightPos);
            return parentNode;
        }

        public TreeNode createTreeFromSortedArrayUsingStack(int[] sortedArray)
        {
            int leftPos = 0;
            int rightPos = sortedArray.Length;

            Stack<TreeNode> nodesStack = new Stack<TreeNode>();

            int mid = (leftPos + (rightPos - leftPos) / 2);

            TreeNode rootNode = new TreeNode(sortedArray[mid]);
            nodesStack.Push(rootNode);

            while (nodesStack.Count > 0)
            {

                TreeNode parentNode = nodesStack.Pop();

                mid = (leftPos + (rightPos - leftPos) / 2);

                parentNode.LeftNode = new TreeNode(mid);
                nodesStack.Push(parentNode.LeftNode);


                // Left side exclude mid.
                parentNode.LeftNode = createTreeFromSortedArray(sortedArray, leftPos, mid - 1);

                // Right side exclude mid.
                parentNode.RightNode = createTreeFromSortedArray(sortedArray, mid + 1, rightPos);

            }
            return rootNode;
        }

        // Traversal Operations ================================================================================================================================================================================================
        public void FindDistance()
        {

        }

        // Depth First Search       
        public string PreOrderDisplay()
        {
            resultString.Clear();
            PreOrderDisplayRecursion(RootdNode);
            return resultString.ToString();
        }

        private void PreOrderDisplayRecursion(TreeNode currentNode)
        {
            if (currentNode != null)
            {
                resultString.Append("   " + currentNode.NodeValue);
                PreOrderDisplayRecursion(currentNode.LeftNode);
                PreOrderDisplayRecursion(currentNode.RightNode);
            }
        }

        // Same flow as Recursion just Push and pop between visits.
        public string PreOrderIterative(TreeNode currentNode)
        {
            resultString.Clear();

            if (currentNode == null)
            {
                return string.Empty;
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();

            // Push Current.
            stack.Push(currentNode);

            while (stack.Count > 0)
            {
                // Pop Current.
                currentNode = stack.Pop();
                resultString.Append("   " + currentNode.NodeValue);

                // Push Right.
                if (currentNode.RightNode != null)
                    stack.Push(currentNode.RightNode);

                // Push Left.
                if (currentNode.LeftNode != null)
                    stack.Push(currentNode.LeftNode);                
            }

            return resultString.ToString();
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

        // Same flow as Recursion just Push and pop between visits. 
        public string InOrderDisplayIterative(TreeNode currNode)
        {
            resultString.Clear();

            if (currNode == null)
                return string.Empty;

            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (stack.Count > 0 || currNode != null)
            {
                if (currNode != null)
                {
                    stack.Push(currNode);
                    currNode = currNode.LeftNode;
                }
                else
                {
                    currNode = stack.Pop();
                    Console.Write(" " + currNode.NodeValue);
                    currNode = currNode.RightNode;
                }
            }

            return resultString.ToString();
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

        // Same flow as Recursion just Push and pop between visits.
        public string PostOrderDisplayIterative(TreeNode currentNode)
        {
            resultString.Clear();

            if (currentNode == null)
                return string.Empty;

            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode peekNode = null;
            TreeNode lastVisitedNode = null;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    peekNode = stack.Peek();

                    if (peekNode.RightNode != null && peekNode.RightNode != lastVisitedNode)
                    {
                        currentNode = peekNode.RightNode;
                    }
                    else
                    {
                        stack.Pop();
                        resultString.Append("  " + peekNode.NodeValue);

                        lastVisitedNode = peekNode;
                    }
                }
            }

            return Convert.ToString(resultString);
        }

        // BFS : Also called as Level Order Traversal.
        // We can remove the stack requirement by maintaining parent pointers in each node, or by 'Morris in-order traversal using threading'
        public string BreadthFirstSearchUsingQueue(TreeNode parentNode)
        {
            if (parentNode == null)
                return string.Empty;

            resultString.Clear();
            Queue<TreeNode> queue = new Queue<TreeNode>();

            // Enque parentNode to Queue
            queue.Enqueue(parentNode);

            while (queue.Count > 0)
            {
                // Dequeue currentNode from Queue
                parentNode = queue.Dequeue();
                resultString.Append("  " + parentNode.NodeValue);

                //Enque leftChild.
                if (parentNode.LeftNode != null)
                    queue.Enqueue(parentNode.LeftNode);

                //Enque rightChild.
                if (parentNode.RightNode != null)
                    queue.Enqueue(parentNode.RightNode);
            }
            return Convert.ToString(resultString);
        }

        //======================================================================================================================================================================================================================

        TreeNode prevNode, firstWrongElement, secondWrongElement;

        public void RecoverTree(TreeNode root)
        {
            recoverTree(root);
            if (firstWrongElement != null && secondWrongElement != null)
            {
                int temp = firstWrongElement.NodeValue;
                firstWrongElement.NodeValue = secondWrongElement.NodeValue;
                secondWrongElement.NodeValue = temp;
            }
        }

        private void recoverTree(TreeNode node)
        {
            if (node == null)
                return;

            recoverTree(node.LeftNode);

            if (firstWrongElement == null && prevNode != null && prevNode.NodeValue > node.NodeValue)
                firstWrongElement = prevNode;

            // This condition satisfies multiple times, so we will consider the last element.
            if (firstWrongElement != null && prevNode != null && prevNode.NodeValue > node.NodeValue)
                secondWrongElement = node;

            prevNode = node;

            recoverTree(node.RightNode);
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

        /* Given binary tree[3, 9, 20, null, null, 15, 7],

            3
           / \
          9  20
            /  \
           15   7

        return its bottom-up level order traversal as:

        [ [15, 7],
          [9, 20],
          [3] ]  */

        public IList<IList<int>> LevelOrderBottomIterative(TreeNode curNode)
        {
            IList<int> items = new List<int>();
            IList<IList<int>> itemsList = new List<IList<int>>();

            if (curNode == null)
                return itemsList;

            Queue<TreeNode> trQ = new Queue<TreeNode>();

            trQ.Enqueue(curNode);
            int levelLen = 0;

            while (trQ.Count() > 0)
            {
                levelLen = trQ.Count();

                for (int lpCnt = 0; lpCnt < levelLen; lpCnt++)
                {
                    TreeNode tr = trQ.Dequeue();
                    items.Add(tr.NodeValue);

                    if (tr.LeftNode != null)
                        trQ.Enqueue(tr.LeftNode);
                    if (tr.RightNode != null)
                        trQ.Enqueue(tr.RightNode);
                }

                itemsList.Add(items);
                items = new List<int>();
            }

            itemsList = itemsList.Reverse().ToList();
            return itemsList;
        }

        public IList<IList<int>> LevelOrderBottomRecursive(TreeNode curNode)
        {
            IList<int> items = new List<int>();
            IList<IList<int>> itemsList = new List<IList<int>>();

            if (curNode == null)
                return itemsList;

            Queue<TreeNode> trQ = new Queue<TreeNode>();

            trQ.Enqueue(curNode);
            int levelLen = 0;

            while (trQ.Count() > 0)
            {
                levelLen = trQ.Count();

                for (int lpCnt = 0; lpCnt < levelLen; lpCnt++)
                {
                    TreeNode tr = trQ.Dequeue();
                    items.Add(tr.NodeValue);

                    if (tr.LeftNode != null)
                        trQ.Enqueue(tr.LeftNode);
                    if (tr.RightNode != null)
                        trQ.Enqueue(tr.RightNode);
                }

                itemsList.Add(items);
                items = new List<int>();
            }

            itemsList = itemsList.Reverse().ToList();
            return itemsList;
        }


        /*       Given   1
                        / \
                       2   5
                      / \   \
                     3   4   6

        The flattened tree should look like:  1->2->3->4->5-6
        Reverse Pre Order technique */

        public void FlattenTree(TreeNode currentNode)
        {
            if (currentNode == null)
                return;

            FlattenTree(currentNode.RightNode);
            FlattenTree(currentNode.LeftNode);

            currentNode.RightNode = PrevNode;
            currentNode.LeftNode = null;
            PrevNode = currentNode;
        }
        /*
         Iterative: Starting from parent node runner, keep a copy of right child, let it be right first since we are going to reset runner.right.
         if runner has left child(runner->left), it will become the new right child of runner, and then we set left child to nullptr. 
         How to deal the old right child right? We need to find it a new parent, which should be the rightmost node in the subtree rooted at the old left child, 
         which we just set as the new right child(runner->right), so rRunner is doing this work to find the new parent for right. 
         After all of this, we continue with runner's right child.

         current runner: 1

            before update:
                 1
                / \
               2   5
              / \   \
             3   4   6

            update:
            right = 1->right = 5
            1->right = 2
            rRunner = 4
            4->right = right = 5

            after update:   
                 1
                  \
                   2   
                  / \   
                 3   4   
                      \
                       5
                        \
                         6

            next runner: 2


         */
        public void FlattenIterative(TreeNode listBuilder)
        {
            while (listBuilder != null)
            {
                if (listBuilder.LeftNode != null)
                {
                    TreeNode oldRight = listBuilder.RightNode;

                    listBuilder.RightNode = listBuilder.LeftNode;
                    listBuilder.LeftNode = null;

                    //Move listBuilder to next (new right child)
                    listBuilder = listBuilder.RightNode;

                    TreeNode newRight = listBuilder;

                    while (newRight.RightNode != null)
                        newRight = newRight.RightNode;

                    // Hook back the oldRight to the new right child's last node.
                    newRight.RightNode = oldRight;
                }
                else
                    listBuilder = listBuilder.RightNode;
            }
        }

        ListNode listNode;
        public TreeNode CreateTreeFromSLL()
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
            TreeNode treeNode = createTreeFromSLL(1, listLen);
            return treeNode;
        }

        public int GetSLLLen(ListNode rootNode)
        {
            int len = 0;
            ListNode currentNode = rootNode;

            while (currentNode != null)
            {
                len++;
                currentNode = currentNode.NextNode;
            }
            return len;
        }

        private TreeNode createTreeFromSLL(int n)
        {
            if (n <= 0)
                return null;

            TreeNode treenode = new TreeNode(0);
            treenode.LeftNode = createTreeFromSLL(n / 2);
            treenode.NodeValue = listNode.NodeValue;

            listNode = listNode.NextNode;
            treenode.RightNode = createTreeFromSLL(n - n / 2 - 1);
            return treenode;
        }

        public TreeNode createTreeFromSLL(int leftPos, int rightPos)
        {
            if (leftPos > rightPos) // Creation done.
                return null;

            int mid = (leftPos + (rightPos - leftPos) / 2);

            // Mid Creation
            TreeNode parentNode = new TreeNode();

            // Left side exclude mid.
            parentNode.LeftNode = createTreeFromSLL(leftPos, mid - 1);
            parentNode.NodeValue = listNode.NodeValue;

            listNode = listNode.NextNode;
            // Right side exclude mid.
            parentNode.RightNode = createTreeFromSLL(mid + 1, rightPos);
            return parentNode;
        }

        int left, right;
        int countTrees(int n)
        {
            if (n <= 1) return 1;
            else
            {
                int sum = 0;
                for (int i = 1; i <= n; i++)
                {
                    left = countTrees(i - 1);
                    right = countTrees(n - i);
                    sum += left * right;
                }
                return sum;
            }
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

        public int FindMinValue()
        {
            int minValue = 0;

            TreeNode ResultNode = FindMinValue(RootdNode);
            if (ResultNode != null)
            {
                minValue = ResultNode.NodeValue;
            }
            return minValue;
        }

        public TreeNode FindMinValue(TreeNode currentNode)
        {
            while (currentNode != null && currentNode.LeftNode != null)
            {
                currentNode = currentNode.LeftNode;
            }

            return currentNode;
        }

        public int FindMaxValue()
        {
            int maxValue = 0;
            TreeNode resultNode = FindMaxValue(RootdNode);
            if (resultNode != null)
            {
                maxValue = resultNode.NodeValue;
            }
            return maxValue;
        }

        private TreeNode FindMaxValue(TreeNode currentNode)
        {
            while (currentNode != null && currentNode.RightNode != null)
            {
                currentNode = currentNode.RightNode;
            }
            return currentNode;
        }

        public int SearchNode(int valueToFind)
        {
            //            if 
            return 0;
        }

        //Need to implement
        int Find2ndLargetElement()
        {
            return -1;
        }

        //Lowest Common Ancestor 
        public int LowestCommonAncestor(int NodeValue1, int NodeValue2)
        {
            TreeNode CommonAncestorNode = LowestCommonAncestor(RootdNode, NodeValue1, NodeValue2);
            //TreeNode CommonAncestorNode = LowestCommonAncestorLoop(RootdNode, NodeValue1, NodeValue2);

            int CommonAncestorValue = 0;
            if (CommonAncestorNode != null)
            {
                CommonAncestorValue = CommonAncestorNode.NodeValue;
            }

            return CommonAncestorValue;
        }

        bool foundFlag = false;
        //Recursion
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

        //Using loop - log(n) operations
        TreeNode LowestCommonAncestorLoop(TreeNode currentNode, int Node1Value, int Node2Value)
        {
            while (currentNode != null)
            {
                // Move to the left subtree if the given values are less than current node's value.
                if (Node1Value < currentNode.NodeValue && Node2Value < currentNode.NodeValue)
                {
                    currentNode = currentNode.LeftNode;
                }
                // Move to right subtree if the given values are greater than current node's value.
                else if (Node1Value > currentNode.NodeValue && Node2Value > currentNode.NodeValue)
                {
                    currentNode = currentNode.RightNode;
                }
                else
                {
                    // We have found the common ancestor.
                    break;
                }
            }
            return currentNode;
        }

        public TreeNode Link2Trees(TreeNode tree1RootNode, TreeNode tree2RootNode)
        {
            // if tree1 is null return tree2
            if (tree1RootNode == null)
            {
                return tree2RootNode;
            }
            // if tree2 is null return tree1
            if (tree2RootNode == null)
            {
                return tree1RootNode;
            }

            TreeNode temp = tree1RootNode;

            while (temp.LeftNode != null)
            {
                temp = temp.LeftNode;
            }

            temp.LeftNode = tree2RootNode;

            return tree1RootNode;
        }

        public TreeNode Merge2BST(TreeNode tree1RootNode, TreeNode tree2RootNode)
        {
            if (tree1RootNode == null)
            {
                return tree2RootNode;
            }
            if (tree2RootNode == null)
            {
                return tree1RootNode;
            }
            MergeTree(tree1RootNode, tree2RootNode);
            return tree1RootNode;
        }

        private void MergeTree(TreeNode tree1TraverseNode, TreeNode tree2TraverseNode)
        {
            if (tree2TraverseNode != null)
            {
                MergeTree(tree1TraverseNode, tree2TraverseNode.LeftNode);
                MergeTree(tree1TraverseNode, tree2TraverseNode.RightNode);
                InsertNodeInTree(tree1TraverseNode, tree2TraverseNode);
            }
        }

        // Insert nodes 
        private TreeNode InsertNodeInTree(TreeNode tree1Node, TreeNode tree2Node)
        {
            if (tree1Node == null)
            {
                tree2Node.LeftNode = null;
                tree2Node.RightNode = null;
                return tree2Node;
            }
            // If tree1Node val Grater than tree2Node then insert tree2Node to tree1Node.Left
            if (tree2Node.NodeValue < tree1Node.NodeValue)
            {
                tree1Node.LeftNode = InsertNodeInTree(tree1Node.LeftNode, tree2Node);
                return tree1Node;
            }
            // If tree1Node val is less than tree2Nod then insert tree2node to tree1node right
            else if (tree2Node.NodeValue > tree1Node.NodeValue)
            {
                tree1Node.RightNode = InsertNodeInTree(tree1Node.RightNode, tree2Node);
                return tree1Node;
            }
            else
            {
                Debug.WriteLine("Duplicate , here you can delete the node\n");
                tree2Node = null;
                return null;
            }
        }

        // MinHeight
        public int MinDepthOfTree(TreeNode currentNode)
        {
            if (currentNode == null)
                return 0;
            return 1 + Math.Min(MinDepthOfTree(currentNode.LeftNode), MinDepthOfTree(currentNode.RightNode));
        }

        public int MinHeightOfTree()
        {
            int TreeMinHeight = MinHeightOfTreeItr(RootdNode);
            return TreeMinHeight;
        }

        private int MinHeightOfTree1(TreeNode currentNode)
        {
            if (currentNode == null)
                return int.MaxValue;

            int LeftMinHeight = MinHeightOfTree(currentNode.LeftNode);
            int RightMinHeight = MinHeightOfTree(currentNode.RightNode);

            return Math.Min(LeftMinHeight, RightMinHeight) + 1;

            //if (LeftMinHeight < RightMinHeight)
            //    return LeftMinHeight + 1;
            //else
            //    return rightMin + 1;
        }

        private int MinHeightOfTree(TreeNode currentNode)
        {
            if (currentNode == null)
                return 0;

            int minHeight = 0;

            if (currentNode.LeftNode != null && currentNode.RightNode != null)
                minHeight = Math.Min(MinHeightOfTree(currentNode.LeftNode), MinHeightOfTree(currentNode.RightNode));
            else
                minHeight = Math.Max(MinHeightOfTree(currentNode.LeftNode), MinHeightOfTree(currentNode.RightNode));

            return minHeight + 1;
        }

        private int MinHeightOfTreeItr(TreeNode rootNode)
        {
            if (rootNode == null)
                return 0;

            int levelCnt = 0;
            Queue<TreeNode> parentQ = new Queue<TreeNode>();
            Queue<TreeNode> levelQ = new Queue<TreeNode>();

            parentQ.Enqueue(rootNode);

            while (parentQ.Count > 0)
            {
                TreeNode currNode = parentQ.Dequeue();

                if (currNode.LeftNode == null && currNode.RightNode == null)
                    return ++levelCnt;

                if (currNode.LeftNode != null)
                    levelQ.Enqueue(currNode.LeftNode);

                if (currNode.RightNode != null)
                    levelQ.Enqueue(currNode.RightNode);

                if (parentQ.Count == 0)
                {
                    parentQ = levelQ;
                    levelQ = new Queue<TreeNode>();
                    ++levelCnt;
                }
            }
            return -1;
        }

        //MaxHeight
        public int MaxDepthOfTree(TreeNode currentNode)
        {
            if (currentNode == null)
                return 0;
            return 1 + Math.Max(MaxDepthOfTree(currentNode.LeftNode), MaxDepthOfTree(currentNode.RightNode));
        }

        public int MaxHeightOfTree()
        {
            int TreeMaxHeight = MaxHeightOfTree(RootdNode);
            return TreeMaxHeight;
        }

        private int MaxHeightOfTree(TreeNode currentNode)
        {
            if (currentNode == null)
                return 0;

            int LeftMaxHeight = MaxHeightOfTree(currentNode.LeftNode);
            int RightMaxHeight = MaxHeightOfTree(currentNode.RightNode);

            if (LeftMaxHeight > RightMaxHeight)
                return (LeftMaxHeight + 1);
            else
                return (RightMaxHeight + 1);
        }

        public bool IsSameTree(TreeNode t1Node, TreeNode t2Node)
        {
            if (t1Node == null || t2Node == null)
                return t1Node == t2Node;
            else
                return (t1Node.NodeValue == t2Node.NodeValue) &&
                        IsSameTree(t1Node.LeftNode, t2Node.LeftNode) &&
                        IsSameTree(t1Node.RightNode, t2Node.RightNode);
        }

        public bool IsSameTreeRec(TreeNode t1Node, TreeNode t2Node)
        {
            if (t1Node == null || t2Node == null)
                return t1Node == t2Node;

            Stack<TreeNode> t1Stack = new Stack<TreeNode>();
            Stack<TreeNode> t2Stack = new Stack<TreeNode>();

            if (t1Node != null)
                t1Stack.Push(t1Node);
            if (t2Node != null)
                t2Stack.Push(t2Node);

            while (t1Stack.Count() > 0 && t2Stack.Count() > 0)
            {
                TreeNode t1 = t1Stack.Pop();
                TreeNode t2 = t2Stack.Pop();

                if (t1.NodeValue != t2.NodeValue)
                    return false;

                if (t1.LeftNode != null)
                    t1Stack.Push(t1.LeftNode);
                if (t2.LeftNode != null)
                    t2Stack.Push(t2.LeftNode);

                if (t1Stack.Count() != t2Stack.Count())
                    return false;

                if (t1.RightNode != null)
                    t1Stack.Push(t1.RightNode);
                if (t2.RightNode != null)
                    t2Stack.Push(t2.RightNode);

                if (t1Stack.Count() != t2Stack.Count())
                    return false;
            }

            return (t1Stack.Count() == t2Stack.Count());
        }

        //======================================================================================================================================================================================================================

        /*
        
        A well-formed binary tree is said to be "Height-Balanced" 
        
        1. If it is empty, or 
        2. Its left and right children are height-balanced and the height of the left tree is within 1 of the height of the right tree.

        Tree is considered balanced when the difference between the min depth and max depth does not exceed 1. 
 
        Binary tree in which the height of the two subtrees of every node never differ by more than 1.

        E.g:

        1. Let A = Depth of the Highest-Level Node - MaxDepth
        2. Let B = Depth of the Lowest-Level Node - MinDepth
        3. If Math.Abs(A-B) <= 1, then the tree is balanced
        */
        public bool IsTreeBalanced(TreeNode currentNode)
        {
            if (currentNode == null)
                return true;

            int leftHeight = MaxDepthOfTree(currentNode.LeftNode);
            int rightHeight = MaxDepthOfTree(currentNode.RightNode);

            if (Math.Abs(leftHeight - rightHeight) > 1)
                return false;
            else
                return IsTreeBalanced(currentNode.LeftNode) && IsTreeBalanced(currentNode.RightNode);
        }

        // Total no of nodes in the tree.
        //https://discuss.leetcode.com/topic/15533/concise-java-solutions-o-log-n-2/24
        public int SizeOfTree(TreeNode currentNode)
        {
            if (currentNode == null)
                return 0;

            return 1 + SizeOfTree(currentNode.LeftNode) + SizeOfTree(currentNode.RightNode);
        }

        //Note it mess ups the existing tree structure.
        public string InOrderIterativeWithoutStak(TreeNode root)
        {
            resultString.Clear();
            InOrderIterativeWithoutStak(root.LeftNode, root);
            return resultString.ToString();
        }

        void InOrderIterativeWithoutStak(TreeNode current, TreeNode parent)
        {
            while (current != null)
            {
                if (parent != null)
                {
                    parent.LeftNode = current.RightNode;
                    current.RightNode = parent;
                }

                if (current.LeftNode != null)
                {
                    parent = current;
                    current = current.LeftNode;
                }
                else
                {
                    resultString.Append("  " + current.NodeValue);
                    current = current.RightNode;
                    parent = null;
                }
            }
        }

        //If the given binary tree is a binary search tree, then the inorder traversal should output the elements in increasing order. 
        public bool IsBSTInOrderRecursion()
        {
            bool isBST = IsBSTInInOrderRecursion(RootdNode);
            //bool isBST = IsValidBSTIteration(RootdNode);
            return isBST;
        }

        public bool IsValidBSTIteration(TreeNode currNode)
        {
            if (currNode == null)
                return true;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode prevNode = null;

            while (currNode != null || stack.Count > 0)
            {
                while (currNode != null)
                {
                    stack.Push(currNode);
                    currNode = currNode.LeftNode;
                }

                currNode = stack.Pop();

                if (prevNode != null && currNode.NodeValue <= prevNode.NodeValue)
                    return false;

                prevNode = currNode;
                currNode = currNode.RightNode;
            }
            return true;
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

        // Keep traverse the tree in order and compare with its previous value.
        public TreeNode PrevNode { get; set; }

        private bool IsBSTInInOrderRecursion(TreeNode currentNode)
        {
            if (currentNode == null)
                return true;

            bool result = IsBSTInInOrderRecursion(currentNode.LeftNode);

            if (result == false)
                return false;

            if (PrevNode != null && currentNode.NodeValue <= PrevNode.NodeValue)
                return false;

            PrevNode = currentNode;

            return IsBSTInInOrderRecursion(currentNode.RightNode);
        }

        /*
                // http://datastructuresinterview.blogspot.com/2013/03/zig-zag-traversal-on-binary-tree.html

        1. Use 2 stacks stack1 and stack2
        2. Push the root to stack1
        3. Till stack1 becomes empty perform steps 4 and 5
        4. Pop from stack1 and display the popped element
        5. Push children of popped element into stack2 from left to right
        6. Till stack2 becomes empty perform steps 7 and 8
        7. Pop from stack2 and display the popped element
        8. Push children of popped element into stack1 from right to left
        9. Repeat steps 3 to 8 till both stacks become empty
         */

        public void ZigZagDisplay()
        {
        }

        /*
        http://www.dsalgo.com/2013/02/print-binary-tree-from-bottom-to-top.html
        */
        public void DisplayFromBottonToTop()
        {
        }

        /*
        http://www.dsalgo.com/2013/02/print-binary-tree-bottom-to-top-level.html
        */
        public void DisplayFromBottonToTopLevelWise()
        {
        }

        public void ReverseTree(TreeNode currentNode)
        {
            if (currentNode == null)
                return;

            TreeNode tempNode = currentNode.RightNode;
            currentNode.RightNode = currentNode.LeftNode;
            currentNode.LeftNode = tempNode;

            ReverseTree(currentNode.LeftNode);
            ReverseTree(currentNode.RightNode);
        }

        /*
        Find if all the leaf nodes are at same level in binary tree. 
        Recursive and non-recursive approach?
               bool IsLeaf(Node node)
        {
        if(node.left==null && node.right==null) 
                return true;
        return false;
        }

        bool CheckBalance(List<Node> l)
        {
                bool collectionHasLeaf=false;
        List<Node> listOfChildren=new List<Node>();
        foreach(Node n in l)
        {
            if(IsLeaf(n))
            { 
            collectionHasLeaf=true
            };

            else
            {
            if(n.left!=null)
                    {listOfChildren.Add(n.left);}
            if(n.right!=null)
                    {listOfChildren.Add(n.right)};
            }
            }
            if(collectionHasLeaf)
            { 
            if(listOfChildren.Count>;0) 
                    return false;
            return true;
            }
            return CheckBalance(listOfChildren);
        }

        Public bool CheckBalance(Node head)
        {
        List<Node> l=new List<Node>();
        l.Add(head);
        return CheckBalance(l);
        }
         */

        //======================================================================================================================================================================================================================
        //http://cslibrary.stanford.edu/109/TreeListRecursion.html
        public void Convert2CircularDoublyLinkedList()
        {

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

        /* Given n, how many structurally unique BST's (binary search trees) that store values 1...n?
        E.g. Given n = 3, there are a total of 5 unique BST's. 

           1         3     3      2      1
            \       /     /      / \      \
             3     2     1      1   3      2
            /     /       \                 \
           2     1         2                 3              
               E.g. n = 4
    
        1 is the root: left 0 node right 3 nodes :temp[1] = trCnt[0] * trCnt[3] = 5
        2 is the root: left 1 node right 2 nodes :temp[2] = trCnt[1] * trCnt[2] = 2
        3 is the root: left 2 node right 1 nodes :temp[3] = trCnt[2] * trCnt[1] = 2
        4 is the root: left 3 node right 0 nodes :temp[4] = trCnt[3] * trCnt[0] = 5
   
        trCnt[4] = temp[1] +... temp[4] = 14
   
        We know that for n = 0 we can have 1 bst of null
                     for n = 1 we have 1 bst of 1
                 and for n = 2 we can arrange using two ways Now idea is simple for rest numbers. 
                     for n = 3 make 1 as root node so there will be 0 nodes in left subtree and 2 nodes in right subtree. 

        We know the solution for 2 nodes that they can be used to make 2 bsts.
        Now making 2 as the root node , there will be 1 in left subtree and 1 node in right subtree. ! node results in 1 way for making a BST.
        Now making 3 as root node. 
        There will be 2 nodes in left subtree and 0 nodes in right subtree. 
        We know 2 will give 2 BST and zero will give 1 BST.
        Totalling the result of all the 3 nodes as root will give 5. Same process can be applied for more numbers.
 
*/

        public int GetUniqueBSTsCount(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            int[] trCnt = new int[n + 1];

            trCnt[0] = 1;
            trCnt[1] = 1; // n = 1
            trCnt[2] = 2; // n = 2

            int leftPos = 0;
            int rightPos = 0;

            for (int i = 3; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    leftPos = j - 1;
                    rightPos = i - j;
                    trCnt[i] += trCnt[leftPos] * trCnt[rightPos];
                }
            }

            return trCnt[n];
        }

        void ConnectNodesAtSameLevel()
        {
            //            http://www.geeksforgeeks.org/connect-nodes-at-same-level/
        }

        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null)
                return -1;

            return KthSmallestHelper(root, ref k);
        }

        private int KthSmallestHelper(TreeNode currNode, ref int kIndx)
        {
            if (currNode == null)
                return -1;

            int resultNodeVal = KthSmallestHelper(currNode.LeftNode, ref kIndx);

            if (resultNodeVal != -1)
                return resultNodeVal;

            if (--kIndx == 0)
                return currNode.NodeValue;

            return KthSmallestHelper(currNode.RightNode, ref kIndx);
        }

        public int KthSmallestMorrisTraversal(TreeNode currNode, int kIndx)
        {
            while (currNode != null)
            {
                if (currNode.LeftNode == null)
                {
                    if (--kIndx == 0)
                        return currNode.NodeValue;

                    currNode = currNode.RightNode;
                }
                else
                {
                    TreeNode run = currNode.LeftNode;
                    while (run.RightNode != null && run.RightNode != currNode)
                    {
                        run = run.RightNode;
                    }
                    if (run.RightNode == null)
                    {
                        run.RightNode = currNode;
                        currNode = currNode.LeftNode;
                    }
                    else
                    {
                        if (--kIndx == 0)
                            return currNode.NodeValue;

                        run.RightNode = null;
                        currNode = currNode.RightNode;
                    }
                }
            }
            return -1;
        }
        public int KthSmallestUsingStack(TreeNode currNode, int kIndx)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();

            while (stack.Count != 0 || currNode != null)
            {
                if (currNode != null)
                {
                    stack.Push(currNode);
                    currNode = currNode.LeftNode;
                }
                else
                {
                    currNode = stack.Pop();

                    if (--kIndx == 0)
                        break;
                    currNode = currNode.RightNode;
                }
            }

            if (kIndx > 0)
                throw new Exception();

            return currNode.NodeValue;
        }
    }
}