using System;

namespace Task2
{
    class Program
    {
        private static IHashFunction Input()
        {
            Console.WriteLine("Choose the hash method: 0 = Hash1, 1 = Hash2");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0)
            {
                return new Hash1();
            }
            else if (choice == 1)
            {
                return new Hash2();
            }
            else
            {
                Console.WriteLine("Wrong input.");
                return default;
            }
        }

        static void Main(string[] args)
        {
            IHashFunction hash = Input();
            var hashTable = new HashTable(hash);
            int command = -1;
            while (true)
            {
                Console.WriteLine("Select the operation: ");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add Value");
                Console.WriteLine("2: Delete Value ");
                Console.WriteLine("3: Hash Contains");
                Console.WriteLine("4: Switch Hash");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 0:
                        {
                            return;
                        }
                    case 1:
                        {
                            Console.WriteLine("Enter the string to add: ");
                            hashTable.AddValue(Console.ReadLine());
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the string to delete: ");
                            Console.WriteLine(hashTable.DeleteValue(Console.ReadLine()));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the string to check: ");
                            Console.WriteLine(hashTable.HashContains(Console.ReadLine()));
                            break;
                        }
                    case 4:
                        {
                            hash = Input();
                            hashTable.ChangeHashFunction(hash);
                            Console.WriteLine("Hash function was changed!");
                            break;
                        }
                }
            }
        }
    }
}