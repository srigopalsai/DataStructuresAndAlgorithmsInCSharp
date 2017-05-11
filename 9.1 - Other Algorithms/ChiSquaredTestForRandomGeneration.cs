using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Implement random function using Chi Squared Test.
    Statistics formula
    http://en.wikipedia.org/wiki/Chi-square_test

    A brute force approach: 
    We could randomly selecting items and put them into a new array. 
    We must make sure that we don’t pick the same item twice though by somehow marking the node as dead.

    0. Array                   : [1] [2] [3] [4] [5]
    1. Randomly select 4       : [4] [?] [?] [?] [?]
    2. Mark element as dead    : [1] [2] [3] [X] [5]
    3. Swap dead element       : [X] [2] [3] [1] [5]

    We should prevent the dead element from being picked again.
    So swap it with first element in the array so that we can skip the first index next time (Step 3)

    We can also optimize this by merging the shuffled array and the original array.
Randomly select 4: [4] [2] [3] [1] [5]
Randomly select 3: [4] [3] [2] [1] [5]
This is an easy algorithm to implement iteratively:


    */
    class ChiSquaredTest
    {
        public static void shuffleArray(int[] cards)
        {
            System.Random random = new Random(1);

            int temp, index;
            for (int i = 0; i < cards.Length; i++)
            {
                index = (int)(random.Next(cards.Length-1) * (cards.Length - i)) + i;
                temp = cards[i];
                cards[i] = cards[index];
                cards[index] = temp;
            }
        }
    }
}
