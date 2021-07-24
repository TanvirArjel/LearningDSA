// <copyright file="MergeTwoSortedArrays.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    public static class MergeTwoSortedArrays
    {
        // Time Complexity: O(m+n) and space complexity: O(m+n)
        public static int[] Merge(int[] array1, int[] array2)
        {
            if (array1 == null || array1.Length == 0)
            {
                return array2;
            }

            if (array2 == null || array2.Length == 0)
            {
                return array1;
            }

            int n1 = array1.Length;
            int n2 = array2.Length;

            int[] output = new int[n1 + n2];

            int i = 0, j = 0, k = 0;

            while (i < n1 && j < n2)
            {
                if (array1[i] < array2[j])
                {
                    output[k++] = array1[i++];
                }
                else
                {
                    output[k++] = array2[j++];
                }
            }

            while (i < n1)
            {
                output[k++] = array1[i++];
            }

            while (j < n2)
            {
                output[k++] = array2[j++];
            }

            return output;
        }
    }
}
