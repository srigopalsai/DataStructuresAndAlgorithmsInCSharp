using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Tests
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        public void DisplayOutput(string message)
        {
            Debug.WriteLine(message);
        }

        public int[] ToArray(string message)
        {
            string[] delim = { " " };

            string[] items = message.Split(delim, StringSplitOptions.RemoveEmptyEntries);

            int[] array = new int[items.Length];

            for (int indx = 0; indx < items.Length; indx++)
            {
                if (string.IsNullOrWhiteSpace(items[indx]))
                    continue;

                array[indx] = Convert.ToInt32(items[indx]);
            }

            return array;
        }

        public bool AssertAreArraysEqual(int[] array1, int[] array2)
        {
            bool hasFailed = false;

            for (int indx = 0; indx < array1.Length; indx++)
            {
                if (array1[indx] != array2[indx])
                {
                    hasFailed = true;
                    Assert.Fail("Values are not matching Val 1 " + array1[indx] + " Val 2 " + array2[indx]);
                }
            }

            return hasFailed;
        }

    }
}
