// <copyright file="FindAllTheProperDivisors.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    /// <summary>
    /// Proper divisors are the factors or divisor which are strictly less than the number itself.
    /// </summary>
    public static class FindAllTheProperDivisors
    {
        // Time Complexity: O(sqrt(n))
        // Space Complexity: O(sqrt(n))
        public static List<int> Find(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("number");
            }

            double sqtOfN = Math.Sqrt(number);

            List<int> factors = new List<int>
            {
                1
            };

            // To exclude the number itself start the iterate from 2.
            for (int i = 2; i <= sqtOfN; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);

                    if (number / i != i)
                    {
                        factors.Add(number / i);
                    }
                }
            }

            return factors;
        }

        // Time Complexity: O(sqrt(n))
        // Space Complexity: O(sqrt(n))
        public static List<int> FindSorted(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("number");
            }

            List<int> factors = new List<int>
            {
                1
            };

            int sqrtOfN = (int)Math.Round(Math.Sqrt(number));

            for (int i = 2; i < sqrtOfN; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                }
            }

            // To exclude the number itself iterate down to 2.
            for (int i = sqrtOfN; i >= 2; i--)
            {
                if (number % i == 0)
                {
                    factors.Add(number / i);
                }
            }

            return factors;
        }
    }
}
