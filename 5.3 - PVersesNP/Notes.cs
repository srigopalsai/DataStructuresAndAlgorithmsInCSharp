using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._9._2___PVersesNP
{
    /*
    ~ SIM http://xlinux.nist.gov/dads//HTML/sim.html
    http://xlinux.nist.gov/dads//

     P versus NP Problem. 
        P - Polynomial.
        NP - Non Deterministic Polynomial Time: Decission problems (yes/no) can be verified by the Yes Answer easily.

        P-NP: Is the class of problmes solved by Polynomial time is identical to class of problems non-deterministic polynomial time.

        Assume we have A X B = 851 So we may need to find the value of A and B. 
        So it could be A = 850 , B = 1, Or A = 23, B = 37 and so on. 
        How about A X B = 174,661 takes longer longer time.
        
        Assume in navie approach trial division O(10^n/2) grows exponentially.
        We will be referring as astronomically big. The quantity can comparable with No of atoms in the universe.
        Given a product, find the smaller factors from it. This problem called as Factorization.
        https://www.youtube.com/watch?v=iMZHXTwxvYM
        One-way fuction means goes in one direction, may not be easy to go in other direction.
        
        In computer science, a nondeterministic algorithm is an algorithm that can exhibit different behaviors on different runs, as opposed to a deterministic algorithm
        An algorithm that solves a problem in nondeterministic polynomial time can run in polynomial time or exponential time depending on the choices it makes during execution


        In computer science, a deterministic algorithm is an algorithm which, given a particular input, will always produce the same output, with the underlying machine always passing through the same sequence of states. Deterministic algorithms are by far the most studied and familiar kind of algorithm, as well as one of the most practical, since they can be run on real machines efficiently.

        Formally, a deterministic algorithm computes a mathematical function; a function has a unique value for any given input, and the algorithm is a process that produces this particular value as output.
        http://en.wikipedia.org/wiki/Deterministic_algorithm
        http://en.wikipedia.org/wiki/Nondeterministic_algorithm
        http://en.wikipedia.org/wiki/P_vs_NP
        ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        The P versus NP problem is a major unsolved problem in computer science. Informally, it asks whether every problem whose solution can be quickly verified by a computer can also be quickly solved by a computer

        The informal term quickly used above means the existence of an algorithm for the task that runs in polynomial time. The general class of questions for which some algorithm can provide an answer in polynomial time is called "class P" or just "P". For some questions, there is no known way to find an answer quickly, but if one is provided with information showing what the answer is, it may be possible to verify the answer quickly. The class of questions for which an answer can be verified in polynomial time is called NP.

        Consider the subset sum problem, an example of a problem that is easy to verify, but whose answer may be difficult to compute. Given a set of integers, does some nonempty subset of them sum to 0? For instance, does a subset of the set {−2, −3, 15, 14, 7, −10} add up to 0? The answer "yes, because {−2, −3, −10, 15} adds up to zero" can be quickly verified with three additions. However, there is no known algorithm to find such a subset in polynomial time (there is one, however, in exponential time, which consists of 2n-1 tries), and indeed such an algorithm can only exist if P = NP; hence this problem is in NP (quickly checkable) but not necessarily in P (quickly solvable).

        An answer to the P = NP question would determine whether problems that can be verified in polynomial time, like the subset-sum problem, can also be solved in polynomial time. 
        If it turned out that P ≠ NP, it would mean that there are problems in NP (such as NP-complete problems) that are harder to compute than to verify: they could not be solved in polynomial time, but the answer could be verified in polynomial time

        P ≠ NP then there exist problems in NP that are neither in P nor NP-complete
        Generally verification of the problem is easier thacn solving the problem. E.g. is above factorization problem.
        ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Clique Problem: E.g. Facebook friends. Clique ( in a group each and every one know each other e.g. a team group )
        3 Clique - 3 people knows each other. 4 Clique - 4 people knows/connected each other
        https://www.youtube.com/watch?v=599k4n95cSo Find Clique k in a Graph.

        ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        NP- Complete: 
        1. Suduko.
        2. Traveling Salesman.
        3. Subset Sum.
        4.

        Proving P = NP 
        Come up with a polynomial time algorithm (correct on all inputs) to solve the NP problem. E.g mention above NP - Complete problems.
        Infact no need to solve, just show that there is an algorithm exists.
        https://www.youtube.com/watch?v=kFl9Z7GPZqg

        Proving P ≠ NP 
        It is hard to show that no strategy works. 
        ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        Elique: https://www.youtube.com/watch?v=CY_klh5uD-E
        ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        HARD Problem: A problem taken exponential time to say Yes or No i.e. verifying the problem. E.g Subset Problem with out sort.
*/
    class Notes
    {
    }
}
