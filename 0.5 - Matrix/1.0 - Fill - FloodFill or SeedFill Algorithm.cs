using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    This problem follow Depth First Search (DFS) apprach of graph, need to use stack if we wanted to avoid recursion
    Refer Time Complexity here http://www.cs.bilkent.edu.tr/~gunduz/teaching/cs201/slides/Recitation4.pdf
    http://en.wikipedia.org/wiki/Flood_fill
    http://www.codecodex.com/wiki/Implementing_the_flood_fill_algorithm
    https://www.youtube.com/watch?v=n6_s8fpAEEY

    Used In : 
    1. Fill Command in Paint. 
    2. Minesweeper 
    3. Boundary fill in image editing application
    
    Approaches:
    1. Recursive Stack Based.
    2. Iterative Queue Baseed.
    3. Fixed Memory Method.
    
    Tail recursion can always be translated to an iterative format. That would save even more stack space.
    
    if()
    {
        //Base case where we dont call recursive function.
    }
    else
    {
        //Recursive case where we call recursive function.
    }

    ============================================================================================================================================================================================================================

    */
    partial class MatrixOperations
    {
        public void FloodFillOrSeedFillAlgorithmTest()
        {
            int[,] squareMatrix =   {   { 1, 0, 0, 1, 1 },
                                        { 1, 0, 0, 1, 1 },
                                        { 1, 1, 1, 0, 0 },
                                        { 0, 0, 1, 0, 1 },
                                        { 1, 1, 1, 0, 1 },
                                        { 0, 0, 0, 1, 0 }};

            int arrayRank = squareMatrix.Rank;

            StringBuilder strBlrd = new StringBuilder();
            strBlrd.Append("Input Matrix : \n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            strBlrd.Append("Test 1 : \n");

            int affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 5, 3);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            strBlrd.Append("Test 2 : \n");

            affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 3, 4);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            strBlrd.Append("Test 3 : \n");

            affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 0, 3);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            strBlrd.Append("Test 4 : \n");

            affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 0, 0);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            MessageBox.Show(strBlrd.ToString());
        }

        //int FloodFillOrSeedFillAlgorithm(int[,] matrix2Fill, int rowPos, int colPos)
        //{
        //    try
        //    {
        //        //if (rowPos < 0 || colPos < 0 || rowPos >= matrix2Fill.GetLength(0) || colPos >= matrix2Fill.GetLength(1))
        //        {
        //          //  return 0;
        //        }

        //        if (matrix2Fill[rowPos, colPos] != 1)
        //        {
        //            return 0;
        //        }

        //        // Just fill                 
        //        matrix2Fill[rowPos, colPos] = 2;

        //        int visitLeft = 0;
        //        int visitRight = 0;
        //        int visitTop = 0;
        //        int visitBottom = 0;

        //        if (rowPos + 1 < matrix2Fill.GetLength(0) && matrix2Fill[rowPos + 1,colPos] != 0)
        //        {
        //            visitLeft = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos + 1, colPos);    // East 
        //        }
        //        if (colPos - 1 >=0 && matrix2Fill[rowPos, colPos - 1] != 0)
        //        {
        //            visitRight = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos, colPos - 1);    // North
        //        }
        //        if (rowPos - 1 >=0 && matrix2Fill[rowPos - 1, colPos] != 0)
        //        {
        //            visitTop = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos - 1, colPos);    // West
        //        }
        //        if (colPos + 1 < matrix2Fill.GetLength(1) && matrix2Fill[rowPos ,colPos + 1] != 0)
        //        {
        //            visitBottom = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos, colPos + 1);    // South
        //        }

        //        return 1 + visitLeft + visitRight + visitTop + visitBottom;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Exception raised " + ex.Message + "\n" + ex.StackTrace);
        //        return -1;
        //    }
        //}

        int FloodFillOrSeedFillAlgorithm(int[,] matrix2Fill, int rowPos, int colPos)
        {
            try
            {
                // Base conditions.
                if (matrix2Fill == null)
                {
                    return 0;
                }

                if (rowPos < 0 || colPos < 0 || rowPos >= matrix2Fill.GetLength(0) || colPos >= matrix2Fill.GetLength(1))
                {
                    return 0;
                }

                if (matrix2Fill[rowPos, colPos] != 1)
                {
                    return 0;
                }

                // Just fill
                matrix2Fill[rowPos, colPos] = 2;

                // Visit east, west, north and south
                int visitLeft = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos - 1, colPos);      // West
                int visitRight = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos + 1, colPos);     // East 
                int visitTop = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos, colPos - 1);       // North
                int visitBottom = FloodFillOrSeedFillAlgorithm(matrix2Fill, rowPos, colPos + 1);    // South

                return 1 + visitLeft + visitRight + visitTop + visitBottom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception raised " + ex.Message + "\n" + ex.StackTrace);
                return -1;
            }
        }

        void FloodFillIterative()
        {
            /*            bool M[128][128];  // adjacency matrix (can have at most 128 vertices)     bool seen[128];   // which vertices have been visited     int n;   // number of vertices         // ... Initialize M to be the adjacency matrix     queue<int> q;  // The BFS queue to represent the visited set     int s = 0;     // the source vertex     
            CPSC 490 Graph Theory: DFS andBFS 
                // BFS flood­fill     for( int v = 0; v < n; v++ ) seen[v] = false;   // set all vertices to be "unvisited"     seen[s] = true;     DoColouring( s, some_color );     q.push( s );
                while (!q.empty() ) {         int u = q.front();  // get first un­touched vertex         q.pop();         for( int v = 0; v < n; v++ ) if( !seen[v] && M[u][v] ) {             seen[v] = true;             DoColouring( v, some_color );             q.push( v );         }     }
                */
        }
        //Assume array is 100 X 100. Some logic optimization.
        void FillMatrix(int[][] squareMatrix, int xPosition, int yPosition)
        {
            try
            {
                if (squareMatrix[xPosition][yPosition] == 1)
                {
                    return;
                }
                squareMatrix[xPosition][yPosition] = 2;

                if (xPosition < 99 && squareMatrix[xPosition + 1][yPosition] != 1)
                {
                    FillMatrix(squareMatrix, xPosition + 1, yPosition);
                }
                if (xPosition > 0 && squareMatrix[xPosition - 1][yPosition] != 1)
                {
                    FillMatrix(squareMatrix, xPosition - 1, yPosition);
                }
                if (yPosition < 99 && squareMatrix[xPosition][yPosition + 1] != 1)
                {
                    FillMatrix(squareMatrix, xPosition, yPosition + 1);
                }
                if (yPosition > 0 && squareMatrix[xPosition][yPosition - 1] != 1)
                {
                    FillMatrix(squareMatrix, xPosition, yPosition - 1);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong : " + exception.Message + "\n" + exception.StackTrace.ToString());
            }
        }
    }
}