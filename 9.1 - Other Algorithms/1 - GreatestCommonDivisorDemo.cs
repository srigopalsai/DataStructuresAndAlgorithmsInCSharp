using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public static class Exercise
    {
        public static int GreatestCommonDivisor(int a, int b)
        {
            int remainder;

            while (b != 0)
            {
                remainder = a % b;
                a = b;
                b = remainder;
            }

            return a;
        }
    }

    public class GreatestCommonDivisorDemo
    {
        public static int RunDemo()
        {
            int x, y;

            Console.WriteLine("This program allows calculating the greatest common divisor");
            Console.Write("Enter Value 1: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Enter Value 2: ");
            y = int.Parse(Console.ReadLine());

            Console.WriteLine("\nThe Greatest Common Divisor of {0} and {1} is {2}.", x, y, Exercise.GreatestCommonDivisor(x, y));

            return 0;
        }
    }
}
/*
Here is an example of running the program:
This program allows calculating 
the greatest common divisor
Enter Value 1: 15
Enter Value 2: 3

The Greatest Common Divisor of 15 and 3 is 3.
Press any key to continue . . .

Here is another example of running the program:
This program allows calculating 
the greatest common divisor
Enter Value 1: 64
Enter Value 2: 12

The Greatest Common Divisor of 64 and 12 is 4.
Press any key to continue . . .
  
Here is one more example of running the program:
This program allows calculating the greatest common divisor
Enter Value 1: 48024
Enter Value 2: 128

The Greatest Common Divisor of 48024 and 128 is 8.
Press any key to continue . . .
*/