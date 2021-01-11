// <copyright file="Node.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;

namespace DataStructuresAndAlgorithms.DataStructures
{
    public class Node<T>
    {
        public Node(T data)
            : this(data, null)
        {
        }

        public Node(T data, NodeList<T> neighbors)
        {
            this.Data = data;
            this.Neighbours = neighbors;
        }

        public T Data { get; set; }

        protected NodeList<T> Neighbours { get; set; }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList() : base()
        {
        }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (int i = 0; i < initialSize; i++)
            {
                Items.Add(default(Node<T>));
            }
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
            {
                if (node.Data.Equals(value))
                {
                    return node;
                }
            }

            // if we reached here, we didn't find a matching node
            return null;
        }
    }
}
