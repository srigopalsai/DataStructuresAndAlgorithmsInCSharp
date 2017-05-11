using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class RecursionSamples
    {
        /*
        ========================================================================================================================================================================================================================

        1. Tail Recursion:
        
        All recursive calls are tail calls and hence do not build up any deferred operations.
        
        Doesn't Maintains Call Stack.
         
        With a compiler or interpreter that treats tail-recursive calls as jumps rather than function calls, a tail-recursive function such as below TailRecursionCalcGCD will execute using constant space.
        
        Thus the program is essentially iterative, equivalent to using imperative language control structures like the "for" and "while" loops.
        
        Also, No logic to be performed after the recursion call (generally last statement with no logic). Can re use the existing 1 stack memory.

        INPUT: Integers x, y such that x >= y and y > 0

        ========================================================================================================================================================================================================================
        */
        int TailRecursionCalcGCD(int x, int y)
        {
            if (y == 0)
            {
                return x;
            }
            else
            {
                return TailRecursionCalcGCD(y, x % y);
            }
        }
    }
}
