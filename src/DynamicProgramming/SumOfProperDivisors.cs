// <copyright file="SumOfProperDivisors.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    public static class SumOfProperDivisors
    {
        public static int FindSum(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("number");
            }

            int sqrtOfN = (int)Math.Round(Math.Sqrt(number));

            int sum = 1;

            for (int i = 2; i <= sqrtOfN; i++)
            {
                if (number % i == 0)
                {
                    sum += i;

                    if (number / i != i)
                    {
                        sum += number / i;
                    }
                }
            }

            return sum;
        }
    }
}
