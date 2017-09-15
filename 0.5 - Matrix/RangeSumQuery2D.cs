using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Time complexity construction O(n*m)
    Time complexity of query O(1)
    Space complexity is O(n*m)
    Reference
    https://leetcode.com/problems/range-sum-query-2d-immutable/
    https://github.com/mission-peace/interview/blob/master/src/com/interview/dynamic/Immutable2DSumRangeQuery.java 
    */

    public class Immutable2DSumRangeQuery
    {
        private int[,] mat;

        public Immutable2DSumRangeQuery(int[,] matrix)
        {

            int row = 0;

            int col = 0;

            if (matrix.GetLength(0) != 0)
            {

                row = matrix.GetLength(0);

                col = matrix.GetLength(1);

            }

            mat = new int[row + 1,col + 1];

            for (int i = 1; i < mat.GetLength(0); i++)
            {

                for (int j = 1; j < mat.GetLength(1); j++)
                {

                    mat[i,j] = mat[i - 1,j] + mat[i,j - 1] + matrix[i - 1,j - 1] - mat[i - 1,j - 1];

                }

            }

        }



        public int SumQuery(int row1, int col1, int row2, int col2)
        {
            row1++;
            col1++;
            row2++;
            col2++;

            return mat[row2,col2] - mat[row1 - 1,col2] - mat[row2,col1 - 1] + mat[row1 - 1,col1 - 1];
        }



        public static void Test()
        {
            int[,] input = {{3, 0, 1, 4, 2},
                        {5, 6, 3, 2, 1},
                        {1, 2, 0, 1, 5},
                        {4, 1, 0, 1, 7},
                        {1, 0, 3, 0, 5}};

            int[,] input1 = { { 2, 0, -3, 4 }, { 6, 3, 2, -1 }, { 5, 4, 7, 3 }, { 2, -6, 8, 1 } };
            Immutable2DSumRangeQuery isr = new Immutable2DSumRangeQuery(input1);
            Console.WriteLine(isr.SumQuery(1, 1, 2, 2));
        }
    }
}