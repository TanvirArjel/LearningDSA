// <copyright file="ReversingLinkedList_Iterative.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public static class ReversingLinkedListIterative
    {
        public static LinkedList ReverseLinkedList(LinkedList inputLinkedList)
        {
            if (inputLinkedList == null)
            {
                throw new ArgumentNullException("inputLinkedList");
            }

            LinkedListNode<int> previousNode = null, currentNode = inputLinkedList.Head;
            while (currentNode != null)
            {
                LinkedListNode<int> originalNext = currentNode.Next; // Before changing next of current, store next node
                currentNode.Next = previousNode; // Now change next of current, This is where actual reversing happens

                // Move previous and current one step forward
                previousNode = currentNode;
                currentNode = originalNext;
            }

            inputLinkedList.Head = previousNode;

            return inputLinkedList;
        }
    }
}
