using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    //http://www.programcreek.com/2014/09/find-a-path-in-a-matrix/
    // Find all paths from top left to bottom right corner 
    // http://algorithms.tutorialhorizon.com/dynamic-programming-count-all-paths-from-top-left-to-bottom-right-of-a-mxn-matrix/
    partial class MatrixOperations
    {
        public int[,] findPath(int[,] matrix)
        {
            int m = matrix.Length;

            int[,] result = new int[m,m];

            List<int[]> temp = new List<int[]>();
            List<int[]> list = new  List<int[]>();

            dfs(matrix, 0, 0, temp, list);


            for (int i = 0; i < list.Count; i++)
            {
                //result[list.get(i)[0],list.get(i)[1]] = 1;
                //Console.WriteLine(Arrays.toString(list.get(i)));
            }

            result[0,0] = 1;

            return result;
        }

        public void dfs(int[,] matrix, int xIndx, int yIndx, List<int[]> temp, List<int[]> list)
        {

            int matrixLength = matrix.Length;

            if (xIndx == matrixLength - 1 && yIndx == matrixLength - 1)
            {
                list.Clear();
                list.AddRange(temp);
                return;
            }

            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            for (int k = 0; k < 4; k++)
            {
                int x = xIndx + dx[k];
                int y = yIndx + dy[k];

                if (x >= 0 && y >= 0 && x <= matrixLength - 1 && y <= matrixLength - 1 && matrix[x,y] == 1)
                {
                    temp.Add(new int[] { x, y });
                    int prev = matrix[x,y];
                    matrix[x,y] = 0;

                    dfs(matrix, x, y, temp, list);

                    matrix[x,y] = prev;
                    temp.RemoveAt(temp.Count - 1);
                }
            }
        }
    }
}
