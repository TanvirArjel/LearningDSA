// <copyright file="FindFibonacciNumber.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.Recursion
{
    // In mathematics, the Fibonacci series is defined by the following recurrence relation:
    // F(0) = 0
    // F(1) = 1
    // F(n) = F(n-1) + F(n-2)
    // i.e.nth element is formed by adding elements at(n-1) and(n-2)
    // So, first 10 fibonacci numbers will be:
    // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34

    // Given a number n, find F(n).
    // Example:
    // Input: 6
    // Output: 8
    // Input: 10
    // Output: 55
    internal static class FindFibonacciNumber
    {
        // Recursive Solution
        // Time complexity: O(2^n)
        public static int GetFibonacciWithRecursion(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number cannot be negative!");
            }

            if (number <= 1)
            {
                return number;
            }

            return GetFibonacciWithRecursion(number - 1) + GetFibonacciWithRecursion(number - 2);
        }

        // Dynamic Programming Solution
        // Time complexity: O(n)
        public static int GetFibonacciWithoutRecursion(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number cannot be negative!");
            }

            if (number <= 1)
            {
                return number;
            }

            int a = 0;
            int b = 1;
            int c = a + b;

            for (int i = 2; i <= number; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }

            return c;
        }
    }
}
