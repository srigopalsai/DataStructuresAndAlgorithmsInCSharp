using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public partial class BinarySearchTreeOperations
    {
        public int countNodes(TreeNode root)
        {
            // edge conditions
            if (root == null)
            {
                return 0;
            }

            int leftHeight = HeightHelperLeft(root);
            int rightHeight = HeightHelperRight(root);

            if (leftHeight == rightHeight)
            {
                return (1 << leftHeight) - 1;
            }

            return countNodes(root.LeftNode) + countNodes(root.RightNode) + 1;
        }

        private int HeightHelperLeft(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + HeightHelperLeft(root.LeftNode);
        }

        private int HeightHelperRight(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + HeightHelperRight(root.RightNode);
        }

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

        public ListNode ListNodeSL { get; set; }

        public TreeNode CreateTreeFromSLLRecurisve(int lIndx, int rIndx)
        {
            if (lIndx > rIndx)
                return null;

            int mIndx = lIndx + (rIndx - lIndx) / 2;

            TreeNode leftChild = CreateTreeFromSLLRecurisve(lIndx, mIndx - 1);
            TreeNode parent = new TreeNode(ListNodeSL.NodeValue);

            parent.LeftNode = leftChild;
            ListNodeSL = ListNodeSL.NextNode;

            parent.RightNode = CreateTreeFromSLLRecurisve(mIndx + 1, rIndx);
            return parent;
        }

        // https://www.geeksforgeeks.org/convert-bst-min-heap/

        // Convert the given BST into a Min Heap with the condition that all the values in the left subtree of a node should be less than all the values in the right subtree of the node.
        // This condition is applied on all the nodes in the so converted Min Heap.
        // Examples:
        //    Input :         4
        //                  /   \
        //                 2     6
        //               /  \   /  \
        //              1   3  5    7  

        //    Output :        1
        //                  /   \
        //                 2     5
        //               /  \   /  \
        //              3   4  6    7 

        // The given BST has been transformed into a Min Heap.
        // All the nodes in the Min Heap satisfies the given condition, that is, values in the left subtree of
        // a node should be less than the values in the right subtree of the node. 

        // function to convert the given BST to MIN HEAP
        // performs preorder traversal of the tree
        public void BSTToMinHeap(TreeNode root, int[] arr, ref int i)
        {
            if (root == null)
                return;

            root.NodeValue = arr[++i];

            BSTToMinHeap(root.LeftNode, arr, ref i);
            BSTToMinHeap(root.RightNode, arr, ref i);
        }

        public void InorderTraversal(TreeNode root, int[] arr)
        {
            if (root == null)
                return;

            // first recur on left subtree
            InorderTraversal(root.LeftNode, arr);

            // then copy the data of the node
            //arr.push_back(root.NodeValue);

            // now recur for right subtree
            InorderTraversal(root.RightNode, arr);
        }

        // utility function to convert the given BST to
        // MIN HEAP
        public void ConvertToMinHeapUtil(TreeNode root)
        {
            // vector to store the data of all the
            // nodes of the BST
            int[] arr = new int[0];
            int i = -1;

            // inorder traversal to populate 'arr'
            InorderTraversal(root, arr);

            // BST to MIN HEAP conversion
            BSTToMinHeap(root, arr, ref i);
        }

        // https://www.geeksforgeeks.org/in-place-convert-bst-into-a-min-heap/
        // Utility function to print Min-heap level by level
        //void printLevelOrder(Node* root)
        //{
        //    // Base Case
        //    if (root == NULL) return;

        //    // Create an empty queue for level order traversal
        //    queue<Node*> q;
        //    q.push(root);

        //    while (!q.empty())
        //    {
        //        int nodeCount = q.size();
        //        while (nodeCount > 0)
        //        {
        //            Node* node = q.front();
        //            cout << node->data << " ";
        //            q.pop();
        //            if (node->left)
        //                q.push(node->left);
        //            if (node->right)
        //                q.push(node->right);
        //            nodeCount--;
        //        }
        //        cout << endl;
        //    }
        //}

        //// A simple recursive function to convert a given
        //// Binary Search tree to Sorted Linked List
        //// root     --> Root of Binary Search Tree
        //// head_ref --> Pointer to head node of created
        ////              linked list
        //void BSTToSortedLL(Node* root, Node** head_ref)
        //{
        //    // Base cases
        //    if (root == NULL)
        //        return;

        //    // Recursively convert right subtree
        //    BSTToSortedLL(root->right, head_ref);

        //    // insert root into linked list
        //    root->right = *head_ref;

        //    // Change left pointer of previous head
        //    // to point to NULL
        //    if (*head_ref != NULL)
        //        (*head_ref)->left = NULL;

        //    // Change head of linked list
        //    *head_ref = root;

        //    // Recursively convert left subtree
        //    BSTToSortedLL(root->left, head_ref);
        //}

        //// Function to convert a sorted Linked
        //// List to Min-Heap.
        //// root --> Root of Min-Heap
        //// head --> Pointer to head node of sorted
        ////              linked list
        //void SortedLLToMinHeap(Node* &root, Node* head)
        //{
        //    // Base Case
        //    if (head == NULL)
        //        return;

        //    // queue to store the parent nodes
        //    queue<Node*> q;

        //    // The first node is always the root node
        //    root = head;

        //    // advance the pointer to the next node
        //    head = head->right;

        //    // set right child to NULL
        //    root->right = NULL;

        //    // add first node to the queue
        //    q.push(root);

        //    // run until the end of linked list is reached
        //    while (head)
        //    {
        //        // Take the parent node from the q and remove it from q
        //        Node* parent = q.front();
        //        q.pop();

        //        // Take next two nodes from the linked list and
        //        // Add them as children of the current parent node
        //        // Also in push them into the queue so that
        //        // they will be parents to the future nodes
        //        Node* leftChild = head;
        //        head = head->right;        // advance linked list to next node
        //        leftChild->right = NULL; // set its right child to NULL
        //        q.push(leftChild);

        //        // Assign the left child of parent
        //        parent->left = leftChild;

        //        if (head)
        //        {
        //            Node* rightChild = head;
        //            head = head->right; // advance linked list to next node
        //            rightChild->right = NULL; // set its right child to NULL
        //            q.push(rightChild);

        //            // Assign the right child of parent
        //            parent->right = rightChild;
        //        }
        //    }
        //}

        //// Function to convert BST into a Min-Heap
        //// without using any extra space
        //Node* BSTToMinHeap(Node* &root)
        //{
        //    // head of Linked List
        //    Node* head = NULL;

        //    // Convert a given BST to Sorted Linked List
        //    BSTToSortedLL(root, &head);

        //    // set root as NULL
        //    root = NULL;

        //    // Convert Sorted Linked List to Min-Heap
        //    SortedLLToMinHeap(root, head);
        //}

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

        public TreeNode ConvertToAdjacencyList(TreeNode node)
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
        public TreeNode ConvertBSTToGreaterTree(TreeNode root)
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

        // Construct Balenced BST (By InOrder)
        public TreeNode BuildTreeFromInOrder(int[] sortedArray)
        {
            if (sortedArray == null || sortedArray.Length == 0)
                return null;

            TreeNode rootNode = BuildTreeFromInOrderRecursionHelper(sortedArray, 0, sortedArray.Length - 1);
            return rootNode;
        }

        private TreeNode BuildTreeFromInOrderRecursionHelper(int[] inOrder, int lIndx, int rIndx)
        {
            if (lIndx > rIndx)
                return null;

            int mid = (lIndx + (rIndx - lIndx) / 2);

            TreeNode currNode = new TreeNode(inOrder[mid]);

            currNode.LeftNode = BuildTreeFromInOrderRecursionHelper(inOrder, lIndx, mid - 1);
            currNode.RightNode = BuildTreeFromInOrderRecursionHelper(inOrder, mid + 1, rIndx);

            return currNode;
        }

        // https://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversa/
        public TreeNode BuildTreeFromPreOrderRecursive(int[] preOrder)
        {
            if (preOrder == null || preOrder.Length == 0)
                return null;

            int preIndex = 0;
            return BuildTreeFromPreOrderHeler(preOrder, ref preIndex, preOrder[0], int.MinValue, int.MaxValue);
        }

        private TreeNode BuildTreeFromPreOrderHeler(int[] preOrder, ref int preIndex, int key, int minVal, int maxVal)
        {
            if (preIndex >= preOrder.Length || key <= minVal || key >= maxVal)
                return null;

            TreeNode currNode = new TreeNode(key);
            preIndex++;

            if (preIndex >= preOrder.Length)
                return currNode;

            currNode.LeftNode = BuildTreeFromPreOrderHeler(preOrder, ref preIndex, preOrder[preIndex], minVal, key);
            currNode.RightNode = BuildTreeFromPreOrderHeler(preOrder, ref preIndex, preOrder[preIndex], key, maxVal);

            return currNode;
        }

        // http://www.geeksforgeeks.org/construct-a-binary-search-tree-from-given-postorder/
        public TreeNode BuildTreeFromPostOrderRecursive(int[] postOrder)
        {
            int postIndex = postOrder.Length - 1;
            return BuildTreeFromPostOrderHeler(postOrder, ref postIndex, postOrder[postIndex], int.MinValue, int.MaxValue);
        }

        private TreeNode BuildTreeFromPostOrderHeler(int[] postOrder, ref int postIndex, int key, int minVal, int maxVal)
        {
            if (postIndex < 0 || key <= minVal || key >= maxVal)
                return null;

            TreeNode currNode = new TreeNode(key);
            postIndex--;

            if (postIndex <= 0)
                return currNode;

            currNode.RightNode = BuildTreeFromPostOrderHeler(postOrder, ref postIndex, postOrder[postIndex], key, maxVal);
            currNode.LeftNode = BuildTreeFromPostOrderHeler(postOrder, ref postIndex, postOrder[postIndex], minVal, key);
            
            return currNode;
        }

        // https://www.geeksforgeeks.org/construct-bst-given-level-order-traversal/

        // Use a queue to store element in the farm NodeInfo which intern stores TreeNode, MinVal, MaxVal.
        // For Root initially element zero and int.MinVal and int.MaxVal and,
        // For a Left  Child,  minVal will be its parent’s minVal   and maxVal will be the parent's nodeVal.
        // For a Right Child,  minVal will be the parent's nodeVal  and maxVal will be its parent’s maxVal.
        public class NodeInfo
        {
            public TreeNode TreeNode { get; set; }

            public int MinVal { get; set; }

            public int MaxVal { get; set; }
        }

        public TreeNode BuildTreeFromLevelOrderIterative(int[] levelOrder)
        {
            if (levelOrder == null || levelOrder.Length == 0)
                return null;

            Queue<NodeInfo> nodeInfoQ = new Queue<NodeInfo>();

            NodeInfo prntNodeInfo = new NodeInfo()
            {
                TreeNode = new TreeNode(levelOrder[0]),
                MaxVal = int.MaxValue,
                MinVal = int.MinValue
            };

            nodeInfoQ.Enqueue(prntNodeInfo);

            TreeNode rootNode = prntNodeInfo.TreeNode;
            NodeInfo chldNodeInfo;
            
            int childVal = 0;

            for(int currIndx = 1; currIndx != levelOrder.Length;)
            {
                prntNodeInfo = nodeInfoQ.Dequeue();
                childVal = levelOrder[currIndx];

                if (currIndx < levelOrder.Length && childVal < prntNodeInfo.TreeNode.NodeValue && childVal > prntNodeInfo.MinVal)
                {
                    chldNodeInfo = new NodeInfo();
                    chldNodeInfo.TreeNode = new TreeNode(childVal);
                    chldNodeInfo.MinVal = prntNodeInfo.MinVal;
                    chldNodeInfo.MaxVal = prntNodeInfo.TreeNode.NodeValue;

                    nodeInfoQ.Enqueue(chldNodeInfo);
                    prntNodeInfo.TreeNode.LeftNode = chldNodeInfo.TreeNode;
                    currIndx++;
                }

                childVal = levelOrder[currIndx];

                if (currIndx < levelOrder.Length && childVal > prntNodeInfo.TreeNode.NodeValue && childVal < prntNodeInfo.MaxVal)
                {
                    chldNodeInfo = new NodeInfo();
                    chldNodeInfo.TreeNode = new TreeNode(childVal);
                    chldNodeInfo.MinVal = prntNodeInfo.TreeNode.NodeValue;
                    chldNodeInfo.MaxVal = prntNodeInfo.MaxVal;

                    nodeInfoQ.Enqueue(chldNodeInfo);
                    prntNodeInfo.TreeNode.RightNode = chldNodeInfo.TreeNode;
                    currIndx++;
                }
            }

            return rootNode;
        }

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
        public string BuildStringFromTree(TreeNode currentNode)
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