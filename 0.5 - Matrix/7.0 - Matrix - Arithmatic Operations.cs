using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Matrix Multiplication :
    http://en.wikipedia.org/wiki/Matrix_multiplication

    1. Strassen Algorithm :
    http://en.wikipedia.org/wiki/Strassen_algorithm

    2. Coppersmith Winograd Algorithm :
    http://en.wikipedia.org/wiki/Coppersmith%E2%80%93Winograd_algorithm

    3. Shmuel Winograd Algorithm :
    http://en.wikipedia.org/wiki/Shmuel_Winograd
    
    4. Don_Coppersmith Algorithm :
    http://en.wikipedia.org/wiki/Don_Coppersmith

    5. Chain Multiplication :
    http://en.wikipedia.org/wiki/Matrix_chain_multiplication
    https://www.youtube.com/watch?v=kHVWdLvidJw
    http://www.stoimen.com/blog/2012/11/26/computer-algorithms-strassens-matrix-multiplication/
     * Helpful in large matrix multiplications

    Generally Strassen’s Method is not preferred for practical applications for following reasons.
    1) The constants used in Strassen’s method are high and for a typical application Naive method works better.
    2) For Sparse matrices, there are better methods especially designed for them.
    3) The submatrices in recursion take extra space.
    4) Because of the limited precision of computer arithmetic on noninteger values, larger errors accumulate in Strassen’s algorithm than in Naive Method (Source: CLRS Book)
    http://www.geeksforgeeks.org/strassens-matrix-multiplication/
    
    */
    class MatrixMultiplication
    {
        public void MultiplyMatrix(int[,] A, int[,] B, int[,] C)
        {
            int matLength = C.GetLength(0);

            for (int rIndx = 0; rIndx < matLength; rIndx++)
            {
                for (int cIndx = 0; cIndx < matLength; cIndx++)
                {
                    C[rIndx, cIndx] = 0;

                    for (int tIndx = 0; tIndx < matLength; tIndx++) // Transpose Indx
                    {
                        C[rIndx, cIndx] += A[rIndx, tIndx] * B[tIndx, cIndx];
                    }
                }
            }
        }
    }

    class CopperSmithWinogradAlgorithm
    {
    }
}