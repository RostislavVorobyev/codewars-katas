namespace Codewars
{
    public static class InvertBinaryTree
    {
        public static TreeNode InvertTree(TreeNode root)
        {

            if (root == null)
            {
                return null;
            }

            var left = InvertTree(root.Left);
            var right = InvertTree(root.Right);

            root.Right = left;
            root.Left = right;

            return root;
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }
}
