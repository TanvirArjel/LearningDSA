using System;
using System.Collections.Generic;

namespace DataStructureAndAlgorithm.DataStructure.Arrays
{
    // Given a set of numbers, find the longest subset of consecutive numbers.
    // Example:
    // Input: 1 3 8 14 4 10 2 11
    // Output: 1 2 3 4
    public class LSCN
    {
        public static int[] FindLscn(int[] inputArray)
        {
            Array.Sort(inputArray);
            List<int> longestSubset = new List<int>();
            List<int> currentSubset = new List<int>();

            Dictionary<int,int> hash = new Dictionary<int, int>();
            
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!hash.ContainsKey(inputArray[i]))
                {
                    currentSubset.Clear();
                    currentSubset.Add(inputArray[i]);
                    hash.Add(inputArray[i], inputArray[i]);

                    int expectedNextValue = inputArray[i]  + 1;
                    while (Array.Exists(inputArray, a => a == expectedNextValue))
                    {
                        currentSubset.Add(expectedNextValue);
                        hash.Add(expectedNextValue, expectedNextValue);
                        expectedNextValue = expectedNextValue + 1;
                    }

                    if (currentSubset.Count > longestSubset.Count)
                    {
                        longestSubset = new List<int>(currentSubset);
                    }
                }
                
            }

            return longestSubset.ToArray();
        }
    }
}
