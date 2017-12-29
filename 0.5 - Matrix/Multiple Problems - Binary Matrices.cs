using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms._0._5___Matrix
{
    class Multiple_Problems___Binary_Matrices
    {
        /*
        // https://www.geeksforgeeks.org/print-unique-rows/
        private void printUnique(int[][] matrix)
        {
            Node root = new Node(-1);

            for (int i = 0; i < matrix.length; i++)
            {
                Node node = root;
                boolean isUnique = false;

                for (int j = 0; j < matrix[0].length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (isUnique = node.left == null) node.left = new Node(matrix[i][j]);
                        node = node.left;
                    }
                    else
                    {
                        if (isUnique = node.right == null) node.right = new Node(matrix[i][j]);
                        node = node.right;
                    }
                }
                if (!isUnique) continue;
                System.out.println();
                for (int j = 0; j < matrix[0].length; j++) System.out.print(matrix[i][j] + " ");
            }
        }

        public static void printMat(int a[][], int r, int c)
        {
            //add code here.

            Map<String, Integer> map = new HashMap<String, Integer>();
            ArrayList<String> list = new ArrayList<String>();
            for (int i = 0; i < r; i++)
            {
                String s = "";
                for (int j = 0; j < c; j++)
                {
                    s += String.valueOf(a[i][j]);
                }
                String k = s;
                if (!list.contains(s))
                {
                    list.add(k);
                }
                if (!map.containsKey(k))
                {
                    map.put(k, 1);
                }
                else
                {
                    int count = map.get(k);
                    map.put(k, count + 1);
                }
            }

            for (int i = 0; i < list.size(); i++)
            {

                String f = list.get(i);
                char[] ch = f.toCharArray();
                for (int j = 0; j < ch.length; j++)
                {
                    System.out.print(ch[j] + " ");
                }

                System.out.print("$");

            }
        }

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