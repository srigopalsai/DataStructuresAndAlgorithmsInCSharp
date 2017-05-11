using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Given a sequence of matrices, find the most efficient way to multiply these matrices together. 
    The problem is not actually to perform the multiplications, but merely to decide in which order to perform the multiplications.
    
    We have many options to multiply a chain of matrices because matrix multiplication is associative. 
    In other words, no matter how we parenthesize the product, the result will be the same. 
    E.g. If we had four matrices A, B, C, and D, we would have:
    (ABC)D = (AB)(CD) = A(BCD) = ....

    However, the order in which we parenthesize the product affects the number of simple arithmetic operations needed to compute the product, or the efficiency. 
    E.g. suppose A is a 10 × 30 matrix, B is a 30 × 5 matrix, and C is a 5 × 60 matrix. Then,
    (AB)C = (10×30×5) + (10×5×60) = 1500 + 3000 = 4500 operations
    A(BC) = (30×5×60) + (10×30×60) = 9000 + 18000 = 27000 operations

    Dynamic Programming :
    1. Optimal Substructure:
    A simple solution is to place parenthesis at all possible places, calculate the cost for each placement and return the minimum value. 
    In a chain of matrices of size n, we can place the first set of parenthesis in n-1 ways. 

    E.g. If the given chain is of 4 matrices. 
    Let the chain be ABCD, then there are 3 way to place first set of parenthesis: A(BCD), (AB)CD and (ABC)D. 
    So when we place a set of parenthesis, we divide the problem into subproblems of smaller size. 
     
    Minimum number of multiplication needed to multiply a chain of size n = Minimum of all n-1 placements (these placements create subproblems of smaller size)
    
    2. Overlapping Subproblems:
    Below Following is a recursive implementation that simply follows the above optimal substructure property. 
    
    Therefore, the problem has optimal substructure property and can be easily solved using recursion.
    http://www.geeksforgeeks.org/dynamic-programming-set-8-matrix-chain-multiplication/
    */
    class MatixChainMultiplication
    {
        //O(N^3)
        void multiply(int[][] A, int[][] B, int[][] C)
        {
            int N = A.Length;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        C[i][j] = C[i][j] +  (A[i][k] * B[k][j]);
                    }
                }
            }
        }


        /* A naive recursive implementation that simply follows the above optimal substructure property  2^n Exponential Time*/

        // Matrix Ai has dimension p[i-1] x p[i] for i = 1..n
//int MatrixChainOrderNaive(int p[], int i, int j)
//{
//    if(i == j)
//        return 0;
//    int k;
//    int min = INT_MAX;
//    int count;
 
//    // place parenthesis at different places between first and last matrix,
//    // recursively calculate count of multiplcations for each parenthesis 
//    // placement and return the minimum count
//    for (k = i; k <j; k++)
//    {
//        count = MatrixChainOrderNaive(p, i, k) +
//                MatrixChainOrderNaive(p, k+1, j) +
//                p[i-1]*p[k]*p[j];
 
//        if (count < min)
//            min = count;
//    }
 
//    // Return minimum count
//    return min;
//}
        
// Matrix Ai has dimension p[i-1] x p[i] for i = 1..n
// Time Complexity: O(n^3)
// Auxiliary Space: O(n^2)

//int MatrixChainOrder(int p[], int n)
//{
 
//    /* For simplicity of the program, one extra row and one extra column are
//       allocated in m[][].  0th row and 0th column of m[][] are not used */
//    int m[n][n];
 
//    int i, j, k, L, q;
 
//    /* m[i,j] = Minimum number of scalar multiplications needed to compute
//       the matrix A[i]A[i+1]...A[j] = A[i..j] where dimention of A[i] is
//       p[i-1] x p[i] */
 
//    // cost is zero when multiplying one matrix.
//    for (i = 1; i < n; i++)
//        m[i][i] = 0;
 
//    // L is chain length.  
//    for (L=2; L<n; L++)   
//    {
//        for (i=1; i<=n-L+1; i++)
//        {
//            j = i+L-1;
//            m[i][j] = INT_MAX;
//            for (k=i; k<=j-1; k++)
//            {
//                // q = cost/scalar multiplications
//                q = m[i][k] + m[k+1][j] + p[i-1]*p[k]*p[j];
//                if (q < m[i][j])
//                    m[i][j] = q;
//            }
//        }
//    }
 
//    return m[1][n-1];
//}
 
//int main()
//{
//    int arr[] = {1, 2, 3, 4};
//    int size = sizeof(arr)/sizeof(arr[0]);
 
//    printf("Minimum number of multiplications is %d "   MatrixChainOrder(arr, size));
 
//    getchar();
//    return 0;
//}
 


    }
}
