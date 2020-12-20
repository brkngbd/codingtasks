using System;

/*
 Write a C# program to Print Binary Equivalent 
of an Integer using Recursion

 */

namespace BinaryEquivalentOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 1025;

            var str = ToBinary(n);

            Console.WriteLine(str);
        }

        static string ToBinary(int n)
        {
            if (n == 0)
                return "0";
            if (n == 1)
                return "1";

            var r = n / 2;
            var c = n % 2 == 0 ? "0" : "1";
            
            return ToBinary(r)+ c;
        }
    }
}
