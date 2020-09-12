// <copyright file="FindFactorialOfANumber.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.Recursion
{
    // Find the factorial of a given number.
    // Input: 3
    // Output: 6
    internal static class FindFactorialOfANumber
    {
        // Time Complexity: O(n)
        public static long GetFactorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Number cannot be a negative number");
            }

            if (number == 0)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
