using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class JobProcessing
    {
        private static List<string> jobs = new List<string>(16);
        private static int nextJobPos = 0;

        public static void AddJob(string jobName)
        {
            jobs.Add(jobName);
        }

        public static string GetNextJob()
        {
            if (nextJobPos > jobs.Count - 1)
                return "NO JOBS IN BUFFER";
            else
            {
                string jobName = jobs[nextJobPos];
                nextJobPos++;
                return jobName;
            }
        }

        public static void Main1()
        {
            AddJob("1");
            AddJob("2");
            Console.WriteLine(GetNextJob());
            AddJob("3");
            Console.WriteLine(GetNextJob());
            Console.WriteLine(GetNextJob());
            Console.WriteLine(GetNextJob());
            Console.WriteLine(GetNextJob());
            AddJob("4");
            AddJob("5");
            Console.WriteLine(GetNextJob());
        }
    }
}