using System;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    public static class MedianOfTwoSortedArrays
    {
        // Time Complexity: O(m+n) and space complexity: O(1)
        public static double Find(int[] array1, int[] array2)
        {
            if (array1 == null)
            {
                array1 = Array.Empty<int>();
            }

            if (array2 == null)
            {
                array2 = Array.Empty<int>();
            }

            int n1 = array1.Length;
            int n2 = array2.Length;

            int total = n1 + n2;
            int mid = total / 2;
            double result = 0;
            int i = 0, j = 0;

            // If the total number is odd then mid is the median.
            if (total % 2 == 1)
            {
                for (int k = 0; k <= mid; k++)
                {
                    if (i < n1 && j < n2)
                    {
                        result = array1[i] < array2[j] ? array1[i++] : array2[j++];
                    }
                    else if (i < n1)
                    {
                        result = array1[i++];
                    }
                    else
                    {
                        result = array2[j++];
                    }
                }
            }

            // If the total number is even then the average of mid and mid-1 is the median.
            if (total % 2 == 0)
            {
                double prev = 0;
                for (int k = 0; k <= mid; k++)
                {
                    if (i < n1 && j < n2)
                    {
                        prev = result;
                        result = array1[i] < array2[j] ? array1[i++] : array2[j++];
                    }
                    else if (i < n1)
                    {
                        prev = result;
                        result = array1[i++];
                    }
                    else
                    {
                        prev = result;
                        result = array2[j++];
                    }
                }

                result = (prev + result) / 2;
            }

            return result;
        }
    }
}
