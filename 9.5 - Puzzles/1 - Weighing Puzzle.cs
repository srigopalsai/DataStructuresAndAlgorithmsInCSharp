using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    You are given n(<=8) weights, w1,w2, · · · ,wn. 
    Find all distinct weight measurements that you can make using a common balance and the given weights. 
    For example, assume that you are given weights of 1, 3, and 5 units. 
    You can weigh all measures from 1 to 9 units as:

    •1=1 2=3−1
    •3=3 4=3+1
    •5=5 6=5+1
    •7=5+3−1 8=5+3
    •9=5+3+1

    You can subtract a specific weight you have, by adding it along with item to be measured.
    Your input will contain the number of weights you have, followed by the weights themselves.
    You need to output all the possible weights you can measure in the increasing order.
    You should not repeat any measures.

    Input: First Line contains N(number of distinct weights)(N<=8). 
    Next line will have N distinct weights separated by space.
 
    Output: list of distinct weights possible in increasing order followed by ‘\n’.
    http://analgorithmist.blogspot.com/2012/10/weighing-puzzle.html
    */
    class _1___Weighing_Puzzle
    {
        int[] binary;

        public void WeightTest()
        {
            int n;
            n = Console.Read();
            int[] weight = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                weight[i]=  Console.Read();
                sum += weight[i]; /* Calculated maximum sum of weights here */
            }

            int index = 2 * n;
            binary = new int[index];

            /*      An array of twice the number of weights, half the bits indicate presence or absence of weight
                    another half bits indicate whether the weight is to be added or subtracted 
            */

            int max = (int)Math.Pow(2, index) - 1; /* Maximum number of combinations of weights and +- signs */

            HashSet<int> s = new HashSet<int>();

            for (int i = max; i > 0; i--)
            {
                generateBinary(i, index);

                /*              For all weights from max to 1, generate binary sequence
                                First bit for + or - sign; if 1: +, if 0: -
                                Next bit will be set fot the weight; 1: included, 0: not included
                */
                int localsum = 0;
                for (int j = 1; j < index; j += 2)
                {
                    if (binary[j] == 1) /*If the bit is 1, I have to include this weight */
                    {
                        if (binary[j - 1] == 1) /* If the previous bit is 1, I have to add the weight */
                            localsum += weight[j / 2];
                        else
                            localsum -= weight[j / 2]; /* If the previous bit is 0, I have to subtract the weight */
                    }
                }
                if (localsum > 0)
                {
                    s.Add(localsum); /* If sum is positive, insert it into the set */
                }
            }

            foreach (int it in s)
            {
                Console.Write(it + " ");
            }
            Console.WriteLine();

        }

        void generateBinary(int n, int bits)
        {
            for (int i = bits - 1; i >= 0; i--)
            {
                int k = n >> i;

                if (Convert.ToBoolean(k & 1))
                    binary[bits - i - 1] = 1;
                else
                    binary[bits - i - 1] = 0;
            }
        }
    }
}
