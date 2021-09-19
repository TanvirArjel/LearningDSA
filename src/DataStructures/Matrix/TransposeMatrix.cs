// <copyright file="TransposeMatrix.cs" company="TanvirArjel">
// Copyright (c) TanvirArjel. All rights reserved.
// </copyright>

namespace DataStructuresAndAlgorithms.DataStructures.Matrix
{
    public static class TransposeMatrix
    {
        public static int[,] Transpose(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return matrix;
            }

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            if (row == col)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = i; j < col; j++)
                    {
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[j, i];
                        matrix[j, i] = temp;
                    }
                }

                return matrix;
            }

            int[,] outputMatrix = new int[col, row];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    outputMatrix[j, i] = matrix[i, j];
                }
            }

            return outputMatrix;
        }
    }
}
