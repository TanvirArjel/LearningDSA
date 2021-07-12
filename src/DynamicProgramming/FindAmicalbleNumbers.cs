using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    /// <summary>
    /// Amicable numbers are two different numbers related in such a way that the sum of the proper divisors of each is equal to the other number.
    /// </summary>
    public static class FindAmicalbleNumbers
    {
        public static List<int> Find(int numberLimit)
        {
            if (numberLimit <= 1)
            {
                throw new ArgumentException("The input number is not a valid numer", "numberLimit");
            }

            List<int> numbers = new List<int>();

            for (int i = 1; i <= numberLimit; i++)
            {
                if (!numbers.Contains(i))
                {
                    // If i == 220 then a = 284  and b = 220
                    int a = GetSumOfProperDivisors(i);
                    int b = GetSumOfProperDivisors(a);

                    // If the sum of proper divisors of a number is equal to that number then it is perfect numbe.
                    if (i == a)
                    {
                        Console.WriteLine("{0} is perfect number", i);
                        continue;
                    }

                    if (i == b)
                    {
                        numbers.Add(i);
                        numbers.Add(a);
                    }
                }
            }

            return numbers;
        }

        /// <summary>
        /// Proper divisors are the factors or divisors which are strictly less than the number itself.
        /// </summary>
        /// <param name="number">The input number.</param>
        /// <returns>Returns sum of the proper divisors.</returns>
        private static int GetSumOfProperDivisors(int number)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException("number");
            }

            int sum = 1; // One is the common divisor of all natural number.
            int sqrtOfN = (int)Math.Round(Math.Sqrt(number));
            for (int i = 2; i < sqrtOfN; i++)
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
