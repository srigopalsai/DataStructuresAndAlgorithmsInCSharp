using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{ 
    partial class DynamicProgrammingSamplesArrays
    {

        //121 https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/
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

        //122 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/
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

        // 309 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/description/
        //================================================================================================================================

        public int MaxProfitIII3(int[] prices)
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

        // DP & State Machine approach.
        public int MaxProfitIII2(int[] prices)
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

        public int MaxProfitIII1(int[] prices)
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

        // 714 https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-transaction-fee/description/
        //================================================================================================================================

        public int MaxProfitVI(int[] prices, int fee)
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