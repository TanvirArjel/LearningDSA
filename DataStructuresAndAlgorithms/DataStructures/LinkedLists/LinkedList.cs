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
                return;
            }

            LinkedListNode<int> newNode = new LinkedListNode<int>(data)
            {
                Next = Head
            };

            Head = newNode;
        }

        public void AddToEnd(int data)
        {
            if (Head == null)
            {
                Head = new LinkedListNode<int>(data);
                return;
            }

            LinkedListNode<int> currentNode = Head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new LinkedListNode<int>(data);
        }

        public LinkedListNode<int> AddToEnd(LinkedListNode<int> head, int data)
        {
            LinkedListNode<int> newNode = new LinkedListNode<int>(data);

            if (head == null)
            {
                head = newNode;
                return head;
            }

            LinkedListNode<int> currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            return head;
        }

        public void AddToEndWithRecursion(LinkedListNode<int> head, int data)
        {
            if (head == null)
            {
                Head = new LinkedListNode<int>(data);
                return;
            }

            if (head.Next == null)
            {
                head.Next = new LinkedListNode<int>(data);
            }
            else
            {
                AddToEndWithRecursion(head.Next, data);
            }
        }

        public void Insert(int data, int position)
        {
            LinkedListNode<int> newNode = new LinkedListNode<int>(data);

            if (position == 1)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            LinkedListNode<int> tempNode = Head;
            for (int i = 1; i < position - 1; i++)
            {
                tempNode = tempNode.Next;
            }

            newNode.Next = tempNode.Next;
            tempNode.Next = newNode;
        }

        public static int FindByIndexBackward(LinkedListNode<int> head, int indexFromTail)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head");
            }

            int index = 0;
            LinkedListNode<int> current = head;
            LinkedListNode<int> result = head;

            while (current != null)
            {
                current = current.Next;
                if (index++ > indexFromTail)
                {
                    result = result.Next;
                }
            }

            return result.Value;
        }

        public LinkedListNode<int> ReverseIterative(LinkedListNode<int> head)
        {
            LinkedListNode<int> current = head;
            LinkedListNode<int> prev = null;

            while (current != null)
            {
                LinkedListNode<int> next = current.Next; // Store the next node for iteration
                current.Next = prev; // Change the link to previous node

                prev = current; // Move the previous node one step forward
                current = next; // Move the current node one step forward
            }

            head = prev;
            Head = prev;
            return head;
        }

        public void ReverseRecursive(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            if (head.Next == null)
            {
                Head = head;
                return;
            }

            ReverseRecursive(head.Next);

            head.Next.Next = head;
            head.Next = null;
        }

        public void DeleteByData(int data)
        {
            if (Head == null)
            {
                return;
            }

            if (Head.Value == data)
            {
                Head = null;
                return;
            }

            LinkedListNode<int> prevNodeOfNodeToBeDeleted = Head;

            while (prevNodeOfNodeToBeDeleted.Next != null)
            {
                if (prevNodeOfNodeToBeDeleted.Next.Value == data)
                {
                    LinkedListNode<int> tempNode = prevNodeOfNodeToBeDeleted.Next.Next;
                    prevNodeOfNodeToBeDeleted.Next = tempNode;
                    return;
                }

                prevNodeOfNodeToBeDeleted = prevNodeOfNodeToBeDeleted.Next;
            }
        }

        public void DeleteByIndex(int index)
        {
            if (Head == null)
            {
                return;
            }

            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            LinkedListNode<int> prevNodeOfNodeToBeDeleted = Head;

            for (int i = 0; i < index - 1; i++)
            {
                prevNodeOfNodeToBeDeleted = prevNodeOfNodeToBeDeleted.Next;
                if (prevNodeOfNodeToBeDeleted == null)
                {
                    return;
                }
            }

            if (prevNodeOfNodeToBeDeleted.Next != null)
            {
                LinkedListNode<int> tempNode = prevNodeOfNodeToBeDeleted.Next.Next;
                prevNodeOfNodeToBeDeleted.Next = tempNode;
            }
        }

        public LinkedListNode<int> Delete(LinkedListNode<int> head, int position)
        {
            if (head == null)
            {
                return head;
            }

            if (position == 0)
            {
                return head.Next;
            }

            head.Next = Delete(head.Next, position - 1);
            return head;
        }

        public static LinkedListNode<int> RemoveDuplicatesFromSorted(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return head;
            }

            LinkedListNode<int> current = head;

            while (current != null)
            {
                LinkedListNode<int> next = current.Next;

                while (next != null && current.Value == next.Value)
                {
                    next = next.Next;
                }

                current.Next = next;
                current = next;
            }

            return head;
        }

        public LinkedListNode<int> AddSorted(LinkedListNode<int> head, int data)
        {
            LinkedListNode<int> newNode = new LinkedListNode<int>(data);

            if (head == null)
            {
                head = newNode;
                Head = newNode;
                return head;
            }

            if (data <= head.Value)
            {
                newNode.Next = head;
                head = newNode;
                Head = newNode;
                return head;
            }

            LinkedListNode<int> current = head;
            LinkedListNode<int> prev = null;

            while (current != null && newNode.Value > current.Value)
            {
                prev = current;
                current = current.Next;
            }

            prev.Next = newNode;
            newNode.Next = current;
            return head;
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

        public LinkedListNode<int> MergeSorted(LinkedListNode<int> head1, LinkedListNode<int> head2)
        {
            if (head1 == null)
            {
                return head2;
            }

            if (head2 == null)
            {
                return head1;
            }

            while (head2 != null)
            {
                head1 = AddSorted(head1, head2.Value);
                head2 = head2.Next;
            }

            return head1;
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
                    if (currentNode.Next != null)
                    {
                        Console.Write("|" + currentNode.Value + "|->");
                    }
                    else
                    {
                        Console.Write("|" + currentNode.Value + "|");
                    }

                    currentNode = currentNode.Next;
                }
            }
            else
            {
                Console.WriteLine("The LinkedList is empty. Please add some nodes to the LinkedList.");
            }
        }

        public void Print(LinkedListNode<int> head)
        {
            if (head == null)
            {
                Console.WriteLine("The LinkedList is empty. Please add some nodes to the LinkedList.");
                return;
            }

            LinkedListNode<int> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Next != null)
                {
                    Console.Write("|" + currentNode.Value + "|->");
                }
                else
                {
                    Console.Write("|" + currentNode.Value + "|");
                }

                currentNode = currentNode.Next;
            }
        }

        // Tail Recursion
        public void PrintRecursive(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            if (head.Next != null)
            {
                Console.Write("|" + head.Value + "|->");
            }
            else
            {
                Console.Write("|" + head.Value + "|");
            }

            PrintRecursive(head.Next);
        }

        // Head Recursion
        public void PrintReverseRecursive(LinkedListNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            PrintReverseRecursive(head.Next);

            Console.Write("|" + head.Value + "|->");
        }

        public bool Compare(LinkedListNode<int> head1, LinkedListNode<int> head2)
        {
            while (head1 != null && head2 != null && head1.Value == head2.Value)
            {
                head1 = head1.Next;
                head2 = head2.Next;
            }

            return head1 == head2;
        }

        public bool CompareRecursive(LinkedListNode<int> head1, LinkedListNode<int> head2)
        {
            if (head1 == null && head2 == null)
            {
                return true;
            }
            else if (head1 == null || head2 == null)
            {
                return false;
            }
            else if (head1.Value != head2.Value)
            {
                return false;
            }

            return CompareRecursive(head1.Next, head2.Next);
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
    }
}
