using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*

    ============================================================================================================================================================================================================================

    In given array find zero and replace the entire row and column with zeros 
    
    E.g Input:
    
    1   2   3   4
    5   6   7   8
    9   10  0   11
    12  13  14  15

    Output:
    
    1   2   0   4
    5   6   0   8
    0   0   0   0
    12  13  0   15
    
    Time Complexity: O(NxM + NxM) 
    https://github.com/mission-peace/interview/blob/master/src/com/interview/multiarray/Fill2DMatrixWith1.java
    ============================================================================================================================================================================================================================  
    */
    partial class MatrixOperations
    {
        StringBuilder strBlrdObj = new StringBuilder();

        public void ReplaceZeroRowsAndColumns()
        {
            int[,] arrayElements = new int[4, 4];
            int rowLength = arrayElements.GetLength(0);
            int colLength = arrayElements.GetLength(1);

            List<int> listOfZeroRows = new List<int>();
            List<int> listOfZeroCols = new List<int>();

            // Input.
            for (int lpRCnt = 0; lpRCnt < rowLength; lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < colLength; lpCCnt++)
                {
                    if (lpRCnt == 2 && (lpCCnt == 2))
                    {
                        arrayElements[lpRCnt, lpCCnt] = 0;
                    }
                    else
                    {
                        arrayElements[lpRCnt, lpCCnt] = ((lpRCnt+1)* (lpCCnt+1));            
                    }
                    strBlrdObj.Append(Convert.ToString(arrayElements[lpRCnt, lpCCnt]) + "\t");
                }
                strBlrdObj.Append("\n");
            }

            MessageBox.Show("Input Array:\n" + Convert.ToString(strBlrdObj));
            
            // Actual Logic. Collect all rows and columns which has zeroes.
            for (int lpRCnt = 0; lpRCnt < rowLength; lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < colLength; lpCCnt++)
                {
                    if (arrayElements[lpRCnt, lpCCnt] == 0)
                    {
                        listOfZeroRows.Add(lpRCnt);
                        listOfZeroCols.Add(lpCCnt);
                    }
                }
            }

            foreach (int row in listOfZeroRows)
            {
                for (int lpCCnt = 0; lpCCnt < colLength; lpCCnt++)
                {
                    arrayElements[row, lpCCnt] = 0;
                }
            }

            foreach (int col in listOfZeroCols)
            {
                for (int lpRCnt = 0; lpRCnt < rowLength; lpRCnt++)
                {
                    arrayElements[lpRCnt, col] = 0;
                }
            }

            strBlrdObj.Clear();
            //Output
            for (int lpRCnt = 0; lpRCnt < rowLength; lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < colLength; lpCCnt++)
                {
                    strBlrdObj.Append(Convert.ToString(arrayElements[lpRCnt, lpCCnt]) + "\t");
                }
                strBlrdObj.Append("\n");
            }

            MessageBox.Show("\nOutput Array:\n" + Convert.ToString(strBlrdObj));
        }

        // Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.         
        public void ReplaceZeroRowsAndColumnsInPlace(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return;

            int rowLen = matrix.GetLength(0);
            int colLen = matrix.GetLength(1);
            int row0ColIndx = 0;

            // Find first row has zeros or not?
            for (; row0ColIndx < colLen && matrix[0, row0ColIndx] != 0; ++row0ColIndx) ;
            //for (; col0RowIndx < rowLen && matrix[col0RowIndx, 0] != 0; ++col0RowIndx) ; // Can avoid if we traverse column backwards while filling zeros

            // Use first row and column as reference indicators.
            for (int lpRCnt = 1; lpRCnt < rowLen; ++lpRCnt)
            {
                for (int lpCCnt = 0; lpCCnt < colLen; ++lpCCnt)
                {
                    if (matrix[lpRCnt, lpCCnt] == 0)
                        matrix[0, lpCCnt] = matrix[lpRCnt, 0] = 0;
                }
            }

            // Set the zeros in the matrix excluding first row. And by start columns from backwards.
            for (int lpRCnt = 1; lpRCnt < rowLen; ++lpRCnt)
            {
                for (int lpCCnt = colLen - 1; lpCCnt >= 0; --lpCCnt) // Can avoid zeroth column test and refilling for zeros.
                //for (int lpCCnt = 0; lpCCnt < colLen; ++lpCCnt)
                {
                    if (matrix[0, lpCCnt] == 0 || matrix[lpRCnt, 0] == 0)
                        matrix[lpRCnt, lpCCnt] = 0;
                }
            }

            // Now set zeros for the first row if required
            if (row0ColIndx < colLen)
            {
                for (int lpCCnt = 0; lpCCnt < matrix.GetLength(1); lpCCnt++)
                    matrix[0, lpCCnt] = 0;
            }

            // Now set zeros for the first column if required. // Can avoid if we traverse column backwards while filling zeros
            //if (col0RowIndx < rowLen)
            //{
            //    for (int lpRCnt = 0; lpRCnt < matrix.GetLength(0); lpRCnt++)
            //        matrix[lpRCnt, 0] = 0;
            //}
        }

        public void ReplaceZeroRowsAndColumnsTest()
        {
            resultArrayString.Clear();
            AppendMatrixToResultString(SquareMaxtixWith0Vals, "Source Matrix : ");
            //MatrixOperationsObj.ReplaceZeroRowsAndColumns();
            ReplaceZeroRowsAndColumnsInPlace(SquareMaxtixWith0Vals);
            AppendMatrixToResultString(SquareMaxtixWith0Vals, "After filling rows and columns with zeros: ");


            AppendMatrixToResultString(SquareEmptyMaxtix, "Source Matrix : ");
            ReplaceZeroRowsAndColumnsInPlace(SquareEmptyMaxtix);
            AppendMatrixToResultString(SquareEmptyMaxtix, "After filling rows and columns with zeros: ");

            AppendMatrixToResultString(SquareMaxtixSingleVal, "Source Matrix : ");
            ReplaceZeroRowsAndColumnsInPlace(SquareMaxtixSingleVal);
            AppendMatrixToResultString(SquareMaxtixSingleVal, "After filling rows and columns with zeros: ");

            AppendMatrixToResultString(SquareMaxtixWith0ValSR, "Source Matrix : ");
            ReplaceZeroRowsAndColumnsInPlace(SquareMaxtixWith0ValSR);
            AppendMatrixToResultString(SquareMaxtixWith0ValSR, "After filling rows and columns with zeros: ");

            AppendMatrixToResultString(SquareMaxtixWith0ValSC, "Source Matrix : ");
            ReplaceZeroRowsAndColumnsInPlace(SquareMaxtixWith0ValSC);
            AppendMatrixToResultString(SquareMaxtixWith0ValSC, "After filling rows and columns with zeros: ");
                             
            MessageBox.Show(resultArrayString.ToString());
        }
    }
}