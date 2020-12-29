// <copyright file="Lcm.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.Recursion
{
    // This class contains the method to find Lowest Common Multiple (LCM) of an array of numbers.
    public static class Lcm
    {
        public static int FindLcm(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = FindLcm(result, numbers[i]);
            }

            return result;
        }

        // This is the efficient way of finding LCM of an array of numbers as this method uses Euclid's Algorithm to find the GCD.
        public static int FindLcmUsingGcd(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            int result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                result = FindLcmUsingGcd(result, numbers[i]);
            }

            return result;
        }

        private static int FindLcmUsingGcd(int a, int b)
        {
            return a * (b / FindLcmUsingGcd(a, b));
        }

        private static int FindLcm(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            if (a == 0 || b == 0)
            {
                return 0;
            }

            if (a == 1)
            {
                return b;
            }

            if (b == 1)
            {
                return a;
            }

            int smllerNum, largeNum;
            if (a > b)
            {
                largeNum = a;
                smllerNum = b;
            }
            else
            {
                largeNum = b;
                smllerNum = a;
            }

            for (int i = 1; i < largeNum; i++)
            {
                int posLcm = smllerNum * i;
                if (posLcm % largeNum == 0)
                {
                    return posLcm;
                }
            }

            return a * b;
        }
    }
}
