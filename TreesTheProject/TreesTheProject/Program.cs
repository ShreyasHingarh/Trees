using System;

namespace TreesTheProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            int[] nums = new int[] {9,6,4,7,1,5,8};
            for(int i = 0;i < nums.Length;i++)
            {
                tree.Insert(nums[i]);
            }
            ;
            tree.Delete(9);
            Console.WriteLine(tree.Minimum);
            Console.WriteLine(tree.Maximum);
            Console.WriteLine(tree.Contains(345));
        }
    }
}
