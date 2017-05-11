/*
http://www.cs.duke.edu/~ola/patterns/plopd/invariant.html
http://www.sanfoundry.com/c-programming-examples-recursion/
http://www.cs.uofs.edu/~mccloske/courses/cmps144/invariants_lec.html
http://stackoverflow.com/questions/3221577/what-is-a-loop-invariant
Recursion:

Defining something in terms of itself.
Recursive functions call themselves.

• Embedded calls are intended to solve smaller versions of the problem.
• Sequence of recursive calls ends when the base case is reached.
• If the base case is never reached, we  have infinite recursion - Bad Logic or program.

http://en.wikipedia.org/wiki/Recursion_(computer_science)


Recursion is the programming equivalent of Mathemetical Induction.
MI is a way of defining something in terms of it self.

When to Use:
When ever back tracking is required.
Can be carried out 'in place' in an array (note recursion uses call stack.

Recursive Data Type:
E.g Lists, Trees.

http://en.wikipedia.org/wiki/Recursive_data_type


Higher-Order Function : (Also functional form, functional or functor) is a function that does at least one of the following:
1. Takes one or more functions as an input
2. Outputs a function
http://en.wikipedia.org/wiki/Higher-order_function

Recursion with BackTracking
http://en.wikipedia.org/wiki/Backtracking

https://www.cs.uaf.edu/2009/spring/cs311/slides/cs311_20090218_backtrack.pdf

MSDN Reg EX http://msdn.microsoft.com/en-us/library/dsy130b4(v=vs.110).aspx

https://www.youtube.com/watch?v=3YP6NP1_tF0
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Types:

1. Tail Recursion.
2. Augumenting Recursion
3. Co Recursion
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Tail Recursion:
        
    Tail-recursive functions are functions in which all recursive calls are tail calls and hence do not build up any deferred operations.
        
    Doesn't Maintains Call Stack.
         
    With a compiler or interpreter that treats tail-recursive calls as jumps rather than function calls, a tail-recursive function such as below TailRecursionCalcGCD will execute using constant space.
        
    Thus the program is essentially iterative, equivalent to using imperative language control structures like the "for" and "while" loops.
        
    INPUT: Integers x, y such that x >= y and y > 0

================================================================================================================================================================================================================================
Time Complexity Calcuation:

Mathematics:

Recurrence Relations
4 Types
1 Linear

R = { Problems solvable in finite time }
R - Recursive Time.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Several methods for deducing a closed form formula from a recurrence.

1. Arithmatic
2. Geometric
3. Polynomial
4. Linear
5. Generating Functions

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Can be more difficult to solve than for standard algorithms because we need to know complexity for the sub-recursions of decreasing size. 

A recurrence relation is an equation that defines each term of a sequence as a function of the previous term.
Recurrence relations are often used when computing the time complexities for recursive algorithms.
Recurrence relation is a function t(n) defined in terms of previous values of n.

It may also be known as a recursive equation, and even a simple one can exhibit complex behavior. 

The study of recurrence relations is known as nonlinear analysis.
A recurrence relation may be solved by placing it in a non-recursive form. 

Read more: http://www.ehow.com/how_5257039_solve-recurrence-relations.html#ixzz32N0QqZOw

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

A Recurrence relation uses 2 formulae to express the amount of work done. 
    1. Formula is for the base case.
    2. Other is for the general case.

E.g.  ( When performing n to 1 or 0 operations)
In the Base Case occurs when n = 0, and number of getOne() operations is '0'.
In the General Case, there are n operations, plus the number of operations needed to sort the bags smaller and bigger via two recursive calls


For Factorial problem. n X (n -1) (n -2)  ...

t(n) = c + t(n- 1) . Every time there is a constant unit time step involved i.e n X ...
Note: since we do not know the no of instructions involved in c, we will consider as a Unit. A unit is a no of instructions.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

1. The Substitution Method:

For Factorial problem. n X (n -1) (n -2) 

t(n) = c + t(n- 1) . Every time there is a constant unit time step involved i.e n X ...
Note: Since we do not know the no of instructions involved in c, we will consider as a Unit. A unit is a no of instructions.

t(n) = c + t (n - 1)
t(n) = c + c + t (n - 2)
t(n) = c + c + c + t (n - 3)
.
.
.    = nc + t(n-n)      At the end we will have n constant operations + t (0) operations i.e. t ( n - n ) = t(0)
     = nc + t(0)        Base case constant time.
     = nc + c0          Read as C not. its not C X zero.

Factorial is O(n)

http://www.cs.ucf.edu/~dmarino/ucf/cop3502/lec_biswas/recursion12.pdf

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

2. Recurrence Reference/ The Recursion Tree:




For more complex problems we will not be able to find the closed form by simple examination and we will thus need our solution techniques for recurrence relations 
Note that we can get basic complexity without having yet

https://www.youtube.com/watch?v=oZ0MP5euLQ0

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

3. Master Theorem:



https://www.youtube.com/watch?v=qCDZm7wGDxY

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

If coefficients do not depend on time (n) they are constant coefficients 
–  When linear these are also called LTI (Linear time invariant) 
If the forcing term/function is 0 the equation is homogenous 

Fundamental Theorem of Algebra:

For every polynomial of degree n, there are exactly n roots.
Roots may not be unique.

Many divide and conquer recurrence relations are of the  form t(n) = a·t(n/b) + g(n) 

–  These are not recurrence relations like we have been solving because they are not of finite order 
–  Not just dependent on a predictable set of t(n-1) ... t(n-k), but the arbitrarily large difference t(n/b) with a variable degree logbn 
–  We can often use a change of variables to translate these into the finite order form which we know how to deal with 

To Recap math:   4x - 7 = 5

Constants : 7,5         A number on its own is called a Constant.
Coefficient :  4        A Coefficient is a number used to multiply a variable (4x means 4 times x, so 4 is a coefficient)
Variable : x            A Variable is a symbol for a number we don't know yet. It is usually a letter like x or y.
Operator : '-'          An Operator is a symbol (such as +, ×, etc) that represents an operation (ie you want to do something with the values).
Expression : 4x - 7     An Expression is a group of terms (the terms are separated by + or - signs)
Terms : 4x, 7, 5        A Term is either a single number or a variable, or numbers and variables multiplied together.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Change of Variables:

Change of variables can be used in other contexts to transform a recurrence 
Not time invariant since after dividing by n the second 
coefficient is (n-1)/n 
Can do a change of variables and replace nT(n) with tn. it is not t X n it is t prefix n

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Induction:

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/
using System.Collections;
namespace DataStructuresAndAlgorithms
{
    partial class RecursionSamples
    {
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        string displayMessage = string.Empty;


        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}