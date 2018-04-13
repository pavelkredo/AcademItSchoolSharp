namespace Tree.Tree
{
    public class TreeNode<T>
    {
        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public T Data { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public TreeNode<T>[] GetChildren()
        {
            return new TreeNode<T>[] { Left, Right };
        }
    }
}
