using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===========================================================================================================================================================================================    

    http://msdn.microsoft.com/en-us/library/ms174986.aspx
    http://msdn.microsoft.com/en-us/library/ms190276.aspx

    http://en.wikipedia.org/wiki/Operator_precedence
    http://en.wikipedia.org/wiki/Operators_in_C_and_C%2B%2B
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    http://en.wikipedia.org/wiki/BODMAS

    B   -   Brackets first 
    O   -   Orders (ie Powers and Square Roots, etc.) 
    D   -   Division
    M   -   Multiplication (Left to right) 
    A   -   Addition
    S   -   Subtraction (Left to right) 

    Evaluate a given mathematical expression, taking into consideration the BODMAS rule. The expression contains no brackets.
    http://www.careercup.com/question?id=5694909059170304
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Precedence Goes from left to right  

    ++, --              - Prefix Unary (E.g. ++i, --i)
    /, %, X             - Same Precedence and which ever comes first from left to right
    +, -                - Same Precedence and which ever comes first from left to right
    <, <=, >, >=        - Comparisions
    ==, !=              - Comparisions
    =, +=               - All Compound Operators( +=, -=, *= /= &=, |= etc)
    ++, --              - Postfix Unary ( i++, i--)
    
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    a-----b

    After parse
    token 1: a
    token 2: --
    token 3: --
    token 4: -
    token 5: b
    conclude: (a--)-- - b

    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    1       ()   []   ->   .   ::                                     Grouping, scope, array/member access 
    2       !   ~   -   +   *   &   sizeof   type cast ++x   --x      (most) unary operations, sizeof and type casts 
    3       *   /   %                                                 Multiplication, division, modulo 
    4       +   -                                                     Addition and subtraction 
    5       <<   >>                                                   Bitwise shift left and right 
    6       <   <=   >   >=                                           Comparisons: less-than, ... 
    7       ==   !=                                                   Comparisons: equal and not equal 
    8       &                                                         Bitwise AND 
    9       ^                                                         Bitwise Exclusive OR 
    10      |                                                         Bitwise Inclusive (Normal) OR 
    11      &&                                                        Logical AND 
    12      ||                                                        Logical OR 
    13      ?:, =, +=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=           Conditional expression (ternary) and assignment operators 
    14      ,                                                         Comma operator 

    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    Maximum Munch Rule :

    http://en.wikipedia.org/wiki/Maximal_munch

    -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    Tip to Remember : Please Excuse Me Dear AiShu  ( P - Paranthasis, E - Exponentials, Me
    ===========================================================================================================================================================================================        
    */
    partial class BinaryAndBitwiseOperations
    {
        StringBuilder strRslt = new StringBuilder();
        Double db = new double();

        public void ArithMaticOperators()
        {
            strRslt.Clear();
            strRslt.AppendLine("ArithMatic Operators :");

            int i = 2;
            int j = 4;
            strRslt.AppendLine("i = 2  j = 4");

            // 
            // + and - 
            int k = i + j - i;
            strRslt.AppendLine("\ni + j - i  : " + k);

            k = i - j + i;
            strRslt.AppendLine("i - j + i  : " + k);

            // + and +
            k = i + j + i;
            strRslt.AppendLine("\ni + j + i  : " + k);

            k = i + j + i;
            strRslt.AppendLine("i + j + i  : " + k);

            // - and -
            k = i - j - i;
            strRslt.AppendLine("\ni - j - i  : " + k);

            k = i + j + i;
            strRslt.AppendLine("i - j - i  : " + k);

            //============================================================================================================================================================

            // X and /
            k = 3 * 4 / 3;
            strRslt.AppendLine("\n3 X 4 / 3  : " + k);

            k = 3 / j * i;
            strRslt.AppendLine("3 / 4 X 3  : " + k);

            // X and +
            k = i + j * i;
            strRslt.AppendLine("\ni + j X i  : " + k);

            k = i * j + 3;
            strRslt.AppendLine("i X j + 3  : " + k);

            // / and +
            k = i + j / i;
            strRslt.AppendLine("\ni + j / i  : " + k);

            k = j / i + i;
            strRslt.AppendLine("j / i + i  : " + k);
            
            //============================================================================================================================================================
            
            // X and -
            k = i - j * i;
            strRslt.AppendLine("\ni - j X i  : " + k);

            k = i * j - i;
            strRslt.AppendLine("i X j - i  : " + k);

            // / and -
            k = i - j / i;
            strRslt.AppendLine("\ni - j / i  : " + k);

            k = j / i - i;
            strRslt.AppendLine("j / i - i  : " + k);
            
            //============================================================================================================================================================

            // + and %
            int l = 20;
            int m = 3;

            strRslt.AppendLine();
            strRslt.AppendLine("\nl = 10  m = 3 ");

            k = i + l % m;
            strRslt.AppendLine("\ni + l % m  : " + k);

            k = l % m + i;
            strRslt.AppendLine("l % m + i  : " + k);

            // - and %
            k = i - l % m;
            strRslt.AppendLine("\ni - l % m  : " + k);

            k = l % m - i;
            strRslt.AppendLine("l % m - i  : " + k);

            // X and %
            k = i * l % m;
            strRslt.AppendLine("\ni X l % m  : " + k);

            k = l % m * i;
            strRslt.AppendLine("l % m X i  : " + k);

            // / and %
            k = i / l % m;
            strRslt.AppendLine("\ni / l % m  : " + k);

            k = (l % m) / i;
            strRslt.AppendLine("l % m / i  : " + k);
            
            k = 2 + 2 - 6 * 20 % 9 / 3;
            strRslt.AppendLine("\n\n2 + 2 - 6 * 20 % 9 / 3  : " + k);

            MessageBox.Show(strRslt.ToString());
        }

        private void UnaryOperators()
        {
            strRslt.Clear();
            strRslt.AppendLine("Unary Operators : ");

            int i = 2;
            int j = 4;

            int k = i++;
            strRslt.AppendFormat("\n i = {0,-10}   j = {1,-10}  ".PadRight(10), i, j);
            strRslt.AppendFormat("   i++ :  {0,10} " , k);
            
            k = ++i;
            strRslt.AppendFormat("\n i = {0,-10}   j = {1,-10}  ", i, j);
            strRslt.AppendFormat("   ++i :  {0,10} ", k);

            k = ++i + ++j;
            strRslt.AppendFormat("\n i = {0,-10}   j = {1,-10}  ", i, j);
            strRslt.AppendFormat("   ++i  +  ++j :  {0,10} " , k);

            k = i++ + j++;
            strRslt.AppendFormat("\n i = {0,-10}   j = {1,-10}  ", i, j);
            strRslt.AppendFormat("   i++  +  j++ :  {0,10} " , k);

            k = i++ + ++j;
            strRslt.AppendFormat("\n i = {0,-10}   j = {1,-10}  ", i, j);
            strRslt.AppendFormat("   i  ++  +  ++j :  {0,10} " , k);

            strRslt.AppendLine();

            k = ++i * ++j;
            strRslt.AppendFormat("\n i = {0,-10}   j = {1,-10}  ", i, j);
            strRslt.AppendFormat("   ++i  X  ++j :  {0,10} " , k);

            k = ++i / ++j;
            strRslt.AppendFormat("\n i = {0,-10}   j = {1,-10}  ", i, j);
            strRslt.AppendFormat("   ++i  /  ++j :  {0,10} " , k);

            k = ++i % ++j;
            strRslt.AppendFormat("\n i = {0,-10}  j = {1,-10}  ", i, j);
            strRslt.AppendFormat("  ++i  %  ++j :  {0,10} " , k);

            MessageBox.Show(strRslt.ToString());
        }

        private void CompoundOperators()
        {
            strRslt.Clear();
            strRslt.AppendLine("Compound Operators : ");

            int i = 2;
            int j = 4;

            int k = 1;

            //+= (Add EQUALS)
            k += j / i;
            strRslt.AppendFormat("\n i = {0,-5}   j = {1,-5}  ".PadRight(10), i, j);
            strRslt.AppendFormat("   k += j / i :  {0,-5} ", k);

            k = 1;
            k += j * i;
            strRslt.AppendFormat("\n i = {0,-5}   j = {1,-5}  ".PadRight(10), i, j);
            strRslt.AppendFormat("   k += j * i :  {0,-5} ", k);

            k = 1;
            k += j - i;
            strRslt.AppendFormat("\n i = {0,-5}   j = {1,-5}  ".PadRight(10), i, j);
            strRslt.AppendFormat("   k += j - i :  {0,-5} ", k);

            k = 1;
            k += j++ + i++;

            strRslt.AppendFormat("\n i = {0,-5}   j = {1,-5}  ".PadRight(10), i, j);
            strRslt.AppendFormat("   k += j + i :  {0,-5} ", k);

            MessageBox.Show(strRslt.ToString());

            /*            
            -= (Subtract EQUALS)
            *= (Multiply EQUALS) 
            /= (Divide EQUALS) 
            %= Modulo EQUALS
            */
                        /* 
            &= (Bitwise AND EQUALS)
            ^= (Bitwise Exclusive OR EQUALS)
            |= (Bitwise OR EQUALS) 
            */
        }

        private void StringConcatenationOperator()
        {
        }

        private void ComparisonOperators()
        {
            // <, <=, >, >=
            // ==, !=, 
            strRslt.Clear();
            strRslt.AppendLine("Comparision Operators : ");

            int i = 2;
            int j = 4;
            
            strRslt.AppendFormat("\n  i = {0,-10}   j = {1,-10}  \n".PadRight(10), i, j);            

            bool result = j + 1 > i + 4;
            strRslt.AppendFormat("\n   j + 1  >  i + 4 :  {0,-20} ", result);

            result = j + 1 >= i + 3;
            strRslt.AppendFormat("\n   j + 1  >=  i + 3 :  {0,-20} ", result);

            MessageBox.Show(strRslt.ToString());
        }

        private void SetOperators()
        {
        }

        private void BitwiseOperators()
        {
        }

        private void ScopeResolutionOperator()
        {
        }
        
        private void LogicalOperators()
        {
            // 1. &&
            // 2. ||

            strRslt.Clear();
            strRslt.AppendLine("Logica Operators : ");

            int i = 2;
            int j = 4;

            strRslt.AppendFormat("\n  i = {0,-10}   j = {1,-10}  \n".PadRight(10), i, j);

            bool result = i == 2 && ++j == 5 || j == 5;

            strRslt.AppendFormat("\n   i == 2 && ++j == 5 || j == 5 :  {0,-20} ", result);

            MessageBox.Show(strRslt.ToString());
        }

        public void OperatorsPrecedenceTest()
        {
            ScopeResolutionOperator();
            BitwiseOperators();
            SetOperators();            
            StringConcatenationOperator();
            
            LogicalOperators();
            ComparisonOperators();
            CompoundOperators();
            UnaryOperators();
            ArithMaticOperators();
        }
    }
}