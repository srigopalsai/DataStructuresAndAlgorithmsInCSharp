/*
    ===================================================================================================================================================================================================
    
    Graph:
    
    A graph G consists of two types of elements, namely vertices and edges.
    
         A
        / \
       /   \
      B-----C

    G = ( V, E) Read as Graph 'G' contains V 'set of Vertices' and E set of Edges. 

    Vertex/vertices (Node):

    A vertex is simply drawn as 'a node' or 'a dot'. 
    It can have a name, which we will call the 'key'. 
    A vertex may also have additional information. We will call this additional information as 'payload'.

    n = | V | ( no of vertices in a graph)
    
    V = {A,B,C}

    Edge (Line or Link):
    
    An edge connects 2 vertices to show that there is a relationship between them. 
    Every edge has two endpoints in the set of vertices, and is said to connect or join the two endpoints.    
    The two endpoints of an edge are also said to be adjacent to each other.

    E = {(A,B),(B,C),(C,A)}  Or  E = {(B,A),(C,B),(A,C)} For Un-Directed Graph.

    m = | E | (no of edges in a graph)

    As in mathematics, an edge (x,y) is said to point or go from x to y.
    The vertices belonging to an edge are called the ends, endpoints, or end vertices of the edge. 

    A vertex may exist in a graph and not belong to an edge.

    Realize that all trees are graphs. 
    A tree is a special case of a graph in which all nodes are reachable from some starting node and one that has no cycles. 
    
    The Graph data structure can consists of three parts:

    1. A Vertex class that represents 'A Node' in the graph.
    2. An Edge class that forms 'A link between two vertices'.
    3. A Graph class that represents the collection of 'Edges' and 'Vertices'.
    DFS & BFS : https://www.youtube.com/watch?v=eXaaYoTKBlE
    http://www.inf.ed.ac.uk/teaching/courses/cs2/LectureNotes/CS2Bh/ADS/lecture9.pdf
http://www.opendatastructures.org/ods-java/12_Graphs.html
http://programmers.stackexchange.com/questions/166212/generic-adjacency-list-graph-implementation
http://www.mathcove.net/petersen/lessons/get-lesson?les=9
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Types of Graphs :

    1. Un Weighted Un-Directed Graph: 
       A graph in which vertices are connected with out direction.
           
        (0)---(1)---(2)
         |   /   \   |
         |  /     \  |
         | /       \ |
        (3)---------(4)


     2. Un Weighted Directed Graph: 
        Vertices connected by specifying the direction. 
     
        (0)-->(1)-->(2)
         ^    ^ ^    ^
         |   /   \   |
         |  /     \  |
         v /       \ v
        (3)<------->(4)

    3. Weighted Un Directed Graph:
       A number will be given to each edge/link.
    
                New York
          700  /       \  20
              /         \
        Boston----600----New Jersey

    4. Weighted Directed Graph:

               New York
          700  /       \  20
              V         V
        Boston--->600---->New Jersey

    Un Directed Graph Representation    :   G = (V, E)
    Directed Graph Representation       :   D = (V, A)

        V a set whose elements are called vertices or nodes.
        A a set of ordered pairs of vertices, called arcs, directed edges, or arrows.

    Each edge is a tuple (v,w) where w, v ∈ V. 
    We can add a third component to the edge tuple to represent a weight.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Representation of Graphs :
    
    1. Adjacency List:

        Vertices are stored as records or objects, and every vertex stores a list of adjacent vertices. 
        This data structure allows the storage of additional data on the vertices. 
        Additional data can be stored if edges are also stored as objects, in which case each vertex stores its incident edges and each edge stores its incident vertices.

    2. Adjacency Matrix:

        A two-dimensional matrix, in which the rows represent source vertices and columns represent destination vertices. 
        Data on edges and vertices must be stored externally. 
        Only the cost for one edge can be stored between each pair of vertices.
        Good for more complete Graphs.

    3. Incidence Matrix: 

        A two-dimensional Boolean matrix, in which the rows represent the vertices and columns represent the edges. 
        The entries indicate whether the vertex at a row is incident to the edge at a column.
    
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Adjacency Matrix Approach:

    Vertices Values can be stored in an array or a hash table.
    And then store their indeces in matrix.

    https://www.youtube.com/watch?v=eEQ00TKw1Ww

    Un Weighted: (Boolean - True/False)
    Undirected: In Symmentric when matrix diagnally (\) devided both sides will be smae. 
    Directed: In Asymmantic when matrix diagnally (\) devided both sides will NOT be smae.

    Weighted: (Store the weight)    Same as Above.
    Undirected: In Symmentric when matrix diagnally (\) devided both sides will be smae.
    Directed: In Asymmantic when matrix diagnally (\) devided both sides will NOT be smae.

    In general we can visit either lower or upper triangle. Use the below give logic.

    int numEdges = 0;
    
    for(int lpRCnt = 0; lpRCnt  < RowLength; lpRCnt++)
    {
        // Here we are visiting the lower part triangle of the matrix.
        for(int lpCCnt = 0; lpCCnt  < lpRCnt; lpCCnt++)
        {
            if(AdjMatrix[lpRCnt,lpCCnt] != -1)
            {
                numEdges++;
            }        
        }   
    }
    
    // Should not forget to  double.
    numEdges = numEdges *2;

    Note : More space wastage if edges are less and if we use Adjacency matrix.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Number of Edges in a Graph :         Here 'n' indicates no of nodes i.e. Vertices.
    
    Undirected Graph  :   n * ( n - 1 ) / 2     E.g. 10 X ( 10 - 1 ) / 2 = 45
    Directed Graph    :   n * ( n - 1 )              10 X ( 10 - 1 )     = 90

    0 Edges <-------------------------------------------------------------------------------> n * ( n - 1 ) / 2    OR       n * ( n - 1 )
            <-----------------Sparser -------- n Vertices ------- Denser ------------------->
    
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Adjacency Linked List Approach : n + e * 2 * 2 = n + 4e 
  
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Graph Terms:

    1. Degree:

    No of Vertices connected or associate to one Vertex.
    E.G. Degree(A) = 2 and Degree(B) = 3

           A
          / \
         /   \
        B-----C
        |
        |
        D
    
    For UnDirected - No of adjacent vertices.
    For Directed   - Refer OutDegree() and InDegree() based on the direction.
    
      0->1->2->0
      3->3, so the function must return true.

    Even Vertex     :    Degree of v is even.
    Odd Vertex      :    Degree of v is odd.
    Isolated Vertex :    Degree of v is zero.
    
    2. Leaf OR Leaf Node OR Leaf Vertex OR (Pendant Vertex):
    
    Is a vertex with degree one.

    If T is a rooted tree, this is equivalent to saying that 'v' has no child nodes. 

    E.g:    (0)---(1)---(2)
             |   /   \   |
             |  /     \  |
             | /       \ |
            (3)---------(4)--------(5)

    (5) - Is a Leaf Node.
    
    3. Path:
    Sequence Of Vertices between 2 vertices. 

    4. Connected Graph:
    A Path between every single vertice in a Graph is connnected to another.

    5. Simple Path: 
    Path with no repeating vertices.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    6. Cycle: (Uni Cyclic Graph)
    A Path Begins and Ends at the same point.

    E.g:    
    1.          1----
                |___|

    2.          1 <------------> 2
    
    3.          1---3   
                |  /
                | /
                2
    
    4.          1----2
                |    |
                3----4
    
    5.          1----2
                |      \
                |       5
                |      /
                3----4 

    Cycle Graph or Circular Graph:

    Cycle Graphs are not Trees.
    
    The cycle graph with n vertices is called Cn. (c X n).

    The number of vertices in Cn equals to the number of edges, and every vertex has degree 2; that is, every vertex has exactly two edges incident with it.

    Simple Cycle:

    http://en.wikipedia.org/wiki/Cycle_graph

    Acyclic Graph:
    If a graph is acyclic, then it must have at least one node with no targets (called a leaf).

    If we "peel off" a leaf node in an acyclic graph, then we are always left with an acyclic graph.
    
    If we keep peeling off leaf nodes, one of two things will happen:

    We will eventually peel off all nodes: The graph is acyclic. 
    OR
    We will get to a point where there is no leaf, yet the graph is not empty: The graph is cyclic.

    http://www.cs.hmc.edu/~keller/courses/cs60/s98/examples/acyclic/
    
    
    In a Directed Graph each vertices can traverse to another, if it can reach back to itself finally then there is cycle.
    
        (0)---->(1)
         ^     /    
         |    /     
         |   /       ______
         |  /        |    ^
         | V         V    |
        (2)<------->(3)-->|
     
    E.g. The following graph contains 3 cycles
    
     1.  0 -> 2 -> 0

    6. Acyclic Graph: - A graph without cycles.
    
    7. Loop: (self-loop, Buckle)
    Is an edge that connects a vertex to itself.

    8. Weight: (Already mentioned in graph types)
    Edges may be weighted to show that there is a cost to go from one vertex to another. 
    E.g: in a graph of roads that connect one city to another, the weight on the edge might represent the distance between the two cities.

    13. Symmetric Relationship:
    If A points to B then B points to A. E.g. Un directed Graph, In Directed 2 vertices v1,v2 pointing each other.

    14. Asymmetric Relationship:
    If A points to B but B may not points to A. E.g. In Directed Graph, one vertex (v1) pointing to other (v2) but v2 may not point back to v1. 
   
    15. Adjacency Relation:
    The edges E of an undirected graph G induce a symmetric binary relation ~ on V that is called the adjacency relation of G. 
    Specifically, for each edge {v1, v2} the vertices v1 and v2 are said to be adjacent to one another, which is denoted v1 ~ v2.
    
    16. Half-edges, loose edges:
    In certain situations it can be helpful to allow edges with only one end, called half-edges, or no ends (loose edges); see for example signed graphs and biased graphs.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    10. Simple Graph:
    An undirected graph that has no loops (edges connected at both ends to the same vertex) and no more than one edge between any two different vertices.
    In a simple graph the edges of the graph form a set (rather than a multiset) and each edge is a distinct pair of vertices.

    11. Mixed Graph:
    G is a graph in which some edges may be directed and some may be undirected. It is written as an ordered triple G = (V, E, A) 

    11. Strongly Connected:
    For Directed Graph. There is a path connecting every pair of vertices

    12. Complete Graph:
    
    17. Signed Graph:
    A graph in which each edge has a positive or negative sign

    Regular Graph:
    Is a graph where each vertex has the same number of neighbors; i.e. every vertex has the same degree or valency. 
    A regular directed graph must also satisfy the stronger condition that the indegree and outdegree of each vertex are equal to each other.
    A regular graph with vertices of degree k is called a k‑regular graph or regular graph of degree k.
    http://en.wikipedia.org/wiki/Regular_graph

    Strongly Connected Graph :

    A graph is said to be strongly connected if every vertex is reachable from every other vertex.
    It is possible to test the strong connectivity of a graph, or to find its strongly connected components, in linear time.
    A directed graph is called strongly connected if there is a path in each direction between each pair of vertices of the graph.
    http://en.wikipedia.org/wiki/Ternary_search
    
    10. Subgraph:
    A subgraph of a graph G is a graph whose vertex set is a subset of that of G, and whose adjacency relation is a subset of that of G restricted to this subset. 
    In the other direction, a supergraph of a graph G is a graph of which G is a subgraph.

    A subgraph 's' is a set of edges 'e' and vertices 'v' such that e ⊂ E and  v ⊂ V.

    Singleton Graph/ Empty Graph/ Complete Graph with one node.
    A Graph contains only one Node.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    11. Walk:
    A walk is an alternating sequence of vertices and edges, beginning and ending with a vertex, where each vertex is incident to both the edge that precedes it 
    and the edge that follows it in the sequence, and where the vertices that precede and follow an edge are the end vertices of that edge. 
    
    A Walk is CLOSED if its first and last vertices are the same, and open if they are different.

    12. Cliques:
    A clique in a graph is a set of pairwise adjacent vertices.

    The complete graph Kn of order n is a simple graph with n vertices in which every vertex is adjacent to every other. The example graph to the right is complete. 
    The complete graph on n vertices is often denoted by Kn. It has n(n-1)/2 edges (corresponding to all possible choices of pairs of vertices).
   
    13. Hypercubes:
    A hypercube graph Q_n is a regular graph with 2n vertices, 2n−1n edges, and n edges touching each vertex. 
    It can be obtained as the one-dimensional skeleton of the geometric hypercube.

    14. Knots:
    A knot in a directed graph is a collection of vertices and edges with the property that every vertex in the knot has outgoing edges, and all outgoing edges from vertices in the knot terminate at other vertices in the knot. 
     
    15. Bi Partite Graph:
    http://en.wikipedia.org/wiki/Bipartite_graph

    Tree:
    A (free) tree is an undirected graph T such that T is connected and T has no cycles.

    Forest:
    Undirected graph with no cycles and components of a forest are trees.


    Dense Graph :
    Sparse  Graph :
    http://en.potiori.com/Sparse_graph.html
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Adjancency:



    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Graph traversal:

    1. DFS: 
    Visits the Child nodes before visiting the Sibling nodes.
    I.e. it traverses the depth of any particular path before exploring its breadth.
    Uses Stacks.
    For traversing a finite graph. 

    Implementation Technique:
    White   : Vertex is unvisited.
    Gray    : Vertex is in progress.
    Black   : DFS has finished processing the vertex.
   
    2. BFS:

    BFS visits the Sibling nodes before visiting the Child nodes. 
    It's usually used to find the shortest path from a node to another.
    Uses Queues.
    For traversing a finite graph. 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Units of Space to Store:

    Each linked list node is 2 units of space unweighted and 3 units for weighted.
    Each array cell is 1 unit of space.
    On average ALL takes 3% space compare to AM.

    Graph:                      Adjancency Linked List          Adjancency Matrix
    
    1. Space:
    
    Directed    - No Weights        n + 2e                          n X n
    Directed    - Weights           n + 3e                          n X n
    Unidirected - No Weights        n + 4e                          n X n
    Unidirected - Weights           n + 6e                          n X n

    2. Time:

    DFS                             O(V + E)                        O(V X V)

                    Adjacency list      Incidence list      Adjacency matrix        Incidence matrix

    Space           O(|V|+|E|)          O(|V|+|E|)          O(|V|^{2})              O(|V| x |E|) 
    Add vertex      O(1)                O(1)                O(|V|^{2})              O(|V| x |E|) 
    Add edge        O(1)                O(1)                O(1)                    O(|V| x |E|) 
    Remove vertex   O(|E|)              O(|E|)              O(|V|^{2})              O(|V| x |E|) 
    Remove edge     O(|E|)              O(|E|)              O(1)                    O(|V| x |E|) 

    Query: are vertices u, v adjacent? (Assuming that the storage positions for u, v are known) O(|V|) O(|V|) O(1) O(|E|) 
    
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Unit Distance Graph:
    E.g.

    Any cycle graph
    Any grid graph
    Any hypercube graph
    Any star graph
    The Petersen graph
    The Heawood graph (Gerbracht 2009)
    The wheel graph W7
    The Moser spindle, the smallest 4-chromatic unit distance 

    There are other graphs like Star Graph, Wheel Graph

    References:
    http://www.ics.uci.edu/~eppstein/163/    

    http://en.wikipedia.org/wiki/Graph_(mathematics)
    http://en.wikipedia.org/wiki/Unit_distance_graph
    
    http://ww3.algorithmdesign.net/handouts/DFS.pdf
    http://www.signumframework.com/DataStructures-Graphs.ashx
    http://jamesmccaffrey.wordpress.com/2011/07/16/a-space-efficient-graph-data-structure-implementation-in-c/
    http://www.algolist.net/Algorithms/Graph/Undirected/Depth-first_search
    
    http://www.java2s.com/Code/Java/Collections-Data-Structure/Adirectedgraphdatastructure.htm
    http://www.algolist.net/Data_structures/Graph/Internal_representation

    http://www.sanfoundry.com/cpp-programming-examples-graph-problems-algorithms/
    http://www.sanfoundry.com/java-programming-examples-graph-problems-algorithms/

    http://www.sanfoundry.com/java-program-implement-adjacency-matrix/
    http://www.sanfoundry.com/java-program-describe-representation-graph-using-adjacency-matrix/
    http://www.sanfoundry.com/java-programming-examples-hard-graph-problems-algorithms/
    http://www.sanfoundry.com/java-programming-examples-combinatorial-problems-algorithms/
    http://www.sanfoundry.com/java-programming-examples-computational-geometry-problems-algorithms/

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ===================================================================================================================================================================================================
*/