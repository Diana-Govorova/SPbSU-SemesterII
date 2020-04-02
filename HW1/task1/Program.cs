using System;

namespace task1
{
    class Program
    {
        private static int Factorial(int n)
            => n <= 1 ? 1 : n * Factorial(n - 1);
       
        static void Main(string[] args)
        {
            Console.Write("Введите число : ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Факториал числа {number} : {Factorial(number)}");
        }
    }
}
