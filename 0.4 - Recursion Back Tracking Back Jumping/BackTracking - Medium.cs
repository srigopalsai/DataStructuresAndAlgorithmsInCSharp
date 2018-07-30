using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class BackTrackingProblems
    {
        // Knight’s tour :
        // Play this game for better understanding http://www.maths-resources.com/knights/
        // http://www.mayhematics.com/t/t.htm
        // Given 8 X 8 chess board with -1 default values, return the below traverse board
        //    0  59  38  33  30  17   8  63
        //   37  34  31  60   9  62  29  16
        //   58   1  36  39  32  27  18   7
        //   35  48  41  26  61  10  15  28
        //   42  57   2  49  40  23   6  19
        //   47  50  45  54  25  20  11  14
        //   56  43  52   3  22  13  24   5
        //   51  46  55  44  53   4  21  12
        //
        // Returns false if no complete tour is possible, otherwise return true and prints the tour.
        // Note that there may be more than one solutions, this function prints one of the feasible solutions.
        // 

        // curRow + 2, curCol - 1 	- downWard two and left  one
        // curRow + 2, curCol + 1 	- downWard two and right one

        // curRow + 1, curCol - 2 	- downWard one and left  two
        // curRow + 1, curCol + 2 	- downWard one and right two

        // curRow - 1, curCol - 2 	- upWard   one and left  two
        // curRow - 1, curCol + 2 	- upWard   one and right two

        // curRow - 2, curCol - 1 	- upWard   two and left  one
        // curRow - 2, curCol + 1 	- upWard   two and right one

        // On an 8 × 8 board, there are exactly 26,534,728,821,064 directed closed tours
        // (i.e.two tours along the same path that travel in opposite directions are counted separately, as are rotations and reflections).
        // The number of undirected closed tours is half this number, since every tour can be traced in reverse.
        // There are 9,862 undirected closed tours on a 6 × 6 board.
        //
        // The number of all directed tours (open and closed) on an n × n board for n = 1, 2, … are:
        // 1; 0; 0; 0; 1,728; 6,637,920; 165,575,218,320; 19,591,828,170,979,904
        //
        // Brute-force algorithms :
        //
        // A brute-force search for a knight's tour is impractical on all but the smallest boards.
        // E.g. On an 8 × 8 board there are approximately 4×1051 possible move sequences, and it is well beyond the capacity of modern computers (or networks of computers) to perform operations on such a large set.
        // However, the size of this number gives a misleading impression of the difficulty of the problem, which can be solved "by using human insight and ingenuity ... without much difficulty
        //
        // Divide and conquer algorithms : (Linear Time)
        //
        // By dividing the board into smaller pieces, constructing tours on each piece, and patching the pieces together.
        // one can construct tours on most rectangular boards in linear time.
        // I.e.In a time proportional to the number of squares on the board
        // https://en.wikipedia.org/wiki/Knight%27s_tour
        // https://www.geeksforgeeks.org/backtracking-algorithms/#standard
        //
        // Neural network solutions :
        //
        // Closed knight's tour on a 24 × 24 board solved by a neural network.
        // The Knight's Tour problem also lends itself to being solved by a neural network implementation.
        // The network is set up such that every legal knight's move is represented by a neuron, and each neuron is initialized randomly to be either "active" or "inactive" (output of 1 or 0), with 1 implying that the neuron is part of the final solution.
        // Each neuron also has a state function(described below) which is initialized to 0.
        //
        // Warnsdorf's rule : 
        //
        // The solution is same as backtracking.Only difference in the algorithm is to pick next move based on some heuristic.
        // Here, the heuristic is, we pick the move which lands up in a cell which has least number of possible moves.
        // That is, we think ahead and pick the cell which has least number of moves available.
        // Explained in Detail http://www.knightstour.in/ 
        // A graphical representation of Warnsdorf's Rule. 
        // Each square contains an integer giving the number of moves that the knight could make from that square. 
        // In this case, the rule tells us to move to the square with the smallest integer in it, namely 2.
        // A very large(130x130) square open Knight's Tour created using Warnsdorf's Rule.
        //
        // Warnsdorf's rule is a 'heuristic' for finding a knight's tour. 
        // The knight is moved so that it always proceeds to the square from which the knight will have the fewest onward moves.
        // When calculating the number of onward moves for each candidate square, we do not count moves that revisit any square already visited.
        // It is, of course, possible to have two or more choices for which the number of onward moves is equal.
        // There are various methods for breaking such ties, including one devised by Pohl[14] and another by Squirrel and Cull.[15]
        // This rule may also more generally be applied to any graph.
        // In graph-theoretic terms, each move is made to the adjacent vertex with the least degree.
        // Although the Hamiltonian path problem is NP-hard in general, on many graphs that occur in practice this heuristic is able to successfully locate a solution in linear time.[14] The knight's tour is a special case.[16]
        // The heuristic was first described in "Des Rösselsprungs einfachste und allgemeinste Lösung" by H. C.von Warnsdorf in 1823. 
        // A computer program that finds a knight's tour for any starting position using Warnsdorf's rule was written by Gordon Horsington and published in 1984 in the book Century/Acorn User Book of Computer Puzzles
        //
        // W
        // Advantages: Compared to other Knights Tour algorithms, simplicity. Compared to W+, it doesn't really have advantages. 
        // Compared to W2, it's much more easy to implement.
        // Disadvantages: there are plenty of cases when there is a solution, but W can't provide one it tends to mess up with bigger boards (50+)
        //
        // W+
        // Advantages: Compared to other Knights Tour algorithms, simplicity.
        // Compared to W: it can provide a solution in much more cases and it almost isn't more complex than W. 
        // Compared to W2, it's much more easy to implement and W+ works on non-square boards too. 10x20 for example.
        // Disadvantages: Compared to W, it doesn't have disadvantages. 
        // Compared to other knights tour algorithms, is that this one can get stuck in some cases. 
        // The toughest for W+ are small boards like 5x5, 6x6, 7x7, 9x9 etc. 
        // As stated on the Wiki, it has problems with boards when both x and y are even. On the other hand, when x and y are even, but greater than 9 it seems W+ manages to find a solution. 
        // Compared to W2, I didn't experience disadvantages.
        //
        // W2
        // Advantages: Compared to W, it gives solutions in much more cases, especially for large boards. 
        // Compared to W+ I didn't notice advantages.
        // Disadvantages: Implementation compared to W and W+.
        //
        // Conclusion:
        // My opinion is that W+ is practically the most acceptable. Don't forget that it isn't perfect. 
        // And I have to say, that my implementation doesn't allow for really big boards. 
        // I tested W+ up to 90x90 (8100 nodes) and it still provided solutions. Although, I didn't do extensive testing because of limited time. 
        // I hope this helps someone who confronted this problem before. Because this isn't a definite answer.
        // I won't accept it for a while, in hope that someone appears who can give a complete answer.

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
            bool result = KnightsTourBackTracking(chessBoard, 0, 0, 1);
            Common.ShowMatrixOnConsole(chessBoard, "Knight Tour as follows ");

            return result;
        }

        int[] rMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        int[] cMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        private bool KnightsTourBackTracking(int[,] chessBoard, int curRIndx, int curCIndx, int visitPos)
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

                if (Common.IsSafe(nextRIndx, nextCIndx, chessBoard, -1) == false)
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
                //Console.WriteLine(" Back tracing " + nextRIndx + " " + nextCIndx);
            }

            return false;
        }

        // Pick least possible cell first.
        private bool KnightsTourBackTrackingWarnsdorf(int[,] board, int curRIndx, int curCIndx, int visitPos)
        {
            if (visitPos == board.GetLength(0) * board.GetLength(1))
            {
                return true;
            }

            IEnumerable<Cell> validCells = GetCells(board, curRIndx, curCIndx);

            // Try all next moves from the current coordinate x, y
            foreach (Cell cell in validCells)
            {
                if (Common.IsSafe(cell.Row, cell.Col, board, -1) == false)
                {
                    continue;
                }

                board[cell.Row, cell.Col] = visitPos;

                if (KnightsTourBackTracking(board, cell.Row, cell.Col, visitPos + 1) == true)
                {
                    return true;
                }

                // Backtracking
                board[cell.Row, cell.Col] = -1;
                //Console.WriteLine(" Back tracing " + nextRIndx + " " + nextCIndx);
            }

            return false;
        }

        public IEnumerable<Cell> GetCells(int[,] board, int curRIndx, int curCIndx)
        {
            int nextRIndx;
            int nextCIndx;
            int weight = 0;

            List<Cell> validMoves = new List<Cell>();

            // Try all next moves from the current coordinate x, y
            for (int nextIndx = 0; nextIndx < 8; nextIndx++)
            {
                nextRIndx = curRIndx + rMove[nextIndx];
                nextCIndx = curCIndx + cMove[nextIndx];

                if (Common.IsSafe(nextRIndx, nextCIndx, board, -1) == false)
                {
                    continue;
                }

                weight = GetWeight(board, nextRIndx, nextCIndx);
                validMoves.Add(new Cell(nextRIndx, nextCIndx, weight));
            }

            //validMoves.Sort(new CellComparer());
            //return validMoves.AsEnumerable();
            return (validMoves.Count == 0) ? validMoves.AsEnumerable() : validMoves.OrderBy(item => item.Weight);
        }

        public int GetWeight(int[,] board, int curRIndx, int curCIndx)
        {
            int nextRIndx;
            int nextCIndx;
            int weight = 0;

            for (int nextIndx = 0; nextIndx < 8; nextIndx++)
            {
                nextRIndx = curRIndx + rMove[nextIndx];
                nextCIndx = curCIndx + cMove[nextIndx];

                if (Common.IsSafe(nextRIndx, nextCIndx, board, -1) == false)
                {
                    continue;
                }

                weight++;
            }

            return weight;
        }

        public class CellComparer : IComparer<Cell>
        {
            public int Compare(Cell cell1, Cell cell2)
            {
                return cell1.Weight > cell2.Weight ? 0 : -1;
            }
        }

        public class Cell
        {
            public int Row { get; set; }

            public int Col { get; set; }

            public int Weight { get; set; }

            public bool Visited { get; set; }

            public Cell(int row, int col, int weight = 0)
            {
                this.Row = row;
                this.Col = col;
                this.Weight = weight;
            }
        }

        // Search Word in Matrix - Brute Force O(N^2) 
        // https://algorithms.tutorialhorizon.com/backtracking-search-a-word-in-a-matrix/
        // https://www.geeksforgeeks.org/search-a-word-in-a-2d-grid-of-characters/
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

        // https://www.geeksforgeeks.org/find-all-occurrences-of-the-word-in-a-matrix/
        // https://www.geeksforgeeks.org/find-count-number-given-string-present-2d-character-array/
        // utility function to search
        // complete string from any
        // given index of 2d char array
        //private int internalSearch(string needle, int row, int col, char[,] hay, int row_max, int col_max)
        //{
        //    int found = 0;

        //    if (row >= 0 && row <= row_max && col >= 0 && col <= col_max && needle == hay[row][col])
        //    {
        //        char match = *needle++;

        //        hay[row,col] = 0;

        //        if (needle == 0)
        //        {
        //            found = 1;
        //        }
        //        else
        //        {

        //            // through Backtrack searching 
        //            // in every directions
        //            found += internalSearch(needle, row, col + 1, hay, row_max, col_max);
        //            found += internalSearch(needle, row, col - 1, hay, row_max, col_max);
        //            found += internalSearch(needle, row + 1, col, hay, row_max, col_max);
        //            found += internalSearch(needle, row - 1, col, hay, row_max, col_max);
        //        }

        //        hay[row,col] = match;
        //    }

        //    return found;
        //}

        // Function to search the string in 2d array
        public int SearchString(string needle, int row, int col, char[,] str, int row_count, int col_count)
        {
            int found = 0;
            int r;
            int c;

            for (r = 0; r < row_count; ++r)
            {
                for (c = 0; c < col_count; ++c)
                {
                    //found += internalSearch(needle, r, c, str, row_count - 1, col_count - 1);
                }
            }

            return found;
        }

        // Driver code
        //int main()
        //{
        //    string needle = "MAGIC";
        //    string[] input = {
        //                        "BBABBM",
        //                        "CBMBBA",
        //                        "IBABBG",
        //                        "GOZBBI",
        //                        "ABBBBC",
        //                        "MCIGAM"
        //                    };

        //    char[,] str = new char[input.Length, input.Length];
        //    int i;

        //    for (i = 0; i < ARRAY_SIZE(input); ++i)
        //    {
        //        str[i] = malloc(strlen(input[i]));
        //        strcpy(str[i], input[i]);
        //    }

        //    Console.WriteLine("count: %d\n", searchString(needle, 0, 0, str, str.Length, strlen(str[0])));

        //    return 0;
        //}
        // https://www.geeksforgeeks.org/z-algorithm-linear-time-pattern-searching-algorithm/
    }
}