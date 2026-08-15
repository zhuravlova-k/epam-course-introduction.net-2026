using System;

namespace RotateMatrix
{
    public static class ArrayExtensions
    {
        public static void Rotate90DegreesClockwise(this int[,]? matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);

            Transpose(matrix);
            ReverseRows(matrix);
        }

        public static void Rotate90DegreesCounterClockwise(this int[,]? matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);

            Transpose(matrix);
            ReverseColumns(matrix);
        }

        public static void Rotate180DegreesClockwise(this int[,]? matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);
            ReverseRows(matrix);
            ReverseColumns(matrix);
        }

        public static void Rotate180DegreesCounterClockwise(this int[,]? matrix)
        {
            matrix.Rotate180DegreesClockwise();
        }

        public static void Rotate270DegreesClockwise(this int[,]? matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);

            matrix.Rotate90DegreesCounterClockwise();
        }

        public static void Rotate270DegreesCounterClockwise(this int[,]? matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);
            matrix.Rotate90DegreesClockwise();
        }

        public static void Rotate360DegreesClockwise(this int[,]? matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);
        }

        public static void Rotate360DegreesCounterClockwise(this int[,]? matrix)
        {
            ArgumentNullException.ThrowIfNull(matrix);
        }

        private static void Transpose(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
        }

        private static void ReverseRows(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, n - 1 - j];
                    matrix[i, n - 1 - j] = temp;
                }
            }
        }

        private static void ReverseColumns(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - 1 - i, j];
                    matrix[n - 1 - i, j] = temp;
                }
            }
        }
    }
}
