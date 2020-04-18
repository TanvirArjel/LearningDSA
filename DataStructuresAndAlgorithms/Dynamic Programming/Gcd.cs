using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.Dynamic_Programming
{
    // Main purpose of this class to calculate Greatest Common Divisor (GCD) or Highest Common Factor (HCF) of an array of number.
    public class Gcd
    {
        // Function to return gcd of a and b . This approach is called Euclidean algorithm 
        private static int FindGcd(int a, int b)
        {
            // If two numbers are equal then any of them is their GCD or HCF
            if (a == b)
                return a;

            // If any of them is zero then other number is the GCD or HCF of them because everything divides 0  
            if (a == 0)
                return b;
            if (b == 0)
                return a;


            // GCD of two numbers does not change if smaller number is subtracted from a bigger number.
            if (a > b)
                return FindGcd(a - b, b);

            return FindGcd(a, b - a);
        }

        // Function to find gcd of  
        // array of numbers 
        public static int FindGcd(int[] arr)
        {
            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                result = FindGcd(result, arr[i]);

                if (result == 1)
                {
                    return 1;
                }
            }

            return result;
        }
    }
}
