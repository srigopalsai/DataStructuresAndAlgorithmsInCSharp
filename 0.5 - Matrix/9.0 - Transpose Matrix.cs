using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    partial class MatrixOperations
    {
        public void TransposeMatrixTest()
        {
            resultArrayString.Clear();
            AppendMatrixToResultString(RectangularMatrix4x4, "Input Matrix");
            
            TransposeMatrix(RectangularMatrix4x4);
            
            List<int> matrixList = new List<int>();

            AppendMatrixToResultString(RectangularMatrix4x4, "Output Matrix");
            ShowResultString();
        }

        // Assuming square matrix.
        public void TransposeMatrix(int[,] matrix)
        {
            int tempElement = 0;

            //for (int LpRCnt = 0; LpRCnt < matrix.GetLength(0); LpRCnt++)
            //{
            //    for (int LpCCnt = 0; LpCCnt < matrix.GetLength(1); LpCCnt++)
            //    {
            //        if (LpCCnt != LpRCnt)
            //        {
            //            tempElement = matrix[LpRCnt, LpCCnt];
            //            matrix[LpRCnt, LpCCnt] = matrix[LpCCnt, LpRCnt];
            //            matrix[LpCCnt, LpRCnt] = tempElement;
            //        }
            //    }
            //}

            for (int lpDiagCnt = 0; lpDiagCnt < matrix.GetLength(0); lpDiagCnt++)
            {
                for (int lpBackCnt = lpDiagCnt - 1; lpBackCnt >= 0; lpBackCnt--)
                {
                    tempElement = matrix[lpDiagCnt, lpBackCnt];
                    matrix[lpDiagCnt, lpBackCnt] = matrix[lpBackCnt, lpDiagCnt];
                    matrix[lpBackCnt, lpDiagCnt] = tempElement;
                }
            }
        }
    }
}