using System;
using System.Collections.Generic;

/*
Task Description

An employee has to work exactly as many hours as they are told to each week, scheduling no more than a given daily maximum number of hours. On some days, the number of hours worked will be given. The employee gets to choose the remainder of their schedule, within the given limits.

 

A completed schedule consists of exactly 7 digits in the range 0 to 8 that represent each day's hours to be worked. A pattern string similar to the schedule will be given, but with some of the digits replaced by a question mark, ?, (ascii 63 decimal). Given a maximum number of hours that can be worked in a day, replace the question marks with digits so that the sum of the scheduled hours is exactly the hours that must be worked in a week.

 

Example

pattern = '08??840'

work_hours = 24

day_hours = 4

There are two days on which they must work 24 - 20 = 4 more hours for the week. All of the possible schedules are listed below:

0804840
0813840
0822840
0831840
0840840
Function Description

Complete the function findSchedules in the editor below.

    findSchedules has the following parameter(s):

    int work_hours:  the hours that must be worked in the week

    int day_hours:  the maximum hours that may be worked in a day

    int pattern:  the partially completed schedule

 

Returns:

    string arr[]: represents all possible valid schedules (must be ordered lexicographically ascending)

Constraints

1 ≤ work_hours ≤ 56
1 ≤ day_hours ≤ 8
| pattern | = 7
Each character of pattern ∈ {0, 1,...,8}
There is at least one correct schedule.
 

Input Format For Custom Testing
Sample Case 0
Sample Input

STDIN     Function 
-----     -----
56      →   work_hours = 56
8       →   day_hours = 8
???8??? →   pattern = '???8???'
Sample Output

8888888
Explanation

work_hours = 56
day_hours = 8
pattern = '???8???'
There is only one way to work 56 hours in 7 days of 8 hours.

Sample Case 1
Sample Input

STDIN        Function
-----        ----- 
3        →   work_hours = 3
2        →   day_hours = 2
??2??00  →   pattern = '??2??00'
Sample Output

0020100
0021000
0120000
1020000
Explanation

work_hours = 3
day_hours = 2
pattern = '??2??00'
They only need to schedule 1 more hour for the week, and it can be on any one of the days in question.

 */

namespace Schedule
{
    class Program
    {
        /*
        int week_hours:  the hours that must be worked in the week
        int day_hours:  the maximum hours that may be worked in a day
        int pattern:  the partially completed schedule
        */

        static void Main(string[] args)
        {
            // sample case -1
            var pattern = "08??840";
            var week_hours = 24;
            var day_hours = 4;

            // sample case 0
            //var pattern = "???8???";
            //var week_hours = 56;
            //var day_hours = 8;

            // sample 1
            //var pattern = "??2??00";
            //var week_hours = 3;
            //var day_hours = 2;

            var results = findSchedules(week_hours, day_hours, pattern);

            Console.WriteLine($"week_hours: {week_hours} day_hours: {day_hours} pattern: {pattern}");

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }

        static List<string> findSchedules(int week_hours, int day_hours, string pattern)
        {
            var resultSet = new HashSet<string>();

            fs(resultSet, week_hours, day_hours, pattern);

            var result = new List<string>(resultSet);
            result.Sort();

            return result;
        }

        static void fs(HashSet<string> results, int week_hours, int day_hours, string pattern)
        {
            var sum = calcSum(pattern);
            var marksCount = calcMarks(pattern);

            if (sum > week_hours)
                return;

            if (sum == week_hours && marksCount == 0)
            {
                results.Add(pattern);
                return;
            }

            for (var pos = 0; pos < pattern.Length; pos++)
            {
                if (pattern[pos] == '?')
                {
                    if (marksCount == 1)
                    {
                        var patternArr = pattern.ToCharArray();
                        var delta = week_hours - sum;
                        if(delta <= day_hours)
                        {
                            patternArr[pos] = (week_hours - sum).ToString()[0];
                            fs(results, week_hours, day_hours, new string(patternArr));
                        }
                        break;
                    }
                    else
                    {
                        for (var h = 0; h <= day_hours; h++)
                        {
                            var patternArr = pattern.ToCharArray();
                            patternArr[pos] = h.ToString()[0];
                            fs(results, week_hours , day_hours, new string(patternArr));
                        }
                    }
                }
            }
        }

        static int calcSum(string pattern)
        {
            var sum = 0;
            foreach(var item in pattern)
            {
                if (item != '?')
                {
                    sum += int.Parse(item.ToString());
                }
            }
            return sum;
        }

        static int calcMarks(string pattern)
        {
            var sum = 0;
            foreach (var item in pattern)
            {
                if (item == '?')
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
