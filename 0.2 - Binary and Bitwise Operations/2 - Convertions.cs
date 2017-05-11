using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*

    ===================================================================================================================================================================================================
Note: the Number Base is also called the Radix


1. Binary (Base 2) has only 2 digits : 0 and 1

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 10   Start back at 0 again, but add 1 on the left 
••• 11     
•••• 100   start back at 0 again, and add one to the number on the left...
 ... but that number is already at 1 so it also goes back to 0 ...
 ... and 1 is added to the next position on the left 
••••• 101     
•••••• 110     
••••••• 111     
•••••••• 1000   Start back at 0 again (for all 3 digits), 
 add 1 on the left 
••••••••• 1001   And so on! 

See how it is done in this little demonstration (press play):

          

Also try Decimal, and try other bases like 3 or 4.
 It will help you understand how all these different bases work. 
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

2. Ternary (Base 3) has 3 digits: 0, 1 and 2

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 2     
••• 10   Start back at 0 again, but add 1 on the left 
•••• 11     
••••• 12     
•••••• 20   Start back at 0 again, but add 1 on the left 
••••••• 21     
•••••••• 22     
••••••••• 100   start back at 0 again, and add one to the number on the left...
 ... but that number is already at 2 so it also goes back to 0 ...
 ... and 1 is added to the next position on the left 
•••••••••• 101   And so on! 
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

3. Quaternary (Base 4) has 4 digits: 0, 1, 2 and 3

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 2     
••• 3     
•••• 10   Start back at 0 again, but add 1 on the left 
••••• 11     
•••••• 12     
••••••• 13     
•••••••• 20   Start back at 0 again, but add 1 on the left 
••••••••• 21   And so on! 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

4. Quinary (Base 5) has 5 digits: 0, 1, 2, 3 and 4

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 2     
••• 3     
•••• 4     
••••• 10   Start back at 0 again, but add 1 on the left 
•••••• 11     
••••••• 12     
•••••••• 13     
••••••••• 14     
•••••••••• 20   Start back at 0 again, but add 1 on the left 
••••••••••
 • 21   And so on! 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

5. Senary (Base 6) has 6 digits: 0, 1, 2, 3, 4 and 5

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 2     
••• 3     
•••• 4     
••••• 5     
•••••• 10   Start back at 0 again, but add 1 on the left 
••••••• 11     
•••••••• 12     
••••••••• 13     
•••••••••• 14     
••••••••••
 • 15     
••••••••••
 •• 20   Start back at 0 again, but add 1 on the left 
••••••••••
 ••• 21   And so on! 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

6. Septenary (Base 7) has 7 digits: 0, 1, 2, 3, 4 5 and 6

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 2   Then 2 
  ⋮     
•••••• 6   Up to 6 
••••••• 10   Start back at 0 again, but add 1 on the left 
•••••••• 11     
••••••••• 12     
  ⋮     
••••••••••
 ••• 16     
••••••••••
 •••• 20   Start back at 0 again, but add 1 on the left 
••••••••••
 ••••• 21   And so on! 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

7. Octal (Base 8) has 8 digits: 0, 1, 2, 3, 4, 5, 6 and 7

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 2   Then 2 
  ⋮     
••••••• 7   Up to 7 
•••••••• 10   Start back at 0 again, but add 1 on the left 
••••••••• 11     
•••••••••• 12     
  ⋮     
••••••••••
 ••••• 17     
••••••••••
 •••••• 20   Start back at 0 again, but add 1 on the left 
••••••••••
 ••••••• 21   And so on! 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

8. Nonary (Base 9) has 9 digits: 0, 1, 2, 3, 4, 5, 6, 7 and 8

We count like this:


  0   Start at 0  
• 1   Then 1 
•• 2   Then 2 
  ⋮     
•••••••• 8   Up to 8 
••••••••• 10   Start back at 0 again, but add 1 on the left 
•••••••••• 11     
••••••••••
 • 12     
  ⋮     
••••••••••
 ••••••• 18     
••••••••••
 •••••••• 20   Start back at 0 again, but add 1 on the left 
••••••••••
 ••••••••• 21   And so on! 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

9. Decimal (Base 10) has 10 digits: 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9

Well ... we talked about this at the start but here it is again:


  0   Start at 0  
• 1   Then 1 
•• 2   Then 2 
  ⋮     
