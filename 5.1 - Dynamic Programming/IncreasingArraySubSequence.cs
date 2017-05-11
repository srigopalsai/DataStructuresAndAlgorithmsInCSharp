using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://www.dsalgo.com/2013/03/back-to-content-increasing-array.html

    Find all the subsequences of the array which has the elements in increasing order. 
    B is a subsequence of array A if B can be formed by removing some elements from the array A without disturbing the order of elements. 
    
    E.g. {2,5,6,1,3} is the input array, Then {2,5}, {2,6}, {2,6,1}, {2,1,3} are some of its subsequences. 
    In these {2,5}, {2,6} are increasing subsequences
    
    Using memorization.
    Then the complexity is O(n*k). The term k is the total possible subsequeces. Which is of the order of 2^n. 
    So in upper bound term it is O(n*2^n).
    But this complexity will only arises when all the subsequences are increasing subsequences.
    */
    partial class DynamicProgrammingSamples
    {
//public static void IncreasingArraySubSequence()
//{
//        int[] input = { 2, 5, 6, 1, 3 };
//  int length = input.Length;

 //   ArrayList < ArrayList < int > > table = new ArrayList < ArrayList < int > >();

 // for (int i = 0; i < length; ++i)
 // {
 //  ArrayList < ArrayList < Integer > > tempTable = new ArrayList < ArrayList < Integer > >();
 //  for (ArrayList < Integer > j : table)
 //  {
 //   if (j.get(j.size() - 1) <= input[i])
 //   {
 //    ArrayList temp = new ArrayList();
 //    temp.addAll(j);
 //    temp.add(input[i]);
 //    tempTable.add(temp);
 //   }
 //  }
 //  table.addAll(tempTable);
 //  ArrayList < Integer > temp = new ArrayList < Integer >();
 //  temp.add(input[i]);
 //  table.add(temp);
 // }

 // // output
 // for (ArrayList < Integer > i : table)
 // {
 //  for (Integer j : i)
 //  {
 //   System.out.print(j + ", ");
 //  }
 //  Console.WriteLine();
 // }
 //}


    }
}
