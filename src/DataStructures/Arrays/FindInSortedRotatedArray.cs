namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{
    public static class FindInSortedRotatedArray
    {
        // Time Complexity is: O(log n)
        public static int Find(int[] array, int element)
        {
            if (array == null || array.Length == 0)
            {
                return -1;
            }

            int start = 0, end = array.Length - 1;

            if (array[start] < array[end])
            {
                return -1;
            }

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (array[mid] == element)
                {
                    return mid;
                }

                // If left half is sorted
                if (array[start] < array[mid])
                {
                    // check if key is present in the left half
                    if (element >= array[start] && element <= array[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }

                // If right half is sorted
                else
                {
                    if (element > array[mid] && element <= array[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}
