using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms.Graphs.AdjacencyListGraph
{
    /*
    http://www.sanfoundry.com/cpp-program-check-undirected-graph-connected-bfs/
    http://www.vcskicks.com/representing-graphs.php
    http://quickgraph.codeplex.com/releases/view/20160
    http://www.sanfoundry.com/java-program-implement-adjacency-list/
    http://www.sanfoundry.com/java-program-describe-representation-graph-using-adjacency-list/
    */
    class GraphOperations
    {

        //Acyclic - A graph without cycles 
        //http://www.sanfoundry.com/cpp-program-check-cycle-graph-traversal/
        public bool IsCycleExistsInGraph()
        {
            return false;
        }
        //private NodeList nodeSet;

        //public NodeList Nodes
        //{
        //    get
        //    {
        //        return nodeSet;
        //    }
        //}

        //public int Count
        //{
        //    get { return nodeSet.Count; }
        //}

        //public Graph()  { }
        //public Graph(NodeList nodeSet)
        //{
        //    if (nodeSet == null)
        //        this.nodeSet = new NodeList();
        //    else
        //        this.nodeSet = nodeSet;
        //}

        //public void AddNode(GraphNode node)
        //{
        //    // adds a node to the graph
        //    nodeSet.Add(node);
        //}

        //public void AddNode(int value)
        //{
        //    // adds a node to the graph
        //    nodeSet.Add(new GraphNode(value));
        //}

        //public void AddDirectedEdge(GraphNode from, GraphNode to, int cost)
        //{
        //    from.Neighbors.Add(to);
        //    from.Costs.Add(cost);
        //}

        //public void AddUndirectedEdge(GraphNode from, GraphNode to, int cost)
        //{
        //    from.Neighbors.Add(to);
        //    from.Costs.Add(cost);

        //    to.Neighbors.Add(from);
        //    to.Costs.Add(cost);
        //}

        //public bool Contains(int value)
        //{
        //    return nodeSet.FindByValue(value) != null;
        //}

        //public bool Remove(int value)
        //{
        //    // first remove the node from the nodeset
        //    GraphNode nodeToRemove = (GraphNode)nodeSet.FindByValue(value);
        //    if (nodeToRemove == null)
        //        // node wasn't found
        //        return false;

        //    // otherwise, the node was found
        //    nodeSet.Remove(nodeToRemove);

        //    // enumerate through each node in the nodeSet, removing edges to this node
        //    foreach (GraphNode gnode in nodeSet)
        //    {
        //        int index = gnode.Neighbors.IndexOf(nodeToRemove);
        //        if (index != -1)
        //        {
        //            // remove the reference to the node and associated cost
        //            gnode.Neighbors.RemoveAt(index);
        //            gnode.Costs.RemoveAt(index);
        //        }
        //    }

        //    return true;
        //}
    }
}
