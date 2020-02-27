using System;
using DataStructureAndAlgorithm.Algorithms.SearchingAlgorithms;
using DataStructureAndAlgorithm.DataStructure.Arrays;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[3,4]{{ 2, 6, 7, 11},
                { 3, 8, 10, 12},
                { 4, 9, 11, 13}};

            Tuple<int, int> index = SortedMatrix.FindElement(array, 2);

            //int index = InterpolationSearch.FindElementInArray(array, 5);

            Console.WriteLine("Item found at: {0},{1}", index.Item1, index.Item2);

            Console.WriteLine();
            Console.WriteLine("...............................");
            Console.WriteLine("Learning Data Structure And Algorithms");
        }
    }
}
