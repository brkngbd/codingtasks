using System;

/*
Given an unsorted array of nonnegative integers, find a continuous subarray which adds to a given number.
Examples:
Input: arr[] = {1, 4, 20, 3, 10, 5}, sum = 33
Ouptut: Sum found between indexes 2 and 4
Input: arr[] = {1, 4, 0, 0, 3, 10, 5}, sum = 7
Ouptut: Sum found between indexes 1 and 4

*/

namespace ContSubarrayThatAddToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //var arr = new int[]{ 1, 4, 20, 3, 10, 5 };
            //var sum = 33;
            // 2,4

            var arr = new int[] { 1, 4, 0, 0, 3, 10, 5 };
            var sum = 7;
            // 1,4

            var result = GetSubarray(arr, sum);
            Console.WriteLine($"{result.left} , {result.right}");
        }

        static (int left, int right) GetSubarray(int[] arr, int sum)
        {
            (int, int) result = (-1, -1);

            var left = 0;
            var right = 0;

            while(left<arr.Length && right<arr.Length)
            {
                var s = GetSum(arr, left, right);
                if (s == sum)
                    return (left, right);
                if (s < sum)
                    right++;
                else
                    left++;
            }

            return result;
        }

        static int GetSum(int[] a, int l, int r)
        {
            var s = 0;
            for (var i = l; i <= r; i++)
                s += a[i];
            return s;
        }
    }
}
