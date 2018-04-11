using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Tree
{
    public class TreeNode<T>
    {
        private TreeNode<T> left;
        private TreeNode<T> right;
        private T data;

        public TreeNode(T data)
        {
            this.data = data;
            left = null;
            right = null;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public TreeNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }

        public TreeNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }

        public TreeNode<T>[] GetChildren()
        {
            return new TreeNode<T>[] { left, right };
        }
    }
}
