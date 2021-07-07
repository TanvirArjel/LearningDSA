namespace DataStructuresAndAlgorithms.DataStructures.Trees.Bst.Problems
{
    public static class BstLowestCommonAnchestor
    {
        // Time Complexity: O(h) where h is the height of the binary search tree.
        // Space Complexity: O(h) Because of recursion's call stack.
        public static BinaryTreeNode<int> FindLCA(BinaryTreeNode<int> root, BinaryTreeNode<int> n1, BinaryTreeNode<int> n2)
        {
            if (root == null)
            {
                return null;
            }

            if (n1 == null || n2 == null)
            {
                return null;
            }

            if (root.Data > n1.Data && root.Data > n2.Data)
            {
                return FindLCA(root.LeftNode, n1, n2);
            }
            else if (root.Data < n1.Data && root.Data < n2.Data)
            {
                return FindLCA(root.RightNode, n1, n2);
            }
            else
            {
                return root;
            }
        }
    }
}
