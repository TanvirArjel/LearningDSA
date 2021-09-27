// <copyright file="MergeSort.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.Algorithms.SortingAlgorithms
{
    // Time Complexity : O(nlog(n))
    // Space Complexity : O(n)
    internal static class MergeSort
    {
        public static void Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (array.Length == 0 || array.Length == 1)
            {
                return;
            }

            int start = 0;
            int end = array.Length - 1;

            Sort(array, start, end);
        }

        private static void Sort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int mid = start + ((end - start) / 2);
            Sort(array, start, mid);
            Sort(array, mid + 1, end);

            Merge(array, start, mid, end);
        }

        private static void Merge(int[] array, int start, int mid, int end)
        {
            // Find the sizes of the two sub-arrays
            int n1 = mid - start + 1;
            int n2 = end - mid;

            // Create two temp arrays
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            int i;
            for (i = 0; i < n1; i++)
            {
                leftArray[i] = array[start + i];
            }

            int j;
            for (j = 0; j < n2; j++)
            {
                rightArray[j] = array[mid + 1 + j];
            }

            i = 0;
            j = 0;
            int k = start;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            while (i < n1)
            {
                array[k++] = leftArray[i++];
            }

            while (j < n2)
            {
                array[k++] = rightArray[j++];
            }
        }
    }
}
