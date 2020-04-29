// <copyright file="LinkedList.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class Node
    {
        public Node(int dataValue)
        {
            this.Data = dataValue;
            this.Next = null;
        }

        public int Data { get; set; }

        public Node Next { get; set; }
    }

    public class LinkedList
    {
        public LinkedList()
        {
            this.Head = null;
        }

        public Node Head { get; set; }

        public void AddSorted(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else if (data < Head.Data)
            {
                AddToStart(data);
            }
            else
            {
                this.AddSortedWithRecursion(Head, data);
            }
        }

        public void AddToStart(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else
            {
                Node tempNode = new Node(data);
                tempNode.Next = Head;
                Head = tempNode;
            }
        }

        public void AddToEnd(int data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else
            {
                AddToEndWithRecursion(Head, data);
            }
        }

        public void PopulateLinkedList(int size)
        {
            if (size < 1)
            {
                return;
            }

            int i = 1;
            Node currentNode = null;
            while (i <= size)
            {
                Node newNode = new Node(i);
                if (Head == null)
                {
                    Head = newNode;
                    currentNode = Head;
                }
                else
                {
                    if (currentNode != null)
                    {
                        currentNode.Next = newNode;
                    }

                    currentNode = newNode;
                }

                i++;
            }
        }

        public void Print()
        {
            if (Head != null)
            {
                Node currentNode = Head;
                while (currentNode != null)
                {
                    Console.Write("|" + currentNode.Data + "|->");
                    currentNode = currentNode.Next;
                }
            }
            else
            {
                Console.WriteLine("The LinkedList is empty. Please add some nodes the LinkedList.");
            }
        }

        private void AddSortedWithRecursion(Node node, int data)
        {
            if (node.Next == null)
            {
                node.Next = new Node(data);
            }
            else if (data < node.Next.Data)
            {
                Node tempNode = new Node(data);
                tempNode.Next = node.Next;
                node.Next = tempNode;
            }
            else
            {
                this.AddSortedWithRecursion(node.Next, data);
            }
        }

        private void AddToEndWithRecursion(Node node, int data)
        {
            if (node.Next == null)
            {
                node.Next = new Node(data);
            }
            else
            {
                this.AddToEndWithRecursion(node.Next, data);
            }
        }
    }
}
