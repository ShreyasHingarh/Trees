using System;

namespace TreesTheProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            int[] nums = new int[] {9,11,4,1,6,14};
            for(int i = 0;i < nums.Length;i++)
            {
                tree.Insert(nums[i]);
            }
            ;


        }
    }
}
