using System;

namespace Task1
{
	public class Division : Operation
	{
		/// <summary>
		/// Sign of division.
		/// </summary>
		protected override char OperationSign { get; } = '/';

		/// <summary>
		/// Division's operation.
		/// </summary>
		/// <returns>Result of operation.</returns>
		public override double Counting()
		{
			double value1 = Left.Counting();
			double value2 = Right.Counting();
			if (value2 == 0)
			{
				throw new DivideByZeroException();
			}
			return value1 / value2;
		}
	}
}
