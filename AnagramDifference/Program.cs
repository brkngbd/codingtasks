using System;
using System.Collections.Generic;
using System.Linq;

/*
Given two words, how many letters do you have to remove from them to make them anagrams?
Example
First word : c od e w ar s (4 letters removed)
Second word : ha c k er r a nk (6 letters removed)
Result : 10
Hints
A word is an anagram of another word if they have the same letters (usually in a different order).
Do not worry about case. All inputs will be lowercase.
When you're done with this kata, check out its big brother/sister : https://www.codewars.com/kata/hardcore-anagram-difference
 */

namespace AnagramDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "codewars";
            var str2 = "hackerrank";
          
            var numberOfSymbolsToRemove = AnagramDifference(str1, str2);

            Console.WriteLine(numberOfSymbolsToRemove);
        }

        static int AnagramDifference(string str1, string str2)
        {
            var symbolsMap = new Dictionary<char, int[]>();

            for (var idx = 0; idx < 2; idx++)
            {
                foreach (var s in new string[] { str1, str2 } [idx])
                {
                    if (!symbolsMap.ContainsKey(s))
                    {
                        var mapItem = new int[2];
                        mapItem[idx] = 1;
                        symbolsMap.Add(s, mapItem);
                    }
                    else
                    {
                        var item = symbolsMap[s];
                        item[idx]++;
                        symbolsMap[s] = item;
                    }
                }
            }

            return symbolsMap.Values.Sum(item => Math.Abs(item[0] - item[1]));
        }
    }
}
