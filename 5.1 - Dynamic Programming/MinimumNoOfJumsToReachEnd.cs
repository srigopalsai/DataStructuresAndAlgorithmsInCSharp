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
        public static String GetHopsGuide(int[] arr)
        {
            if (arr == null || arr.Length == 0 || arr[0] == 0) return "failure";

            int[] hopsGuide = new int[arr.Length + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length + 1; j++)
                {
                    int alternatePath = 0;
                    if (j <= i + arr[i])
                    {
                        alternatePath = j - i;
                        hopsGuide[j] = Math.Max(hopsGuide[j], alternatePath);
                    }
                    else
                        break;

                }
            }

            if (hopsGuide[hopsGuide.Length - 1] > 0)
            {
                String path = "out";

                for (int i = hopsGuide.Length - 1; i > 0; )
                {
                    i -= hopsGuide[i];
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
