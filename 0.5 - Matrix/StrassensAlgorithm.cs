using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    https://www.youtube.com/watch?v=kHVWdLvidJw
     http://www.stoimen.com/blog/2012/11/26/computer-algorithms-strassens-matrix-multiplication/
     * Helpful in large matrix multiplications

    Generally Strassen’s Method is not preferred for practical applications for following reasons.
 1) The constants used in Strassen’s method are high and for a typical application Naive method works better.
 2) For Sparse matrices, there are better methods especially designed for them.
 3) The submatrices in recursion take extra space.
 4) Because of the limited precision of computer arithmetic on noninteger values, larger errors accumulate in Strassen’s algorithm than in Naive Method (Source: CLRS Book)
    http://www.geeksforgeeks.org/strassens-matrix-multiplication/
     * */
    class StrassensAlgorithm
    {
    }
}
