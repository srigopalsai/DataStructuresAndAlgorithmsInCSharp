using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    public partial class TreeDemo : Window
    {
        public TreeDemo()
        {
            List<int> intlst = new List<int>();
            
            InitializeComponent();
        }
        object obj = "Sai";
        object SaySai()
        {
            return obj;
        }

        private void BinarySearchTreeDemoButton_Click(object sender, RoutedEventArgs e)
        {
            object ob = SaySai();
           
            StringBuilder outputString = new StringBuilder();

            BinarySearchTreeOperations BinarySearchTreeDemoObject = new BinarySearchTreeOperations();

            TreeNode rootNode = CreateBSTTree1To9(BinarySearchTreeDemoObject);

            //CreateBSTTree1To15(BinarySearchTreeDemoObject);

            //BinarySearchTreeDemoObject.AddNodeToTreeWhile(-2147483648);
            //BinarySearchTreeDemoObject.AddNodeToTreeWhile(-2147483648);

            //BinarySearchTreeDemoObject.RecoverTree(BinarySearchTreeDemoObject.RootdNode);
            //outputString.Append(Environment.NewLine + "Recover Tree : " );
            
            outputString.Append(Environment.NewLine);
            outputString.Append(Environment.NewLine + "Breadth First Search Traversal : " + BinarySearchTreeDemoObject.BreadthFirstSearchUsingQueue(BinarySearchTreeDemoObject.RootdNode));
            outputString.Append(Environment.NewLine);

            outputString.Append(Environment.NewLine + "Pre Order Traversal                : " + BinarySearchTreeDemoObject.PreOrderDisplay());
            outputString.Append(Environment.NewLine + "Pre Order Traversal Iterative : " + BinarySearchTreeDemoObject.PreOrderIterative(BinarySearchTreeDemoObject.RootdNode));

            outputString.Append(Environment.NewLine);
            outputString.Append(Environment.NewLine + "In Order Traversal                 : " + BinarySearchTreeDemoObject.InOrderDisplay());
            outputString.Append(Environment.NewLine + "In Order Traversal Iterative  : " + BinarySearchTreeDemoObject.InOrderDisplayIterative(BinarySearchTreeDemoObject.RootdNode));
            
            outputString.Append(Environment.NewLine);            
            outputString.Append(Environment.NewLine + "Post Order Traversal                : " + BinarySearchTreeDemoObject.PostOrderDisplay());
            outputString.Append(Environment.NewLine + "Post Order Traversal Iterative : " + BinarySearchTreeDemoObject.PostOrderDisplayIterative(BinarySearchTreeDemoObject.RootdNode));

            outputString.Append(Environment.NewLine);  
            outputString.Append(Environment.NewLine + "Is BST - Using In Order Recursion : " + BinarySearchTreeDemoObject.IsBSTInOrderRecursion());
            
            outputString.Append(Environment.NewLine);
            outputString.Append(Environment.NewLine + "Min Height/Depth Of the Tree : " + BinarySearchTreeDemoObject.MinDepthOfTree(BinarySearchTreeDemoObject.RootdNode));
            outputString.Append(Environment.NewLine + "Min Height/Depth Of the Tree : " + BinarySearchTreeDemoObject.MinHeightOfTree());
            //outputString.Append(Environment.NewLine + "Max Height/Depth Of the Tree : " + BinarySearchTreeDemoObject.MaxDepthOfTree(BinarySearchTreeDemoObject.RootdNode));
            //outputString.Append(Environment.NewLine + "Max Height/Depth Of the Tree : " + BinarySearchTreeDemoObject.MaxHeightOfTree());

            outputString.Append(Environment.NewLine);
            outputString.Append(Environment.NewLine + "Is Tree Balanced :" + BinarySearchTreeDemoObject.IsTreeBalanced(BinarySearchTreeDemoObject.RootdNode));
            outputString.Append(Environment.NewLine);

            IList<IList<int>> zzitemsColl = BinarySearchTreeDemoObject.ZigzagLevelOrder();
            //BinarySearchTreeDemoObject.PrevNode = null;
            //BinarySearchTreeDemoObject.ReverseTree(BinarySearchTreeDemoObject.RootdNode);
            //outputString.Append(Environment.NewLine);
            //outputString.Append(Environment.NewLine + "In Order aftare Invert Tree :" + BinarySearchTreeDemoObject.InOrderDisplay());
            //outputString.Append(Environment.NewLine);

            //BinarySearchTreeDemoObject.PrevNode = null;
            //TreeNode listNode =  BinarySearchTreeDemoObject.ConvertToDLL(BinarySearchTreeDemoObject.RootdNode);

            //outputString.Append(Environment.NewLine);
            //outputString.Append(Environment.NewLine + "In Order aftare Invert Tree :" + BinarySearchTreeDemoObject.InOrderDisplay());
            //outputString.Append(Environment.NewLine);

            rootNode = BinarySearchTreeDemoObject.CreateTreeFromSLL();
            outputString.Append(Environment.NewLine + "CreateTreeFromSLL");

            //TreeNode listNode = BinarySearchTreeDemoObject.ConverToAdjustcentList(BinarySearchTreeDemoObject.RootdNode);
            //outputString.Append(Environment.NewLine);

            //TreeNode listNode = BinarySearchTreeDemoObject.ToAdjacencyList(BinarySearchTreeDemoObject.RootdNode);

            rootNode = BinarySearchTreeDemoObject.SortedArrayToBST(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            outputString.Append(Environment.NewLine);
            //BinarySearchTreeDemoObject.CreateTreeFromSLL();

            //TreeNode listNode = BinarySearchTreeDemoObject.ToAdjacencyList(BinarySearchTreeDemoObject.RootdNode);
            
            //outputString.Append(Environment.NewLine);
            //outputString.Append(Environment.NewLine + "Convert to Linked List In ZigZag :" + BinarySearchTreeDemoObject.ConvertToLinkedList(BinarySearchTreeDemoObject.RootdNode));
            //outputString.Append(Environment.NewLine);

            //bool result = BinarySearchTreeDemoObject.IsBST(BinarySearchTreeDemoObject.RootdNode);
            //outputString.Append(Environment.NewLine + Environment.NewLine + "Is BST ? " + result.ToString());

            outputString.Append(Environment.NewLine + "Min Value in tree : " + BinarySearchTreeDemoObject.FindMinValue());
            outputString.Append(Environment.NewLine + "Max Value in tree : " + BinarySearchTreeDemoObject.FindMaxValue());
            outputString.Append(Environment.NewLine + "Size of the tree : " + BinarySearchTreeDemoObject.SizeOfTree(BinarySearchTreeDemoObject.RootdNode));

            outputString.Append(Environment.NewLine + "Lowest Common Ancestor for 1,5 is : " + BinarySearchTreeDemoObject.LowestCommonAncestor(1, 5));
            outputString.Append(Environment.NewLine);

            //BinarySearchTreeDemoObject.RemoveNode(7);
            //outputString.Append(Environment.NewLine + Environment.NewLine + 
            //                                          "Node (7 - has right childs ) Removal result " + result.ToString());
            //outputString.Append(Environment.NewLine + "In Order Traversal : " + BinarySearchTreeDemoObject.InOrderDisplay());

            //result = BinarySearchTreeDemoObject.RemoveNode(9);
            //outputString.Append(Environment.NewLine + Environment.NewLine + 
            //                                          "Node (9 - has left childs ) Removal result " + result.ToString());
            //outputString.Append(Environment.NewLine + "In Order Traversal : " + BinarySearchTreeDemoObject.InOrderDisplay());

            //result = BinarySearchTreeDemoObject.RemoveNode(8);
            //outputString.Append(Environment.NewLine + Environment.NewLine + 
            //                                          "Node (8 - No childs ) Removal result " + result.ToString());
            //outputString.Append(Environment.NewLine + "In Order Traversal : " + BinarySearchTreeDemoObject.InOrderDisplay());

            //result = BinarySearchTreeDemoObject.RemoveNode(6);
            //outputString.Append(Environment.NewLine + Environment.NewLine + 
            //                                          "Node (6 - Has both left and right childs ) Removal result " + result.ToString());
            //outputString.Append(Environment.NewLine + "In Order Traversal : " + BinarySearchTreeDemoObject.InOrderDisplay());

            //Merge & Link Tree
            BinarySearchTreeOperations BinarySearchTreeDemoObject1 = new BinarySearchTreeOperations();
            BinarySearchTreeDemoObject1.AddNodeToTree(2);
            BinarySearchTreeDemoObject1.AddNodeToTree(1);
            BinarySearchTreeDemoObject1.AddNodeToTree(3);

            BinarySearchTreeOperations BinarySearchTreeDemoObject2 = new BinarySearchTreeOperations();
            BinarySearchTreeDemoObject2.AddNodeToTree(5);
            BinarySearchTreeDemoObject2.AddNodeToTree(4);
            BinarySearchTreeDemoObject2.AddNodeToTree(6);

            BinarySearchTreeOperations BinarySearchTreeDemoObject3 = new BinarySearchTreeOperations();
            BinarySearchTreeDemoObject3.RootdNode = BinarySearchTreeDemoObject3.Merge2BST(BinarySearchTreeDemoObject1.RootdNode, BinarySearchTreeDemoObject2.RootdNode);
            outputString.Append(Environment.NewLine + "Merge Successful : " + BinarySearchTreeDemoObject3.PreOrderDisplay());

            BinarySearchTreeOperations BinarySearchTreeDemoObject4 = new BinarySearchTreeOperations();
            BinarySearchTreeDemoObject4.RootdNode = BinarySearchTreeDemoObject3.Link2Trees(BinarySearchTreeDemoObject1.RootdNode, BinarySearchTreeDemoObject2.RootdNode);
            outputString.Append(Environment.NewLine + "Link Successful  : " + BinarySearchTreeDemoObject3.PreOrderDisplay());

            //BinaryTreeOperations btIsSymm = new BinaryTreeOperations();
            //btIsSymm.AddNodeToTree(2);
            //btIsSymm.AddNodeToTree(1);
            //btIsSymm.AddNodeToTree(3);
            //bool isSymmentric = btIsSymm.IsSymmetric(btIsSymm.RootdNode);

            MessageBox.Show(outputString.ToString());
        }

        private TreeNode CreateBSTTree1To9(BinarySearchTreeOperations BinarySearchTreeDemoObject)
        {
            BinarySearchTreeDemoObject.AddNodeToTree(6);
            BinarySearchTreeDemoObject.AddNodeToTree(4);
            BinarySearchTreeDemoObject.AddNodeToTree(8);
            BinarySearchTreeDemoObject.AddNodeToTree(2);
            BinarySearchTreeDemoObject.AddNodeToTree(5);
            BinarySearchTreeDemoObject.AddNodeToTree(7);
            BinarySearchTreeDemoObject.AddNodeToTree(9);
            BinarySearchTreeDemoObject.AddNodeToTree(1);
            BinarySearchTreeDemoObject.AddNodeToTree(3);

            return BinarySearchTreeDemoObject.RootdNode;
        }

        private TreeNode CreateBSTTree1To15(BinarySearchTreeOperations BinarySearchTreeDemoObject)
        {
            BinarySearchTreeDemoObject.AddNodeToTree(8);
            BinarySearchTreeDemoObject.AddNodeToTree(6);
            BinarySearchTreeDemoObject.AddNodeToTree(12);
            BinarySearchTreeDemoObject.AddNodeToTree(4);
            BinarySearchTreeDemoObject.AddNodeToTree(7);
            BinarySearchTreeDemoObject.AddNodeToTree(10);
            BinarySearchTreeDemoObject.AddNodeToTree(14);
            BinarySearchTreeDemoObject.AddNodeToTree(2);
            BinarySearchTreeDemoObject.AddNodeToTree(5);
            BinarySearchTreeDemoObject.AddNodeToTree(9);
            BinarySearchTreeDemoObject.AddNodeToTree(11);
            BinarySearchTreeDemoObject.AddNodeToTree(13);
            BinarySearchTreeDemoObject.AddNodeToTree(15);
            BinarySearchTreeDemoObject.AddNodeToTree(1);
            BinarySearchTreeDemoObject.AddNodeToTree(3);

            return BinarySearchTreeDemoObject.RootdNode;
        }

        private void BinaryTreeDemoButton_Click(object sender, RoutedEventArgs e)
        {
            TreeNode rootNode = CreateBinaryTree1();
            StringBuilder outputString = new StringBuilder();

            BinaryTreeOperations BinaryTreeDemoObject = new BinaryTreeOperations();
            BinaryTreeDemoObject.RootdNode = rootNode;
        }

        private TreeNode CreateBinaryTree1()
        {
            TreeNode rootNode = new TreeNode(9);
            rootNode.LeftNode = new TreeNode(3);
            rootNode.RightNode = new TreeNode(2);
            rootNode.LeftNode.LeftNode = new TreeNode(4);
            rootNode.LeftNode.RightNode = new TreeNode(1);
            rootNode.RightNode.RightNode = new TreeNode(6);

            return rootNode;
        }

        private void MedianOfNumbersStreamButton_Click(object sender, RoutedEventArgs e)
        {
            MedianOfIntegerStream mOfIS = new MedianOfIntegerStream();
            mOfIS.GetMedianTest();
        }

        private void MinMaxHeapDemoButton_Click(object sender, RoutedEventArgs e)
        {
            Trees.HeapOperations.HeapDemo heapDemo = new Trees.HeapOperations.HeapDemo();
            heapDemo.HeapTest();
        }
    }
}