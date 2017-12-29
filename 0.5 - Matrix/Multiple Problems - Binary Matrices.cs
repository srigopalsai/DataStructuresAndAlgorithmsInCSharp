using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms._0._5___Matrix
{
    class Multiple_Problems___Binary_Matrices
    {
        public class Node
        {
            public Node right;
            public Node left;
            public int Val;
            public Node(int val)
            {
                Val = val;
            }
        }

        // https://www.geeksforgeeks.org/print-unique-rows/
        private void PrintUniqueRows(int[,] matrix)
        {
            Node root = new Node(-1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Node node = root;
                bool isUnique = false;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        if (isUnique = node.left == null)
                        {
                            node.left = new Node(matrix[i, j]);
                        }

                        node = node.left;
                    }
                    else
                    {
                        if (isUnique = node.right == null)
                        {
                            node.right = new Node(matrix[i, j]);
                        }
                        node = node.right;
                    }
                }

                if (!isUnique)
                {
                    continue;
                }

                Console.WriteLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine(matrix[i, j] + " ");
                }
            }
        }

        public static void printMat(int[,] a, int r, int c)
        {
            Dictionary<String, int> map = new Dictionary<String, int>();
            List<String> list = new List<String>();

            for (int i = 0; i < r; i++)
            {
                String s = "";

                for (int j = 0; j < c; j++)
                {
                    s += String.valueOf(a[i,j]);
                }

                String k = s;

                if (!list.Contains(s))
                {
                    list.Add(k);
                }
                if (!map.ContainsKey(k))
                {
                    map[k] = 1;
                }
                else
                {
                    int count = map[k];
                    map[k] = count + 1; ;
                }
            }

            for (int i = 0; i < list.Count(); i++)
            {

                String f = list[i];

                for (int j = 0; j < f.Length; j++)
                {
                    Console.WriteLine(f[j] + " ");
                }

                Console.Write("$");
            }
        }
/*
        //https://www.geeksforgeeks.org/maximum-size-sub-matrix-with-all-1s-in-a-binary-matrix/
        //Given a binary matrix, find out the maximum size square sub-matrix with all 1s. 
        //Algorithm:

        //    Let the given binary matrix be M[R][C]. 
        //    The idea of the algorithm is to construct an auxiliary size matrix S[][] in which each entry S[i][j] represents size of the square sub-matrix 
        //    with all 1s including M[i][j] where M[i][j] is the rightmost and bottommost entry in sub-matrix.
         

        // method for Maximum size square sub-matrix with all 1s
        static void printMaxSubSquare(int M[][])
        {
            int i, j;
            int R = M.length;         //no of rows in M[][]
            int C = M[0].length;     //no of columns in M[][]
            int S[][] = new int[R][C];     
         
            int max_of_s, max_i, max_j; 
       
//             Set first column of S[][]
            for(i = 0; i<R; i++)
                S[i][0] = M[i][0];
       
            // Set first row of S[][]   
            for(j = 0; j<C; j++)
                S[0][j] = M[0][j];
           
             //Construct other entries of S[][]
            for(i = 1; i<R; i++)
            {
                for(j = 1; j<C; j++)
                {
                    if(M[i][j] == 1) 
                        S[i][j] = Math.min(S[i][j - 1], Math.min(S[i - 1][j], S[i - 1][j - 1])) + 1;
                    else
                        S[i][j] = 0;
                }
            }

             //Find the maximum entry, and indexes of maximum entry 
             //    in S[][] 
        max_of_s = S[0][0]; max_i = 0; max_j = 0;
                    for(i = 0; i<R; i++)
                    {
                        for(j = 0; j<C; j++)
                        {
                            if(max_of_s<S[i][j])
                            {
                                max_of_s = S[i][j];
                                max_i = i; 
                                max_j = j;
                            }        
                        }                 
                    }     
        
                    System.out.println("Maximum size sub-matrix is: ");
                    for(i = max_i; i > max_i - max_of_s; i--)
                    {
                        for(j = max_j; j > max_j - max_of_s; j--)
                        {
                            System.out.print(M[i][j] + " ");
                        }  
                        System.out.println();
                    }  
            }    */
    }
}