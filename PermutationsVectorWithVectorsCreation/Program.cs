using System;
using System.Collections.Generic;
using System.Linq;

/*
Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Example 2:

Input: nums = [0,1]
Output: [[0,1],[1,0]]
Example 3:

Input: nums = [1]
Output: [[1]]
 

Constraints:

1 <= nums.length <= 6
-10 <= nums[i] <= 10
All the integers of nums are unique.
 */


namespace PermutationsVectorWithVectorsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            var sample = new int[] { 1, 2, 3 };
            var result = new Solution().Permute(sample);
            foreach(var permutation in result)
            {
                Console.WriteLine();
                foreach(var item in permutation)
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}

public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {

        Array.Sort(nums);
        var result = new List<List<int>>();
        var source = new List<int>(nums);

        Permute(new List<int>(), source, result);

        return result.Cast<IList<int>>().ToList<IList<int>>();
    }

    public void Permute(List<int> left, List<int> rigth, List<List<int>> result)
    {
        if (rigth.Count == 0)
        {
            result.Add(left);
            return;
        }

        for (var i = 0; i < rigth.Count; i++)
        {
            var newLeft = new List<int>(left);
            newLeft.Add(rigth[i]);
            var newRigth = new List<int>(rigth);
            newRigth.RemoveAt(i);
            Permute(newLeft, newRigth, result);
        }
    }
}
