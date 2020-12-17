using System;

namespace CodingTasks
{
    /*
   You are given coins of different denominations and a total amount of money. 
   Write a function to compute the number of combinations that make up that amount. 
   You may assume that you have infinite number of each kind of coin.
   Example 1:
   Input: amount = 5, coins = [1, 2, 5]
   Output: 4
   Explanation: there are four ways to make up the amount:
   5=5
   5=2+2+1
   5=2+1+1+1
   5=1+1+1+1+1

   Input: amount = 3, coins = [2]
   Output: 0
   Explanation: the amount of 3 cannot be made up just with coins of 2.

   Example 3:
   Input: amount = 10, coins = [10] 
   Output: 1
   */

    class Program
    {
        static long callCount = 0;

        static void Main(string[] args)
        {
            // 1
            var amount = 5;
            var coins = new int[] { 1, 2, 5 };
            // Output: 4
            // call count = 27

            // 2
            //var amount = 3;
            //var coins = new int[] { 2 };
            //Output: 0
            // call count = 5

            // 3
            //var amount = 10;
            //var coins = new int[] { 10 };
            // Output: 1
            // call count = 3

            // 4
            //var amount = 3000;
            //var coins = new int[] { 1, 2, 5 };
            // Output: 451201
            // call count = 904055901

            Array.Sort(coins);

            var countOfCombinations = CountOfCombinationsRecursiveBruteForce(coins, amount, coins.Length - 1);

            Console.WriteLine($"count of combinations : {countOfCombinations}");
            Console.WriteLine($"total calls : {callCount}");
        }

        static int CountOfCombinationsRecursiveBruteForce(int[] coins, int amount, int maxDenominatorId)
        {
            // diagnostics
            callCount++;

            // base cases
            if (amount < 0 || maxDenominatorId < 0)
                return 0;
            if (amount == 0)
                return 1;

            // next case
            return CountOfCombinationsRecursiveBruteForce(coins, amount, maxDenominatorId - 1) + CountOfCombinationsRecursiveBruteForce(coins, amount - coins[maxDenominatorId], maxDenominatorId);
        }
    }
}
