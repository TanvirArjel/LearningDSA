// <copyright file="StairCaseSearch.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

using System;

namespace DataStructuresAndAlgorithms.Algorithms.SearchingAlgorithms
{
    // 1. Stair Case Search algorithm is used to find an element in a 2 dimensional array or matrix in most efficient way.
    // 2. Time complexity of this algorithm is: O(n)
    public static class StairCaseSearch
    {
        public static Tuple<int, int> FindElement(int[,] sortedMatrix, int element)
        {
            if (sortedMatrix == null || sortedMatrix.Length == 0)
            {
                return new Tuple<int, int>(-1, -1);
            }

            int totalRows = sortedMatrix.GetLength(0);
            int totalColumns = sortedMatrix.GetLength(0);

            if (element < sortedMatrix[0, 0] || element > sortedMatrix[totalRows - 1, totalColumns - 1])
            {
                return new Tuple<int, int>(-1, -1);
            }

            int r = 0; // row
            int c = totalColumns - 1; // column
            while (r <= totalColumns - 1 && c >= 0)
            {
                if (sortedMatrix[r, c] == element)
                {
                    return new Tuple<int, int>(r, c);
                }

                if (element < sortedMatrix[r, c])
                {
                    c--;
                }
                else
                {
                    r++;
                }
            }

            return new Tuple<int, int>(-1, -1);
        }
    }
}
