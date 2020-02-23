using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructureAndAlgorithm
{
    public class Node
    {
        public int Data;
        public Node NextNode;

        public Node(int dataValue)
        {
            Data = dataValue;
            NextNode = null;
        }
    }

    public class MyLinkedList
    {
        public Node HeadNode;

        public MyLinkedList()
        {
            HeadNode = null;
        }

        public void AddSorted(int data)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(data);
            }
            else if (data < HeadNode.Data)
            {
                AddToStart(data);
            }
            else
            {
                AddSortedWithRecursion(HeadNode, data);
            }

        }

        private void AddSortedWithRecursion(Node node, int data)
        {
            if (node.NextNode == null)
            {
                node.NextNode = new Node(data);
            }
            else if (data < node.NextNode.Data)
            {
                Node tempNode = new Node(data);
                tempNode.NextNode = node.NextNode;
                node.NextNode = tempNode;
            }
            else
            {
                AddSortedWithRecursion(node.NextNode, data);
            }
        }

        public void AddToStart(int data)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(data);
            }
            else
            {
                Node tempNode = new Node(data);
                tempNode.NextNode = HeadNode;
                HeadNode = tempNode;
            }
        }

        public void AddToEnd(int data)
        {
            if (HeadNode == null)
            {
                HeadNode = new Node(data);
            }
            else
            {
                AddToEndWithRecursion(HeadNode, data);
            }

        }

        private void AddToEndWithRecursion(Node node, int data)
        {
            if (node.NextNode == null)
            {
                node.NextNode = new Node(data);
            }
            else
            {
                AddToEndWithRecursion(node.NextNode, data);
            }
        }


        public void Print()
        {
            if (HeadNode != null)
            {
                Console.Write("|" + HeadNode.Data + "|->");
                Node nextNode = HeadNode.NextNode;
                while (nextNode != null)
                {
                    Console.Write("|" + nextNode.Data + "|->");
                    nextNode = nextNode.NextNode;
                }

            }
        }
    }
}
