using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
     * try using Lync,
     */
    partial class MatrixOperations
    {
        //http://stackoverflow.com/questions/19615106/sorting-matrix-based-on-columns-comparison
        //http://msdn.microsoft.com/en-us/library/85y6y2d3(v=vs.110).aspx
        public void SortBruteForce(int[,] Matrix)
        {
            int TempCol1Element = 0;
            int TempCol2Element = 0;

            for (int LpRowIndx = 0; LpRowIndx < Matrix.GetUpperBound(0) + 1; LpRowIndx++)
            {
                for (int LpColIndx = 0; LpColIndx < Matrix.GetUpperBound(0) + 1; LpColIndx++)
                {
                    if (Matrix[LpRowIndx, 0] < Matrix[LpColIndx, 0])
                    {
                        TempCol1Element = Matrix[LpRowIndx, 0];
                        TempCol2Element = Matrix[LpRowIndx, 1];

                        Matrix[LpRowIndx, 0] = Matrix[LpColIndx, 0];
                        Matrix[LpRowIndx, 1] = Matrix[LpColIndx, 1];

                        Matrix[LpColIndx, 0] = TempCol1Element;
                        Matrix[LpColIndx, 1] = TempCol2Element;
                    }
                }
            }
            //for (int i = 0; i < 50; i++)
            //{
            //    for (int j = 0; j < 49 - i; j++)
            //    {
            //        if (rating[j, 1] < rating[j + 1, 1]) // column 1 entry comparison
            //        {
            //            temp1 = rating[j, 0];              // swap both column 0 and column 1
            //            temp2 = rating[j, 1];

            //            rating[j, 0] = rating[j + 1, 0];
            //            rating[j, 1] = rating[j + 1, 1];

            //            rating[j + 1, 0] = temp1;
            //            rating[j + 1, 1] = temp2;
            //        }
            //    }
            //}

            //LINQ
            //int[][] mat = new[] { new[] { 4, 4 }, new[] { 5, 1 }, new[] { 3, 2 }, new[] { 6, 1 } };
            //var ordered = mat.OrderByDescending(i => i[1]);
        }
        public void SortMatrixUsingSortedDictionary(int[,] Matrix)
        {
            SortedDictionary<int, int> matrixDict = new SortedDictionary<int, int>();
 
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                //fill sortedDictionary with your data
                matrixDict.Add(Matrix[i, 0], Matrix[i, 1]);
            }

            // Display results
            foreach (KeyValuePair<int, int> pair in matrixDict)
            {


            }
        }
    }
}