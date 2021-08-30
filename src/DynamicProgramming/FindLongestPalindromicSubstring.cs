// <copyright file="FindLongestPalindromicSubstring.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

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
        public static string FindLPS2(string s)
        {
            if (s == null || s == string.Empty)
            {
                return string.Empty;
            }

            int start = 0;
            int maxLength = 1;

            for (int i = 0; i < s.Length; i++)
            {
                int oddLength = LengthOfPalidrom(s, i, i);
                int evenLength = LengthOfPalidrom(s, i, i + 1);

                int length = Math.Max(oddLength, evenLength);

                if (length > maxLength)
                {
                    maxLength = length;
                    start = i - ((maxLength - 1) / 2);
                }
            }

            return s.Substring(start, maxLength);
        }

        public static int LengthOfPalidrom(string s, int left, int right)
        {
            if (s == null || s == string.Empty)
            {
                return 0;
            }

            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }

            return right - left - 1;
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
