using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList alphabet = new LinkedList();
            int position = 0;
            for (int i = 97; i < 123; i++)
            {
                alphabet.AddNodeByPosition(position, (char)i);
                position++;
            }

            Console.Write("Input string: ");
            string str = Console.ReadLine();
            int[] arrayOfIndex = new int[100];
            int[] arrayOfIndextMTF = new int[100];

            arrayOfIndex = alphabet.MoveToFrontFunction(arrayOfIndextMTF, str);
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine(arrayOfIndex[i]);
            }
        }
    }
}
