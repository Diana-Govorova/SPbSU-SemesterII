using System;

namespace Task1
{
	/// <summary>
	/// Сlass that implements the basic functions of a calculator.
	/// </summary>
	public class CalculatorLogic
	{
		private double result = 0;
		public double FirstNumber { get; set; } = 0;
		public double SecondNumber { get; set; } = 0;
		internal bool IsContainDot { get; set; }
		public char Symbol { get; set; } = ' ';
		internal bool IsOperationPressedEarly { get; set; }
		internal bool IsEqualPressed { get; set; }
		internal bool IsDelete { get; set; }

		internal void EqualButtonPressed()
		{
			Operation();
			IsOperationPressedEarly = false;
			IsEqualPressed = true;
		}

		public void Operation()
		{
			switch (Symbol)
			{
				case '+':
					{
						result = FirstNumber + SecondNumber;
						break;
					}
				case '-':
					{
						result = FirstNumber - SecondNumber;
						break;
					}
				case '*':
					{
						result = FirstNumber * SecondNumber;
						break;
					}
				case '/':
					{
						result = FirstNumber / SecondNumber;
						break;
					}
				case '%':
					{
						result = FirstNumber * SecondNumber / 100;
						break;
					}
			}
			FirstNumber = result;
		}

		public void Remove()
		{
			FirstNumber = 0;
			SecondNumber = 0;
		}

		public void SqrtMath(double resultOfSqrt)
		{
			resultOfSqrt = Math.Sqrt(FirstNumber);
			FirstNumber = resultOfSqrt;
		}

		public void DivisedOfOne(double resultDivisedOfOne)
		{
			resultDivisedOfOne = 1 / FirstNumber;
			FirstNumber = resultDivisedOfOne;
		}
	}
}
