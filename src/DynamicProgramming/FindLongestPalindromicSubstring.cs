// <copyright file="FindLongestPalindromicSubstring.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    public static class FindLongestPalindromicSubstring
    {
        // Time Complexity: O(n^3) and Space Complexity: O(1)
        public static string FindLPS1(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length == 0)
            {
                return string.Empty;
            }

            string output = input[0].ToString(); // Every single charcater is a palindrom.

            for (int len = 2; len <= input.Length; len++)
            {
                for (int i = 0; i <= input.Length - len; i++)
                {
                    string subString = input.Substring(i, len);

                    bool isPalindrom = CheckIfPalindrom(subString);

                    if (isPalindrom)
                    {
                        output = subString;
                    }
                }
            }

            return output;
        }

        // Time Complexity: O(n^2) and Space Complexity: O(1)
        public static string FindLPS2(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length == 0)
            {
                return string.Empty;
            }

            int maxLength = 1; // The result (length of LPS)

            int palindromStart = 0;

            int low, high;

            // One by one consider every character as center point of even and odd length palindromes
            for (int i = 1; i < input.Length; i++)
            {
                // Find the longest even length palindrome with center points as i-1 and i.
                low = i - 1;
                high = i;
                while (low >= 0 && high < input.Length && input[low] == input[high])
                {
                    if (high - low + 1 > maxLength)
                    {
                        palindromStart = low;
                        maxLength = high - low + 1;
                    }

                    --low;
                    ++high;
                }

                // Find the longest odd length palindrome with center point as i
                low = i - 1;
                high = i + 1;
                while (low >= 0 && high < input.Length && input[low] == input[high])
                {
                    if (high - low + 1 > maxLength)
                    {
                        palindromStart = low;
                        maxLength = high - low + 1;
                    }

                    --low;
                    ++high;
                }
            }

            string longestPalindrom = input.Substring(palindromStart, maxLength);
            return longestPalindrom;
        }

        private static bool CheckIfPalindrom(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length == 0)
            {
                return false;
            }

            int start = 0;
            int end = input.Length - 1;
            bool isPalidrom = true;
            while (start <= end)
            {
                if (input[start++] != input[end--])
                {
                    isPalidrom = false;
                    break;
                }
            }

            return isPalidrom;
        }
    }
}
