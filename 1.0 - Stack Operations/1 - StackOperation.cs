using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    // Implement Stack using Queue.
    // 225 Easy https://leetcode.com/problems/implement-stack-using-queues
    public class MyStack
    {
        Queue<int> queue = new Queue<int>();

        public void Push(int val)
        {
            queue.Enqueue(val);

            for (int indx = 1; indx < queue.Count(); indx++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        public int Pop()
        {
            return queue.Dequeue();
        }

        public int Top()
        {
            return queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count() == 0;
        }
    }

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