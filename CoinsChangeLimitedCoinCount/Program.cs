using System;

/*
Write a method that, given:
- an amount of money
- an array of coin denominations
- computes the number of ways to make the amount of money with coins of the available denominations.

Example: for amount=4 (4¢) and denominations=[1,2,3][1,2,3] (11¢, 22¢ and 33¢), 
your program would output 4—the number of ways to make 4¢ with those denominations:

1¢, 1¢, 1¢, 1¢
1¢, 1¢, 2¢
1¢, 3¢
2¢, 2¢

Как именно получается так что 1¢ четыре штуки 1¢, 1¢, 1¢, 1¢,
в input их вроде только две штуки [1,2,3][1,2,3] (11¢, 22¢ and 33¢)

!!!

я понял условие так: есть список номиналов и кол-во монет каждого номинала
denominations {1,2,3}
counts:       {2,2,2}
то есть, в примере по 2 шт каждого номинала

как получается вариант как в примере с 4 1-центовыми - понятия не имею, 
либо условие записано не точно либо пример не от этой задачки

 */

namespace CoinsChangeLimitedCoinCount
{
    class Program
    {
        static void Main(string[] args)
        {

            //var amount = 4;
            //var coins = new int[] { 1, 2, 3 };
            //var counts = new int[] { 1, 1, 1 };

            /* если считаем, что все монетки одинаковые которые с одинаковым номиналом
               и использовать можно каждую только по 1 разу
           
            1 3

            всего 1 вариант
             */

            var amount = 4;
            var coins = new int[] { 1, 2, 3 };
            var counts = new int[] { 2, 2, 2 };

            /*
             каждую можно использовать по 2 раза, всего выходит 3 варианта

             1    1 1 2
             2    2 2
             3    1 3
            
            */

            var ways = createdp3(coins, counts, amount);

            Console.WriteLine(ways);
        }
       
        static int createdp3(int[] coins, int[] counts, int amount)
        {
            var dp = new int[amount + 1, coins.Length];
            for (var s = 0; s <= amount; s++)
            {
                for (var k = 1; k <= counts[0]; k++)
                {
                    if(s==0)
                    {
                        dp[s, 0] = 1;
                    }
                    else
                    {
                        dp[s, 0] += (s == coins[0] * k)  ? 1 : 0;
                    }
                }
            }

            for (var i = 1; i < coins.Length; i++)
            {
                for (var s = 0; s <= amount; s++)
                {
                    if (s == 0) // если сумма = 0 то всего 1 вариант всегда
                    {
                        dp[s, i] = 1;
                    }
                    else
                    {
                        dp[s, i] += dp[s, i - 1]; // сначала варианты с пред i

                        // плюс все комбинации вариантов для всех k для текущего i
                        for (var k = 1; k <= counts[i]; k++)
                        {
                            var delta = coins[i] * k;
                            if (s >= delta)
                            {
                                dp[s, i] += dp[s - delta, i - 1]; // если с тек мон ок то добавляем варианты
                            }
                        }
                    }
                }
            }

            printDp(dp, coins, amount);
            return dp[amount, counts.Length - 1];
        }

        static void printDp(int[,] dp, int[] coins, int amount)
        {
            for (var s = 0; s <= amount; s++)
            {
                Console.Write($"\t{s}");
            }
            Console.WriteLine();

            for (var coinId = 0; coinId < coins.Length; coinId++)
            {
                Console.Write($"{coins[coinId]}");
                for (var s = 0; s <= amount; s++)
                {
                    Console.Write($"\t{dp[s, coinId]}");
                }
                Console.WriteLine();
            }
        }
    }
}
