using System;

namespace Task3
{
    class Program
    {
        private static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        private static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        private static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        public static void Main(string[] args)
        {
            Console.Write("Ввведите количество элементов массива: ");
            var len = int.Parse(Console.ReadLine());
            if (len < 0)
            {
                Console.WriteLine("Length of array isnt correct");
                return;
            }
            var a = new int[len];
            for (var i = 0; i < a.Length; ++i)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", QuickSort(a)));
        }
    }
}