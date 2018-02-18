using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms._4._0___Trees
{
    // https://github.com/mission-peace/interview/blob/master/src/com/interview/tree/FenwickTree.java
    // https://www.geeksforgeeks.org/binary-indexed-tree-range-update-range-queries/
    /**
     * A Fenwick tree or binary indexed tree is a data structure providing efficient methods
     * for calculation and manipulation of the prefix sums of a table of values.
     * 
     * Space complexity for fenwick tree is O(n)
     * Time complexity to create fenwick tree is O(nlogn)
     * Time complexity to update value is O(logn)
     * Time complexity to get prefix sum is O(logn)
     * 
     * References
     * http://www.geeksforgeeks.org/binary-indexed-tree-or-fenwick-tree-2/
     * https://www.topcoder.com/community/data-science/data-science-tutorials/binary-indexed-trees/
     * http://en.wikipedia.org/wiki/Fenwick_tree
     */
    public class FenwickTree
    {
        // Creating tree is like updating Fenwick tree for every value in array        
        public int[] CreateTree(int[] input)
        {
            int[] binaryIndexedTree = new int[input.Length + 1];

            for (int indx = 1; indx <= input.Length; indx++)
            {
                UpdateBinaryIndexedTree(binaryIndexedTree, input[indx - 1], indx);
            }

            return binaryIndexedTree;
        }

        // Start from index + 1 if you updating index in original array. 
        // Keep adding this value for next node till you reach outside range of tree

        public void UpdateBinaryIndexedTree(int[] binaryIndexedTree, int val, int index)
        {
            while (index < binaryIndexedTree.Length)
            {
                binaryIndexedTree[index] += val;
                index = GetNext(index);
            }
        }

        // Start from index + 1 if you want prefix sum 0 to index. Keep adding value till you reach 0
        public int GetSum(int[] binaryIndexedTree, int index)
        {
            index = index + 1;
            int sum = 0;

            while (index > 0)
            {
                sum += binaryIndexedTree[index];
                index = GetParent(index);
            }

            return sum;
        }        

        /** To get parent
         * 1) 2's complement of index minus of index
         * 2) AND this with index
         * 3) Subtract that from index     */

        private int GetParent(int index)
        {
            return index - (index & -index);
        }

        /**
         * To get next
         * 1) 2's complement of index minus of index
         * 2) AND this with index
         * 3) Add it to index
         */

        private int GetNext(int index)
        {
            return index + (index & -index);
        }

        public static void FenwickTreeTest()
        {
            int[] input = { 1, 2, 3, 4, 5, 6, 7 };
            FenwickTree ft = new FenwickTree();

            int[] binaryIndexedTree = ft.CreateTree(input);

            Console.WriteLine("assert 1 == " + ft.GetSum(binaryIndexedTree, 0));
            Console.WriteLine("assert 1 == " + ft.GetSum(binaryIndexedTree, 1));
            Console.WriteLine("assert 1 == " + ft.GetSum(binaryIndexedTree, 2));
            Console.WriteLine("assert 1 == " + ft.GetSum(binaryIndexedTree, 3));
            Console.WriteLine("assert 1 == " + ft.GetSum(binaryIndexedTree, 4));
            Console.WriteLine("assert 1 == " + ft.GetSum(binaryIndexedTree, 5));
            Console.WriteLine("assert 1 == " + ft.GetSum(binaryIndexedTree, 6));
        }
    }
}