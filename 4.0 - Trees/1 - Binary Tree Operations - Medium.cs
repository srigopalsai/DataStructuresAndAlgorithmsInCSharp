using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public partial class BinaryTreeOperations
    {
        // Medium 654 https://leetcode.com/submissions/detail/120667189/
        //public TreeNode constructMaximumBinaryTree(int[] nums)
        //{
        //    if (nums == null || nums.Length == 0)
        //        return null;

        //    Queue<TreeNode> st = new Queue<TreeNode>();
        //    foreach (int num in nums)
        //    {
        //        TreeNode cur = new TreeNode(num);

        //        while (!st.isEmpty() && st.peekLast().val < num)
        //        {
        //            cur.LeftNode = st.removeLast();
        //        }

        //        if (!st.isEmpty())
        //            st.peekLast().right = cur;

        //        st.addLast(cur);
        //    }

        //    return st.peekFirst();
        //}
    }
}
