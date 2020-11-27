using NUnit.Framework;

namespace Task1
{
	public class MultiplicationTests
	{
		private Multiplication multiplication;
		private Number left;
		private Number right;

		[SetUp]
		public void Setup()
		{
			multiplication = new Multiplication();
			left = new Number(1);
			right = new Number(1);
			multiplication.Left = left;
			multiplication.Right = right;
		}

		[Test]
		public void MultiplicationTest()
		{
			left.Value = 3;
			right.Value = 12;
			Assert.AreEqual(36, multiplication.Counting());
		}

		[Test]
		public void MultiplicationOfLargeValuesTest()
		{
			left.Value = 1000000;
			right.Value = 10000;
			Assert.AreEqual(10000000000, multiplication.Counting());
		}

		[Test]
		public void MultiplicationOfNegativeValuesTest()
		{
			left.Value = -3;
			right.Value = -2;
			Assert.AreEqual(6, multiplication.Counting());
		}

		[Test]
		public void MultiplicationOfDoubleValuesTest()
		{
			left.Value = 3.6;
			right.Value = 0.5;
			Assert.AreEqual(1.8, multiplication.Counting());
		}
	}
}
