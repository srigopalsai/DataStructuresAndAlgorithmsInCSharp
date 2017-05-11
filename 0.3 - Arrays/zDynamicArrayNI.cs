using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/Dynamic_array
    A dynamic array, growable array, resizable array, dynamic table, mutable array, or array list is a random access, 
        variable-size list data structure that allows elements to be added or removed. 
    It is supplied with standard libraries in many modern mainstream programming languages.

    A dynamic array is not the same thing as a dynamically allocated array, which is a fixed-size array whose size is fixed when the array is allocated.
    Although a dynamic array may use such a fixed-size array as a back end.[1]

    function insertEnd(dynarray a, element e)
    if (a.size = a.capacity)
        // resize a to twice its current capacity:
        a.capacity ← a.capacity * 2  
        // (copy the contents to the new memory location here)
    a[a.size] ← e
    a.size ← a.size + 1
    */
    partial class ArraySamples
    {
    }
}
