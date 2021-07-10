// <copyright file="FindTheHeightOfBinaryTree.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTree.Problems
{
    public class FindTheHeightOfBinaryTree
    {
        public int FindHeight(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return -1;
            }

            int heightOfLeft = FindHeight(root.LeftNode);
            int heightOfRight = FindHeight(root.RightNode);

            return Math.Max(heightOfLeft, heightOfRight) + 1;
        }
    }
}
