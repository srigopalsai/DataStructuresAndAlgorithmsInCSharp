using DataStructuresAndAlgorithms.Graphs.Matrix;
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Graphs
{
    /*
    http://en.wikipedia.org/wiki/Shortest_path_problem
    With 0 or 1 Move left or dowm https://www.youtube.com/watch?v=keb6rP07Yqg
    Floyd Warshall : http://www.thelearningpoint.net/computer-science/algorithms-all-to-all-shortest-paths-in-graphs---floyd-warshall-algorithm-with-c-program-source-code
Bellman–Ford algorithm O(VE) 
Dijkstra's algorithm : http://en.wikipedia.org/wiki/Dijkstra%27s_algorithm
    http://www.sanfoundry.com/java-program-find-shortest-path-between-two-vertices-using-dijkstras-algorithm/
    http://www.thelearningpoint.net/computer-science/algorithms-shortest-path-in-graphs---dijkstra-algorithm--with-c-program-source-code
    Code and notes http://www.cs.cornell.edu/~wdtseng/icpc/notes/graph_part2.pdf
Gabow's algorithm O(E logE/V L) 
    http://www.sanfoundry.com/java-program-gabow-algorithm/
    http://www.geeksforgeeks.org/shortest-path-exactly-k-edges-directed-weighted-graph/
    http://quiz.geeksforgeeks.org/algorithms-greedy-algorithms-question-2/

    =================================================================================================================================
    Lee Algorithm or A* Algorithm Min Cost Path Finding https://www.youtube.com/watch?v=lBRtnuxg-gU&t=181s
    //http://www.geeksforgeeks.org/shortest-path-in-a-binary-maze/
    http://www.techiedelight.com/find-shortest-path-in-maze/
    http://stackoverflow.com/questions/30551194/find-shortest-path-in-a-maze-with-recursive-algorithm
    http://stackoverflow.com/questions/16366448/maze-solving-with-breadth-first-search

    Similar Question http://www.geeksforgeeks.org/find-minimum-numbers-moves-needed-move-one-cell-matrix-another/
    Nice Project with different algorithms http://qiao.github.io/PathFinding.js/visual/

        https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/ShortestDistanceFromExit.java

    */

    public partial class MatrixOperations
    {
        public void ShortestPathTest()
        {
            Point source = new Point { xPos = 0, yPos = 0 };
            //Point dest = new Point { xPos = 3, yPos = 4 }; // Path 
            //Point dest = new Point { xPos = 2, yPos = 1 };
            //Point dest = new Point { xPos = 5, yPos = 5 }; // 10
            //Point dest = new Point { xPos = 4, yPos = 2 }; // 12
            Point dest = new Point { xPos = 0, yPos = 5 }; //6
            int[,] srcMat = TestData.BinaryMatrixCollection[TestData.Keys.TenByTen1];
            Common.ShowMatrixOnConsole(srcMat, "Source Matrix");
            
            Point destPoint = ShortestPathByLeeBFS(srcMat, source.xPos, source.yPos, dest.xPos, dest.yPos);
            Common.ShowMatrixOnConsole(srcMat, "Traversed Matrix");

            if (destPoint == null)
                Console.WriteLine("Not found");
            else
            {
                Console.WriteLine("Shortest Path Traverse Positions");
                while (destPoint.GetPreviousPoint() != null)
                {
                    Console.WriteLine(destPoint.xPos + "  " + destPoint.yPos);
                    destPoint = destPoint.GetPreviousPoint();
                }
            }

            //Stack<Point> result = new Stack<Point>();
            //int pathVal = ShortestPathByLeeBFS(srcMat, source, dest, result);

            //int[,] solMat = new int[srcMat.GetLength(0), srcMat.GetLength(1)];
            //bool result = GetPath(srcMat, source.xPos, source.yPos, solMat);
        }
        
        public int ShortestPathByLeeBFS(int[,] matrix, Point srcPoint, Point destPoint, Stack<Point> resultPath)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return -1;

            if (matrix[srcPoint.xPos, srcPoint.yPos] != 1 || matrix[destPoint.xPos, destPoint.yPos] != 1)
                return -1;

            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

            // Mark the source cell as visited
            visited[srcPoint.xPos, srcPoint.yPos] = true;

            Queue<Vertex> vertexQueue = new Queue<Vertex>();

            Vertex s = new Vertex() { Point = srcPoint, Distance = 0 };

            vertexQueue.Enqueue(s);  // Enqueue source cell
            resultPath.Push(srcPoint);

            // These arrays are used to get row and column numbers of 4 neighbours of a given cell
            int[] rowNum = { -1, 0, 0, 1 };
            int[] colNum = { 0, -1, 1, 0 };

            // Do a BFS starting from source cell
            while (vertexQueue.Count > 0)
            {
                Vertex currVertex = vertexQueue.Dequeue();
                Point currPoint = currVertex.Point;

                // Reached the destination cell, we are done
                if (currPoint.xPos == destPoint.xPos && currPoint.yPos == destPoint.yPos)
                    return currVertex.Distance;

                for (int lpCnt = 0; lpCnt < 4; lpCnt++)
                {
                    int rowPos = currPoint.xPos + rowNum[lpCnt];
                    int colPos = currPoint.yPos + colNum[lpCnt];

                    // If adjacent cell is valid, has path and not visited yet, enqueue it.
                    if (Point.IsSafePoint(matrix, rowPos, colPos) == true && visited[rowPos, colPos] == false)
                    {
                        visited[rowPos, colPos] = true;
                        Point point = new Point() { xPos = rowPos, yPos = colPos };
                        Vertex Adjcell = new Vertex() { Point = point,
                                                        Distance = currVertex.Distance + 1 };
                    }
                }
            }
            return -1;
        }

        //====================================================================================================================================
        //Approach 2 Retun list of locations

        public Point ShortestPathByLeeBFS(int[,] srcMaze, int xSrcPos, int ySrcPos, int xDestPos, int yDestPos)
        {
            Queue<Point> pointQueue = new Queue<Point>();
            pointQueue.Enqueue(new Point(xSrcPos, ySrcPos, null));

            while (pointQueue.Count > 0)
            {
                Point currPoint = pointQueue.Dequeue();
                
                // Reached Destination
                if (currPoint.xPos == xDestPos && currPoint.yPos == yDestPos) 
                    return currPoint;
                
                // Visit Neighbours
                ProcessPoint(srcMaze, currPoint, pointQueue, currPoint.xPos + 1, currPoint.yPos);
                ProcessPoint(srcMaze, currPoint, pointQueue, currPoint.xPos - 1, currPoint.yPos);
                ProcessPoint(srcMaze, currPoint, pointQueue, currPoint.xPos, currPoint.yPos + 1);
                ProcessPoint(srcMaze, currPoint, pointQueue, currPoint.xPos, currPoint.yPos - 1);
            }
            return null;
        }

        private void ProcessPoint(int[,] srcMaze, Point currPoint, Queue<Point> pointQueue, int xPos, int yPos)
        {
            if (Point.IsSafePoint(srcMaze, xPos, yPos))
            {
                srcMaze[currPoint.xPos, currPoint.yPos] = -1;// Current point visited
                Point nextP = new Point(xPos, yPos, currPoint);
                pointQueue.Enqueue(nextP);
            }
        }

        //====================================================================================================================================

        /* 
        Consider a matrix with rows and columns, where each cell contains either a ‘0’ or a ‘1’ and any cell containing a 1 is called a filled cell. 
        Two cells are said to be connected if they are adjacent to each other horizontally, vertically, or diagonally.
        If one or more filled cells are also connected, they form a region. find the length of the largest region.
        
        E.g:    Input : M[][5] = { 0 0 1 1 0
                                   1 0 1 1 0
                                   0 1 0 0 0
                                   0 0 0 0 1 }
        Output : 6 In the above example, there are 2 regions one with length 1 and the other as 6.
        http://www.geeksforgeeks.org/find-length-largest-region-boolean-matrix/

        Time complexity: O(n^2)
        */
        public void GetLargestRegionLengthTest()
        {
            int[,] srcMatrix = new int[,] { {0, 0, 1, 1, 0},
                                    {1, 0, 1, 1, 0},
                                    {0, 1, 0, 0, 0},
                                    {0, 0, 0, 0, 1}};

            int result = GetLargestRegionLength(srcMatrix);
            Common.ShowMatrixOnConsole(srcMatrix);
            Console.WriteLine("Largest region length is " + result);
        }

        public int GetLargestRegionLength(int[,] srcMatrix)
        {
            int regionLen = 0;
            int rowLen = srcMatrix.GetLength(0);
            int colLen = srcMatrix.GetLength(1);
            bool[,] visited = new bool[rowLen, colLen];

            for (int rowIndx = 0; rowIndx < rowLen; ++rowIndx)
            {
                for (int colIndx = 0; colIndx < colLen; ++colIndx)
                {
                    if (srcMatrix[rowIndx, colIndx] == 1 && visited[rowIndx, colIndx] == false)
                    {
                        int count = 1;

                        DfsRecursive8Neighbours(srcMatrix, visited, rowIndx, colIndx, ref count);

                        regionLen = Math.Max(regionLen, count);
                    }
                }
            }
            return regionLen;
        }

        //====================================================================================================================================
    }
}
/*
 Working Copy 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class Maze
    {
        public int[,] arr = new int[,] {
            {1,1,1,1,1,0,0,0,0},
            {1,1,0,1,0,0,0,0,0},
            {1,1,0,1,0,0,0,0,0},
            {0,1,1,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0} };

        public class Point
        {
            public int x;
            public int y;

            Point parent;

            public Point(int x, int y, Point parent)
            {
                this.x = x;
                this.y = y;
                this.parent = parent;
            }

            public Point getParent()
            {
                return this.parent;
            }
        }

        public Queue<Point> q = new Queue<Point>();

        public Point getPathBFS(int x, int y, int x1, int y1)
        {
            q.Enqueue(new Point(x, y, null));

            while (q.Count > 0)
            {
                Point p = q.Dequeue();

                if ((p.x ==x1 && p.y == y1) || ( p.x == arr.GetLength(0) && p.y == arr.GetLength(1)))
                {
                    Console.WriteLine("Destination reached!");
                    return p;
                }

                if (isFree(p.x + 1, p.y))
                {
                    arr[p.x, p.y] = -1;
                    Point nextP = new Point(p.x + 1, p.y, p);
                    q.Enqueue(nextP);
                }

                if (isFree(p.x - 1, p.y))
                {
                    arr[p.x, p.y] = -1;
                    Point nextP = new Point(p.x - 1, p.y, p);
                    q.Enqueue(nextP);
                }

                if (isFree(p.x, p.y + 1))
                {
                    arr[p.x, p.y] = -1;
                    Point nextP = new Point(p.x, p.y + 1, p);
                    q.Enqueue(nextP);
                }

                if (isFree(p.x, p.y - 1))
                {
                    arr[p.x, p.y] = -1;
                    Point nextP = new Point(p.x, p.y - 1, p);
                    q.Enqueue(nextP);
                }
            }
            return null;
        }

        public bool isFree(int x, int y)
        {
            if ((x >= 0 && x < arr.GetLength(0)) && (y >= 0 && y < arr.GetLength(1)) && (arr[x, y] == 1 ))
            {
                return true;
            }
            return false;
        }

        public static void Main(String[] args)
        {
            Maze mz = new Maze();
            Console.WriteLine("Source Matrix");

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(string.Format("{0}\t", mz.arr[i, j]));
                }
                Console.WriteLine();
            }

            Console.WriteLine("Maze Matrix");
            Point p = mz.getPathBFS(0, 0, 0,4);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(string.Format("{0}\t", mz.arr[i, j]));
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Shortest Path");

            while (p.getParent() != null)
            {
                Console.WriteLine(p.x + "  " + p.y );
                p = p.getParent();
            }
            Console.Read();
        }
    }
}*/
