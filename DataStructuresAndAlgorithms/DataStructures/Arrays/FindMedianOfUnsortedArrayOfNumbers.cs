// <copyright file="FindMedianOfUnsortedArrayOfNumbers.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // Find the median of given a unsorted array of numbers.
    // Input: {4,5,3,8,7,9}
    // Output: 5
    internal static class FindMedianOfUnsortedArrayOfNumbers
    {
        // This solution is using sorting.
        // Time Complexity is: O(nlogn)
        public static double FindMedian(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException("numbers");
            }

            int[] sortedNumbers = (int[])numbers.Clone();
            Array.Sort(sortedNumbers);

            int size = sortedNumbers.Length;
            int mid = size / 2;

            double median = (size % 2 != 0) ? sortedNumbers[mid] : ((double)(sortedNumbers[mid - 1] + sortedNumbers[mid]) / 2);
            return median;
        }

        public static double FindMedianWithoutSorting(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException("numbers");
            }

            int median = numbers.Median();

            return (double)median;
        }

        /// <summary>
        /// Note: specified list would be mutated in the process.
        /// </summary>
        /// <param name="list">The type to be extended.</param>
        /// <returns>Returns <typeparamref name="T"/>.</returns>
        private static T Median<T>(this IList<T> list)
            where T : IComparable<T>
        {
            return list.NthOrderStatistic((list.Count - 1) / 2);
        }

        private static double Median<T>(this IEnumerable<T> sequence, Func<T, double> getValue)
        {
            List<double> list = sequence.Select(getValue).ToList();
            int mid = (list.Count - 1) / 2;
            return list.NthOrderStatistic(mid);
        }

        /// <summary>
        /// Returns Nth smallest element from the list. Here n starts from 0 so that n=0 returns minimum, n=1 returns 2nd smallest element etc.
        /// Note: specified list would be mutated in the process.
        /// Reference: Introduction to Algorithms 3rd Edition, Corman et al, pp 216.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="list">The type to be extended.</param>
        /// <param name="n">The size of the array.</param>
        /// <param name="rnd">The random number to be picked as median.</param>
        /// <returns>Returns <typeparamref name="T"/>.</returns>
        private static T NthOrderStatistic<T>(this IList<T> list, int n, Random rnd = null)
            where T : IComparable<T>
        {
            return NthOrderStatistic(list, n, 0, list.Count - 1, rnd);
        }

        private static T NthOrderStatistic<T>(this IList<T> list, int n, int start, int end, Random rnd)
            where T : IComparable<T>
        {
            while (true)
            {
                int pivotIndex = list.Partition(start, end, rnd);

                if (pivotIndex == n)
                {
                    return list[pivotIndex];
                }

                if (n < pivotIndex)
                {
                    end = pivotIndex - 1;
                }
                else
                {
                    start = pivotIndex + 1;
                }
            }
        }

        /// <summary>
        /// Partitions the given list around a pivot element such that all elements on left of pivot are <= pivot
        /// and the ones at thr right are > pivot. This method can be used for sorting, N-order statistics such as
        /// as median finding algorithms.
        /// Pivot is selected ranodmly if random number generator is supplied else its selected as last element in the list.
        /// Reference: Introduction to Algorithms 3rd Edition, Corman et al, pp 171
        /// </summary>
        private static int Partition<T>(this IList<T> list, int start, int end, Random rnd = null)
            where T : IComparable<T>
        {
            if (rnd != null)
            {
                list.Swap(end, rnd.Next(start, end + 1));
            }

            T pivot = list[end];
            int lastLow = start - 1;
            for (int i = start; i < end; i++)
            {
                if (list[i].CompareTo(pivot) <= 0)
                {
                    list.Swap(i, ++lastLow);
                }
            }

            list.Swap(end, ++lastLow);
            return lastLow;
        }

        private static void Swap<T>(this IList<T> list, int i, int j)
        {
            // This check is not required but Partition function may make many calls so its for perf reason
            if (i == j)
            {
                return;
            }

            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
