using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    http://stackoverflow.com/questions/4311694/maximize-the-rectangular-area-under-histogram?lq=1  
    http://stackoverflow.com/questions/4303813/find-the-row-representing-the-smallest-integer-in-row-wise-sorted-matrix?rq=1
    http://stackoverflow.com/a/4303939/2466650
    http://stackoverflow.com/questions/11446223/finding-complete-rectangles-enclosing-0?rq=1
    http://stackoverflow.com/questions/746082/how-to-find-list-of-possible-words-from-a-letter-matrix-boggle-solver?rq=1
    http://stackoverflow.com/questions/2478447/find-largest-rectangle-containing-only-zeros-in-an-n%c3%97n-binary-matrix?rq=1
    http://blog.csdn.net/arbuckle/article/details/710988
    http://www.informatik.uni-ulm.de/acm/Locals/2003/html/judge.html
    In a given binary matrix Find largest sub matrix which can be made by zeros and return its size.
    E.g.
    
    Input:
    
    1	1	1	1	1
    0	1	0	0	0
    0	1	0	0	0
    1	0	0	0	0
    1	0	0	0	1
    
    Output: 9

    Largest Rectangle in a Histogram.
    Has different solutions from O(N^2), O(N log N) and O(N) - Using Stacks.
    Brute Force - O(N^2)
    
    Dynamic Programming
    1 1 1 0 0 0
    0 0 0 0 0 0 0 0 0 1 1 1 1 1 0

    ======================================================================================================================================
    
    Dynamic programming:
    Is a method for solving complex problems by breaking them down into simpler subproblems.
    
    Need to test

    1 1 1 1 0 0 0 0 0 1 0 0 1 1 1
    0 1 1 1 1 1 0 0 0 1 0 0 1 1 0
    0 0 0 1 1 1 1 1 0 1 0 0 1 0 0
    0 0 0 0 0 1 1 1 1 1 0 0 0 0 0
    0 0 0 0 0 0 0 1 1 
    
    It makes possible to count the number of solutions without visiting them all. 
        Imagine backtracking values for the first row – what information would we require about the remaining rows, in order to be able to accurately count the solutions obtained for each first row value? 
    
    It takes far less time than naive methods that don't take advantage of the subproblem overlap (like depth-first search).
    The idea to solve a given problem, 
    we need to solve different parts of the problem (subproblems), then combine the solutions of the subproblems to reach an overall solution.

    When using a more naive method, many of the subproblems are generated and solved many times. 
    The dynamic programming approach seeks to solve each subproblem only once, thus reducing the number of computations: once the solution to a given subproblem has been computed, 
    it is stored or "memo-ized": the next time the same solution is needed, it is simply looked up. 
    This approach is especially useful when the number of repeating subproblems grows exponentially as a function of the size of the input.

    Dynamic programming algorithms are used for optimization (for example, finding the shortest path between two points, or the fastest way to multiply many matrices). 
    A dynamic programming algorithm will examine all possible ways to solve the problem and will pick the best solution. 
    Therefore, we can roughly think of dynamic programming as an intelligent, brute-force method that enables us to go through all possible solutions to pick the best one.
    
    http://en.wikipedia.org/wiki/Dynamic_programming

    http://stackoverflow.com/questions/19610071/naive-way-to-find-largest-block-in-a-rectangle-of-1s-and-0s/19610652#19610652
    http://www.bing.com/search?q=scan+line+algorithms&form=IE11TR&src=IE11TR&pc=SNJB
    http://www.informatik.uni-ulm.de/acm/Locals/2003/html/judge.html
    http://en.wikipedia.org/wiki/Block_matrix
    ======================================================================================================================================

    */
    partial class MatrixOperations
    {

    }
}
	   
/*

0	0	0	0	0
1	0	1	1	1
1	0	1	1	1
0	1	1	1	1
0	1	1	1	1

*/

//static int min(int a, int b, int c)
//{
//    return ((a<b)?((a<c)?a:c):((b<c)?b:c));
//}

//static int Largest_matrix(int[,] input, int[,] temp, int size)
//{
//    int i, j;

//    int max=0; // this variable stores maximum value 

//    /* last row values storing in temp*/
//    for (i = size - 1, j = 0; j < size; j++)
//    {
//        temp[i,j] = input[i,j] ^ 1;
//    }
//    /* last column values storing in temp */
//    for (i = 0, j = size - 1; i < size - 1; i++)
//    {
//        temp[i,j] = input[i,j] ^ 1;
//    }

//    for (i = size - 2; i >= 0; i--)
//    {
//        for (j = size - 2; j >= 0; j--)
//        {
//            if ((input[i,j] == 0) && !(input[i,j] ^ input[i + 1,j] ^ input[i + 1,j + 1] ^ input[i,j + 1]))
//            {
//                temp[i,j] = 1 + min(temp[i + 1,j], temp[i + 1,j + 1], temp[i,j + 1]);
//                if (max < temp[i,j])
//                    max = temp[i,j];
//            }
//            else
//            {
//                temp[i,j] = input[i,j] ^ 1;
//            }
//        }
//    }
//    return max;
//}


//int main()
//{
//    int[,] input = {
//        {1,0,0,0,1},
//        {0,0,0,0,0},
//        {0,0,0,0,0},
//        {1,0,1,0,0},
//        {0,0,0,0,0}
//    };

//    int[,] temp[5,5] = {0};

//    printf("\n largest matrix is %d\n", Largest_matrix(input, temp, 5));

//    for(int i=0; i<;5; i++ )
//    {
//        for(int j=0; j<;5; j++ )
//        {
//            printf("%d, ", temp[i,j] );
//        }
//        printf("\n");
//    }

//}

//public int solution3(int[] height)
//{

//    int n = height.Length;
//    if (n == 0) return 0;

//    Stack<Int32> left = new Stack<Int32>();
//    Stack<Int32> right = new Stack<Int32>();

//    int[] width = new int[n];// widths of intervals.

//    Array.fill(width, 1);// all intervals should at least be 1 unit wide.

//    for (int i = 0; i < n; i++)
//    {
//        // count # of consecutive higher bars on the left of the (i+1)th bar
//        while (!left.isEmpty() && height[i] <= height[left.Peek()])
//        {
//            // while there are bars stored in the stack, we check the bar on the top of the stack.
//            left.Pop();
//        }

//        if (left.isEmpty())
//        {
//            // all elements on the left are larger than height[i].
//            width[i] += i;
//        }
//        else
//        {
//            // bar[left.peek()] is the closest shorter bar.
//            width[i] += i - left.Peek() - 1;
//        }
//        left.Push(i);
//    }

//    for (int i = n - 1; i >= 0; i--)
//    {

//        while (!right.isEmpty() && height[i] <= height[right.Peek()])
//        {
//            right.Pop();
//        }

//        if (right.isEmpty())
//        {
//            // all elements to the right are larger than height[i]
//            width[i] += n - 1 - i;
//        }
//        else
//        {
//            width[i] += right.Peek() - i - 1;
//        }
//        right.Push(i);
//    }

//    int max = Int32.MinValue;
//    for (int i = 0; i < n; i++)
//    {
//        // find the maximum value of all rectangle areas.
//        max = Math.Max(max, width[i] * height[i]);
//    }

//    return max;
//}