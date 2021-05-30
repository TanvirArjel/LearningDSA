// <copyright file="BinaryTree.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DataStructuresAndAlgorithms.DataStructures.Trees
{
    public class BinaryTree<T>
    {
        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTreeNode<T> Root { get; set; }

        // This is one of the depth first traversals.
        public void TraversePreOrder(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            Console.Write(root.Data);
            TraversePreOrder(root.LeftNode);
            TraversePreOrder(root.RightNode);
        }

        // This is one of the depth first traversals.
        public void TraverseInOrder(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            TraversePreOrder(root.LeftNode);
            Console.Write(root.Data);
            TraversePreOrder(root.RightNode);
        }

        // This is one of the depth first traversals.
        public void TraversePostOrder(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            TraversePreOrder(root.LeftNode);
            TraversePreOrder(root.RightNode);
            Console.Write(root.Data);
        }

        // This is breadth first traversal.
        public void TraverseLevelOrder(BinaryTreeNode<int> rootNode)
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
                Console.Write(currentNode.Data.ToString(CultureInfo.InvariantCulture) + " ");

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

        public void PrintTopView(BinaryTreeNode<int> root)
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

        public virtual void Clear()
        {
            Root = null;
        }
    }
}
