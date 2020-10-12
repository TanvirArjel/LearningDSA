// <copyright file="PostOrderTraversal.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTreeTraversals
{
    // Problem: Given a Binary Tree, print the nodes of a binary tree in a post-order fashion.
    // Input: Sample tree
    //              1
    //       2              3
    //   4       5       6       7

    // Output : 4 5 2 6 7 3 1

    // Algorithms:
    // In the post-order traversal for a given node 'n',
    // 1. We first traverse left-subtree of 'n' by calling printPostorder(n.left)
    // 2. Then we traverse right-subtree of 'n' by calling printPostorder(n.right)
    // 3. And finally we visit node 'n' itself.

    // Time Complexity is O(n)
    // Space Complexity is : O(1)
    public class PostOrderTraversal
    {
        private readonly BinaryTree<int> _binaryTree = new BinaryTree<int>();

        public PostOrderTraversal()
        {
            // Initializing or Creating the Sample Binray Tree here
            _binaryTree.Root = new BinaryTreeNode<int>(
                1,
                new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(4), new BinaryTreeNode<int>(5)),
                new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(6), new BinaryTreeNode<int>(7)));
        }

        public void PrintPostOrder()
        {
            PrintPostOrder(_binaryTree.Root);
        }

        public void PrintPostOrder<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PrintPostOrder(node.LeftNode);
            PrintPostOrder(node.RightNode);
            Console.Write(node.Value + " ");
        }
    }
}
