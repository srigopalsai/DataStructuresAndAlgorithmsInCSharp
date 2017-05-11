/*
.NET Source Code            :   http://referencesource.microsoft.com/#mscorlib/system/threading/Tasks/Task.cs#045a746eb48cbaa9
Programming Paradigm        :   Is a fundamental style of computer programming. 
                                A way of building the structure and elements of computer programs.

Imperative Programming      :   Describes computation in terms of statements that change a program state
                                http://en.wikipedia.org/wiki/Imperative_programming


Declarative Programming     :   A style of building the structure and elements of computer programs, that expresses the logic of a computation without describing its control flow
                                Declarative programming is often defined as any style of programming that is not imperative
                                E.g DQL, SQL, Regular Expressions 
                                http://en.wikipedia.org/wiki/Declarative_programming


Functional Programming      :   A style of building the structure and elements of computer programs, that treats computation as the evaluation of mathematical functions and avoids state and mutable data
                                http://en.wikipedia.org/wiki/Functional_programming

Object Oriented Programming :

                                http://en.wikipedia.org/wiki/Object-oriented_programming

Logic Programming           :
                                http://en.wikipedia.org/wiki/Logic_programming
Symbolic Programming        :
                                http://en.wikipedia.org/wiki/Symbolic_programming

A Multi-Paradigm            :   Programming language is a programming language that supports more than one programming paradigm.

Comparision                 :   http://en.wikipedia.org/wiki/Comparison_of_programming_paradigms

Defencive Programming       :   http://en.wikipedia.org/wiki/Defensive_programming

How to Calculate Time Complexity of an Algorithm :

http://blogs.msdn.com/b/nmallick/archive/2010/03/30/how-to-calculate-time-complexity-for-a-given-algorithm.aspx
http://stackoverflow.com/questions/487258/plain-english-explanation-of-big-o/487278#487278
for (int r = 0; r < 10000; r++)
    for (int c = 0; c < 10000; c++)
        if (c % r == 0)
            Console.WriteLine("blah!");

This one is O(1), because for any input n, it will run 10000 * 10000 times.


=======================================================================================================================================================================================================


CPU:

A central processing unit (CPU) is the electronic circuitry within a computer that carries out the instructions of a computer program by performing the basic arithmetic, logical, control and input/output (I/O) operations specified by the instructions.

ALU :

In digital electronics, an arithmetic logic unit (ALU) is a digital circuit that performs arithmetic and bitwise logical operations on integer binary numbers. It is a fundamental building block of the central processing unit (CPU) found in many computers. 

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
FPU :

A floating-point unit (FPU, colloquially a math coprocessor) is a part of a computer system specially designed to carry out operations on floating point numbers. 
Typical operations are addition, subtraction, multiplication, division, square root, and bitshifting. 
Some systems (particularly older, microcode-based architectures) can also perform various transcendental functions such as exponential or trigonometric calculations, though in most modern processors these are done with software library routines.


===========================================================================================================================================================================================

Entire RAM has divided in numbers of equal parts, which are known as memory cells.


Each cell can store one-byte data. Data are stored in the 
binary number system. That is a character data reserves one 
memory cell while floating data reserves four memory cells.


Each memory cell has unique address. Address is always in
whole number and must be in increasing order.
===========================================================================================================================================================================================

http://www.cquestions.com/2011/02/memory-cell-in-computer.html

http://www.cquestions.com/2011/02/what-is-residence-memory-in-c.html
http://www.cquestions.com/2011/02/physical-address-of-computer.html

http://www.cquestions.com/2011/08/lcm-using-recursion-in-c.html

http://www.cquestions.com/2008/01/write-c-program-for-multiplication-of.html

http://www.cquestions.com/2008/01/write-c-program-to-find-perfect-number.html

===========================================================================================================================================================================================

Proving Program is Correct:

1. If test case is passed it doesn't mean program is correct. It may fail for diferent input other than input given in the passed test.


Program Variables   :

Output Variables    :


Domains
1. An Input Domain      :
2. A Program Domain     :
3. An Output Domain     :

For large programs this method may not work.

===========================================================================================================================================================================================
What is offset address?

Each segment has divided into 2 parts.
1. Segment no (4 bit)
2. Offset address (16 bit)

we can say memory address of any variable in c has two parts segment number and offset address.

===========================================================================================================================================================================================
Off Topic But worth Reading about Asking question in right manner http://sscce.org/

===========================================================================================================================================================================================
Sprint :
http://en.wikipedia.org/wiki/Sprint_(software_development)
http://stackoverflow.com/questions/1227318/what-is-the-difference-between-sprint-and-iteration-in-scrum-and-length-of-each
http://stackoverflow.com/questions/48386/sprint-velocity-calculations?rq=1
http://stackoverflow.com/questions/209011/what-is-the-difference-between-scrum-and-extreme-programming?rq=1
http://stackoverflow.com/questions/12222341/what-to-do-if-a-scrum-user-story-is-discovered-mid-sprint-to-be-more-complex-tha?rq=1
http://stackoverflow.com/questions/14858959/in-scrum-is-changing-acceptance-criteria-during-a-sprint-ok?rq=1


Extreme Programming focus on programming, TDD etc


Predators - Bug fixing
Spartans - Code refactoring
Pirates – Performance

Point Value 	Time Bucket

1/2 point	    6-13 hours
1 point 	    13-20 hours
2 points	    20-35 hours
3 points	    35-55 hours
5 points	    55-85 hours
8 points	    85-135 hours
13 points	    135-220 hours
20 points	    220-300 hours
40 points	    >300 hours

XXS 	0 to 3	    0.5
XS	    3 to 6	    1
S	    6 to 13	    2
M	    13-20	    3
L	    20-35	    5
XL	    35-55	    8
XXL 	55-85	    13
XXXL	85+	        20
===========================================================================================================================================================================================
C# Basics               : http://msdn.microsoft.com/en-us/library/hh147285(VS.88).aspx
C# Compilation Errors   : http://msdn.microsoft.com/en-us/library/4bwh6d2t.aspx

*/