using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public partial class MatrixOperations
    {
        /* Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.
           A region is captured by flipping all 'O's into 'X's in that surrounded region.
           https://leetcode.com/problems/surrounded-regions/
        */
        public void FillOsWIthXsIfSurroundedByXs(char[,] board)
        {
            if (board.GetLength(0) == 0 || board.GetLength(1) == 0)         
                return;

            for (int i = 0; i < board.Length; i++)
            {
                dfs(board, i, 0);
                dfs(board, i, board.GetLength(0) - 1);
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                dfs(board, 0, i);
                dfs(board, board.Length - 1, i);
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                {
                    if (board[i,j] == 'O')
                    {
                        board[i,j] = 'X';
                    }
                    else if (board[i,j] == '1')
                    {
                        board[i,j] = 'O';
                    }
                }
            }
        }

        private void dfs(char[,] board, int i, int j)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board.GetLength(0))
            {
                return;
            }

            if (board[i,j] != 'O')
            {
                return;
            }

            board[i,j] = '1';
            if (i < board.Length - 2)
            {
                dfs(board, i + 1, j);
            }
            if (i > 1)
            {
                dfs(board, i - 1, j);
            }
            if (j < board.GetLength(0) - 2)
            {
                dfs(board, i, j + 1);
            }
            if (j > 1)
            {
                dfs(board, i, j - 1);
            }
        }

        public void FillOsWIthXsIfSurroundedByXsTest()
        {
            char[,] board ={{'X','X','X','X'},
                          {'X','X','O','X'},
                          {'X','O','X','X'},
                          {'X','X','O','X'}};

            FillOsWIthXsIfSurroundedByXs(board);
        }
    }
}