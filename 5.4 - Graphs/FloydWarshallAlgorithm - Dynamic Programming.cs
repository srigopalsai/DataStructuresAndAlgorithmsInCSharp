using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs
{
    /*
     * https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/FloydWarshallAllPairShortestPath.java
    http://www.sanfoundry.com/cpp-program-find-all-pairs-shortest-path/
    http://www.geeksforgeeks.org/dynamic-programming-set-16-floyd-warshall-algorithm/
    http://community.topcoder.com/tc?module=Static&d1=tutorials&d2=graphsDataStrucs3
    http://www.algorithmist.com/index.php/Floyd-Warshall%27s_Algorithm

    Find out quickly whether one vertex is reachable from another vertex. 
    E.g. If we can go from A to B and B to C it means we can go from A to C.

    E.g. You want to fly from Athens to Murmansk on Hubris Airlines and you don’t care how many intermediate stops you need to make.
    Is this trip possible?

    You could examine the connectivity table.
    But then you would need to look through all the entries on a given row, which would take O(N) time (where N is the average number of vertices reachable from a given vertex). 
    But is there a faster way?

    It’s possible to construct a table that will tell you instantly (that is, in O(1) time) whether one vertex is reachable from another. 
    Such a table can be obtained by systematically modifying a graph’s adjacency matrix. 
    The graph represented by this revised adjacency matrix is called the transitive closure of the original graph.

    Remember that in an ordinary adjacency matrix the row number indicates where an edge starts and the column number indicates where it ends. (This is similar to the arrangement in the connectivity table.) 
    A 1 at the intersection of row C and column D means there’s an edge from vertex C to vertex D. 
    You can get from one vertex to the other in one step. 
    (Of course, in a directed graph it does not follow that you can go the other way, from D to C.) 

    - A B C D E
    A 0 0 1 0 0
    B 1 0 0 0 1
    C 0 0 0 0 0
    D 0 0 0 0 1
    E 0 0 1 0 0

    You might wonder if this algorithm can find paths of more than two edges. 
    After all, the rule only talks about combining two one-edge paths into one two-edge path. 
    As it turns out, the algorithm will build on previously discovered multi-edge paths to create paths of arbitrary length.

    Row A
    We start with row A. There’s nothing in columns A and B, but there’s a 1 at column
    C, so we stop there.
    Now the 1 at this location says there is a path from A to C. If we knew there was a
    path from some vertex X to A, then we would know there was a path from X to C.
    Where are the edges (if any) that end at A? They’re in column A. So we examine all
    the cells in column A. In Table 13.6 there’s only one 1 in column A: at row B. It says
    there’s an edge from B to A. So we know there’s an edge from B to A, and another
    (the one we started with) from A to C. From this we infer that we can get from B to
    C in two steps. 
        You can verify this is true by looking at the graph in Figure 13.15.
    To record this result, we put a 1 at the intersection of row B and column C. 
        The result is shown in Figure 13.16a.
    The remaining cells of row A are blank.
    Rows B, C, and D
    We go to row B. The first cell, at column A, has a 1, indicating an edge from B to A.
    Are there any edges that end at B? We look in column B, but it’s empty, so we know
    that none of the 1s we find in row B will result in finding longer paths because no
    edges end at B.


     All-pairs shortest path with Floyd- Warshall Someteimes, we have a graph and want to find the shortest path from u to v for all pairs of vertices (u, v). 
     Note that we already know how to do this in  On3 time – we can run the quadratic version of Dijkstra's algorithm from each of the n vertices. 
     However, there is a 4­line algorithm that will do the same job.
     
        http://www.cs.cornell.edu/~wdtseng/icpc/notes/graph_part3.pdf
    */
    public partial class MatrixOperations
    {

        int[,] graph = new int[128,128];
        int n; // a weighted graph and its size

        void floydWarshall()
        {
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        graph[i,j] = Math.Min(graph[i,j], graph[i,k] + graph[k,j]);
                    }
                }
            }
        }
        void main()
        {
            // initialize the graph[,] adjacency matrix and n        
            // graph[i,i] should be zero for all i.        
            // graph[i,j] should be "infinity" if edge (i, j) does not exist        
            // otherwise, graph[i,j] is the weight of the edge (i, j)
            floydWarshall();
            // now graph[i,j] is the length of the shortest path from i to j    }

        }
    }
}