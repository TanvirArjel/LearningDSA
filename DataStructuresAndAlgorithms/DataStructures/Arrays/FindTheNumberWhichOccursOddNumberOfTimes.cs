// <copyright file="FindTheNumberWhichOccursOddNumberOfTimes.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // Problem: In an array having positive integers, except for one number which occurs odd number of times,
    // all other numbers occur even number of times. Find the number.
    // Input: 2 5 9 1 5 1 8 2 8
    // Output: 9
    // Input : 2 3 4 3 1 4 5 1 4 2 5
    // Output: 4
    public static class FindTheNumberWhichOccursOddNumberOfTimes
    {
        // Using XOR operator
        // Time complexity : O(n)
        public static int GetNumberOccuringOddNumberOfTimes(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new ArgumentNullException("inputArray");
            }

            int result = inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                result = result ^ inputArray[i];
            }

            return result;
        }

        // Time Complexity: O(nxm) where n is the number of item in the array and m is unique count of the items.
        public static int GetNumberOccuringOddNumberOfTimesWithDictionary(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new ArgumentNullException("inputArray");
            }

            Dictionary<int, int> numberDictionary = new Dictionary<int, int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                if (numberDictionary.ContainsKey(inputArray[i]))
                {
                    KeyValuePair<int, int> item = numberDictionary.First(d => d.Key == inputArray[i]);
                    numberDictionary[inputArray[i]] = item.Value + 1;
                }
                else
                {
                    numberDictionary[inputArray[i]] = 1;
                }
            }

            foreach (KeyValuePair<int, int> item in numberDictionary)
            {
                if (item.Value % 2 == 1)
                {
                    return item.Key;
                }
            }

            return 0;
        }
    }
}
