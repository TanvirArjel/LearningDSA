using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Algorithms.SearchingAlgorithms
{

    // 1. Improved variant of binary search.
    // 2. Data must be in sorted form.
    // 3. Time complexity of this algorithm is: O(log(log(n)))
    public class InterpolationSearch
    {
        // If x is present in arr[0..n-1], then returns index of it, else returns -1. 
        public static int FindElementInArray(int[] array, int item)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            // Since array is sorted, an element present in array must be in range defined by corner 
            if (item < array[0] || item > array[array.Length - 1])
            {
                return -1;
            }

            int lo = 0, hi = array.Length - 1;

            while (lo <= hi)
            {
                if (lo == hi)
                {
                    if (array[lo] == item) return lo;
                    return -1;
                }

                // Probing the position with keeping uniform distribution in mind. 
                int position = lo + ((hi - lo) * (item - array[lo])) /  (array[hi] - array[lo]);

                if (array[position] == item)
                {
                    return position;
                }

                if (item > array[position])
                {
                    lo = position + 1;
                }
                else
                {
                    hi = position - 1;
                }
            }

            return -1;
        }
    }
}
