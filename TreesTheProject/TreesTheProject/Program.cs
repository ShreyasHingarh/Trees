using System;

namespace TreesTheProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            int[] nums = new int[] {9,11,4,1,6,14,3,5};
            for(int i = 0;i < nums.Length;i++)
            {
                tree.Insert(nums[i]);
            }
            ;
            tree.Delete(5);
            Console.WriteLine(tree.Minimum);
            Console.WriteLine(tree.Maximum);
            Console.WriteLine(tree.Contains(345));
        }
    }
}
