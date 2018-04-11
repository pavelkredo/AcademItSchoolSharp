using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree.Tree;

namespace Tree.Main
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(new TreeNode<int>(1));
            tree.Add(3);
            tree.Add(4);
            tree.Add(6);
            tree.Add(7);
            tree.Add(8);
            tree.Add(10);
            tree.Add(13);
            tree.Add(14);
            tree.Add(2);

            Console.WriteLine(tree.Search(1));
            Console.WriteLine(tree.Value);

            tree.Delete(6);

            Console.WriteLine(tree.Search(6));
            Console.WriteLine(tree.Value);

            Console.WriteLine(tree.getDeep());
        }
    }
}
