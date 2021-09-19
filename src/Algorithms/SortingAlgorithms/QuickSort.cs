// <copyright file="QuickSort.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.Algorithms.SortingAlgorithms
{
    // Time Complexity : O(nlog(n)) in average case. O(n^2) in worst case.
    // Space Complexity : O(1)
    internal static class QuickSort
    {
        public static void Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (array.Length == 0)
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

            int pivotIndex = Partition(array, start, end);
            Sort(array, start, pivotIndex - 1);
            Sort(array, pivotIndex + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int pIndex = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] < pivot)
                {
                    Swap(array, i, pIndex);
                    pIndex++;
                }
            }

            Swap(array, pIndex, end);

            return pIndex;
        }

        private static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
