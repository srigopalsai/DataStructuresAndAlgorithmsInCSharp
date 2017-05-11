using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs.Matrix
{
    public class Vertex
    {
        public Point Point { get; set; }

        public int Distance { get; set; }
    }

    public class Graph
    {
        public int NoOfVertices { get; set; }
        public List<char> AdjancecyVerticesList { get; set; }

        // For maintaing Edge information.
        int[,] AdjancencyMatrix;

        bool isWeightedGraph = false;
        
        public bool IsWeightedGraph
        {
            get
            {
                return isWeightedGraph;
            }
        }

        public Graph(int graphLenght, bool isWeightedGraph)
        {
            if (AdjancecyVerticesList == null)
            {
                AdjancecyVerticesList = new List<char>();
            }

            this.isWeightedGraph = isWeightedGraph;
            AdjancencyMatrix = new int[graphLenght, graphLenght];
        }

        public string ToString()
        {
            return ShowAdjacencyMatrix();
        }

        public string ShowAdjacencyMatrix()
        {
            StringBuilder resultMessage = new StringBuilder();

            int tmpHdr = 0;
            resultMessage.Append("\t");

            for (tmpHdr = 0; tmpHdr < AdjancencyMatrix.GetLength(0); ++tmpHdr)
            {
                resultMessage.Append(AdjancecyVerticesList[tmpHdr] + "\t");
            }

            resultMessage.Append("\n\n");

            for (int lpRCnt = 0; lpRCnt < AdjancencyMatrix.GetLength(0); ++lpRCnt)
            {
                resultMessage.Append(AdjancecyVerticesList[lpRCnt] + "\t");

                for (int lpCCnt = 0; lpCCnt < AdjancencyMatrix.GetLength(1); ++lpCCnt)
                {
                    resultMessage.Append(AdjancencyMatrix[lpRCnt, lpCCnt] + "\t");
                }

                resultMessage.Append(Environment.NewLine);
            }
            return Convert.ToString(resultMessage);
        }

        //=============================================================================================================================================================================================

        public bool AddUnWightedEdge(char vertex1, char vertex2)
        {
            if (IsWeightedGraph == true)
            {
                throw new Exception("Created Graph is Weighted, Use this function only for Unweighted graph operations.");
            }

            int vertex1Pos = AdjancecyVerticesList.IndexOf(vertex1);
            int vertex2Pos = AdjancecyVerticesList.IndexOf(vertex2);

            AdjancencyMatrix[vertex1Pos, vertex2Pos] = 1;
            return false;
        }

        public bool AddWightedEdge(char vertex1, char vertex2, char weight)
        {
            if (IsWeightedGraph == false)
            {
                throw new Exception("Created Grapg is UnWeighted, Use this function only for weighted graph operations.");
            }

            int vertex1Pos = AdjancecyVerticesList.IndexOf(vertex1);
            int vertex2Pos = AdjancecyVerticesList.IndexOf(vertex2);

            AdjancencyMatrix[vertex1Pos, vertex2Pos] = weight;
            return false;
        }
        
        public bool AddVertex(char vertex)
        {
            if (AdjancecyVerticesList == null)
            {
                throw new Exception("Graph is not initialized");
            }

            AdjancecyVerticesList.Add(vertex);
            return true;
        }

        public bool RemoveEdge(int vertexPos)
        {
            for (int lpCCnt = 0; lpCCnt < AdjancencyMatrix.GetLength(0); ++lpCCnt)
            {
                AdjancencyMatrix[vertexPos, lpCCnt] = 0;
            }
            for (int lpRCnt = 0; lpRCnt < AdjancencyMatrix.GetLength(1); ++lpRCnt)
            {
                AdjancencyMatrix[lpRCnt, vertexPos] = 0;
            }
            return false;
        }

        public bool RemoveVertex(char vertex)
        {
            int vertexPos = AdjancecyVerticesList.IndexOf(vertex);
            AdjancecyVerticesList.Remove(vertex);
            AdjancecyVerticesList.Insert(vertexPos, '-');

            RemoveEdge(vertexPos);
            return false;
        }

        public bool ClearGraph()
        {
            return false;
        }
        
        //=============================================================================================================================================================================================

        public string GetShortestPath()
        {
            return ToString();
        }

        public string GetLongestPath()
        {
            return ToString();
        }

        public string DepthFirstSearch()
        {
            return ToString();
        }

        public string BreadthFirstSearch()
        {
            return ToString();
        }

        //=============================================================================================================================================================================================

        /* Acyclic - A graph without cycles 
        Time Complexity : O(E Log V). Can use DFS.
        
        For every visited vertex ‘v’, if there is an adjacent ‘u’ such that u is already visited and u is not parent of v, then there is a cycle in graph. 
        If we don’t find such an adjacent for any vertex, we say that there is no cycle. 
        Assumption : There are no parallel edges between any two vertices.
        Find all cycles http://stackoverflow.com/questions/12367801/finding-all-cycles-in-undirected-graphs?noredirect=1&lq=1
        Johnson's Algorithm -
        Torjans Algorithm
        Kosaraju.
        https://github.com/danielrbradley/CycleDetection

            https://github.com/t1/graph/blob/master/src/main/java/com/github/t1/graph/StronglyConnectedComponentsFinder.java

            Tarjan's algorithm		Strongly Connected Graph		Uses Single Pass DFS and 1 Stack	O(|V| + |E|)			
            Sample https://github.com/t1/graph/blob/master/src/main/java/com/github/t1/graph/StronglyConnectedComponentsFinder.java
            https://stackoverflow.com/questions/6643076/tarjan-cycle-detection-help-c-sharp#sca
            http://www.personal.kent.edu/~rmuhamma/Algorithms/MyAlgorithms/GraphAlgor/depthSearch.htm
            http://www.me.utexas.edu/~bard/IP/Handouts/cycles.pdf
            http://stackoverflow.com/questions/546655/finding-all-cycles-in-graph/33956957#33956957
        */
        public bool IsCycleExistsInGraph()
        {
            return false;
        }

        //Network Flow Problem http://www.sanfoundry.com/cpp-program-network-flow-problem/
        public bool IsLoopExists()
        {
            bool loopFound = false;

            for (int lpCnt = 0; lpCnt < AdjancencyMatrix.GetLength(0); lpCnt++)
            {
                if (AdjancencyMatrix[lpCnt, lpCnt] == 1)
                {
                    loopFound = true;
                    break;
                }
            }

            return loopFound;
        }

        public bool DetectLoop(int[,] a)
        {
            int total = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i,j] == 1 && i != j)
                    {
                        count = count + 1;
                    }
                    else if (i == j && a[i,j] == 1)
                    {
                        count = count + 2;
                        // Vertex i + 1 contain self loop in a graph", i + 1);
                    }
                }
            }

            return true;
        }
        public bool IsPathExists(char vertex1, char vertex2)
        {
            return false;
        }

        public bool IsVertexExists(char vertex)
        {
            return false;
        }

        public bool IsDirectedGraph()
        {
            return false;
        }

        /*
        http://www.sanfoundry.com/cpp-program-graph-bipartite-dfs/
        http://www.sanfoundry.com/cpp-program-graph-bipartite-bfs/
        http://www.sanfoundry.com/cpp-program-bipartite-2-color-algorithm/
        https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/BiparteGraph.java
        */
        public bool IsGraphBiparatiteDFS()
        {
            return false;
        }

        /*
        http://www.sanfoundry.com/cpp-program-graph-biconnected/
        */
        public bool IsGraphBiConnected()
        {
            return false;
        }

        /*
http://www.sanfoundry.com/cpp-program-check-directed-graph-connected-dfs/
http://www.sanfoundry.com/cpp-program-check-undirected-graph-connected-dfs/
http://www.sanfoundry.com/cpp-program-check-undirected-graph-connected-bfs/
*/
        public void IsConnected()
        {

        }

        public bool AreAdjecentsOrNeighbors(char vertex1, char vertex2)
        {
            return false;
        }

        public string MazeTraversal()
        {
            return ToString();
        }

        //=============================================================================================================================================================================================

        public void FindSingleSoruceShortestPath(){}

        /*
        http://www.sanfoundry.com/cpp-program-find-all-pairs-shortest-path/
        */
        public void FindAllPairsShortestPath()
        { 
        }

        public void FindAllForwardEdgesInAGraph()
        {
        }

        public void FindAllCrossEdgesInAGraph()
        {
        }

        public void FindAllBackEdgesInAGraph()
        {
        }

        public void FindNoOfArticulationPointsInAGraph()
        {
        }

        //=============================================================================================================================================================================================

        /*
        Unlike Trees, Graphs may contain cycles, so while visiting we may come to the same node again. 
        To avoid processing a node more than once, we use a boolean visited array. For simplicity, it is assumed that all vertices are reachable from the starting vertex.
        */
        public void BirthFirstSearch()
        { 
        }
        public void DepthLimitedSearch()
        {
        }

        public void UniformCostSearch()
        {
        }

        public void IterativeDeepening() 
        {
        }

        /*
        http://www.sanfoundry.com/java-program-implement-max-flow-min-cut-theorem/
        */
        public void MaxFlowMinCutTheorem()
        {
        }

        /*
        http://www.sanfoundry.com/java-program-implement-network-flow-problem/
        */
        public void NetworkFlowProblem()
        {
        }
                
        public void WordWrapProblem()
        {
        }

        public void MaximumLenghtChainOfPairs() 
        { 
        }

        //=============================================================================================================================================================================================
    }
}

/*
For lesser space consider using BitArray instead of Boolean Array.

A BitArray uses one bit for each value, while a bool[] uses one byte for each value.
A BitArray uses 32 times less memory compare to bool array.

True indicates that the bit is on (1) and False indicates the bit is off (0).

E.g.

    byte[] myBytes = new byte[5] { 1, 2, 3, 4, 5 };
    BitArray myBA3 = new BitArray( myBytes );

    bool[] myBools = new bool[5] { true, false, true, true, false };
    BitArray myBA4 = new BitArray( myBools );

    int[]  myInts  = new int[5] { 6, 7, 8, 9, 10 };
    BitArray myBA5 = new BitArray( myInts );
*/