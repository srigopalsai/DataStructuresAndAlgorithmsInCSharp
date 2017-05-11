using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    We may say a radix is a position in a number.
    http://www.bogotobogo.com/Algorithms/radixsort.php

    http://xlinux.nist.gov/dads//HTML/radixsort.html
    https://www.youtube.com/watch?v=E5rPS17Cy-c&list=PLJ7II9mlYqWjUc3_E_AO9JmXVfxMSC-3n&index=25
    Non comaritive http://en.wikipedia.org/wiki/Radix_sort 
    http://stackoverflow.com/questions/14415881/how-to-pair-socks-from-a-pile-efficiently?page=2&tab=oldest#tab-top
    ============================================================================================================================================================================================================================
    */
    class RadixSortDemo
    {
        static void ByteBasedSort(int ByteNo, int[] src, int[] dest)
        {
            int[] count = new int[256];
            int[] index = new int[256];

            for (int i = 0; i < src.Length; i++)
            {
                count[(src[i] >> (ByteNo * 8)) & 0xff]++;
            }

            index[0] = 0;

            for (int i = 1; i < 256; i++)
            {
                index[i] = index[i - 1] + count[i - 1];
            }

            for (int i = 0; i < src.Length; i++)
            {
                dest[index[(src[i] >> (ByteNo * 8)) & 0xff]] = src[i];
                index[(src[i] >> (ByteNo * 8)) & 0xff]++;
            }
        }

        static void RadixSort(int[] array)
        {
            int[] temp = new int[array.Length];
            ByteBasedSort(0, array, temp);
            ByteBasedSort(1, temp, array);
            ByteBasedSort(2, array, temp);
            ByteBasedSort(3, temp, array);
        }

        static void RunRadixSortDemo(string[] args)
        {
            int[] arr = { 24, 56, 24, 85, 90 };
            RadixSort(arr);

            foreach (int a in arr)
            {
                Console.WriteLine(a);
            }
        }
    }
}
