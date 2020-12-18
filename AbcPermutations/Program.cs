using System;
using System.Collections.Generic;

/*
 
ABC ==> "ABC, ACB, BAC, BCA, CAB, CBA"
AAB ==> "AAB, ABA, BAA"

Write a recursive function that gives a string that can produce 
all possible permutations

 */

namespace AbcPermutations
{
    class Program
    { 
        static void Main(string[] args)
        {
            //var str = "ABC";
            var str = "AAB";
            var permutations = new HashSet<string>();

            LettersPermutations("", str, permutations);

            foreach(var permutation in permutations)
            {
                Console.WriteLine(permutation);
            }
        }

        static void LettersPermutations(string left, string right, HashSet<string> result)
        {
            if(right.Length==0)
            {
                result.Add(left);
                return;
            }

            for(var i=0; i<right.Length; i++)
            {
                LettersPermutations(left + right[i], right.Substring(0, i) + right.Substring(i + 1), result);
            }
        }
    }
}
