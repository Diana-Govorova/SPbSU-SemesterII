using System;

namespace Task2
{
    class Program
    {
        private static int CalculateFibonacciIteratively(int n)
        {
            int fib1 = 0;
            int fib2 = 1;
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    while (n > 1)
                    {
                        int tmp = fib2;
                        fib2 = fib1 + fib2;
                        fib1 = tmp;
                        n--;
                    }
                    return fib2;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите число : ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"Число Фиббоначи {number} : {CalculateFibonacciIteratively(number)}");
        }
    }
}
