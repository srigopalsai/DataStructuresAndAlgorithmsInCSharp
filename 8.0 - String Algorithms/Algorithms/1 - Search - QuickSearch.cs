using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    /*
    simplification of the Boyer-Moore algorithm;
uses only the bad-character shift;
easy to implement;
preprocessing phase in O(m+sigma) time and O(sigma) space complexity;
searching phase in O(mn) time complexity;
very fast in practice for short patterns and large alphabets.
     http://www-igm.univ-mlv.fr/~lecroq/string/node19.html#SECTION00190
     */
    partial class StringAlgorithms
    { }
//    class QuickSearch
//    {
//        void preQsBc(string x, int m, int qsBc[]) {
//   int i;

//   for (i = 0; i < ASIZE; ++i)
//      qsBc[i] = m + 1;
//   for (i = 0; i < m; ++i)
//      qsBc[x[i]] = m - i;
//}


//void QS(string x, int m, string y, int n) {
//   int j, qsBc[ASIZE];

//   /* Preprocessing */
//   preQsBc(x, m, qsBc);
 
//   /* Searching */
//   j = 0;
//   while (j <= n - m) {
//      if (memcmp(x, y + j, m) == 0)
//         OUTPUT(j);
//      j += qsBc[y[j + m]];               /* shift */
//   }
//}
//    }
}
