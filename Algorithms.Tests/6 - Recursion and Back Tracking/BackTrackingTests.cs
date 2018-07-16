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
            backTrackingProblems.KnightsTourBackTracking();
        }
    }
}
