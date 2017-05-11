using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*

    Branch predictor is the part of a processor that determines whether a conditional branch (jump) in the instruction flow of a program is likely to be taken or not. 

    Branch Prediction:

    Predicting the outcome of a branch.

    Why BP?

    1. Increases the number of  instructions available for the scheduler to issue.  
    2. Increases instruction level parallelism (ILP).
    3. Allows useful work to be completed while waiting for the branch to resolve.

    Direction:

        1. Strongly not taken
        2. Weakly not taken
        3. Weakly taken
        4. Strongly taken
    
    =================================================================================================================================================================================================

    There are various types of branches seen in (assembly) code. 
    
    1. Un-Conditional Branches:

    #0 ADD          c, a, b
    #1 BRANCH       #4
    #2 ADD          b, a, c
    #3 MULTIPLY     e, b, a
    #4 ADD          d, a, b

    In this example, the branch instruction would cause the processor to skip instructions #2 and #3 and go directly to #4. 
    A typical modern processor works on multiple instructions at once in its pipeline. 
    This typically means that the processor will start working on the next instruction before the previous one has finished. 
    In the above example, the processor would begin working on instruction #2 before instruction #1 is finished. However, when instruction #1 finishes, the processor realizes it should have skipped #2 and discards the result. 
    This is a waste of both potential performance and power.

    In order to avoid this, the processor keeps a history of past branches (see article linked by one of the above posters) and makes a guess as to whether a future branch will be taken or not. T
    he more accurate this branch prediction is, the less number of cycles the processor wastes processing instructions which were never meant to execute.

    Branches come in many forms. The above example is a very simple type of branch called an unconditional branch. It is called that because the branch will always be taken. 
    This is the easiest type of branch to deal with because the processor only has to decode (i.e. recognize that it is a branch instruction, which can take anywhere form 1-4 cycles if not more) before it knows what to do.

    =================================================================================================================================================================================================

    2. Conditional branches:

    #0 COMPARE      a, b
    #1 BEQ          #4
    #2 ADD          b, a, c
    #3 MULTIPLY     e, b, a
    #4 ADD          d, a, b

    In the above example, BEQ stands for branch-if-equal. The COMPARE instruction compares the values of the variables a and b and determines if they are equal. 
    The branch instruction will look at the result of the last comparison made and jump to instruction #4 only if a and b were equal.

    This is difficult for a processor to resolve because it must wait for instruction #0 to finish executing before knowing whether to branch or not. 
    In this case, the processor again makes an educated guess based on branch history. But this time, it won't know the result until instruction #0 finishes. 
    If it starts working on one instruction every cycle, then it could have started processing a lot of instructions before it knows that it made a mistake.

    =================================================================================================================================================================================================

    3. Unknown target:

    #0 COMPARE      a, b
    #1 ADD          c, a, b
    #2 BEQ          c
    #3 ADD          b, a, c
    #4 MULTIPLY     e, b, a
    #5 ADD          d, a, b

    In this example, not only does the processor not know whether to jump (branch) when it starts processing instruction #2, it also doesn't know where to jump to as the variable c has not yet been determined; instruction #1 needs to finish first.
    For this type of branch, processors usually contain something called a branch target buffer. 
    This can be a multi-entry buffer in which the processor stores past addresses that have been jumped to. Each time a branch instruction (say, #2) is executed, the processor stores the target (the value of c) that it jumped to. 
    Next time the same instruction (#2, for instance in a loop) is executed, it uses the value in the branch target buffer.

    All of this is guess-work by the processor. If it guesses right, it can execute a stream of instructions uninterrupted. 
    If it guesses wrong, it has spent a lot of time executing instructions that it shouldn't have and will then have to flush those instructions and start over on the correct ones. 
    In today's microprocessors, pipeline stages (i.e. the number of cycles it takes for a processor to process an instruction from start to finish) range anywhere from 8 stages (ARM Cortex A9) to 31 stages (Pentium 4 at 65nm).
    Being able to predict branches correctly is one of the most critical functions of a processor's performance as well as power consumption.

    =================================================================================================================================================================================================    
    
    Some lower detailed notes:

    Branch Prediction Strategies:
    
        1. Static:
            Decided before runtime
        E.g.
            Always-Not Taken
            Always-Taken
            Backwards Taken, 
            Forward Not Taken (BTFNT)
            Profile-driven prediction

        2. Dynamic:
            Prediction decisions may change during the execution of the program

    Target Address:

        1. PC+Offset (Taken)
        2. PC+4      (Not-Taken)


    Target Address Predictors:

        1. Branch Target Address Cache (BTAC) 
        2. Branch Target Buffer (BTB)

    =================================================================================================================================================================================================        
    
    What happens when a branch is predicted?

        On MisPredict:
            No speculative state may commit
            Squash instructions in the pipeline
            Must not allow stores in the pipeline to occur
                Cannot allow stores which would not have happened to commit
            Need to handle exceptions appropriately

    Bimodal Prediction: Refer diagram in wiki.

    Correlation:

    B1: if (x)
		...
    B2: if (y)
		...
	   z=x&&y
    B3: if (z)
		...

    B3 can be predicted with 100% accuracy based on the outcomes of B1 and B2
    
    =================================================================================================================================================================================================    

    Two-Level Prediction

    Uses two levels of information to make a direction prediction
        Branch History Table (BHT)
        PHT
    Captures patterned behavior of branches
        Groups of branches are correlated
        Particular branches have particular behavior
    Two-level Predictor Classification

    Yeh and Patt 3-letter naming scheme
        Type of history collected

        G (global), 
        P (per branch), 
        S (per set)
        M (merge?)	
            added by Skadron, Martonosi, Clark
        PHT type
            A (adaptive), S (static)
        PHT organization
            g (global), p (per branch), s (per set)

    Hybrid Prediction:

    Two or more predictor components combined
    Different branches benefit from different types of history

    Special Branches:

    Procedure calls and returns
        Calls are always taken 
        Return address almost always known 
    Return Address Stack (RAS)
        On a procedure call, push the address of the instruction after the call onto the stack

    Issues Affecting Accurate Branch Prediction


    Pentium III

    Dynamic branch prediction
        512-entry BTB predicts direction and target, 4-bit history used with PC to derive direction
        Static branch predictor for BTB misses
    Return Address Stack (RAS), 4/8 entries

    Branch Penalties: 
        Not Taken: No penalty
        Correctly predicted taken: 1 cycle
        Mispredicted: At least 9 cycles, as many as 26, average 10-15 cycles

    =================================================================================================================================================================================================    

    Branch target predictor:

    http://en.wikipedia.org/wiki/Branch_predictor
    http://en.wikipedia.org/wiki/Conditional_branch
    http://www.quora.com/What-is-branch-prediction-in-the-context-of-CPUs
    
    Branches:
    Instructions which can alter the flow of instruction execution in a program

    Types of Branches

    Direct:
	    Conditional	    :	if-then-else, for/while loops
	    Un-Conditional	: 	Procedure calls, Goto
    
    InDirect:
	    Un-Conditional	    :	return
				            virtual functional lookup
				            functiona pointers

    Techniques:

        Stalling
        Branch Delay Slots
        Predication

    =================================================================================================================================================================================================    
    
    */
    partial class OtherAlgorithmSamples 
    {
        public static void BranchPredictionDemo()
        {
            HashSet<int> tempArr = new HashSet<int>();
/*
            Random randomObj = new Random(Guid.NewGuid().GetHashCode());
            for (int lpCnt = 0; lpCnt < 10; lpCnt++)
            {
                int randomNumber = randomObj.Next(0, 100);
                Console.WriteLine(randomNumber);
            }

            //This code generates numbers between 1 - 100 and then takes 10 of them.
            var result = Enumerable.Range(1, 101).OrderBy(g => Guid.NewGuid()).Take(10).ToArray();
*/
            // Note Below Next wont ensure returns unique values.
            Random rdObj = new Random(1);
            
            int MaxNums = 100000;
            int MaxHalfLen = MaxNums / 2;
            int randNum = 0;

            for (int lpCnt = 0; lpCnt < MaxNums; )
            {
                randNum = rdObj.Next(MaxNums);
             
                if (!tempArr.Contains(randNum))
                {
                    tempArr.Add(randNum);
                    lpCnt++;
                }
               
            }

            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("Sai", "Sri");
            nvc.Set("Sai", "SaiSri");
            
            Stopwatch sw = new Stopwatch();
            sw.Start();

            ArrayList al = new ArrayList();
            al.Add("a");

            foreach(int num in tempArr)
            {
                if (num >= MaxHalfLen)
                {
                    tempArr.Select(a => a);
//                    tempArr= tempArr[lpCnt] * 1; 
                }
            }

            sw.Stop();
            string str = "Before Sort : ElapsedTicks " + sw.ElapsedTicks.ToString();
                
            var tempArrColl =tempArr.OrderBy(a => a);

            sw.Restart();

            foreach (int num in tempArrColl)
            {
                if (num >= MaxHalfLen)
                {
                    tempArr.Select(a => a);
                    //                    tempArr= tempArr[lpCnt] * 1; 
                }
            }

            sw.Stop();
            str += "\nAfter Sort   : ElapsedTicks " + sw.ElapsedTicks.ToString();

            MessageBox.Show(str);
        }
    }
}