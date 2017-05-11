using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/Set_(computer_science)
     * Union(S,T): returns the union of sets S and T.
     * Intersection(S,T): returns the intersection of sets S and T.
     * Difference(S,T): returns the difference of sets S and T.
     * SubSet(S,T): a predicate that tests whether the set S is a subset of set T.
 
    Static sets:
    * is_element_of(x,S): checks whether the value x is in the set S.
    * is_empty(S): checks whether the set S is empty.
    * size(S) or cardinality(S): returns the number of elements in S.
    * iterate(S): returns a function that returns one more value of S at each call, in some arbitrary order.
    * enumerate(S): returns a list containing the elements of S in some arbitrary order.
    * build(x1,x2,…,xn,): creates a set structure with values x1,x2,…,xn.
    * create_from(collection): creates a new set structure containing all the elements of the given collection or all the elements returned by the given iterator.

    Dynamic sets:
    * create(): creates a new, initially empty set structure. *create_with_capacity(n): creates a new set structure, initially empty but capable of holding up to n elements.
    * add(S,x): adds the element x to S, if it is not present already.
    * remove(S, x): removes the element x from S, if it is present.
    * capacity(S): returns the maximum number of values that S can hold.

    Additional operations:

    * pop(S): returns an arbitrary element of S, deleting it from S.
    * map(F,S): returns the set of distinct values resulting from applying function F to each element of S.
    * filter(P,S): returns the subset containing all elements of S that satisfy a given predicate P.
    * fold(A0,F,S): returns the value A|S| after applying Ai+1 := F(Ai, e) for each element e of S.
    * clear(S): delete all elements of S.
    * equal(S1, S2): checks whether the two given sets are equal (i.e. contain all and only the same elements).
    * hash(S): returns a hash value for the static set S such that if equal(S1, S2) then hash(S1) = hash(S2)

    Other operations can be defined for sets with elements of a special type:
     
    * sum(S): returns the sum of all elements of S for some definition of "sum". For example, over integers or reals, it may be defined as fold(0, add, S).
    * nearest(S,x): returns the element of S that is closest in value to x (by some metric).
    * min(S), max(S): returns the minimum/maximum element of S

    Some set structures may allow only some of these operations. The cost of each operation will depend on the implementation, and possibly also on the particular values stored in the set, and the order in which they are inserted.

     A multimap (sometimes also multihash) is a generalization of a map or associative array abstract data type in which more than one value may be associated with and returned for a given key.
     */
    partial class SetOperations
    {
    }
}
