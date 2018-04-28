using System;
using Tree.Tree;

namespace Tree.Main
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(7);
            tree.Add(4);
            tree.Add(6);
            tree.Add(1);
            tree.Add(3);
            tree.Add(10);
            tree.Add(8);
            tree.Add(13);
            tree.Add(14);
            tree.Add(2);

            Console.WriteLine(tree.Contains(1));
            Console.WriteLine(tree.Count);

            tree.Delete(2);

            Console.WriteLine(tree.Contains(3));
            Console.WriteLine(tree.Count);
        }
    }
}
