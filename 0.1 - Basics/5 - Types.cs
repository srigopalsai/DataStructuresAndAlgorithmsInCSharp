using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================

    Value Types     : int, char, struct, Structs (Int16, Int32, Int64. UInt16,.. IntPtr, Double Char, etc)

    http://msdn.microsoft.com/en-us/library/s1ax56ch.aspx
    http://msdn.microsoft.com/en-us/library/system.char.aspx
    http://msdn.microsoft.com/en-us/library/aa691279(v=vs.71).aspx
    Basic Multilingual Plane http://en.wikipedia.org/wiki/Basic_Multilingual_Plane#Basic_Multilingual_Plane

    Long vs Double  :

    Double only stores the most significant figure and not all the digits that could be in the number. 
    E.g. if you have a double > max value of long it will not be storing any information for digits after the decimal point or any of the figure just to the left of the deciaml point.
    
    http://stackoverflow.com/questions/1582529/maximum-value-vs-size-of-long-and-double-in-net

    Precision is the main difference. 

    Float   - 7         digits              ( 32 bit)
    Double  - 15 - 16   digits              ( 64 bit)
    Decimal - 28 - 29   significant digits  (128 bit)

    1. Float and Double can     be divided by integer zero  Without an exception at both compilation and run time.
    2. Decimal          cannot  be divided by integer zero. Compilation will always fail if you do that.
    http://stackoverflow.com/questions/618535/what-is-the-difference-between-decimal-float-and-double-in-net?rq=1
    http://docs.oracle.com/cd/E19957-01/806-3568/ncg_goldberg.html

    Atomic :
    Reads and writes of the following data types are atomic: bool, char, byte, sbyte, short, ushort, uint, int, float, and reference types. In addition, reads and writes of enum types with an underlying type in the previous list are also atomic. Reads and writes of other types, including long, ulong, double, and decimal, as well as user-defined types, are not guaranteed to be atomic. Aside from the library functions designed for that purpose, there is no guarantee of atomic read-modify-write, such as in the case of increment or decrement.
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Reference Types : String, Array, Class, Interface, Deligate, Dnyamic, Object
    
    http://msdn.microsoft.com/en-us/library/490f96s2.aspx
        is about 2 to 3 times faster than 

        Value[] list = new Value[N];
        for (int i = 0; i < N; i++)
        {
            list[i] = new Value(i, true);
        }

        Where Value is a struct with two fields (id and is_valid).

    ===================================================================================================================================================================================================
    
    Boxing Un-Boxing        :
    http://msdn.microsoft.com/en-us/library/4d43ts61(v=vs.90).aspx
    
    Returning an array means that you have to make a fresh copy of the array every time you return it
    Why Arrays are Harmful some times http://blogs.msdn.com/b/ericlippert/archive/2008/09/22/arrays-considered-somewhat-harmful.aspx
    
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Structs vs Classes      :   http://stackoverflow.com/questions/3942721/structs-versus-classes?lq=1
    
        Value[] list = new Value[N];
        for (int i = 0; i < N; i++)
        {
            list[i].id = i;
            list[i].is_valid = true;
        }

    
    ===================================================================================================================================================================================================
    
    Ref Parameters  :
    
    ===================================================================================================================================================================================================
    
    Out Parameters  :
    
    ===================================================================================================================================================================================================
    
    Mutable         :   A mutable object, which CAN be Modified after it is created
    
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Immutable       :   An immutable object is an object whose state CANNOT be Modified after it is created.
                        In some cases, an object is considered immutable even if some internally used attributes change but the object's state appears to be unchanging from an external point of view. 
                        E.g. an object that uses memoization to cache the results of expensive computations could still be considered an immutable object

    1. Structs are Immutable.
    2. Immutable objects are often useful because they are inherently thread-safe
    3. Immutability is a compile-time construct that indicates what a programmer can do through the normal interface of the object, not necessarily what they can absolutely do.
       For instance, by circumventing the type system or violating const correctness in C or C++.

    Value types are not immutable by definition. Both structs and classes can be either mutable or immutable. 
    All four combinations are possible. 
    If a struct or class has non-readonly public fields, public properties with setters, or methods which set private fields, it is mutable because you can change its state without creating a new instance of that type.

    http://en.wikipedia.org/wiki/Immutable_object
    http://stackoverflow.com/questions/214714/mutable-vs-immutable-objects
    http://stackoverflow.com/questions/9183929/why-do-c-sharp-arrays-use-a-reference-type-for-enumeration-but-listt-uses-a-m

    Strings in .NET :

    http://stackoverflow.com/questions/2365272/why-net-string-is-immutable?rq=1
    http://stackoverflow.com/questions/93091/why-cant-strings-be-mutable-in-java-and-net
 
    ===================================================================================================================================================================================================

    Collections:
    
    Closely related data can be handled more efficiently when grouped together into a collection. 
    Instead of writing separate code to handle each individual object, you can use the same code to process all the elements of a collection.
    
    http://msdn.microsoft.com/en-us/library/7y3x785f(v=vs.110).aspx
    http://msdn.microsoft.com/en-us/library/gg145045(v=vs.110).aspx

    Commonly Used Collections :
    http://msdn.microsoft.com/en-us/library/0ytkdh4s(v=vs.110).aspx

    Thread Safe Collections :
    http://msdn.microsoft.com/en-us/library/dd997305(v=vs.110).aspx

    Specilized Collections :
    http://msdn.microsoft.com/en-us/library/7hyz15wf(v=vs.110).aspx
 
    Comparer : 
    http://msdn.microsoft.com/en-us/library/cfttsh47(v=vs.110).aspx
    
    ===================================================================================================================================================================================================

    Why Immutability?

    1. Snapshot semantics, allowing you to share your collections in a way that the receiver can count on never changing.
    2. Implicit thread-safety in multi-threaded applications (no locks required to access collections).
    3. Any time you have a class member that accepts or returns a collection type and you want to include read-only semantics in the contract.
    4. Functional programming friendly.
    5. Allow modification of a collection during enumeration, while ensuring original collection does not change.
    6. They implement the same IReadOnly* interfaces that your code already deals with so migration is easy.
    
    Immutable Collection : System.Collection.Immutable http://msdn.microsoft.com/en-us/library/dn385366(v=vs.110).aspx 

    Application Domains :
    http://msdn.microsoft.com/en-us/library/dah4cwez(v=vs.110).aspx
    http://msdn.microsoft.com/en-us/library/2bh4z9hs(v=vs.110).aspx

    ===================================================================================================================================================================================================

    Deep Copy Vs Shallow Copy :

    Deep Copy       :   System.Array.CopyTo()
    Shallow Copy    :   System.Array.Clone() 

    ===================================================================================================================================================================================================

    */
    partial class BinaryAndBitwiseOperations
    {
        //=============================================================================================================================================================================================

        public static void FloatWithModulus()
        {            
            float f = 9.9f, m = 3.3f;
            float c = f % m;
            Console.WriteLine(c);
        }

        //=============================================================================================================================================================================================

        // Read Only

        //=============================================================================================================================================================================================
    }
}