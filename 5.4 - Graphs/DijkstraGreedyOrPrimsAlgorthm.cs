using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs.AdjacencyList
{
    /*http://www.bogotobogo.com/Algorithms/Dijkstra_Shortest_Path.php
    Dijkstra is a Greedy algorithm  
    Single Source Shortest Path is the problem to find path from one designated vertex to every other vertex in the graph
    Prims Algorthm
    https://www.topcoder.com/community/data-science/data-science-tutorials/introduction-to-graphs-and-their-data-structures-section-2/
    For Graph DFS refer FloodFill program

        Player exchange problem we want to exchange the positions of two players on a grid. There are impassable spaces represented by ‘X’ and spaces that we can walk in represented by ‘ ‘. Since we have two players our node structure becomes a bit more complicated, we have to represent the positions of person A and person B. Also, we won’t be able to simply use our array to represent visited positions any more, we will have an auxiliary data structure to do that. Also, we are allowed to make diagonal movements in this problem, so we now have 9 choices, we can move in one of 8 directions or simply stay in the same position. Another little trick that we have to watch for is that the players can not just swap positions in a single turn, so we have to do a little bit of validity checking on the resulting state. 
    */

    public class Dijkstra
    {
        public void DijkstraSPTest()
        {
            Graph graph = new Graph();

            Vertex CityA = BuildAdjListGraph(graph);
            Vertex CityZ = graph.Verticies[graph.Verticies.Count - 1];

            Console.Clear();
            graph.DisplayAdjacencyList();

            ComputeAllPathsByDijkstra(CityA);
            List<Vertex> path = GetShortestPathTo(CityZ);

            Console.WriteLine(string.Format("Shortest Distance From {0} To {1} is {2}", CityA.Name, CityZ.Name, CityZ.MinDistance));

            Console.ReadLine();
            graph.Clear();

            int[,] srcMatrix = TestData.MatrixCollection[TestData.Keys.TenByTen1];

            graph.CreateFromMatrix(srcMatrix, true, false);
            graph.DisplayAdjacencyList();

            ComputeAllPathsByDijkstra(graph.Verticies[0]);
            path = GetShortestPathTo(graph.Verticies[2]);

            Console.WriteLine(string.Format("Shortest Distance From {0} To {1} is {2}",
                                                    graph.Verticies[0].Name, graph.Verticies[2].Name, graph.Verticies[0].MinDistance));
            Console.Read();
        }

        public void ComputeAllPathsByDijkstra(Vertex source)
        {
            source.MinDistance = 0;

            Queue<Vertex> vertexQueue = new Queue<Vertex>();
            vertexQueue.Enqueue(source);

            while (vertexQueue.Count > 0)
            {
                Vertex vertexU = vertexQueue.Dequeue();

                foreach (Edge edge in vertexU.Adjacents)
                {
                    Vertex vertexV = edge.Target;
                    double distanceThroughU = vertexU.MinDistance + edge.Weight;

                    if (distanceThroughU < vertexV.MinDistance)
                    {
                        vertexV.MinDistance = distanceThroughU;
                        vertexV.Previous = vertexU;
                        vertexQueue.Enqueue(vertexV);
                    }
                }
            }
        }

        public List<Vertex> GetShortestPathTo(Vertex target)
        {
            List<Vertex> pathList = new List<Vertex>();

            for (Vertex vertex = target; vertex != null; vertex = vertex.Previous)
                pathList.Add(vertex);

            pathList.Reverse();

            Console.Write(pathList[0].Name + " (" + pathList[0].MinDistance + ") - ");

            for (int lpRCnt = 1; lpRCnt < pathList.Count; lpRCnt++)
                Console.Write(pathList[lpRCnt].Name + " (" + (pathList[lpRCnt].MinDistance - pathList[lpRCnt - 1].MinDistance) + ") - ");

            Console.WriteLine();
            return pathList;
        }

        private Vertex BuildAdjListGraph(Graph graph)
        {
            /*  List of Distances between Cities:

                A - B : 10
                F - K : 23
                R - M : 8
                K - O : 40
                Z - P : 18
                J - K : 25
                D - B : 11
                M - A : 8
                P - R : 15  */

            Vertex CityA = graph.AddVertex("A");
            Vertex CityB = graph.AddVertex("B");
            Vertex CityD = graph.AddVertex("D");
            Vertex CityF = graph.AddVertex("F");
            Vertex CityK = graph.AddVertex("K");
            Vertex CityJ = graph.AddVertex("J");
            Vertex CityM = graph.AddVertex("M");
            Vertex CityO = graph.AddVertex("O");
            Vertex CityP = graph.AddVertex("P");
            Vertex CityR = graph.AddVertex("R");
            Vertex CityZ = graph.AddVertex("Z");

            // Set the edges and weight
            CityA.Adjacents = new List<Edge> { new Edge(CityB, 10) };
            CityB.Adjacents = new List<Edge> { new Edge(CityA, 10) };
            CityA.Adjacents = new List<Edge> { new Edge(CityM, 08) };
            CityM.Adjacents = new List<Edge> { new Edge(CityA, 08) };
            CityB.Adjacents = new List<Edge> { new Edge(CityD, 11) };
            CityD.Adjacents = new List<Edge> { new Edge(CityB, 11) };
            CityF.Adjacents = new List<Edge> { new Edge(CityK, 23) };
            CityK.Adjacents = new List<Edge> { new Edge(CityF, 23) };
            CityK.Adjacents = new List<Edge> { new Edge(CityO, 40) };
            CityO.Adjacents = new List<Edge> { new Edge(CityK, 40) };
            CityJ.Adjacents = new List<Edge> { new Edge(CityK, 25) };
            CityK.Adjacents = new List<Edge> { new Edge(CityJ, 25) };
            CityM.Adjacents = new List<Edge> { new Edge(CityR, 08) };
            CityR.Adjacents = new List<Edge> { new Edge(CityM, 08) };
            CityR.Adjacents = new List<Edge> { new Edge(CityP, 15) };
            CityP.Adjacents = new List<Edge> { new Edge(CityR, 15) };
            CityP.Adjacents = new List<Edge> { new Edge(CityZ, 18) };
            CityZ.Adjacents = new List<Edge> { new Edge(CityP, 18) };

            return CityA;
        }

        //======================================================================================================================================
        //http://programmingcindia.blogspot.com/2014/03/c-program-for-shortest-path-using.html
        //void ComputeAllPathsByDijkstra(int[,] G, int n, int startnode)
        //{
        //    int MAX = G.GetLength(0);
        //    int[,] cost = new int[MAX, MAX];
        //    int[] distance = new int[MAX];
        //    int[] pred = new int[MAX];
        //    bool[] visited = new bool[MAX];
        //    int count, mindistance, nextnode=0;

        //    int i = 0, j = 0;
        //    // pred[] stores the predecessor of each node count gives the number of nodes seen so far
        //    //create the cost matrix
        //    for (i = 0; i < n; i++)
        //    {
        //        for (j = 0; j < n; j++)
        //        {
        //            if (G[i, j] == 0)
        //            {
        //                //cost[i,j]= INFINITY;Double.PositiveInfinity;
        //            }
        //            else
        //                cost[i, j] = G[i, j];
        //        }
        //    }

        //    //initialize
        //    for (i = 0; i < n; i++)
        //    {
        //        distance[i] = cost[startnode, i];
        //        pred[i] = startnode;
        //        visited[i] = false;
        //    }

        //    distance[startnode] = 0;
        //    visited[startnode] = true;
        //    count = 1;
        //    while (count < n - 1)
        //    {
        //        mindistance = INFINITY;
        //        // nextnode is the node at minimum distance
        //        for (i = 0; i < n; i++)
        //            if (distance[i] < mindistance && visited[i] == false)
        //            {
        //                mindistance = distance[i];
        //                nextnode = i;
        //            }

        //        //check if a better path exist through nextnode
        //        visited[nextnode] = true;

        //        for (i = 0; i < n; i++)
        //        {
        //            if (visited[i] == false)
        //            {
        //                if (mindistance + cost[nextnode, i] < distance[i])
        //                {
        //                    distance[i] = mindistance + cost[nextnode, i];
        //                    pred[i] = nextnode;
        //                }
        //                count++;
        //            }
        //        }

        //        //print the path and distance of each node
        //        for (i = 0; i < n; i++)
        //        {
        //            if (i != startnode)
        //            {
        //                Console.Write(string.Format("\n Distance of {0} = {1} ", i, distance[i]));
        //                Console.Write("\nPath =  " + i);
        //                j = i;
        //                do
        //                {
        //                    j = pred[j];

        //                    Console.Write("<- " + j);
        //                } while (j != startnode);
        //            }
        //        }
        //    }
        //}

        //======================================================================================================================================
    }
}