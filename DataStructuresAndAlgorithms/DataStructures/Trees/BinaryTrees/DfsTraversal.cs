// <copyright file="DfsTraversal.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTrees
{
    internal class DfsTraversal
    {
        public static void PrintDfsTraversal(BinaryTreeNode<int> node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.Value + " ");
            PrintDfsTraversal(node.LeftNode);
            PrintDfsTraversal(node.RightNode);
        }

        // Input: Sample tree
        //              1
        //       2              3
        //   4       5       6       7

        // Output : 1 2 4 5 3 6 7
        public static void PrintBfsTraversalWithDefaultData()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(
                1,
                new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(4), new BinaryTreeNode<int>(5)),
                new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(6), new BinaryTreeNode<int>(7)));
            PrintDfsTraversal(root);
        }
    }
}
