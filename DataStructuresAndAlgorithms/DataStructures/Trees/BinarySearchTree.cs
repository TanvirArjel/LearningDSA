// <copyright file="BinarySearchTree.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees
{
    public class BinarySearchTree
    {
        public BinarySearchTree()
        {
            Root = null;
        }

        public BinaryTreeNode<int> Root { get; set; }

        public virtual void Clear()
        {
            Root = null;
        }

        public void Add(int data)
        {
            // create a new Node instance
            BinaryTreeNode<int> nodeToBeAdded = new BinaryTreeNode<int>(data);

            // now, insert n into the treetrace down the tree until we hit a NULL
            BinaryTreeNode<int> current = Root, parent = null;
            while (current != null)
            {
                if (data == current.Data)
                {
                    // For attempting duplicate insertion you can raise exception or just ignore.
                    //// throw new ArgumentException("The data you are trying to add is already exists.");
                    return;
                }
                else if (data > current.Data)
                {
                    // data > current.Value, must add new Node to current's right subtree
                    parent = current;
                    current = current.RightNode;
                }
                else if (data < current.Data)
                {
                    // data < current.Value, must add new Node to current's left subtree
                    parent = current;
                    current = current.LeftNode;
                }
            }

            if (parent == null)
            {
                Root = nodeToBeAdded;
            }
            else
            {
                // data >  parent.Value, therefore the new Node must be added to the right subtree
                if (data > parent.Data)
                {
                    parent.RightNode = nodeToBeAdded;
                }
                else
                {
                    parent.LeftNode = nodeToBeAdded;
                }
            }
        }
    }
}
