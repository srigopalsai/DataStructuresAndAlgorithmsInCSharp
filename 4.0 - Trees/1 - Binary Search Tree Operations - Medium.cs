using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public partial class BinarySearchTreeOperations
    {
        // https://www.geeksforgeeks.org/construct-bst-from-given-preorder-traversa/

        public TreeNode ConstructTreeByPreOrder(int[] preOrder, ref int preIndex, int key, int min, int max, int preLength)
        {
            if (preIndex >= preLength)
                return null;

            TreeNode root = null;

            // If current element of pre[] is in range, then only it is part of current subtree
            if (key <= min || key >= max)
                return root;

            // if (key > min && key < max)

            // Allocate memory for root of this subtree and increment *preIndex
            root = new TreeNode(key);
            preIndex = preIndex + 1;

            if (preIndex >= preLength)
                return root;

            //if (preIndex < size)

            // Contruct the subtree under root
            // All TreeNodes which are in range {min .. key} will go in left
            // subtree, and first such TreeNode will be root of left subtree.
            root.LeftNode = ConstructTreeByPreOrder(preOrder, ref preIndex, preOrder[preIndex], min, key, preLength);

            // All TreeNodes which are in range {key..max} will go in right
            // subtree, and first such TreeNode will be root of right subtree.
            root.RightNode = ConstructTreeByPreOrder(preOrder, ref preIndex, preOrder[preIndex], key, max, preLength);

            return root;
        }
              
        // http://www.geeksforgeeks.org/construct-a-binary-search-tree-from-given-postorder/

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

        public string Tree2str(TreeNode currentNode)
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