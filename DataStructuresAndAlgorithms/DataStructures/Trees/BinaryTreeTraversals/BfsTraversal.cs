// <copyright file="BfsTraversal.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTreeTraversals
{
    internal static class BfsTraversal
    {
        public static void PrintBfsTraversal(BinaryTreeNode<int> rootNode)
        {
            if (rootNode == null)
            {
                return;
            }

            Queue<BinaryTreeNode<int>> nodesToBeExplored = new Queue<BinaryTreeNode<int>>();
            nodesToBeExplored.Enqueue(rootNode);

            while (nodesToBeExplored.Any())
            {
                BinaryTreeNode<int> currentNode = nodesToBeExplored.Dequeue();
                Console.Write(currentNode.Value.ToString(CultureInfo.InvariantCulture) + " ");

                if (currentNode.LeftNode != null)
                {
                    nodesToBeExplored.Enqueue(currentNode.LeftNode);
                }

                if (currentNode.RightNode != null)
                {
                    nodesToBeExplored.Enqueue(currentNode.RightNode);
                }
            }
        }

        // Input: Sample tree
        //              1
        //       2              3
        //   4       5       6       7

        // Output : 1 2 3 4 5 6 7
        public static void PrintBfsTraversalWithDefaultData()
        {
            BinaryTreeNode<int> root = new BinaryTreeNode<int>(1, new BinaryTreeNode<int>(2, new BinaryTreeNode<int>(4), new BinaryTreeNode<int>(5)), new BinaryTreeNode<int>(3, new BinaryTreeNode<int>(6), new BinaryTreeNode<int>(7)));
            PrintBfsTraversal(root);
        }
    }
}
