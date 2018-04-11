using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Tree
{
    public class BinaryTree<T>
    {
        public class Comparator : IComparer<T>
        {
            int IComparer<T>.Compare(T object1, T object2)
            {
                return new CaseInsensitiveComparer().Compare(object1, object2);
            }
        }

        private TreeNode<T> mainNode;
        private int value;
        IComparer<T> cmp = new Comparator();

        public BinaryTree()
        {

        }

        public BinaryTree(TreeNode<T> mainNode)
        {
            this.mainNode = mainNode;
            value++;
        }

        public int Value { get { return value; } }

        public void Add(T data)
        {
            TreeNode<T> currentNode = mainNode;

            while (!data.Equals(currentNode.Data))
            {
                if (cmp.Compare(currentNode.Data, data) < 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        currentNode.Left = new TreeNode<T>(data);
                        value++;
                    }
                }
                else
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                    else
                    {
                        currentNode.Right = new TreeNode<T>(data);
                        value++;
                    }
                }
            }
        }

        public bool Search(T data)
        {
            TreeNode<T> currentNode = mainNode;

            while (!data.Equals(currentNode.Data))
            {
                if (cmp.Compare(currentNode.Data, data) < 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Delete(T data)
        {
            TreeNode<T> currentNode = mainNode;
            TreeNode<T> parentNode = null;

            while (!data.Equals(currentNode.Data))
            {
                parentNode = currentNode;

                if (cmp.Compare(currentNode.Data, data) < 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (parentNode.Left.Data.Equals(currentNode.Data))
                {
                    parentNode.Left = null;
                }
                else if (parentNode.Right.Data.Equals(currentNode.Data))
                {
                    parentNode.Right = null;
                }
            }

            if ((currentNode.Left == null && currentNode.Right != null) || (currentNode.Left != null && currentNode.Right == null))
            {
                if (parentNode.Left.Data.Equals(currentNode.Data))
                {
                    parentNode.Left = currentNode.Left;
                }
                else if (parentNode.Right.Data.Equals(currentNode.Data))
                {
                    parentNode.Right = currentNode.Right;
                }
            }

            if (currentNode.Left != null && currentNode.Right != null)
            {
                TreeNode<T> leftElement = currentNode;

                while (leftElement.Left != null)
                {
                    leftElement = leftElement.Left;
                }

                TreeNode<T> rightSon = leftElement.Right;

                if (parentNode.Left.Data.Equals(currentNode.Data))
                {
                    parentNode.Left = leftElement;
                }
                else if (parentNode.Right.Data.Equals(currentNode.Data))
                {
                    parentNode.Right = leftElement;
                }

                if (rightSon != null)
                {
                    leftElement = rightSon;
                }
            }

            value--;
        }

        public void WidthRound()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(mainNode);

            while(queue.Count > 0)
            {
                TreeNode<T> element = queue.Dequeue();

                if(element.Left != null)
                {
                    queue.Enqueue(element.Left);
                }

                if(element.Right != null)
                {
                    queue.Enqueue(element.Right);
                }
            }
        }

        public void DeepRoundWithRecursion(TreeNode<T> node)
        {
            foreach(TreeNode<T> child in node.GetChildren())
            {
                DeepRoundWithRecursion(child);
            }
        }

        public void DeepRound()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(mainNode);

            while (queue.Count > 0)
            {
                TreeNode<T> element = queue.Dequeue();

                if (element.Right != null)
                {
                    queue.Enqueue(element.Right);
                }

                if (element.Left != null)
                {
                    queue.Enqueue(element.Left);
                }
            }
        }
    }
}
