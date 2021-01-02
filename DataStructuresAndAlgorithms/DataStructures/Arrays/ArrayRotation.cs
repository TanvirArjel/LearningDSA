using System;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // Given an array and a positive integer k, rotate the array k times.
    // Example:
    // Array:  1 2 3 4 5
    // k: 1
    // Output: 2 3 4 5 1
    // k: 2
    // Output: 3 4 5 1 2
    // k: 3
    // Output: 4 5 1 2 3
    internal class ArrayRotation
    {
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        public static void RotateArrayUsingReversal(int[] array, int k)
        {
            int length = array.Length;

            if (array == null || length == 0)
            {
                throw new ArgumentNullException("array");
            }

            if (k < 0)
            {
                throw new ArgumentOutOfRangeException("k");
            }

            if (k > length)
            {
                k %= length;
            }

            if (k == 0)
            {
                return;
            }

            ReverseArray(array, 0, k - 1); // Reverse the first k items;
            ReverseArray(array, k, length - 1); // Reverse the the remaining item.
            ReverseArray(array, 0, length - 1); // Now reverse the all item.
        }

        private static void ReverseArray(int[] array, int s, int e)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException("array");
            }

            while (s < e)
            {
                int temp = array[s];
                array[s] = array[e];
                array[e] = temp;
                s++;
                e--;
            }
        }
    }
}
