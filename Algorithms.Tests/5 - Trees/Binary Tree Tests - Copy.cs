using System;
using DataStructuresAndAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class BinarySearchTreeTests
    {
        TreeNode rootNode9;
        TreeNode rootNode15;
        BinarySearchTreeOperations bstOperations = new BinarySearchTreeOperations();

        int[] preOrder9 = new int[] { 6, 4, 2, 1, 3, 5, 8, 7, 9 };
        int[] inOrder9 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] postOrder9 = new int[] { 1, 3, 2, 5, 4, 7, 9, 8, 6 };

        int[] preOrder15 = new int[] { 8, 6, 4, 2, 1, 3, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
        int[] inOrder15 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        int[] postOrder15 = new int[] { 1, 3, 2, 5, 4, 7, 6, 9, 11, 10, 13, 15, 14, 12, 8 };

        public BinarySearchTreeTests()
        {
            rootNode9 = bstOperations.SortedArrayToBST(inOrder9);
            rootNode15 = bstOperations.SortedArrayToBST(inOrder15);
        }

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

    }
}