using System;

namespace DataStructureAndAlgorithm.DataStructure.LinkedLists
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int dataValue)
        {
            Data = dataValue;
            Next = null;
        }
    }

    public class LinkedList
    {
        public Node Head;

        public LinkedList()
        {
            Head = null;
        }

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
                AddSortedWithRecursion(Head, data);
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
                AddSortedWithRecursion(node.Next, data);
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

        private void AddToEndWithRecursion(Node node, int data)
        {
            if (node.Next == null)
            {
                node.Next = new Node(data);
            }
            else
            {
                AddToEndWithRecursion(node.Next, data);
            }
        }

        public void PopulateLinkedList(int size)
        {
            if (size < 1)
                return;

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
    }
}
