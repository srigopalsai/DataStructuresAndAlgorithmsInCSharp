using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class RecursionSamples
    {
        //======================================================================================================================================================================================================================
        bool RecurValCarryForward(int lpCnt)
        {
            if (lpCnt >= 0)
            {
                if (lpCnt == 3)
                    return false;

                return RecurValCarryForward(++lpCnt);
            }
            return true;
        }
        
        //3. Direct Recursion: Recursive Call from its body itself.=============================================================================================================================================================
        int fooDirect(int x)
        {
            if (x <= 0)
            {
                return x;
            }

            return fooDirect(x - 1);
        }

        //4. Indirect Recursion: A recursive call from another function.========================================================================================================================================================
        int foo(int x)
        {
            if (x <= 0)
            {
                return x;
            }

            return fooIndirect(x);
        }
        int fooIndirect(int y)
        {
            return foo(y - 1);
        }

        //5. Mutual Recursion: Similar to Indirect. 2 functions calls mutually each other=======================================================================================================================================
        // E.g. http://www.technicalinterviewquestions.net/2009/03/print-2d-array-matrix-spiral-order.html
        int fooMutual1(int x)
        {
            if (x <= 0)
            {
                return x;
            }
            return fooMutual2(x);
        }

        //======================================================================================================================================================================================================================
        int fooMutual2(int y)
        {
            return fooMutual1(y - 1);
        }

        //======================================================================================================================================================================================================================
        //6. Linear Recursion: No pending operation involves Another recursive call to the function.

        //======================================================================================================================================================================================================================
        //7. Non-Linear (Tree) Recursion: When the pending operation does involve another recursive call to the function.
        int fib(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }
            return fib(n - 1) + fib(n - 2);
        }

        //======================================================================================================================================================================================================================
        //8 Structural Recursion: Recursive algorithms are particularly appropriate when the underlying problem or the data to be treated are defined in recursive terms
    }
}
