using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._6___Sorting_Techniques
{
    /*
    Bucket sort, or bin sort, is a sorting algorithm that works by partitioning an array into a number of buckets. Each bucket is then sorted individually, either using a different sorting algorithm, or by recursively applying the bucket sorting algorithm.
    It is a distribution sort, and is a cousin of radix sort in the most to least significant digit flavour. 
    Bucket sort is a generalization of pigeonhole sort.

    A common optimization is to put the unsorted elements of the buckets back in the original array first, then run insertion sort over the complete array.
    Because insertion sort's runtime is based on how far each element is from its final position, the number of comparisons remains relatively small, and the memory hierarchy is better exploited by storing the list contiguously in memory.


    http://www.bogotobogo.com/Algorithms/bucketsort.php
    https://www.youtube.com/watch?v=aaKNtxHgaq4
    */
    class BucketSortNI
    {
    }
}
