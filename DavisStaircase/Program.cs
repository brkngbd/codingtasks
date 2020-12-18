using System;
using System.Collections.Generic;

/*
Davis has a number of staircases in his house and he likes to climb each staircase , , or  
steps at a time. Being a very precocious child, he wonders how many ways there are to reach the top of the staircase.

Given the respective heights for each of the  staircases in his house, 
find and print the number of ways he can climb each staircase, module  on a new line.

For example, there is s=1  staircase in the house that is n=5 steps high. 
Davis can step on the following sequences of steps:

1 1 1 1 1
1 1 1 2
1 1 2 1 
1 2 1 1
2 1 1 1
1 2 2
2 2 1
2 1 2
1 1 3
1 3 1
3 1 1
2 3
3 2

There are 13 possible ways he can take these  steps. 

For 7 steps there are ways


Function Description

Complete the stepPerms function in the editor below. 
It should recursively calculate and return the integer number of ways Davis can climb the staircase, modulo 10000000007.

stepPerms has the following parameter(s):

n: an integer, the number of stairs in the staircase
*/

namespace DavisStaircase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(stepPerms(7));
        }

        static int stepPerms(int n)
        {
            return (int)(CountOfWays(n) % 100000000007L);
        }

        static Dictionary<int, long> dic = new Dictionary<int, long>();

        static long CountOfWays(int n)
        {
            if (n == 0)
                return 1;

            if (n == 1)
                return 1;

            if (n == 2)
                return 2;

            if (n == 3)
                return 4;

            if (dic.ContainsKey(n))
                return dic[n];
            else
            {
                var p = CountOfWays(n - 1) + CountOfWays(n - 2) + CountOfWays(n - 3);
                dic[n] = p;
                return p;
            }
        }
    }
}
