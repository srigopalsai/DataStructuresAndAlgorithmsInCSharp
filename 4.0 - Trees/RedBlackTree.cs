using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    //Self Balanced Binary Search Tree: http://en.wikipedia.org/wiki/Red-black_tree
    /*      Average       Worst case 

    Space   O(n)        O(n) 
    Time:
    Search  O(log n)    O(log n)
    Insert  O(log n)    O(log n)
    Delete  O(log n)    O(log n) 
    
    1. A node is either red or black.
    2. The root is black. (This rule is sometimes omitted. Since the root can always be changed from red to black, but not necessarily vice-versa, this rule has little effect on analysis.)
    3. All leaves (NIL) are black. (All leaves are same color as the root.)
    4. Every red node must have two black child nodes.
    5. Every path from a given node to any of its descendant leaves contains the same number of black nodes.

    */
    class RedBlackTree
    {
    }
}
