using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{

    /*
    ===================================================================================================================================================================================================

    http://www.sanfoundry.com/java-program-find-mst-using-prims-algorithm/
    http://en.wikipedia.org/wiki/Minimum_spanning_tree
    
    http://www.geeksforgeeks.org/greedy-algorithms-set-2-kruskals-minimum-spanning-tree-mst/
    http://weierstrass.is.tokushima-u.ac.jp/ikeda/suuri/dijkstra/Prim.shtml
    

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Spanning Tree:
        
    A spanning tree of a graph is just a subgraph that contains all the vertices and is a tree. 
    A graph may have many spanning trees; for instance the complete graph on four vertices     
    
    O---O
    |\ /|
    | X |
    |/ \|
    O---O

    has 16 Spanning Trees: 

    O---O    O---O    O   O    O---O
    |   |    |        |   |        |
    |   |    |        |   |        |
    |   |    |        |   |        |
    O   O    O---O    O---O    O---O

    O---O    O   O    O   O    O   O
     \ /     |\ /      \ /      \ /|
      X      | X        X        X |
     / \     |/ \      / \      / \|
    O   O    O   O    O---O    O   O

    O   O    O---O    O   O    O---O
    |\  |       /     |  /|     \
    | \ |      /      | / |      \
    |  \|     /       |/  |       \
    O   O    O---O    O   O    O---O

    O---O    O   O    O   O    O---O
    |\       |  /      \  |       /|
    | \      | /        \ |      / |
    |  \     |/          \|     /  |
    O   O    O---O    O---O    O   O

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Minimum spanning Trees :

    A minimum spanning tree (MST) of an edge-weighted graph is a spanning tree whose weight (the sum of the weights of its edges) is no larger than the weight of any other spanning tree. 

    Now suppose the edges of the graph have weights or lengths. 
    The weight of a tree is just the sum of weights of its edges. 
    Different trees have different lengths. 

    Minimum Spanning Tree:
    
    Is a subgraph that is a tree and connects all the vertices together. 
    A single graph can have many different spanning trees. 
    A minimum spanning tree (MST) or minimum weight spanning tree for a weighted, connected and undirected graph is a spanning tree with weight less than or equal to the weight of every other spanning tree. 
    The weight of a spanning tree is the sum of weights given to each edge of the spanning tree.

    Why Minimum Spanning Tree?

    While using graph based applications we may provide some weight for each edge. 
    The weight might be distance, time, cost etc. So we may need the shortest connection together to save distance, time or cost . 

    Problem: How to find the minimum length spanning tree? 

    1. A randomized algorithm can solve it in linear expected time. [Karger, Klein, and Tarjan]
    2. It can be solved in linear worst case time if the weights are small integers. 
    3. The best solution is very close to linear but not exactly linear. 
       The exact bound is O(m log beta(m,n)) where the beta function has a complicated definition: the smallest i such that log(log(log(...log(n)...))) is less than m/n, where the logs are nested i times. [Gabow, Galil, Spencer, and Tarjan]

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Algorthms: ( All are Greedy Algorithms)

    1. Kruskal's Algorithm  :   Also Known as Greedy Algorithm.
                                Easiest to understand and probably the best one for solving problems by hand.   
    
                                Sort the edges of G in increasing order by length
                                Keep a subgraph S of G, initially empty
                                
                                for each edge e in sorted order
                                    if the endpoints of e are disconnected in S
                                    add e to S
                                
                                return S

                                When ever we add an edge (u,v), it's always the smallest connecting the part of S reachable from u with the rest of G, so by the lemma it must be part of the MST. 
                                By using Greedy algorithm, it chooses at each step the cheapest edge to add to S. 
        
                                We should be very careful when trying to use greedy algorithms to solve other problems, since it usually doesn't work. 
                                E.g. if we want to find a shortest path from a to b, it might be a bad idea to keep taking the shortest edges.
    http://www.sanfoundry.com/java-program-find-mst-using-kruskals-algorithm/

              Time Analysis :   The line testing whether two endpoints are disconnected looks like it should be slow.
                                Linear time per iteration, or O( m n) total.
 
                                But actually there are some complicated data structures that let us perform each test in close to constant time; this is known as the union-find problem.                                 
                                Sorting step: O(m log n) time.
                                
                                Total time : O (m n) and Sorting : O (m log n)
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    2. Prim's Algorithm     :   Rather than build a subgraph one edge at a time, Prim's algorithm builds a tree one vertex at a time.
                             
                                let T be a single vertex x
                                while (T has fewer than n vertices)
                                {
                                    find the smallest edge connecting T to G-T
                                    add it to T
                                }

                                Again, it looks like the loop has a slow step in it. But again, some data structures can be used to speed this up. 
                                The idea is to use a heap to remember, for each vertex, the smallest edge connecting T with that vertex.
            Prim with heaps :
                                    make a heap of values (vertex,edge,weight(edge))
                                        initially (v,-,infinity) for each vertex
                                        let tree T be empty

                                    while (T has fewer than n vertices)
                                    {
                                        let (v,e,weight(e)) have the smallest weight in the heap
                                        remove (v,e,weight(e)) from the heap
                                        add v and e to T
                                        for each edge f=(u,v)
                                        if u is not already in T
                                            find value (u,g,weight(g)) in heap
                                            if weight(f) < weight(g)
                                            replace (u,g,weight(g)) with (u,f,weight(f))
                                    }

    http://www.sanfoundry.com/java-program-find-mst-using-prims-algorithm/
              Time Analysis :   We perform n steps in which we remove the smallest element in the heap, and at most 2m steps in which we examine an edge f=(u,v). 
                                For each of those steps, we might replace a value on the heap, reducing it's weight. 
                                (You also have to find the right value on the heap, but that can be done easily enough by keeping a pointer from the vertices to the corresponding values.) 
                                I haven't described how to reduce the weight of an element of a binary heap, but it's easy to do in O(log n) time. 
                                Alternately by using a more complicated data structure known as a Fibonacci heap, you can reduce the weight of an element in constant time. 

                                Total Time : O( m + n log n). 
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    3. Boruvka's Algorithm  :   Although this seems a little complicated to explain, it's probably the easiest one for computer implementation since it doesn't require any complicated data structures. 
                                The idea is to do steps like Prim's algorithm, in parallel all over the graph at the same time. Similar to Merge Sort.

                                make a list L of n trees, each a single vertex
                                while (L has more than one tree)
                                    for each T in L, find the smallest edge connecting T to G-T
                                    add all those edges to the MST
                                    (causing pairs of trees in L to merge)

                                As we saw in Prim's algorithm, each edge you add must be part of the MST, so it must be ok to add them all at once. 
              Time Analysis :   Each pass reduces the number of trees by a factor of two, so there are O(log n) passes. 
                                Each pass takes time O(m) (first figure out which tree each vertex is in, then for each edge test whether it connects two trees and is better than the ones seen before for the trees on either endpoint).
            
                                Total Time :  O(m log n).
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    4. A Hybrid Algorithm   :   The idea is to do O(log log n) passes of Boruvka's algorithm, then switch to Prim's algorithm. 
                                Prim's algorithm then builds one large tree by connecting it with the small trees in the list L built by Boruvka's algorithm, keeping a heap which stores, for each tree in L, 
                                                                                                                                                                                    the best edge that can be used to connect it to the large tree. 
                                Alternately, you can think of collapsing the trees found by Boruvka's algorithm into "supervertices" and running Prim's algorithm on the resulting smaller graph. 
                                The point is that this reduces the number of remove min operations in the heap used by Prim's algorithm, to equal the number of trees left in L after Boruvka's algorithm, which is O(n / log n). 

               Time Analysis :  O(m log log n) for the first part.
                                O(m + (n/log n) log n) = O(m + n) for the second.
                                
                                Total Time : O(m log (log n)) total.

    http://en.potiori.com/Dijkstra%27s_algorithm.html
    http://en.potiori.com/Blossom_(graph_theory).html
    http://www.ics.uci.edu/~eppstein/161/960206.html
    http://algs4.cs.princeton.edu/43mst/

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    For Directed Graphs:
    http://en.wikipedia.org/wiki/Arborescence_(graph_theory  Can be solved in quadratic time using the Chu–Liu/Edmonds algorithm.

    ===================================================================================================================================================================================================
    */
    class MinimumSpanningTree
    {
    }
}