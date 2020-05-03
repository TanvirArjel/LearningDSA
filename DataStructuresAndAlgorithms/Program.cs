// <copyright file="Program.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using DataStructuresAndAlgorithms.DataStructures.Arrays;

namespace DataStructuresAndAlgorithms
{
    internal static class Program
    {
        private static void Main()
        {
            int[] inputArray1 = { 2, 4, 1, 2, 6, 1, 6, 13, 13 };
            // int[] inputArray2 = { 1, 2, 3 };
            HashSet<int> hashSet = FindDuplicatesInArray.GetDuplicatesDictionary(inputArray1);
            Console.WriteLine(hashSet.ToString());
            Console.WriteLine("...............................");
            Console.WriteLine("Learning Data Structure And Algorithms");
        }
    }
}
