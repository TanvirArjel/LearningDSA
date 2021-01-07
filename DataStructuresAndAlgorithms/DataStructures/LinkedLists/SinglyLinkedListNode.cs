// <copyright file="SinglyLinkedListNode.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class SinglyLinkedListNode<T> : Node<T>
    {
        private SinglyLinkedListNode<T> _next;

        public SinglyLinkedListNode(T data) : base(data)
        {
            this.Next = null;
        }

        public SinglyLinkedListNode<T> Next
        {
            get
            {
                return _next;
            }

            set
            {
                if (value != null)
                {
                    if (Neighbours == null)
                    {
                        Neighbours = new NodeList<T>();
                    }

                    Neighbours.Add(value);
                    _next = value;
                }
            }
        }
    }
}
