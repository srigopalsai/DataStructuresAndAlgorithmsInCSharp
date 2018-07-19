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

        // Returns false if no complete tour is possible, otherwise return true and prints the tour. 
        // Note that there may be more than one solutions, this function prints one of the feasible solutions.

        public bool KnightsTourBackTracking(int boardDimension = 8)
        {
            int[,] chessBoard = new int[boardDimension, boardDimension];

            for (int rIndx = 0; rIndx < chessBoard.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < chessBoard.GetLength(1); cIndx++)
                {
                    chessBoard[rIndx, cIndx] = -1;
                }
            }

            // Since the Knight is initially at the first block
            chessBoard[0, 0] = 0;

            // Start from 0,0 and explore all tours.
            return KnightsTourBackTracking(chessBoard, 0, 0, 1);
        }

        int[] rMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] cMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        private bool KnightsTourBackTracking(int[,] chessBoard, int curRIndx, int curCIndx, int visitPos )
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

                if (KnightsTourBackTracking(chessBoard, nextRIndx, nextCIndx, visitPos + 1) == true)
                {
                    return true;
                }

                // Backtracking
                chessBoard[nextRIndx, nextCIndx] = -1;
                Console.WriteLine(" Back tracing " + nextRIndx + " " + nextCIndx);
            }

            return false;
        }

        // Search Word in Matrix - Brute Force O(N^2) 
        // https://algorithms.tutorialhorizon.com/backtracking-search-a-word-in-a-matrix/

        int[,] solution;
        int pathIndx = 1;

        public bool SearchWordInMatrix(char[,] matrix, String word)
        {
            if (matrix == null || matrix.Length == 0 || string.IsNullOrWhiteSpace(word))
                return false;

            solution = new int[matrix.GetLength(0), matrix.GetLength(1)];
            pathIndx = 1;

            Common.ShowMatrixOnConsole(matrix, "Search Word in Matrix");

            for (int rIndx = 0; rIndx < matrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < matrix.GetLength(1); cIndx++)
                {
                    if (SearchWordInMatrix(matrix, word, rIndx, cIndx, 0) == true)
                    {
                        Common.ShowMatrixOnConsole(solution, "Traversal Path");

                        return true;
                    }
                }
            }

            return false;
        }

        private bool SearchWordInMatrix(char[,] matrix, String word, int rIndx, int cIndx, int strIndx)
        {
            // Check if current cell not already used or character in it is not not

            if (solution[rIndx, cIndx] != 0 || matrix[rIndx, cIndx] != word[strIndx])
            {
                return false;
            }

            solution[rIndx, cIndx] = pathIndx++;

            if (strIndx == word.Length - 1)
            {
                return true;
            }

            // Check if cell is already used

            if (rIndx + 1 < matrix.GetLength(0) && SearchWordInMatrix(matrix, word, rIndx + 1, cIndx, strIndx + 1))
            {
                // Go down
                return true;
            }

            if (rIndx - 1 >= 0 && SearchWordInMatrix(matrix, word, rIndx - 1, cIndx, strIndx + 1))
            {
                // Go up
                return true;
            }

            if (cIndx + 1 < matrix.GetLength(1) && SearchWordInMatrix(matrix, word, rIndx, cIndx + 1, strIndx + 1))
            {
                // Go right
                return true;
            }

            if (cIndx - 1 >= 0 && SearchWordInMatrix(matrix, word, rIndx, cIndx - 1, strIndx + 1))
            {
                // Go left
                return true;
            }

            if (rIndx - 1 >= 0 && cIndx + 1 < matrix.GetLength(1) && SearchWordInMatrix(matrix, word, rIndx - 1, cIndx + 1, strIndx + 1))
            {
                // Go diagonally up right
                return true;
            }

            if (rIndx - 1 >= 0 && cIndx - 1 >= 0 && SearchWordInMatrix(matrix, word, rIndx - 1, cIndx - 1, strIndx + 1))
            {
                // Go diagonally up left
                return true;
            }

            if (rIndx + 1 < matrix.GetLength(0) && cIndx - 1 >= 0 && SearchWordInMatrix(matrix, word, rIndx + 1, cIndx - 1, strIndx + 1))
            {
                // Go diagonally down left
                return true;
            }

            if (rIndx + 1 < matrix.GetLength(0) && cIndx + 1 < matrix.GetLength(1) && SearchWordInMatrix(matrix, word, rIndx + 1, cIndx + 1, strIndx + 1))
            {
                // Go diagonally down right
                return true;
            }

            // If none of the option works out, BACKTRACK and return false

            solution[rIndx, cIndx] = 0;
            pathIndx--;

            return false;
        }
    }
}