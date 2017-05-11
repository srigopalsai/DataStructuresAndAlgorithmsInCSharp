using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
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
        int mazeRowLenght=0;
        int mazeColLenght=0;

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