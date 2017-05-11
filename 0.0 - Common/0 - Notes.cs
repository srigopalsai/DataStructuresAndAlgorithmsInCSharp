/*
    ============================================================================================================================================================================================================================

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Theoretical Computer Science :

    1.  Algorithms
    2.  Data Structures
    3.  Very-large-scale Integration
    4.  Machine Learning
    5.  Cryptography
    6.  Program Semantics
    7.  Formal Methods

    Computation:

    8.  Distributed Computation
    9.  Parallel Computation            http://ocw.mit.edu/courses/mathematics/18-337j-parallel-computing-fall-2011/
    10. Quantum Computation
    11. Symbolic Computation
    12. Computational Biology
    13. Computational Geometry

    Theory:

    14. Computational Number Theory
    15. Computational Complexity Theory (P = NP)
    16. Computational Learning Theory
    17. Information Theory
    18. Automata Theory
    19. Coding Theory


    char ch = '4'; int no = ch - '2'; int ascval = (int)ch;  bool rstl = ch-'0' < 6;
    
    ============================================================================================================================================================================================================================

    Algorithm           : Is the specification of a process to be carried out by a computer.    

    Properties of Algorithm :

    1. Defines data to which process will be applied.
    2. Every elementary step taken from a set of well specified action.
    3. Describes ordering(s) of execution of these steps.
    4. Properties 2 and 3 based on precisely defined conventions, suitable for an automatic device.
    5. For any data, guaranteed to terminate after finite number of steps.

    Algrothm vs Program :

    Algorithm usually considerd a more abstract notion, independent of platform, programming logic.

    Program becomes more abastract.


    Types of Algorithms :

    1. Brute Force.
    2. Simple Recursive
    3. Back Tracking
    4. Divide and Conquor
    5. Greedy Algorithms
    6. Dynamic Programming
    7. Branch and Bound.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Time and Space Complexity :

    Upper Bound ( Worst Case )           Big O (Big Omicron)        UW Omicron or UW Big O
    Lower Bound ( Best Case )            Big Ω Big Omega            LB Omega
    Lower + Upper Bound ( Average Case ) Big 0 (Big Theta)          LUAT

    Analysis :

    Amortized Analysis :

    Amortized analysis is not the same as an "average performance" - amortized analysis gives a hard guarantee on what the performance will do if you do so much actions.

    Is a method of analyzing algorithms that considers the entire sequence of operations of the program. 
    It allows for the establishment of a worst-case bound for the performance of an algorithm irrespective of the inputs by looking at all of the operations

    Dynamic arrays has a good example of amortized analysis.
    Appending to dynamic array takes O(n) time in the worst case, but when performing many appends in sequence, the average (amortized) cost of each append becomes O(1).

    http://stackoverflow.com/questions/14002391/amortized-analysis-of-algorithms
    http://tutorialslaxman.blogspot.com/2011/03/amortized-analysis-in-daa.html
    http://stackoverflow.com/questions/11102585/what-is-amortized-analysis-of-algorithms?rq=1
    Asymptotically optimal

    If, roughly speaking, for large inputs it performs at worst a constant factor (independent of the input size) worse than the best possible algorithm						
    As a simple example, it's known that all comparison sorts require at least Ω(n log n) comparisons in the average and worst cases. Mergesort and heapsort are comparison sorts which perform O(n log n) comparisons,	
					
    Asymptotic computational complexity ( Big O)						
    "Is the usage of the asymptotic analysis for the estimation of computational complexity of algorithms and computational problems, commonly associated with the usage of the big O notation.

    Using big-O notation is not very accurate. 
    The big-Omega notation is the lower limit. 
    The big-theta notation is the combination of both. So this would be a theta(n)."						
    Parallel computing is a form of computation in which many calculations are carried out simultaneously,[1] operating on the principle that large problems can often be divided into smaller ones, which are then solved concurrently ("in parallel"). 
    There are several different forms of parallel computing: bit-level, instruction level, data, and task parallelism						

    Asymptotic Analysis	:					
    In mathemetical analysis, Asymptotic Analysis is method of describing limited behavior						
    Amortized Analysis						
    "Amortized Time - Considers the entire sequence of operations of the program.
    Written as O(n)+ for O(n) or O(log n)+ for O(log n), or add 'plus' to respective time notation.
    ""amortized"" or ""average case"": 
    This is no more than using big-O notation for the expected value of a function, rather than the function itself. 

    E.g, Some data structures may have a worse-case complexity of O(N) for a single operation, but guarantee that if you do many of these operations, the average-case complexity will be O(1).
    Initially emerged from a method called aggregate analysis, which is now subsumed by amortized analysis.

    3 methods for performing amortized analysis:

    1. Aggregate analysis: determines the upper bound T(n) on the total cost of a sequence of n operations, then calculates the amortized cost to be T(n) / n.
    2. The accounting method: determines the individual cost of each operation, combining its immediate execution time and its influence on the running time of future operations. 
    Usually, many short-running operations accumulate a ""debt"" of unfavorable state in small increments, while rare long-running operations decrease it drastically.
    3. The potential method: is like the accounting method, but overcharges operations early to compensate for undercharges later.

    http://www.cs.cornell.edu/courses/cs3110/2011sp/lectures/lec20-amortized/amortized.htm 
    http://stackoverflow.com/questions/200384/constant-amortized-time
    http://stackoverflow.com/questions/11102585/what-is-amortized-analysis-of-algorithms



    Regular asymptotic analysis looks at the performance of an individual operation asymptotically, as a function of the size of the problem. The O() notation is what indicates an asymptotic analysis.

    Amortized analysis (which is also an asymptotic analysis) looks at the total performance of multiple operations on a shared datastructure.

    The difference is, amortized analysis typically proves that the total computation required for M operations has a better performance guarantee than M times the worst case for the individual operation.
       http://stackoverflow.com/questions/11102585/what-is-amortized-analysis-of-algorithms?rq=1

    Amortized analysis: Sometimes, an algorithm (usually an operation on a data structure) needs a long time to run, but changes the data structure such that subsequent operations are not costly. 
    A worst case run time analysis would be inappropriate. An amortized analysis averages over a series of operations (not over the input).
    Competitiveness analysis: For online algorithms we need a new concept of run time analysis. 
    The main concept is to compare the run time an algorithm needs in the worst case (i.e. forall possible inputs) not knowing the input, with the runtime of an optimal offline algorithm (which knows the input).

   ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

   ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

   Deterministic vs. Randomized :

   Deterministic algorithms produce on a given input the same results following the same computation steps. 
   Randomized algorithms throw coins during execution. 
   Hence either the order of execution or the result of the algorithm might be different for each run on the same input.

   ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   //Optimization Goals :

   //1. Exact 
   //2. Approximate: 
   //Traveling Saleman Problem with triangle inequality for n cities. 
   //This is an NP-hard problem (no polynomial-time algorithm is known).
   // The following greedy, deterministic algorithm yields a 2􀀀approximation for the TSP with triangle inequality in
   // time O(n2).
   // 1. Compute a minimum spanning tree T for the complete graph implied by the n cities.
   // 2. Duplicate all edges of T yielding a Eulerian graph T0 and then find an Eulerian path in T0.
   // 3. Convert the Eulerian cycle into a Hamiltonian cycle by taking shortcuts.

   //3. Heuristic 
   //4. Operational
   ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

   ============================================================================================================================================================================================================================
   */