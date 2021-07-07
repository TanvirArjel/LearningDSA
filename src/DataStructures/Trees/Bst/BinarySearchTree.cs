// <copyright file="BinarySearchTree.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Trees.Bst
{
    public static class BinarySearchTree
    {
        public static BinaryTreeNode<int> Insert(BinaryTreeNode<int> root, int data)
        {
            // create a new Node instance
            BinaryTreeNode<int> nodeToBeInserted = new BinaryTreeNode<int>(data);

            if (root == null)
            {
                return nodeToBeInserted;
            }

            // now, insert n into the treetrace down the tree until we hit a NULL
            BinaryTreeNode<int> current = root;
            while (current != null)
            {
                if (data == current.Data)
                {
                    // For attempting duplicate insertion you can raise exception or just ignore.
                    //// throw new ArgumentException("The data you are trying to add is already exists.");
                    break;
                }
                else if (data > current.Data)
                {
                    if (current.RightNode == null)
                    {
                        current.RightNode = nodeToBeInserted;
                        break;
                    }

                    current = current.RightNode;
                }
                else if (data < current.Data)
                {
                    if (current.LeftNode == null)
                    {
                        current.LeftNode = nodeToBeInserted;
                        break;
                    }

                    current = current.LeftNode;
                }
            }

            return root;
        }

        public static BinaryTreeNode<int> InsertRecursive(BinaryTreeNode<int> root, int data)
        {
            // create a new Node instance
            BinaryTreeNode<int> nodeToBeInserted = new BinaryTreeNode<int>(data);

            if (root == null)
            {
                root = nodeToBeInserted;
            }
            else if (data <= root.Data)
            {
                root.LeftNode = InsertRecursive(root.LeftNode, data);
            }
            else
            {
                root.RightNode = InsertRecursive(root.RightNode, data);
            }

            return root;
        }
    }
}
