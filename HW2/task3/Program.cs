using System;
using static Task3.Calculator;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which stack option do you want: \"0\" = List, \"1\" = Array");
            int choice = Convert.ToInt32(Console.ReadLine());
            IStack stack;
            if (choice == 0)
            {
                stack = new StackAsList();
            }
            else if (choice == 1)
            {
                stack = new StackAsArray();
            }
            else
            {
                throw new Exception("Please, enter right value!");
            }
            var calculator = new Calculator(stack);
            while (true)
            {
                Console.WriteLine("Enter postfix expression to calculate. ");
                string expression = Console.ReadLine();
                Console.WriteLine($"Result: {calculator.CalculateExpressionValue(expression)}");
            }
        }
    }
}
