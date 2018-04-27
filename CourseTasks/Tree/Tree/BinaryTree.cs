using System;
using System.Collections.Generic;

namespace Tree.Tree
{
    public class BinaryTree<T>
    {
        private TreeNode<T> root;
        private IComparer<T> comparer;

        public BinaryTree()
        {
            comparer = Comparer<T>.Default;
        }

        public BinaryTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Count { get; private set; }

        public void Add(T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>(data);
                Count++;
                return;
            }

            TreeNode<T> currentNode = root;

            while (true)
            {
                if (comparer.Compare(data, currentNode.Data) < 0)
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
                        currentNode.Right = new TreeNode<T>(data);
                        Count++;
                        return;
                    }
                }
            }
        }

        public bool Contains(T data)
        {
            if (root == null)
            {
                return false;
            }

            TreeNode<T> currentNode = root;

            while (true)
            {
                int compareResult = comparer.Compare(data, currentNode.Data);

                if (compareResult < 0)
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
                else if (compareResult > 0)
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
                else
                {
                    return true;
                }
            }
        }

        public bool Delete(T data)
        {
            TreeNode<T> currentNode = root;
            TreeNode<T> parentNode = null;
            
            //Поиск нужного узла

            while (true)
            {
                int compareResult = comparer.Compare(data, currentNode.Data);

                if (compareResult == 0)
                {
                    break;
                }

                parentNode = currentNode;

                if (compareResult < 0)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                        continue;
                    }
                    else
                    {
                        break;
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
                        break;
                    }
                }
            }

            //Удаление узла

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (currentNode == root)
                {
                    root = null;
                    Count--;
                    return true;
                }

                if (parentNode.Left != null && comparer.Compare(parentNode.Left.Data, data) == 0)
                {
                    parentNode.Left = null;
                }
                else
                {
                    parentNode.Right = null;
                }

                Count--;
                return true;
            }

            if ((currentNode.Left == null && currentNode.Right != null) || (currentNode.Left != null && currentNode.Right == null))
            {
                if (currentNode == root)
                {
                    if (currentNode.Left != null)
                    {
                        root = currentNode.Left;
                    }
                    else
                    {
                        root = currentNode.Right;
                    }

                    Count--;
                    return true;
                }

                if (parentNode.Left != null && comparer.Compare(parentNode.Left.Data, data) == 0)
                {
                    if (currentNode.Left != null)
                    {
                        parentNode.Left = currentNode.Left;
                    }
                    else
                    {
                        parentNode.Left = currentNode.Right;
                    }

                    Count--;
                    return true;
                }
                else
                {
                    if (currentNode.Left != null)
                    {
                        parentNode.Right = currentNode.Left;
                    }
                    else
                    {
                        parentNode.Right = currentNode.Right;
                    }

                    Count--;
                    return true;
                }
            }

            if (currentNode.Left != null && currentNode.Right != null)
            {
                TreeNode<T> leftElement = currentNode.Right;

                while (leftElement.Left != null)
                {
                    leftElement = leftElement.Left;
                }

                T value = leftElement.Data;

                Delete(value);

                if (currentNode == root)
                {
                    root.Data = value;
                    return true;
                }

                if (parentNode.Left != null && comparer.Compare(parentNode.Left.Data, currentNode.Data) == 0)
                {
                    parentNode.Left.Data = value;
                }
                else if (comparer.Compare(parentNode.Right.Data, currentNode.Data) == 0)
                {
                    parentNode.Right.Data = value;
                }

                return true;
            }

            return false;
        }

        public void BreadthTraversal(Action<T> action)
        {
            if (root == null)
            {
                return;
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode<T> element = queue.Dequeue();
                action(element.Data);

                if (element.Left != null)
                {
                    queue.Enqueue(element.Left);
                }

                if (element.Right != null)
                {
                    queue.Enqueue(element.Right);
                }
            }
        }

        public void DepthRecursionTraversal(Action<T> action)
        {
            StartDepthRecursionTraversal(root, action);
        }

        private void StartDepthRecursionTraversal(TreeNode<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Data);

            StartDepthRecursionTraversal(node.Left, action);
            StartDepthRecursionTraversal(node.Right, action);
        }

        public void DepthTraversal(Action<T> action)
        {
            if (root == null)
            {
                return;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode<T> element = stack.Pop();
                action(element.Data);

                if (element.Right != null)
                {
                    stack.Push(element.Right);
                }

                if (element.Left != null)
                {
                    stack.Push(element.Left);
                }
            }
        }
    }
}