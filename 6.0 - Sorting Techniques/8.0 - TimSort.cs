using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===========================================================================================================================================================================================

    Timsort is a hybrid sorting algorithm, derived from merge sort and insertion sort, designed to perform well on many kinds of real-world data. 
    It was invented by Tim Peters in 2002 for use in the Python programming language

    The algorithm finds subsets of the data that are already ordered, and uses that knowledge to sort the remainder more efficiently. 
    This is done by merging an identified subset, called a run, with existing runs until certain criteria are fulfilled

    ===========================================================================================================================================================================================
    
    Worst case       : O(n log n)
    Best case        : O(n) 
    Average case     : O(n log n) 
    Worst case Space : O(n)

    ===========================================================================================================================================================================================
    
    http://en.wikipedia.org/wiki/Timsort
    http://stackoverflow.com/questions/11724879/given-a-sorted-array-with-a-few-numbers-in-between-reversed-how-to-sort-it?rq=1

    ===========================================================================================================================================================================================
    */
    class SortingAlgorithms
    {
        public void TimSort()
        { }
    }
}
