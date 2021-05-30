// <copyright file="PreOrderTraversal.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTreeTraversals
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
    public class PreOrderTraversal
    {
        private readonly BinaryTree<int> _binaryTree = new BinaryTree<int>();

        public PreOrderTraversal()
        {
            // Initializing or Creating the Sample Binray Tree here
            _binaryTree.Root = new BinaryTreeNode<int>(
                1,
                new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(4), new BinaryTreeNode<int>(5)),
                new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(6), new BinaryTreeNode<int>(7)));
        }

        public void PrintPreOrder()
        {
            PrintPreOrder(_binaryTree.Root);
        }

        public void PrintPreOrder<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.Data + " ");
            PrintPreOrder(node.LeftNode);
            PrintPreOrder(node.RightNode);
        }
    }
}
