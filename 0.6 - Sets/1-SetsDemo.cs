using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://www.careercup.com/question?id=5746565784272896
    http://www.sanfoundry.com/java-program-bit-set/
    http://www.sanfoundry.com/java-program-bit-matrix/
    One may define the operations of the algebra of sets:
    union(S,T): returns the union of sets S and T.
    intersection(S,T): returns the intersection of sets S and T.
    difference(S,T): returns the difference of sets S and T.
    subset(S,T): a predicate that tests whether the set S is a subset of set T.

     Additional operations[edit]

    There are many other operations that can (in principle) be defined in terms of the above, such as:
    pop(S): returns an arbitrary element of S, deleting it from S.
    map(F,S): returns the set of distinct values resulting from applying function F to each element of S.
    filter(P,S): returns the subset containing all elements of S that satisfy a given predicate P.
    fold(A0,F,S): returns the value A|S| after applying Ai+1 := F(Ai, e) for each element e of S.
    clear(S): delete all elements of S.
    equal(S1, S2): checks whether the two given sets are equal (i.e. contain all and only the same elements).
    hash(S): returns a hash value for the static set S such that if equal(S1, S2) then hash(S1) = hash(S2)

    Other operations can be defined for sets with elements of a special type:
    sum(S): returns the sum of all elements of S for some definition of "sum". For example, over integers or reals, it may be defined as fold(0, add, S).
    nearest(S,x): returns the element of S that is closest in value to x (by some metric).
    min(S), max(S): returns the minimum/maximum element of S.
    Set Theory	"Set theory begins with a fundamental binary relation between an object o and a set A. 

If o is a member (or element) of A, write o ∈ A. 
Since sets are objects, the membership relation can relate sets as well."
	"Derived binary relation between two sets is the subset relation, also called set inclusion. 
If all the members of set A are also members of set B, then A is a subset of B, denoted A ⊆ B. For example, {1,2} is a subset of {1,2,3} , but {1,4} is not"
	"Set Theory is the branch of mathematical logic that studies sets, which are collections of objects. 
Although any type of object can be collected into a set, set theory is applied most often to objects that are relevant to mathematics.

A is a subset of (or is included in) B, denoted by A \subseteq B
B is a superset of (or includes) A, denoted by B \supseteq A."
	A is a subset of (or is included in) B, denoted by
	B is a superset of (or includes) A, denoted by

Union	                            A is also a proper (or strict) subset of B; this is written as
Intersection	                    B is a proper superset of A; this is written as
Set Difference Or Minus	            Sets A and B, denoted A ∪ B, is the set of all objects that are a member of A, or B, or both. 
                                    The union of {1, 2, 3} and {2, 3, 4} is the set {1, 2, 3, 4}.
Symmetric Difference	            Sets A and B, denoted A ∩ B, is the set of all objects that are members of both A and B. 
                                    The intersection of {1, 2, 3} and {2, 3, 4} is the set {2, 3}
Cartesian Product ( Union All)	    B and A, denoted B \ A, is the set of all members of B that are not members of A. 
                                    The set difference {1,2,3} \ {2,3,4} is {1}
Power Set	                        Sets A and B, denoted A △ B or A ⊖ B.
                                    Set of all objects that are a member of exactly one of A and B (elements which are in one of the sets, but not in both). 

E.g.  The sets {1,2,3} and {2,3,4} , the symmetric difference set is {1,4} . 
It is the set difference of the union and the intersection, (A ∪ B) \ (A ∩ B) or (A \ B) ∪ (B \ A)."

*/
    class _1_SetsDemo
    {
        public void SetDemo()
        {
            Tuple<int, string, string> SampleObj = new Tuple<int, string, string>(1, "Sai", "Sri");

            
        }
    }
}
