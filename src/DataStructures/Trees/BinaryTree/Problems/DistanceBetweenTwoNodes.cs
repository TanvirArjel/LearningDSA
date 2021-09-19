// <copyright file="DistanceBetweenTwoNodes.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTree.Problems
{
    // Explanation: 1. First find the LCA between two nodes
    // 2. Find the distances between LCA and the two nodes.
    // 3. The the sum fo the two distances is the distance between two nodes.
    internal static class DistanceBetweenTwoNodes
    {
        public static int FindDistance(BinaryTreeNode<int> root, int node1, int node2)
        {
            BinaryTreeNode<int> lca = FindLca(root, node1, node2);

            int distance1 = FindLevelFromRoot(lca, node1, 0);
            int distance2 = FindLevelFromRoot(lca, node2, 0);
            return distance1 + distance2;
        }

        private static int FindLevelFromRoot(BinaryTreeNode<int> root, int node, int level)
        {
            if (root == null)
            {
                return -1;
            }

            if (root.Data == node)
            {
                return level;
            }

            int left = FindLevelFromRoot(root.LeftNode, node, level + 1);

            if (left > -1)
            {
                return left;
            }

            int right = FindLevelFromRoot(root.RightNode, node, level + 1);
            return level + 1;
        }

        private static BinaryTreeNode<int> FindLca(BinaryTreeNode<int> root, int node1, int node2)
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

            if (leftLca != null && rightLca != null)
            {
                return root;
            }

            if (leftLca == null && rightLca == null)
            {
                return null;
            }

            return leftLca == null ? rightLca : leftLca;
        }
    }
}
