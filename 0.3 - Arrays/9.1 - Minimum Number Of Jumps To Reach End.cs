using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================
    
    Given an array of integers where each element represents the max number of steps that can be made forward from that element. 
    Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element). 
    If an element is 0, then cannot move through that element.
    
    Input: arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
    Output: 3 (1-> 3 -> 8 ->9)
    
    First element is 1, so can only go to 3. Second element is 3, so can make at most 3 steps eg to 5 or 8 or 9.

    References :
    http://stackoverflow.com/questions/23301358/linear-time-algorithm-for-minimum-number-of-jumps-required-to-reach-end
    
    ===================================================================================================================================================================================================
    */
    partial class ArraySamples
    {
        public void MinimumNumberOfJumpsToReachEndTest()
        { 
            //int[] arr = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9};
            int[] arr = { 1, 1, 2, 3, 1, 4 };

            stringBldr.Clear();
            stringBldr.AppendLine("Source Array");
            
            for (int lpCnt = 0; lpCnt < arr.Length; lpCnt++)
            {
                stringBldr.Append("  " + arr[lpCnt]);
            }
            stringBldr.AppendLine(" No of Jums : ");

            //MinimumNumberOfJumpsToReachEnd(arr, 0, arr.Length);
            int rslt = min_jumps(arr, arr.Length);
            MessageBox.Show(stringBldr.ToString() + rslt);
        }

        int min_jumps(int[] a, int size)
        {
            int lnrLpIndex = 0;
            int jmpLpIndex = 0;

            int max = 0;
            int totalJumpCount = 0;

            while ( lnrLpIndex < size )
            {
                totalJumpCount++;
                max = 0;

                for (jmpLpIndex = 0; jmpLpIndex < a[lnrLpIndex]; jmpLpIndex++)
                {
                    int maxVal = jmpLpIndex + a[jmpLpIndex];

                    if (max < maxVal)
                    {
                        max = maxVal;
                        //stringBldr.Append("  " +max);
                    }
                }
                if (max == 0)
                {
                    return Int32.MaxValue;
                }
                stringBldr.Append("  " +max);
                lnrLpIndex = lnrLpIndex + max;
            }
            return totalJumpCount;
        }

        // Returns minimum number of jumps to reach arr[h] from arr[l]
        public int MinimumNumberOfJumpsToReachEnd(int[] arr, int frontIndx, int rearIndx)
        {
            // Base case: when source and destination are same
            if (rearIndx == frontIndx)
            {
                return 0;
            }
            
            // When nothing is reachable from the given source
            if (arr[frontIndx] == 0)
            {
                return Int32.MaxValue;
            }
 
            // Traverse through all the points reachable from arr[l]. 
            // Recursively get the minimum number of jumps needed to reach arr[h] from these reachable points.
            int min = Int32.MaxValue;

            for (int lpCnt = frontIndx + 1; lpCnt <= rearIndx && ( lpCnt <= (frontIndx + arr[frontIndx])); lpCnt++)
            {
                // Recursive 
                int jumps = MinimumNumberOfJumpsToReachEnd(arr, lpCnt, rearIndx);
            
                if (jumps != Int32.MaxValue && jumps + 1 < min)
                {
                    min = jumps + 1;
                }
            }

            stringBldr.Append("  " + min);
            return min;
        }

//        int find_min_steps(int arr[], int n)
//{
//  // min_steps_dp[i] is an array which 
//  // indicate minimum jumps required to reach i. 
//  int min_steps_dp[20];
//  int i, temp, next_vacant;
//  // next_vacant : Is the index in the array whose min_steps needs to be updated
//  // in the next iteration.
//  next_vacant = 1;
//  for(i=0;i<n;min_steps_dp[i++] = 500);
//  // Minimum steps required to reach index 0 is 0
//  min_steps_dp[0]  = 0;
//  for(i=0;i<n && min_steps_dp[n-1] == 500;i++)
//  {
//    temp = i + arr[i];
//    printf(" temp : %d i: %d arr: %d\n",temp,i,arr[i]);
//    if(temp >= n)
//    {
//      min_steps_dp[n-1] = min(min_steps_dp[n-1], min_steps_dp[i] +1);
//    }
//    else
//    {
//      min_steps_dp[temp] = min(min_steps_dp[temp], min_steps_dp[i]+1);
//    }
//    if(temp>next_vacant)
//    {
//      for(;next_vacant<temp;next_vacant++)
//      {
//      // this loop executes only ONCE for each element in the array, so over the
//      // course of execution, is an O(n) loop only. The order of the outer loop still
//      // remains O(n).
//        min_steps_dp[next_vacant] = min(min_steps_dp[next_vacant],min_steps_dp[temp]);
//      }
//    }
//  }
//  for(i=0;i<n;i++)
//  {
//    printf("%d ",min_steps_dp[i]);
//  }
//  return min_steps_dp[n-1];
 
//}
//main()
//{
//  int arr[] = {1,3,5,8,9,2,6,7,6,8,9};
//  int len;
//  len = sizeof(arr)/sizeof(arr[0]);
//  printf("\n MIN steps : %d\n",find_min_steps(arr,len));
//}
    }
}