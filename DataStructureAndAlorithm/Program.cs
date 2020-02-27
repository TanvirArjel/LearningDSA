using System;
using DataStructureAndAlgorithm.Algorithms.SearchingAlgorithms;
using DataStructureAndAlgorithm.Arrays;
using DataStructureAndAlgorithm.LinkedLists;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new[] {5};
            Array.Sort(array);

            int index = InterpolationSearch.FindElementInArray(array, 5);

            Console.WriteLine("Item found at: {0}",index);

            Console.WriteLine();
            Console.WriteLine("...............................");
            Console.WriteLine("Learning Data Structure And Algorithms");
        }
    }
}
