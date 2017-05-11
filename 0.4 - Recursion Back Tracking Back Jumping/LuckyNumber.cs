using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*

    Lucky numbers are subset of integers.

    Take the set of integers
    1,2,3,4,5,6,7,8,9,10,11,12,14,15,16,17,18,19,……

    First, delete every second number, we get following reduced set.
    1,3,5,7,9,11,13,15,17,19,…………

    Now, delete every third number, we get
    1, 3, 7, 9, 13, 15, 19,….….

    Continue this process indefinitely……
    Any number that does NOT get deleted due to above process is called “lucky”.

    Therefore, set of lucky numbers is 1, 3, 7, 13,………

    Is Given number Lucky?

    1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,15,17,18,19,20,21,……
    1,3,5,7,9,11,13,15,17,19,…..
    1,3,7,9,13,15,19,……….
    1,3,7,13,15,19,………
    1,3,7,13,19,………
    

    In next step every 6th number in sequence should be deleted. 
    But 19 will not be deleted after this step because position of 19 is 5th after this step. 
    Therefore, 19 is lucky. 

    http://www.geeksforgeeks.org/lucky-numbers/
    */

    class LuckyNumber
    {
        // Returns 1 if next_position is a lucky no. ohterwise returns 0
        bool IsLuckyNumberUsingRecursion(int next_position)
        {
            int counter = 2;

            if (counter > next_position)
            {
                return true;
            }

            if (next_position % counter == 0)
            {
                return false;
            }

            /*calculate next position of input no*/
            next_position -= next_position / counter;

            counter++;
            return IsLuckyNumberUsingRecursion(next_position);
        }

        bool IsLuckyNumberUsingIteration(int next_position)
        {
            int counter = 2;

            while (true)
            {
                if (counter > next_position)
                {
                    return true;
                }

                if (next_position % counter == 0)
                {
                    return false;
                }

                /*calculate next position of input no*/
                next_position -= next_position / counter;

                counter++;
            }
        }
    }
}
