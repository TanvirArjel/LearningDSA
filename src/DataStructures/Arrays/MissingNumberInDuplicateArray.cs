// <copyright file="MissingNumberInDuplicateArray.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // Given two integer arrays where second array is duplicate of first array with just 1 element missing. Find the element.
    // Input:
    // Array1 - 9 7 8 5 4 6 2 3 1
    // Array2 - 2 4 3 9 1 8 5 6
    // Output: 7
    internal static class MissingNumberInDuplicateArray
    {
        public static int FindMissingNumber(int[] array1, int[] array2)
        {
            if (array1 == null && array2 == null)
            {
                throw new ArgumentException("Input arrays are empty!");
            }
            else if (array1 == null)
            {
                if (array2.Length == 1)
                {
                    return array2[0];
                }
                else
                {
                    throw new ArgumentException("Input is not valid!");
                }
            }
            else if (array2 == null)
            {
                if (array1.Length == 1)
                {
                    return array1[0];
                }
                else
                {
                    throw new ArgumentException("Input is not valid!");
                }
            }
            else
            {
                int len1 = array1.Length;
                int len2 = array2.Length;
                if (Math.Abs(len1 - len2) != 1)
                {
                    throw new ArgumentException("Input is not valid!");
                }

                if (len1 > len2)
                {
                    return FindMissingNumberUsingXOR(array1, array2);
                }
                else
                {
                    return FindMissingNumberUsingXOR(array2, array1);
                }
            }
        }

        // Using XOR Operation. Consider both array as a single array. Now there will be one number ocurring odd nubmer (1) of times.
        // XOR operation do the trick. Use this when arithmetic operators are not allowed to use.
        // Time Complexity is O(n)
        // Space Complexity is O(1)
        private static int FindMissingNumberUsingXOR(int[] array1, int[] array2)
        {
            int result = array1[0];

            for (int i = 1; i < array1.Length; i++)
            {
                result = result ^ array1[i];
            }

            for (int i = 0; i < array2.Length; i++)
            {
                result = result ^ array2[i];
            }

            return result;
        }

        // Using Sum. Substract sum of one array from another. Result will be the missing number.
        // Use this when arithmetic operators are allowed to use.
        // Time Complexity is O(n)
        // Space Complexity is O(1)
        private static int FindMissingNumberUsingSum(int[] array1, int[] array2)
        {
            int result = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                result += array1[i];
            }

            for (int i = 0; i < array2.Length; i++)
            {
                result -= array2[i];
            }

            return result;
        }
    }
}
