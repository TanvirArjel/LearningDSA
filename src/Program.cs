// <copyright file="Program.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using DataStructuresAndAlgorithms.Algorithms.SortingAlgorithms;

namespace DataStructuresAndAlgorithms
{
    internal static class Program
    {
        private static void Main()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            MergeSort.Sort(arr);

            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
