using System;

namespace Task4
{
    class Program
    {
        static void PrintMatrixSpiral(int[,] matrix)
        {
            int sizeOfMatrix = matrix.GetLength(0);
            int column = sizeOfMatrix / 2;
            int str = sizeOfMatrix / 2;
            int step = 1;

            while (true)
            {
                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[str, column]} ");
                    column++;
                }

                if (str == 0)
                {
                    return;
                }

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[str, column]} ");
                    str++;
                }

                step++;

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[str, column]} ");
                    column--;
                }

                for (int i = 0; i < step; ++i)
                {
                    Console.Write($"{matrix[str, column]} ");
                    str--;
                }

                step++;
            }
        }

        static void Main(string[] args)
        {
            int[,] inputMatrix = new int[5, 5] { { 21, 22, 23, 24, 25 },
                                                 { 20, 7, 8, 9, 10 },
                                                 { 19, 6, 1, 2, 11 },
                                                 { 18, 5, 4, 3, 12 },
                                                 { 17, 16, 15, 14, 13 } };

            PrintMatrixSpiral(inputMatrix);
        }
    }
}