using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Increase_Array
{
    public class Routine
    {
        public static void IncreaseArray(ref string[] values, int increment)
        {
            string[] array = new string[values.Length + increment];

            values.CopyTo(array, 0);

            values = array;
        }
    }

    public class Program
    {
        private static void Show(string[] ns)
        {
            foreach (string name in ns)
                Console.WriteLine("Name: " + name);
        }

        public static void RunDemo(string[] args)
        {
            string[] names = new string[5];
            Console.WriteLine("Length of names = " + names.Length.ToString());
            Console.WriteLine("");

            names[0] = "Alexander";
            names[1] = "Paulette";
            names[2] = "Gertrude";
            names[3] = "Hélène";
            names[4] = "Patricia";

            Show(names);
            Routine.IncreaseArray(ref names, 5);
            Console.WriteLine("\nLength of names = " + names.Length.ToString());
            Console.WriteLine("");
            
            names[5] = "Alain";
            names[6] = "Gerogette";

            Show(names);
            Console.WriteLine("");
        }
    }
}
/*
  
This would produce:
Length of names = 5

Name: Alexander
Name: Paulette
Name: Gertrude
Name: Hélène
Name: Patricia

Length of names = 10

Name: Alexander
Name: Paulette
Name: Gertrude
Name: Hélène
Name: Patricia
Name: Alain
Name: Gerogette
Name:
Name:
Name:

Press any key to continue . . .
*/