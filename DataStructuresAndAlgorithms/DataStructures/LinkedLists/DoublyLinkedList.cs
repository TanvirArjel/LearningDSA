// <copyright file="DoublyLinkedList.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public static class DoublyLinkedList
    {
        public static DoublyLinkedListNode<int> InsertAtHead(DoublyLinkedListNode<int> head, int data)
        {
            DoublyLinkedListNode<int> newNode = new DoublyLinkedListNode<int>(data);

            if (head == null)
            {
                head = newNode;
                return head;
            }

            head.Prev = newNode;
            newNode.Next = head;

            return newNode;
        }

        public static DoublyLinkedListNode<int> InsertAtTail(DoublyLinkedListNode<int> head, int data)
        {
            DoublyLinkedListNode<int> newNode = new DoublyLinkedListNode<int>(data);

            if (head == null)
            {
                head = newNode;
                return head;
            }

            DoublyLinkedListNode<int> lastNode = head;

            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            newNode.Prev = lastNode;
            lastNode.Next = newNode;

            return head;
        }

        public static DoublyLinkedListNode<int> InsertSorted(DoublyLinkedListNode<int> head, int data)
        {
            DoublyLinkedListNode<int> newNode = new DoublyLinkedListNode<int>(data);

            if (head == null)
            {
                return newNode;
            }

            if (data <= head.Data)
            {
                newNode.Next = head;
                head.Prev = newNode;
                return newNode;
            }

            DoublyLinkedListNode<int> currentNode = head;

            while (currentNode.Next != null && data > currentNode.Next.Data)
            {
                currentNode = currentNode.Next;
            }

            DoublyLinkedListNode<int> nextOfCurrent = currentNode.Next;
            newNode.Next = nextOfCurrent;

            if (nextOfCurrent != null)
            {
                nextOfCurrent.Prev = newNode;
            }

            newNode.Prev = currentNode;
            currentNode.Next = newNode;

            return head;
        }

        public static DoublyLinkedListNode<int> Reverse(DoublyLinkedListNode<int> head)
        {
            if (head == null)
            {
                return head;
            }

            DoublyLinkedListNode<int> current = head;
            DoublyLinkedListNode<int> newHead = head;

            while (current != null)
            {
                DoublyLinkedListNode<int> prev = current.Prev;

                current.Prev = current.Next;
                current.Next = prev;

                newHead = current;
                current = current.Prev; // Item in the next in iteration has been the prev of current.
            }

            return newHead;

        }

        public static void Print(DoublyLinkedListNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            DoublyLinkedListNode<int> currentNode = head;
            while (currentNode != null)
            {
                Console.Write(currentNode.Data + "->");
                currentNode = currentNode.Next;
            }
        }
    }
}
