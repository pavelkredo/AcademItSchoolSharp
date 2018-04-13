using System;
using System.Collections.Generic;

namespace Tree.Tree
{
    public class BinaryTree<T>
    {
        private TreeNode<T> mainNode;
        private IComparer<T> comparer;

        public BinaryTree()
        {
            comparer = Comparer<T>.Default;
        }

        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count { get; set; }

        public void Add(T data)
        {
            if(mainNode == null)
            {
                mainNode = new TreeNode<T>(data);
                Count++;
            }

            TreeNode<T> currentNode = mainNode;

            while (comparer.Compare(data, currentNode.Data) != 0)
            {
                if (comparer.Compare(currentNode.Data, data) < 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        currentNode.Left = new TreeNode<T>(data);
                        Count++;
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
                        Count++;
                    }
                }
            }
        }

        public bool Contains(T data)
        {
            TreeNode<T> currentNode = mainNode;

            while (comparer.Compare(data, currentNode.Data) != 0)
            {
                if (comparer.Compare(currentNode.Data, data) < 0)
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

            while (comparer.Compare(data, currentNode.Data) != 0)
            {
                parentNode = currentNode;

                if (comparer.Compare(currentNode.Data, data) < 0)
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
                if (comparer.Compare(parentNode.Left.Data, currentNode.Data) == 0)
                {
                    parentNode.Left = null;
                }
                else if (comparer.Compare(parentNode.Right.Data, currentNode.Data) == 0)
                {
                    parentNode.Right = null;
                }
            }

            if ((currentNode.Left == null && currentNode.Right != null) || (currentNode.Left != null && currentNode.Right == null))
            {
                if (comparer.Compare(parentNode.Left.Data, currentNode.Data) == 0)
                {
                    parentNode.Left = currentNode.Left;
                }
                else if (comparer.Compare(parentNode.Right.Data, currentNode.Data) == 0)
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

                if (comparer.Compare(parentNode.Left.Data, currentNode.Data) == 0)
                {
                    parentNode.Left = leftElement;
                }
                else if (comparer.Compare(parentNode.Right.Data, currentNode.Data) == 0)
                {
                    parentNode.Right = leftElement;
                }

                if (rightSon != null)
                {
                    leftElement = rightSon;
                }
            }

            Count--;
        }

        public void BreadthTraversal(Func<T> func)
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(mainNode);

            while(queue.Count > 0)
            {
                TreeNode<T> element = queue.Dequeue();
                func();

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

        public void DepthRecursionTraversal(TreeNode<T> node, Func<T> func)
        {
            func();

            foreach(TreeNode<T> child in node.GetChildren())
            {
                DepthRecursionTraversal(child, func);
            }
        }

        public void DepthTraversal(Func<T> func)
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(mainNode);

            while (queue.Count > 0)
            {
                TreeNode<T> element = queue.Dequeue();
                func();

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
