using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms.DataStructures.Arrays
{

    // Given a sorted matrix where rows and the columns are sorted.Write an algorithm to search an element in the matrix in O(n).
    public class SortedMatrix
    {

        // The algorithm used here is called Stair Search algorithm for 2 dimensional array or matrix
        public static Tuple<int, int> FindElement(int[,] sortedMatrix, int element)
        {
            if (sortedMatrix == null || sortedMatrix.Length == 0)
            {
                return new Tuple<int, int>(-1,-1);
            }

            int totalRows = sortedMatrix.GetLength(0);
            int totalColumns = sortedMatrix.GetLength(0);

            if (element < sortedMatrix[0,0] || element > sortedMatrix[totalRows - 1,totalColumns - 1])
            {
                return new Tuple<int, int>(-1, -1);
            }
            
            int r = 0; // row
            int c = totalColumns - 1;// column
            while (r <= totalColumns - 1 && c >= 0)
            {
                if (sortedMatrix[r,c] == element)
                {
                    return new Tuple<int, int>(r,c);
                }

                if (element < sortedMatrix[r,c] )
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
