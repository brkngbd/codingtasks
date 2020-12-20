using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //string word = null;
            //string word = "";
            //string word = "x";
            //string word = "xx";
            //string word = "xxx";
            //string word = "xyx";
            //string word = "xyyx";
            string word = "neveroddoreven";
            //string word = "abcd";
            //string word = "abcde";

            Console.WriteLine($"Is palindrome = {IsPalindrome(word)}");
        }

        static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
                return true;

            var left = 0;
            var right = s.Length - 1;

            while(left<right)
            {
                if (s[left++] != s[right--])
                    return false;
            }
            return true;
        }
    }
}
