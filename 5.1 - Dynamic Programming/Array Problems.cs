using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{ 
    partial class DynamicProgrammingSamplesArrays
    {
        /*
        Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. 
        E.g. 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers. 
        Note that 1 is typically treated as an ugly number, and n does not exceed 1690.
        */
        // http://www.geeksforgeeks.org/ugly-numbers/
        // 263 https://leetcode.com/problems/ugly-number

        // Divides num1 by Greatest Divisible Power of num2
        public int MaxDivide(int num1, int num2)
        {
            while (num1 % num2 == 0)
            {
                num1 = num1 / num2;
            }

            return num1;
        }

        public int IsUgly(int num)
        {
            num = MaxDivide(num, 2);
            num = MaxDivide(num, 3);
            num = MaxDivide(num, 5);

            return (num == 1) ? 1 : 0;
        }

        // Function to get the nth ugly number - Not time efficient
        public int GetNthUglyNo(int nthUgly)
        {
            int num = 1;
            int count = 1;

            while (count <= nthUgly)
            {
                num++;

                if (IsUgly(num) == 1)
                {
                    count++;
                }
            }

            return num;
        }

        public void UglyNumberTest()
        {
            int no = GetNthUglyNo(150);
            Console.WriteLine("150th ugly no. is " + no);
        }

        // DP O(n) space
        public int GetNthUglyNoDP(int n)
        {
            int[] uglyNums = new int[n];
            uglyNums[0] = 1;

            int nextUglyNo = 1;

            int num2Cntr = 0;
            int num3Cntr = 0;
            int num5Cntr = 0;

            int nextMultipleOf2 = 2;
            int nextMultipleOf3 = 3;
            int nextMultipleOf5 = 5;

            for (int num = 1; num < n; num++)
            {
                nextUglyNo = Math.Min(nextMultipleOf2,
                                Math.Min(nextMultipleOf3, nextMultipleOf5));

                uglyNums[num] = nextUglyNo;

                if (nextUglyNo == nextMultipleOf2)
                {
                    num2Cntr = num2Cntr + 1;
                    nextMultipleOf2 = uglyNums[num2Cntr] * 2;
                }
                if (nextUglyNo == nextMultipleOf3)
                {
                    num3Cntr = num3Cntr + 1;
                    nextMultipleOf3 = uglyNums[num3Cntr] * 3;
                }
                if (nextUglyNo == nextMultipleOf5)
                {
                    num5Cntr = num5Cntr + 1;
                    nextMultipleOf5 = uglyNums[num5Cntr] * 5;
                }
            } 
            return nextUglyNo;
        }

        //121 https://leetcode.com/problems/best-time-to-buy-and-sell-stock
        //================================================================================================================================

        public int MaxProfitI(int[] prices)
        {
            int maxCur = 0;
            int maxSoFar = 0;

            for (int indx = 1; indx < prices.Length; indx++)
            {
                maxCur += prices[indx] - prices[indx - 1];
                maxCur = Math.Max(0, maxCur);

                maxSoFar = Math.Max(maxCur, maxSoFar);
            }
            return maxSoFar;
        }

        //122 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii
        //================================================================================================================================

        public int MaxProfitII(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;

            int maxprofit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxprofit += prices[i] - prices[i - 1];
                }
            }
            return maxprofit;
        }

        // 123 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii
        public int MaxProfitIII(int[] prices)
        {
            int buy1 = Int32.MinValue;
            int buy2 = Int32.MinValue;

            int sell1 = 0;
            int sell2 = 0;

            foreach (int price in prices)
            {
                sell2 = Math.Max(sell2, buy2 + price);      // The maximum if we've just sold 2nd stock so far.
                buy2 = Math.Max(buy2, sell1 - price);       // The maximum if we've just buy  2nd stock so far.

                sell1 = Math.Max(sell1, buy1 + price);      // The maximum if we've just sold 1nd stock so far.
                buy1 = Math.Max(buy1, -price);              // The maximum if we've just buy  1st stock so far. 
            }

            return sell2; ///Since sell1 is initiated as 0, so sell2 will always higher than sell1.
        }

        // 309 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown
        //================================================================================================================================

        public int MaxProfitIV3(int[] prices)
        {
            if (prices.Length <= 1)
                return 0;

            int maxBuy = int.MinValue;
            int maxSell = 0;

            int prevMaxCooldown = 0;
            int maxCooldown = 0;

            for (int indx = 0; indx < prices.Length; indx++)
            {
                prevMaxCooldown = maxCooldown;
                maxCooldown = maxSell;

                maxSell = Math.Max(maxSell, maxBuy + prices[indx]);
                maxBuy = Math.Max(maxBuy, prevMaxCooldown - prices[indx]);
            }

            return maxSell;
        }


        public int MaxProfitIV(int k, int[] prices)
        {
            int priceLen = prices.Length;
            if (priceLen <= 1)
                return 0;

            //if k >= n/2, then you can make maximum number of transactions.
            if (k >= priceLen / 2)
            {
                int maxPro = 0;
                for (int indx = 1; indx < priceLen; indx++)
                {
                    if (prices[indx] > prices[indx - 1])
                    {
                        maxPro += prices[indx] - prices[indx - 1];
                    }
                }
                return maxPro;
            }

            int[,] dp = new int[k + 1, priceLen];

            for (int indx = 1; indx <= k; indx++)
            {
                int localMax = dp[indx - 1, 0] - prices[0];

                for (int j = 1; j < priceLen; j++)
                {
                    dp[indx, j] = Math.Max(dp[indx, j - 1], prices[j] + localMax);
                    localMax = Math.Max(localMax, dp[indx - 1, j] - prices[j]);
                }
            }

            return dp[k, priceLen - 1];
        }


        // DP & State Machine approach.
        public int MaxProfitIV2(int[] prices)
        {
            if (prices.Length <= 1)
                return 0;

            int sold = 0;
            int prvSold = 0;
            int hold = int.MinValue;
            int rest = 0;

            for (int indx = 0; indx < prices.Length; ++indx)
            {
                prvSold = sold;
                sold = hold + prices[indx];
                hold = Math.Max(hold, rest - prices[indx]);
                rest = Math.Max(rest, prvSold);
            }

            return Math.Max(sold, rest);
        }

        public int MaxProfitIV1(int[] prices)
        {
            int[] result = new int[prices.Length];
            int[] sell = new int[prices.Length];
            int diff = 0;

            for (int indx = 1; indx < prices.Length; indx++)
            {
                diff = prices[indx] - prices[indx - 1];
                sell[indx] = diff + Math.Max(sell[indx - 1], indx > 2 ? result[indx - 3] : 0);

                result[indx] = Math.Max(sell[indx], result[indx - 1]);
            }

            return result.Length == 0 ? 0 : result[result.Length - 1];
        }

        // 714 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee
        //================================================================================================================================

        public int MaxProfitV(int[] prices, int fee)
        {
            int s0 = 0;
            int s1 = int.MinValue;
            int tmp = 0;

            foreach (int price in prices)
            {
                tmp = s0;

                s0 = Math.Max(s0, s1 + price);
                s1 = Math.Max(s1, tmp - price - fee);
            }

            return s0;
        }

    }
}