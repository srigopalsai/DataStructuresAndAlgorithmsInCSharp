using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    //Computational complexity:  computing a topological ordering of a directed acyclic graph is NC2; that is, it can be computed in O(log2 n) time on a parallel computer using a polynomial number O(nk) of processors, for some constant k
    //http://en.wikipedia.org/wiki/Topological_sorting
    // Aim :  To print the order in which jobs should be executed.
    class Job
    {
        public String JobName;
        public int NumberOfDependents;
        public List<Job> DependsOn;

        public Job(String name)
        {
            JobName = name;
            NumberOfDependents = 0;
            DependsOn = new List<Job>();
        }
    }

    class JobsGraph
    {
        HashSet<Job> Jobs = null;

        public JobsGraph()
        {
            Jobs = new HashSet<Job>();
        }

        public void AddEdge(Job S, Job D)
        {
            if (!Jobs.Contains(S)) Jobs.Add(S);
            if (!Jobs.Contains(D)) Jobs.Add(D);
            S.DependsOn.Add(D);
            D.NumberOfDependents++;
        }

        public void PrintJobExecutionOrder()
        {
            List<Job> TSO = new List<Job>();
            Queue<Job> Q = new Queue<Job>();
            Job job = null;

            foreach (Job j in Jobs)
            {
                if (j.NumberOfDependents == 0) Q.Enqueue(j);
            }

            while (Q.Count > 0)
            {
                job = Q.Dequeue();
                TSO.Add(job);
                foreach (Job j in job.DependsOn)
                {
                    j.NumberOfDependents--;
                    if (j.NumberOfDependents == 0)
                        Q.Enqueue(j);
                }
            }

            if (TSO.Count != Jobs.Count)
                Console.WriteLine("There exists atleast one cycle in the Job graph");
            else
            {
                for (int i = TSO.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(TSO[i].JobName);
                }
            }
        }
    }

    public class TopologicalSort
    {
        static void RunDemo(string[] args)
        {
            JobsGraph JG = new JobsGraph();

            Job j1 = new Job("1");
            Job j2 = new Job("2");
            Job j3 = new Job("3");
            Job j4 = new Job("4");
            Job j5 = new Job("5");
            Job j6 = new Job("6");
            Job j7 = new Job("7");
            Job j8 = new Job("8");
            Job j9 = new Job("9");
            Job j10 = new Job("10");
            Job j11 = new Job("11");

            JG.AddEdge(j7, j8);
            JG.AddEdge(j7, j11);
            JG.AddEdge(j5, j11);
            JG.AddEdge(j3, j8);
            JG.AddEdge(j3, j10);
            JG.AddEdge(j8, j9);
            JG.AddEdge(j11, j2);
            JG.AddEdge(j11, j9);
            JG.AddEdge(j11, j10);

            JG.PrintJobExecutionOrder();
        }
    }
}
