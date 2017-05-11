using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    ============================================================================================================================================================================================================================
    
    Using a regular chess board, the challenge is to place eight queens on the board such that no queen is attacking any of the others. 
    For those not familiar with chess pieces, the queen is able to attack any square on the same row, any square on the same column, and also any square on either of the diagonals.

    For 8 queens, Solution considers 64^8 or 281 474 976 710 656 different solutions, of which only 92 (duplicate of other types) are valid. But there are only 12 distinct solutions.
     (92 does not divide equally by 12 because many of the reflections and rotations of a pure solutions are not unique).

    http://en.literateprograms.org/Eight_queens_puzzle_(C)
    https://www.youtube.com/user/ProgrammingInterview/videos
    http://rosettacode.org/wiki/N-queens_problem#C.23
    http://en.literateprograms.org/Eight_queens_puzzle_(C)
    Play around with borad online at : http://www.datagenetics.com/blog/august42012/

    Board       Total Solutions             Unique Solutions

     1 x 1      1                           1  
     2 x 2      0                           0  
     3 x 3      0                           0  
     4 x 4      2                           1  
     5 x 5      10                          2  
     6 x 6      4                           1  
     7 x 7      40                          6  
     8 x 8      92                          12  
     9 x 9      352                         46  
     10 x 10    724                         92  
     11 x 11    2,680                       341  
     12 x 12    14,200                      1,787  
     13 x 13    73,712                      9,233  
     14 x 14    365,596                     45,752  
     15 x 15    2,279,184                   285,053  
     16 x 16    14,772,512                  1,846,955  
     17 x 17    95,815,104                  11,977,939  
     18 x 18    666,090,624                 83,263,591  
     19 x 19    4,968,057,848               621,012,754  
     20 x 20    39,029,188,884              4,878,666,808  
     21 x 21    314,666,222,712             39,333,324,973  
     22 x 22    2,691,008,701,644           336,376,244,042  
     23 x 23    24,233,937,684,440          3,029,242,658,210  
     24 x 24    227,514,171,973,736         28,439,272,956,934  
     25 x 25    2,207,893,435,808,350       275,986,683,743,434  
     26 x 26    22,317,699,616,364,000      2,789,712,466,510,280  

    ============================================================================================================================================================================================================================
    */
    partial class RecursionSamples
    {
        int N = 4;

        public void NQueensTest()
        {
            //int[,] board = new int[4, 4]   {{0, 0, 0, 0},
            //                                {0, 0, 0, 0},
            //                                {0, 0, 0, 0},
            //                                {0, 0, 0, 0}};
            //int noOfQueens = 4;
            //String message = Common.DisplayMatrix(board, "Source Board\n");
            ////NQueens(board, noOfQueens);
            //message += Common.DisplayMatrix(board, "Filled With Queens\n");

            bool[,] board = new bool[N, N];

            if (FindSolution(board, 0))
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write(board[i, j] ? "|Q" : "| ");
                    }
                    Console.WriteLine("|");
                }
            }
            else
            {
                Console.WriteLine("No solution found for n = " + N + ".");
            }

            Console.ReadKey(true);
        }
        //public void NQueens(int[,] board, int noOfQueens)
        //{

        //}
        //public void PlaceQueen(int[,] board)
        //{
 
        //}
        //public void IsValidPosition(int[,] board, int rowPos, int colPos)
        //{
 
        //}
        bool Allowed(bool[,] board, int x, int y)
        {
            for (int i=0; i<=x; i++)
            {
                if (board[i,y] || (i <= y && board[x-i,y-i]) || (y+i < N && board[x-i,y+i]))
                {
                    return false;
                }
            }
            return true;
        }
 
        bool FindSolution(bool[,] board, int x)
        {
            for (int y = 0; y < N; y++)
            {
                if (Allowed(board, x, y))
                {
                    board[x, y] = true;
                    if (x == N-1 || FindSolution(board, x + 1))
                    {
                        return true;
                    }
                    board[x, y] = false;
                }
            }
            return false;
        }
    }
}
