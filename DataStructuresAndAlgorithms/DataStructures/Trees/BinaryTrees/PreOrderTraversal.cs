// <copyright file="PreOrderTraversal.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTrees
{
    // Problem: Given a Binary Tree, print the nodes of a binary tree in a pre-order fashion.
    // Input: Sample tree
    //              1
    //       2              3
    //   4       5       6       7

    // Output : 1 2 4 5 3 6 7

    // Algorithms:
    // In the pre-order traversal for a given node 'n',
    // 1. We first visit the node 'n' itself.
    // 2. Then we traverse left-subtree of 'n' by calling printPreOrder(n.left)
    // 3. And finally we traverse right-subtree of 'n' by calling printPreOrder(n.right)

    // Time Complexity is O(n)
    // Space Complexity is : O(1)
    public class BinaryTree
    {
        private TreeNode root;

        public BinaryTree()
        {
            // Initializing or Creating the Binary Sample Binray Tree here
            root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7)));
        }

        public void PrintPreOrder()
        {
            PrintPreOrder(root);
        }

        private void PrintPreOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.Data);
            PrintPreOrder(node.LeftNode);
            PrintPreOrder(node.RightNode);
        }

        private class TreeNode
        {
            // This constructor is for creating leaf node.
            public TreeNode(int data)
            {
                Data = data;
            }

            // This constructor is for creating parent node.
            public TreeNode(int data, TreeNode leftNode, TreeNode rightNode)
            {
                Data = data;
                LeftNode = leftNode;
                RightNode = rightNode;
            }

            public int Data { get; set; }

            public TreeNode LeftNode { get; set; }

            public TreeNode RightNode { get; set; }
        }
    }
}
