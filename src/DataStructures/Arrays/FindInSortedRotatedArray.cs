// <copyright file="FindInSortedRotatedArray.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    public static class FindInSortedRotatedArray
    {
        // Time Complexity is: O(log n)
        public static int Find(int[] array, int element)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            int start = 0, end = array.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (array[mid] == element)
                {
                    return mid;
                }

                // If left half is sorted
                if (start <= mid - 1 && array[start] <= array[mid - 1])
                {
                    // check if key is present in the left half
                    if (element >= array[start] && element <= array[mid - 1])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (mid + 1 <= end && element >= array[mid + 1] && element <= array[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return -1;
        }

        public static int FindRecursion(int[] array, int start, int end, int element)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (array[mid] == element)
            {
                return mid;
            }

            // If the left part is sorted.
            if (start <= mid - 1 && array[start] <= array[mid - 1])
            {
                if (element >= array[start] && element <= array[mid - 1])
                {
                    return FindRecursion(array, start, mid - 1, element);
                }
                else
                {
                    return FindRecursion(array, mid + 1, end, element);
                }
            }

            // If the left part is sorted
            else
            {
                if (mid - 1 <= end && element >= array[mid + 1] && element <= array[mid])
                {
                    return FindRecursion(array, mid + 1, end, element);
                }
                else
                {
                    return FindRecursion(array, start, mid - 1, element);
                }
            }
        }
    }
}
