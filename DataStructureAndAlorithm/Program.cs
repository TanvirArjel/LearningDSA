using System;
using DataStructureAndAlgorithm.LinkedList;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Original LinkedList");
            Console.WriteLine();
            LinkedList.LinkedList intLinkedList = new LinkedList.LinkedList();
            intLinkedList.PopulateLinkedList(10);
            intLinkedList.Print();


            Console.WriteLine();
            Console.WriteLine("...............................");

            Console.WriteLine("Reversed LinkedList");
            Console.WriteLine();
            ReversingLinkedListIterative reversing = new ReversingLinkedListIterative();
            LinkedList.LinkedList reverseLinkedList = reversing.ReverseLinkedList(intLinkedList);
            reverseLinkedList.Print();


            Console.WriteLine();
            Console.WriteLine("...............................");
            Console.WriteLine("Learning Data Structure And Algorithms");
        }
    }
}
