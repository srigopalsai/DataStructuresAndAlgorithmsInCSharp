using System;
using DataStructuresAndAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class BinarySearchTreeTests : TestBase
    {
        TreeNode rootNode9;
        TreeNode rootNode15;
        BinarySearchTreeOperations bstOperations = new BinarySearchTreeOperations();

        int[] preOrder9 = new int[] { 6, 4, 2, 1, 3, 5, 8, 7, 9 };
        int[] preOrder92 = new int[] { 5, 2, 1, 3, 4, 7, 6, 8, 9 };
        int[] inOrder9 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] postOrder9 = new int[] { 1, 3, 2, 5, 4, 7, 9, 8, 6 };

        int[] preOrder15 = new int[] { 8, 6, 4, 2, 1, 3, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
        int[] inOrder15 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        int[] postOrder15 = new int[] { 1, 3, 2, 5, 4, 7, 6, 9, 11, 10, 13, 15, 14, 12, 8 };

        public BinarySearchTreeTests()
        {
            rootNode9 = bstOperations.ConstructTreeByInOrder(inOrder9);
            rootNode15 = bstOperations.ConstructTreeByInOrder(inOrder15);
        }

        [TestMethod]
        public void IsValidPreorderTraversalTest()
        {
            int[] pre1 = new int[] { 40, 30, 35, 80, 100 };
            int n = pre1.Length;
            bool result = bstOperations.IsValidPreorderTraversal(pre1);

            int[] pre2 = new int[] { 40, 30, 35, 20, 80, 100 };
            int n1 = pre2.Length;
            result = bstOperations.IsValidPreorderTraversal(pre1);

            if (result == true)
            {
                Console.WriteLine("CanRepresentBST true");
            }
            else
            {
                Console.WriteLine("CanRepresentBST false");
            }
        }

        [TestMethod]
        public int LowestCommonAncestorTest(int NodeValue1, int NodeValue2)
        {
            TreeNode CommonAncestorNode = bstOperations.LowestCommonAncestorIteration(rootNode9, NodeValue1, NodeValue2);
            //TreeNode CommonAncestorNode = LowestCommonAncestorLoop(RootdNode, NodeValue1, NodeValue2);

            int CommonAncestorValue = 0;
            if (CommonAncestorNode != null)
            {
                CommonAncestorValue = CommonAncestorNode.NodeValue;
            }

            return CommonAncestorValue;
        }

        [TestMethod]
        public void ConstructTreeByInOrderTest()
        {
            TreeNode tNode = bstOperations.ConstructTreeByInOrder(inOrder9);

            string result = bstOperations.PreOrderIterative(tNode);
            DisplayOutput(result);
            Console.WriteLine("Inorder traversal of the constructed tree is ..TODO");
        }

        [TestMethod]
        public void ConstructTreeByPreOrderTest()
        {
            int index = 0;
            TreeNode tNode = bstOperations.ConstructTreeByPreOrderHeler(preOrder92, ref index, preOrder92[0], int.MinValue, int.MaxValue);

            string result = bstOperations.InOrderDisplayIterative(tNode);
            DisplayOutput(result);
            Console.WriteLine("Inorder traversal of the constructed tree is ..TODO");
        }
    }
}