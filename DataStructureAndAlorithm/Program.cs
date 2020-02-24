using System;
using DataStructureAndAlgorithm.LinkedLists;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original LinkedList");
            Console.WriteLine();
            LinkedList intLinkedList = new LinkedList();
            intLinkedList.PopulateLinkedList(10);
            intLinkedList.Print();


            Console.WriteLine();
            Console.WriteLine("...............................");

            Console.WriteLine("Reversed LinkedList");
            Console.WriteLine();
            ReversingLinkedListIterative reversing = new ReversingLinkedListIterative();
            LinkedLists.LinkedList reverseLinkedList = reversing.ReverseLinkedList(intLinkedList);
            reverseLinkedList.Print();


            Console.WriteLine();
            Console.WriteLine("...............................");
            Console.WriteLine("Learning Data Structure And Algorithms");
        }
    }
}
