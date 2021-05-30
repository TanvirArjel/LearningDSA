// <copyright file="SinglyLinkedList.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedList()
        {
            this.Head = null;
        }

        public SinglyLinkedListNode<int> Head { get; set; }

        public void AddToStart(int data)
        {
            if (Head == null)
            {
                Head = new SinglyLinkedListNode<int>(data);
                return;
            }

            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data)
            {
                Next = Head
            };

            Head = newNode;
        }

        public void AddToEnd(int data)
        {
            if (Head == null)
            {
                Head = new SinglyLinkedListNode<int>(data);
                return;
            }

            SinglyLinkedListNode<int> currentNode = Head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new SinglyLinkedListNode<int>(data);
        }

        public SinglyLinkedListNode<int> AddToEnd(SinglyLinkedListNode<int> head, int data)
        {
            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data);

            if (head == null)
            {
                head = newNode;
                return head;
            }

            SinglyLinkedListNode<int> currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            return head;
        }

        public SinglyLinkedListNode<int> AddToEnd(SinglyLinkedListNode<int> head, SinglyLinkedListNode<int> newNode)
        {
            if (head == null)
            {
                head = newNode;
                return head;
            }

            SinglyLinkedListNode<int> currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            return head;
        }

        public void AddToEndWithRecursion(SinglyLinkedListNode<int> head, int data)
        {
            if (head == null)
            {
                Head = new SinglyLinkedListNode<int>(data);
                return;
            }

            if (head.Next == null)
            {
                head.Next = new SinglyLinkedListNode<int>(data);
            }
            else
            {
                AddToEndWithRecursion(head.Next, data);
            }
        }

        public void Insert(int data, int position)
        {
            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data);

            if (position == 1)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            SinglyLinkedListNode<int> tempNode = Head;
            for (int i = 1; i < position - 1; i++)
            {
                tempNode = tempNode.Next;
            }

            newNode.Next = tempNode.Next;
            tempNode.Next = newNode;
        }

        public static int FindByIndexBackward(SinglyLinkedListNode<int> head, int indexFromTail)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head");
            }

            int index = 0;
            SinglyLinkedListNode<int> current = head;
            SinglyLinkedListNode<int> result = head;

            while (current != null)
            {
                current = current.Next;
                if (index++ > indexFromTail)
                {
                    result = result.Next;
                }
            }

            return result.Data;
        }

        public SinglyLinkedListNode<int> ReverseIterative(SinglyLinkedListNode<int> head)
        {
            SinglyLinkedListNode<int> current = head;
            SinglyLinkedListNode<int> prev = null;

            while (current != null)
            {
                SinglyLinkedListNode<int> next = current.Next; // Store the next node for iteration
                current.Next = prev; // Change the link to previous node

                prev = current; // Move the previous node one step forward
                current = next; // Move the current node one step forward
            }

            head = prev;
            Head = prev;
            return head;
        }

        public void ReverseRecursive(SinglyLinkedListNode<int> head)
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

            if (Head.Data == data)
            {
                Head = null;
                return;
            }

            SinglyLinkedListNode<int> prevNodeOfNodeToBeDeleted = Head;

            while (prevNodeOfNodeToBeDeleted.Next != null)
            {
                if (prevNodeOfNodeToBeDeleted.Next.Data == data)
                {
                    SinglyLinkedListNode<int> tempNode = prevNodeOfNodeToBeDeleted.Next.Next;
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

            SinglyLinkedListNode<int> prevNodeOfNodeToBeDeleted = Head;

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
                SinglyLinkedListNode<int> tempNode = prevNodeOfNodeToBeDeleted.Next.Next;
                prevNodeOfNodeToBeDeleted.Next = tempNode;
            }
        }

        public SinglyLinkedListNode<int> Delete(SinglyLinkedListNode<int> head, int position)
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

        public static SinglyLinkedListNode<int> RemoveDuplicatesFromSorted(SinglyLinkedListNode<int> head)
        {
            if (head == null)
            {
                return head;
            }

            SinglyLinkedListNode<int> current = head;

            while (current != null)
            {
                SinglyLinkedListNode<int> next = current.Next;

                while (next != null && current.Data == next.Data)
                {
                    next = next.Next;
                }

                current.Next = next;
                current = next;
            }

            return head;
        }

        public SinglyLinkedListNode<int> AddSorted(SinglyLinkedListNode<int> head, int data)
        {
            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data);

            if (head == null)
            {
                head = newNode;
                Head = newNode;
                return head;
            }

            if (data <= head.Data)
            {
                newNode.Next = head;
                head = newNode;
                Head = newNode;
                return head;
            }

            SinglyLinkedListNode<int> current = head;
            SinglyLinkedListNode<int> prev = null;

            while (current != null && newNode.Data > current.Data)
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
                Head = new SinglyLinkedListNode<int>(data);
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

        public SinglyLinkedListNode<int> MergeSorted(SinglyLinkedListNode<int> head1, SinglyLinkedListNode<int> head2)
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
                head1 = AddSorted(head1, head2.Data);
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
            SinglyLinkedListNode<int> currentNode = null;
            while (i <= size)
            {
                SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(i);
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
                SinglyLinkedListNode<int> currentNode = Head;
                while (currentNode != null)
                {
                    if (currentNode.Next != null)
                    {
                        Console.Write("|" + currentNode.Data + "|->");
                    }
                    else
                    {
                        Console.Write("|" + currentNode.Data + "|");
                    }

                    currentNode = currentNode.Next;
                }
            }
            else
            {
                Console.WriteLine("The LinkedList is empty. Please add some nodes to the LinkedList.");
            }
        }

        public void Print(SinglyLinkedListNode<int> head)
        {
            if (head == null)
            {
                Console.WriteLine("The LinkedList is empty. Please add some nodes to the LinkedList.");
                return;
            }

            SinglyLinkedListNode<int> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Next != null)
                {
                    Console.Write("|" + currentNode.Data + "|->");
                }
                else
                {
                    Console.Write("|" + currentNode.Data + "|");
                }

                currentNode = currentNode.Next;
            }
        }

        // Tail Recursion
        public void PrintRecursive(SinglyLinkedListNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            if (head.Next != null)
            {
                Console.Write("|" + head.Data + "|->");
            }
            else
            {
                Console.Write("|" + head.Data + "|");
            }

            PrintRecursive(head.Next);
        }

        // Head Recursion
        public void PrintReverseRecursive(SinglyLinkedListNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            PrintReverseRecursive(head.Next);

            Console.Write("|" + head.Data + "|->");
        }

        public bool Compare(SinglyLinkedListNode<int> head1, SinglyLinkedListNode<int> head2)
        {
            while (head1 != null && head2 != null && head1.Data == head2.Data)
            {
                head1 = head1.Next;
                head2 = head2.Next;
            }

            return head1 == head2;
        }

        public bool CompareRecursive(SinglyLinkedListNode<int> head1, SinglyLinkedListNode<int> head2)
        {
            if (head1 == null && head2 == null)
            {
                return true;
            }
            else if (head1 == null || head2 == null)
            {
                return false;
            }
            else if (head1.Data != head2.Data)
            {
                return false;
            }

            return CompareRecursive(head1.Next, head2.Next);
        }

        public static SinglyLinkedListNode<int> FindMergeNode(SinglyLinkedListNode<int> head1, SinglyLinkedListNode<int> head2)
        {
            if (head1 == null || head2 == null)
            {
                return null;
            }

            SinglyLinkedListNode<int> currentHead1 = head1;
            SinglyLinkedListNode<int> currentHead2 = head2;

            while (currentHead1 != currentHead2)
            {
                if (currentHead1 != null)
                {
                    currentHead1 = currentHead1.Next;
                }
                else
                {
                    currentHead1 = head2;
                }

                if (currentHead2 != null)
                {
                    currentHead2 = currentHead2.Next;
                }
                else
                {
                    currentHead2 = head1;
                }
            }

            return currentHead1;
        }

        private void AddSortedWithRecursion(SinglyLinkedListNode<int> node, int data)
        {
            if (node.Next == null)
            {
                node.Next = new SinglyLinkedListNode<int>(data);
            }
            else if (data < node.Next.Data)
            {
                SinglyLinkedListNode<int> tempNode = new SinglyLinkedListNode<int>(data)
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
