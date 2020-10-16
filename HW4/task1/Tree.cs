using System.Data;

namespace Task1
{
	/// <summary>
	/// Class with an implementation of the tree.
	/// </summary>
	public class Tree
	{
		private INode tree;

		/// <summary>
		/// checking expression for correctness.
		/// </summary>
		/// <param name="expression">Input expression.</param>
		/// <returns>Is correct.</returns>
		public bool IsCorrectExpression(string expression)
		{
			int amountOfValues = 0;

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == ' ' || expression[i] == ')' || expression[i] == '(')
				{
					continue;
				}
				else if (char.IsDigit(expression[i]))
				{
					GetNumber(ref i, expression);
					amountOfValues++;
					continue;
				}
				else if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
				{
					amountOfValues--;
				}
				else
				{
					return false;
				}
			}

			return amountOfValues != 0;
		}

		/// <summary>
		/// Create the tree.
		/// </summary>
		/// <param name="inputString">Input string.</param>
		public void BuildTree(string inputString)
		{
			if (!IsCorrectExpression(inputString))
			{
				throw new InvalidExpressionException();
			}

			int counter = 0;
			tree = AddElement(inputString, ref counter);
		}

		/// <summary>
		/// Get operation.
		/// </summary>
		/// <param name="operation">Name of operation.</param>
		/// <returns>Operation.</returns>
		private static Operation ChooseOperation(char operation)
		{
			if (operation == '+')
			{
				return new Addition();
			}
			if (operation == '-')
			{
				return new Substraction();
			}
			if (operation == '*')
			{
				return new Multiplication();
			}
			if (operation == '/')
			{
				return new Division();
			}

			throw new InvalidExpressionException();
		}

		/// <summary>
		/// Add element.
		/// </summary>
		/// <param name="inputString">Expression string.</param>
		/// <param name="counter">Counter.</param>
		/// <returns>Tree element.</returns>
		private INode AddElement(string inputString, ref int counter)
		{
			if (counter == inputString.Length)
			{
				return null;
			}

			while (inputString[counter] == '(' || inputString[counter] == ')' || inputString[counter] == ' ')
			{
				counter++;
				if (counter == inputString.Length)
				{
					return null;
				}
			}

			if (char.IsDigit(inputString[counter]))
			{
				int value = GetNumber(ref counter, inputString);
				return new Number(value);
			}
			else
			{
				char operation = inputString[counter];
				counter++;
				Operation newElement = ChooseOperation(operation);
				newElement.Left = AddElement(inputString, ref counter);
				newElement.Right = AddElement(inputString, ref counter);
				return newElement;
			}
		}

		/// <summary>
		/// Get number.
		/// </summary>
		/// <param name="position">Position of element.</param>
		/// <param name="expression">Input expression.</param>
		/// <returns>Element.</returns>
		private static int GetNumber(ref int position, string expression)
		{
			string value = null;

			while (char.IsDigit(expression[position]))
			{
				value += expression[position];
				position++;
			}

			return int.Parse(value);
		}

		/// <summary>
		/// Counting expression.
		/// </summary>
		/// <returns>Result of expression.</returns>
		public double Counting() 
			=> tree.Counting();

		/// <summary>
		/// Print expression.
		/// </summary>
		public void PrintTree() 
			=> tree.Print();
	}
}