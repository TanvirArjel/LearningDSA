// <copyright file="PrintTopView.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTree.Problems
{
    public static class PrintTopView
    {
        public static void Print(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return;
            }

            Queue<QueueObj> queueObjs = new Queue<QueueObj>();
            queueObjs.Enqueue(new QueueObj(root, 0));

            SortedDictionary<int, BinaryTreeNode<int>> topNodes = new SortedDictionary<int, BinaryTreeNode<int>>();

            while (queueObjs.Any())
            {
                QueueObj currentQueueObj = queueObjs.Dequeue();
                if (!topNodes.ContainsKey(currentQueueObj.Hd))
                {
                    topNodes[currentQueueObj.Hd] = currentQueueObj.Node;
                }

                if (currentQueueObj.Node.LeftNode != null)
                {
                    queueObjs.Enqueue(new QueueObj(currentQueueObj.Node.LeftNode, currentQueueObj.Hd - 1));
                }

                if (currentQueueObj.Node.RightNode != null)
                {
                    queueObjs.Enqueue(new QueueObj(currentQueueObj.Node.RightNode, currentQueueObj.Hd + 1));
                }
            }

            foreach (KeyValuePair<int, BinaryTreeNode<int>> item in topNodes)
            {
                Console.Write(item.Value.Data + " ");
            }
        }

        private class QueueObj
        {
            public QueueObj(BinaryTreeNode<int> node, int level)
            {
                Node = node;
                Hd = level;
            }

            public BinaryTreeNode<int> Node { get; set; }

            public int Hd { get; set; }
        }
    }
}
