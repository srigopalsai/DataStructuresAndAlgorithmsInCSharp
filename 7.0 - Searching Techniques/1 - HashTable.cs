using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    Hashtable:
     * Is essentially a Key-Value-Pair collection where you define the key and the value then you can find the value by using the key.
     * It is synchronized. So it comes with its cost. Only one thread can access in one time.
     
    HashSet:
     * Allowes you to add a value, this value is unique and you do not define the key.
     * A HashSet implements ICollection and IEnumerable.
     * HashSet does not allow duplicate values.
     * HashSet<String> stateSet = new HashSet<String>();
                    stateSet.add ("CA");
                    stateSet.add ("NY");
        
    HashMap:
     * Is another data structure concept which is not supported by .net
     * There is performance benifit of HashSet <int> over List<int>. 
     * From usability point of view you should ask when to use HashTable over Dictnary and HashSet over List.

     * Like Hashtable it also accepts key value pair.
     * It allows null for both key and value.
     * It is unsynchronized. So come up with better performance
    http://www.algolist.net/Data_structures/Hash_table/Simple_example
    http://www.sanfoundry.com/java-program-implement-hash-tables/

    ===================================================================================================================================================================================================
    */
    public class HashTableDemo
    {
        HashSet<string> StringHashSet;
        
        HashTableDemo()
        {
            StringHashSet = new HashSet<string>();
        }
    }
    /*
    Space       Average case  O(n)[1]        Worst case  O(n) 
    Search      Average case  O(1)           Worst case  O(n) 
    Insert      Average case  O(1)           Worst case  O(n) 
    Delete      Average case  O(1)           Worst case  O(n) 

    Hashtable is A standard solution to the dictionary problem.
    
    1. Hash Key Generation
    2. Linear probing or Open addressing (duplicate keys resolving)

    http://www.algolist.net/Data_structures/Hash_table
    */
    /*
    public class HashEntry
    {
        private int key;
        private int value;

        HashEntry(int key, int value)
        {
            this.key = key;
            this.value = value;
        }

        public int getKey()
        {
            return key;
        }

        public int getValue()
        {
            return value;
        }
    }
    public class HashMap
    {
        private static int TABLE_SIZE = 128;
        HashEntry[] table;

        HashMap()
        {
            table = new HashEntry[TABLE_SIZE];

            for (int i = 0; i < TABLE_SIZE; i++)
            {
                table[i] = null;
            }
        }

        public int get(int key)
        {
            int hash = (key % TABLE_SIZE);

            while (table[hash] != null && table[hash].getKey() != key)
            {
                hash = (hash + 1) % TABLE_SIZE;
            }

            if (table[hash] == null)
            {
                return -1;
            }
            else
            {
                return table[hash].getValue();
            }
        }

        public void put(int key, int value)
        {
            int hash = (key % TABLE_SIZE);
            while (table[hash] != null && table[hash].getKey() != key)
            {
                hash = (hash + 1) % TABLE_SIZE;
            }
            //table[hash] = new HashEntry(key, value); 
        }
    }
     */ 
}