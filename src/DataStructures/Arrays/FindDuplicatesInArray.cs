// <copyright file="FindDuplicatesInArray.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // Given an array of n elements which contains integers from 0 to n-1 only.
    // The numbers can appear any number of times.Find the repeating numbers.
    // Input: {2, 4, 1, 2, 6, 1, 6, 3, 0}
    // Ouput: {1, 2, 6}
    internal class FindDuplicatesInArray
    {
        // Use 2 loops to find duplicates in the array. In outer loop, pick each element one by one and
        // in inner loop check if duplicate exists for that element in the array.
        // Time Complexity: O(n^2)
        // Space Complexity: O(1)
        public static HashSet<int> GetDuplicatesBruthForce(int[] inputArray)
        {
            HashSet<int> duplicates = new HashSet<int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] == inputArray[j])
                    {
                        duplicates.Add(i);
                    }
                }
            }

            return duplicates;
        }

        // Loop though all the elements and store their count into a dictionary and returns the element with count > 1.
        // Time Complexity: O(n)
        // Space Complexity: O(1)
        public static HashSet<int> GetDuplicatesDictionary(int[] inputArray)
        {
            Dictionary<int, int> numberDictionary = new Dictionary<int, int>();

            for (int i = 0; i < inputArray.Length; i++)
            {
                int currentKey = inputArray[i];
                int currentValue;
                if (numberDictionary.TryGetValue(currentKey, out currentValue))
                {
                    numberDictionary[currentKey] = currentValue + 1;
                }
                else
                {
                    numberDictionary.Add(currentKey, 1);
                }
            }

            return numberDictionary.Where(d => d.Value > 1).Select(d => d.Key).ToHashSet();
        }
    }
}
