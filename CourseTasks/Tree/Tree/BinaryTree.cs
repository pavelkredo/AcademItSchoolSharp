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

        public int Count { get; set; }

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

        public void Delete(T data)
        {
            TreeNode<T> currentNode = root;
            TreeNode<T> parentNode = null;

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

            if (currentNode.Left == null && currentNode.Right == null)
            {
                if (parentNode == root)
                {
                    root = null;
                    Count--;
                    return;
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
                return;
            }

            if ((currentNode.Left == null && currentNode.Right != null) || (currentNode.Left != null && currentNode.Right == null))
            {
                if (parentNode == root)
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
                    return;
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
                    return;
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
                    return;
                }
            }

            if (currentNode.Left != null && currentNode.Right != null)
            {
                TreeNode<T> leftElement = currentNode.Right;
                TreeNode<T> leftElementParent = currentNode;

                while (leftElement.Left != null)
                {
                    leftElementParent = leftElement;
                    leftElement = leftElement.Left;
                }

                TreeNode<T> rightSon = leftElement.Right;

                if (rightSon != null)
                {
                    if (leftElementParent.Left == leftElement)
                    {
                        leftElementParent.Left = rightSon;
                    }
                    else if (leftElementParent.Right == leftElement)
                    {
                        leftElementParent.Right = rightSon;
                    }
                }

                leftElement.Left = currentNode.Left;
                leftElement.Right = currentNode.Right;

                if (parentNode == null)
                {
                    root = leftElement;

                    Count--;
                    return;
                }

                if (parentNode.Left != null && comparer.Compare(parentNode.Left.Data, currentNode.Data) == 0)
                {
                    parentNode.Left = leftElement;
                }
                else if (comparer.Compare(parentNode.Right.Data, currentNode.Data) == 0)
                {
                    parentNode.Right = leftElement;
                }

                Count--;
                return;
            }
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

        public void DepthRecursionTraversal(TreeNode<T> node, Action<T> action)
        {
            if(node == null)
            {
                return;
            }

            action(node.Data);

            DepthRecursionTraversal(node.Left, action);
            DepthRecursionTraversal(node.Right, action);
        }

        public void DepthTraversal(Action<T> action)
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