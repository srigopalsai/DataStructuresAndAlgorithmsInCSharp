using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataStructuresAndAlgorithms
{
    /* 
    http://en.wikipedia.org/wiki/Radix_tree

    A Trie, or Prefix tree, Radix Tree, Digital Treaa.
    Is an ordered tree data structure that is used to store an associative array where the keys are strings. 
    Unlike a binary search tree, no node in the tree stores the key associated with that node; instead, its position in the tree shows what key it is associated with.
    All the descendants of any one node have a common prefix of the string associated with that node, and the root is associated with the empty string. 
    Values are normally not associated with every node, only with leaves and some inner nodes that happen to correspond to keys of interest.

    Bitwise Tries are much the same as a normal character based trie except that individual bits are used to traverse what effectively becomes a form of binary tree. Generally, implementations use a special CPU instruction to very quickly find the first set bit in a fixed length key (e.g. GCC's __builtin_clz() intrinsic)

    When the trie is mostly static, i.e. all insertions or deletions of keys from a prefilled trie are disabled and only lookups are needed, and when the trie nodes are not keyed by node specific data (or if the node's data is common) it is possible to compress the trie representation by merging the common branches

    https://www.youtube.com/watch?v=NdfIfxTsVDo
    */
    class PrefixTree
    {
        static void TestTrie()
        {
            Trie tree = new Trie();

            string s = @"   In computer science, a trie, or prefix tree, 
                            is an ordered tree data structure that is used to 
                            store an associative array where the keys are strings. 
                            Unlike a binary search tree, no node in the tree 
                            stores the key associated with that node; 
                            instead, its position in the tree shows what key 
                            it is associated with. All the descendants 
                            of any one node have a common prefix of the string 
                            associated with that node, and the root is associated 
                            with the empty string. Values are normally not associated 
                            with every node, only with leaves and some inner nodes 
                            that happen to correspond to keys of interest. ";

            foreach (string str in s.Replace("\r\n", "").Split(' ', ',', ';', '.'))
            {
                if (str.Length > 0)
                {
                    tree.Add(str);
                }
            }

            foreach (string word in tree.Find("tr**"))
            {
                Console.WriteLine(word);
            }

        }
    }

    class TrieNode
    {
        private TrieNode[] _nodes;
        private bool _isEnd;

        public TrieNode()
        {
            _nodes = new TrieNode[26];
        }

        private int Index(char c)
        {
            if (c < 'a' || c > 'z') throw new ArgumentOutOfRangeException();
            return (int)(c - 'a');
        }

        public bool IsEnd { get { return _isEnd; } set { _isEnd = value; } }
     
        public IEnumerable<TrieNode> Nodes { get { return _nodes; } }

        public TrieNode this[char c] { get { return _nodes[Index(c)]; } }

        public TrieNode AddChild(char c)
        {
            TrieNode node = this[c];
            if (node == null)
            {
                node = new TrieNode();
                _nodes[Index(c)] = node;
            }
            return node;
        }
    }

    class Trie
    {
        private TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Add(string s)
        {
            TrieNode node = _root;
            foreach (char c in s.ToLower())
            {
                node = node.AddChild(c);
            }
            node.IsEnd = true;
        }

        public bool Contains(string s)
        {
            TrieNode node = _root;
            foreach (char c in s.ToLower())
            {
                node = node[c];
                if (node == null)
                {
                    return false;
                }
            }
            return node.IsEnd;
        }

        public List<string> Find(string mask)
        {
            return Find(mask, _root);
        }

        private List<string> Find(string mask, TrieNode node)
        {
            char c = mask[0];
            mask = mask.Substring(1);
            List<string> list = new List<string>();
            if (c == '*')
            {
                c = 'a';
                foreach (TrieNode child in node.Nodes)
                {
                    if (child != null)
                    {
                        if (mask.Length == 0)
                        {
                            if (child.IsEnd)
                            {
                                list.Add(c.ToString());
                            }
                        }
                        else
                        {
                            foreach (string s in Find(mask, child))
                            {
                                list.Add(c.ToString() + s);
                            }
                        }
                    }
                    c++;
                }
            }
            else
            {
                TrieNode child = node[c];
                if (child != null)
                {
                    if (mask.Length == 0)
                    {
                        if (child.IsEnd)
                        {
                            list.Add(c.ToString());
                        }
                    }
                    else
                    {
                        foreach (string s in Find(mask, child))
                        {
                            list.Add(c.ToString() + s);
                        }
                    }
                }
            }
            return list;
        }
    }
}
/*
public class Trie
{

    // we are only dealing with keys with chars 'a' to 'z'
    final static int ALPHABET_SIZE = 26;
    final static int NON_VALUE = -1;

    class TrieNode
    {
        boolean isLeafNode;
        int value;

        TrieNode[] children;

        TrieNode(boolean isLeafNode, int value)
        {
            this.value = value;
            this.isLeafNode = isLeafNode;
            children = new TrieNode[ALPHABET_SIZE];
        }

        public void markAsLeaf(int value)
        {
            this.isLeafNode = true;
            this.value = value;
        }
    }

    TrieNode root;
    Trie()
    {
        this.root = new TrieNode(false, NON_VALUE);
    }

    private int getIndex(char ch)
    {
        return ch - 'a';
    }

    public int search(String key)
    {
        // null keys are not allowed
        if (key == null)
        {
            return NON_VALUE;
        }

        TrieNode currentNode = this.root;
        int charIndex = 0;

        while ((currentNode != null) && (charIndex < key.length()))
        {
            int childIndex = getIndex(key.charAt(charIndex));

            if (childIndex < 0 || childIndex >= ALPHABET_SIZE)
            {
                return NON_VALUE;
            }
            currentNode = currentNode.children[childIndex];

            charIndex += 1;

        }

        if (currentNode != null)
        {
            return currentNode.value;
        }

        return NON_VALUE;
    }

    public void insert(String key, int value)
    {
        // null keys are not allowed
        if (key == null) return;

        key = key.toLowerCase();

        TrieNode currentNode = this.root;
        int charIndex = 0;

        while (charIndex < key.length())
        {
            int childIndex = getIndex(key.charAt(charIndex));

            if (childIndex < 0 || childIndex >= ALPHABET_SIZE)
            {
                Console.WriteLine("Invalid Key");
                return;
            }

            if (currentNode.children[childIndex] == null)
            {
                currentNode.children[childIndex] = new TrieNode(false, NON_VALUE);
            }

            currentNode = currentNode.children[childIndex];
            charIndex += 1;
        }

        // mark currentNode as leaf
        currentNode.markAsLeaf(value);
    }

    public static void main(String[] args)
    {
        Trie tr = new Trie();

        tr.insert("aab", 3);
        int value = tr.search("aab");

        Console.WriteLine(value);
    }
}
*/
