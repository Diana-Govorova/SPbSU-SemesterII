using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<string>();
            int command = -1;
            while (true)
            {
                Console.WriteLine("Select the operation: ");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add Node to queue");
                Console.WriteLine("2: Delete Node from queue");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            Console.WriteLine("Enter the value, then enter the priority:");
                            string value = Console.ReadLine();
                            int priority = Convert.ToInt32(Console.ReadLine());
                            queue.Enqueue(value, priority);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(queue.Dequeue());
                            break;
                        }
                }
                Console.WriteLine();
            }
        }
    }
}