using System;
using DataStructureAndAlgorithm.Arrays;
using DataStructureAndAlgorithm.LinkedLists;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new[] {5,1, 3, 8, 14, 4, 10, 2, 11};
            Array.Sort(array);

            int index = BinarySearch.FindElementInArray(array, 10);

            Console.WriteLine("Item found at: {0}",index);

            Console.WriteLine();
            Console.WriteLine("...............................");
            Console.WriteLine("Learning Data Structure And Algorithms");
        }
    }
}
