using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
    Branch Predection   :
    http://www.quora.com/What-is-branch-prediction-in-the-context-of-CPUs
    ===================================================================================================================================================================================================
    
    Loop Un Rolling     :
    
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Loop Un Winding     :

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Loop Invariants     :   In Every Iteration 'A condition that must be true' at a certain point.
    
    Property of a loop which that holds before (and after) each repetition.    

    In contract programming, an invariant is a condition that must be true (by contract) before and after any public method is called.

    Invariants are used in proving correctness of programs, choosing an invariant depends on what you are trying to prove.
    
    http://stackoverflow.com/questions/3221577/what-is-a-loop-invariant
	http://www.cs.uofs.edu/~mccloske/courses/cmps144/invariants_lec.html	

	An invariant is a condition that can be relied upon to be true during execution of a program, or during some portion of it.	
	http://www.cs.miami.edu/~burt/learning/Math120.1/Notes/LoopInvar.html	

    1. Use your intuition about what the code does.
    2. Loop Invariants are incremental.
    3. In a list, invariants usually say something about the 'part of list that's been processed so far'.
    4. Invariants have no concept of time.
    5. Invariants are true even when loop condition is false.
    6. In proofs, use only invs, loop conditon, pre and math. Anything else should be part of an invariant.
    7. Will tell about the present condition, not past or not future.
    
    From
        Initialization          - Compound or Sequence ( instruction 1, instruction 2... instruction n)
    Invariant
        Invariant_Expression    - Boolean Expression
    Variant
        Variant_Expression      - Integer Expression
    Until
        Exit_Condition          - Boolean Expression
    Loop
        Body                    - Compound or Sequence( instruction 1, instruction 2... instruction n)
    End
    
    https://www.youtube.com/watch?v=t3gtm4KH2b8
    http://en.wikipedia.org/wiki/Invariant_(computer_science)
    http://en.wikipedia.org/wiki/Loop_invariant
    https://www.youtube.com/watch?v=AUs9mvIHoLg
    https://www.youtube.com/watch?v=t3gtm4KH2b8
    an invariant is a condition that can be relied upon to be true during execution of a program, or during some portion of it. 
    http://en.wikipedia.org/wiki/Loop-invariant_code_motion
    http://www.cs.miami.edu/~burt/learning/Math120.1/Notes/LoopInvar.html
    Paradox. 
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Loop Variant        :

    A loop variant is a mathematical function defined on the state space of a computer program whose value is monotonically decreased with respect to a (strict) well-founded relation by the iteration of a while loop under some invariant conditions, thereby ensuring its termination.
    Integer expression that must be 
        1. Non-negative when after initialization (from)
        2. Decrease (i.e by atleast one), while remaining non-negative, for every iteration of the body (loop)
        3. Executed with exit condtion not satisfied.

    http://en.wikipedia.org/wiki/State_(computer_science)


    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    for vs foreach      :   http://stackoverflow.com/questions/1124753/performance-difference-for-control-structures-for-and-foreach-in-c-sharp?lq=1
                            http://www.codeproject.com/Articles/146797/Fast-and-Less-Fast-Loops-in-C


    

    ===========================================================================================================================================================================================
    */
    partial class BinaryAndBitwiseOperations
    {
     
    }
}
