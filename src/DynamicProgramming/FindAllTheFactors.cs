// <copyright file="FindAllTheFactors.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    /// <summary>
    /// Find all the divisors or factors of a natual number.
    /// </summary>
    public static class FindAllTheFactors
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

            List<int> factors = new List<int>();

            for (int i = 1; i <= sqtOfN; i++)
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

            List<int> factors = new List<int>();

            int sqrtOfN = (int)Math.Round(Math.Sqrt(number));

            for (int i = 1; i < sqrtOfN; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                }
            }

            for (int i = sqrtOfN; i >= 1; i--)
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
