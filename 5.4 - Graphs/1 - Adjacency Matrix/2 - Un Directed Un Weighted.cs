using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms.Graphs.Matrix
{
    class UnDirectedUnWeightedGraphOperations
    {
        StringBuilder strBlrd = new StringBuilder();
        Graph UnWeightedUnDirectedGraph;

       /*
       (1)---(2)---(3)
        |   /   \   |
        | (0)    \  |
        | /       \ |
       (5)---------(4)
       */
        public UnDirectedUnWeightedGraphOperations()
        {
            UnWeightedUnDirectedGraph = new Graph(6, false);

            //1. Create Un Weighted Un Directed Graph.
            BuildGraph();

            //2. Is Loop Exists in Graph.
            
            // Create a Loop Node or Loop Vertex.
            UnWeightedUnDirectedGraph.AddUnWightedEdge('E', 'E');

            bool isLoopExists = UnWeightedUnDirectedGraph.IsLoopExists();
            strBlrd.Append("\nIs Loop Exists : " + isLoopExists);
            
            //3. Remove Vertex and It's Edges from Graph. When we remove Vertex, we need to remove all it edges (links) to it's adjacents.
            UnWeightedUnDirectedGraph.RemoveVertex('F');

            strBlrd.Append("\n\nAdjacency Matrix After Vertex ('F') removed : \n\n");
            strBlrd.Append(UnWeightedUnDirectedGraph.ShowAdjacencyMatrix());
            
            MessageBox.Show(strBlrd.ToString());
        }

        public void BuildGraph()
        {
            strBlrd.Append("Un Ordered Un Weighted Graph :\n\n");

            strBlrd.Append(@"(A)--(B)----(C)" + Environment.NewLine);
            strBlrd.Append(@" |      /     \     |" + Environment.NewLine);
            strBlrd.Append(@" |   (F)      \    |" + Environment.NewLine);
            strBlrd.Append(@" |  /           \   |" + Environment.NewLine);
            strBlrd.Append(@"(E)---------(D)" + Environment.NewLine);

            strBlrd.Append(Environment.NewLine);
            
            UnWeightedUnDirectedGraph.AddVertex('A');
            UnWeightedUnDirectedGraph.AddVertex('B');
            UnWeightedUnDirectedGraph.AddVertex('C');
            UnWeightedUnDirectedGraph.AddVertex('D');
            UnWeightedUnDirectedGraph.AddVertex('E');
            UnWeightedUnDirectedGraph.AddVertex('F');

            UnWeightedUnDirectedGraph.AddUnWightedEdge('A', 'B');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('B', 'C');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('C', 'D');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('D', 'E');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('E', 'F');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('F', 'B');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('A', 'E');

            // In Un Directed Each vertex point back to it adjacent.
            UnWeightedUnDirectedGraph.AddUnWightedEdge('B','A');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('C','B');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('D','C');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('E','D');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('F','E');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('B','F');
            UnWeightedUnDirectedGraph.AddUnWightedEdge('E','A');

            strBlrd.Append("Adjacency Matrix : \n\n");
            strBlrd.Append(UnWeightedUnDirectedGraph.ShowAdjacencyMatrix());
        }

        /*

        http://www.geeksforgeeks.org/depth-first-traversal-for-a-graph/
        http://www.sanfoundry.com/java-program-check-whether-undirected-graph-connected-using-dfs/
        http://www.sanfoundry.com/java-program-traverse-graph-using-dfs-2/
       Unlike trees, graphs may contain cycles, so we may come to the same node again. 
       To avoid processing a node more than once, we use a boolean visited array. 
       If we don’t mark visited vertices, then 2 will be processed again and it will become a non-terminating process.
       
       (0)--(1)--(2)
        |   / \   |
        |  /   \  | 
        | /     \ |
       (3)-------(4)
         
       */
        public void DfsTraversalUDGraph()
        {

        }

        /*
        http://www.sanfoundry.com/java-program-traverse-graph-using-bfs/
        */
        public void BfsTraversalUDGraph()
        { 
        }

        #region Directed Graph Operations

        public void DetectCycleInADirectedGraph()
        {
        }

        /*
        We can either use Breadth First Search (BFS) or Depth First Search (DFS) to find path between two vertices. 
        Take the first vertex as source in BFS (or DFS), follow the standard BFS (or DFS). 
        If we see the second vertex in our traversal, then return true. Else return false.

        E.g. In the following graph, there is a path from vertex 1 to 3 but there is no path from 3 to 0.

        (0)---->(1)
         ^     /    
         |    /     
         |   /       ______
         |  /        |    ^
         | V         V    |
        (2)-------->(3)-->|

        */
        public void FindPathBetween2Vertices()
        {
        }

        /*
        http://www.sanfoundry.com/java-program-check-whether-directed-graph-connected-using-dfs/
        */
        public void DfsTraversalDGraph()
        {

        }

        /*
        http://www.sanfoundry.com/java-program-tarjan-algorithm/
        */
        public void TarjanAlgorithm()
        { 
        }

        //http://www.sanfoundry.com/java-program-kosaraju-algorithm/

        /*
        http://www.sanfoundry.com/java-program-topological-sorting-graphs/
        http://www.sanfoundry.com/java-program-check-cycle-graph-using-topological-sort/
        */
        public void TopologicalSort()
        {
        }

        /*
        http://www.sanfoundry.com/java-program-check-whether-graph-biconnected/
        */
        public void IsGraphBiConnected()
        { 
        }
        /*
        http://www.sanfoundry.com/java-program-find-strongly-connected-components-graphs/
        */
        #endregion Directed Graph Operations
    }
}