using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var list = new LinkedList();
            int command = -1;
            while (true)
            {
                Console.WriteLine("Select the operation: ");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: AddNodeByPosition");
                Console.WriteLine("2: DeleteNodeByPosition ");
                Console.WriteLine("3: GetSize");
                Console.WriteLine("4: IsEmpty? ");
                Console.WriteLine("5: GetNodeValueByPosition ");
                Console.WriteLine("6: ChangeNodeValueByPosition ");
                Console.WriteLine("7: PrintLinkedList ");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            Console.WriteLine("Enter the position, then enter the value:");
                            int position = Convert.ToInt32(Console.ReadLine());
                            int value = Convert.ToInt32(Console.ReadLine());
                            list.AddNodeByPosition(position, value);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the position: ");
                            int position = Convert.ToInt32(Console.ReadLine());
                            list.DeleteNodeByPosition(position);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"{list.GetSize()}");
                            break;
                        }
                    case 4:
                        {
                            if (list.IsEmpty())
                            {
                                Console.WriteLine("List is empty");
                            }
                            else
                            {
                                Console.WriteLine("List isnt empty");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter the position: ");
                            int position = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"{list.GetNodeValueByPosition(position)}");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter the position, then enter the value:");
                            int position = Convert.ToInt32(Console.ReadLine());
                            int value = Convert.ToInt32(Console.ReadLine());
                            list.ChangeNodeValueByPosition(position, value);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Your list is: ");
                            list.PrintLinkedList();
                            break;
                        }
                }
                Console.WriteLine();
            }
        }
    }
}