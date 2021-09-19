// <copyright file="MinimumDistanceBetweenAnyNodes.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.Bst.Problems
{
    public static class MinimumDistanceBetweenAnyNodes
    {
        private static int minDistance = int.MaxValue;

        public static int Find(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return minDistance;
            }

            if (root.LeftNode == null && root.RightNode == null)
            {
                return root.Data;
            }

            if (root.LeftNode != null)
            {
                int distance = root.Data - root.LeftNode.Data;
                minDistance = Math.Min(minDistance, distance);
            }

            if (root.RightNode != null)
            {
                int distance = root.RightNode.Data - root.Data;
                minDistance = Math.Min(minDistance, distance);
            }

            Find(root.LeftNode);
            Find(root.RightNode);

            return minDistance;
        }

        public static int Find2(BinaryTreeNode<int> root)
        {
            List<int> list = GetListInorder(root, new List<int>());

            int minDist = int.MaxValue;

            for (int i = 0; i < list.Count - 1; i++)
            {
                int currentDiff = list[i + 1] - list[i];
                minDist = Math.Min(minDist, currentDiff);
            }

            return minDist;
        }

        private static List<int> GetListInorder(BinaryTreeNode<int> root, List<int> list)
        {
            if (root == null)
            {
                return list;
            }

            GetListInorder(root.LeftNode, list);
            list.Add(root.Data);
            GetListInorder(root.RightNode, list);

            return list;
        }
    }
}