••••••••• 9   Up to 9 
•••••••••• 10   Start back at 0 again, but add 1 on the left 
••••••••••
 • 11     
••••••••••
 •• 12     
  ⋮     
••••••••••
 ••••••••• 19     
••••••••••
 •••••••••• 20   Start back at 0 again, but add 1 on the left 
••••••••••
 ••••••••••
 • 21   And so on! 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

10. Undecimal (Base 11)

Undecimal (Base 11) needs one more digit than Decimal, so "A" is used, like this:


Decimal:
0 1 2 3 4 5 6 7 8 9 10 11 12 ... 

Undecimal:
0 1 2 3 4 5 6 7 8 9 A 10 11 ... 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
11. Duodecimal (Base 12)

Duodecimal (Base 12) needs two more digits than Decimal, so "A" and "B" are used:


Decimal:
0 1 2 3 4 5 6 7 8 9 10 11 12 13 ... 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

12. Duodecimal:
0 1 2 3 4 5 6 7 8 9 A B 10 11 ... 

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
13. Hexadecimal (Base 16)

Because there are more than 10 digits, hexadecimal is written using letters as well, like this:


Decimal:
0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 ... 

Hexadecimal:
0 1 2 3 4 5 6 7 8 9 A B C D E F 10 11 ... 
    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

14. Vigesimal (Base 20)

With vigesimal, the convention is that I is not used because it looks like 1, so J=18 and K=19, as in this table:


Decimal:
0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 ... 

Vigesimal:
0 1 2 3 4 5 6 7 8 9 A B C D E F G H J K 10 ... 

