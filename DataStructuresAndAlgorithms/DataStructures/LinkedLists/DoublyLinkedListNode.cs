namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class DoublyLinkedListNode<T> : Node<T>
    {
        private DoublyLinkedListNode<T> prev;
        private DoublyLinkedListNode<T> _next;

        public DoublyLinkedListNode(T data) : base(data)
        {
            this.Prev = null;
            this.Next = null;
        }

        public DoublyLinkedListNode<T> Prev
        {
            get
            {
                return prev;
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
                    prev = value;
                }
            }
        }

        public DoublyLinkedListNode<T> Next
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
