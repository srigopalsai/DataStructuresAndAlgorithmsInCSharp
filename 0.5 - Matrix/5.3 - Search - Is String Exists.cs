using System;

namespace DataStructuresAndAlgorithms
{
    partial class MatrixOperations
    {
        public void IsStringExistsInMatrixTest()
        {
            char[,] stringMatrix1 = {{'A','C','P','R','C'},
                                    {'X','S','O','P','C'},
                                    {'V','O','V','N','I'},
                                    {'W','G','F','M','N'},
                                    {'Q','A','T','I','T'}};

            char[,] stringMatrix2 = {{'Y','A','A','O'},
                                     {'A','O','A','O'},
                                     {'Y','A','O','O'},
                                     {'H','A','A','O'},
                                     {'Y','A','H','O'}};

            string str2Find1 = "MICROSOFT";
            string str2Find2 = "YAHOO";

            char[] charArr2Find = str2Find1.ToCharArray();
            bool IsStringExists = IsStringExistsInMatrix(stringMatrix1, charArr2Find, 0, 0, 0);

        }

        //Assume array is 100 X 100. Some logic optimization.
        bool IsStringExistsInMatrix(char[,] squareMatrix, char[] charArr2Find, int nextCharPos, int xPosition, int yPosition)
        {
            try
            {
                if (squareMatrix[xPosition, yPosition] == 1)
                {
                    return false;
                }
                squareMatrix[xPosition, yPosition] = '2';

                if (xPosition < 99 && squareMatrix[xPosition + 1, yPosition] != 1)
                {
                    IsStringExistsInMatrix(squareMatrix, charArr2Find, 0, xPosition + 1, yPosition);
                }
                if (xPosition > 0 && squareMatrix[xPosition - 1, yPosition] != 1)
                {
                    IsStringExistsInMatrix(squareMatrix, charArr2Find, 0, xPosition - 1, yPosition);
                }
                if (yPosition < 99 && squareMatrix[xPosition, yPosition + 1] != 1)
                {
                    IsStringExistsInMatrix(squareMatrix, charArr2Find, 0, xPosition, yPosition + 1);
                }
                if (yPosition > 0 && squareMatrix[xPosition, yPosition - 1] != 1)
                {
                    IsStringExistsInMatrix(squareMatrix, charArr2Find, 0, xPosition, yPosition - 1);
                }
                return false;
            }
            catch (Exception exception)
            {
                throw new Exception("Something went wrong : " + exception.Message + "\n" + exception.StackTrace.ToString());
            }
        }
    }
}