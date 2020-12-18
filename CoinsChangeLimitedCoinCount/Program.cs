using System;
using System.Collections.Generic;

/*
Write a method that, given:
- an amount of money
- an array of coin denominations
- computes the number of ways to make the amount of money with coins of the available denominations.

Example: for amount=4 (4¢) and denominations=[1,2,3][1,2,3] (11¢, 22¢ and 33¢), your program would output 4—the number of ways to make 4¢ with those denominations:
1¢, 1¢, 1¢, 1¢
1¢, 1¢, 2¢
1¢, 3¢
2¢, 2¢
Как именно получается так что 1¢ четыре штуки 1¢, 1¢, 1¢, 1¢,
в input их вроде только две штуки [1,2,3][1,2,3] (11¢, 22¢ and 33¢)

 */

namespace CoinsChangeLimitedCoinCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var coins = new int[] { 1,2,3 };
            var amount = 10;
            var permutationsCount = CountOfPermutations(coins, amount, coins.Length - 1);

            Console.WriteLine($"count = {l.Count}");
            foreach(var p in l)
            {
                Console.WriteLine(p);
            }
        }

        static Queue<int> q = new Queue<int>();
        static HashSet<string> l = new HashSet<string>();

        static int CountOfPermutations(int[] coins, int amount, int i, bool coinused=false)
        {
            if (amount < 0)
            {
                if(coinused)
                    q.Dequeue();
                return 0;
            }

            if (amount == 0)
            {
                var a = q.ToArray();
                Array.Sort(a);
                l.Add(String.Join("", a));
                q.Dequeue();
                return 1;
            }

            if (i < 0)
            {
                if (coinused)
                    q.Dequeue();
                return 0;
            }

            if(amount< coins[i])
            {
                return CountOfPermutations(coins, amount, i - 1, false);
            }
            else
            {
                q.Enqueue(coins[i]);
                var c2 = CountOfPermutations(coins, amount - coins[i], i - 1, true);
                var c1 = CountOfPermutations(coins, amount, i - 1, false);
                return c1 + c2;
            }
        }
    }
}
