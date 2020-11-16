using System;
using System.Data;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var tree = new Tree();
				tree.BuildTree("( * ( + 1 1 ) 2 )");
				Console.WriteLine(tree.Counting());
			}

			catch (DivideByZeroException)
			{
				Console.WriteLine("Invalid expression");
			}

			catch (InvalidExpressionException)
			{
				Console.WriteLine("Invalid expression");
			}
		}
	}
}
