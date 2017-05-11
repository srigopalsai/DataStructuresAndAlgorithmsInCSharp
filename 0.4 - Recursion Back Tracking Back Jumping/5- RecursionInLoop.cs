using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Stack Overflow Recursion Function :

    1. Goes infinite if given number is >= 1 as every recursive call is not chaning the number to break at some moment. 
    public void Recursions2InLoop(int num)
    {
        for (int n = num; n >= 1; n--)
        {
            Debug.WriteLine(num);
            Recursions2InLoop(num);
        }
    }
    */

    partial class RecursionSamples
    {
        public void RecursionInLoopTest()
        {
            Debug.WriteLine("Quadratic Time N^2 Demo :");
            RecursionInLoopQadratic(3);

            //Debug.WriteLine("N^4 Time Demo :");
            //RecursionInLoopN4(3);

            Debug.WriteLine("4^N Exponential Time Demo :");
           
            //NoOfSteps = 0;
            //RecursionInLoop4N(1);
            //Debug.WriteLine("No Of Steps :" + NoOfSteps);

            //NoOfSteps = 0;
            //RecursionInLoop4N(1);
            //Debug.WriteLine("No Of Steps :" + NoOfSteps);

            //NoOfSteps = 0;
            //Recursions2InLoop(1);
            //Debug.WriteLine("No Of Steps :" + NoOfSteps);
        }

        // Quadratic Time - N^2
        public void RecursionInLoopQadratic(int num)
        {
            for (int n = num; n >= 1; n--)
            {
                Debug.WriteLine(num);
                RecursionInLoopQadratic(num - 1);
            }            
        }
 
        // N^4
        public void RecursionInLoopN4(int num)
        {
            NoOfSteps++;
            for (int n1 = num; n1 >= 1; n1--)
            {
                for (int n = num; n >= 1; n--)
                {
                    Debug.WriteLine(num);
                    RecursionInLoopN4(num - 1);
                }
            }
        }
        
        /*
        
        The function is best imagined to be solving a complex problem by divide-and-conquer. 
        It reduces an n-sized problem to four instances of an (n-1)-sized problem, recursing until the subproblem is trivial (size 0). 
        
        A problem of size 1 is 1 + 4                       = 5 Steps (entry-point call + 4 trivial subproblems).
        A problem of size 2 in 1 + 4 * ( 1 + 4 )           = 21 steps, and so on.
        A problem of size 3 in 1 + 4 * ( 1 + 4 * (1 + 4) ) = 85 steps, and so on.
        
        */

        static int NoOfSteps = 0;
        public void RecursionInLoop4N(int num)
        {
            ++NoOfSteps;

            if (num == 0)
            {
                return;
            }

            for (int n = 3; n >= 0; n--)
            {
                Debug.WriteLine(num);
                RecursionInLoop4N(num - 1);
            }
        }

        public void Recursions2InLoop(int num)
        {
            ++NoOfSteps;
            
            Debug.WriteLine("Current Value is : " + num);

            for (int n = num; n >= 1; n--)
            {
                Recursions2InLoop(num - 1);
//                Recursions2InLoop(num);
            }
        }
    }
}