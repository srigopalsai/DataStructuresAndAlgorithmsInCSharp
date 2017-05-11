using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    partial class RecursionSamples
    {
        /*
        2. Augmenting Recursion: 
        
        Logic to be performed after the recursion call.

        1. Maintains Call Stack.
        2. Factorial function (also below) is not tail-recursive. 
        3. Because its recursive call is not in tail position, it builds up deferred multiplication operations that must be performed after the final recursive call completes. 

    
        */
        int AugmentingRecursionCalcFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * AugmentingRecursionCalcFactorial(n - 1);
            }
        }
    }
}