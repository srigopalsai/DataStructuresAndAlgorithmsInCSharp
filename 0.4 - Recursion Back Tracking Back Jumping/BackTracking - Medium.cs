using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class BackTrackingProblems
    {
        // https://www.geeksforgeeks.org/backtracking-algorithms/#standard

        // Knight’s tour :
        // Play this game for better understanding http://www.maths-resources.com/knights/
        /* Given 8 X 8 chess board with -1 default values, return the below traverse board
              0  59  38  33  30  17   8  63
             37  34  31  60   9  62  29  16
             58   1  36  39  32  27  18   7
             35  48  41  26  61  10  15  28
             42  57   2  49  40  23   6  19
             47  50  45  54  25  20  11  14
             56  43  52   3  22  13  24   5
             51  46  55  44  53   4  21  12
         */

        public bool IsSafe(int rIndx, int cIndx, int[,] visitMatrix)
        {
            return (rIndx >= 0 && rIndx < visitMatrix.GetLength(0) &&
                    cIndx >= 0 && cIndx < visitMatrix.GetLength(1) && visitMatrix[rIndx, cIndx] == -1);
        }

        public void DisplaySolution(int[,] visitMatrix)
        {
            for (int rIndx = 0; rIndx < visitMatrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < visitMatrix.GetLength(1); cIndx++)
                {
                    Console.Write(visitMatrix[rIndx, cIndx] + " ");
                }

                Console.WriteLine();
            }
        }

        // Returns false if no complete tour is possible, otherwise return true and prints the tour. 
        // Note that there may be more than one solutions, this function prints one of the feasible solutions.

        public bool KnightsTourBackTracking()
        {
            int[,] chessBoard = new int[8, 8];

            for (int rIndx = 0; rIndx < chessBoard.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < chessBoard.GetLength(1); cIndx++)
                {
                    chessBoard[rIndx, cIndx] = -1;
                }
            }

            // Since the Knight is initially at the first block
            chessBoard[0, 0] = 0;

            // Start from 0,0 and explore all tours using KnightsTourBackTrackingHelper()
            if (!KnightsTourBackTrackingHelper(chessBoard, 0, 0, 1))
            {
                Console.WriteLine("Solution does not exist");
                return false;
            }
            else
            {
                DisplaySolution(chessBoard);
            }

            return true;
        }

        int[] rMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] cMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        // A recursive utility function to solve Knight Tour problem
        private bool KnightsTourBackTrackingHelper(int[,] chessBoard, int curRIndx, int curCIndx, int visitPos )
        {
            if (visitPos == chessBoard.GetLength(0) * chessBoard.GetLength(1))
            {
                return true;
            }

            int nextRIndx;
            int nextCIndx;

            // Try all next moves from the current coordinate x, y
            for (int nextIndx = 0; nextIndx < 8; nextIndx++)
            {
                nextRIndx = curRIndx + rMove[nextIndx];
                nextCIndx = curCIndx + cMove[nextIndx];

                if (IsSafe(nextRIndx, nextCIndx, chessBoard) == false)
                {
                    continue;
                }

                chessBoard[nextRIndx, nextCIndx] = visitPos;

                if (KnightsTourBackTrackingHelper(chessBoard, nextRIndx, nextCIndx, visitPos + 1))
                {
                    return true;
                }
                else
                {
                    // Backtracking
                    chessBoard[nextRIndx, nextCIndx] = -1;
                    Console.WriteLine(" Taking back tracing " + nextRIndx + " " + nextCIndx);
                }
            }

            return false;
        }
    }
}