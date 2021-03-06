﻿using System;
using DataStructuresAndAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class BinaryTreeTests : TestBase
    {
        TreeNode rootNode9;
        TreeNode rootNode15;
        BinaryTreeOperations btOperations = new BinaryTreeOperations();

        public BinaryTreeTests()
        {
            rootNode9 = btOperations.BuildTreeFromPreAndInOrder(preOrder9, inOrder9);
            rootNode15 = btOperations.BuildTreeFromPreAndInOrder(preOrder15, inOrder15);
        }

        public int[] InOrder9 { get => inOrder9; set => inOrder9 = value; }

        [TestMethod]
        public void IsBalancedTest()
        {
            bool result = btOperations.IsBalancedIterative(rootNode9);
        }

        [TestMethod]
        public void BuildTreeFromInAndLevelOrderTests()
        {
            int[] inOrder = { 4, 8, 10, 12, 14, 20, 22 };
            int[] levelOrder = { 20, 8, 22, 4, 12, 10, 14 };
            //BuildTreeFromInAndLevelOrderTest(levelOrder, inOrder);

            //BuildTreeFromInAndLevelOrderTest(levelOrder9, inOrder9);
            //BuildTreeFromInAndLevelOrderTest(levelOrder15, inOrder15);
            BuildTreeFromInAndLevelOrderTest(levelOrder92, inOrder92);
        }

        public void BuildTreeFromInAndLevelOrderTest(int[] levelOrder, int[] inOrder)
        {
            TreeNode tNode = btOperations.BuildTreeFromInAndLevelOrder(levelOrder, inOrder, 0, inOrder.Length - 1);

            string result = btOperations.InOrderDisplay(tNode);
            DisplayOutput(result);

            int[] resultArr = ToArray(result);
            Assert.AreEqual(true, AreArraysEqual(inOrder, resultArr));
        }

        [TestMethod]
        public void ConstructFullCompleteTreeTest()
        {
            int preindex = 0;

            int[] pre = { 1, 2, 4, 8, 9, 5, 3, 6, 7 };
            int[] post = { 8, 9, 4, 5, 2, 6, 7, 3, 1 };

            TreeNode root = btOperations.BuildFullCompleteTree(pre, post, 0, pre.Length - 1, ref preindex);
            Console.WriteLine("Inorder traversal of the constructed tree:");
        }

        [TestMethod]
        public void ConstructSpecialTreeTest()
        {
            int index = 0;
            int[] preNums = new int[] { 10, 30, 20, 5, 15 };
            char[] preLN = new char[] { 'N', 'N', 'L', 'L', 'L' };

            TreeNode treeNode = new TreeNode();
            TreeNode mynode = btOperations.BuildSpecialTree(preNums, preLN, ref index, treeNode);
        }

        [TestMethod]
        public void FindModeTest()
        {
            int[] modes = btOperations.FindMode(rootNode9);

            foreach (int mode in modes)
            {
                TestContext.WriteLine(" " + mode);
            }
        }
    }
}