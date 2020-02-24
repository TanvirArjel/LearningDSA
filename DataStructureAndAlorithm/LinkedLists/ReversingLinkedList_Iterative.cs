namespace DataStructureAndAlgorithm.LinkedLists
{
    public class ReversingLinkedListIterative
    {
        public LinkedLists.LinkedList ReverseLinkedList(LinkedLists.LinkedList inputLinkedList)
        {
            Node previousNode = null, currentNode = inputLinkedList.Head;
            while (currentNode != null)
            {
                Node originalNext = currentNode.Next; // Before changing next of current, store next node
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
