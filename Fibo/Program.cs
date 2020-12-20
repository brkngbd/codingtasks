using System;

namespace Fibo
{
    class Program
    {
        static void Main(string[] args)
        {

            Test();
        }

        static int Fibo(int n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;

            return Fibo(n - 1) + Fibo(n-2);
        }

        static void Test()
        {
            var nArr =     new[] { 0, 1, 2, 3, 4, 5, 6,  7,  8,  9 };
            var expected = new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };

            for (var i= 0; i < nArr.Length; i++)
            {
                var r = Fibo(nArr[i]);
                if ( r != expected[i] )
                {
                    Console.WriteLine($"Test failed. Expected Fibo({nArr[i]}) is {expected[i]}. Actual is {r}");
                }
            }
        }
    }
}
