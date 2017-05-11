using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs
{
    public partial class MatrixOperations
    {
        /*
        Strongly Connected:
        -------------------
        If every node can be reached from a vertex v, and every node can reach same vertex v, then the graph is strongly connected. 
        
        Un Directed Graph:
        ------------------
        We can just do a BFS or DFS starting from any vertex. If BFS or DFS visits all vertices, then the given undirected graph is connected. 
        
        Directed Graph:
        ---------------
        A simple idea is to use a all pair shortest path algorithm like Floyd Warshall or find Transitive Closure of graph. 
        Time complexity of this method would be O(v3).
        
        We can also do DFS V times starting from every vertex. If any DFS, doesn’t visit all vertices, then graph is not strongly connected. 
        This algorithm takes O(V*(V+E)) time which can be same as transitive closure for a dense graph.
        A better idea can be Strongly Connected Components (SCC) algorithm. We can find all SCCs in O(V+E) time. 
        If number of SCCs is one, then graph is strongly connected. The algorithm for SCC does extra work as it finds all SCCs. 

        Kosaraju Algorithm : 
        --------------------
        1) Do a BFS or DFS traversal of graph starting from any arbitrary vertex v. 
            If traversal doesn’t visit all vertices, then return false.

        3) Reverse all edges (or find transpose or reverse of graph)

        4) Mark all vertices as not visited in reversed graph.

        5) Again do a BFS or DFS traversal of reversed graph starting from same vertex v (Same as step 2). 
            If BFS traversal doesn’t visit all vertices, then return false.  Otherwise, return true.

        Tarjan’s Algorithm:
        -------------------
        We can find whether a graph is strongly connected or not in one traversal.
         */
    }
}
