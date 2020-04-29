// <copyright file="BinarySearchInSortedArray.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // 1. Fast search algorithm compared to linear search algorithm.
    // 2. This algorithm is based on divide and conquer strategy to find a number in a sorted integer array.
    // 3. Binary search looks for an particular item by comparing the middle most item of the collection.
    // 4. Time complexity of this algorithm is: O(log(n)).
    public static class BinarySearch
    {
        public static int FindElementInArray(int[] array, int item)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            int start = 0;
            int end = array.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (array[mid] == item)
                {
                    return mid;
                }

                if (item > array[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return -1;
        }
    }
}
