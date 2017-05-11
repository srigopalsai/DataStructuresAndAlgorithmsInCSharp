using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/Substitution_matrix
 http://en.wikipedia.org/wiki/Distance_matrix
    http://en.wikipedia.org/wiki/Similarity_matrix
    http://en.wikipedia.org/wiki/Transpose
    */
    class Transpose
    {
        void rotateRight(int[,] matrix, int length)
        {
            for (int layer = 0; layer < length / 2; ++layer)
            {
                int first = layer;
                int last = length - 1 - layer;

                for (int i = first; i < last; ++i)
                {
                    int topline = matrix[first, i];
                    int rightcol = matrix[i, last];
                    int bottomline = matrix[last, (length - layer - 1 - i)];
                    int leftcol = matrix[(length - layer - 1 - i), first];

                    matrix[first, i] = leftcol;
                    matrix[i, last] = topline;
                    matrix[last, (length - layer - 1 - i)] = rightcol;
                    matrix[(length - layer - 1 - i), first] = bottomline;
                }
            }
        }

    //  for x = 0 to f - 1
    //  for y = 0 to c - 1
    //  temp = a[x,y]
    //  a[x,y] = a[y,n-1-x]
    //  a[y,n-1-x] = a[n-1-x,n-1-y]
    //  a[n-1-x,n-1-y] = a[n-1-y,x]
    //  a[n-1-y,x] = temp

    }
}