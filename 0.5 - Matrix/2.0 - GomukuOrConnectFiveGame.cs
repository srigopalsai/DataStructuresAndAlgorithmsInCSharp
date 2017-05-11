using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
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
    partial class MatrixOperations
    {
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

            int affectedCellCnt =  IsWinnerOfTheGame(squareMatrix, 3, 4, valueToFind);
            
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