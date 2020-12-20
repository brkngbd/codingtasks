using System;

/*
Given a string with repeating characters, 
output a string with pairs {character}{number of times repeated sequentially}
aaabbcccdddaaabbbbcdeeef => a3b2c3d3a3b4c1d1e3f1


 */

namespace StringWithRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "aaabbcccdddaaabbbbcdeeef";
            // a3b2c3d3a3b4c1d1e3f1
            

            Console.WriteLine(Process(s));
        }

        static string Process(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var result = "";
            var c = s[0];
            var cnt = 1;

            for(var i = 1; i<s.Length; i++)
            {
                if(s[i]==c)
                {
                    cnt++;
                }
                else
                {
                    result += $"{c}{cnt}";
                    c = s[i];
                    cnt = 1;
                }
            }
            result += $"{c}{cnt}";
            return result;
        }
    }
}
