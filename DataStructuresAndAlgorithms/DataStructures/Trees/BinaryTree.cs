// <copyright file="BinaryTree.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees
{
    public class BinaryTree<T>
    {
        public BinaryTree()
        {
            Root = null;
        }

        public BinaryTreeNode<T> Root { get; set; }

        public virtual void Clear()
        {
            Root = null;
        }
    }
}
