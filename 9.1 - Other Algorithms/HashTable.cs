using System;
using System.Collections;

namespace DataStructuresAndAlgorithms
{

    /*
    Consider the post man delivering the post in a 100 floor apt. 
    Collection Techniques:
    
    1. Lenear Probing:

    If the assigned index or suitable index is not empty then it will assing the next available location.
    If 1 collision occurs then there are chances that another collision is called clustering. This is a serious draw back.
    In worst case insertion, deletion, seach operations becomes O(N)
    
    2. Seperate Chaining:
    
    Follow seperate chain with linked list in each location. O (N/k)

    Tips to reduce the collision:
    Choose good hash technique or hash function to generate the unique hash key.
    Make use of the info provided by the key.
    Uniformly distribute the output across the table.


    Hash Function Techniques:

    1. Division ( Use mod function )
    2. Folding (Shift Folding / Boundary Folding)
    3. Mid Square Function
    4. Extraction
    5. Radix Transformation
    http://www.youtube.com/watch?v=4IMwaHVTZ28

    http://www.youtube.com/watch?v=h2d9b_nEzoA
    http://www.youtube.com/watch?v=eUJxyfAewxs
    http://www.youtube.com/watch?v=UPo-M8bzRrc

    In C# For very large Hashtable objects, we can increase the maximum capacity to 2 billion elements on a 64-bit system by setting the enabled attribute of the gcAllowVeryLargeObjects configuration element to true in the run-time environment.
    
    The foreach statement of the C# language (For Each in Visual Basic) requires the type of each element in the collection. S
    ince each element of the Hashtable is a key/value pair, the element type is not the type of the key or the type of the value. 
        
    foreach(DictionaryEntry de in myHashtable)
    {
        // ...
    }

    The foreach statement is a wrapper around the enumerator, which only allows reading from, not writing to, the collection.
    Because serializing and deserializing an enumerator for a Hashtable can cause the elements to become reordered, it is not possible to continue enumeration without calling the Reset method. 


    */
  
    class HashTableExample
    {
        public static void RunDemo()
        {
            // Create a new hash table. 
            //
            Hashtable openWith = new Hashtable();

            // There are no duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is already in the hash table. 
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is the default property, so we can omit its name when accessing elements. 
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            // The default Item property can be used to change the value associated with a key.
            openWith["rtf"] = "winword.exe";
            Console.WriteLine("For key = \"rtf\", value = {0}.", openWith["rtf"]);

            // If a key does not exist, setting the default Item property for that key adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // ContainsKey can be used to test keys before inserting them. 
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}", openWith["ht"]);
            }

            // Use foreach to enumerate hash table elements the elements are retrieved as KeyValuePair objects.
            Console.WriteLine();
            foreach (DictionaryEntry de in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", de.Key, de.Value);
            }

            // To get the values alone, use the Values property.
            ICollection valueColl = openWith.Values;

            // The elements of the ValueCollection are strongly typed with the type that was specified for hash table values.
            Console.WriteLine();
            foreach (string s in valueColl)
            {
                Console.WriteLine("Value = {0}", s);
            }

            // To get the keys alone, use the Keys property.
            ICollection keyColl = openWith.Keys;

            // The elements of the KeyCollection are strongly typed with the type that was specified for hash table keys.
            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }

            // Use the Remove method to remove a key/value pair by using its key.
            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }
        }
    }

    /* This code example produces the following output:

    An element with Key = "txt" already exists.
    For key = "rtf", value = wordpad.exe.
    For key = "rtf", value = winword.exe.
    Value added for key = "ht": hypertrm.exe

    Key = dib, Value = paint.exe
    Key = txt, Value = notepad.exe
    Key = ht, Value = hypertrm.exe
    Key = bmp, Value = paint.exe
    Key = rtf, Value = winword.exe
    Key = doc, Value = winword.exe

    Value = paint.exe
    Value = notepad.exe
    Value = hypertrm.exe
    Value = paint.exe
    Value = winword.exe
    Value = winword.exe

    Key = dib
    Key = txt
    Key = ht
    Key = bmp
    Key = rtf
    Key = doc

    Remove("doc")
    Key "doc" is not found.

    */
}
