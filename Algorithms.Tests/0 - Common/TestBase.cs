using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Algorithms.Tests
{
    public class TestBase
    {
        public int[] preOrder9 = new int[] { 6, 4, 2, 1, 3, 5, 8, 7, 9 };
        public  int[] inOrder9 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public  int[] postOrder9 = new int[] { 1, 3, 2, 5, 4, 7, 9, 8, 6 };
        public  int[] levelOrder9 = new int[] { 6, 4, 8, 2, 5, 7, 9, 1, 3 };

        public  int[] preOrder15 = new int[] { 8, 6, 4, 2, 1, 3, 5, 7, 12, 10, 9, 11, 14, 13, 15 };
        public  int[] inOrder15 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        public  int[] postOrder15 = new int[] { 1, 3, 2, 5, 4, 7, 6, 9, 11, 10, 13, 15, 14, 12, 8 };
        public  int[] levelOrder15 = new int[] { 8, 6, 12, 4, 7, 10, 14, 2, 5, 9, 11, 13, 15, 1, 3 };

        public  int[] inOrder92 = new int[] { 1, 3, 4, 5, 6, 7, 8, 10, 12 };
        public  int[] levelOrder92 = new int[] { 7, 4, 12, 3, 6, 8, 1, 5, 10 };
        public  int[] preOrder93 = new int[] { 5, 2, 1, 3, 4, 7, 6, 8, 9 };

        public TestContext TestContext { get; set; }

        public void DisplayOutput(string message)
        {
            Debug.WriteLine(message);
        }

        public int[] ToArray(string message)
        {
            string[] delim = { " " };

            string[] items = message.Split(delim, StringSplitOptions.RemoveEmptyEntries);

            int[] array = new int[items.Length];

            for (int indx = 0; indx < items.Length; indx++)
            {
                if (string.IsNullOrWhiteSpace(items[indx]))
                    continue;

                array[indx] = Convert.ToInt32(items[indx]);
            }

            return array;
        }

        public bool AreArraysEqual(int[] array1, int[] array2)
        {
            for (int indx = 0; indx < array1.Length; indx++)
            {
                if (array1[indx] != array2[indx])
                {
                    Assert.Fail("Values are not matching Val 1 " + array1[indx] + " Val 2 " + array2[indx]);
                    return false;
                }
            }

            return true;
        }

    }
}
