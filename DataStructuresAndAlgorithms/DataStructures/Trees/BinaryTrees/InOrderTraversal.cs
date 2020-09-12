// <copyright file="InOrderTraversal.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTrees
{
    // Problem: Given a Binary Tree, print the nodes of a binary tree in a in-order fashion.
    // Input: Sample tree
    //              1
    //       2              3
    //   4       5       6       7

    // Output : 4 2 5 1 6 3 7

    // Algorithms:
    // In the post-order traversal for a given node 'n',
    // 1. We first traverse left-subtree of 'n' by calling printPostorder(n.left)
    // 2. Then finally we visit node 'n' itself.
    // 2. And finally we traverse right-subtree of 'n' by calling printPostorder(n.right)

    // Time Complexity is O(n)
    // Space Complexity is : O(1)
    public class InOrderTraversal
    {
        private readonly BinaryTree<int> _binaryTree = new BinaryTree<int>();

        public InOrderTraversal()
        {
            // Initializing or Creating the Sample Binray Tree here
            _binaryTree.Root = new BinaryTreeNode<int>(
                1,
                new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(4), new BinaryTreeNode<int>(5)),
                new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(6), new BinaryTreeNode<int>(7)));
        }

        public void PrintInOrder()
        {
            PrintInOrder(_binaryTree.Root);
        }

        public void PrintInOrder<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PrintInOrder(node.LeftNode);
            Console.Write(node.Value + " ");
            PrintInOrder(node.RightNode);
        }
    }
}
