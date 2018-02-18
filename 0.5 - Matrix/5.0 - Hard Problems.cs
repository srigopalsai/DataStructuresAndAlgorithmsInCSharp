using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms._0._5___Matrix
{
    public class HardProblems
    {
        // Binary indexed tree or Fenwick Tree
        // https://github.com/mission-peace/interview/blob/master/src/com/interview/tree/FenwickTree.java
        // https://www.youtube.com/watch?v=CWDQJGaN1gY
        // https://zhuhan0.blogspot.com/2017/09/leetcode-308-range-sum-query-2d-mutable.html
        class NumMatrix
        {
            private int[,] matrix;
            private int[,] tree;

            private int height;
            private int width;

            public NumMatrix(int[,] matrix)
            {
                height = matrix.GetLength(0);

                if (height == 0)
                {
                    return;
                }

                width = matrix.GetLength(0);

                this.matrix = new int[height, width];
                tree = new int[height + 1, width + 1];

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        update(i, j, matrix[i,j]);
                    }
                }
            }

            public void update(int row, int col, int val)
            {
                int diff = val - matrix[row,col];
                matrix[row,col] = val;

                for (int i = row + 1; i <= height; i += (i & -i))
                {
                    for (int j = col + 1; j <= width; j += (j & -j))
                    {
                        tree[i,j] += diff;
                    }
                }
            }

            public int sumRegion(int row1, int col1, int row2, int col2)
            {
                return sum(row2, col2) - sum(row1 - 1, col2) - sum(row2, col1 - 1) + sum(row1 - 1, col1 - 1);
            }

            private int sum(int row, int col)
            {
                int sum = 0;
                for (int i = row + 1; i > 0; i -= (i & -i))
                {
                    for (int j = col + 1; j > 0; j -= (j & -j))
                    {
                        sum += tree[i,j];
                    }
                }
                return sum;
            }
        }

        /**
         * Your NumMatrix object will be instantiated and called as such:
         * NumMatrix obj = new NumMatrix(matrix);
         * obj.update(row,col,val);
         * int param_2 = obj.sumRegion(row1,col1,row2,col2);
         */
    }
}
