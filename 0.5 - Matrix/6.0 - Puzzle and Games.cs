using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    http://en.wikipedia.org/wiki/Fifteen_puzzle
    http://en.wikipedia.org/wiki/Sliding_puzzle
    http://en.wikipedia.org/wiki/Rubik%27s_Cube
    
    15-puzzle 
    Also called 
    1. Gem Puzzle 
    2. Boss Puzzle
    3. Game of Fifteen
    4. Mystic Square and many others) is a sliding puzzle
    
    Description: 15 of the 16 positions in a 4*4 matrix are filled by tiles, leaving one unfilled hole. Tiles adjoining the hole can be shifted into the hole, the object being to form some particular permutation of the tiles (typically forming a picture out of fragments printed on the tiles). 
    Status: this is a finite problem, but can easily be generalized to n*n matrices. Testing whether a solution exists is in P but finding the solution with the fewest moves is NP-complete.

    SudokuPuzzle

    S-O-S
    Two or more players no need to use the same char every time.
    http://en.wikipedia.org/wiki/SOS_(game)

    Concurrency https://www.youtube.com/watch?v=GNiHaKatuJc

    http://en.wikipedia.org/wiki/Tic-tac-toe
    
    Tricks:
    http://www.wikihow.com/Win-at-Tic-Tac-Toe
    */

    /*

===================================================================================================================================================================================================
Problem:

Consider a rat in a maze. There is only one entry and one exit. 
There are blocks in its path and it can easily take a wrong route or long route. Find a shortest path from the entry to the exit.

Solution:

The maze can be viewed as a two dimensional array with 1's in paths that can be taken and 0's in paths that cannot be taken.
The best solution can be achieved using backtracking

_|_|_|_|_|#|_|_|_|_|

_|_|#|_|#|_|_|_|#|#|

_|#|_|_|_|#|#|#|_|#|

_|#|_|_|_|#|_|_|#|_|

#|_|#|#|_|_|_|_|_|_|

#|_|_|_|_|_|_|#|_|_|

#|_|_|#|_|_|_|_|_|_|

#|_|_|_|_|_|_|_|#|_|

_|_|_|#|_|#|#|_|_|#|

#|#|#|#|_|#|_|_|_|_|

Shortest path : (0,1),(0,2),(0,3),(1,3),(2,3),(2,4),(3,4),(4,4),(4,5),(4,6),(5,6),(6,6),(6,7),(7,7),(8,7),(8,8),(9,8),(9,9)

Analysis & Approach :

1. Use BFS - breadth first traversal. 
2. Mark the entry point as 1, then all the accessible cells from 1 mark as 2. 
3. Then all the accessible cells from 2 that are not already marked are marked as 3. 
4. In this way any cell that is accessible from n marked node and not already marked are marked as n+1. 
5. In this way when the exit cell is marked. We find the shortest path.

1. Now to reconstruct the path we start from exit. 
2. Note its mark n and any adjacent cell that has marked with  n-1 is the previous cell. 
3. Now we add previous cell in the path and search for n-2 in its adjacent cells. 
4. In this way when we reach the entry cell our path is constructed.



Refernce Links :
http://algorithms.tutorialhorizon.com/backtracking-rat-in-a-maze-puzzle/
http://www.dsalgo.com/2013/02/find-shortest-path-in-maze.html

===================================================================================================================================================================================================
*/
    public partial class MatrixOperations
    {
        int[] pathRowArray;
        int[] pathColArray;
        int pathRowIndex = -1;
        int pathColIndex = -1;
        int mazeRowLenght = 0;
        int mazeColLenght = 0;

        public string RunMazePuzzle()
        {
            int[,] mazeArray = new int[4, 4];
            //1. Create Maze
            for (int lpRowCnt = 0; lpRowCnt < mazeArray.GetLength(0); lpRowCnt++)
            {
                for (int lpColCnt = 0; lpColCnt < mazeArray.GetLength(1); lpColCnt++)
                {
                    if (lpColCnt == 0 || lpRowCnt == (mazeArray.GetLength(0) - 1))
                    {
                        mazeArray[lpRowCnt, lpColCnt] = 1;
                    }
                    else
                    {
                        mazeArray[lpRowCnt, lpColCnt] = 0;
                    }
                }
            }

            int totalLenght = mazeArray.Length;
            pathRowArray = new int[totalLenght];
            pathColArray = new int[totalLenght];
            //for (int lpCnt = 0; lpCnt < totalLenght; lpCnt++)
            //{
            //    pathRowArray[lpCnt] = -1;
            //    pathColArray[lpCnt] = -1;
            //}
            //2. Fnd the path.
            FindPathForRat(mazeArray, 0, 0);

            StringBuilder resultString = new StringBuilder();
            //3. Display the path
            for (int lpCnt = 0; lpCnt < pathRowArray.Length; lpCnt++)
            {
                resultString.Append(pathRowArray[lpCnt] + " " + pathRowArray[lpCnt] + "\n");
            }

            return Convert.ToString(resultString);
        }

        void FindPathForRat(int[,] mazeArray, int mazeRowIndex, int mazeColIndex)
        {
            if (mazeRowIndex < mazeArray.GetLength(0) && mazeColIndex < mazeArray.GetLength(1))
            {
                if (mazeArray[mazeRowIndex, mazeColIndex] == 1)
                {
                    //Then there is a path, store it in another pathArray.
                    pathRowArray[++pathRowIndex] = mazeRowIndex;
                    pathColArray[++pathColIndex] = mazeColIndex;

                    //Reached exit only for colum of maze. Move to next row.
                    if (mazeColIndex == (mazeArray.GetLength(1) - 1))
                    {
                        FindPathForRat(mazeArray, ++mazeRowIndex, mazeColIndex);
                    }
                    //Reached exit only for row of maze. Move to next column.
                    else if (mazeRowIndex == (mazeArray.GetLength(0) - 1))
                    {
                        FindPathForRat(mazeArray, mazeRowIndex, ++mazeColIndex);
                    }
                    //Not reached exit for both row and colum of maze.
                    else
                    {
                        FindPathForRat(mazeArray, mazeRowIndex, ++mazeColIndex);
                        FindPathForRat(mazeArray, ++mazeRowIndex, mazeColIndex);
                    }
                }
                else
                {
                    pathRowArray[++pathRowIndex] = -1;
                    pathColArray[++pathColIndex] = -1;

                    FindPathForRat(mazeArray, mazeRowIndex, ++mazeColIndex);
                    FindPathForRat(mazeArray, ++mazeRowIndex, mazeColIndex);
                }
            }
            //Reached exit for both row and colum of maze. Can print the collected path.
            if (mazeRowIndex == mazeRowLenght - 1 && mazeColIndex == mazeColLenght - 1)
            {
                //                Environment.Exit(0);
            }


        }

        /*
 public class RatInMaze {



	public int[][] solution;



	//initialize the solution matrix in constructor.

	public RatInMaze(int N) {

		solution = new int[N][N];

		for (int i = 0; i < N; i++) {

			for (int j = 0; j < N; j++) {

				solution[i][j] = 0;

			}

		}

	}



	public void solveMaze(int[][] maze, int N) {

		if (findPath(maze, 0, 0, N, "down")) {

			print(solution, N);

		}else{

			Console.WriteLine("NO PATH FOUND");

		}

		

	}



	public boolean findPath(int[][] maze, int x, int y, int N, String direction) {

		// check if maze[x][y] is feasible to move

		if(x==N-1 && y==N-1){//we have reached

			solution[x][y] = 1;

			return true;

		}

		if (isSafeToGo(maze, x, y, N)) {

			// move to maze[x][y]

			solution[x][y] = 1;			

			// now rat has four options, either go right OR go down or left or go up

			if(direction!="up" && findPath(maze, x+1, y, N, "down")){ //go down

				return true;

			}

			//else go down

			if(direction!="left" && findPath(maze, x, y+1, N,"right")){ //go right

				return true;

			}

			if(direction!="down" && findPath(maze, x-1, y, N, "up")){ //go up

				return true;

			}

			if(direction!="right" &&  findPath(maze, x, y-1, N, "left")){ //go left

				return true;

			}

			//if none of the options work out BACKTRACK undo the move

			solution[x][y] = 0;

			return false;

		}

		return false;

	}



	// this function will check if mouse can move to this cell

	public boolean isSafeToGo(int[][] maze, int x, int y, int N) {

		// check if x and y are in limits and cell is not blocked

		if (x >= 0 && y >= 0 && x < N  && y < N && maze[x][y] != 0) {

			return true;

		}
		return false;
	}

	public void print(int [][] solution, int N){

		for (int i = 0; i < N; i++) {

			for (int j = 0; j < N; j++) {

				System.out.print(" " + solution[i][j]);
			}
			Console.WriteLine();
		}
	}

	public static void main(String[] args) {

		int N = 5;
		int[][] maze = { { 1, 0, 1, 1,1 }, { 1, 1, 1, 0,1 }, { 0, 0,0, 1, 1 },

				{ 0, 0, 0, 1,0 },{ 0, 0,0, 1, 1 } };
		RatInMaze r = new RatInMaze(N);
		r.solveMaze(maze, N);
	}
}
 =================================================================================================================================
public class ShortestPathInMaze
{
 public static void main(String[] args)
 {
  boolean[][] maze = new boolean[10][10];
  makeRandomMaze(maze);
  printMaze(maze);
  List path = findShortestPath(maze);
  if (path == null)
  {
   Console.WriteLine("No path possible");
   return;
  }
  for (Cell cell : path)
   System.out.print(cell + ",");
 }

 private static List findShortestPath(boolean[][] maze)
 {
  int[][] levelMatrix = new int[maze.length][maze[0].length];
  for (int i = 0; i < maze.length; ++i)
   for (int j = 0; j < maze[0].length; ++j)
   {
    levelMatrix[i][j] = maze[i][j] == true ? -1 : 0;
   }
  LinkedList queue = new LinkedList();
  Cell start = new Cell(0, 0);
  Cell end = new Cell(maze.length - 1, maze[0].length - 1);
  queue.add(start);
  levelMatrix[start.row][start.col] = 1;
  while (!queue.isEmpty())
  {
   Cell cell = queue.poll();
   if (cell == end)
    break;
   int level = levelMatrix[cell.row][cell.col];
   Cell[] nextCells = new Cell[4];
   nextCells[3] = new Cell(cell.row, cell.col - 1);
   nextCells[2] = new Cell(cell.row - 1, cell.col);
   nextCells[1] = new Cell(cell.row, cell.col + 1);
   nextCells[0] = new Cell(cell.row + 1, cell.col);

   for (Cell nextCell : nextCells)
   {
    if (nextCell.row < 0 || nextCell.col < 0)
     continue;
    if (nextCell.row == maze.length
      || nextCell.col == maze[0].length)
     continue;
    if (levelMatrix[nextCell.row][nextCell.col] == 0)
    {
     queue.add(nextCell);
     levelMatrix[nextCell.row][nextCell.col] = level + 1;
    }
   }
  }
  if (levelMatrix[end.row][end.col] == 0)
   return null;
  LinkedList path = new LinkedList();
  Cell cell = end;
  while (!cell.equals(start))
  {
   path.push(cell);
   int level = levelMatrix[cell.row][cell.col];
   Cell[] nextCells = new Cell[4];
   nextCells[0] = new Cell(cell.row + 1, cell.col);
   nextCells[1] = new Cell(cell.row, cell.col + 1);
   nextCells[2] = new Cell(cell.row - 1, cell.col);
   nextCells[3] = new Cell(cell.row, cell.col - 1);
   for (Cell nextCell : nextCells)
   {
    if (nextCell.row < 0 || nextCell.col < 0)
     continue;
    if (nextCell.row == maze.length
      || nextCell.col == maze[0].length)
     continue;
    if (levelMatrix[nextCell.row][nextCell.col] == level - 1)
    {
     cell = nextCell;
     break;
    }
   }
  }
  return path;
 }

 private static class Cell
 {
  public int row;
  public int col;

  public Cell(int row, int column)
  {
   this.row = row;
   this.col = column;
  }

  @Override
  public boolean equals(Object obj)
  {
   if (this == obj)
    return true;
   if ((obj == null) || (obj.getClass() != this.getClass()))
    return false;
   Cell cell = (Cell) obj;
   if (row == cell.row && col == cell.col)
    return true;
   return false;
  }

  @Override
  public String toString()
  {
   return "(" + row + "," + col + ")";
  }
 }

 private static void printMaze(boolean[][] maze)
 {
  for (int i = 0; i < maze.length; ++i)
  {
   for (int j = 0; j < maze[i].length; ++j)
   {
    if (maze[i][j])
     System.out.print("#|");
    else
     System.out.print("_|");
   }
   Console.WriteLine();
  }
 }

 private static void makeRandomMaze(boolean[][] maze)
 {
  for (int i = 0; i < maze.length; ++i)
  {
   for (int j = 0; j < maze[0].length; ++j)
   {
    maze[i][j] = (int) (Math.random() * 3) == 1;
   }
  }
  maze[0][0] = false;
  maze[maze.length - 1][maze[0].length - 1] = false;

 }
}

*/
        class GameOf15
        {
        }

        /*
        ============================================================================================================================================================================================================================

        http://en.wikipedia.org/wiki/Gomoku
        http://en.wikipedia.org/wiki/Go_(game)

         *  Similar to Tic-Tac-Toe Game. Called as Connect Five or Connect 5.
         *  A 19 X 19 Grid matrix and 2 players will play one after the other eigther whites (E.g. 1's ) or Blacks (E.g. 0's)
         *  Who places 5 consecutive 1's or 0 first ( Horizontal, Vertical or Diagnal ) is the winner.
         *  Generally who start the game first most likely the winner.

        Similar Games:

        M,N,K Game:
        http://en.wikipedia.org/wiki/M,n,k-game     
        Connect 6:
        http://en.wikipedia.org/wiki/Connect6
        Renju:
        http://en.wikipedia.org/wiki/Renju

        ============================================================================================================================================================================================================================
        */

        bool isRowBackwardVisited = false;
        bool isColBackwardVisited = false;

        bool isRowForwardVisited = false;
        bool isColForwardVisited = false;

        bool isForwardDiagnalVisited = false;
        bool isBackwardDiagnalVisited = false;

        public int IsWinnerOfTheGame(int[,] matrix, int rowPos, int colPos, int valueToFind)
        {
            // Step 1. Base Case Conditions. Do not enter or Do Nothing if any of these negative conditions are true.
            if (matrix == null || rowPos < 0 || rowPos >= matrix.GetLength(0) || colPos < 0 || colPos >= matrix.GetLength(1))
            {
                return 0;
            }

            // Step 2. Check if the valueTo matches the current cell and if the cell is already visited.
            if (matrix[rowPos, colPos] != valueToFind || matrix[rowPos, colPos] == 5)
            {
                return 0;
            }

            else if (matrix[rowPos, colPos] != 5)
            {
                // Step 3. Mark the cell as visited. So that we will not consider it next time.
                matrix[rowPos, colPos] = 5;

                int wonRowBCellCnt = 0;
                int wonRowFCellCnt = 0;

                int wonColBCellCnt = 0;
                int wonColFCellCnt = 0;

                int wonTDFCellCnt = 0;
                int wonTDBCellCnt = 0;

                // Step 4. Row Back Tracking. Recursively visit back to top cells.
                if (isRowBackwardVisited == false)
                {
                    wonRowBCellCnt += (1 + IsWinnerOfTheGame(matrix, rowPos - 1, colPos, valueToFind));
                }
                // Step 5. Row Forward Search. Recursively visit down to bottom cells.
                if (wonRowBCellCnt < 5 && isRowForwardVisited == false)
                {
                    isRowBackwardVisited = true;
                    wonRowFCellCnt += (1 + IsWinnerOfTheGame(matrix, rowPos + 1, colPos, valueToFind));
                }

                // Step 6. Column Back Tracking. Recursively visit back to left cells.
                if (wonRowFCellCnt < 5 && isColBackwardVisited == false)
                {
                    isRowForwardVisited = true;
                    wonColBCellCnt += (1 + IsWinnerOfTheGame(matrix, rowPos, colPos - 1, valueToFind));
                }

                // Step 7. Column Forward Search. Recursively visit front to forward cells.
                if (wonColBCellCnt < 5 && isColForwardVisited == false)
                {
                    isColBackwardVisited = true;
                    wonColFCellCnt += (1 + IsWinnerOfTheGame(matrix, rowPos, colPos + 1, valueToFind));
                }

                // Step 8. Top Down Forward Diagnal (\) Search. Recursively visit row + 1 and col + 1.
                if (wonColFCellCnt < 5 && isForwardDiagnalVisited == false)
                {
                    isColForwardVisited = true;
                    wonTDFCellCnt += (1 + IsWinnerOfTheGame(matrix, rowPos + 1, colPos + 1, valueToFind));
                }

                // Step 9. Top Down Backward Diagnal (/) Search. Recursively visit row - 1 and col - 1.
                if (wonTDFCellCnt < 5 && isBackwardDiagnalVisited == false)
                {
                    isForwardDiagnalVisited = true;
                    wonTDBCellCnt += (1 + IsWinnerOfTheGame(matrix, rowPos - 1, colPos - 1, valueToFind));
                }
            }

            // TODO - Yet to implement.
            // Step 10. Bottom Up Forward Diagnal (\) Search.
            // Step 11. Bottom Up Backward Diagnal (/) Search.

            // Step 12. Return the result.

            //if (wonRBCellCnt == 5)
            //{
            //    return wonRBCellCnt;
            //}
            //else if (wonRFCellCnt == 5)
            //{
            //    return wonRFCellCnt;
            //}
            //else if (wonCBCellCnt == 5)
            //{
            //    return wonCBCellCnt;
            //}
            //else if (wonCFCellCnt == 5)
            //{
            //    return wonCFCellCnt;
            //}

            //else if (wonTDFCellCnt == 5)
            //{
            //    return wonTDFCellCnt;
            //}
            //else if (wonTDBCellCnt == 5)
            //{
            //    return wonTDBCellCnt;
            //}
            return 0;
        }

        public void GomukuOrConnectFiveGameTest()
        {
            //                          0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18
            int[,] squareMatrix =   { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2}, // 0
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2, 0}, // 1
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0}, // 2
                                      { 0, 0, 0, 0, 2, 2, 2, 2, 2, 0, 0, 0, 1, 0, 0, 2, 0, 0, 0}, // 3
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 0}, // 4
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 5
                                      { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6
                                      { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0}, // 7
                                      { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0}, // 8
                                      { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0}, // 9
                                      { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0}, // 10
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0}, // 11
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 13
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 15
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 17
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1}};// 18

            StringBuilder strBlrd = new StringBuilder();
            strBlrd.Append("Input Matrix : \n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            strBlrd.Append("Test 1 : \n");

            // To find the player, we can move this logic outside.
            int valueToFind = squareMatrix[3, 4];

            isRowForwardVisited = false;
            isColForwardVisited = false;

            isRowBackwardVisited = false;
            isColBackwardVisited = false;

            isForwardDiagnalVisited = false;
            isBackwardDiagnalVisited = false;

            int affectedCellCnt = IsWinnerOfTheGame(squareMatrix, 3, 4, valueToFind);

            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            strBlrd.Append("Test 2 : \n");
            valueToFind = squareMatrix[0, 9];

            isRowForwardVisited = false;
            isColForwardVisited = false;

            isRowBackwardVisited = false;
            isColBackwardVisited = false;

            isForwardDiagnalVisited = false;
            isBackwardDiagnalVisited = false;

            affectedCellCnt = IsWinnerOfTheGame(squareMatrix, 0, 9, valueToFind);

            strBlrd.Append("\nNo of Cells Affected Cells : " + affectedCellCnt + "\n");

            for (int lpRCnt = 0; lpRCnt < squareMatrix.GetLength(0); lpRCnt++)
            {
                for (int lpCCnt = 0; lpCCnt < squareMatrix.GetLength(1); lpCCnt++)
                {
                    strBlrd.Append(squareMatrix[lpRCnt, lpCCnt] + "\t");
                }
                strBlrd.Append("\n");
            }

            //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            MessageBox.Show(strBlrd.ToString());
        }
    }
}
/*
Description: This ancient game is played by placing stones on a 19*19 board. 
When a group of stones of one color is completely surrounded by stones of the other color, the surrounded group is removed from the board. 
The object is to control empty squares by surrounding them; after both players are unwilling to continue play, these squares are counted and the scores adjusted by the numbers of stones that had been removed. 

Status: 
This is a finite game, but can be generalized to n*n boards. 
Even without ko (special rules related to repetition of positions) the game is PSPACE-hard; with ko (Japanese rules) it is EXPTIME-complete. 
It is apparently still open whether Chinese or US rules Go is EXPTIME-complete. 
Even certain "simple" endgames in which the go board has been decomposed into many small independent regions of play are PSPACE-hard.
*/