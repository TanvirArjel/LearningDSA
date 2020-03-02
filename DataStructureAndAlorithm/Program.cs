using DataStructureAndAlgorithm.DataStructures.Arrays;
using System;

namespace DataStructureAndAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new[] {78, 82, 99, 10, 23, 35, 49, 51, 60};
            int pivotIndex = FindPivotInSortedRotatedArray.WithBinarySearch(array);
            Console.WriteLine("Pivot index is: {0}", pivotIndex);
            Console.WriteLine();
            Console.WriteLine("...............................");
            Console.WriteLine("Learning Data Structure And Algorithms");
        }
    }
}
