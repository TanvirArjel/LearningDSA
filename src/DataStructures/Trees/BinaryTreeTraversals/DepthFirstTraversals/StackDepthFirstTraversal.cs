// <copyright file="StackDepthFirstTraversal.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTreeTraversals.DepthFirstTraversals
{
    public static class StackDepthFirstTraversal
    {
        public static void Print(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return;
            }

            Dictionary<int, BinaryTreeNode<int>> visitedNodes = new Dictionary<int, BinaryTreeNode<int>>();

            Stack<BinaryTreeNode<int>> nodesToBeExplored = new Stack<BinaryTreeNode<int>>();
            nodesToBeExplored.Push(root);

            while (nodesToBeExplored.Any())
            {
                BinaryTreeNode<int> currentNode = nodesToBeExplored.Peek();

                if (!visitedNodes.ContainsKey(currentNode.Data))
                {
                    Console.Write(currentNode.Data.ToString(CultureInfo.InvariantCulture) + " ");
                    visitedNodes.Add(currentNode.Data, currentNode);
                }

                if ((currentNode.LeftNode == null && currentNode.RightNode == null)
                    || (visitedNodes.ContainsKey(currentNode.LeftNode.Data)
                         && visitedNodes.ContainsKey(currentNode.RightNode.Data)))
                {
                    nodesToBeExplored.Pop();
                    continue;
                }

                if (currentNode.LeftNode != null && !visitedNodes.ContainsKey(currentNode.LeftNode.Data))
                {
                    nodesToBeExplored.Push(currentNode.LeftNode);
                    continue;
                }

                if (currentNode.RightNode != null && !visitedNodes.ContainsKey(currentNode.RightNode.Data))
                {
                    nodesToBeExplored.Push(currentNode.RightNode);
                }
            }
        }
    }
}
