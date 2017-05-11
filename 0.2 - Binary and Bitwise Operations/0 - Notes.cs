/*
1 – Set 
0 – Clear

Most Significant Bit --- Least Significant Bit

Bit Field        :  A bit field is a term used in computer programming to store multiple, logical, neighboring bits, where each of the sets of bits, and single bits can be addressed. 
Bit Manipulation :  Is the act of algorithmically manipulating bits or other pieces of data shorter than a word

Carry Flag       :  Usually indicated as the C flag, is a single bit in a system status (flag) register used to indicate when an arithmetic carry or borrow has been generated out of the most significant ALU bit position. 
                    The carry flag enables numbers larger than a single ALU width to be added/subtracted by carrying (adding) a binary digit from a partial addition/subtraction to the least significant bit position of a more significant word. 
                    It is also used to extend bit shifts and rotates in a similar manner on many processors (sometimes done via a dedicated X flag). 

Borrow Flag      :

Half Carry Flag  : http://en.wikipedia.org/wiki/Half-carry_flag

Flag Field       :  Is an integer interpreted as a sequence of boolean bits, each called a "flag".

Taking the example of a 6502 processor's status register, the following information was held within 8 bits:

Bit 7. Negative flag
Bit 6. Overflow flag
Bit 5. Unused
Bit 4. Break flag
Bit 3. Decimal flag
Bit 2. Interrupt-disable flag
Bit 1. Carry flag
Bit 0. Zero flag

Instruction set  :  An instruction set, or instruction set architecture (ISA), is the part of the computer architecture related to programming, 
                    including the native data types, instructions, registers, addressing modes, memory architecture, interrupt and exception handling, and external I/O. 
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Bit Shifts       :  Are sometimes considered bitwise operations, because they treat a value as a series of bits rather than as a numerical quantity. In these operations the digits are moved, or shifted, to the left or right

Arithmetic shift :  The bits that are shifted out of either end are discarded. 
                    In a  left arithmetic shift, zeros are shifted in on the right.
                    In a right arithmetic shift, the sign bit (the MSB in two's complement) is shifted in on the left, thus preserving the sign of the operand.

This example uses an 8-bit register:

       00010111 (decimal +23)  LEFT-SHIFT
    =  00101110 (decimal +46)                   The leftmost digit was shifted past the end of the register, and a new 0 was shifted into the rightmost position. 

       10010111 (decimal −105) RIGHT-SHIFT
    =  11001011 (decimal −53)                   The rightmost 1 was shifted out (perhaps into the carry flag), and a new 1 was copied into the leftmost position, preserving the sign of the number. 

Multiple shifts are sometimes shortened to a single shift by some number of digits. 

E.g.    00010111 (decimal +23) LEFT-SHIFT-BY-TWO
     =  01011100 (decimal +92)


A left arithmetic shift by n is equivalent to multiplying by 2n (provided the value does not overflow), while a right arithmetic shift by n of a two's complement value is equivalent to dividing by 2n and rounding toward negative infinity. 
If the binary number is treated as ones' complement, then the same right-shift operation results in division by 2n and rounding toward zero.

Logical Shift   :   Zeros are shifted-in to replace the discarded bits. Therefore the logical and arithmetic left-shifts are exactly the same.

However, as the logical right-shift inserts value 0 bits into the most significant bit, instead of copying the sign bit, it is ideal for unsigned binary numbers.
   while the arithmetic right-shift is ideal for signed two's complement binary numbers.


Rotate No Carry :   Another form of shift is the circular shift or bit rotation. 
                    In this operation, the bits are "rotated" as if the left and right ends of the register were joined. 
                    The value that is shifted in on the right during a left-shift is whatever value was shifted out on the left, and vice versa. 
                    This operation is useful if it is necessary to retain all the existing bits, and is frequently used in digital cryptography.

Rotate through Carry :  Is similar to the rotate no carry operation, but the two ends of the register are separated by the carry flag. 
                        The bit that is shifted in (on either end) is the old value of the carry flag, and the bit that is shifted out (on the other end) becomes the new value of the carry flag.
    
                    A single rotate through carry can simulate a logical or arithmetic shift of one position by setting up the carry flag beforehand. 

                    E.g. if the carry flag contains 0,                      then x RIGHT-ROTATE-THROUGH-CARRY-BY-ONE is a logical right-shift, 
                     and if the carry flag contains a copy of the sign bit, then x RIGHT-ROTATE-THROUGH-CARRY-BY-ONE is an arithmetic right-shift. 

                    For this reason, some microcontrollers such as low end PICs just have rotate and rotate through carry, and don't bother with arithmetic or logical shift instructions.

                    Rotate through carry is especially useful when performing shifts on numbers larger than the processor's native word size.
                    Because if a large number is stored in two registers, the bit that is shifted off the end of the first register must come in at the other end of the second. 
                    With rotate-through-carry, that bit is "saved" in the carry flag during the first shift, ready to shift in during the second shift without any extra preparation.


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


Bit Banning      : Is a technique for serial communications using software instead of dedicated hardware. 
                   Software directly sets and samples the state of pins on the microcontroller, and is responsible for all parameters of the signal: timing, levels, synchronization, etc
                   http://en.wikipedia.org/wiki/Bit_banging

BIT Predicate or Ackermann Coding : Sometimes written BIT(i, j), is a predicate which tests whether the jth bit of the number i is 1, when i is written in binary.

Masking :

A mask is data that is used for bitwise operations, particularly in a bit field.
Using a mask, multiple bits in a Byte, nibble, word (etc.) can be set either on, off or inverted from on to off (or vice versa) in a single bitwise operation.

For example, given a bit pattern 0011 (decimal 3), to determine whether the second bit is Set (1), we use a bitwise AND with a bit pattern containing 1 only in the second bit:

    0011 (decimal 3)
AND 0010 (decimal 2)
  = 0010 (decimal 2)

Because the result 0010 is non-zero, we know the second bit in the original pattern was set. This is often called bit masking


E.g. n is the index of the bit to be manipulated within the variable bit_fld, which is an unsigned char being used as a bit field. Bit indexing begins at 0, not 1. Bit 0 is the least significant bit.

1. Set a bit    :  bit_fld |=  (1 << n)
2. Clear a bit  :  bit_fld &= ~(1 << n)
3. Toggle a bit :  bit_fld ^=  (1 << n)
4. Test a bit   :  bit_fld &   (1 << n)

================================================================================================================================================================================================================================

Commutative     :   Is a binary operation is commutative if changing the order of the operands does not change the result. It is a fundamental property of many binary operations, and many mathematical proofs depend on.
                    E.g. (1,2(3,4,5)) = (1,2,3,)4,5) = (1,2,3,4,5)


Associativity   :

The associative property is closely related to the commutative property. 
he associative property of an expression containing two or more occurrences of the same operator states that the order operations are performed in does not affect the final result, as long as the order of terms doesn't change. 
In contrast, the commutative property states that the order of the terms does not affect the final result.

Most commutative operations encountered in practice are also associative. However, commutativity does not imply associativity

rearranging the parentheses in such an expression will not change its value. Consider the following equations:
( 2 + 3 ) + 4 = 2 + ( 3 + 4 ) = 9
( 2 X 3 ) X 4 = 2 X ( 3 X 4 ) = 24
Even though the parentheses were rearranged, the values of the expressions were not altered. Since this holds true when performing addition and multiplication on any real numbers, it can be said that "addition and multiplication of real numbers are associative operations."

Associativity is not to be confused with commutativity, which addresses whether a × b = b × a.


Symmentry       :

Some forms of symmetry can be directly linked to commutativity. When a commutative operator is written as a binary function then the resulting function is symmetric across the line y = x. 
As an example, if we let a function f represent addition (a commutative operation) so that f(x,y) = x + y then f is a symmetric function, which can be seen in the image on the right.

For relations, a symmetric relation is analogous to a commutative operation, in that if a relation R is symmetric, then a R b <==> b R a.

================================================================================================================================================================================================================================



Programming tasks that require bit manipulation include low-level device control, error detection and correction algorithms, data compression, encryption algorithms, and optimization. 
For most other tasks, modern programming languages allow the programmer to work directly with abstractions instead of bits that represent those abstractions. 
Source code that does bit manipulation makes use of the bitwise operations: AND, OR, XOR, NOT, and bit shifts.

When signed integers are shifted right, the value of the far left bit is copied to the other bits. 
The far left bit is '1' when the value is negative otherwise it is '0'. 
All 1 bits gives -1. Unfortunately, this behavior is architecture-specific. 


More Samples :  https://graphics.stanford.edu/~seander/bithacks.html
                http://help.topcoder.com/data-science/competing-in-algorithm-challenges/algorithm-tutorials/a-bit-of-fun-fun-with-bits/
                http://www.quora.com/How-do-I-understand-bitwise-tricks-in-C++-for-competitive-programming
                http://blog.typps.com/2007/10/bitwise-operators-in-c-or-xor-and-not.html
Bit Matrix      http://www.sanfoundry.com/java-program-bit-matrix/ 
Bit Sets        http://www.sanfoundry.com/java-program-bit-set/
Turn Off Bits   http://www.geeksforgeeks.org/how-to-turn-off-a-particular-bit-in-a-number/
                http://www.dsalgo.com/2013/03/swap-without-temp.html
                http://www.geeksforgeeks.org/swap-two-numbers-without-using-temporary-variable/



WORD  (16 bits/2 bytes)     Is a term for the natural unit of data used by a particular processor design. 
                            A word is basically a fixed-sized group of digits (binary or decimal) that are handled as a unit by the instruction set or the hardware of the processor.

DWORD (32 bits/4 bytes) - Double 
QWORD (64 bits/8 bytes) - Quad

================================================================================================================================================================================================================================
XOR :

⊕ - XOR Symbol
X ⊕ X = 0
X ⊕ 0 = X
X ⊕ Y = Y ⊕ X
( X ⊕ Y ) ⊕ Z = X ⊕ ( Y ⊕ Z )


XOR Linked List : http://en.wikipedia.org/wiki/XOR_linked_list

Drawbacks :

1. General-purpose debugging tools cannot follow the XOR chain, making debugging more difficult; [1]
2. The price for the decrease in memory usage is an increase in code complexity, making maintenance more expensive;
3. Most garbage collection schemes do not work with data structures that do not contain literal pointers;
4. XOR of pointers is not defined in some contexts (e.g., the C language), although many languages provide some kind of type conversion between pointers and integers;
5. The pointers will be unreadable if one isn't traversing the list — for example, if the pointer to a list item was contained in another data structure;
6. While traversing the list you need to remember the address of the previously accessed node in order to calculate the next node's address.
7. XOR linked lists do not provide some of the important advantages of doubly-linked lists. 
   Such as the ability to delete a node from the list knowing only its address or the ability to insert a new node before or after an existing node when knowing only the address of the existing node.


================================================================================================================================================================================================================================

Decimal/Denary Representation:

1. Digits are in the range of 0 to 9
2. Digits are multiplies of powers of 10
E.g. 237    2 X 10^2  +  3 X 10^1  +  7 X 10^0
            200 + 30 +  7
    
Binary Representation:
1. Digits are 0 or 1.
2. Digits are multiples of powers of 2

E.g 237
    
2^0     + 2^2 + 2^3       + 2^5 + 2^6 + 2^7  
1 +        4 + 8          + 32 + 64 + 128 
    
2^31 	=	2147483647
   
============================================================================================================================================================================================================================

Arithmatic Operations on Binary Numbers :

        8421
+
            111 - 7
        1000 - 8
------------
        1111 - 15

-
        1001
        1100
------------
        -100
    
============================================================================================================================================================================================================================

Representing Negative numbers in Binary :

In mathematics, negative numbers in any base are represented by prefixing them with a minus ("−") sign. 
But in computer hardware, numbers are represented only as sequences of bits, without extra symbols. 
    
1. Sign-and-magnitude
2. Ones' complement     Inverting all bits. http://en.wikipedia.org/wiki/Ones%27_complement
                        Use the leftmost bit as the sign bit. 
3. Two's complement     Inverting all bits and adding 1 and any carry bit at the end is discarded. http://en.wikipedia.org/wiki/Two%27s_complement
4. Excess-K. 


http://en.wikipedia.org/wiki/Signed_number_representations

1. Sign and Magnitude :

    Advantages      : Easy.
    Disadvantages   : With 8 bits we can only represent 127 (or -127) instead of 255
                        Difficult/impossible to do arithmetic with sign and magnitude representation.
                        How do we add a negative 5(1101) in Sign Mangnitude to anything represented in standard binary?

1. Where the first bit (MSB - Most significant Bit) in a binary number represents eigther a + or a -
0 represents +
1 represents -


In 16 Bits :

+/- |    8192     4096     2048    1024    512     256     128       64      32  16  8   4   2   1   =  16383
1   |    1         1         0       1       0       1       0       1       1   0   1   0   1   0   = 
0   |    1         1         0       1       0       1       0       1       1   0   1   0   1   0   = 

In 8 Bits :
+/- 64  32  16  8   4   2   1
1   1   1   0   1   0   1   0   = -106
0   1   1   0   1   0   1   0   = +106


In 4 Bits :
+/- 8   4   2   1
1   1   0   1   0   = -10
0   1   0   1   0   = +10

11010 - Sign and Magnitude         Representation = -10
11010   Standard/Non-Signed Binary Representation =  26

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

3. 2's Complement (Singed Binary):

First bit(MSB) does not represent a + or a -
Instead MSB is the negative form of what it would be with standard binary representation

-128     +64     +32 +16 +8  +4  +2  +1   =  
    1       0       0   0   1   0   1   1   = -117
    1       1       0   1   0   1   0   0   = -44

    Write Binary Number for -53

    First find Standard Binary for 53.
    0       0       1   1   0   1   0   1   = -53

    Now find the 1's Complement for 53.
    1       1       0   0   1   0   1   0   = -53

    Add 1 to the 1's Complement of 53.
    1       1       0   0   1   0   1   0
                                        1
-------------------------------------------------
    1       1       0   0   1   0   1   1
-128    +64              +8      +2  +1   = -53

    0       0       1   1   0   1   0   1    = -53
     
93-51 = 93 + -51

    93 = 01011101
-51 = 11001101
    
    01011101+
    11001101
---------
100101010 (Ignore the Carry)
    00101010 = 42   

>>  - Signed.
>>> - Un Signed.

============================================================================================================================================================================================================================
    
Binary represantation of 38, find the slots below which sum is 38 and keep 1 and make other slots 0 

2^9     2^8     2^7     2^6     2^5     2^4     2^3     2^2     2^1     2^0
512     256     128     64      32      16      8       4       2       1
                                1       0       0       1       1       0    
And 38's binary representation is 1 0 0 1 1 0 

1110 1101

===========================================================================================================================================================================================

unsigned char       :  8 bits (0 to 255)
unsigned short      :  16 bits
unsigned int        :  32 bits (Each one is multiples of power of 2)
unsigned long long  :  64 bits

===========================================================================================================================================================================================
    
Big-Endian and Little-Endian:

The terms that describe the order in which a sequence of bytes are stored in computer memory. 
    
Big-endian systems      : Store the most significant byte of a word in the smallest address and the least significant byte is stored in the largest address - Most Smallest and Least Largest
                            Or Is an order in which the "big end"    ( most significant value in the sequence) is stored first (at the lowest storage address). 
 
Little-endian systems   : Store the least significant byte in the smallest address. - Least Smallest and Most Largest
                            Or Is an order in which the "little end" (least significant value in the sequence) is stored first. 

===========================================================================================================================================================================================

Shift Operations:

<< left shift
>> right shift

E.g. 38 << 1     Output: Double in size 76 (Multiply by 2)
E.g. 38 >> 1     Output: Half in size 19   (Devide by 2)

40 << 1   	40 X 2^1    =  80
40 << 2   	40 X 2^2    =  160
40 << 3   	40 X 2^3    =  320
-40 << 3   	40 X 2^3    = -320 ( Imp to note )
40 << 4   	40 X 2^4    =  640
40 << 5   	40 X 2^5    =  1280
40 << 18    40 X 2^18   =  10485760

We can shifit any numbers in between 0 to 31 for 32 bit integers
In binary, multiplying a number by two is the same as adding a zero to the right side

40 >> 1 	40 / 2^1	=  20
40 >> 2 	40 / 2^2    =  10
40 >> 3 	40 / 2^3    =  5
40 >> 4 	40 / 2^4    =  2.5
40 >> 5 	40 / 2^5    =  1  (1.25)
40 >> 18	40 / 2^18   =  0 (0.000152)
    

Be aware of truncation and overflow issues.

===========================================================================================================================================================================================

Arithmatic vs Logicas Shifts :

The bit shifts are sometimes considered bitwise operations, because they treat a value as a series of bits rather than as a numerical quantity. 
In these operations the digits are moved, or shifted, to the left or right. 
    
Registers in a computer processor have a fixed width, so some bits will be "shifted out" of the register at one end, while the same number of bits are "shifted in" from the other end.
The differences between bit shift operators lie in how they determine the values of the shifted-in bits.

    
Arithmetic Shift:

In an arithmetic shift, the bits that are shifted out of either end are discarded. 
In a  left arithmetic shift, zeros are shifted-in on the right.
In a right arithmetic shift, the sign bit (the MSB in two's complement) is shifted-in on the left.

Logical Shift:

In a logical shift, zeros are shifted-in to replace the discarded bits. So the logical and arithmetic left-shifts are exactly the same.

However, as the logical right-shift inserts value 0 bits into the most significant bit, instead of copying the sign bit.
    
Logical Right-shift is ideal for unsigned binary numbers.
Arithmetic right-shift is ideal for signed two's complement binary numbers.

In C#, 
The right-shift is an arithmetic shift when the first operand is an int or long. 
If the first operand is of type uint or ulong, the right-shift is a logical shift.

Arithmetic right shift will shift in the sign bit while preserving the sign bit. 
Logical shift always shifts in zeros no matter in which direction you do the shift
    
In Java,
Arithmetic right shift operator is >> 
Logical right shift operator is >>>

>>  - Signed.
>>> - Un Signed.

============================================================================================================================================================================================================================

Logical Right Shift >>> ( same as >> except considering the sign )

&	Bitwise   AND (Both results should be true), 
| 	Bitwise   OR  (Any one result should be true).
~ 	Bitwise   NOT (Invert) Complement bitwise operator. Taking the binary representation of a number, taking it's complement (inverting all the bits) and adding one. 
            Flip all bits E.g.   3   In Binary  0000 0011 
                                ~3 (Complement) 1111 1100
^	Exclusive XOR ( results should be inversion, if both same (true/false) then result is false)
    
ANDing anything to 1 is the same as "keeping" that bit
E.g. 	0 & 1 Result 0
        1 & 1 Result 1

ANDing with 0 is the same as "ignoring" that bit.
E.g. 	0 & 0 Result 0
    	1 & 0 Result 0
Uses:

int result = 5 * (int)Math.Pow(2, 7);
int result = 5 << 7;
    

http://programmingansic.blogspot.com/2014/11/1s-and-2s-complement.html

================================================================================================================================================================================================================================

[Flags]
enum Days2
{
    None = 0x0,
    Sunday = 0x1,
    Monday = 0x2,
    Tuesday = 0x4,
    Wednesday = 0x8,
    Thursday = 0x10,
    Friday = 0x20,
    Saturday = 0x40
}

class MyClass
{
    Days2 meetingDays = Days2.Tuesday | Days2.Thursday;
    Days2 notWednesday = ~(Days2.Wednesday);
}
    
Take this, an algorithm to calculate the absolute value of a number, without using any CONDITIONAL BRANCH instruction:
int abs(const int input) 
{
    int temp = A >> 31;
    return ( input ^ A ) - A;
}

A reason to avoid CONDITIONAL BRANCHING is that it could stop your processor pre-fetching, waiting for the condition to be verified to know to which value the PROGRAM COUNTER should be set.

Common C# Operations on Bitwise
    
boolean isFoo = ...
boolean isBar = ...

if (isFoo ^ isBar) 
{
    // Either isFoo is true or isBar is true, but not both.
    
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Relating with Set Operations :

http://www.quora.com/How-do-I-understand-bitwise-tricks-in-C++-for-competitive-programming

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

For instance, you might have an integer in the database representing a set of security permissions for a user, and in your web app you would have to check those before continuing.

Those tend to only require & and | - e.g.
if ((permissions & Permission.CreateUser) != 0)
{
    ...
}

OR
    
Permission requiredPermission = Permission.CreateUser | Permission.ChangePassword;

Nibble : 4 bits 

============================================================================================================================================================================================================================
http://www.exploringbinary.com/binary-addition/
http://en.wikipedia.org/wiki/Nibble
http://en.wikipedia.org/wiki/Endianness
http://searchnetworking.techtarget.com/definition/big-endian-and-little-endian
http://www.cs.umd.edu/class/sum2003/cmsc311/Notes/Data/endian.html
http://vipan.com/htdocs/bitwisehelp.html    
http://www.allaboutcircuits.com/vol_1/index.html
http://www.ehow.com/how_5124016_convert-negative-numbers-binary.html
http://stackoverflow.com/questions/93744/most-common-c-sharp-bitwise-operations-on-enums
http://stackoverflow.com/questions/261062/when-to-use-bitwise-operators-during-webdevelopment
http://ascii.cl/conversion.htm
http://msdn.microsoft.com/en-us/library/cc138362.aspx
http://stackoverflow.com/questions/47981/how-do-you-set-clear-and-toggle-a-single-bit-in-c-c
Detailed http://www.anotherchris.net/csharp/csharp-bit-manipulation-by-example-part-2/
http://www.blackwasp.co.uk/CSharpLogicalBitwiseOps.aspx

============================================================================================================================================================================================================================

On simple low-cost processors, typically, bitwise operations are substantially faster than division, several times faster than multiplication, and sometimes significantly faster than addition. 
While modern processors usually perform addition and multiplication just as fast as bitwise operations due to their longer instruction pipelines and other architectural design choices.
Bitwise operations do commonly use less power because of the reduced use of resources.


For unsigned integers, the bitwise complement of a number is the "mirror reflection" of the number across the half-way point of the unsigned integer's range. 
E.g. for 8-bit unsigned integers, NOT x = 255 - x, which can be visualized on a graph as a downward line that effectively "flips" an increasing range from 0 to 255, to a decreasing range from 255 to 0. 
A simple but illustrative example use is to invert a grayscale image where each pixel is stored as an unsigned integer.


(& , |, ^ ) Takes two equal-length binary representations.


AND:

For example:
    0101 (decimal 5)
AND 0011 (decimal 3)
  = 0001 (decimal 1)

The operation may be used to determine whether a particular bit is set (1) or clear (0). 



If we store the result, this may be used to clear selected bits in a register. 
Given the example 0110 (decimal 6), the second bit may be cleared by using a bitwise AND with the pattern that has a zero only in the second bit:

    0110 (decimal 6)
AND 1101 (decimal 13)
  = 0100 (decimal 4)


Because of this property, it becomes easy to check the parity of a binary number by checking the value of the lowest valued bit

OR:

The bitwise OR may be used to set the selected bits to 1. For example, it can be used for setting a specific bit (or flag) in a register, where each bit represents an individual Boolean state. 
Thus, 0010 (decimal 2) can be considered a set of four flags, where the first, third, and fourth flags are clear (0) and the second flag is set (1). 
The fourth flag may be set by performing a bitwise OR between this value and a bit pattern with only the fourth bit set:

   0010 (decimal 2)
OR 1000 (decimal 8)
 = 1010 (decimal 10)

XOR
This technique is an efficient way to store a number of Boolean values using as little memory as possible.

================================================================================================================================================================================================================================

*/