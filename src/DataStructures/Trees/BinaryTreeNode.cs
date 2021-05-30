// <copyright file="BinaryTreeNode.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode(T data) : base(data, new NodeList<T>(2))
        {
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> leftNode, BinaryTreeNode<T> rightNode) : base(data, new NodeList<T>(2))
        {
            Neighbours[0] = leftNode;
            Neighbours[1] = rightNode;
        }

        public BinaryTreeNode<T> LeftNode
        {
            get
            {
                return (BinaryTreeNode<T>)Neighbours[0];
            }

            set
            {
                Neighbours[0] = value;
            }
        }

        public BinaryTreeNode<T> RightNode
        {
            get
            {
                return (BinaryTreeNode<T>)Neighbours[1];
            }

            set
            {
                Neighbours[1] = value;
            }
        }
    }
}
