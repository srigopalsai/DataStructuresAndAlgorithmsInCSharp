using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    //Recursive flood fill algorithm is DFS. We can do a BFS to convert it to nonrecursive.
    //Refer Time Complexity here http://www.cs.bilkent.edu.tr/~gunduz/teaching/cs201/slides/Recitation4.pdf
    //http://en.wikipedia.org/wiki/Flood_fill
    //http://www.codecodex.com/wiki/Implementing_the_flood_fill_algorithm
    //https://www.youtube.com/watch?v=n6_s8fpAEEY

    //Used In : 
    //1. Fill Command in Paint. 
    //2. Minesweeper 
    //3. Boundary fill in image editing application
    
    //Approaches:
    //1. Recursive Stack Based.
    //2. Iterative Queue Baseed.
    //3. Fixed Memory Method.
    
    //Tail recursion can always be translated to an iterative format. That would save even more stack space.
    /*
    if()
    {
        //Base case where we dont call recursive function.
    }
    else
    {
        //Recursive case where we call recursive function.
    }

    The simple 4-way recursive algorithm is pathological and consumes O(N) bytes of stack space where N is the number of pixels to fill. 
    The queue method is a lot better, in the normal case you have a ring of O(sqrt(N)) pixels.
    It is possible to devise an intricate fill pattern where you have more pixels in the queue and I'm not sure what the upper limit is. 

    //Crashes if recursion stack is full
    void floodFill8(int x, int y, int newColor, int oldColor)
    {
      if(x >= 0 && x < w && y >= 0 && y < h && screenBuffer[y][x] == oldColor && screenBuffer[y][x] != newColor)
      {
        screenBuffer[y][x] = newColor; //set color before starting recursion!

        floodFill8(x + 1, y    , newColor, oldColor);
        floodFill8(x - 1, y    , newColor, oldColor);
        floodFill8(x    , y + 1, newColor, oldColor);
        floodFill8(x    , y - 1, newColor, oldColor);
        floodFill8(x + 1, y + 1, newColor, oldColor);
        floodFill8(x - 1, y - 1, newColor, oldColor);
        floodFill8(x - 1, y + 1, newColor, oldColor);
        floodFill8(x + 1, y - 1, newColor, oldColor);
      }
    }

        //4-way floodfill using our own stack routines
void floodFill4Stack(int x, int y, int newColor, int oldColor)
{
  if(newColor == oldColor) return; //avoid infinite loop
  emptyStack();

  static const int dx[4] = {0, 1, 0, -1}; // relative neighbor x coordinates
  static const int dy[4] = {-1, 0, 1, 0}; // relative neighbor y coordinates

  if(!push(x, y)) return;
  while(pop(x, y))
  {
    screenBuffer[y][x] = newColor;
    for(int i = 0; i < 4; i++) {
      int nx = x + dx[i];
      int ny = y + dy[i];
      if(nx > 0 && nx < w && ny > 0 && ny < h && screenBuffer[ny][nx] == oldColor) {
        if(!push(nx, ny)) return;
      }
    }
  }
}

        //8-way floodfill using our own stack routines
void floodFill4Stack(int x, int y, int newColor, int oldColor)
{
  if(newColor == oldColor) return; //avoid infinite loop
  emptyStack();

  static const int dx[8] = {0, 1, 1, 1, 0, -1, -1, -1}; // relative neighbor x coordinates
  static const int dy[8] = {-1, -1, 0, 1, 1, 1, 0, -1}; // relative neighbor y coordinates

  if(!push(x, y)) return;
  while(pop(x, y))
  {
    screenBuffer[y][x] = newColor;
    for(int i = 0; i < 8; i++) {
      int nx = x + dx[i];
      int ny = y + dy[i];
      if(nx > 0 && nx < w && ny > 0 && ny < h && screenBuffer[ny][nx] == oldColor) {
        if(!push(nx, ny)) return;
      }
    }
  }
}

        //stack friendly and fast floodfill algorithm
void floodFillScanline(int x, int y, int newColor, int oldColor)
{
  if(oldColor == newColor) return;
  if(screenBuffer[y][x] != oldColor) return;

  int x1;

  //draw current scanline from start position to the right
  x1 = x;
  while(x1 < w && screenBuffer[y][x1] == oldColor)
  {
    screenBuffer[y][x1] = newColor;
    x1++;
  }

  //draw current scanline from start position to the left
  x1 = x - 1;
  while(x1 >= 0 && screenBuffer[y][x1] == oldColor)
  {
    screenBuffer[y][x1] = newColor;
    x1--;
  }

  //test for new scanlines above
  x1 = x;
  while(x1 < w && screenBuffer[y][x1] == newColor)
  {
    if(y > 0 && screenBuffer[y - 1][x1] == oldColor)
    {
      floodFillScanline(x1, y - 1, newColor, oldColor);
    }
    x1++;
  }
  x1 = x - 1;
  while(x1 >= 0 && screenBuffer[y][x1] == newColor)
  {
    if(y > 0 && screenBuffer[y - 1][x1] == oldColor)
    {
      floodFillScanline(x1, y - 1, newColor, oldColor);
    }
    x1--;
  }

  //test for new scanlines below
  x1 = x;
  while(x1 < w && screenBuffer[y][x1] == newColor)
  {
    if(y < h - 1 && screenBuffer[y + 1][x1] == oldColor)
    {
      floodFillScanline(x1, y + 1, newColor, oldColor);
    }
    x1++;
  }
  x1 = x - 1;
  while(x1 >= 0 && screenBuffer[y][x1] == newColor)
  {
    if(y < h - 1 && screenBuffer[y + 1][x1] == oldColor)
    {
      floodFillScanline(x1, y + 1, newColor, oldColor);
    }
    x1--;
  }
}

        //The scanline floodfill algorithm using our own stack routines, faster
void floodFillScanlineStack(int x, int y, int newColor, int oldColor)
{
  if(oldColor == newColor) return;
  emptyStack();

  int x1;
  bool spanAbove, spanBelow;

  if(!push(x, y)) return;

  while(pop(x, y))
  {
    x1 = x;
    while(x1 >= 0 && screenBuffer[y][x1] == oldColor) x1--;
    x1++;
    spanAbove = spanBelow = 0;
    while(x1 < w && screenBuffer[y][x1] == oldColor )
    {
      screenBuffer[y][x1] = newColor;
      if(!spanAbove && y > 0 && screenBuffer[y - 1][x1] == oldColor)
      {
        if(!push(x1, y - 1)) return;
        spanAbove = 1;
      }
      else if(spanAbove && y > 0 && screenBuffer[y - 1][x1] != oldColor)
      {
        spanAbove = 0;
      }
      if(!spanBelow && y < h - 1 && screenBuffer[y + 1][x1] == oldColor)
      {
        if(!push(x1, y + 1)) return;
        spanBelow = 1;
      }
      else if(spanBelow && y < h - 1 && screenBuffer[y + 1][x1] != oldColor)
      {
        spanBelow = 0;
      }
      x1++;
    }
  }
}
    ============================================================================================================================================================================================================================

    */
    partial class MatrixOperations
    {
        public void FloodFillOrSeedFillAlgorithmTest()
        {
            int[,] squareMatrix =   {   { 1, 0, 0, 1, 1 },
                                        { 1, 0, 0, 1, 1 },
                                        { 1, 1, 1, 0, 0 },
                                        { 0, 0, 1, 0, 1 },
                                        { 1, 1, 1, 0, 1 },
                                        { 0, 0, 0, 1, 0 }};

            int arrayRank = squareMatrix.Rank;

            StringBuilder strBlrd = new StringBuilder();
            strBlrd.Append("Input Matrix : \n");

            for (int rIndx = 0; rIndx < squareMatrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < squareMatrix.GetLength(1); cIndx++)
                {
                    strBlrd.Append(squareMatrix[rIndx, cIndx] + "\t");
                }
                strBlrd.Append("\n");
            }

            strBlrd.Append("Test 1 : \n");

            int affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 5, 3);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int rIndx = 0; rIndx < squareMatrix.GetLength(0); rIndx++)
            {
                for (int cIndx = 0; cIndx < squareMatrix.GetLength(1); cIndx++)
                {
                    strBlrd.Append(squareMatrix[rIndx, cIndx] + "\t");
                }
                strBlrd.Append("\n");
            }

            Console.WriteLine(strBlrd.ToString());
            strBlrd.Append("Test 2 : \n");

            affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 3, 4);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            strBlrd.Append("Test 3 : \n");

            affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 0, 3);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            strBlrd.Append("Test 4 : \n");

            affectedCellCnt = FloodFillOrSeedFillAlgorithm(squareMatrix, 0, 0);
            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            MessageBox.Show(strBlrd.ToString());
        }

        int FloodFillOrSeedFillAlgorithm(int[,] matrix, int rIndx, int cIndx)
        {
            try
            {
                // Base conditions.
                if (matrix == null || rIndx < 0 || cIndx < 0 || rIndx >= matrix.GetLength(0) || cIndx >= matrix.GetLength(1))
                {
                    return 0;
                }

                if (matrix[rIndx, cIndx] != 1)
                {
                    return 0;
                }

                // Just fill
                matrix[rIndx, cIndx] = 2;

                // Visit east, west, north and south
                int visitLeft = FloodFillOrSeedFillAlgorithm(matrix, rIndx - 1, cIndx);      // West
                int visitRight = FloodFillOrSeedFillAlgorithm(matrix, rIndx + 1, cIndx);     // East 
                int visitTop = FloodFillOrSeedFillAlgorithm(matrix, rIndx, cIndx - 1);       // North
                int visitBottom = FloodFillOrSeedFillAlgorithm(matrix, rIndx, cIndx + 1);    // South

                return 1 + visitLeft + visitRight + visitTop + visitBottom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception raised " + ex.Message + "\n" + ex.StackTrace);
                return -1;
            }
        }

        void FloodFillIterative()
        {
            /*            bool M[128,128];  // adjacency matrix (can have at most 128 vertices)     bool seen[128];   // which vertices have been visited     int n;   // number of vertices         // ... Initialize M to be the adjacency matrix     queue<int> q;  // The BFS queue to represent the visited set     int s = 0;     // the source vertex     
            CPSC 490 Graph Theory: DFS andBFS 
                // BFS flood­fill     for( int v = 0; v < n; v++ ) seen[v] = false;   // set all vertices to be "unvisited"     seen[s] = true;     DoColouring( s, some_color );     q.push( s );
                while (!q.empty() ) {         int u = q.front();  // get first un­touched vertex         q.pop();         for( int v = 0; v < n; v++ ) if( !seen[v] && M[u,v] ) {             seen[v] = true;             DoColouring( v, some_color );             q.push( v );         }     }
                */
        }

        //Assume array is 100 X 100. Some logic optimization.

        void FillMatrix(int[,] matrix, int rIndx, int cIndx)
        {
            try
            {
                if (matrix[rIndx,cIndx] == 1)
                {
                    return;
                }

                matrix[rIndx,cIndx] = 2;

                if (rIndx < 99 && matrix[rIndx + 1,cIndx] != 1)
                {
                    FillMatrix(matrix, rIndx + 1, cIndx);
                }
                if (rIndx > 0 && matrix[rIndx - 1,cIndx] != 1)
                {
                    FillMatrix(matrix, rIndx - 1, cIndx);
                }
                if (cIndx < 99 && matrix[rIndx,cIndx + 1] != 1)
                {
                    FillMatrix(matrix, rIndx, cIndx + 1);
                }
                if (cIndx > 0 && matrix[rIndx,cIndx - 1] != 1)
                {
                    FillMatrix(matrix, rIndx, cIndx - 1);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong : " + exception.Message + "\n" + exception.StackTrace.ToString());
            }
        }

        void floodFill4Stack(int[,] matrix, int x, int y, int newColor, int oldColor)
        {
            if (newColor == oldColor) return; //avoid infinite loop

            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();


            int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 }; // relative neighbor x coordinates
            int[] dy = { -1, -1, 0, 1, 1, 1, 0, -1 }; // relative neighbor y coordinates

            stack.Push(new Tuple<int, int>(x, y));

            while (stack.Count > 0)
            {
                Tuple<int, int> tpl = stack.Pop();

                x = tpl.Item1;
                y = tpl.Item2;
                
                matrix[y ,x] = newColor;

                for (int i = 0; i < 8; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (nx > 0 && nx < matrix.GetLength(0) && ny > 0 && ny < matrix.GetLength(1) && matrix[ny,nx] == oldColor)
                    {
                        stack.Push(new Tuple<int, int>(nx, ny));
                    }
                }
            }
        }

        class Point
        {
            public int rIndx;
            public int cIndx;

            public Point(int rIndx, int cIndx)
            {
                this.rIndx = rIndx;
                this.cIndx = cIndx;
            }
        }

        public void FloodFillIterativeStack(int[,] matrix, int rIndx, int cIndx, int newColor, int oldColor)
        {
            if (newColor == oldColor)
                return;

            Stack<Point> stack = new Stack<Point>();

            int[] drIndx = { 0, 1, 1, 1, 0, -1, -1, -1 };
            int[] dcIndx = { -1, -1, 0, 1, 1, 1, 0, -1 };

            stack.Push(new Point(rIndx, cIndx));

            while (stack.Count > 0)
            {
                Point p = stack.Pop();

                for (int indx = 0; indx < 8; indx++)
                {
                    int trIndx = rIndx + drIndx[indx];
                    int tcIndx = cIndx + dcIndx[indx];

                    if (IsValidCell(matrix, trIndx, tcIndx))
                    {
                        stack.Push(new Point(trIndx, tcIndx));
                    }
                }
            }
        }

        private bool IsValidCell(int[,] matrix, int trIndx, int tcIndx)
        {
            throw new NotImplementedException();
        }
    }
}