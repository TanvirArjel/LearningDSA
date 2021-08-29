// <copyright file="LowestCommonAncestor.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTree.Problems
{
    public static class LowestCommonAncestor
    {
        public static BinaryTreeNode<int> FindLca(BinaryTreeNode<int> root, int node1, int node2)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Data == node1 || root.Data == node2)
            {
                return root;
            }

            BinaryTreeNode<int> leftLca = FindLca(root.LeftNode, node1, node2);
            BinaryTreeNode<int> rightLca = FindLca(root.RightNode, node1, node2);

            if (leftLca == null && rightLca == null)
            {
                return null;
            }

            if (leftLca != null && rightLca != null)
            {
                return root;
            }

            return leftLca == null ? rightLca : leftLca;
        }
    }
}
