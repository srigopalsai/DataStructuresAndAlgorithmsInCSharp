using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://jamesmccaffrey.wordpress.com/2011/07/16/a-space-efficient-graph-data-structure-implementation-in-c/
    */
    //public class LowerTriangularBitMatrix
    //{
    //    private BitArray[] data;
    //    public readonly int Dim;

    //    public LowerTriangularBitMatrix(int n)
    //    {
    //        this.data = new BitArray[n - 1];
            
    //        // We will not store the main diagonal so the first row  has no cols and so is not needed
    //        for (int i = 0; i < data.Length; ++i)
    //        {
    //            data[i] = new BitArray(i + 1); // see picture
    //        }
    //        this.Dim = n;
    //    }

    //    public void SetValue(int row, int col, bool value)
    //    {
    //        if (row > col)
    //        {
    //            data[row - 1][col] = value; // normal
    //        }
    //        else
    //        {
    //            data[col - 1][row] = value; // the symmetric part
    //        }
    //    }

    //    public bool GetValue(int row, int col)
    //    {
    //        if (row == col)
    //        {
    //            return false; // main diagonal values
    //        }
    //        if (row > col)
    //        {
    //            return data[row - 1][col];
    //        }
    //        else
    //        {
    //            return data[col - 1][row];
    //        }
    //    }

    //    public override string ToString()
    //    {
    //        string s = "";
    //        s += "x" + Environment.NewLine; // first row diagonal value
    //        for (int i = 0; i < data.Length; ++i)
    //        {
    //            for (int j = 0; j < data[i].Length; ++j)
    //            {
    //                if (data[i][j] == true) s += "1 "; else s += "0 ";
    //            }
    //            s += "x "; // trailing implied diagonal value
    //            s += Environment.NewLine;
    //        }
    //        return s;
    //    }
    //}

    //public class MyGraph // graph which uses a lower triangular matrix
    //{
    //    private LowerTriangularBitMatrix data; // program defined helper class.
    //    private int numberNodes;
    //    private int numberEdges;
    //    private int[] numberNeighbors; // for NumberNeighbors method

    //    public MyGraph(string graphFile, string fileFormat) // ctor
    //    {
    //        if (fileFormat.ToUpper() == "DIMACS")
    //            LoadDimacsFormatGraph(graphFile);
    //        else if (fileFormat.ToUpper() == "SIMPLE")
    //            LoadSimpleFormatGraph(graphFile);
    //        else
    //            throw new Exception("Format " + fileFormat + " not supported");
    //    }

    //    private void LoadSimpleFormatGraph(string graphFile)
    //    {
    //        FileStream ifs = new FileStream(graphFile, FileMode.Open);
    //        StreamReader sr = new StreamReader(ifs);
    //        string line = "";
    //        string[] tokens = null;
    //        string[] subTokens = null;

    //        // count number of lines == number of nodes
    //        int numNodes = 0;
    //        int numEdges = 0;
    //        while ((sr.ReadLine() != null))
    //        {
    //            ++numNodes;
    //        }
    //        sr.Close(); ifs.Close();

    //        this.data = new LowerTriangularBitMatrix(numNodes);

    //        // second pass, parse and store
    //        int fromNode = -1;
    //        int toNode = -1;
    //        ifs = new FileStream(graphFile, FileMode.Open); // reopen file
    //        sr = new StreamReader(ifs);
    //        while ((line = sr.ReadLine()) != null)
    //        {
    //            line = line.Trim();
    //            tokens = line.Split(':'); // separate from-node and to-nodes
    //            tokens[0] = tokens[0].Trim();
    //            tokens[1] = tokens[1].Trim();
    //            fromNode = int.Parse(tokens[0]);
    //            subTokens = tokens[1].Split(' '); // get the to-nodes
    //            for (int i = 0; i < subTokens.Length; ++i)
    //            {
    //                toNode = int.Parse(subTokens[i]);
    //                if (fromNode < toNode)
    //                {
    //                    // because storage is a lower tiangular matrix
    //                    this.data.SetValue(fromNode, toNode, true);
    //                    ++numEdges;
    //                }
    //            }
    //        }
    //        sr.Close(); ifs.Close();

    //        // third pass, get number-adjacent
    //        // iterate through the LowerTriangularBitMatrix data
    //        // by using GetData, which works on a virtual n x n matrix
    //        // we can avoid dealing with the physical representation

    //        this.numberNeighbors = new int[numNodes];
    //        for (int row = 0; row < numNodes; ++row)
    //        {
    //            int count = 0;
    //            for (int col = 0; col < numNodes; ++col)
    //            {
    //                if (data.GetValue(row, col) == true)
    //                    ++count;
    //            }
    //            numberNeighbors[row] = count;
    //        }

    //        this.numberNodes = numNodes;
    //        this.numberEdges = numEdges;
    //        return;
    //    } // LoadSimpleFormatGraph

    //    private void LoadDimacsFormatGraph(string graphFile)
    //    {
    //        // DIMACS is a 'real' format . . .
    //    }

    //    public int NumberNodes
    //    {
    //        get { return this.numberNodes; }
    //    }

    //    public int NumberEdges
    //    {
    //        get { return this.numberEdges; }
    //    }

    //    public int NumberNeighbors(int node)
    //    {
    //        return this.numberNeighbors[node];
    //    }

    //    public bool AreAdjacent(int nodeA, int nodeB)
    //    {
    //        // GetData takes care of row < col or row > col
    //        if (this.data.GetValue(nodeA, nodeB) == true)
    //            return true;
    //        else
    //            return false;
    //    }

    //    public override string ToString()
    //    {
    //        string s = "";
    //        for (int i = 0; i < this.data.Dim; ++i)
    //        {
    //            s += i + ": ";
    //            for (int j = 0; j < this.data.Dim; ++j)
    //            {
    //                if (this.data.GetValue(i, j) == true)
    //                    s += j + " ";
    //            }
    //            s += Environment.NewLine;
    //        }
    //        return s;
    //    }
    //}
   

}