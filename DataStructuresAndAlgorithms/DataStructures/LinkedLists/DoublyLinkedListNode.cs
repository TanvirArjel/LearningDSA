namespace DataStructuresAndAlgorithms.DataStructures.LinkedLists
{
    public class DoublyLinkedListNode<T> : Node<T>
    {
        public DoublyLinkedListNode(T data) : base(data, new NodeList<T>(2))
        {
            this.Prev = null;
            this.Next = null;
        }

        public DoublyLinkedListNode<T> Prev
        {
            get
            {
                return (DoublyLinkedListNode<T>)Neighbours[0];
            }

            set
            {
                Neighbours[0] = value;
            }
        }

        public DoublyLinkedListNode<T> Next
        {
            get
            {
                return (DoublyLinkedListNode<T>)Neighbours[1];
            }

            set
            {
                Neighbours[1] = value;
            }
        }
    }
}