More About Bases

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    
    Binary      (Base 2)    :   0  1 
    Ternary     (Base 3)    :   0  1  2  10  11  12  20  21  22  100
    Quaternary  (Base 4)    :   0  1  2  3   10  11  12  13  14  20  21  22  23  24
    Quinary     (Base 5)
    Senary      (Base 6)
    Septenary   (Base 7)
    Octal       (Base 8)    :   0 1 2 3 4 5 6 7   
    Nonary      (Base 9)
    Decimal     (Base 10)   : Denary      :   0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42    
    Unidecimal  (Base 11)
    Duodecimal  (Base 12)
    Hexadecimal (Base 16)   :   0 1 2 3 4 5 6 7 8 9  A  B  C  D  E  F 10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 20 21 22 23 24 25 26 27 28 29 2A  
    http://www.mathsisfun.com/hexadecimals.html
    Vegesimal   (Base 20)   :   0 1 2 3 4 5 6 7 8 9  A  B  C  D  E  F  G  H  J  K 10 11 12... 
                                With vigesimal, the convention is that 'I' is not used because it looks like 1, so J=18 and K=19, as in this table
    Roman Numerals      :   I, II, III, IV, V, VI, VII, VIII, IX, X

    ===================================================================================================================================================================================================

    Binary Number       :   http://en.wikipedia.org/wiki/Binary_numeral_system  
                            http://www.mathsisfun.com/binary-number-system.html
                                                                                
    Base 2.
    
    Decimal to Binary for 65     -       1       0       0       0       0       0       1

    2| 65
      ------
     2| 32 - 1
       -------
      2| 16 - 0
        -------
        2| 8 - 0
          -------
         2| 4 - 0
           -------
          2| 2 - 0
            -------
           2| 1 - 0
            -------
               0 - 1

    Write bottom to top.

    Note: 2 X 0 = 0 and 1/2 Reminder 1.

    A series of binary digits (from most significant digit to least significant), bn-1bn-2bn-3...b2b1b0

    LSD (least significant digit) method 

    Let bi = the least significant binary digit, i.e., i = 0
        1.Divide the number N by 2; this produces a quotient Q and a remainder R.
        2.Let R = bi.
        3.Let Q replace N
        4.If N = 0 then quit; otherwise increase i to i+1 and repeat steps 1-4.

    ===================================================================================================================================================================================================

    Ternary             :   http://en.wikipedia.org/wiki/Ternary_numeral_system
    Base 3.             

    ===================================================================================================================================================================================================

    Octal Number        :   http://en.wikipedia.org/wiki/Octal
    Base 8.

    Octal Multiplication
    ---------------------------
    × | 01 02 03 04 05 06 07 10 
    ---------------------------
    01| 01 02 03 04 05 06 07 10 
    02| 02 04 06 10 12 14 16 20 
    03| 03 06 11 14 17 22 25 30 
    04| 04 10 14 20 24 30 34 40 
    05| 05 12 17 24 31 36 43 50 
    06| 06 14 22 30 36 44 52 60 
    07| 07 16 25 34 43 52 61 70 
    10| 10 20 30 40 50 60 70 100 
    
    ===================================================================================================================================================================================================

    Decimal/Denary Number    : 
    Base 10.

    Binary to Decimal :

    1           0           0           0           0           0           1
    2^6 X 1     2^5 X 0     2^4 X 0     2^3 X 0     2^2 X 0     2^1 X 0     2^0 X 1  
    64          0           0           0           0           0           1   =   65

    Convert binary number 101111 to Decimal:

    1 *  1 = 1
    1 *  2 = 2
    1 *  4 = 4
    1 *  8 = 8
    0 * 16 = 0
    1 * 32 = 32
    
    Decimal value   : 1 + 2 + 4 + 8 + 0 + 32 = 47

    ===================================================================================================================================================================================================

    Hexadecimal Number  :   http://en.wikipedia.org/wiki/Hexadecimal  http://www.mathsisfun.com/hexadecimals.html
    Base 16.

    Hexadecimal Counting:   http://en.wikipedia.org/wiki/File:Hexadecimal-counting.jpg 

    Hexadecimal Multiplication : http://en.wikipedia.org/wiki/File:Hexadecimal_multiplication_table.svg

    1. Each hexadecimal digit represents four binary digits (bits), and the primary use of hexadecimal notation is a human-friendly representation of binary-coded values in computing and digital electronics
    2. Hexadecimal is also commonly used to represent computer memory addresses.
    3. One hexadecimal digit represents a nibble, which is half of an octet or byte (8 bits). 
       E.g byte values can range from 0 to 255 (decimal), but may be more conveniently represented as two hexadecimal digits in the range 00 to FF. 
    
    ◾(1E3)16  = (0001 1110 0011)2
    ◾(0A2B)16 = (0000 1010 0010 1011)2
    ◾(7E0C)16 = (0111 1110 0000 1100)2

    ◾(0000 1110)2 = 0Eh
    ◾(0011 1001)2 = 39h
    ◾(1001 1100)2 = 9Ch

    ---------------------------------------------------------------------------
    E.g.1 :     Hexadecimal Value : D1CE

                D = 13 x 16^3   (16^3)
                1 = 1  x 16^2   (16^2)
                C = 12 x 16     (16^1)
                E = 14 x 1      (16^0)

                Decimal Value   : 53,710
    ---------------------------------------------------------------------------
    E.g.2 :     Hexadecimal Value : 2E6.A3
    
                2 =  2  x 16^2
                E =  14 x 16
                6 =  6  x 1
                . = .
                A =  10 / 1  (16^0)
                3 =   3 / 16 (16^1)

                ( 2 × 1 6 × 16 ) + ( 14 × 16 ) + 6 . ( 10 / 1 ) + ( 3 / 16 )

                Decimal Value   : 742.28 

    1. Convert 256 to hexadecimal. Divide it by 16: 256/16 = 16.
    2. Since it has no remainder, put "0" as a remainder.
    3. Divide 16 by 16, which is 1. No remainder, so again put "0" as a remainder.
    4. Lastly, since we know that 1/16 is less than one, just put 1 as the remainder. Our remainder list is 001, so we switch it around and get 100. 100 is hexadecimal for 256!

    1. Divide 2500 by 16, we get 156.25. Multiply our remainder, (.25), by 16. This gives us 4. Add 4 to the list of remainders.
    2. Divide 156 by 16, which gives us 9.75. Multiply the remainder by 16, we get 12. Add 12 to the list of remainders. (Remember, in hexadecimal, 12 is C, so put C instead.) Our remainder list should be: 4C.
    3. Since we know 9/16 is less than one, add 9 to the list of remainders without bothering to divide it. The remainder list is 4C9. Switch it around, and we get 9C4. 9C4 is hexadecimal for 2500.

    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    All Conversion Functions:
    http://www.cquestions.com/2011/07/program-to-convert-decimal-to-binary-in.html

    ===================================================================================================================================================================================================
    
    Roman Numerals      :   http://en.wikipedia.org/wiki/Roman_numerals

     Symbol    Value
        I       1
        V       5
        X       10
        L       50
        C       100
        D       500
        M       1,000

    MMXIV - 2014

    ===================================================================================================================================================================================================

                    1       2       3       4
    Cardinal    :   One     Two     Three   Four
    Ordinal     :   First   Second  Third   Fourth
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Base64      : 
    
    Is a group of similar binary-to-text encoding schemes that represent binary data in an ASCII string format by translating it into a radix-64 representation. 
    The term Base64 originates from a specific MIME content transfer encoding.

    Base64 encoding schemes are commonly used when there is a need to encode binary data that needs to be stored and transferred over media that are designed to deal with textual data. 
    This is to ensure that the data remains intact without modification during transport. 
    Base64 is commonly used in a number of applications including email via MIME, and storing complex data in XML

    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Built in Types              :   http://msdn.microsoft.com/en-us/library/ya5y69ds.aspx
    Implicit Conversion in C#   :   http://msdn.microsoft.com/en-us/library/y5b434w4.aspx
    Integral Types & Range      :   http://msdn.microsoft.com/en-us/library/exx3b86w.aspx
    Default Values              :   http://msdn.microsoft.com/en-us/library/83fhsxwc.aspx
    Formatting Numeric Results  :   http://msdn.microsoft.com/en-us/library/s8s7t687.aspx   E.g. {0:C} - Currency, {0:D} - Decimal, {0:E} - Scientific {0:F2} - Fixed Point, {0:N} - Number, {0:X}

    Reference Links

    https://www.youtube.com/channel/UC_-G3VS5SIUEONILW8s6LjQ
    http://en.wikipedia.org/wiki/Base64
    http://stackoverflow.com/questions/201479/what-is-base-64-encoding-used-for

    ============================================================================================================================================================================================================================
    */
    partial class BinaryAndBitwiseOperations
    {
        public void RandomDemo()
        {
            strRslt.AppendLine("Positive Infinity : " + double.PositiveInfinity);
            strRslt.AppendLine("Negative Infinity : " + double.NegativeInfinity);

            strRslt.AppendLine("Epsilon : " + double.Epsilon);
            strRslt.AppendLine("Negative Infinity : " + double.NegativeInfinity);

        }
        // From Decimal/Denary/Engligh Number : ================================================================================================================================================================================

        public Int64 Decimal2Binary(Int64 decimalNumber)
        {
            string binaryRsvrStr = string.Empty;

            Int64 quotent = decimalNumber;
            Int64 reminder = 0;

            while (quotent > 0)
            {
                reminder = quotent % 2;
                binaryRsvrStr += reminder;
                quotent = quotent / 2;
            }

            StringBuilder binaryStr = new StringBuilder();

            for (int lpCnt = binaryRsvrStr.Length - 1; lpCnt >= 0; lpCnt--)
            {
                binaryStr.Append(binaryRsvrStr[lpCnt]);
            }

            Int64 binaryNum = Int64.Parse(binaryStr.ToString());

            return binaryNum;
        }

        //http://www.cquestions.com/2011/07/c-program-for-fractional-decimal-to.html
        //Decimal Fractions to Binary http://cs.furman.edu/digitaldomain/more/ch6/dec_frac_to_bin.htm
        public Int64 FractionalDecimal2Binary(Int64 decimalNumber)
        {
            return -1;
        }

        /*
        http://m.wikihow.com/Convert-from-Decimal-to-Hexadecimal
        */
        public Int64 Decimal2HexaDecimal()
        {
            return -1;
        }

        public Int64 Decimal2Octal(Int64 decimalNumber)
        {
            string binaryRsvrStr = string.Empty;

            Int64 quotent = decimalNumber;
            Int64 reminder = 0;

            while (quotent > 0)
            {
                reminder = quotent % 8;
                binaryRsvrStr += reminder;
                quotent = quotent / 8;
            }

            StringBuilder binaryStr = new StringBuilder();

            for (int lpCnt = binaryRsvrStr.Length - 1; lpCnt >= 0; lpCnt--)
            {
                binaryStr.Append(binaryRsvrStr[lpCnt]);
            }

            Int64 octalNum = Int64.Parse(binaryStr.ToString());

            return octalNum;
        }

        //http://www.cquestions.com/2011/08/c-program-to-convert-decimal-to-roman.html
        public string Decimal2Roman(Int64 decimalNumber)
        {
            return string.Empty;
        }
        // From Octal : ========================================================================================================================================================================================================

        public Int64 Octal2Decimal()
        {
            return -1;
        }

        public Int64 Octal2HexaDecimal()
        {
            return -1;
        }

        public Int64 Octal2Binary(string octalNumber)
        {
            StringBuilder binaryStr = new StringBuilder();

            for (int lpCnt = 0; lpCnt < octalNumber.Length; lpCnt++)
            {
                switch (octalNumber[lpCnt])
                {
                    case '0': binaryStr.Append("000"); break;
                    case '1': binaryStr.Append("001"); break;
                    case '2': binaryStr.Append("010"); break;
                    case '3': binaryStr.Append("011"); break;
                    case '4': binaryStr.Append("100"); break;
                    case '5': binaryStr.Append("101"); break;
                    case '6': binaryStr.Append("110"); break;
                    case '7': binaryStr.Append("111"); break;
                    default:
                        {
                            throw new Exception("Invalid Octal Number");
                        }
                }
            }

            return Convert.ToInt64(binaryStr.ToString());
        }

        // From Binary : =======================================================================================================================================================================================================

        public Int64 Binary2Decimal(Int64 binaryNumber)
        {
            Int64 remainder;
            Int64 decimalNumber = 0;
            Int64 base2Multiplier = 1;

            while (binaryNumber != 0)
            {
                // reminder would be always eigther 1 or 0.
                remainder = binaryNumber % 10;

                decimalNumber = decimalNumber + remainder * base2Multiplier;

                binaryNumber = binaryNumber / 10;

                // base2Multiplier -> 1, 2, 4, 8, 16, 32 ... 
                base2Multiplier = base2Multiplier * 2;
            }

            return decimalNumber;
        }

        public Int64 Binary2HexaDecimal()
        {
            return -1;
        }

        // http://www.cquestions.com/2011/07/binary-to-octal-conversion-in-c.html
        public Int64 Binary2Octal()
        {

            return -1;
        }

        /*  Binary Codes for Alphabets : 
            Get the ASCII value for each charater and then convert it into Binary format.

          ASCII    Chr  Binary Format         ASCII    Chr  Binary Format 
            65   	A     01000001             	97      a    01100001
            66  	B     01000010             	98      b    01100010
            67  	C     01000011             	99      c    01100011
            68  	D     01000100             	100 	d    01100100
            69  	E     01000101             	101 	e    01100101
            70  	F     01000110             	102 	f    01100110
            71  	G     01000111             	103 	g    01100111
            72  	H     01001000             	104 	h    01101000
            73  	I     01001001             	105 	i    01101001
            74  	J     01001010             	106 	j    01101010
            75  	K     01001011             	107 	k    01101011
            76  	L     01001100             	108 	l    01101100
            77  	M     01001101             	109 	m    01101101
            78  	N     01001110             	110 	n    01101110
            79  	O     01001111             	111 	o    01101111
            80  	P     01010000             	112 	p    01110000
            81  	Q     01010001             	113 	q    01110001
            82  	R     01010010             	114 	r    01110010
            83  	S     01010011             	115 	s    01110011
            84  	T     01010100             	116 	t    01110100
            85  	U     01010101             	117 	u    01110101
            86  	V     01010110             	118 	v    01110110
            87  	W     01010111             	119 	w    01110111
            88  	X     01011000             	120 	x    01111000
            89  	Y     01011001             	121 	y    01111001
            90  	Z     01011010             	122 	z    01111010
        */

        public char Binary2Char(Int64 binaryNumber)
        {

            return '\0';
        }

        public string LongBinary2Hexadecimal(string strBinary = "0110011010010111001001110101011100110100001101101000011001010110001101101011")
        {
            //string strHex = Convert.ToString(strBinary, 2).ToString("X");
            //return strHex;
            StringBuilder result = new StringBuilder(strBinary.Length / 8 + 1);

            // TODO: check all 1's or 0's... Will throw otherwise

            int mod4Len = strBinary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                strBinary = strBinary.PadLeft(((strBinary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < strBinary.Length; i += 8)
            {
                string eightBits = strBinary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }

        // From Hexadecimal : ==================================================================================================================================================================================================

        public Int64 HexadecimaltoDecimal(string hexadecimalNumber)
        {
            return -1;
        }

        /*
        http://msdn.microsoft.com/en-us/library/bb311038.aspx
        http://www.c-sharpcorner.com/UploadFile/Joshy_geo/HexConverter10282006021521AM/HexConverter.aspx
        */
        public Int64 HexadecimaltoDecimalCSharp(string hexadecimalNumber)
        {
            //int value = Convert.ToInt32(hex, 16);

            return Int64.Parse(hexadecimalNumber, System.Globalization.NumberStyles.HexNumber);
        }

        public Int64 HexadecimaltoBinary(string hexadecimalNumber)
        {
            return -1;
        }

        public Int64 HexadecimaltoOctal(string hexadecimalNumber)
        {
            return -1;
        }

        // From Char or String : ===============================================================================================================================================================================================

        // Using String.Format("{0:X}", intValue) OR intValue.ToString("X") OR Convert.ToInt32(intValue, 16) OR ToString("X2")) - 0C ~ allways double-digit output

        public string StringToHexadecimal(string stringValue = "Hello World!")
        {
            string hexOutput = string.Empty;
            char[] values = stringValue.ToCharArray();

            foreach (char letter in values)
            {
                // Get the integral value of the character. 
                int intValue = Convert.ToInt32(letter);

                // Convert the decimal value to a hexadecimal value in string form. 
                hexOutput += " " + String.Format("{0:X}", intValue);

                //string myHex = intValue.ToString("X");  // gives you hex
                //int myNewInt = Convert.ToInt32(intValue, 16); 

            }

            return hexOutput;
        }

        // Using Char.ConvertFromUtf32
        public string HexadecimalToStringCSharp(string hexadecimalNumber = "48 65 6C 6C 6F 20 57 6F 72 6C 64 21")
        {
            string rsltStr = string.Empty;
            string[] hexValuesSplit = hexadecimalNumber.Split(' ');

            foreach (String hex in hexValuesSplit)
            {
                // Convert the number expressed in base-16 to an integer. 
                int value = Convert.ToInt32(hex, 16);

                // Get the character corresponding to the integral value. 
                string stringValue = Char.ConvertFromUtf32(value);

                char charValue = (char)value;
                rsltStr += " " + charValue;
            }

            return rsltStr;
        }

        // Using System.Globalization.NumberStyles.AllowHexSpecifier
        public float HexadecimalToFloatCSharp(string hexadecimalNumber = "43480170")
        {
            uint num = uint.Parse(hexadecimalNumber, System.Globalization.NumberStyles.AllowHexSpecifier);

            byte[] floatVals = BitConverter.GetBytes(num);
            float f = BitConverter.ToSingle(floatVals, 0);

            return f;
        }

        public Int64 Char2Number(char charToConvert)
        {
            return 0;
        }

        public byte[] ConvertToBinary(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
        // Base 64 : ===========================================================================================================================================================================================================
        // http://msdn.microsoft.com/en-us/library/System.Convert_methods(v=vs.110).aspx
        // http://msdn.microsoft.com/en-us/library/8s62fh68(v=vs.110).aspx
        // http://msdn.microsoft.com/en-us/library/system.convert.frombase64chararray(v=vs.110).aspx
        public void ConvertFromBaseToBaseInDotNet()
        {
            int[] supportedBases = { 2, 8, 10, 16 };

            byte[] byteArrayNumbers = { 10, 65, Byte.MinValue, Byte.MaxValue };
            short[] shortArrayNumbers = { Int16.MinValue, -13621, -18, 12, 19142, Int16.MaxValue };
            int[] intArrayNumbers = { Int32.MinValue, -19327543, -13621, -18, 12, 19142, Int32.MaxValue };
            long[] longArrayNumbers = { Int64.MinValue, -193275430, -13621, -18, 12, 1914206117, Int64.MaxValue };

            foreach (int baseValue in supportedBases)
            {
                Debug.WriteLine("Base {0} conversion: For Byte ", baseValue);
                foreach (byte number in byteArrayNumbers)
                {
                    Debug.WriteLine("   {0, -5}  -->  {1}", number, Convert.ToString(number, baseValue));
                }

                Debug.WriteLine("Base {0} conversion: For Short ", baseValue);
                foreach (short number in shortArrayNumbers)
                {
                    Debug.WriteLine("   {0, -5}  -->  {1}", number, Convert.ToString(number, baseValue));
                }
            }

            System.Globalization.NumberFormatInfo numberFormatInfo = new System.Globalization.NumberFormatInfo();
            numberFormatInfo.NegativeSign = "~";
            numberFormatInfo.PositiveSign = "!";

            foreach (int number in byteArrayNumbers)
            {
                Debug.WriteLine("{0,-12}  -->  {1,12}",
                                  Convert.ToString(number, System.Globalization.CultureInfo.InvariantCulture),
                                  Convert.ToString(number, numberFormatInfo));
            }
        }

        //======================================================================================================================================================================================================================

        public void ConversionTest()
        {
            strRslt.Clear();
            strRslt.AppendLine("Convertion Test : ");

            string longHexaDecimalNumber;
            Int64 decimalNumber = 65;
            Int64 binaryNumber = 0;
            Int64 octalNum = 0;

            //=======================================================================================================================================================

            // From Decimal
            strRslt.AppendLine("\n\n From Decimal To : ");

            binaryNumber = Decimal2Binary(decimalNumber);
            strRslt.AppendFormat("\n        Decimal Number : {0}  Binary Number {1}", decimalNumber, binaryNumber);
            strRslt.AppendFormat("\n C# Way Decimal Number : {0}  Binary Number {1}", decimalNumber, Convert.ToString(decimalNumber, 2).PadLeft(8, '0'));

            decimalNumber = 10;
            binaryNumber = Decimal2Binary(decimalNumber);
            strRslt.AppendFormat("\n Decimal Number : {0}  Binary Number {1}", decimalNumber, binaryNumber);

            strRslt.AppendLine();

            octalNum = Decimal2Octal(decimalNumber);
            strRslt.AppendFormat("\n        Decimal Number : {0}  Octal Number {1}", decimalNumber, octalNum);
            strRslt.AppendFormat("\n C# Way Decimal Number : {0}  Octal Number {1}", decimalNumber, Convert.ToInt32(octalNum.ToString(), 8));

            decimalNumber = 25;
            octalNum = Decimal2Octal(decimalNumber);
            strRslt.AppendFormat("\n        Decimal Number : {0}  Octal Number {1}", decimalNumber, octalNum);
            strRslt.AppendFormat("\n C# Way Decimal Number : {0}  Octal Number {1}", decimalNumber, Convert.ToInt32(octalNum.ToString(), 8));

            //=======================================================================================================================================================

            // From Binary
            strRslt.AppendLine("\n\n From Binary To : ");

            binaryNumber = 1000001;
            decimalNumber = Binary2Decimal(binaryNumber);
            strRslt.AppendFormat("\n Decimal Number : {0}  Binary Number {1}", decimalNumber, binaryNumber);

            binaryNumber = 1010;
            decimalNumber = Binary2Decimal(binaryNumber);
            strRslt.AppendFormat("\n Decimal Number : {0}  Binary Number {1}", decimalNumber, binaryNumber);

            //=======================================================================================================================================================

            // From Octal
            strRslt.AppendLine("\n\n From Octal To : ");

            string octalNumber = "123";
            binaryNumber = Octal2Binary(octalNumber);
            strRslt.AppendFormat("\n Octal Number : {0}  Binary Number {1}", decimalNumber, binaryNumber);

            LongBinary2Hexadecimal();
            strRslt.AppendFormat("\n Octal Number : {0}  Binary Number {1}", decimalNumber, binaryNumber);

            longHexaDecimalNumber = LongBinary2Hexadecimal();
            strRslt.AppendFormat("\n Long Binary to Hexadecimal", longHexaDecimalNumber);
            //=======================================================================================================================================================
            MessageBox.Show(strRslt.ToString());
        }
    }
}
/*
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Decimal to Binary :

    Verification for 65     -       1       0       0       0       0       0       1

       2| 65
         ---------
         2| 32 - 1
          ---------
          2| 16 - 0
            --------
            2| 8 - 0
             --------
             2| 4 - 0
              --------
              2| 2 - 0
               --------
               2| 1 - 0
               --------
                  0 - 1

    Write bottom to top.

    Note: 2 X 0 = 0 and 1/2 Reminder 1.
    
    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Binary to Decimal :

    1           0           0           0           0           0           1
    64          32          16          8           4           2           1
    2^6         2^5         2^4         2^3         2^2         2^1         2^0

    2^6 X 1     2^5 X 0     2^4 X 0     2^3 X 0     2^2 X 0     2^1 X 0     2^0 X 1
    2^6         0           0           0           0           0           2^0
    64                                                                      1   =   65

    ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*/