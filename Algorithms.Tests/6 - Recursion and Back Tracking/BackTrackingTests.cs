using System;
using DataStructuresAndAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class BackTrackingTests
    {
        BackTrackingProblems backTrackingProblems = new BackTrackingProblems();

        [TestMethod]
        public void KnightsTourBackTrackingTest()
        {
            bool result = backTrackingProblems.KnightsTourBackTracking();

            // Start from 0,0 and explore all tours using KnightsTourBackTrackingHelper()
            if (result == true)
            {
                Console.WriteLine("Knight tour exist");
            }
            else
            {
                Console.WriteLine("Knight tour doesn't exist");
            }
        }

        [TestMethod]
        public void SearchWordInMatrixTest()
        {
            char[,] matrix = {  { 't', 'z', 'x', 'c', 'd' },
                                { 'a', 'h', 'n', 'z', 'x' }, 
                                { 'h', 'w', 'o', 'i', 'o' },
                                { 'o', 'r', 'n', 'r', 'n' }, 
                                { 'a', 'b', 'r', 'i', 'n' } };

            string word = "horizon";
            bool result = backTrackingProblems.SearchWordInMatrix(matrix, "horizon");

            if (result == true)
            {
                Console.WriteLine("Given Word " + word + " found in the given matrix ");
            }
            else
            {
                Console.WriteLine("Given Word " + word + " not found in the given matrix ");
            }
        }
    }
}
