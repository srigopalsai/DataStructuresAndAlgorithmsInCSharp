using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================

    Arrays should be in sorted order
    
    Worst case performance      O(log n) 
    Best case performance       O(1) 
    Average case performance    O(log n) 

    Worst case space complexity O(1)
    
    http://en.wikipedia.org/wiki/Binary_search_algorithm
        
    E.g.  Sorted List Contains. 1   2   3   4   5   6   7   8   9   10
    ElementToSearch 2.

    ============================================================================================================================================================================================================================
    
    Iteration 1:
    
    startPos = 0
    endPos = 10 
    midPos = 5      i.e 10 - 0 /2 + 0
    midElement = 6
    
    if  ElementToSearch < midElement
        endPos = midIndex--
    so endPos = 4

    Iteration 2:
     
    startPos = 0
    endPos = 4
    midPos = 2      i.e 4 - 0 /2 + 0
    midElement = 3
    if  ElementToSearch < midElement
        endPos = midIndex--
    so endPos = 4

    Binary Search is a type of dichotomic search that operates by selecting between two distinct alternatives (dichotomies) at each step

    Split/Slice/Segment.
   
    Time Calculation:

    t(n) = c + t (n/2)  + c + c + t (n/4)  .... ( Constant time for gettting mid element and checking it)
         = c + c + .... t(n/n)              How many contants time required.
         = c log n + t(1)                   Log n times of c required.

    ============================================================================================================================================================================================================================    
    */
    public partial class SearchingAlgorithms
    {
        public void BinarySearchTest()
        {
            int[] ArrayToSort = new int[] { 11, 22, 33, 44, 55, 66 };
            int resultPosition = BinarySearchArray(ArrayToSort, 11);

            MessageBox.Show("Position of 44 in array is " + resultPosition);

        }

        public int BinarySearchArray(int[] sortedList, int elementToSearch) 
        {
            int startPosition = 0;
            int endPosition = sortedList.Length - 1;

            while (startPosition < endPosition) 
            {
                // Split the array into 2.

                //Avoids overflow exception.
                //int midIndex = ((endPosition - startPosition) / 2) +startPosition; 

                int midIndex = ((endPosition + startPosition) / 2);               
                // Get the middle element from the array.
                int midElementValue = sortedList[midIndex]; 

                // Compare with mid element in the array
                if (elementToSearch > midElementValue) 
                {
                    //Found element in right half.
                    startPosition = ++midIndex; 
                } 
                else if (elementToSearch < midElementValue) 
                {
                    //Found element in left half.
                    endPosition = --midIndex; 
                } 
                else 
                { 
                    //Found the position.
                    return midIndex; 
                } 
            }             
            return -1; 
        }
    }
}