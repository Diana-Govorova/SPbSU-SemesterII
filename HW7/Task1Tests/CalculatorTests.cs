using NUnit.Framework;

namespace Task1
{
	public class CalculatorTests
	{
		private CalculatorLogic calculator;

		[SetUp]
		public void Setup()
		{
			calculator = new CalculatorLogic();
		}

		[Test]
		public void AdditionTest()
		{
			calculator.Symbol = '+';
			calculator.FirstNumber = 15;
			calculator.SecondNumber = 60;

			calculator.Operation();

			Assert.AreEqual(75, calculator.FirstNumber);
		}

		[Test]
		public void SubtractionTest()
		{
			calculator.Symbol = '-';
			calculator.FirstNumber = 11;
			calculator.SecondNumber = 14;

			calculator.Operation();

			Assert.AreEqual(-3, calculator.FirstNumber);
		}

		[Test]
		public void MultiplicationTest()
		{
			calculator.Symbol = '*';
			calculator.FirstNumber = 11;
			calculator.SecondNumber = 5;

			calculator.Operation();

			Assert.AreEqual(55, calculator.FirstNumber);
		}

		[Test]
		public void  DivisionTest()
		{
			calculator.Symbol = '/';
			calculator.FirstNumber = 12;
			calculator.SecondNumber = 4;

			calculator.Operation();

			Assert.AreEqual(3, calculator.FirstNumber);
		}

		[Test]
		public void SqrtTest()
		{
			double result = 0;
			calculator.FirstNumber = 169;
			
			calculator.SqrtMath(result);

			Assert.AreEqual(13, calculator.FirstNumber);
		}
		[Test]
		public void PercentTest()
		{
			calculator.Symbol = '%';
			calculator.FirstNumber = 5;
			calculator.SecondNumber = 8;

			calculator.Operation();

			Assert.AreEqual(0.4, calculator.FirstNumber, 0.0001);
		}

		[Test]
		public void RemoveTest()
		{
			calculator.FirstNumber = 5;

			double result = 0;

			calculator.DivisedOfOne(result);

			Assert.AreEqual(0.2, calculator.FirstNumber, 0.0000001);
		}

		[Test]
		public void DivisionOfOneTest()
		{
			double result = 0;
			calculator.FirstNumber = 5;
			calculator.DivisedOfOne(result);

			Assert.AreEqual(0.2, calculator.FirstNumber, 0.001);
		}
	}
}