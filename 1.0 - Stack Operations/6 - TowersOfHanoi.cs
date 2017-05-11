using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    http://www.sanfoundry.com/java-program-implement-solve-tower-of-hanoi-using-stacks/
    https://www.youtube.com/watch?v=oZ0MP5euLQ0
    Time Complexity 2n ( Exponential Time)
    */
    partial class StackOperations
    {
        static string result= string.Empty;
        //Witout Stacks, using recursion.
        public static void TowersOfHanoiMoveWithOutStack(int n, int from, int to, int via)
        {
            Debug.WriteLine(n);
            if (n == 1)
            {
                //Debug.WriteLine("Move disk from pole " + from + " to pole " + to);
                result += "\nMove disk from pole " + from + " to pole " + to;
            }
            else
            {
                TowersOfHanoiMoveWithOutStack(n - 1, from, via, to);
                TowersOfHanoiMoveWithOutStack(1    , from, to, via);
                TowersOfHanoiMoveWithOutStack(n - 1, via, to, from);
            }
        }
        public static void RunTowersOfHanoiMoveWithOutStack()
        {
            Debug.Flush();
            result = "Towers of Hanoi Operations\n";
            TowersOfHanoiMoveWithOutStack(4, 1, 2, 3);
            MessageBox.Show(result);
        }
    }
}
