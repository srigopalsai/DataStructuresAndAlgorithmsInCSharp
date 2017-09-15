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
