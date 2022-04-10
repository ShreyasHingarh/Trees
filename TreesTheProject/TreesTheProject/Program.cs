using System;
using System.Collections.Generic;

namespace TreesTheProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<char> tree = new Tree<char>();



            char[] letters = new char[] { 'F', 'B', 'A', 'D', 'C', 'E', 'G', 'I', 'H' };
            for (int i = 0; i < letters.Length; i++)
            {
                tree.Insert(letters[i]);
            }
            ;
            var list = tree.BreadthFirst(tree.Root);
            foreach(var letter in list)
            {
               Console.WriteLine(letter);
            }
        }
    }
}
