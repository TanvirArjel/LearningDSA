// <copyright file="IsBinarySearchTree.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTree.Problems
{
    public class IsBinarySearchTree
    {
        public bool IsBst(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return true;
            }

            return IsBst(root, int.MinValue, int.MaxValue);
        }

        private bool IsBst(BinaryTreeNode<int> root, int minValue, int maxValue)
        {
            if (root == null)
            {
                return true;
            }

            if (root.Data > minValue && root.Data < maxValue
                && IsBst(root.LeftNode, minValue, root.Data)
                && IsBst(root.RightNode, root.Data, maxValue))
            {
                return true;
            }

            return false;
        }
    }
}
