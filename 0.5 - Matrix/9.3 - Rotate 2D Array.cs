using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    Rotation matrices are square matrices, with real entries
       In-place Rotation is only possible with Square Matrix

1) original matrix

1 2 3
4 5 6
7 8 9

2) transpose

1 4 7
2 5 8
3 6 9

3-a) change rows to rotate left

3 6 9
2 5 8
1 4 7

3-b) or change columns to rotate right

7 4 1
8 5 2
9 6 3

    The algorithm is to rotate each "ring", working from the outermost to the innermost.
AAAAA
ABBBA
ABCBA
ABBBA
AAAAA


    cons int row = 10;
cons int col = 10;
//transpose
for(int r = 0; r < row; r++)
{
  for(int c = r; c < col; c++)
  {  
    Common.Swap(Array[r][c], Array[c][r]);
  }
}
//reverse elements on row order
for(int r = 0; r < row; r++)
{
    for(int c =0; c < col/2; c++)
    {
      Common.Swap(Array[r][c], Array[r][col-c-1])
    }
}
    ---------------------------------------------------------------------------------------------

The algorithm would rotate all the A's first, then B's then C's. Rotating a ring requires moving 4 values at once.

The index i ranges from 0..ring-width-1, e.g. for A the width is 5.
  (i,0) -> temp
  (0, N-i-1) -> (i, 0)
  (N-i-1, N-1) -> (0, N-i-1)
  (N-1, i) -> (N-i-1, N-1)
  temp -> (N-1, i)  

    ---------------------------------------------------------------------------------------------

    By 90 Degreee

    for(int i=0; i<n/2; i++)
   for(int j=0; j<(n+1)/2; j++)
       cyclic_roll(m[i][j], m[n-1-j][i], m[n-1-i][n-1-j], m[j][n-1-i]);


void cyclic_roll(int &a, int &b, int &c, int &d)
{
   int temp = a;
   a = b;
   b = c;
   c = d;
   d = temp;
}

    Uses : Imagae Rotation
    http://en.wikipedia.org/wiki/Rotation_matrix

    http://stackoverflow.com/questions/42519/how-do-you-rotate-a-two-dimensional-array?rq=1

    http://stackoverflow.com/questions/2893101/how-to-rotate-a-n-x-n-matrix-by-90-degrees
    */
    partial class MatrixOperations
    {

    }
}