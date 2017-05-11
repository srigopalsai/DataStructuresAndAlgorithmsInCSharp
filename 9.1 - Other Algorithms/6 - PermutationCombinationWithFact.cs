using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class PermutationCombinationWithFact
    {
        private long Factorial(long number)
        {
            if (number <= 1)
                return 1;
            return number * Factorial(number - 1);
        }

        private long Permutation(long n, long r)
        {
            if (r == 0 || n == 0)
            {
                return 0;
            }
            if ((r >= 0) && (r <= n))
            {
                return Factorial(n) / Factorial(n - r);
            }
            else
            {
                return 0;
            }
        }
        private long Combinatorial(long a, long b)
        {
            if (a <= 1)
            {
                return 1;
            }
            return Factorial(a) / 
                    ((Factorial(b) * Factorial(a - b)));
        }

        public static int PermutationCombinationWithFactDemo()
        {
            long factor = 0;
            long second = 0;

            PermutationCombinationWithFact exo = new PermutationCombinationWithFact();

            Console.Write("To calculate a factorial, enter a (small positive) number: ");
            factor = long.Parse(Console.ReadLine());
            
            Console.Write("To calculate a permutation and the combination, enter a second (small positive) number: ");
            second = long.Parse(Console.ReadLine());

            Console.WriteLine("Factorial:   F({0}) = {1}", factor, exo.Factorial(factor));
            Console.WriteLine("Permutation: P({0}, {1}) = {2}", factor, second, exo.Permutation(factor, second));
            Console.WriteLine("Combination: C({0}, {1}) = {2}", factor, second, exo.Combinatorial(factor, second));

            return 0;
        }
    }
}