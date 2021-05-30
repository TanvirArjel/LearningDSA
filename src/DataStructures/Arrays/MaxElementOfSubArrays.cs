// <copyright file="MaxElementOfSubArrays.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    public static class MaxElementOfSubArrays
    {
        public static void PrintMaxFromSubArrays(int[] array, int k)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < k; i++)
            {
                // Remove all useless elements present at the front of the list
                while (list.Count != 0 && array[i] > array[list.Last.Value])
                {
                    list.RemoveLast();
                }

                // add index of current element at the back
                list.AddLast(i);
            }

            for (int i = k; i < array.Length; i++)
            {
                // First element present in the list is the greatest element for the last 'k' sized sub-array
                Console.Write(array[list.First.Value] + " ");

                // Now remove all indices of elements from the list which do not belong to current window
                while (list.Count != 0 && (list.First.Value < (i - k + 1)))
                {
                    list.RemoveFirst();
                }

                // now again remove all useless elements present at the front of the list
                // remove all useless elements present at the front of the list
                while (list.Count != 0 && array[i] > array[list.Last.Value])
                {
                    list.RemoveLast();
                }

                // And finally insert this new element at the back of the list
                list.AddLast(i);
            }

            // Now print the largest element from the last sub-array(window)
            Console.WriteLine(array[list.First.Value]);
        }
    }
}
