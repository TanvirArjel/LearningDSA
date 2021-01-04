// <copyright file="LinkedList.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class LinkedList
    {
        public LinkedList()
        {
            this.Head = null;
        }

        public LinkedListNode<int> Head { get; set; }

        public void AddToStart(int data)
        {
            if (Head == null)
            {
                Head = new LinkedListNode<int>(data);
            }
            else
            {
                LinkedListNode<int> newNode = new LinkedListNode<int>(data)
                {
                    Next = Head
                };

                Head = newNode;
            }
        }

        public void AddToEnd(int data)
        {
            if (Head == null)
            {
                Head = new LinkedListNode<int>(data);
            }
            else
            {
                AddToEndWithWhile(Head, data);
            }
        }

        public void AddSorted(int data)
        {
            if (Head == null)
            {
                Head = new LinkedListNode<int>(data);
            }
            else if (data < Head.Value)
            {
                AddToStart(data);
            }
            else
            {
                this.AddSortedWithRecursion(Head, data);
            }
        }

        public void PopulateLinkedList(int size)
        {
            if (size < 1)
            {
                return;
            }

            int i = 1;
            LinkedListNode<int> currentNode = null;
            while (i <= size)
            {
                LinkedListNode<int> newNode = new LinkedListNode<int>(i);
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
                LinkedListNode<int> currentNode = Head;
                while (currentNode != null)
                {
                    Console.Write("|" + currentNode.Value + "|->");
                    currentNode = currentNode.Next;
                }
            }
            else
            {
                Console.WriteLine("The LinkedList is empty. Please add some nodes to the LinkedList.");
            }
        }

        private void AddSortedWithRecursion(LinkedListNode<int> node, int data)
        {
            if (node.Next == null)
            {
                node.Next = new LinkedListNode<int>(data);
            }
            else if (data < node.Next.Value)
            {
                LinkedListNode<int> tempNode = new LinkedListNode<int>(data)
                {
                    Next = node.Next
                };
                node.Next = tempNode;
            }
            else
            {
                this.AddSortedWithRecursion(node.Next, data);
            }
        }

        private void AddToEndWithRecursion(LinkedListNode<int> node, int data)
        {
            if (node != null)
            {
                if (node.Next == null)
                {
                    node.Next = new LinkedListNode<int>(data);
                }
                else
                {
                    this.AddToEndWithRecursion(node.Next, data);
                }
            }
            else
            {
                Head = new LinkedListNode<int>(data);
                return;
            }
        }

        private void AddToEndWithWhile(LinkedListNode<int> head, int data)
        {
            if (head != null)
            {
                LinkedListNode<int> currentNode = head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = new LinkedListNode<int>(data);
            }
            else
            {
                Head = new LinkedListNode<int>(data);
            }
        }
    }
}
