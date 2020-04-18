using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.DataStructures.Trees.BinaryTree
{
    // Problem: Given a Binary Tree, print the nodes of a binary tree in a pre-order fashion.
    // Input: Sample tree
    //              1
    //       2              3
    //   4       5       6       7
    // 

    // Output : 1 2 4 5 3 6 7

    // Algorithms:
    // In the pre-order traversal for a given node 'n',
    // 1. We first visit the node 'n' itself.
    // 2. Then we traverse left-subtree of 'n' by calling printPreOrder(n.left)
    // 3. And finally we traverse right-subtree of 'n' by calling printPreOrder(n.right)

    // Time Complexity is O(n)
    // Space Complexity is : O(1)

    public class BinaryTree
    {
        private TreeNode root;
        public BinaryTree()
        {
            // Initializing or Creating the Binary Sample Binray Tree here
            root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7)));
        }

        //public TreeNode GetRoot()
        //{
        //    return rootNode;
        //}
        class TreeNode
        {
            private int data;
            public int Data
            {
                get { return data; }
            }
            private TreeNode leftNode;
            public TreeNode LeftNode
            {
                get { return leftNode; }
            }

            private TreeNode rightNode;
            public TreeNode RightNode
            {
                get { return rightNode; }
            }

            // This constructor is for creating parent node.
            public TreeNode(int data, TreeNode leftNode, TreeNode rightNode)
            {
                this.data = data;
                this.leftNode = leftNode;
                this.rightNode = rightNode;
            }

            // This constructor is for creating leaf node.
            public TreeNode(int data)
            {
                this.data = data;
            }
            public void SetData(int data)
            {
                this.data = data;
            }

            public void SetLeftNode(TreeNode node)
            {
                this.leftNode = node;
            }

            public void SetRightNode(TreeNode right)
            {
                this.rightNode = right;
            }
        }


        public void PrintPreOrder()
        {
            PrintPreOrder(root);
        }

        private void PrintPreOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.Data);
            PrintPreOrder(node.LeftNode);
            PrintPreOrder(node.RightNode);
        }
    }
}
