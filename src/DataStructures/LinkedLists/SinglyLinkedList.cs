// <copyright file="SinglyLinkedList.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class SinglyLinkedList
    {
        public static SinglyLinkedListNode<int> AddToStart(SinglyLinkedListNode<int> head, int data)
        {
            if (head == null)
            {
                head = new SinglyLinkedListNode<int>(data);
                return head;
            }

            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data)
            {
                Next = head
            };

            return newNode;
        }

        public static SinglyLinkedListNode<int> AddToEnd(SinglyLinkedListNode<int> head, int data)
        {
            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data);

            if (head == null)
            {
                return newNode;
            }

            SinglyLinkedListNode<int> currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = newNode;
            return head;
        }

        public static SinglyLinkedListNode<int> AddToEndWithRecursion(SinglyLinkedListNode<int> head, int data)
        {
            if (head == null)
            {
                return new SinglyLinkedListNode<int>(data);
            }

            if (head.Next == null)
            {
                head.Next = new SinglyLinkedListNode<int>(data);
            }
            else
            {
                AddToEndWithRecursion(head.Next, data);
            }

            return head;
        }

        public static SinglyLinkedListNode<int> Insert(SinglyLinkedListNode<int> head, int data, int position)
        {
            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data);

            if (head == null)
            {
                return newNode;
            }

            if (position < 1)
            {
                throw new ArgumentException("The value of position must be greater than 0.");
            }

            if (position == 1)
            {
                newNode.Next = head;
                return newNode;
            }

            SinglyLinkedListNode<int> tempNode = head;

            // We have to find the node before of the position at which new node will be inserted so that we can
            // make the new node as next node of that node (node before of the position).
            for (int i = 1; i < position - 1; i++)
            {
                tempNode = tempNode.Next;
            }

            newNode.Next = tempNode.Next;
            tempNode.Next = newNode;

            return head;
        }

        public static SinglyLinkedListNode<int> FindByIndexBackward(
            SinglyLinkedListNode<int> head,
            int indexFromTail)
        {
            if (head == null)
            {
                throw new ArgumentNullException("head");
            }

            int index = 0;
            SinglyLinkedListNode<int> result = head;

            while (head != null)
            {
                head = head.Next;
                if (index++ > indexFromTail)
                {
                    result = result.Next;
                }
            }

            return result;
        }

        public static SinglyLinkedListNode<int> ReverseIterative(SinglyLinkedListNode<int> head)
        {
            SinglyLinkedListNode<int> current = head;
            SinglyLinkedListNode<int> prev = null;

            while (current != null)
            {
                SinglyLinkedListNode<int> currentNext = current.Next; // Store the next node for iteration
                current.Next = prev; // Change the link to previous node

                prev = current; // Move the previous node one step forward
                current = currentNext; // Move the current node one step forward
            }

            head = prev;
            return head;
        }

        public static SinglyLinkedListNode<int> ReverseRecursive(SinglyLinkedListNode<int> head)
        {
            if (head == null)
            {
                return null;
            }

            SinglyLinkedListNode<int> reverseHead;

            if (head.Next == null)
            {
                reverseHead = head;
                return reverseHead;
            }

            reverseHead = ReverseRecursive(head.Next);

            SinglyLinkedListNode<int> current = head.Next;
            current.Next = head;
            head.Next = null;

            return reverseHead;
        }

        public static SinglyLinkedListNode<int> DeleteByData(SinglyLinkedListNode<int> head, int data)
        {
            if (head == null)
            {
                return null;
            }

            if (head.Data == data)
            {
                return head.Next;
            }

            SinglyLinkedListNode<int> currentNode = head;

            while (currentNode.Next != null)
            {
                if (currentNode.Next.Data == data)
                {
                    SinglyLinkedListNode<int> tempNode = currentNode.Next.Next;
                    currentNode.Next = tempNode;
                    return head;
                }

                currentNode = currentNode.Next;
            }

            return head;
        }

        public static SinglyLinkedListNode<int> DeleteByIndex(SinglyLinkedListNode<int> head, int index)
        {
            if (head == null)
            {
                return null;
            }

            if (index == 0)
            {
                return head.Next;
            }

            SinglyLinkedListNode<int> prevNodeOfNodeToBeDeleted = head;

            for (int i = 0; i < index - 1; i++)
            {
                prevNodeOfNodeToBeDeleted = prevNodeOfNodeToBeDeleted.Next;
            }

            if (prevNodeOfNodeToBeDeleted.Next != null)
            {
                SinglyLinkedListNode<int> tempNode = prevNodeOfNodeToBeDeleted.Next.Next;
                prevNodeOfNodeToBeDeleted.Next = tempNode;
            }

            return head;
        }

        public static SinglyLinkedListNode<int> Delete(SinglyLinkedListNode<int> head, int position)
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

        public static SinglyLinkedListNode<int> AddSorted(SinglyLinkedListNode<int> head, int data)
        {
            SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(data);

            if (head == null)
            {
                return newNode;
            }

            if (data <= head.Data)
            {
                newNode.Next = head;
                return newNode;
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

        public static SinglyLinkedListNode<int> MergeSorted(SinglyLinkedListNode<int> head1, SinglyLinkedListNode<int> head2)
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

        public static SinglyLinkedListNode<int> Create(int size)
        {
            if (size < 1)
            {
                return null;
            }

            SinglyLinkedListNode<int> head = new SinglyLinkedListNode<int>(1);

            int i = 2;
            while (i <= size)
            {
                SinglyLinkedListNode<int> newNode = new SinglyLinkedListNode<int>(i);
                SinglyLinkedListNode<int> curretNode = head;

                while (curretNode.Next != null)
                {
                    curretNode = curretNode.Next;
                }

                curretNode.Next = newNode;

                i++;
            }

            return head;
        }

        public static void Print(SinglyLinkedListNode<int> head)
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
        public static void PrintRecursive(SinglyLinkedListNode<int> head)
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

        // head Recursion
        public static void PrintReverseRecursive(SinglyLinkedListNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            PrintReverseRecursive(head.Next);

            Console.Write("|" + head.Data + "|->");
        }

        public static bool Compare(SinglyLinkedListNode<int> head1, SinglyLinkedListNode<int> head2)
        {
            while (head1 != null && head2 != null && head1.Data == head2.Data)
            {
                head1 = head1.Next;
                head2 = head2.Next;
            }

            return head1 == head2;
        }

        public static bool CompareRecursive(SinglyLinkedListNode<int> head1, SinglyLinkedListNode<int> head2)
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

            SinglyLinkedListNode<int> currenthead1 = head1;
            SinglyLinkedListNode<int> currenthead2 = head2;

            while (currenthead1 != currenthead2)
            {
                if (currenthead1 != null)
                {
                    currenthead1 = currenthead1.Next;
                }
                else
                {
                    currenthead1 = head2;
                }

                if (currenthead2 != null)
                {
                    currenthead2 = currenthead2.Next;
                }
                else
                {
                    currenthead2 = head1;
                }
            }

            return currenthead1;
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
