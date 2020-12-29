// <copyright file="Gcd.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.Recursion
{
    // Main purpose of this class to calculate Greatest Common Divisor (GCD) or Highest Common Factor (HCF) of an array of number.
    public static class Gcd
    {
        // Function to find gcd of array of numbers.
        public static int FindGcd(int[] arr)
        {
            if (arr == null)
            {
                return 0;
            }

            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                result = FindGcdUsingEuclidAlgo(result, arr[i]);

                if (result == 1)
                {
                    return 1;
                }
            }

            return result;
        }

        // Euclidean algorithm
        private static int FindGcdUsingEuclidAlgo(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        // Function to return gcd of a and b
        private static int FindGcdUsingRecursion(int a, int b)
        {
            // If two numbers are equal then any of them is their GCD or HCF
            if (a == b)
            {
                return a;
            }

            // If any of them is 1  then 1  is the GCD between them.
            if (a == 1 || b == 1)
            {
                return 1;
            }

            // If any of them is zero then other number is the GCD or HCF of them because everything divides 0.
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            // GCD of two numbers does not change if smaller number is subtracted from a bigger number.
            if (a > b)
            {
                return FindGcdUsingRecursion(a - b, b);
            }

            return FindGcdUsingRecursion(a, b - a);
        }
    }
}
