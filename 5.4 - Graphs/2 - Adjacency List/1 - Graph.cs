using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs.AdjacencyList
{
   //  https://github.com/mission-peace/interview/blob/master/src/com/interview/graph/Graph.java
     
    public class Vertex
    {
        public String Name { get; set; }

        public int Value { get; set; }

        public bool IsVisited { get; set; }

        public List<Edge> Adjacents { get; set; }

        public double MinDistance { get; set; } = Double.PositiveInfinity;

        public Vertex Previous { get; set; }

        public Vertex(String name = "", int value = 0)
        {
            Name = name;
            Value = value;
        }
    }

    public class Edge
    {
        public Vertex Target { get; set; }

        public int Weight { get; set; }

        public Edge(Vertex target, int weight = 0)
        {
            Target = target;
            Weight = weight;
        }
    }

    class Graph
    {
        Dictionary<int, string> NameValues = new Dictionary<int, string>();

        public List<Vertex> Verticies { get; set; }

        string[] names = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public bool IsDirected { get; set; }

        public bool IsWeighted { get; set; }

        public Graph(bool isDirected = false, bool isWeighted = false)
        {
            IsDirected = isDirected;
            IsWeighted = isWeighted;
            Verticies = new List<Vertex>();

            for (int lpCnt = 0; lpCnt < 26; lpCnt++)
                NameValues.Add(lpCnt, names[lpCnt]);
        }

        public void Clear()
        {
            Verticies.Clear();
            IsDirected = false;
            IsWeighted = false;
        }

        public Vertex AddVertex(int vertexVal)
        {
            Vertex vertex = new Vertex(string.Empty, vertexVal);
            Verticies.Add(vertex);

            return vertex;
        }

        public Vertex AddVertex(string vertexName)
        {
            Vertex vertex = new Vertex(vertexName);
            Verticies.Add(vertex);

            return vertex;
        }

        public void AddAdjacent(Vertex srcVertex, Vertex targetVertex)
        {
            srcVertex.Adjacents.Add(new Edge(targetVertex));
        }

        public void CreateFromMatrix(int[,] matrix, bool display = true, bool isDirected = false)
        {
            Clear();
            this.IsDirected = isDirected;
            this.IsWeighted = IsWeighted;

            for (int lpRCnt = 0; lpRCnt < matrix.GetLength(0); lpRCnt++)
            {
                Verticies.Add(new Vertex() { Name = NameValues[lpRCnt], Value = lpRCnt });
            }

            for (int lpRCnt = 0; lpRCnt < matrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < matrix.GetLength(1); lpCCnt++)
                {
                    if (matrix[lpRCnt, lpCCnt] != 0)
                    {
                        if (Verticies[lpRCnt].Adjacents == null)
                            Verticies[lpRCnt].Adjacents = new List<Edge>();

                        Verticies[lpRCnt].Adjacents.Add(new Edge(Verticies[lpCCnt], matrix[lpRCnt, lpCCnt]));

                        if (isDirected == false)
                        {
                            if (Verticies[lpCCnt].Adjacents == null)
                                Verticies[lpCCnt].Adjacents = new List<Edge>();

                            Verticies[lpCCnt].Adjacents.Add(new Edge(Verticies[lpRCnt], matrix[lpRCnt, lpCCnt]));
                        }
                    }
                }
            }

            //if (isDirected == false)
            //{
            //    for (int lpRCnt = 0; lpRCnt < matrix.GetLength(0); lpRCnt++)
            //    {
            //        for (int lpCCnt = 0; lpCCnt < matrix.GetLength(1); lpCCnt++)
            //        {
            //            if (matrix[lpRCnt, lpCCnt] != 0)
            //            {
            //                if (Verticies[lpRCnt].Adjacents == null)
            //                    Verticies[lpRCnt].Adjacents = new List<Edge>();

            //                Verticies[lpCCnt].Adjacents.Add(new Edge(Verticies[lpRCnt], matrix[lpRCnt, lpCCnt]));
            //            }
            //        }
            //    }
            //}

            if (display == true)
            {
                for (int lpRCnt = 0; lpRCnt < matrix.GetLength(0); lpRCnt++)
                {
                    for (int lpCCnt = 0; lpCCnt < matrix.GetLength(1); lpCCnt++)
                    {
                        Console.Write(matrix[lpRCnt, lpCCnt] + "  ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void DisplayAdjacencyList()
        {
            if (this.Verticies == null || this.Verticies.Count == 0)
            {
                Console.WriteLine("No nodes in graph to display");
                return;
            }

            for (int lpRCnt = 0; lpRCnt < this.Verticies.Count; lpRCnt++)
            {
                Console.Write(Verticies[lpRCnt].Name + "  ->  ");

                if (Verticies[lpRCnt].Adjacents == null || Verticies[lpRCnt].Adjacents.Count == 0)
                    continue;

                for (int lpCCnt = 0; lpCCnt < Verticies[lpRCnt].Adjacents.Count; lpCCnt++)
                {
                    Console.Write(Verticies[lpRCnt].Adjacents[lpCCnt].Target.Name + "(" + Verticies[lpRCnt].Adjacents[lpCCnt].Weight + ")  ");
                }
                Console.WriteLine();
            }
        }
    }
}