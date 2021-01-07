// <copyright file="SinglyLinkedListNode.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class SinglyLinkedListNode<T> : Node<T>
    {
        public SinglyLinkedListNode(T data) : base(data, new NodeList<T>(1))
        {
            this.Next = null;
        }

        public SinglyLinkedListNode<T> Next
        {
            get
            {
                return (SinglyLinkedListNode<T>)Neighbours[0];
            }

            set
            {
                Neighbours[0] = value;
            }
        }
    }
}
