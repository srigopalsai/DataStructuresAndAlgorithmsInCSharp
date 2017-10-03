using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*Given an array, you should start at index 0, and you can jump 
  * from the current index to a max of " current index + arr[current index]
  * and make it out of the array at the other end in minimum number of hops.
  */
    public partial class DynamicProgrammingSamples
    {
        public static String GetHopsGuide(int[] nums)
        {
            if (nums == null || nums.Length == 0 || nums[0] == 0)
                return "failure";

            int[] hopsLkUp = new int[nums.Length + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length + 1; j++)
                {
                    int alternatePath = 0;

                    if (j <= i + nums[i])
                    {
                        alternatePath = j - i;
                        hopsLkUp[j] = Math.Max(hopsLkUp[j], alternatePath);
                    }
                    else
                        break;
                }
            }

            if (hopsLkUp[hopsLkUp.Length - 1] > 0)
            {
                String path = "out";

                for (int i = hopsLkUp.Length - 1; i > 0; )
                {
                    i -= hopsLkUp[i];
                    path = i + " " + path;
                }

                return path;
            }
            else
            {
                return "failure";
            }
        }

        static void RunDemo(string[] args)
        {
           
            int[] arr = { 5, 6, 0, 4, 2, 4, 1, 0, 0, 4 };
            //int[] arr1 = { 2,1,2,4,0,0,0};
            //int[] arr1 = {  };

            String hopsguide = null;

            try
            {
                hopsguide = GetHopsGuide(arr);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(hopsguide);
        }
    }
}
