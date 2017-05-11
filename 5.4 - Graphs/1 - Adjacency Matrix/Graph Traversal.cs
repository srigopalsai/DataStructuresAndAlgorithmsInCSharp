using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs
{
    /*
     * Visual Animation for Graph Traversal https://visualgo.net/dfsbfs
     * DFS is Pre Order Traversal of Tree
     * It is possible to make BFS and DFS look almost the same as each other (as similar as, say, Prim's and  Dijkstra's algorithms are to each other)
     * 
    http://ww3.algorithmdesign.net/handouts/DFS.pdf
    White Gray Black http://www.algolist.net/Algorithms/Graph/Undirected/Depth-first_search
    http://cyberlingo.blogspot.com/2015/03/depth-first-search-adjacency-matrix.html
    Iterative http://www.sanfoundry.com/java-program-traverse-graph-using-dfs-2/
       
    Notes: 
    Both Bfs & Dfs https://www.codeproject.com/articles/32212/introduction-to-graph-with-breadth-first-search-bf
    http://wikistack.com/c-program-for-bfs-using-adjacency-matrix/
    http://www.sanfoundry.com/java-program-traverse-graph-using-bfs/
    http://sasivakkalankacoding.blogspot.com/2012/09/breadth-first-search-on-adjacency-matrix_4.html
    http://www.geeksforgeeks.org/connectivity-in-a-directed-graph/
    http://stackoverflow.com/questions/8088626/depth-first-traversal-and-adj-matrix

       
    Assume that graph is connected. Depth-first search visits every vertex in the graph and checks every edge its edge. 
    Therefore, DFS complexity is O(V + E). 
    As it was mentioned before, if an adjacency matrix is used for a graph representation, then all edges, adjacent to a vertex can't be found efficiently, that results in O(V^2) complexity. 
        
    DFS doesn't go through all edges. The vertices and edges, which depth-first search has visited is a tree. 
    This tree contains all vertices of the graph (if it is connected) and is called graph spanning tree. 
    This tree exactly corresponds to the recursive calls of DFS.

    If a graph is disconnected, DFS won't visit all of its vertices. For details, see finding connected components algorithm.

    DFS : O(n+e) neighbour checks

    //====================================================================================================================================

    Graph DFS Recursive vs Iterative :
    ----------------------------------
    A DFS does not specify which node you see first. 
    It is not important because the order between edges is not defined [remember: edges are a set usually]. 
         
    Iterative : You first insert all the elements into the stack - and then handle the head of the stack [which is the last node inserted].
    Thus the first node you handle is the last son.
    Recursive : You handle each node when you see it. Thus the first node you handle is the first son.
    To make the iterative DFS yield the same result as recursive one for Adj List you need to add elements to the stack at reverse order.

    Use DFS for : 
    -------------
    Testing for connectivity 
    Finding a Spanning Tree 
    Finding Paths 
    Finding a cycle 
    
    //====================================================================================================================================
    
    Iterative Deepening Depth-First Search (IDS or IDDS) :
    ------------------------------------------------------
    IDDFS combines DFS's space-efficiency and BFS's completeness (when the branching factor is finite). 
    https://en.wikipedia.org/wiki/Iterative_deepening_depth-first_search

    */

    public partial class MatrixOperations
    {
        // For White Gray Black Approach 
        // https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/ShortestDistanceFromExit.java
        public int UNVISITED = 0; // White
        public int VISITING = 1;  // Gray
        public int FINISHED = 2;  // Black

        public void TraversalTest()
        {
            //int[,] srcMatrix = new int[,] { { 0, 1, 0, 1, 0 },
            //                                { 1, 0, 1, 0, 0 },
            //                                { 0, 1, 0, 1, 1 },
            //                                { 0, 1, 0, 1, 1 },
            //                                { 1, 0, 0, 1, 1 } };
             
            //0  1  2  3  4  5
            // DFS 0 1 2 3 5 4 http://wikistack.com/a-recursive-implementation-of-dfs/
            int[,] graph6by6 = new int[,] {{0, 1, 1, 0, 0, 0}, //0
                      {0, 0, 1, 1, 0, 0}, //1
                      {0, 0, 0, 1, 0, 0}, //2
                      {0, 0, 0, 0, 0, 1}, //3
                      {0, 0, 1, 0, 0, 0}, //4
                      {0, 0, 0, 0, 0, 0}};//5


            int[,] adjMatrix5by5 = new int[,] {// 0, 1, 2, 3, 4  DFS 0 4 3 2 1 http://wikistack.com/depth-first-traversal-of-graph/
                                                { 0, 1, 1, 0, 1 },
                                                { 0, 0, 0, 0, 0 },
                                                { 0, 0, 0, 1, 0 },
                                                { 0, 0, 0, 0, 0 },
                                                { 0, 0, 1, 1, 0 } };

            /* http://wikistack.com/a-recursive-implementation-of-dfs/
            g.addList (0, 1);
            g.addList (0, 2);
            g.addList (4, 3);
            g.addList (0, 4);
            g.addList (4, 2);
            g.addList (2, 1);
            g.addList (2, 3);
            */

            int[,] srcMatrix = TestData.BinaryMatrixCollection[TestData.Keys.SevenBySeven1];
            bool[] visitMatrix = new bool[srcMatrix.GetLength(0)];

            Console.Clear();
            TraversalTest(srcMatrix, visitMatrix, 0);
        }

        public void TraversalTest(int[,] srcMatrix, bool[] visitMatrix, int uVertex)
        {
            Common.ShowMatrixOnConsole(srcMatrix, "Source Matrix");

            Console.Write("DFS Recursive : ");
            DftRecursive(srcMatrix, visitMatrix, uVertex);

            //Console.Write("DFS Recursive WhiteGrayBlack : ");
            //DftRecursiveWhiteGrayBlack(srcMatrix);

            Console.Write("\nDFS Iterative : ");
            DftIterative(srcMatrix, uVertex);

            Console.Write("\nBFS Iterative : ");
            BftIterative(srcMatrix, uVertex);

            //==========================================================================================
            //Adjaceny List
            AdjacencyList.Graph graph = new AdjacencyList.Graph();
            graph.CreateFromMatrix(srcMatrix,false);
        }

        //====================================================================================================================================
        
        public void DftRecursiveWhiteGrayBlack(int[,] srcMatrix)
        {
            int[] visited = new int[srcMatrix.GetLength(0)];

            //Loops over each node in the graph in case we haven't visited it yet 
            for (int vertex = 0; vertex < srcMatrix.GetLength(0); ++vertex)
            {
                DftRecursiveHelper(srcMatrix, vertex, visited);
            }
        }

        public void DftRecursiveHelper(int[,] srcMatrix, int vetex, int[] visitMatrix)
        {
            if (visitMatrix[vetex] != UNVISITED)
                return;

            //Console.WriteLine("Visiting Vertex : " + vetex);
            visitMatrix[vetex] = VISITING;

            for (int neighbour = 0; neighbour < srcMatrix.GetLength(1); ++neighbour)
            {
                if (srcMatrix[vetex, neighbour] == 1)
                {
                    Console.WriteLine(" Found an Edge between : " + vetex + ", " + neighbour);
                    DftRecursiveHelper(srcMatrix, neighbour, visitMatrix);
                }
            }

            //Console.WriteLine("Finishing Vertex : " + vetex);
            visitMatrix[vetex] = FINISHED;
        }

        /*
          bool M[128][128]; // adjacency matrix    
          int colour[128]; // 0 is white, 1 is gray and 2 is black    
          int dfsNum[128], 
          int num;  // keeps track of the current DFS number and is incremented each time a new vertex is visited
          int n;    // the number of vertices

       // p is u's parent in the DFS tree    
       void dfs( int u, int p ) 
       {        
       colour[u] = 1;
       
       // Array simply assigns to each vertex a DFS number –  a number from 0 to n-­1 that indicates the order in which the dfs() function visited the vertices.
       dfsNum[u] = num++;

            for( int v = 0; v < n; v++ ) 
       if( M[u][v] && v != p ) 
       {            
        if( colour[v] == 0 ) 
        {                
        // (u,v) is a forward edge                
        dfs( v, u );            
        }            
        else if( colour[v] == 1 ) 
        {                
        // (u,v) is a back edge            
        }            
        else {                 
        // (u,v) is a cross edge            
        }        
       }        
       colour[u] = 2;    
       }
       
            int main() 
            {        
             // ... fill up M[][] with an adjacency matrix        
             // ... set n to be the number of vertices
             
            for( int i = 0; i < n; i++ ) 
             {    colour[i] = 0;        
                num = 0;        
             }
                dfs( 0, ­1 );                
                return 0;    
            }
       */
        //====================================================================================================================================

        public void DftRecursive(int[,] srcMatrix, bool[] visitMatrix, int vertex)
        {
            visitMatrix[vertex] = true;
            Console.Write(vertex + "  ");

            for (int neighbour = 0; neighbour < srcMatrix.GetLength(0); neighbour++)
            {
                if (visitMatrix[neighbour] == false && srcMatrix[vertex, neighbour] == 1)
                {
                    DftRecursive(srcMatrix, visitMatrix, neighbour);
                }
            }
        }

        // Arrays used to get row and column numbers of 8 neighbours of a given cell
        int[] rowNbr = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] colNbr = { -1, 0, 1, -1, 1, -1, 0, 1 };

        public void DfsRecursive8Neighbours(int[,] srcMatrix, bool[,] visitMatrix, int row, int col, ref int visitCount)
        {
            // Mark current cell as visited
            visitMatrix[row, col] = true;

            // Recursive call for all connected neighbours
            for (int cellPos = 0; cellPos < 8; ++cellPos)
            {
                if (IsSafePosition(srcMatrix, visitMatrix, row + rowNbr[cellPos], col + colNbr[cellPos]))
                {
                    visitCount++;
                    DfsRecursive8Neighbours(srcMatrix, visitMatrix, row + rowNbr[cellPos], col + colNbr[cellPos], ref visitCount);
                }
            }
        }

        public static bool IsSafePosition(int[,] matrix, bool[,] visitMatrix, int xPos, int yPos, int safeVal = 1)
        {
            if (xPos >= 0 && xPos < matrix.GetLength(0) &&
                yPos >= 0 && yPos < matrix.GetLength(1) &&
                matrix[xPos, yPos] == safeVal && visitMatrix[xPos,yPos] == false)
            {
                return true;
            }
            return false;
        }
        //====================================================================================================================================

        public void DftIterative(int[,] srcMatrix, int srcVertex)
        {  
            bool[] visited = new bool[srcMatrix.GetLength(0)];           

            Stack<int> vertexStack = new Stack<int>();
            vertexStack.Push(srcVertex);
            
            while (vertexStack.Count > 0)
            {
                int vertex = vertexStack.Pop();

                if (visited[vertex] == true)
                    continue;

                Console.Write(vertex + "  ");
                visited[vertex] = true;

                for (int neighbour = 0; neighbour < srcMatrix.GetLength(0); neighbour++)
                //for (int neighbour = srcMatrix.GetLength(0) - 1; neighbour >= 0; neighbour--)
                {
                    if (srcMatrix[vertex, neighbour] == 1 && visited[neighbour] == false)
                    {
                        vertexStack.Push(neighbour);
                    } 
                }
            }
        }

        //====================================================================================================================================
        // No Weights given
        public void BftIterative(int[,] srcMatrix, int srcVertex)
        {
            bool[] visited = new bool[srcMatrix.GetLength(0)];
          
            Queue<int> vertexQueue = new Queue<int>();
            vertexQueue.Enqueue(srcVertex);
            
            while (vertexQueue.Count > 0)
            {
                int vertex = vertexQueue.Dequeue();

                if (visited[vertex] == true)
                    continue;

                Console.Write(vertex+ "  ");
                visited[vertex] = true;

                for (int neighbour = 0; neighbour < srcMatrix.GetLength(1); neighbour++)
                {
                    if (srcMatrix[vertex,neighbour] == 1 && visited[neighbour] == false)
                    {
                        vertexQueue.Enqueue(neighbour);                        
                    }                    
                }
            }
        }
    }
}