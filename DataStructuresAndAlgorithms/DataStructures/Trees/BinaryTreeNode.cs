// <copyright file="BinaryTreeNode.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees
{
    public class BinaryTreeNode<T> : Node<T>
    {
        public BinaryTreeNode(T data) : base(data, null)
        {
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> leftNode, BinaryTreeNode<T> rightNode) : base(data)
        {
            NodeList<T> children = new NodeList<T>(2);
            children[0] = leftNode;
            children[1] = rightNode;

            Neighbours = children;
        }

        public BinaryTreeNode<T> LeftNode
        {
            get
            {
                if (Neighbours == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode<T>)Neighbours[0];
                }
            }

            set
            {
                if (Neighbours == null)
                {
                    Neighbours = new NodeList<T>(2);
                }

                Neighbours[0] = value;
            }
        }

        public BinaryTreeNode<T> RightNode
        {
            get
            {
                if (Neighbours == null)
                {
                    return null;
                }
                else
                {
                    return (BinaryTreeNode<T>)Neighbours[1];
                }
            }

            set
            {
                if (Neighbours == null)
                {
                    Neighbours = new NodeList<T>(2);
                }

                Neighbours[1] = value;
            }
        }
    }
}
