// <copyright file="LinkedListNode.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class LinkedListNode<T> : Node<T>
    {
        public LinkedListNode(T data) : base(data)
        {
            this.Next = null;
        }

        public LinkedListNode<T> Next { get; set; }
    }
}
