using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms._8._0___String_Algorithms
{
    /*
    http://en.wikipedia.org/wiki/Edit_distance
    http://en.wikipedia.org/wiki/Levenshtein_distance
    http://en.wikibooks.org/wiki/Algorithm_Implementation/Strings/Levenshtein_distance
    https://allaboutalgorithms.wordpress.com/2011/10/31/edit-distance-between-two-strings-using-recursion/
    http://www.csse.monash.edu.au/~lloyd/tildeAlgDS/Dynamic/Edit/
    Edit distances find applications in natural language processing, where automatic spelling correction can determine candidate corrections for a misspelled word by selecting words from a dictionary that have a low distance to the word in question. In bioinformatics, it can be used to quantify the similarity of macromolecules such as DNA, which can be viewed as strings of the letters A, C, G and T.

Uses:

File Revision

The Unix command diff f1 f2 finds the difference between files f1 and f2, producing an edit script to convert f1 into f2. If two (or more) computers share copies of a large file F, and someone on machine-1 edits F=F.bak, making a few changes, to give F.new, it might be very expensive and/or slow to transmit the whole revised file F.new to machine-2. However, diff F.bak F.new will give a small edit script which can be transmitted quickly to machine-2 where the local copy of the file can be updated to equal F.new. 

diff treats a whole line as a "character" and uses a special edit-distance algorithm that is fast when the "alphabet" is large and there are few chance matches between elements of the two strings (files). In contrast, there are many chance character-matches in DNA where the alphabet size is just 4, {A,C,G,T}. 

Try `man diff' to see the manual entry for diff. 

Remote Screen Update Problem

If a computer program on machine-1 is being used by someone from a screen on (distant) machine-2, e.g. via rlogin etc., then machine-1 may need to update the screen on machine-2 as the computation proceeds. One approach is for the program (on machine-1) to keep a "picture" of what the screen currently is (on machine-2) and another picture of what it should become. The differences can be found (by an algorithm related to edit-distance) and the differences transmitted... saving on transmission band-width. 

Spelling Correction

Algorithms related to the edit distance may be used in spelling correctors. If a text contains a word, w, that is not in the dictionary, a `close' word, i.e. one with a small edit distance to w, may be suggested as a correction. 

Transposition errors are common in written text. A transposition can be treated as a deletion plus an insertion, but a simple variation on the algorithm can treat a transposition as a single point mutation. 

Plagiarism Detection

The edit distance provides an indication of similarity that might be too close in some situations ... think about it. 

Molecular Biology


Example

An example of a DNA sequence from `Genebank' can be found [here]. The simple edit distance algorithm would normally be run on sequences of at most a few thousand bases. 
 

The edit distance gives an indication of how `close' two strings are. Similar measures are used to compute a distance between DNA sequences (strings over {A,C,G,T}, or protein sequences (over an alphabet of 20 amino acids), for various purposes, e.g.: 
1.to find genes or proteins that may have shared functions or properties
2.to infer family relationships and evolutionary trees over different organisms


Speech Recognition

Algorithms similar to those for the edit-distance problem are used in some speech recognition systems: find a close match between a new utterance and one in a library of classified utterances. 

    */
    class Edit_Distance_In_Strings_Levenshtein_Distance
    {
        int EditDistance(string String1, string String2, int m, int n)
        {

            if (String2.Length == n) 
            {
                return (String1.Length - m);
            }
            if (String1.Length == m) 
            {
                return (String2.Length - n);
            }
            if (String1[m] == String2[n]) 
            {
                return EditDistance(String1, String2, m + 1, n + 1);
            }
            if (String1[m] != String2[n])
            {
                return 1 + Math.Min(Math.Min(EditDistance(String1, String2, m, n + 1), EditDistance(String1, String2, m + 1, n)), EditDistance(String1, String2, m + 1, n + 1));
            }
            return -1;
        }

        private Int32 levenshtein(String a, String b)
        {

            if (string.IsNullOrEmpty(a))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    return b.Length;
                }
                return 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Length;
                }
                return 0;
            }

            Int32 cost;
            Int32[,] d = new int[a.Length + 1, b.Length + 1];
            Int32 min1;
            Int32 min2;
            Int32 min3;

            for (Int32 i = 0; i <= d.GetUpperBound(0); i += 1)
            {
                d[i, 0] = i;
            }

            for (Int32 i = 0; i <= d.GetUpperBound(1); i += 1)
            {
                d[0, i] = i;
            }

            for (Int32 i = 1; i <= d.GetUpperBound(0); i += 1)
            {
                for (Int32 j = 1; j <= d.GetUpperBound(1); j += 1)
                {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];

        }

        //An implementation with reduced memory useage


        public int LevenshteinDistance(string source, string target)
        {
            if (String.IsNullOrEmpty(source))
            {
                if (String.IsNullOrEmpty(target)) return 0;
                return target.Length;
            }
            if (String.IsNullOrEmpty(target)) return source.Length;

            if (source.Length > target.Length)
            {
                var temp = target;
                target = source;
                source = temp;
            }

            var m = target.Length;
            var n = source.Length;
            var distance = new int[2, m + 1];
            // Initialize the distance 'matrix'
            for (var j = 1; j <= m; j++) distance[0, j] = j;

            var currentRow = 0;
            for (var i = 1; i <= n; ++i)
            {
                currentRow = i & 1;
                distance[currentRow, 0] = i;
                var previousRow = currentRow ^ 1;
                for (var j = 1; j <= m; j++)
                {
                    var cost = (target[j - 1] == source[i - 1] ? 0 : 1);
                    distance[currentRow, j] = Math.Min(Math.Min(
                                distance[previousRow, j] + 1,
                                distance[currentRow, j - 1] + 1),
                                distance[previousRow, j - 1] + cost);
                }
            }
            return distance[currentRow, m];
        }


    }
}
