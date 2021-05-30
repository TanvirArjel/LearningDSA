// <copyright file="FindPivotInSortedRotatedArray.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // Given a sorted integer array which is rotated any number of times, find the pivot index i.e. index of the minimum element of the array.
    // Input: 78,82,99,10,23,35,49,51,60
    // Output: 3
    public static class FindPivotInSortedRotatedArray
    {
        // With Linear Search, Time Complexity is : O(n)
        public static int WithLinearSearch(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            // If array contains one element or array is not rotated, then first index is the pivot.
            if (array.Length == 1 || array[0] < array[array.Length - 1])
            {
                return 0;
            }

            int pivotIndex = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    pivotIndex = i + 1;
                    break;
                }
            }

            return pivotIndex;
        }

        // With Binary Search, Time Complexity is : O(log(n))
        public static int WithBinarySearch(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            // If array contains one element or array is not rotated, then first index is the pivot.
            if (array.Length == 1 || array[0] < array[array.Length - 1])
            {
                return 0;
            }

            int start = 0, end = array.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;

                // check if mid+1 is pivot
                if (mid < array.Length - 1 && array[mid] > array[mid + 1])
                {
                    return mid + 1;
                }

                // If array[start] <= array[mid],it means from start to mid, all elements are in sorted order,
                // so pivot will be in second half
                if (array[start] <= array[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    // else pivot lies in first half, so we find the pivot in first half
                    end = mid - 1;
                }
            }

            return 0;
        }
    }
}
