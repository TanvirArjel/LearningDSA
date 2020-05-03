// <copyright file="FindLastIndexOfItemInSortedArrayWithDuplicates.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    // Given a sorted array of integers containing duplicates, write a program which returns the last index of an element.
    // Input : [0, 1, 2, 2, 4, 5, 5, 5, 8]
    // Given Item : 5
    // Output : Last index of 5 is: 7
    // Time Complexity is: O(log n)
    // Space Complexity is: O(1)
    public static class FindLastIndexOfItemInSortedArrayWithDuplicates
    {
        public static int FindLastIndex(int[] inputArray, int item)
        {
            if (inputArray == null || inputArray.Length == 0)
            {
                return -1;
            }

            int startIndex = 0;
            int endIndex = inputArray.Length - 1;

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (inputArray[midIndex] == item && (midIndex == endIndex || inputArray[midIndex + 1] > item))
                {
                    return midIndex;
                }
                else if (item >= inputArray[midIndex])
                {
                    startIndex = midIndex + 1;
                }
                else
                {
                    endIndex = midIndex - 1;
                }
            }

            return -1;
        }
    }
}
